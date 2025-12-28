using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CoolMaster.Common;
using CoolMaster.Services;
using CoolMaster.Model;

namespace CoolMaster
{
    public partial class frmSignIn : Form
    {
        private readonly AuthService _authService = new AuthService();

        // Expose logged user so Program.Main có thể lấy
        public User LoggedUser { get; private set; }

        public frmSignIn()
        {
            InitializeComponent();
            this.AcceptButton = btnLogin;

            //Hiệu ứng giao diện
            btnSignUp.Cursor = Cursors.Hand;
            btnSignUp.Font = new Font(btnSignUp.Font, FontStyle.Underline);
            btnForgotPassword.Cursor = Cursors.Hand;
            btnForgotPassword.Font = new Font(btnForgotPassword.Font, FontStyle.Underline);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // Xử lý ẩn/hiện mật khẩu
        private void txtPassWord_IconRightClick(object sender, EventArgs e)
        {
            UIHelper.TogglePasswordVisibility(txtPassword);
        }

        // Xử lý nút Đăng nhập
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userId = txtUserID.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tài khoản và mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // GỌI SERVICE
                var user = _authService.Login(userId, password);

                if (user != null)
                {
                    // Lưu user đã đăng nhập để bên ngoài (Program.Main) truy xuất
                    LoggedUser = user;

                    MessageBox.Show($"Đăng nhập thành công! Xin chào {user.Role} {user.FullName}", "Thông báo");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác!", "Lỗi Đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }                    
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message);
            }
        }

        // Xử lý nút Đăng ký
        private void btnSignUp_Click(object sender, EventArgs e)
        {
            frmSignUp reg = new frmSignUp();
            this.Hide();
            reg.ShowDialog();
            this.Show();
        }

        private void btnSignUp_MouseEnter(object sender, EventArgs e)
        {
            btnSignUp.ForeColor = Color.Cyan;
        }

        private void btnSignUp_MouseLeave(object sender, EventArgs e)
        {
            btnSignUp.ForeColor = Color.DeepSkyBlue;
        }

        // Xử lý nút Quên mật khẩu
        private void btnForgotPassword_Click(object sender, EventArgs e)
        {
            try
            {
                frmForgotPassword forgotPass = new frmForgotPassword();
                this.Hide();
                forgotPass.ShowDialog();
                this.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi mở form Quên mật khẩu: " + ex.Message + "\n" + ex.StackTrace);
            }
        }

        private void btnForgotPassword_MouseEnter(object sender, EventArgs e)
        {
            btnForgotPassword.ForeColor = Color.Cyan;
        }

        private void btnForgotPassword_MouseLeave(object sender, EventArgs e)
        {
            btnForgotPassword.ForeColor = Color.DeepSkyBlue;
        }
        
        private void btnLoginQR_Click(object sender, EventArgs e)
        {
            frmSignInQR frmQr = new frmSignInQR();
            this.Hide();

            if (frmQr.ShowDialog() == DialogResult.OK)
            {
                // Nếu dùng QR login, có thể set LoggedUser trong frmSignInQR tương tự
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                this.Show();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
