using CoolMaster.Model;
using CoolMaster.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoolMaster.Forms.Sales
{
    public partial class frmAddCustomer : Form
    {
        private readonly CustomerService _service;

        // Thuộc tính này giúp frmPOS và frmCustomer lấy được khách hàng vừa tạo / cập nhật
        public Customer NewCustomer { get; private set; }

        // Flag để biết là form đang ở mode Sửa hay Thêm
        private bool _isEdit = false;

        // Giữ đối tượng cũ khi sửa để gán Id...
        private Customer _existingCustomer;

        // ORIGINAL constructor (kept for POS usage)
        public frmAddCustomer(CustomerService service, string phoneDraft = "")
        {
            InitializeComponent();
            _service = service;

            // Nếu người dùng đã nhập SĐT ở màn hình POS, điền sẵn vào đây
            if (!string.IsNullOrEmpty(phoneDraft))
            {
                txtPhone.Text = phoneDraft;
                // Nếu phoneDraft không phải số (ví dụ nhập tên), chuyển sang ô Tên
                long n;
                if (!long.TryParse(phoneDraft, out n))
                {
                    txtFullName.Text = phoneDraft;
                    txtPhone.Clear();
                }
            }
        }

        // NEW overload: dùng để mở form ở chế độ Edit
        public frmAddCustomer(CustomerService service, Customer existingCustomer) : this(service, "")
        {
            if (existingCustomer == null) return;

            _isEdit = true;
            _existingCustomer = existingCustomer;

            // Điền dữ liệu hiện có vào controls
            txtFullName.Text = existingCustomer.FullName;
            txtPhone.Text = existingCustomer.PhoneNumber;
            txtAddress.Text = existingCustomer.Address;

            // Gán NewCustomer tham chiếu tới object hiện có để cập nhật trực tiếp và trả về form cha
            NewCustomer = existingCustomer;

            // Optionally update UI title if you have a label (not required)
            if (this.Text == "Form1" || string.IsNullOrWhiteSpace(this.Text))
            {
                this.Text = "Cập nhật khách hàng";
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate
                if (string.IsNullOrWhiteSpace(txtFullName.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên khách hàng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtFullName.Focus();
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtPhone.Text))
                {
                    MessageBox.Show("Vui lòng nhập số điện thoại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPhone.Focus();
                    return;
                }

                if (_isEdit)
                {
                    // Update existing customer object
                    _existingCustomer.FullName = txtFullName.Text.Trim();
                    _existingCustomer.PhoneNumber = txtPhone.Text.Trim();
                    _existingCustomer.Address = txtAddress.Text.Trim();

                    // Call service to update DB
                    await _service.UpdateCustomer(_existingCustomer);

                    // Set NewCustomer to updated object so caller can use it
                    NewCustomer = _existingCustomer;

                    MessageBox.Show("Cập nhật khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Create new object
                    var cus = new Customer
                    {
                        FullName = txtFullName.Text.Trim(),
                        PhoneNumber = txtPhone.Text.Trim(),
                        Address = txtAddress.Text.Trim()
                    };

                    // Call Service lưu vào DB
                    await _service.AddCustomer(cus);

                    // Return created customer to caller
                    NewCustomer = cus;

                    MessageBox.Show("Thêm khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

    }
}
