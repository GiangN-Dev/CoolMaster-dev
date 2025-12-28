using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoolMaster.DTOs;      // Để nhận diện ServiceTicketDTO
using CoolMaster.Services;  // Để nhận diện IServiceTicketService

namespace CoolMaster.Forms.Technical
{
    public partial class frmServiceTicket : Form
    {
        // Khai báo Service (cầu nối xử lý nghiệp vụ)
        private readonly IServiceTicketService _service;

        // BindingSource giúp quản lý dữ liệu trên lưới dễ hơn
        private BindingSource _bindingSource = new BindingSource();

        // 1. Constructor mặc định (Bắt buộc cho Visual Studio Designer)
        public frmServiceTicket()
        {
            InitializeComponent();
        }

        // 2. Constructor có tham số (Dùng khi chạy thật với DI)
        public frmServiceTicket(IServiceTicketService service) : this()
        {
            _service = service;
        }

        // Sự kiện Form Load: Chạy khi form vừa mở lên
        private async void frmServiceTicket_Load(object sender, EventArgs e)
        {
            SetupDataGridView(); // Cấu hình giao diện lưới
            await LoadData();    // Tải dữ liệu từ Service
        }

        private void SetupDataGridView()
        {
            // LƯU Ý: Bạn cần đảm bảo DataGridView trên giao diện có tên là "dgvTickets"
            if (dgvTickets != null)
            {
                dgvTickets.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvTickets.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvTickets.MultiSelect = false;
                dgvTickets.ReadOnly = true;

                // Disable auto-generate — designer columns (VN) are used
                dgvTickets.AutoGenerateColumns = false;
            }
        }

        // Hàm tải dữ liệu dùng chung
        private async Task LoadData(string keyword = null)
        {
            try
            {
                // Gọi Service lấy danh sách về
                var list = await _service.GetAllTicketsAsync();

                // Nếu có từ khóa tìm, lọc bên client (hoặc bạn có thể gọi service có tham số)
                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    list = list.FindAll(t =>
                        (!string.IsNullOrEmpty(t.CustomerName) && t.CustomerName.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0)
                        || (!string.IsNullOrEmpty(t.PhoneNumber) && t.PhoneNumber.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0)
                        || (!string.IsNullOrEmpty(t.DeviceName) && t.DeviceName.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0)
                        || (!string.IsNullOrEmpty(t.IssueDescription) && t.IssueDescription.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0)
                    );
                }
                // Đổ vào BindingSource -> Đổ lên Grid
                _bindingSource.DataSource = list;
                if (dgvTickets != null) dgvTickets.DataSource = _bindingSource;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        // ----------------- CÁC NÚT CHỨC NĂNG -----------------

        private async void btnAddTicket_Click(object sender, EventArgs e)
        {
            // Mở Form chi tiết để nhập thông tin phiếu mới
            using (var dlg = new frmServiceTicketDetail())
            {
                dlg.Text = "Tạo phiếu sửa chữa";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    var newTicket = dlg.Ticket;
                    try
                    {
                        await _service.CreateTicketAsync(newTicket);
                        MessageBox.Show("Tạo phiếu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex.Message);
                    }
                }
            }
        }

        private async void btnUpdateTicket_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem đã chọn dòng nào chưa
            if (dgvTickets == null || dgvTickets.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn phiếu cần sửa!");
                return;
            }

            // Lấy dữ liệu dòng đang chọn
            var selectedTicket = (ServiceTicketDTO)dgvTickets.SelectedRows[0].DataBoundItem;

            // Mở form chi tiết với dữ liệu hiện tại để sửa
            using (var dlg = new frmServiceTicketDetail(selectedTicket))
            {
                dlg.Text = "Sửa phiếu sửa chữa";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    var updated = dlg.Ticket;
                    if (MessageBox.Show("Bạn muốn lưu thay đổi cho phiếu này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        try
                        {
                            await _service.UpdateTicketAsync(updated);
                            MessageBox.Show("Cập nhật xong!");
                            await LoadData();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi: " + ex.Message);
                        }
                    }
                }
            }
        }

        private async void btnDeleteTicket_Click(object sender, EventArgs e)
        {
            if (dgvTickets == null || dgvTickets.SelectedRows.Count == 0) return;
            var selectedTicket = (ServiceTicketDTO)dgvTickets.SelectedRows[0].DataBoundItem;

            if (MessageBox.Show("Xác nhận xóa phiếu này?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    await _service.DeleteTicketAsync(selectedTicket.Id);
                    MessageBox.Show("Đã xóa!");
                    await LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể xóa: " + ex.Message);
                }
            }
        }

        // Search button handler (kết nối với nút Tìm trên toolbar)
        private async void btnSearch_Click(object sender, EventArgs e)
        {
            await LoadData(txtSearch.Text?.Trim());
        }

        private void pnlHeader_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void pnlFooter_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvTickets_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
