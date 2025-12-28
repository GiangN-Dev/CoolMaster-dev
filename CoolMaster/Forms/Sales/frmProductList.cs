using CoolMaster.Common;
using CoolMaster.Data.Repositories;
using CoolMaster.DTOs;
using CoolMaster.Forms.Sales;
using CoolMaster.Model;
using CoolMaster.Services;
using CoolMaster.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoolMaster.Forms.Sales
{
    public partial class frmProductList : Form
    {
        private readonly ProductService _productService;
        private BindingSource _bindingSource = new BindingSource(); 
        private CancellationTokenSource _searchCts;

        private string _currentKeyword = "";

        // Sorter
        private DataGridViewSorter<ProductViewDTO> _gridSorter;

        // add button fields
        private FontAwesome.Sharp.IconButton btnExportProducts;
        private FontAwesome.Sharp.IconButton btnImportProducts;

        public frmProductList(ProductService service)
        {
            InitializeComponent();
            _productService = service ?? throw new ArgumentNullException(nameof(service));
            InitializeGrid();
            
            ucPager.OnPageChanged += async (s, e) =>
            {
                await LoadData(_currentKeyword, e.PageIndex, e.PageSize);
            };

            dgvProducts.Resize += (s, e) => ucPager.CalculatePageSize(dgvProducts);
        
        }

        private void DgvProducts_Resize(object sender, EventArgs e)
        {
            //Gọi hàm tính toán của UC, truyền DataGridView vào
            ucPager.CalculatePageSize(dgvProducts);
        }

        private void InitializeGrid()
        {
            // 1. Cấu hình cơ bản
            dgvProducts.AutoGenerateColumns = false; // QUAN TRỌNG: Tắt tự sinh cột
            dgvProducts.DataSource = _bindingSource; // Gán nguồn dữ liệu qua BindingSource (kept for compatibility)
            dgvProducts.ReadOnly = true;
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.AllowUserToAddRows = false;
            dgvProducts.AllowUserToResizeRows = false;
            dgvProducts.RowHeadersVisible = false;
            dgvProducts.BackgroundColor = Color.WhiteSmoke;
            dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProducts.BorderStyle = BorderStyle.None;
            dgvProducts.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvProducts.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            // 2. Định nghĩa cột (Strong Typing với nameof)
            dgvProducts.Columns.Clear();

            AddColumn("Mã vạch", nameof(ProductViewDTO.Barcode), 100);
            AddColumn("Tên hàng hóa", nameof(ProductViewDTO.ProductName), 300);
            AddColumn("Danh mục", nameof(ProductViewDTO.CategoryName), 150);

            var colUnit = AddColumn("ĐVT", nameof(ProductViewDTO.Unit), 60);
            // Format tiền tệ
            var colPrice = AddColumn("Giá bán", nameof(ProductViewDTO.UnitPrice), 100);
            colPrice.DefaultCellStyle.Format = "N0"; // VD: 120,000
            colPrice.DefaultCellStyle.ForeColor = Color.DarkGreen;

            // Tồn kho
            AddColumn("Kho", nameof(ProductViewDTO.StockWarehouse), 60);
            AddColumn("Quầy", nameof(ProductViewDTO.StockCounter), 60);


            var colTotal = AddColumn("Tổng tồn", nameof(ProductViewDTO.TotalStock), 80);
            colTotal.DefaultCellStyle.Font = new Font(dgvProducts.Font, FontStyle.Bold);
            colTotal.DefaultCellStyle.ForeColor = Color.Blue;


            var colId = AddColumn("ID", nameof(ProductViewDTO.ProductId), 0);
            colId.Visible = false;


            _gridSorter = new DataGridViewSorter<ProductViewDTO>(dgvProducts);
         
            btnExportProducts = new FontAwesome.Sharp.IconButton
            {
                Text = "Xuất CSV",
                IconChar = FontAwesome.Sharp.IconChar.FileExport,
                IconColor = Color.White,
                BackColor = Color.FromArgb(23, 162, 184),
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.White,
                Width = 100,
                Height = 30,
                Left = 120,
                Top = 10
            };
            btnExportProducts.FlatAppearance.BorderSize = 0;
            btnExportProducts.Click += BtnExportProducts_Click;

            // Import products CSV
            btnImportProducts = new FontAwesome.Sharp.IconButton
            {
                Text = "Nhập CSV",
                IconChar = FontAwesome.Sharp.IconChar.FileImport,
                IconColor = Color.Black,
                BackColor = Color.FromArgb(255, 193, 7),
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.Black,
                Width = 100,
                Height = 30,
                Left = 230,
                Top = 10
            };
            btnImportProducts.FlatAppearance.BorderSize = 0;
            btnImportProducts.Click += BtnImportProducts_Click;

            // Add buttons to the Form (positioning top-left - adjust if you have a toolbar panel)
            this.Controls.Add(btnExportProducts);
            this.Controls.Add(btnImportProducts);
        }

        // Helper DRY: Add Column
        private DataGridViewColumn AddColumn(string header, string property, int fillWeight)
        {
            var col = new DataGridViewTextBoxColumn
            {
                HeaderText = header,
                DataPropertyName = property,
                FillWeight = fillWeight <= 0 ? 1 : fillWeight // Nếu truyền vào <= 0 thì tự động đổi thành 1
            };
            dgvProducts.Columns.Add(col);
            return col;
        }


        private async Task LoadData(string keyword, int pageIndex, int pageSize)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                _currentKeyword = keyword;

                // Gọi Service
                var result = await _productService.GetProductList(keyword, pageIndex, pageSize);

                // Bind Data
                _gridSorter.UpdateItems(result.Items?.ToList() ?? new List<ProductViewDTO>());

                // CẬP NHẬT TRẠNG THÁI CHO USER CONTROL
                ucPager.UpdateState(result.TotalCount);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private async void btnFilter_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                var categoriesTask = _productService.GetCategoryNames();
                var brandsTask = _productService.GetBrandNames();
                await Task.WhenAll(categoriesTask, brandsTask);
                Cursor = Cursors.Default;

                using (var frm = new frmProductFilter(categoriesTask.Result, brandsTask.Result))
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        var req = frm.FilterResult;
                        _currentKeyword = req.Keyword;

                        // Gọi tìm kiếm nâng cao
                        // Lưu ý: Cần sửa LoadData để hỗ trợ filter object nếu muốn, 
                        // ở đây demo gọi trực tiếp service và update UC
                        var result = await _productService.SearchProducts(req, 1, ucPager.PageSize);

                    //    _gridSorter.UpdateItems(result.Items?.ToList() ?? new List<ProductViewDTO>());

                        // Reset về trang 1
                        ucPager.ResetToFirstPage();
                        ucPager.UpdateState(result.TotalCount);
                    }
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show("Lỗi bộ lọc: " + ex.Message);
            }
        }

        private async void txtSearch_TextChanged(object sender, EventArgs e)
        {
            _searchCts?.Cancel();
            _searchCts = new CancellationTokenSource();
            try
            {
                await Task.Delay(100, _searchCts.Token);

                // Reset về trang 1 khi tìm kiếm
                ucPager.ResetToFirstPage();
                await LoadData(txtSearch.Text.Trim(), 1, ucPager.PageSize);
            }
            catch (TaskCanceledException) { }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tìm kiếm: {ex.Message}");
            }
        }

    

        private async void frmProductList_Load(object sender, EventArgs e)
        {
            ucPager.CalculatePageSize(dgvProducts);
            // Load trang 1
            await LoadData(_currentKeyword, 1, ucPager.PageSize);
        }

        private void BtnExportProducts_Click(object sender, EventArgs e)
        {
            try
            {
                var items = (_bindingSource.DataSource as IEnumerable<ProductViewDTO>)?.ToList() ?? new List<ProductViewDTO>();
                if (items.Count == 0) return;
                using (var sd = new SaveFileDialog() { Filter = "CSV|*.csv", FileName = $"Products_{DateTime.Now:yyyyMMdd}.csv" })
                {
                    if (sd.ShowDialog() == DialogResult.OK)
                    {
                        ExcelHelper.ExportToCsv(items, sd.FileName);
                        MessageBox.Show("Xuất thành công!");
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        private async void BtnImportProducts_Click(object sender, EventArgs e)
        {
            try
            {
                using (var ofd = new OpenFileDialog())
                {
                    ofd.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                    if (ofd.ShowDialog(this) != DialogResult.OK) return;

                    var rows = ExcelHelper.ImportFromCsv(ofd.FileName, skipHeaderLines: 1);
                    if (rows == null || rows.Count == 0)
                    {
                        MessageBox.Show("File CSV rỗng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Prepare category lookup
                    var conn = ConfigurationManager.ConnectionStrings["CoolMasterConnString"].ConnectionString;
                    var catRepo = new CategoryRepository(conn);
                    var cats = (await catRepo.GetAllAsync()).ToList();

                    var errors = new List<string>();
                    int created = 0;
                    foreach (var r in rows)
                    {
                        if (r.Length == 0) continue;
                        try
                        {
                            string barcode = r.Length > 0 ? r[0].Trim() : "";
                            string name = r.Length > 1 ? r[1].Trim() : "";
                            string catName = r.Length > 2 ? r[2].Trim() : "";
                            string unit = r.Length > 3 ? r[3].Trim() : "Cái";
                            string priceStr = r.Length > 4 ? r[4].Trim() : "0";
                            string swStr = r.Length > 5 ? r[5].Trim() : "0";
                            string scStr = r.Length > 6 ? r[6].Trim() : "0";
                            string brand = r.Length > 7 ? r[7].Trim() : "";
                            string warrantyStr = r.Length > 8 ? r[8].Trim() : "0";
                            string desc = r.Length > 9 ? r[9].Trim() : "";

                            if (string.IsNullOrWhiteSpace(barcode) || string.IsNullOrWhiteSpace(name))
                            {
                                errors.Add("Thiếu barcode hoặc tên: bỏ qua dòng.");
                                continue;
                            }

                            if (!decimal.TryParse(priceStr, out decimal price) || price < 0)
                            {
                                errors.Add($"Barcode {barcode}: Giá không hợp lệ '{priceStr}'.");
                                continue;
                            }

                            if (!int.TryParse(swStr, out int sw) || sw < 0)
                            {
                                errors.Add($"Barcode {barcode}: Tồn kho (Kho) không hợp lệ '{swStr}'.");
                                continue;
                            }

                            if (!int.TryParse(scStr, out int sc) || sc < 0)
                            {
                                errors.Add($"Barcode {barcode}: Tồn kho (Quầy) không hợp lệ '{scStr}'.");
                                continue;
                            }

                            if (!int.TryParse(warrantyStr, out int warranty) || warranty < 0)
                            {
                                errors.Add($"Barcode {barcode}: Thời gian bảo hành không hợp lệ '{warrantyStr}'.");
                                continue;
                            }

                            // Kiểm tra độ dài các trường quan trọng
                            if (barcode.Length > 50 || name.Length > 255 || unit.Length > 10 || brand.Length > 100 || desc.Length > 500)
                            {
                                errors.Add($"Barcode {barcode}: Thông tin không hợp lệ: vượt quá độ dài cho phép.");
                                continue;
                            }

                            var cat = cats.FirstOrDefault(c => string.Equals(c.CategoryName, catName, StringComparison.OrdinalIgnoreCase));
                            int catId = cat?.CategoryId ?? 0;

                            // Create product using constructor that sets stock values (StockWarehouse & StockCounter have private setters)
                            var product = new Product(
                                name,
                                sw,
                                sc,
                                price
                            )
                            {
                                Barcode = barcode,
                                Unit = string.IsNullOrWhiteSpace(unit) ? "Cái" : unit,
                                Brand = brand,
                                WarrantyMonth = warranty,
                                Description = desc,
                                CategoryId = catId
                            };

                            await _productService.CreateProduct(product);
                            created++;
                        }
                        catch (Exception ex)
                        {
                            errors.Add($"Dòng {rows.IndexOf(r) + 2}: " + ex.Message);
                        }
                    }

                    MessageBox.Show($"Đã tạo {created} sản phẩm." + (errors.Count > 0 ? $"\nCó lỗi ở {errors.Count} dòng: {string.Join(", ", errors)}" : ""), "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ucPager.ResetToFirstPage(); // Reset về trang 1
                    await LoadData(_currentKeyword, 1, ucPager.PageSize);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xuất CSV: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
