using CoolMaster.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoolMaster.DTOs;
using CoolMaster.Common;
using System.IO;
using CoolMaster.Utils;

namespace CoolMaster.Forms.Inventory
{
    public partial class frmStockIn : Form
    {
        private readonly InventoryService _inventoryService;
        private int _currentPage = 1;
        private int _totalPages = 0;
        private CancellationTokenSource _searchCts;

        // Sorting state
        private string _sortProperty = null;
        private bool _sortAscending = true;

        // Current page items cached so we can sort client-side
        private List<InventoryViewDTO> _currentItems = new List<InventoryViewDTO>();
        public frmStockIn(InventoryService inventoryService)
        {
            InitializeComponent();
            _inventory_service_null_check(inventoryService);
            _inventoryService = inventoryService ?? throw new ArgumentNullException(nameof(inventoryService));
            SetupGrid();
        }

        // small helper to keep original behavior (no functional change)
        private void _inventory_service_null_check(InventoryService inventoryService)
        {
            // intentionally left for future checks or logging
        }

        private void SetupGrid()
        {
            dgvInventory.AutoGenerateColumns = false;
            dgvInventory.Columns.Clear();

            AddCol("Mã vạch", nameof(InventoryViewDTO.Barcode), 120);
            AddCol("Tên sản phẩm", nameof(InventoryViewDTO.ProductName), 250);
            AddCol("Danh mục", nameof(InventoryViewDTO.CategoryName), 150);

            var colWare = AddCol("Kho (SL)", nameof(InventoryViewDTO.StockWarehouse), 100);
            colWare.DefaultCellStyle.ForeColor = Color.DarkBlue;
            colWare.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            var colCount = AddCol("Quầy (SL)", nameof(InventoryViewDTO.StockCounter), 100);
            colCount.DefaultCellStyle.ForeColor = Color.DarkGreen;
            colCount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            var colTotal = AddCol("Tổng", nameof(InventoryViewDTO.TotalStock), 80);
            colTotal.DefaultCellStyle.Font = new Font(dgvInventory.Font, FontStyle.Bold);
            colTotal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            AddCol("ĐVT", nameof(InventoryViewDTO.Unit), 80);

            // Enable programmatic sort so we can control sort direction and glyph
            foreach (DataGridViewColumn c in dgvInventory.Columns)
            {
                c.SortMode = DataGridViewColumnSortMode.Programmatic;
            }

            // Hook header click for sorting
            dgvInventory.ColumnHeaderMouseClick -= dgvInventory_ColumnHeaderMouseClick;
            dgvInventory.ColumnHeaderMouseClick += dgvInventory_ColumnHeaderMouseClick;
        }

        private DataGridViewColumn AddCol(string header, string prop, int width)
        {
            var col = new DataGridViewTextBoxColumn
            {
                HeaderText = header,
                DataPropertyName = prop,
                Width = width,
                SortMode = DataGridViewColumnSortMode.Programmatic
            };
            dgvInventory.Columns.Add(col);
            return col;
        }

        private async void frmInventory_Load(object sender, EventArgs e)
        {
            await LoadData();
        }

        private async Task LoadData()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                var result = await _inventory_service_GetInventoryListSafe(txtSearch.Text.Trim(), null, _currentPage, 20);

                // Cache current page items so we can sort locally
                _currentItems = result.Items?.ToList() ?? new List<InventoryViewDTO>();

                // Apply any active sort
                if (!string.IsNullOrEmpty(_sortProperty))
                {
                    ApplySortToCurrentItems();
                }

                dgvInventory.DataSource = new BindingList<InventoryViewDTO>(_currentItems);
                _totalPages = result.TotalPages;
                lblPageInfo.Text = $"Trang {_currentPage}/{_totalPages} (Tổng: {result.TotalCount} SP)";

                btnPrev.Enabled = _currentPage > 1;
                btnNext.Enabled = _currentPage < _totalPages;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        // wrapper to call service safely (keeps code clearer)
        private async Task<PagedResult<InventoryViewDTO>> _inventory_service_GetInventoryListSafe(string keyword, int? catId, int page, int size)
        {
            return await _inventoryService.GetInventoryList(keyword, catId, page, size);
        }

        private async void txtSearch_TextChanged(object sender, EventArgs e)
        {
            _searchCts?.Cancel();
            _searchCts = new CancellationTokenSource();
            try
            {
                await Task.Delay(300, _searchCts.Token);
                _currentPage = 1;
                await LoadData();
            }
            catch (TaskCanceledException) { }
        }

        private async void btnPrev_Click(object sender, EventArgs e)
        {
            if (_currentPage > 1)
            {
                _currentPage--;
                await LoadData();
            }
        }

        private async void btnNext_Click(object sender, EventArgs e)
        {
            if (_currentPage < _totalPages)
            {
                _currentPage++;
                await LoadData();
            }
        }

        // Xử lý nút Nhập Kho
        private async void btnImport_Click(object sender, EventArgs e)
        {
            var row = dgvInventory.CurrentRow;
            if (row == null) return;
            var item = (InventoryViewDTO)row.DataBoundItem;
            if (item == null) return;

            // Hiển thị dialog nhập số lượng / supplier / ghi chú
            var input = ShowImportDialog(item.ProductName);
            if (input == null) return; // user hủy

            int qty = input.Value.quantity;
            int? supplierId = input.Value.supplierId;
            string note = input.Value.note;

            try
            {
                Cursor = Cursors.WaitCursor;

                // Tạm thời dùng userId = 1 (Admin) — nên thay bằng user thực tế khi có session
                int userId = 1;

                await _inventoryService.ImportToWarehouse(item.ProductId, qty, supplierId, note, userId);

                MessageBox.Show("Nhập kho thành công!", "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi nhập kho: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        // Trả về null nếu Cancel, ngược lại Tuple(quantity, supplierIdNullable, note)
        private (int quantity, int? supplierId, string note)? ShowImportDialog(string productDisplayName)
        {
            using (var dlg = new Form())
            {
                dlg.FormBorderStyle = FormBorderStyle.FixedDialog;
                dlg.StartPosition = FormStartPosition.CenterParent;
                dlg.ClientSize = new Size(380, 200);
                dlg.Text = "Nhập kho - " + productDisplayName;
                dlg.MaximizeBox = false;
                dlg.MinimizeBox = false;
                dlg.ShowInTaskbar = false;

                var lblQty = new Label { Left = 12, Top = 18, Width = 120, Text = "Số lượng nhập:" };
                var nudQty = new NumericUpDown { Left = 140, Top = 14, Width = 200, Minimum = 1, Maximum = 1000000, Value = 1 };

                var lblSupplier = new Label { Left = 12, Top = 58, Width = 120, Text = "Supplier ID (tùy chọn):" };
                // Removed PlaceholderText — System.Windows.Forms.TextBox in .NET Framework 4.8 doesn't have PlaceholderText property.
                var txtSupplier = new TextBox { Left = 140, Top = 54, Width = 200 };

                var lblNote = new Label { Left = 12, Top = 98, Width = 120, Text = "Ghi chú:" };
                var txtNote = new TextBox { Left = 140, Top = 94, Width = 200 };

                var btnOk = new Button { Text = "OK", Left = 140, Width = 90, Top = 140, DialogResult = DialogResult.OK };
                var btnCancel = new Button { Text = "Hủy", Left = 250, Width = 90, Top = 140, DialogResult = DialogResult.Cancel };

                btnOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
                btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

                dlg.Controls.Add(lblQty);
                dlg.Controls.Add(nudQty);
                dlg.Controls.Add(lblSupplier);
                dlg.Controls.Add(txtSupplier);
                dlg.Controls.Add(lblNote);
                dlg.Controls.Add(txtNote);
                dlg.Controls.Add(btnOk);
                dlg.Controls.Add(btnCancel);

                dlg.AcceptButton = btnOk;
                dlg.CancelButton = btnCancel;

                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    int qty = (int)nudQty.Value;
                    int? supplierId = null;
                    if (!string.IsNullOrWhiteSpace(txtSupplier.Text))
                    {
                        if (int.TryParse(txtSupplier.Text.Trim(), out int sid) && sid > 0)
                            supplierId = sid;
                        else
                        {
                            MessageBox.Show("Supplier ID không hợp lệ. Vui lòng nhập số hoặc để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return null;
                        }
                    }
                    string note = txtNote.Text?.Trim();
                    return (qty, supplierId, note);
                }

                return null;
            }
        }

        // Xử lý nút Chuyển Quầy - cập nhật: hỏi số lượng trước khi gọi TransferToCounter
        private async void btnTransfer_Click(object sender, EventArgs e)
        {
            var row = dgvInventory.CurrentRow;
            if (row == null) return;
            var item = (InventoryViewDTO)row.DataBoundItem;
            if (item == null) return;

            if (item.StockWarehouse <= 0)
            {
                MessageBox.Show("Kho hết hàng, không thể chuyển ra quầy!");
                return;
            }

            // Hỏi số lượng chuyển
            int? qtyInput = ShowTransferQuantityDialog(item.ProductName, item.StockWarehouse);
            if (!qtyInput.HasValue) return; // user hủy

            int qty = qtyInput.Value;
            if (qty <= 0)
            {
                MessageBox.Show("Số lượng phải lớn hơn 0.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (qty > item.StockWarehouse)
            {
                MessageBox.Show($"Không thể chuyển {qty}. Trong kho chỉ còn {item.StockWarehouse}.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Xác nhận
            if (MessageBox.Show($"Chuyển {qty} {item.Unit} của '{item.ProductName}' từ kho ra quầy?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                Cursor = Cursors.WaitCursor;
                // Giả sử UserId = 1 (Admin) — nên thay bằng user thực tế
                await _inventory_service_TransferToCounterSafe(item.ProductId, qty, $"Chuyển ra quầy (từ UI) - SL: {qty}", 1);
                MessageBox.Show("Đã chuyển thành công!");
                await LoadData(); // Refresh Grid
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi nghiệp vụ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        // Safety wrapper (keeps call sites tidy)
        private async Task _inventory_service_TransferToCounterSafe(int productId, int qty, string note, int userId)
        {
            await _inventoryService.TransferToCounter(productId, qty, note, userId);
        }

        // Hiển thị dialog nhỏ hỏi số lượng chuyển; trả về null nếu hủy
        private int? ShowTransferQuantityDialog(string productDisplayName, int maxAvailable)
        {
            using (var dlg = new Form())
            {
                dlg.FormBorderStyle = FormBorderStyle.FixedDialog;
                dlg.StartPosition = FormStartPosition.CenterParent;
                dlg.ClientSize = new Size(360, 140);
                dlg.Text = "Chuyển ra quầy - " + productDisplayName;
                dlg.MaximizeBox = false;
                dlg.MinimizeBox = false;
                dlg.ShowInTaskbar = false;

                var lbl = new Label { Left = 12, Top = 16, Width = 320, Text = $"Nhập số lượng cần chuyển (tối đa {maxAvailable}):" };
                var nud = new NumericUpDown
                {
                    Left = 12,
                    Top = 40,
                    Width = 320,
                    Minimum = 1,
                    Maximum = maxAvailable > 0 ? Math.Min(maxAvailable, 1000000) : 1000000,
                    Value = 1
                };

                var btnOk = new Button { Text = "OK", Left = 160, Width = 80, Top = 80, DialogResult = DialogResult.OK };
                var btnCancel = new Button { Text = "Hủy", Left = 250, Width = 80, Top = 80, DialogResult = DialogResult.Cancel };

                dlg.Controls.Add(lbl);
                dlg.Controls.Add(nud);
                dlg.Controls.Add(btnOk);
                dlg.Controls.Add(btnCancel);

                dlg.AcceptButton = btnOk;
                dlg.CancelButton = btnCancel;

                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    return (int)nud.Value;
                }

                return null;
            }
        }

        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        // ------------------- Sorting logic -------------------

        private void dgvInventory_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                var col = dgvInventory.Columns[e.ColumnIndex];
                var propName = col.DataPropertyName;
                if (string.IsNullOrEmpty(propName)) return;

                if (_sortProperty == propName)
                {
                    // toggle direction
                    _sortAscending = !_sortAscending;
                }
                else
                {
                    _sortProperty = propName;
                    _sortAscending = true;
                }

                ApplySortToCurrentItems();
                UpdateColumnSortGlyphs(col);
            }
            catch
            {
                // ignore sorting errors silently
            }
        }

        private void ApplySortToCurrentItems()
        {
            if (string.IsNullOrEmpty(_sortProperty) || _currentItems == null) return;

            var prop = typeof(InventoryViewDTO).GetProperty(_sortProperty);
            if (prop == null) return;

            // Use LINQ OrderBy with reflection; values implement IComparable (string, int, decimal)
            try
            {
                if (_sortAscending)
                    _currentItems = _currentItems.OrderBy(x => prop.GetValue(x, null)).ToList();
                else
                    _currentItems = _currentItems.OrderByDescending(x => prop.GetValue(x, null)).ToList();
            }
            catch
            {
                // fallback: do nothing on failure
            }

            dgvInventory.DataSource = new BindingList<InventoryViewDTO>(_currentItems);
        }

        private void UpdateColumnSortGlyphs(DataGridViewColumn active)
        {
            foreach (DataGridViewColumn c in dgvInventory.Columns)
            {
                c.HeaderCell.SortGlyphDirection = SortOrder.None;
            }
            if (active != null)
            {
                active.HeaderCell.SortGlyphDirection = _sortAscending ? SortOrder.Ascending : SortOrder.Descending;
            }
        }

        // Export current page to CSV (Excel-compatible)
        private async void btnExportCsv_Click(object sender, EventArgs e)
        {
            try
            {
                if (_currentItems == null || _currentItems.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để xuất.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                using (var dlg = new SaveFileDialog())
                {
                    dlg.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                    dlg.FileName = "InventoryExport_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".csv";
                    if (dlg.ShowDialog(this) != DialogResult.OK) return;

                    // --- SỬA LỖI Ở ĐÂY ---
                    // Chạy việc ghi file ở luồng phụ (background thread) để không đơ giao diện
                    // và thỏa mãn yêu cầu của từ khóa 'async'
                    await Task.Run(() =>
                    {
                        ExcelHelper.ExportToCsv(_currentItems, dlg.FileName);
                    });

                    MessageBox.Show("Đã xuất CSV thành công:\n" + dlg.FileName, "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất CSV: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Bulk import CSV with columns: Barcode,Quantity[,SupplierId[,Note]]
        private async void btnImportCsv_Click(object sender, EventArgs e)
        {
            try
            {
                using (var dlg = new OpenFileDialog())
                {
                    dlg.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                    if (dlg.ShowDialog(this) != DialogResult.OK) return;

                    var rows = ExcelHelper.ImportFromCsv(dlg.FileName, skipHeaderLines: 1); // assume first line header

                    if (rows == null || rows.Count == 0)
                    {
                        MessageBox.Show("File CSV rỗng hoặc không đọc được.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Map barcode -> productId using currently loaded products; if not loaded, load full list
                    if (_currentItems == null || _currentItems.Count == 0)
                    {
                        var res = await _inventory_service_GetInventoryListSafe(string.Empty, null, 1, 2000);
                        _currentItems = res.Items?.ToList() ?? new List<InventoryViewDTO>();
                    }

                    var errors = new List<string>();
                    int successCount = 0;

                    // Execute imports sequentially; consider batching if needed
                    foreach (var r in rows)
                    {
                        if (r.Length == 0) continue;
                        var barcode = r.Length > 0 ? r[0].Trim() : string.Empty;
                        var qtyStr = r.Length > 1 ? r[1].Trim() : "0";
                        var supplierStr = r.Length > 2 ? r[2].Trim() : string.Empty;
                        var note = r.Length > 3 ? r[3].Trim() : string.Empty;

                        if (string.IsNullOrWhiteSpace(barcode))
                        {
                            errors.Add("Dòng có barcode rỗng - bỏ qua.");
                            continue;
                        }

                        if (!int.TryParse(qtyStr, out int qty) || qty <= 0)
                        {
                            errors.Add($"Barcode {barcode}: số lượng '{qtyStr}' không hợp lệ.");
                            continue;
                        }

                        int? supplierId = null;
                        if (!string.IsNullOrWhiteSpace(supplierStr))
                        {
                            if (int.TryParse(supplierStr, out int sid) && sid > 0) supplierId = sid;
                            else { errors.Add($"Barcode {barcode}: SupplierId '{supplierStr}' không hợp lệ."); continue; }
                        }

                        var prod = _currentItems.FirstOrDefault(x => string.Equals(x.Barcode?.Trim(), barcode, StringComparison.OrdinalIgnoreCase));
                        if (prod == null)
                        {
                            errors.Add($"Barcode {barcode}: không tìm thấy sản phẩm.");
                            continue;
                        }

                        try
                        {
                            // Use userId = 1 for now
                            await _inventoryService.ImportToWarehouse(prod.ProductId, qty, supplierId, note, 1);
                            successCount++;
                        }
                        catch (Exception ex)
                        {
                            errors.Add($"Barcode {barcode}: lỗi khi nhập ({ex.Message})");
                        }
                    }

                    // Refresh grid
                    await LoadData();

                    var msg = $"Hoàn tất: {successCount} dòng nhập thành công.";
                    if (errors.Count > 0)
                        msg += $"\n{errors.Count} lỗi. Xem chi tiết trong thông báo.";

                    MessageBox.Show(msg, "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (errors.Count > 0)
                    {
                        // Offer to save errors to a CSV for inspection
                        if (MessageBox.Show("Bạn có muốn lưu danh sách lỗi thành file CSV để kiểm tra không?", "Lưu lỗi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            using (var sd = new SaveFileDialog())
                            {
                                sd.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                                sd.FileName = "ImportErrors_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".csv";
                                if (sd.ShowDialog(this) == DialogResult.OK)
                                {
                                    File.WriteAllLines(sd.FileName, errors, Encoding.UTF8);
                                    MessageBox.Show("Đã lưu lỗi: " + sd.FileName, "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi trong quá trình nhập CSV: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
