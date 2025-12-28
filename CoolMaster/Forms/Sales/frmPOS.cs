using CoolMaster.Common;
using CoolMaster.Data.Repositories;
using CoolMaster.DTOs;
using CoolMaster.Model;
using CoolMaster.Services;
using CoolMaster.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoolMaster.Forms.Sales
{
    public partial class frmPOS : Form
    {
        private readonly POSService _posService;
        private readonly CustomerService _customerService;

        // Quản lý giỏ hàng
        private BindingList<CartItemDTO> _cartItems = new BindingList<CartItemDTO>();
        private List<POSProductDTO> _allProducts = new List<POSProductDTO>();
        private List<POSProductDTO> _filteredProducts = new List<POSProductDTO>();
        private AutoCompleteStringCollection _customerAutoSource = new AutoCompleteStringCollection();

        private Customer _selectedCustomer;
        private int _currentStaffId = 1;

        public frmPOS(POSService posService, CustomerService custService)
        {
            InitializeComponent();
            _posService = posService;
            _customerService = custService;

            _cartItems = new BindingList<CartItemDTO>();
            _allProducts = new List<POSProductDTO>();
            _filteredProducts = new List<POSProductDTO>();
            _customerAutoSource = new AutoCompleteStringCollection();

            InitializeCustomControl();
            SetupPaymentCombo();
        }

        private void SetupPaymentCombo()
        {
            // Nạp danh sách từ Enum
            cboPaymentMethod.Items.Add("Tiền mặt");
            cboPaymentMethod.Items.Add("Chuyển khoản");
            cboPaymentMethod.Items.Add("Thẻ (POS)");
            cboPaymentMethod.SelectedIndex = 0; // Mặc định tiền mặt

            cboPaymentMethod.BackColor = Color.Transparent;
            cboPaymentMethod.DrawMode = DrawMode.OwnerDrawFixed;
            cboPaymentMethod.DropDownStyle = ComboBoxStyle.DropDownList;

            cboPaymentMethod.BorderRadius = 10; 
            cboPaymentMethod.BorderThickness = 1;
            cboPaymentMethod.FillColor = Color.White;
            cboPaymentMethod.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

            cboPaymentMethod.TextAlign = HorizontalAlignment.Left;
        }

        private void InitializeCustomControl()
        {
            dgvInvoice.AutoGenerateColumns = false;
            dgvInvoice.DataSource = _cartItems;

            if (dgvInvoice.Columns["colCustomer"] == null)
            {
                DataGridViewTextBoxColumn colCust = new DataGridViewTextBoxColumn();
                colCust.Name = "colCustomer";
                colCust.HeaderText = "Khách hàng";
                colCust.DataPropertyName = "CustomerName"; // Map với DTO
                colCust.ReadOnly = true;
                dgvInvoice.Columns.Insert(1, colCust); // Chèn vào vị trí thứ 2
            }
            else
            {
                dgvInvoice.Columns["colCustomer"].DataPropertyName = "CustomerName";
            }

            // Map các cột khác
            dgvInvoice.Columns["colId"].DataPropertyName = "ProductId";
            dgvInvoice.Columns["colName"].DataPropertyName = "ProductName";
            dgvInvoice.Columns["colQty"].DataPropertyName = "Quantity";
            dgvInvoice.Columns["colPrice"].DataPropertyName = "UnitPrice";
            dgvInvoice.Columns["colTotal"].DataPropertyName = "TotalPrice";

            dgvInvoice.Columns["colPrice"].DefaultCellStyle.Format = "N0";
            dgvInvoice.Columns["colTotal"].DefaultCellStyle.Format = "N0";
            dgvInvoice.Columns["colQty"].ReadOnly = false;

            // --- 2. Cấu hình Autocomplete cho ô Tìm khách hàng ---
            txtCustomerSearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtCustomerSearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtCustomerSearch.AutoCompleteCustomSource = _customerAutoSource;
        }

        private async void frmPOS_Load(object sender, EventArgs e)
        {
            await LoadCategories();
            await LoadProducts();
            await LoadCustomerSuggestions();

            txtSearchProduct.Focus();
        }

        private async Task LoadCustomerSuggestions()
        {
            // Lấy tất cả khách hàng (chỉ lấy Tên và SĐT cho nhẹ)
            var customers = await _posService.SearchCustomers("");

            _customerAutoSource.Clear();
            foreach (var c in customers)
            {
                // Gợi ý theo: "Tên - SĐT"
                _customerAutoSource.Add($"{c.FullName} - {c.PhoneNumber}");
                // Gợi ý thêm SĐT riêng
                _customerAutoSource.Add(c.PhoneNumber);
            }
        }

        private async Task LoadCategories()
        {
            var categories = await _posService.GetCategories();
            var list = categories.ToList();
            list.Insert(0, new Category { CategoryId = 0, CategoryName = "Tất cả" });

            cboCategory.DataSource = list;
            cboCategory.DisplayMember = "CategoryName";
            cboCategory.ValueMember = "CategoryId";
        }

        private async Task LoadProducts()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                // Lấy tất cả sản phẩm 1 lần để cache client
                _allProducts = await _posService.GetProductsForPOS();

                // Mặc định hiển thị tất cả
                ApplyFilter();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải sản phẩm: " + ex.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void ApplyFilter()
        {
            string keyword = txtSearchProduct.Text.Trim().ToLower();
            string selectedCatName = cboCategory.Text.Trim();
            bool isFilterCat = cboCategory.SelectedIndex > 0;

            var query = _allProducts.AsEnumerable();

            if (isFilterCat)
            {
                query = query.Where(p => !string.IsNullOrEmpty(p.CategoryName) &&
                                         p.CategoryName.Equals(selectedCatName, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(p =>
                    (p.ProductName != null && p.ProductName.ToLower().Contains(keyword)) ||
                    (p.Barcode != null && p.Barcode.ToLower().Contains(keyword)));
            }

            _filteredProducts = query.ToList();
            RenderProductList(_filteredProducts);
        }

        private void RenderProductList(List<POSProductDTO> products)
        {
            flpProducts.Controls.Clear();
            flpProducts.SuspendLayout();

            foreach (var p in products.Take(50))
            {
                if (p.StockCounter <= 0) continue;

                var pnl = new Panel
                {
                    Width = 130,
                    Height = 180,
                    Margin = new Padding(10),
                    BackColor = Color.White,
                    Cursor = Cursors.Hand,
                    Tag = p
                };
                pnl.Click += ProductItem_Click;

                var pic = new PictureBox
                {
                    Dock = DockStyle.Top,
                    Height = 100,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    BackColor = Color.WhiteSmoke,
                    Tag = p
                };

                if (!string.IsNullOrEmpty(p.ImageUrl))
                {
                    // Lấy ảnh từ Resources dựa vào tên (VD: "maylanh1")
                    object img = Properties.Resources.ResourceManager.GetObject(p.ImageUrl);
                    pic.Image = (img as Image) ?? Properties.Resources.no_image;
                }
                else
                {
                    pic.Image = Properties.Resources.no_image;
                }

                var lblName = new Label
                {
                    Text = p.ProductName,
                    Dock = DockStyle.Top,
                    Height = 40,
                    Font = new Font("Segoe UI", 9, FontStyle.Regular),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Tag = p
                };
                lblName.Click += (s, e) => { ProductItem_Click(pnl, e); };

                var lblPrice = new Label
                {
                    Text = $"{p.UnitPrice:N0}đ\n(SL: {p.StockCounter})",
                    Dock = DockStyle.Bottom,
                    Height = 40,
                    Font = new Font("Segoe UI", 9, FontStyle.Bold),
                    ForeColor = Color.DarkBlue,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Tag = p
                };
                lblPrice.Click += (s, e) => { ProductItem_Click(pnl, e); };

                pnl.Controls.Add(lblName);
                pnl.Controls.Add(pic);
                pnl.Controls.Add(lblPrice);

                flpProducts.Controls.Add(pnl);
            }

            flpProducts.ResumeLayout();
        }

        private void ProductItem_Click(object sender, EventArgs e)
        {
            POSProductDTO product = null;
            if (sender is Control c && c.Tag is POSProductDTO p)
            {
                product = p;
            }

            if (product == null) return;

            using (var frm = new frmQuantityInput(product.ProductName))
            {
                // Nếu người dùng nhấn OK (Xác nhận)
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    int qty = frm.Quantity;
                    // 3. Gọi hàm thêm vào giỏ với số lượng đã nhập
                    if (qty > 0)
                    {
                        AddToCart(product, qty);
                    }
                }
            }
        }

        private void AddToCart(POSProductDTO product, int quantityToAdd = 1)
        {
            if (product.StockCounter < 1)
            {
                MessageBox.Show("Sản phẩm đã hết hàng tại quầy.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var existingItem = _cartItems.FirstOrDefault(x => x.ProductId == product.ProductId);

            if (existingItem != null)
            {
                // Validate tồn kho: SL hiện tại trong giỏ + SL mới thêm > Tồn kho thực tế
                if (existingItem.Quantity + quantityToAdd > product.StockCounter)
                {
                    MessageBox.Show($"Không đủ hàng! Kho chỉ còn {product.StockCounter}.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Cộng dồn
                existingItem.Quantity += quantityToAdd;

                // Reset Binding để Grid cập nhật lại cột Thành tiền
                _cartItems.ResetBindings();
            }
            else
            {
                // Validate số lượng nhập vào > Tồn kho
                if (quantityToAdd > product.StockCounter)
                {
                    MessageBox.Show($"Không đủ hàng! Kho chỉ còn {product.StockCounter}.", "Cảnh báo");
                    return;
                }

                _cartItems.Add(new CartItemDTO
                {
                    ProductId = product.ProductId,
                    ProductName = product.ProductName,
                    UnitPrice = product.UnitPrice,
                    Quantity = quantityToAdd, // Sử dụng số lượng nhập từ Form
                    CurrentStock = product.StockCounter,
                    CustomerName = _selectedCustomer?.FullName ?? "Khách lẻ"
                });
            }

            CalculateTotal();
        }

        private void CalculateTotal()
        {
            decimal total = _cartItems.Sum(x => x.TotalPrice);
            lblTotalMoney.Text = $"{total:N0} đ";
        }

        private void dgvInvoice_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu cột được sửa là cột Số lượng (colQty)
            if (dgvInvoice.Columns[e.ColumnIndex].Name == "colQty")
            {
                var row = dgvInvoice.Rows[e.RowIndex];
                var item = (CartItemDTO)row.DataBoundItem;

                // 1. Validate số âm hoặc 0
                if (item.Quantity <= 0)
                {
                    MessageBox.Show("Số lượng phải lớn hơn 0. Nếu muốn xóa hãy dùng nút Xóa (hoặc phím Delete).");
                    item.Quantity = 1; // Reset về 1
                }
                // 2. Validate tồn kho
                else if (item.Quantity > item.CurrentStock)
                {
                    MessageBox.Show($"Số lượng vượt quá tồn kho! (Tồn: {item.CurrentStock})");
                    item.Quantity = item.CurrentStock; // Reset về max tồn kho
                }

                _cartItems.ResetBindings(); // Cập nhật lại Grid
                CalculateTotal();
            }
        }

        private async void btnPay_Click(object sender, EventArgs e)
        {
            if (_cartItems.Count == 0)
            {
                MessageBox.Show("Giỏ hàng đang trống!", "Thông báo");
                return;
            }

            if (MessageBox.Show($"Xác nhận thanh toán {lblTotalMoney.Text}?", "Thanh toán", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Lấy phương thức từ ComboBox
                PaymentMethod method = (PaymentMethod)cboPaymentMethod.SelectedIndex;

                // Gọi hàm xử lý chung với trạng thái HOÀN THÀNH
                await HandleCheckout(OrderStatus.Completed, method);
            }
        }

        private void OpenBillForm(int orderId)
        {
            try
            {
                // Lấy chuỗi kết nối từ cấu hình (để tạo OrderService mới)
                string connStr = ConfigurationManager.ConnectionStrings["CoolMasterConnString"].ConnectionString;

                // Khởi tạo các lớp cần thiết cho frmBill
                IOrderRepository orderRepo = new OrderRepository(connStr);
                OrderService orderService = new OrderService(orderRepo);

                // Mở Form
                using (var frm = new frmBill(orderService, orderId))
                {
                    frm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể mở form in hóa đơn: " + ex.Message);
            }
        }

        private void txtSearchProduct_TextChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter && txtSearchProduct.Focused)
            {
                string barcode = txtSearchProduct.Text.Trim();
                if (!string.IsNullOrEmpty(barcode))
                {
                    var product = _allProducts.FirstOrDefault(p => p.Barcode.Equals(barcode, StringComparison.OrdinalIgnoreCase));
                    if (product != null)
                    {
                        AddToCart(product);
                        txtSearchProduct.Clear();
                        return true; // Đã xử lý xong, chặn tiếp tục
                    }
                }
            }

            // Nếu focus ở ô KHÁCH HÀNG, trả về false để sự kiện KeyDown của nó được chạy
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private async void txtCustomerSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string input = txtCustomerSearch.Text.Trim();
                if (string.IsNullOrEmpty(input)) return;

                // Tách SĐT nếu người dùng chọn từ gợi ý "Tên - SĐT"
                string keyword = input;
                if (input.Contains("-"))
                {
                    var parts = input.Split('-');
                    if (parts.Length > 1) keyword = parts[1].Trim(); // Lấy phần SĐT
                }

                Cursor = Cursors.WaitCursor;
                var customers = await _posService.SearchCustomers(keyword);
                Cursor = Cursors.Default;

                var cust = customers.FirstOrDefault();

                if (cust != null)
                {
                    SetSelectedCustomer(cust);
                }
                else
                {
                    if (MessageBox.Show("Khách hàng chưa tồn tại. Thêm mới ngay?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        btnAddCustomer_Click(null, null); // Gọi hàm mở form thêm
                    }
                }
            }
        }

        private void SetSelectedCustomer(Customer cust)
        {
            _selectedCustomer = cust;
            txtCustomerSearch.Text = $"{cust.FullName} - {cust.PhoneNumber}";

            foreach (var item in _cartItems)
            {
                item.CustomerName = cust.FullName;
            }
            // Refresh Grid
            dgvInvoice.Refresh();

            MessageBox.Show($"Đã chọn khách: {cust.FullName}");
        }

        private void btnScanBarcode_Click(object sender, EventArgs e)
        {
            txtSearchProduct.Focus();
            txtSearchProduct.SelectAll();
        }

        private async void btnCancel_Click(object sender, EventArgs e)
        {
            if (_cartItems.Count == 0) return;

            var dr = MessageBox.Show("Xác nhận HỦY đơn hàng và ghi vào lịch sử?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                PaymentMethod method = (PaymentMethod)cboPaymentMethod.SelectedIndex;
                await HandleCheckout(OrderStatus.Cancelled, method);
            }
        }

        private async Task HandleCheckout(OrderStatus status, PaymentMethod method)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                var request = new CheckoutRequestDTO
                {
                    CustomerId = _selectedCustomer?.CustomerId,
                    StaffId = _currentStaffId,
                    Items = _cartItems.ToList(),
                    TotalAmount = _cartItems.Sum(x => x.TotalPrice)
                };

                // GỌI SERVICE (Đã truyền đủ 3 tham số: request, status, method)
                int newOrderId = await _posService.Checkout(request, status, method);

                // HIỂN THỊ THÔNG BÁO
                string successMsg = status == OrderStatus.Completed ? "Thanh toán thành công!" : "Đã lưu đơn Hủy vào hệ thống.";
                MessageBox.Show(successMsg, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // RESET GIAO DIỆN
                _cartItems.Clear();
                CalculateTotal();
                _selectedCustomer = null;
                txtCustomerSearch.Text = "";
                txtSearchProduct.Text = "";

                // --- ĐẢM BẢO WORKFLOW CỦA BẠN ---

                // 1. Reload lại kho vì số lượng đã thay đổi
                await LoadProducts();

                // 2. Nếu là đơn thành công thì mới mở Form hóa đơn
                if (status == OrderStatus.Completed)
                {
                    OpenBillForm(newOrderId);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xử lý: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            string phoneDraft = txtCustomerSearch.Text.Trim();

            using (var frm = new frmAddCustomer(_customerService, phoneDraft))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    var newCust = frm.NewCustomer;
                    // Reload lại gợi ý để có khách mới
                    _ = LoadCustomerSuggestions();
                    // Chọn luôn khách vừa tạo
                    SetSelectedCustomer(newCust);
                }
            }
        }
    }
}
