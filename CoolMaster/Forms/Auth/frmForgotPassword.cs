using CoolMaster.Common;
using CoolMaster.Model;
using CoolMaster.Services;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace CoolMaster
{
    public partial class frmForgotPassword : Form
    {
        // 1: Nhập Email, 2: Nhập OTP, 3: Đổi mật khẩu
        private int currentStep = 1;
        private string targetEmail = "";
        private readonly AuthService _authService = new AuthService();
        private readonly User _currentUser;

        public frmForgotPassword()
        {
            InitializeComponent();
            SetupUI_Step1();
        }

        public frmForgotPassword(User user) : this()
        {
            _currentUser = user;
            targetEmail = user.Email;

            SetupUI_Step3();

            if (btnBackToSignIn != null) btnBackToSignIn.Visible = false;
        }

        // --- HÀM ĐIỀU KHIỂN GIAO DIỆN ---
        private void SetupUI_Step1()
        {
            currentStep = 1;
            ToggleVisible(true, false, false);
            btnAction.Text = "Xác nhận";
            lblMessage.Text = "Vui lòng nhập Email để nhận mã.";
            txtEmail.Focus();
        }

        private void SetupUI_Step2()
        {
            currentStep = 2;
            ToggleVisible(false, true, false);
            btnAction.Text = "XÁC NHẬN OTP";
            txtOTP.Clear();
            txtOTP.Focus();
            lblMessage.Text = "Mã OTP có hiệu lực trong 120 giây.";
        }

        private void SetupUI_Step3()
        {
            currentStep = 3;
            ToggleVisible(false, false, true);
            btnAction.Text = "ĐỔI MẬT KHẨU";
            txtNewPass.Focus();
            lblMessage.Text = "Nhập mật khẩu mới của bạn.";
        }

        // Hàm phụ để ẩn hiện các textbox cho gọn code
        private void ToggleVisible(bool showEmail, bool showOTP, bool showPass)
        {
            txtEmail.Visible = showEmail;
            txtOTP.Visible = showOTP;
            txtNewPass.Visible = showPass;
            txtConfirmPass.Visible = showPass;
        }
        // --- XỬ SỰ KIỆN ---
        private void btnAction_Click(object sender, EventArgs e)
        {
            switch (currentStep)
            {
                case 1: XuLy_GuiMa(); break;
                case 2: XuLy_KiemTraOTP(); break;
                case 3: XuLy_DoiMatKhau(); break;
            }
        }


        // Bước 1: Gửi mã OTP
        private void XuLy_GuiMa()
        {
            string email = txtEmail.Text.Trim();
            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Vui lòng nhập Email!");
                return;
            }

            try
            {
                // Gọi Service
                if (_authService.ForgotPassword_SendOTP(email))
                {
                    targetEmail = email;
                    MessageBox.Show("Mã OTP đã được gửi!", "Thông báo");
                    SetupUI_Step2();
                }
                else
                {
                    MessageBox.Show("Email không tồn tại hoặc lỗi gửi mail.", "Lỗi");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống" + ex.Message);
            }
        }

        // BƯỚC 2: KIỂM TRA OTP
        private void XuLy_KiemTraOTP()
        {
            string inputOTP = txtOTP.Text.Trim();

            // Gọi Service
            if (_authService.ForgotPassword_VerifyOTP(targetEmail, inputOTP))
            {
                SetupUI_Step3();
            }
            else
            {
                MessageBox.Show("Mã OTP không đúng hoặc đã hết hạn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // BƯỚC 3: ĐỔI PASS
        private void XuLy_DoiMatKhau()
        {
            string pass = txtNewPass.Text.Trim();
            string confirm = txtConfirmPass.Text.Trim();

            if (pass.Length < 5) { MessageBox.Show("Mật khẩu phải từ 5 ký tự trở lên"); return; }
            if (pass != confirm) { MessageBox.Show("Mật khẩu nhập lại không khớp"); return; }

            // Gọi Service
            if (_authService.ForgotPassword_ResetPassword(targetEmail, pass))
            {
                MessageBox.Show("Đổi mật khẩu thành công! Hãy đăng nhập lại.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra khi cập nhật mật khẩu.");
            }
        }

        // Xử lý ẩn/hiện mật khẩu
        private void txtConfirmPass_IconRightClick(object sender, EventArgs e)
        {
            UIHelper.TogglePasswordVisibility(txtConfirmPass);
        }

        private void txtNewPass_IconRightClick(object sender, EventArgs e)
        {
            UIHelper.TogglePasswordVisibility(txtNewPass);
        }

        private void btnBackToSignIn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
