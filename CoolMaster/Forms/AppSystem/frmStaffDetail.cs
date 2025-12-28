using CoolMaster.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoolMaster.Forms.AppSystem
{
    public partial class frmStaffDetail : Form
    {
        public User StaffData { get; private set; }
        private bool _isEditMode = false;

        public frmStaffDetail(User staff = null)
        {
            InitializeComponent();

            if (staff != null)
            {
                // CHẾ ĐỘ SỬA
                _isEditMode = true;
                StaffData = staff;
                FillDataToControls();
                lblHeader.Text = "CẬP NHẬT NHÂN VIÊN";

                // Khi sửa: Không cho sửa mã, không cho sửa mật khẩu tại đây
                txtStaffCode.ReadOnly = true;
                txtPassword.Enabled = false;
                txtPassword.PlaceholderText = "******** (Mật khẩu được bảo mật)";
            }
            else
            {
                // CHẾ ĐỘ THÊM MỚI
                _isEditMode = false;
                StaffData = new User();
                lblHeader.Text = "ĐĂNG KÝ NHÂN VIÊN MỚI";

                // Khi thêm: Mã tự sinh nên để ReadOnly
                txtStaffCode.ReadOnly = true;
                txtStaffCode.Text = "[Hệ thống tự sinh]";
                txtPassword.Enabled = true;
            }
        }

        private void FillDataToControls()
        {
            txtFullName.Text = StaffData.FullName;
            txtStaffCode.Text = StaffData.StaffCode;
            txtPhone.Text = StaffData.PhoneNumber;
            txtEmail.Text = StaffData.Email;
            txtAddress.Text = StaffData.Address;
            cboRole.SelectedItem = StaffData.Role;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validate dữ liệu
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFullName.Focus();
                return;
            }

            if (!_isEditMode && string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu khởi tạo!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            // Đổ dữ liệu vào object
            StaffData.FullName = txtFullName.Text.Trim();
            StaffData.PhoneNumber = txtPhone.Text.Trim();
            StaffData.Email = txtEmail.Text.Trim();
            StaffData.Address = txtAddress.Text.Trim();
            StaffData.Role = cboRole.Text;

            if (!_isEditMode)
            {
                StaffData.Password = txtPassword.Text; // Sẽ được hash ở Service
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
