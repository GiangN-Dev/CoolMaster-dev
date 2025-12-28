namespace CoolMaster.Forms.Suppliers
{
    partial class frmSupplierDetail
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
            this.components = new System.ComponentModel.Container();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.pnlContainer = new Guna.UI2.WinForms.Guna2Panel();
            this.btnCancel = new Guna.UI2.WinForms.Guna2Button();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.txtAddress = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblTitleAddress = new System.Windows.Forms.Label();
            this.txtPhone = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblTitlePhone = new System.Windows.Forms.Label();
            this.txtContact = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblTitleContact = new System.Windows.Forms.Label();
            this.txtName = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblTitleName = new System.Windows.Forms.Label();
            this.lblHeader = new System.Windows.Forms.Label();
            this.pnlContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.BorderRadius = 10;
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.ShadowColor = System.Drawing.Color.DimGray;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // pnlContainer
            // 
            this.pnlContainer.BorderColor = System.Drawing.Color.LightGray;
            this.pnlContainer.BorderThickness = 1;
            this.pnlContainer.Controls.Add(this.btnCancel);
            this.pnlContainer.Controls.Add(this.btnSave);
            this.pnlContainer.Controls.Add(this.txtAddress);
            this.pnlContainer.Controls.Add(this.lblTitleAddress);
            this.pnlContainer.Controls.Add(this.txtPhone);
            this.pnlContainer.Controls.Add(this.lblTitlePhone);
            this.pnlContainer.Controls.Add(this.txtContact);
            this.pnlContainer.Controls.Add(this.lblTitleContact);
            this.pnlContainer.Controls.Add(this.txtName);
            this.pnlContainer.Controls.Add(this.lblTitleName);
            this.pnlContainer.Controls.Add(this.lblHeader);
            this.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContainer.Location = new System.Drawing.Point(0, 0);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(500, 480);
            this.pnlContainer.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.BorderColor = System.Drawing.Color.Silver;
            this.btnCancel.BorderRadius = 8;
            this.btnCancel.BorderThickness = 1;
            this.btnCancel.FillColor = System.Drawing.Color.Transparent;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.Location = new System.Drawing.Point(370, 410);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 40);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.BorderRadius = 8;
            this.btnSave.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(57)))), ((int)(((byte)(142)))));
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(250, 410);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 40);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Lưu lại";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtAddress
            // 
            this.txtAddress.BorderRadius = 5;
            this.txtAddress.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAddress.DefaultText = "";
            this.txtAddress.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtAddress.Location = new System.Drawing.Point(25, 300);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.PlaceholderText = "";
            this.txtAddress.SelectedText = "";
            this.txtAddress.Size = new System.Drawing.Size(450, 36);
            this.txtAddress.TabIndex = 4;
            // 
            // lblTitleAddress
            // 
            this.lblTitleAddress.AutoSize = true;
            this.lblTitleAddress.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTitleAddress.ForeColor = System.Drawing.Color.DimGray;
            this.lblTitleAddress.Location = new System.Drawing.Point(25, 280);
            this.lblTitleAddress.Name = "lblTitleAddress";
            this.lblTitleAddress.Size = new System.Drawing.Size(44, 15);
            this.lblTitleAddress.TabIndex = 7;
            this.lblTitleAddress.Text = "Địa chỉ";
            // 
            // txtPhone
            // 
            this.txtPhone.BorderRadius = 5;
            this.txtPhone.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPhone.DefaultText = "";
            this.txtPhone.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPhone.Location = new System.Drawing.Point(25, 230);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.PlaceholderText = "";
            this.txtPhone.SelectedText = "";
            this.txtPhone.Size = new System.Drawing.Size(450, 36);
            this.txtPhone.TabIndex = 3;
            // 
            // lblTitlePhone
            // 
            this.lblTitlePhone.AutoSize = true;
            this.lblTitlePhone.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTitlePhone.ForeColor = System.Drawing.Color.DimGray;
            this.lblTitlePhone.Location = new System.Drawing.Point(25, 210);
            this.lblTitlePhone.Name = "lblTitlePhone";
            this.lblTitlePhone.Size = new System.Drawing.Size(96, 15);
            this.lblTitlePhone.TabIndex = 5;
            this.lblTitlePhone.Text = "Số điện thoại (*)";
            // 
            // txtContact
            // 
            this.txtContact.BorderRadius = 5;
            this.txtContact.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtContact.DefaultText = "";
            this.txtContact.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtContact.Location = new System.Drawing.Point(25, 160);
            this.txtContact.Name = "txtContact";
            this.txtContact.PlaceholderText = "";
            this.txtContact.SelectedText = "";
            this.txtContact.Size = new System.Drawing.Size(450, 36);
            this.txtContact.TabIndex = 2;
            // 
            // lblTitleContact
            // 
            this.lblTitleContact.AutoSize = true;
            this.lblTitleContact.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTitleContact.ForeColor = System.Drawing.Color.DimGray;
            this.lblTitleContact.Location = new System.Drawing.Point(25, 140);
            this.lblTitleContact.Name = "lblTitleContact";
            this.lblTitleContact.Size = new System.Drawing.Size(82, 15);
            this.lblTitleContact.TabIndex = 3;
            this.lblTitleContact.Text = "Người liên hệ";
            // 
            // txtName
            // 
            this.txtName.BorderRadius = 5;
            this.txtName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtName.DefaultText = "";
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtName.Location = new System.Drawing.Point(25, 90);
            this.txtName.Name = "txtName";
            this.txtName.PlaceholderText = "";
            this.txtName.SelectedText = "";
            this.txtName.Size = new System.Drawing.Size(450, 36);
            this.txtName.TabIndex = 1;
            // 
            // lblTitleName
            // 
            this.lblTitleName.AutoSize = true;
            this.lblTitleName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTitleName.ForeColor = System.Drawing.Color.DimGray;
            this.lblTitleName.Location = new System.Drawing.Point(25, 70);
            this.lblTitleName.Name = "lblTitleName";
            this.lblTitleName.Size = new System.Drawing.Size(122, 15);
            this.lblTitleName.TabIndex = 1;
            this.lblTitleName.Text = "Tên Nhà Cung Cấp (*)";
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(57)))), ((int)(((byte)(142)))));
            this.lblHeader.Location = new System.Drawing.Point(20, 20);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(268, 25);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "THÔNG TIN NHÀ CUNG CẤP";
            // 
            // frmSupplierDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(500, 480);
            this.Controls.Add(this.pnlContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSupplierDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chi tiết Nhà Cung Cấp";
            this.pnlContainer.ResumeLayout(false);
            this.pnlContainer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2Panel pnlContainer;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblTitleName;
        private Guna.UI2.WinForms.Guna2TextBox txtName;
        private System.Windows.Forms.Label lblTitleContact;
        private Guna.UI2.WinForms.Guna2TextBox txtContact;
        private System.Windows.Forms.Label lblTitlePhone;
        private Guna.UI2.WinForms.Guna2TextBox txtPhone;
        private System.Windows.Forms.Label lblTitleAddress;
        private Guna.UI2.WinForms.Guna2TextBox txtAddress;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private Guna.UI2.WinForms.Guna2Button btnCancel;
    }
}