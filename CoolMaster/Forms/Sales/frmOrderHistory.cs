using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoolMaster.Common;
using CoolMaster.DTOs;
using CoolMaster.Services;
using CoolMaster.Utils;

namespace CoolMaster.Forms.Sales
{
    public partial class frmOrderHistory : Form
    {
        private readonly OrderService _orderService;
        private List<OrderHistoryDTO> _currentItems = new List<OrderHistoryDTO>();

        // sorter
        private DataGridViewSorter<OrderHistoryDTO> _gridSorter;

        public frmOrderHistory(OrderService service)
        {
            InitializeComponent();
            _orderService = service;
            InitializeGridConfig();

            // 1. Đăng ký sự kiện chuyển trang từ UserControl
            ucPager.OnPageChanged += async (s, e) =>
            {
                await LoadData(e.PageIndex, e.PageSize);
            };

            // 2. Đăng ký sự kiện Resize: Tự tính số dòng khi phóng to/thu nhỏ
            dgvOrders.Resize += (s, e) => ucPager.CalculatePageSize(dgvOrders);
        }

        private void InitializeGridConfig()
        {
            dgvOrders.AutoGenerateColumns = false;

            // Map cột DTO với cột trên Design
            colId.DataPropertyName = "OrderId";
            colCode.DataPropertyName = "OrderCode";       // #1001
            colDate.DataPropertyName = "CreatedAt";
            colCustomer.DataPropertyName = "CustomerName";
            colTotal.DataPropertyName = "TotalAmount";
            colPaymentStatus.DataPropertyName = "PaymentStatusText"; // Tiền mặt/Chuyển khoản
            colServiceStatus.DataPropertyName = "OrderStatusText";   // Hoàn thành/Đã hủy
            dgvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOrders.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvOrders.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            // Định dạng ngày và tiền
            colDate.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            colTotal.DefaultCellStyle.Format = "N0"; // 1,000,000
            colTotal.DefaultCellStyle.ForeColor = Color.Blue;

            // Thiết lập tỷ lệ độ rộng cho từng cột (FillWeight)
            colCode.FillWeight = 80;
            colDate.FillWeight = 120;
            colCustomer.FillWeight = 100; // Cột này cần rộng nhất
            colTotal.FillWeight = 100;

            // Create sorter
            _gridSorter = new DataGridViewSorter<OrderHistoryDTO>(dgvOrders);

            // Sự kiện tìm kiếm: Reset về trang 1
            txtSearch.TextChanged += async (s, e) =>
            {
                ucPager.ResetToFirstPage();
                await LoadData(1, ucPager.PageSize);
            };

            btnFilter.Click += async (s, e) =>
            {
                ucPager.ResetToFirstPage();
                await LoadData(1, ucPager.PageSize);
            };

            // Load mặc định 30 ngày gần nhất
            dtpFromDate.Value = DateTime.Now.AddDays(-30);
            dtpToDate.Value = DateTime.Now;
        }

        private async void frmOrderHistory_Load(object sender, EventArgs e)
        {
            // Tính toán số dòng phù hợp với màn hình ngay khi mở
            ucPager.CalculatePageSize(dgvOrders);

            // Load dữ liệu trang 1
            await LoadData(1, ucPager.PageSize);
        }

        private async Task LoadData(int pageIndex, int pageSize)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                var result = await _orderService.GetOrderHistory(
                    txtSearch.Text.Trim(),
                    dtpFromDate.Value,
                    dtpToDate.Value,
                    pageIndex,
                    pageSize
                );

                // Lưu lại để export excel
                _currentItems = result.Items?.ToList() ?? new List<OrderHistoryDTO>();

                // Bind data vào Grid thông qua Sorter
                _gridSorter.UpdateItems(_currentItems);

                // CẬP NHẬT TRẠNG THÁI CHO USER CONTROL (Tổng số bản ghi)
                ucPager.UpdateState(result.TotalCount);
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

        private void btnViewDetail_Click(object sender, EventArgs e)
        {
            if (dgvOrders.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn đơn hàng cần xem.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var item = (OrderHistoryDTO)dgvOrders.CurrentRow.DataBoundItem;
            if (item == null) return;

            try
            {
                // Mở Form hóa đơn
                using (var frm = new frmBill(_orderService, item.OrderId))
                {
                    frm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi mở hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnExportExcel_Click(object sender, EventArgs e)
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
                    dlg.FileName = "OrderHistory_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".csv";

                    if (dlg.ShowDialog(this) != DialogResult.OK) return;

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

        private async void btnReload_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Reset các bộ lọc về mặc định
                txtSearch.Clear();
                dtpFromDate.Value = DateTime.Now.AddDays(-30);
                dtpToDate.Value = DateTime.Now;

                // 2. Reset phân trang về trang đầu
                ucPager.ResetToFirstPage();

                // 3. Tải lại dữ liệu (tự động tính lại pageSize hiện tại)
                await LoadData(1, ucPager.PageSize);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi làm mới dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
