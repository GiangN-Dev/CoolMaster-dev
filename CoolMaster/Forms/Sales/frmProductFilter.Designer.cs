namespace CoolMaster.Forms.Sales
{
    partial class frmProductFilter
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
            this.pnlHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlFooter = new Guna.UI2.WinForms.Guna2Panel();
            this.btnReset = new Guna.UI2.WinForms.Guna2Button();
            this.btnApply = new Guna.UI2.WinForms.Guna2Button();
            this.pnlBody = new Guna.UI2.WinForms.Guna2Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numPriceTo = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.numPriceFrom = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.cboStockStatus = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboBrand = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboCategory = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblKeyword = new System.Windows.Forms.Label();
            this.txtKeyword = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnClose = new FontAwesome.Sharp.IconButton();
            this.pnlHeader.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.pnlBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPriceTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPriceFrom)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.BorderRadius = 15;
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.ShadowColor = System.Drawing.Color.DimGray;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.btnClose);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(500, 50);
            this.pnlHeader.TabIndex = 2;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(57)))), ((int)(((byte)(142)))));
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(133, 21);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "BỘ LỌC DỮ LIỆU";
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.White;
            this.pnlFooter.Controls.Add(this.btnReset);
            this.pnlFooter.Controls.Add(this.btnApply);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 450);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(500, 70);
            this.pnlFooter.TabIndex = 1;
            // 
            // btnReset
            // 
            this.btnReset.BorderColor = System.Drawing.Color.Silver;
            this.btnReset.BorderRadius = 10;
            this.btnReset.BorderThickness = 1;
            this.btnReset.FillColor = System.Drawing.Color.White;
            this.btnReset.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnReset.ForeColor = System.Drawing.Color.Black;
            this.btnReset.Location = new System.Drawing.Point(211, 15);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(99, 40);
            this.btnReset.TabIndex = 0;
            this.btnReset.Text = "Làm mới";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnApply
            // 
            this.btnApply.BorderRadius = 10;
            this.btnApply.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(57)))), ((int)(((byte)(142)))));
            this.btnApply.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnApply.ForeColor = System.Drawing.Color.White;
            this.btnApply.Location = new System.Drawing.Point(319, 15);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(170, 40);
            this.btnApply.TabIndex = 1;
            this.btnApply.Text = "Áp dụng bộ lọc";
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // pnlBody
            // 
            this.pnlBody.BackColor = System.Drawing.Color.White;
            this.pnlBody.Controls.Add(this.label5);
            this.pnlBody.Controls.Add(this.label4);
            this.pnlBody.Controls.Add(this.numPriceTo);
            this.pnlBody.Controls.Add(this.numPriceFrom);
            this.pnlBody.Controls.Add(this.label3);
            this.pnlBody.Controls.Add(this.cboStockStatus);
            this.pnlBody.Controls.Add(this.label2);
            this.pnlBody.Controls.Add(this.cboBrand);
            this.pnlBody.Controls.Add(this.label1);
            this.pnlBody.Controls.Add(this.cboCategory);
            this.pnlBody.Controls.Add(this.lblKeyword);
            this.pnlBody.Controls.Add(this.txtKeyword);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 50);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(500, 400);
            this.pnlBody.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.DimGray;
            this.label5.Location = new System.Drawing.Point(270, 260);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "Đến";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(30, 260);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 15);
            this.label4.TabIndex = 1;
            this.label4.Text = "Khoảng giá (Từ)";
            // 
            // numPriceTo
            // 
            this.numPriceTo.BackColor = System.Drawing.Color.Transparent;
            this.numPriceTo.BorderRadius = 10;
            this.numPriceTo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.numPriceTo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numPriceTo.Location = new System.Drawing.Point(270, 280);
            this.numPriceTo.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numPriceTo.Name = "numPriceTo";
            this.numPriceTo.Size = new System.Drawing.Size(200, 40);
            this.numPriceTo.TabIndex = 2;
            // 
            // numPriceFrom
            // 
            this.numPriceFrom.BackColor = System.Drawing.Color.Transparent;
            this.numPriceFrom.BorderRadius = 10;
            this.numPriceFrom.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.numPriceFrom.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numPriceFrom.Location = new System.Drawing.Point(30, 280);
            this.numPriceFrom.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numPriceFrom.Name = "numPriceFrom";
            this.numPriceFrom.Size = new System.Drawing.Size(200, 40);
            this.numPriceFrom.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(30, 180);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Trạng thái tồn kho";
            // 
            // cboStockStatus
            // 
            this.cboStockStatus.BackColor = System.Drawing.Color.Transparent;
            this.cboStockStatus.BorderRadius = 10;
            this.cboStockStatus.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboStockStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStockStatus.FocusedColor = System.Drawing.Color.Empty;
            this.cboStockStatus.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboStockStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboStockStatus.ItemHeight = 30;
            this.cboStockStatus.Location = new System.Drawing.Point(30, 200);
            this.cboStockStatus.Name = "cboStockStatus";
            this.cboStockStatus.Size = new System.Drawing.Size(440, 36);
            this.cboStockStatus.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(260, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Thương hiệu";
            // 
            // cboBrand
            // 
            this.cboBrand.BackColor = System.Drawing.Color.Transparent;
            this.cboBrand.BorderRadius = 10;
            this.cboBrand.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboBrand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBrand.FocusedColor = System.Drawing.Color.Empty;
            this.cboBrand.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboBrand.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboBrand.ItemHeight = 30;
            this.cboBrand.Location = new System.Drawing.Point(260, 120);
            this.cboBrand.Name = "cboBrand";
            this.cboBrand.Size = new System.Drawing.Size(210, 36);
            this.cboBrand.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(30, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "Danh mục";
            // 
            // cboCategory
            // 
            this.cboCategory.BackColor = System.Drawing.Color.Transparent;
            this.cboCategory.BorderRadius = 10;
            this.cboCategory.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategory.FocusedColor = System.Drawing.Color.Empty;
            this.cboCategory.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboCategory.ItemHeight = 30;
            this.cboCategory.Location = new System.Drawing.Point(30, 120);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(210, 36);
            this.cboCategory.TabIndex = 9;
            // 
            // lblKeyword
            // 
            this.lblKeyword.AutoSize = true;
            this.lblKeyword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblKeyword.ForeColor = System.Drawing.Color.DimGray;
            this.lblKeyword.Location = new System.Drawing.Point(30, 25);
            this.lblKeyword.Name = "lblKeyword";
            this.lblKeyword.Size = new System.Drawing.Size(105, 15);
            this.lblKeyword.TabIndex = 10;
            this.lblKeyword.Text = "Từ khóa tìm kiếm";
            // 
            // txtKeyword
            // 
            this.txtKeyword.BorderRadius = 10;
            this.txtKeyword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtKeyword.DefaultText = "";
            this.txtKeyword.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtKeyword.Location = new System.Drawing.Point(30, 45);
            this.txtKeyword.Name = "txtKeyword";
            this.txtKeyword.PlaceholderText = "Nhập tên sản phẩm hoặc mã vạch...";
            this.txtKeyword.SelectedText = "";
            this.txtKeyword.Size = new System.Drawing.Size(440, 40);
            this.txtKeyword.TabIndex = 11;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.IconChar = FontAwesome.Sharp.IconChar.Remove;
            this.btnClose.IconColor = System.Drawing.Color.Gray;
            this.btnClose.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnClose.IconSize = 24;
            this.btnClose.Location = new System.Drawing.Point(460, 10);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(30, 30);
            this.btnClose.TabIndex = 1;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmProductFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.ClientSize = new System.Drawing.Size(500, 520);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmProductFilter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Advanced Filter";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.pnlBody.ResumeLayout(false);
            this.pnlBody.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPriceTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPriceFrom)).EndInit();
            this.ResumeLayout(false);

        }

       

    

        #endregion
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private FontAwesome.Sharp.IconButton btnClose;
        private Guna.UI2.WinForms.Guna2Panel pnlFooter;
        private Guna.UI2.WinForms.Guna2Button btnApply;
        private Guna.UI2.WinForms.Guna2Button btnReset;
        private Guna.UI2.WinForms.Guna2Panel pnlBody;
        private Guna.UI2.WinForms.Guna2TextBox txtKeyword;
        private System.Windows.Forms.Label lblKeyword;
        private Guna.UI2.WinForms.Guna2ComboBox cboCategory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2ComboBox cboBrand;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2ComboBox cboStockStatus;
        private Guna.UI2.WinForms.Guna2NumericUpDown numPriceFrom;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2NumericUpDown numPriceTo;
        private System.Windows.Forms.Label label5;
    }
}