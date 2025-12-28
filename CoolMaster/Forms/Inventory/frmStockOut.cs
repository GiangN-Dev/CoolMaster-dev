using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoolMaster.DTOs;
using CoolMaster.Services;
using CoolMaster.Utils;

namespace CoolMaster.Forms.Inventory
{
    public partial class frmStockOut : Form
    {
        private readonly InventoryService _inventoryService;
        private readonly int _currentUserId;

        private BindingList<StockOutItemDTO> _exportBinding;
        private List<InventoryViewDTO> _products = new List<InventoryViewDTO>();

        private CancellationTokenSource _searchCts;

        // sorters
        private DataGridViewSorter<InventoryViewDTO> _prodSorter;
        private DataGridViewSorter<StockOutItemDTO> _exportSorter;

        public frmStockOut(InventoryService inventoryService, int currentUserId)
        {
            if (inventoryService == null) throw new ArgumentNullException(nameof(inventoryService));

            InitializeComponent();

            _inventoryService = inventoryService;
            _currentUserId = currentUserId;

            _exportBinding = new BindingList<StockOutItemDTO>();
            SetupGrids();
            HookEvents();

            // initial load
            _ = LoadProductsAsync();
        }

        private void HookEvents()
        {
            txtSearchProduct.TextChanged += txtSearchProduct_TextChanged;
            dgvProducts.CellDoubleClick += dgvProducts_CellDoubleClick;
            dgvExportItems.CellContentClick += dgvExportItems_CellContentClick;
            dgvExportItems.CellEndEdit += dgvExportItems_CellEndEdit;
            btnSave.Click += btnSave_Click;
            btnCancel.Click += btnCancel_Click;

            // update export sorter when binding list changes
            _exportBinding.ListChanged += (s, e) => _exportSorter?.UpdateItems(_exportBinding.ToList());
        }

        private void SetupGrids()
        {
            // Products grid
            dgvProducts.AutoGenerateColumns = false;
            dgvProducts.Columns.Clear();

            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Mã vạch", DataPropertyName = nameof(InventoryViewDTO.Barcode), Width = 120 });
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Tên sản phẩm", DataPropertyName = nameof(InventoryViewDTO.ProductName), Width = 240 });
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Danh mục", DataPropertyName = nameof(InventoryViewDTO.CategoryName), Width = 120 });
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Kho (SL)", DataPropertyName = nameof(InventoryViewDTO.StockWarehouse), Width = 80, DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter } });
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Quầy (SL)", DataPropertyName = nameof(InventoryViewDTO.StockCounter), Width = 80, DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter } });
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "ĐVT", DataPropertyName = nameof(InventoryViewDTO.Unit), Width = 60 });

            // Export items grid
            dgvExportItems.AutoGenerateColumns = false;
            dgvExportItems.Columns.Clear();

            dgvExportItems.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Mã vạch", DataPropertyName = nameof(StockOutItemDTO.Barcode), Width = 100, ReadOnly = true });
            dgvExportItems.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Sản phẩm", DataPropertyName = nameof(StockOutItemDTO.ProductName), Width = 160, ReadOnly = true });
            dgvExportItems.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "ĐVT", DataPropertyName = nameof(StockOutItemDTO.Unit), Width = 60, ReadOnly = true });

            var qtyCol = new DataGridViewTextBoxColumn { HeaderText = "SL", DataPropertyName = nameof(StockOutItemDTO.Quantity), Width = 60 };
            dgvExportItems.Columns.Add(qtyCol);

            var priceCol = new DataGridViewTextBoxColumn { HeaderText = "Đơn giá", DataPropertyName = nameof(StockOutItemDTO.Price), Width = 90, DefaultCellStyle = { Format = "N2", Alignment = DataGridViewContentAlignment.MiddleRight } };
            dgvExportItems.Columns.Add(priceCol);

            var totalCol = new DataGridViewTextBoxColumn { HeaderText = "Thành tiền", DataPropertyName = nameof(StockOutItemDTO.Total), Width = 100, ReadOnly = true, DefaultCellStyle = { Format = "N2", Alignment = DataGridViewContentAlignment.MiddleRight } };
            dgvExportItems.Columns.Add(totalCol);

            var btnDel = new DataGridViewButtonColumn { HeaderText = "", Text = "Xóa", UseColumnTextForButtonValue = true, Width = 60 };
            dgvExportItems.Columns.Add(btnDel);

            // create sorters after columns created
            _prodSorter = new DataGridViewSorter<InventoryViewDTO>(dgvProducts);
            _exportSorter = new DataGridViewSorter<StockOutItemDTO>(dgvExportItems);

            // initial bind export list
            _exportSorter.UpdateItems(_exportBinding.ToList());
        }

        private async Task LoadProductsAsync()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                var res = await _inventoryService.GetInventoryList(txtSearchProduct.Text.Trim(), null, 1, 200);
                _products = res.Items?.ToList() ?? new List<InventoryViewDTO>();

                // bind via sorter
                _prodSorter.UpdateItems(_products);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void dgvProducts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var prod = dgvProducts.Rows[e.RowIndex].DataBoundItem as InventoryViewDTO;
            if (prod == null) return;

            var exist = _exportBinding.FirstOrDefault(x => x.ProductId == prod.ProductId);
            if (exist != null)
            {
                exist.Quantity += 1;
            }
            else
            {
                var item = new StockOutItemDTO
                {
                    ProductId = prod.ProductId,
                    Barcode = prod.Barcode,
                    ProductName = prod.ProductName,
                    Unit = prod.Unit,
                    Quantity = 1,
                    Price = prod.UnitPrice
                };
                _exportBinding.Add(item);
            }

            // update export sorter
            _exportSorter.UpdateItems(_exportBinding.ToList());
            RefreshTotal();
        }

        private void dgvExportItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Delete button column is last
            if (dgvExportItems.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                var item = dgvExportItems.Rows[e.RowIndex].DataBoundItem as StockOutItemDTO;
                if (item != null)
                {
                    _exportBinding.Remove(item);
                    _exportSorter.UpdateItems(_exportBinding.ToList());
                    RefreshTotal();
                }
            }
        }

        private void dgvExportItems_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Validate numeric edits (Quantity and Price)
            var row = dgvExportItems.Rows[e.RowIndex];
            var item = row.DataBoundItem as StockOutItemDTO;
            if (item == null) return;

            // Ensure quantity >= 1
            if (item.Quantity <= 0)
            {
                MessageBox.Show("Số lượng phải là số nguyên dương.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                item.Quantity = 1;
            }

            if (item.Price < 0m)
            {
                MessageBox.Show("Đơn giá không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                item.Price = 0m;
            }

            _exportSorter.UpdateItems(_exportBinding.ToList());
            RefreshTotal();
        }

        private void RefreshTotal()
        {
            decimal total = _exportBinding.Sum(x => x.Total);
            lblTotalMoney.Text = $"{total:N0} đ";
        }

        private async void txtSearchProduct_TextChanged(object sender, EventArgs e)
        {
            _searchCts?.Cancel();
            _searchCts = new CancellationTokenSource();
            try
            {
                await Task.Delay(300, _searchCts.Token);
                await LoadProductsAsync();
            }
            catch (TaskCanceledException) { }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (_exportBinding.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một sản phẩm để xuất kho.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var request = new StockOutRequestDTO
            {
                
                UserId = _currentUserId,
                Items = _exportBinding.ToList()
            };

            if (MessageBox.Show($"Xác nhận xuất {_exportBinding.Count} dòng hàng? Tổng: {lblTotalMoney.Text}", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            Cursor = Cursors.WaitCursor;
            try
            {
                foreach (var it in request.Items)
                {
                    await _inventoryService.TransferToCounter(it.ProductId, it.Quantity, $"Xuất kho: {request.Reason}; Người nhận: {request.Receiver}", request.UserId);
                }

                MessageBox.Show("Xuất kho xử lý xong.", "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất kho: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
