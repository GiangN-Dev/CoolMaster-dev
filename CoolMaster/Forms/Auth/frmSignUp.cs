using System;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using CoolMaster.Services;
using CoolMaster.Model;
using CoolMaster.Common;

namespace CoolMaster
{
    public partial class frmSignUp : Form
    {
        private readonly AuthService _authService = new AuthService();

        public frmSignUp()
        {
            InitializeComponent();
            // Nạp danh sách chức vụ
            cboRole.Items.Add("Quản lý");
            cboRole.Items.Add("Thu ngân");
            cboRole.Items.Add("Thủ kho");
            cboRole.Items.Add("Kỹ thuật");
            cboRole.Items.Add("Kế toán");

            cboRole.SelectedIndex = -1;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string fullName = txtFullName.Text.Trim();
            string address = txtAddress.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string password = txtPassword.Text.Trim();
            string confirmPass = txtConfirmPass.Text.Trim();

            // Validate
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(fullName)
                || string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(address) || string.IsNullOrEmpty(confirmPass))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboRole.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn chức vụ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Email không hợp lệ!", "Lỗi Email", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }

            if (phone.Length != 10 || !phone.All(char.IsDigit))
            {
                MessageBox.Show("Số điện thoại phải đúng 10 chữ số!", "Lỗi SĐT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhone.Focus();
                return;
            }

            if (password.Length < 5)
            {
                MessageBox.Show("Mật khẩu phải từ 5 ký tự trở lên!", "Lỗi Mật khẩu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            if (password != confirmPass)
            {
                MessageBox.Show("Mật khẩu nhập lại không khớp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtConfirmPass.Clear();
                return;
            }

            try
            {
                // Tạo đối tượng User
                var tempUser = new User
                {
                    FullName = fullName,
                    Role = cboRole.SelectedItem.ToString(),
                    Email = email,
                    Address = address,
                    PhoneNumber = phone
                };

                // Gọi Service
                User createdUser = _authService.Register(tempUser, password);
                MessageBox.Show($"Đăng ký thành công!\n\nTài khoản (ID) của bạn là: {createdUser.StaffCode}\n(Vui lòng ghi nhớ ID này để đăng nhập)",
                                "Chúc mừng", MessageBoxButtons.OK, MessageBoxIcon.Information);

                frmSignIn loginForm = new frmSignIn();
                loginForm.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đăng ký thất bại: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        } 

        // --- CÁC HÀM GIAO DIỆN --
        private void cboRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lblRolePlaceholder != null) // Kiểm tra null cho an toàn
                lblRolePlaceholder.Visible = (cboRole.SelectedIndex == -1);
        }

        private void lblRolePlaceholder_Click(object sender, EventArgs e)
        {
            cboRole.Focus();
            cboRole.DroppedDown = true;
        }

        private void btnBackToSignIn_Click(object sender, EventArgs e)
        {
            this.Close(); // Đóng form đăng ký
        }

        private void txtPassword_IconRightClick(object sender, EventArgs e)
        {
            UIHelper.TogglePasswordVisibility(txtPassword);
        }

        private void txtConfirmPass_IconRightClick(object sender, EventArgs e)
        {
            UIHelper.TogglePasswordVisibility(txtConfirmPass);
        }
    }
}
