using CoolMaster.Common;
using CoolMaster.DTOs;
using CoolMaster.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoolMaster.Forms.AppSystem
{
    public partial class frmRevenueReport : Form
    {
        private readonly ReportService _service;
        private int _currentPage = 1;
        private readonly int _pageSize = 20;
        private int _totalPages = 0;
        private int _totalItems = 0;
        private ReportFilterRequest _currentFilter;
        private bool _isLoading = false; // Biến cờ chặn spam click và lỗi đồng bộ

        public frmRevenueReport(ReportService service)
        {
            InitializeComponent();
            _service = service;

            // 1. Khởi tạo bộ lọc mặc định (Tháng hiện tại)
            _currentFilter = new ReportFilterRequest
            {
                ReportType = ReportType.RevenueByDay,
                FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1),
                ToDate = DateTime.Now,
                Keyword = ""
            };

            // 2. Đăng ký sự kiện (Lưu ý: Nếu btnFilter đã gán trong Designer thì không gán ở đây)
            RegisterEvents();

            // 3. Hiển thị dữ liệu mặc định lên giao diện
            UpdateMainUI();
        }

        private void RegisterEvents()
        {
            // Các nút phân trang
            btnNext.Click += async (s, e) => { if (_currentPage < _totalPages) { _currentPage++; await LoadData(); } };
            btnPrev.Click += async (s, e) => { if (_currentPage > 1) { _currentPage--; await LoadData(); } };

            // In ấn
            btnPrint.Click += btnPrint_Click;
            printDocument1.PrintPage += PrintDocument1_PrintPage;

            // Load dữ liệu khi Form hiển thị
            this.Load += async (s, e) => await LoadData();
        }

        /// <summary>
        /// Đồng bộ dữ liệu từ Control trên UI vào đối tượng Filter trước khi tải
        /// </summary>
        private void SyncFilterFromUI()
        {
            _currentFilter.FromDate = dtpFrom.Value;
            _currentFilter.ToDate = dtpTo.Value;
            _currentFilter.Keyword = txtSearch.Text;
            _currentFilter.ReportType = (ReportType)cboReportType.SelectedIndex;
        }

        /// <summary>
        /// Cập nhật các Control UI dựa trên đối tượng Filter (Dùng sau khi đóng Form Lọc)
        /// </summary>
        private void UpdateMainUI()
        {
            // Tạm gỡ sự kiện để tránh trigger LoadData nhiều lần
            cboReportType.SelectedIndexChanged -= cboReportType_SelectedIndexChanged;

            cboReportType.SelectedIndex = (int)_currentFilter.ReportType;
            dtpFrom.Value = _currentFilter.FromDate;
            dtpTo.Value = _currentFilter.ToDate;
            txtSearch.Text = _currentFilter.Keyword;

            bool isProd = (_currentFilter.ReportType == ReportType.TopSellingQuantity ||
                          _currentFilter.ReportType == ReportType.TopSellingRevenue);
            txtSearch.Visible = isProd;

            cboReportType.SelectedIndexChanged += cboReportType_SelectedIndexChanged;
        }

        private async void cboReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            _currentPage = 1;
            await LoadData();
        }

        public async Task LoadData()
        {
            if (_isLoading) return;
            _isLoading = true;

            try
            {
                Cursor = Cursors.WaitCursor;

                // BƯỚC QUAN TRỌNG: Lấy giá trị từ UI nạp vào Filter
                SyncFilterFromUI();

                // 1. Lấy dữ liệu báo cáo
                var resultObj = await _service.GetReportData(
                    _currentFilter.ReportType,
                    _currentFilter.FromDate,
                    _currentFilter.ToDate,
                    _currentFilter.Keyword,
                    _currentPage,
                    _pageSize
                );

                SetupGridColumns(_currentFilter.ReportType);

                // 2. Đổ dữ liệu vào Grid
                if (resultObj is PagedResult<RevenueReportDTO> resRev)
                {
                    dgvReport.DataSource = resRev.Items;
                    _totalItems = resRev.TotalCount;
                    _totalPages = resRev.TotalPages;
                }
                else if (resultObj is PagedResult<ProductPerformanceDTO> resProd)
                {
                    dgvReport.DataSource = resProd.Items;
                    _totalItems = resProd.TotalCount;
                    _totalPages = resProd.TotalPages;
                }

                // 3. Cập nhật giao diện phân trang
                lblPageInfo.Text = $"Trang {_currentPage}/{Math.Max(1, _totalPages)} (Tổng: {_totalItems} dòng)";
                btnPrev.Enabled = _currentPage > 1;
                btnNext.Enabled = _currentPage < _totalPages;

                // 4. Cập nhật thẻ tóm tắt (Cards)
                var summary = await _service.GetTotalSummary(_currentFilter.FromDate, _currentFilter.ToDate);
                lblTotalRevenue.Text = $"Tổng doanh thu: {summary.Item1:N0} đ";
                lblOrderCount.Text = $"Tổng đơn đã bán: {summary.Item2}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _isLoading = false;
                Cursor = Cursors.Default;
            }
        }

        private async void btnFilter_Click(object sender, EventArgs e)
        {
            // Trước khi mở form con, đồng bộ ngày từ màn hình chính vào trước
            SyncFilterFromUI();

            using (var frm = new frmReportFilter(_currentFilter))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    _currentFilter = frm.FilterResult;
                    UpdateMainUI(); // Cập nhật lại ngày/loại lên UI chính
                    _currentPage = 1;
                    await LoadData();
                }
            }
        }

        private void SetupGridColumns(ReportType type)
        {
            dgvReport.AutoGenerateColumns = false;
            dgvReport.Columns.Clear();

            if (type == ReportType.RevenueByDay || type == ReportType.RevenueByMonth)
            {
                AddCol("Thời gian", "TimeLabel", 150);
                AddCol("Số đơn hàng", "OrderCount", 100);
                var colRev = AddCol("Doanh thu", "TotalRevenue", 200);
                colRev.DefaultCellStyle.Format = "N0";
                colRev.DefaultCellStyle.ForeColor = Color.DarkGreen;
                colRev.DefaultCellStyle.Font = new Font(dgvReport.Font, FontStyle.Bold);
            }
            else
            {
                AddCol("Mã SP", "Barcode", 100);
                AddCol("Tên sản phẩm", "ProductName", 250);
                AddCol("Danh mục", "CategoryName", 150);
                AddCol("SL Bán", "QuantitySold", 100);
                var colRev = AddCol("Doanh thu", "RevenueGenerated", 150);
                colRev.DefaultCellStyle.Format = "N0";
                colRev.DefaultCellStyle.ForeColor = Color.Blue;
            }
        }

        private DataGridViewColumn AddCol(string header, string prop, int width)
        {
            var col = new DataGridViewTextBoxColumn
            {
                HeaderText = header,
                DataPropertyName = prop,
                Width = width
            };
            dgvReport.Columns.Add(col);
            return col;
        }

        // --- GIỮ NGUYÊN VÀ TỐI ƯU LOGIC IN ---
        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dgvReport.Rows.Count == 0) return;

            PrintPreviewDialog preview = new PrintPreviewDialog();
            preview.Document = printDocument1;
            ((Form)preview).WindowState = FormWindowState.Maximized;
            preview.ShowDialog();
        }

        private void PrintDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font fontHeader = new Font("Arial", 18, FontStyle.Bold);
            Font fontSub = new Font("Arial", 12, FontStyle.Regular);
            Font fontBody = new Font("Arial", 10, FontStyle.Regular);

            float y = 50;

            // 1. Vẽ Header
            e.Graphics.DrawString("BÁO CÁO DOANH THU COOLMASTER", fontHeader, Brushes.Black, 150, y);
            y += 45;
            e.Graphics.DrawString($"Loại: {cboReportType.SelectedItem}", fontSub, Brushes.Black, 50, y);
            y += 25;
            e.Graphics.DrawString($"Thời gian: {dtpFrom.Value:dd/MM/yyyy} - {dtpTo.Value:dd/MM/yyyy}", fontSub, Brushes.Black, 50, y);
            y += 45;

            // 2. Vẽ Tiêu đề cột
            int x = 50;
            foreach (DataGridViewColumn col in dgvReport.Columns)
            {
                e.Graphics.FillRectangle(Brushes.LightGray, x, y, col.Width, 30);
                e.Graphics.DrawRectangle(Pens.Black, x, y, col.Width, 30);
                e.Graphics.DrawString(col.HeaderText, new Font("Arial", 10, FontStyle.Bold), Brushes.Black, x + 5, y + 5);
                x += col.Width;
            }
            y += 30;

            // 3. Vẽ các dòng dữ liệu
            foreach (DataGridViewRow row in dgvReport.Rows)
            {
                x = 50;
                foreach (DataGridViewCell cell in row.Cells)
                {
                    string val = cell.FormattedValue?.ToString() ?? "";
                    e.Graphics.DrawRectangle(Pens.Black, x, y, dgvReport.Columns[cell.ColumnIndex].Width, 30);
                    e.Graphics.DrawString(val, fontBody, Brushes.Black, x + 5, y + 5);
                    x += dgvReport.Columns[cell.ColumnIndex].Width;
                }
                y += 30;

                // Kiểm tra ngắt trang nếu quá dài
                if (y > e.MarginBounds.Bottom)
                {
                    e.HasMorePages = false; // Ở bản đơn giản này chúng ta in 1 trang
                    break;
                }
            }

            // 4. Footer tổng kết
            y += 25;
            e.Graphics.DrawString($"{lblTotalRevenue.Text} | {lblOrderCount.Text}", new Font("Arial", 11, FontStyle.Bold), Brushes.DarkBlue, 50, y);
        }
    }
}