namespace CoolMaster.Forms.Settings
{
    partial class frmSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.gbDatabase = new System.Windows.Forms.GroupBox();
            this.btnBackup = new FontAwesome.Sharp.IconButton();
            this.btnRestore = new FontAwesome.Sharp.IconButton();
            this.gbAccount = new System.Windows.Forms.GroupBox();
            this.btnLogout = new FontAwesome.Sharp.IconButton();
            this.btnChangePass = new FontAwesome.Sharp.IconButton();
            this.btnRegister = new FontAwesome.Sharp.IconButton();
            this.pnlContainer.SuspendLayout();
            this.gbDatabase.SuspendLayout();
            this.gbAccount.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContainer
            // 
            this.pnlContainer.Controls.Add(this.gbDatabase);
            this.pnlContainer.Controls.Add(this.gbAccount);
            this.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContainer.Location = new System.Drawing.Point(0, 0);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Padding = new System.Windows.Forms.Padding(50);
            this.pnlContainer.Size = new System.Drawing.Size(990, 595);
            this.pnlContainer.TabIndex = 0;
            // 
            // gbDatabase
            // 
            this.gbDatabase.Controls.Add(this.btnBackup);
            this.gbDatabase.Controls.Add(this.btnRestore);
            this.gbDatabase.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.gbDatabase.Location = new System.Drawing.Point(494, 31);
            this.gbDatabase.Name = "gbDatabase";
            this.gbDatabase.Size = new System.Drawing.Size(400, 300);
            this.gbDatabase.TabIndex = 0;
            this.gbDatabase.TabStop = false;
            this.gbDatabase.Text = "Dữ liệu (Sao lưu & Phục hồi)";
            // 
            // btnBackup
            // 
            this.btnBackup.BackColor = System.Drawing.Color.Gray;
            this.btnBackup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackup.ForeColor = System.Drawing.Color.White;
            this.btnBackup.IconChar = FontAwesome.Sharp.IconChar.Database;
            this.btnBackup.IconColor = System.Drawing.Color.White;
            this.btnBackup.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBackup.IconSize = 40;
            this.btnBackup.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBackup.Location = new System.Drawing.Point(30, 50);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnBackup.Size = new System.Drawing.Size(340, 50);
            this.btnBackup.TabIndex = 0;
            this.btnBackup.Text = "        Sao lưu dữ liệu (Backup)";
            this.btnBackup.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBackup.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBackup.UseVisualStyleBackColor = false;
            // 
            // btnRestore
            // 
            this.btnRestore.BackColor = System.Drawing.Color.Gray;
            this.btnRestore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestore.ForeColor = System.Drawing.Color.White;
            this.btnRestore.IconChar = FontAwesome.Sharp.IconChar.ArrowRotateBackward;
            this.btnRestore.IconColor = System.Drawing.Color.White;
            this.btnRestore.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnRestore.IconSize = 40;
            this.btnRestore.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRestore.Location = new System.Drawing.Point(30, 120);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnRestore.Size = new System.Drawing.Size(340, 50);
            this.btnRestore.TabIndex = 1;
            this.btnRestore.Text = "       Phục hồi dữ liệu (Restore)";
            this.btnRestore.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRestore.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRestore.UseVisualStyleBackColor = false;
            // 
            // gbAccount
            // 
            this.gbAccount.Controls.Add(this.btnLogout);
            this.gbAccount.Controls.Add(this.btnChangePass);
            this.gbAccount.Controls.Add(this.btnRegister);
            this.gbAccount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.gbAccount.Location = new System.Drawing.Point(44, 31);
            this.gbAccount.Name = "gbAccount";
            this.gbAccount.Size = new System.Drawing.Size(400, 300);
            this.gbAccount.TabIndex = 1;
            this.gbAccount.TabStop = false;
            this.gbAccount.Text = "Tài khoản";
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.Gray;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.IconChar = FontAwesome.Sharp.IconChar.RightFromBracket;
            this.btnLogout.IconColor = System.Drawing.Color.White;
            this.btnLogout.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnLogout.IconSize = 40;
            this.btnLogout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.Location = new System.Drawing.Point(30, 190);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnLogout.Size = new System.Drawing.Size(340, 50);
            this.btnLogout.TabIndex = 0;
            this.btnLogout.Text = "                Đăng xuất";
            this.btnLogout.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLogout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLogout.UseVisualStyleBackColor = false;
            // 
            // btnChangePass
            // 
            this.btnChangePass.BackColor = System.Drawing.Color.Gray;
            this.btnChangePass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangePass.ForeColor = System.Drawing.Color.White;
            this.btnChangePass.IconChar = FontAwesome.Sharp.IconChar.Key;
            this.btnChangePass.IconColor = System.Drawing.Color.White;
            this.btnChangePass.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnChangePass.IconSize = 40;
            this.btnChangePass.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnChangePass.Location = new System.Drawing.Point(30, 120);
            this.btnChangePass.Name = "btnChangePass";
            this.btnChangePass.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnChangePass.Size = new System.Drawing.Size(340, 50);
            this.btnChangePass.TabIndex = 1;
            this.btnChangePass.Text = "              Đổi mật khẩu";
            this.btnChangePass.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnChangePass.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnChangePass.UseVisualStyleBackColor = false;
            // 
            // btnRegister
            // 
            this.btnRegister.BackColor = System.Drawing.Color.Gray;
            this.btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegister.ForeColor = System.Drawing.Color.White;
            this.btnRegister.IconChar = FontAwesome.Sharp.IconChar.UserPlus;
            this.btnRegister.IconColor = System.Drawing.Color.White;
            this.btnRegister.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnRegister.IconSize = 40;
            this.btnRegister.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRegister.Location = new System.Drawing.Point(30, 50);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnRegister.Size = new System.Drawing.Size(340, 50);
            this.btnRegister.TabIndex = 2;
            this.btnRegister.Text = "          Đăng ký nhân viên";
            this.btnRegister.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRegister.UseVisualStyleBackColor = false;
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.ClientSize = new System.Drawing.Size(990, 595);
            this.Controls.Add(this.pnlContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSettings";
            this.Text = "Cài đặt hệ thống";
            this.pnlContainer.ResumeLayout(false);
            this.gbDatabase.ResumeLayout(false);
            this.gbAccount.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlContainer;
        private System.Windows.Forms.GroupBox gbAccount;
        private System.Windows.Forms.GroupBox gbDatabase;
        private FontAwesome.Sharp.IconButton btnRegister;
        private FontAwesome.Sharp.IconButton btnChangePass;
        private FontAwesome.Sharp.IconButton btnLogout;
        private FontAwesome.Sharp.IconButton btnBackup;
        private FontAwesome.Sharp.IconButton btnRestore;
    }
}