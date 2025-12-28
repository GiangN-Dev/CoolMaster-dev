using System;
using System.Windows.Forms;
using CoolMaster.DTOs;

namespace CoolMaster.Forms.Technical
{
    public partial class frmServiceTicketDetail : Form
    {
        // Public DTO returned to caller
        public ServiceTicketDTO Ticket { get; private set; }

        // Constructor for creating new ticket
        public frmServiceTicketDetail()
        {
            InitializeComponent();

            // initialize DTO with defaults
            Ticket = new ServiceTicketDTO
            {
                CreatedDate = DateTime.Now,
                Status = "Mới"
            };

            // ensure combo default if designer set items
            if (cboStatus != null && cboStatus.Items.Count > 0)
                cboStatus.SelectedIndex = 0;
        }

        // Constructor for editing existing ticket
        public frmServiceTicketDetail(ServiceTicketDTO existing) : this()
        {
            if (existing == null) return;

            // clone to avoid mutating original if user cancels
            Ticket = new ServiceTicketDTO
            {
                Id = existing.Id,
                CustomerName = existing.CustomerName,
                PhoneNumber = existing.PhoneNumber,
                DeviceName = existing.DeviceName,
                IssueDescription = existing.IssueDescription,
                Status = existing.Status,
                CreatedDate = existing.CreatedDate
            };

            // populate controls (defensive null checks)
            if (txtCustomer != null) txtCustomer.Text = Ticket.CustomerName;
            if (txtPhone != null) txtPhone.Text = Ticket.PhoneNumber;
            if (txtDevice != null) txtDevice.Text = Ticket.DeviceName;
            if (txtIssue != null) txtIssue.Text = Ticket.IssueDescription;
            if (cboStatus != null)
            {
                var idx = cboStatus.Items.IndexOf(Ticket.Status);
                cboStatus.SelectedIndex = idx >= 0 ? idx : 0;
            }
        }

        // Designer's event handler for Save button
        private void btnSave_Click(object sender, EventArgs e)
        {
            // basic validation
            if (txtCustomer == null || string.IsNullOrWhiteSpace(txtCustomer.Text))
            {
                MessageBox.Show("Vui lòng nhập tên khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCustomer?.Focus();
                return;
            }

            if (txtPhone == null || string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhone?.Focus();
                return;
            }

            // copy values back to DTO
            Ticket.CustomerName = txtCustomer.Text.Trim();
            Ticket.PhoneNumber = txtPhone.Text.Trim();
            Ticket.DeviceName = txtDevice?.Text?.Trim();
            Ticket.IssueDescription = txtIssue?.Text?.Trim();
            Ticket.Status = cboStatus?.SelectedItem?.ToString() ?? Ticket.Status;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // Designer's event handler for Cancel button
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}