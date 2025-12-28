using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoolMaster.DTOs;
using CoolMaster.Services;
using CoolMaster.Forms.Technical;

namespace CoolMaster.Forms.Technical
{
    public partial class frmWarrantyLookup : Form
    {
        private BindingSource _bindingSource = new BindingSource();

        // Optional service bridge for creating tickets in real app (can be null in demo)
        private readonly IServiceTicketService _ticketService;

        // In-memory storage when no real service is injected.
        private readonly List<ServiceTicketDTO> _localTickets = new List<ServiceTicketDTO>();
        private int _localNextId = 1;

        // Default constructor required by Designer
        public frmWarrantyLookup()
        {
            InitializeComponent();
            InitializeCustom();
        }

        // Constructor for runtime use with DI/service injection
        public frmWarrantyLookup(IServiceTicketService ticketService) : this()
        {
            _ticketService = ticketService;
        }

        // Shared initialization moved out so both ctors can call it
        private void InitializeCustom()
        {
            // Disable auto-generate => designer columns will be used
            if (dgvWarranty != null)
                dgvWarranty.AutoGenerateColumns = false;

            // Wire events
            if (btnCheck != null) btnCheck.Click += btnCheck_Click;
            if (btnCreateTicket != null) btnCreateTicket.Click += btnCreateTicket_Click;
            if (btnDelete != null) btnDelete.Click += btnDelete_Click;

            // Use binding source for easier filtering / refresh
            if (dgvWarranty != null)
                dgvWarranty.DataSource = _bindingSource;
        }

        private async void frmWarrantyLookup_Load(object sender, EventArgs e)
        {
            await LoadData();
        }

        // Load data from service (real service when injected; fallback to in-memory list)
        private async Task LoadData(string keyword = null)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                List<ServiceTicketDTO> list;

                if (_ticketService != null)
                {
                    // real service: fetch all tickets then optionally filter
                    list = await _ticketService.GetAllTicketsAsync() ?? new List<ServiceTicketDTO>();
                }
                else
                {
                    // in-memory list populated by Create action
                    list = _localTickets.ToList();
                }

                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    var k = keyword.Trim();
                    list = list.FindAll(t =>
                        (!string.IsNullOrEmpty(t.CustomerName) && t.CustomerName.IndexOf(k, StringComparison.OrdinalIgnoreCase) >= 0)
                        || (!string.IsNullOrEmpty(t.PhoneNumber) && t.PhoneNumber.IndexOf(k, StringComparison.OrdinalIgnoreCase) >= 0)
                        || (!string.IsNullOrEmpty(t.DeviceName) && t.DeviceName.IndexOf(k, StringComparison.OrdinalIgnoreCase) >= 0)
                        || (!string.IsNullOrEmpty(t.IssueDescription) && t.IssueDescription.IndexOf(k, StringComparison.OrdinalIgnoreCase) >= 0)
                    );
                }

                _bindingSource.DataSource = list;
                if (dgvWarranty != null) dgvWarranty.DataSource = _bindingSource;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        // Nút Tra cứu: gọi LoadData với từ khóa
        private async void btnCheck_Click(object sender, EventArgs e)
        {
            await LoadData(txtSearch.Text?.Trim());
        }

        // Nút Tạo: mở dialog tạo phiếu (dùng frmServiceTicketDetail). Sau OK -> gọi service tạo hoặc lưu vào in-memory list
        private async void btnCreateTicket_Click(object sender, EventArgs e)
        {
            // Prefill DTO for dialog
            ServiceTicketDTO prefill = new ServiceTicketDTO
            {
                CreatedDate = DateTime.Now,
                Status = "Mới"
            };

            try
            {
                object selected = null;
                if (dgvWarranty != null && dgvWarranty.SelectedRows.Count > 0)
                    selected = dgvWarranty.SelectedRows[0].DataBoundItem;

                if (selected != null)
                {
                    prefill.CustomerName = GetStringProp(selected, "CustomerName") ?? GetStringProp(selected, "Customer");
                    prefill.PhoneNumber = GetStringProp(selected, "PhoneNumber") ?? GetStringProp(selected, "Phone");
                    prefill.DeviceName = GetStringProp(selected, "DeviceName") ?? GetStringProp(selected, "Device");
                    prefill.IssueDescription = GetStringProp(selected, "IssueDescription") ?? GetStringProp(selected, "Issue");
                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(txtSearch.Text))
                        prefill.DeviceName = txtSearch.Text.Trim();
                }
            }
            catch
            {
                // ignore prefill errors
            }

            // Use constructor that accepts DTO (frmServiceTicketDetail has that ctor).
            using (var dlg = new frmServiceTicketDetail(prefill))
            {
                dlg.Text = "Tạo phiếu từ Tra cứu";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    var newTicket = dlg.Ticket;
                    try
                    {
                        if (_ticketService != null)
                        {
                            // Persist ticket using real service
                            await _ticketService.CreateTicketAsync(newTicket);
                        }
                        else
                        {
                            // No service: add to in-memory list so it appears in grid
                            // Assign an Id and ensure CreatedDate is set
                            newTicket.Id = _localNextId++;
                            if (newTicket.CreatedDate == default(DateTime))
                                newTicket.CreatedDate = DateTime.Now;

                            _localTickets.Add(newTicket);
                        }

                        // Reload grid from service (or in-memory)
                        await LoadData(txtSearch.Text?.Trim());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Không thể tạo phiếu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // Helper to safely read string property from dynamic/anonymous/DTO objects via reflection
        private string GetStringProp(object obj, string propName)
        {
            if (obj == null) return null;
            var prop = obj.GetType().GetProperty(propName);
            if (prop == null) return null;
            var val = prop.GetValue(obj);
            return val?.ToString();
        }

        // Nút Xóa: xóa hàng đang chọn (yêu cầu service thực tế)
        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvWarranty == null || dgvWarranty.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Xác nhận xóa mục được chọn?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            try
            {
                var item = dgvWarranty.SelectedRows[0].DataBoundItem as ServiceTicketDTO;
                if (item == null)
                {
                    MessageBox.Show("Không lấy được dữ liệu dòng chọn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (_ticketService != null)
                {
                    await _ticketService.DeleteTicketAsync(item.Id);
                }
                else
                {
                    // remove from in-memory list
                    _localTickets.RemoveAll(t => t.Id == item.Id);
                }

                MessageBox.Show("Xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Sau khi xóa, reload
                await LoadData(txtSearch.Text?.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Optional sample helper for local testing (kept but not used for main flow)
        private List<dynamic> GetSampleWarrantyList()
        {
            return new List<dynamic>
            {
                new { Serial = "SN001", CustomerName = "Nguyễn A", PhoneNumber = "0900000001", DeviceName = "Tủ lạnh", Status = "Có BH", CreatedDate = DateTime.Now.AddDays(-10) },
                new { Serial = "SN002", CustomerName = "Trần B", PhoneNumber = "0900000002", DeviceName = "Máy giặt", Status = "Hết BH", CreatedDate = DateTime.Now.AddDays(-40) },
            };
        }

        private void btnCheck_Click_1(object sender, EventArgs e)
        {

        }
    }
}
