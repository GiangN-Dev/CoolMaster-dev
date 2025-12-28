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

namespace CoolMaster.Forms.Settings
{
    public partial class frmSettings : Form
    {
        private readonly User _currentUser;
        private readonly DatabaseService _dbService;

        public frmSettings(User user)
        {
            InitializeComponent();
            _currentUser = user;
            _dbService = new DatabaseService();

            // Gán sự kiện
            btnLogout.Click += BtnLogout_Click;
            btnChangePass.Click += BtnChangePass_Click;
            btnRegister.Click += BtnRegister_Click;
            btnBackup.Click += BtnBackup_Click;
            btnRestore.Click += BtnRestore_Click;
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Restart();
                Environment.Exit(0);
            }
        }

        private void BtnChangePass_Click(object sender, EventArgs e)
        {
            frmForgotPassword frm = new frmForgotPassword(_currentUser);
            frm.ShowDialog();
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            if (_currentUser.Role != "Quản lý")
            {
                MessageBox.Show("Chức năng này chỉ dành cho Quản lý (Admin).", "Không có quyền truy cập", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            frmSignUp frm = new frmSignUp();
            frm.ShowDialog();
        }

        private async void BtnBackup_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Backup Files (*.bak)|*.bak";
                sfd.FileName = $"CoolMaster_Backup_{DateTime.Now:yyyyMMdd_HHmmss}.bak";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        this.Cursor = Cursors.WaitCursor;
                        await _dbService.BackupDatabase(sfd.FileName);
                        MessageBox.Show("Sao lưu dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi sao lưu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        this.Cursor = Cursors.Default;
                    }
                }
            }
        }

        private async void BtnRestore_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("CẢNH BÁO QUAN TRỌNG!\n\n1. Hành động này sẽ XÓA SẠCH dữ liệu hiện tại và thay thế bằng dữ liệu từ file sao lưu.\n2. Ứng dụng sẽ khởi động lại ngay sau khi phục hồi.\n\nBạn có chắc chắn muốn tiếp tục?",
               "Xác nhận phục hồi", MessageBoxButtons.YesNo, MessageBoxIcon.Error) != DialogResult.Yes)
                return;

            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Backup Files (*.bak)|*.bak";
                ofd.Title = "Chọn file sao lưu để phục hồi";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        this.Cursor = Cursors.WaitCursor;

                        // Gọi Service Restore
                        await _dbService.RestoreDatabase(ofd.FileName);

                        MessageBox.Show("Phục hồi thành công! Ứng dụng sẽ khởi động lại để áp dụng dữ liệu mới.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Khởi động lại ứng dụng
                        Application.Restart();
                        Environment.Exit(0);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi phục hồi: " + ex.Message + "\n\n(Đảm bảo file .bak hợp lệ và không bị sử dụng bởi tiến trình khác)", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        this.Cursor = Cursors.Default;
                    }
                }
            }
        }

    }
}
