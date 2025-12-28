namespace CoolMaster
{
    partial class frmSignInQR
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
            this.guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.pnlQRLogin = new Guna.UI2.WinForms.Guna2Panel();
            this.picQRCode = new Guna.UI2.WinForms.Guna2PictureBox();
            this.btnXacNhanQRLogin = new Guna.UI2.WinForms.Guna2GradientButton();
            this.lblEmailQR = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtEmailQR = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblInstruction = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnBackToSignIn = new Guna.UI2.WinForms.Guna2GradientButton();
            this.guna2GradientPanel1.SuspendLayout();
            this.pnlQRLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picQRCode)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2GradientPanel1
            // 
            this.guna2GradientPanel1.Controls.Add(this.pnlQRLogin);
            this.guna2GradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2GradientPanel1.FillColor = System.Drawing.Color.DodgerBlue;
            this.guna2GradientPanel1.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(9)))), ((int)(((byte)(60)))));
            this.guna2GradientPanel1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.guna2GradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.guna2GradientPanel1.Name = "guna2GradientPanel1";
            this.guna2GradientPanel1.Size = new System.Drawing.Size(550, 550);
            this.guna2GradientPanel1.TabIndex = 0;
            // 
            // pnlQRLogin
            // 
            this.pnlQRLogin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlQRLogin.BackColor = System.Drawing.Color.Transparent;
            this.pnlQRLogin.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.pnlQRLogin.BorderThickness = 2;
            this.pnlQRLogin.Controls.Add(this.btnBackToSignIn);
            this.pnlQRLogin.Controls.Add(this.btnXacNhanQRLogin);
            this.pnlQRLogin.Controls.Add(this.lblEmailQR);
            this.pnlQRLogin.Controls.Add(this.txtEmailQR);
            this.pnlQRLogin.Controls.Add(this.lblInstruction);
            this.pnlQRLogin.Controls.Add(this.picQRCode);
            this.pnlQRLogin.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.pnlQRLogin.Location = new System.Drawing.Point(0, 0);
            this.pnlQRLogin.Name = "pnlQRLogin";
            this.pnlQRLogin.Size = new System.Drawing.Size(550, 550);
            this.pnlQRLogin.TabIndex = 2;
            this.pnlQRLogin.Visible = false;
            // 
            // picQRCode
            // 
            this.picQRCode.ImageRotate = 0F;
            this.picQRCode.Location = new System.Drawing.Point(75, 75);
            this.picQRCode.Name = "picQRCode";
            this.picQRCode.Size = new System.Drawing.Size(400, 400);
            this.picQRCode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picQRCode.TabIndex = 0;
            this.picQRCode.TabStop = false;
            this.picQRCode.Visible = false;
            // 
            // btnXacNhanQRLogin
            // 
            this.btnXacNhanQRLogin.BackColor = System.Drawing.Color.White;
            this.btnXacNhanQRLogin.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnXacNhanQRLogin.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnXacNhanQRLogin.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnXacNhanQRLogin.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnXacNhanQRLogin.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnXacNhanQRLogin.FillColor = System.Drawing.Color.DodgerBlue;
            this.btnXacNhanQRLogin.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(80)))), ((int)(((byte)(255)))));
            this.btnXacNhanQRLogin.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXacNhanQRLogin.ForeColor = System.Drawing.Color.White;
            this.btnXacNhanQRLogin.Location = new System.Drawing.Point(124, 298);
            this.btnXacNhanQRLogin.Name = "btnXacNhanQRLogin";
            this.btnXacNhanQRLogin.Size = new System.Drawing.Size(300, 45);
            this.btnXacNhanQRLogin.TabIndex = 13;
            this.btnXacNhanQRLogin.Text = "Xác Nhận";
            this.btnXacNhanQRLogin.Click += new System.EventHandler(this.btnXacNhanQRLogin_Click);
            // 
            // lblEmailQR
            // 
            this.lblEmailQR.BackColor = System.Drawing.Color.Transparent;
            this.lblEmailQR.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblEmailQR.ForeColor = System.Drawing.Color.White;
            this.lblEmailQR.Location = new System.Drawing.Point(125, 201);
            this.lblEmailQR.Name = "lblEmailQR";
            this.lblEmailQR.Size = new System.Drawing.Size(92, 22);
            this.lblEmailQR.TabIndex = 12;
            this.lblEmailQR.Text = "Địa Chỉ Email";
            // 
            // txtEmailQR
            // 
            this.txtEmailQR.BackColor = System.Drawing.Color.White;
            this.txtEmailQR.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtEmailQR.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEmailQR.DefaultText = "";
            this.txtEmailQR.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtEmailQR.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtEmailQR.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmailQR.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmailQR.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(137)))), ((int)(((byte)(207)))));
            this.txtEmailQR.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmailQR.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtEmailQR.ForeColor = System.Drawing.Color.White;
            this.txtEmailQR.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmailQR.IconLeft = global::CoolMaster.Properties.Resources.IconEmail;
            this.txtEmailQR.IconLeftOffset = new System.Drawing.Point(-15, 0);
            this.txtEmailQR.IconLeftSize = new System.Drawing.Size(75, 50);
            this.txtEmailQR.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtEmailQR.Location = new System.Drawing.Point(125, 231);
            this.txtEmailQR.Name = "txtEmailQR";
            this.txtEmailQR.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.txtEmailQR.PlaceholderText = "Nhập Email của bạn";
            this.txtEmailQR.SelectedText = "";
            this.txtEmailQR.Size = new System.Drawing.Size(300, 45);
            this.txtEmailQR.TabIndex = 11;
            this.txtEmailQR.TextOffset = new System.Drawing.Point(-15, 0);
            // 
            // lblInstruction
            // 
            this.lblInstruction.BackColor = System.Drawing.Color.Transparent;
            this.lblInstruction.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstruction.ForeColor = System.Drawing.Color.White;
            this.lblInstruction.Location = new System.Drawing.Point(122, 504);
            this.lblInstruction.Name = "lblInstruction";
            this.lblInstruction.Size = new System.Drawing.Size(307, 22);
            this.lblInstruction.TabIndex = 1;
            this.lblInstruction.Text = "Đã gửi Mã QR vào Email. Mã có hiệu lực 120s.";
            this.lblInstruction.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblInstruction.Visible = false;
            // 
            // btnBackToSignIn
            // 
            this.btnBackToSignIn.BackColor = System.Drawing.Color.Transparent;
            this.btnBackToSignIn.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(97)))), ((int)(((byte)(163)))));
            this.btnBackToSignIn.BorderRadius = 10;
            this.btnBackToSignIn.BorderThickness = 1;
            this.btnBackToSignIn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnBackToSignIn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnBackToSignIn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnBackToSignIn.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnBackToSignIn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnBackToSignIn.FillColor = System.Drawing.Color.DodgerBlue;
            this.btnBackToSignIn.FillColor2 = System.Drawing.Color.DodgerBlue;
            this.btnBackToSignIn.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackToSignIn.ForeColor = System.Drawing.Color.White;
            this.btnBackToSignIn.Image = global::CoolMaster.Properties.Resources.IconBack;
            this.btnBackToSignIn.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnBackToSignIn.ImageOffset = new System.Drawing.Point(-10, 0);
            this.btnBackToSignIn.ImageSize = new System.Drawing.Size(200, 80);
            this.btnBackToSignIn.Location = new System.Drawing.Point(471, 12);
            this.btnBackToSignIn.Name = "btnBackToSignIn";
            this.btnBackToSignIn.Size = new System.Drawing.Size(67, 45);
            this.btnBackToSignIn.TabIndex = 21;
            this.btnBackToSignIn.Click += new System.EventHandler(this.btnBackToSignIn_Click);
            // 
            // frmSignInQR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 550);
            this.Controls.Add(this.guna2GradientPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSignInQR";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmSignInQR";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSignInQR_FormClosing);
            this.Load += new System.EventHandler(this.frmSignInQR_Load);
            this.guna2GradientPanel1.ResumeLayout(false);
            this.pnlQRLogin.ResumeLayout(false);
            this.pnlQRLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picQRCode)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
        private Guna.UI2.WinForms.Guna2Panel pnlQRLogin;
        private Guna.UI2.WinForms.Guna2PictureBox picQRCode;
        private Guna.UI2.WinForms.Guna2GradientButton btnXacNhanQRLogin;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblEmailQR;
        private Guna.UI2.WinForms.Guna2TextBox txtEmailQR;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblInstruction;
        private Guna.UI2.WinForms.Guna2GradientButton btnBackToSignIn;
    }
}