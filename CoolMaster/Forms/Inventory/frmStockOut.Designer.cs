namespace CoolMaster.Forms.Inventory
{
    partial class frmStockOut
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.lblTitleLeft = new System.Windows.Forms.Label();
            this.txtSearchProduct = new Guna.UI2.WinForms.Guna2TextBox();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.dgvExportItems = new System.Windows.Forms.DataGridView();
            this.pnlPayment = new System.Windows.Forms.Panel();
            this.lblTotalLabel = new System.Windows.Forms.Label();
            this.lblTotalMoney = new System.Windows.Forms.Label();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.btnCancel = new Guna.UI2.WinForms.Guna2Button();
            this.pnlInfo = new System.Windows.Forms.Panel();
            this.lblTitleRight = new System.Windows.Forms.Label();
            this.dtpExportDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.pnlSearch.SuspendLayout();
            this.pnlRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExportItems)).BeginInit();
            this.pnlPayment.SuspendLayout();
            this.pnlInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.dgvProducts);
            this.pnlLeft.Controls.Add(this.pnlSearch);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(10);
            this.pnlLeft.Size = new System.Drawing.Size(600, 700);
            this.pnlLeft.TabIndex = 0;
            // 
            // dgvProducts
            // 
            this.dgvProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProducts.Location = new System.Drawing.Point(10, 130);
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.Size = new System.Drawing.Size(580, 560);
            this.dgvProducts.TabIndex = 0;
            // 
            // pnlSearch
            // 
            this.pnlSearch.Controls.Add(this.lblTitleLeft);
            this.pnlSearch.Controls.Add(this.txtSearchProduct);
            this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearch.Location = new System.Drawing.Point(10, 10);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(580, 120);
            this.pnlSearch.TabIndex = 1;
            // 
            // lblTitleLeft
            // 
            this.lblTitleLeft.AutoSize = true;
            this.lblTitleLeft.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitleLeft.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(57)))), ((int)(((byte)(142)))));
            this.lblTitleLeft.Location = new System.Drawing.Point(10, 10);
            this.lblTitleLeft.Name = "lblTitleLeft";
            this.lblTitleLeft.Size = new System.Drawing.Size(292, 32);
            this.lblTitleLeft.TabIndex = 0;
            this.lblTitleLeft.Text = "CHỌN HÀNG XUẤT KHO";
            // 
            // txtSearchProduct
            // 
            this.txtSearchProduct.BorderRadius = 5;
            this.txtSearchProduct.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearchProduct.DefaultText = "";
            this.txtSearchProduct.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSearchProduct.Location = new System.Drawing.Point(3, 64);
            this.txtSearchProduct.Name = "txtSearchProduct";
            this.txtSearchProduct.PlaceholderText = "Tìm theo tên hoặc mã vạch...";
            this.txtSearchProduct.SelectedText = "";
            this.txtSearchProduct.Size = new System.Drawing.Size(574, 36);
            this.txtSearchProduct.TabIndex = 1;
            this.txtSearchProduct.TextChanged += new System.EventHandler(this.txtSearchProduct_TextChanged);
            // 
            // pnlRight
            // 
            this.pnlRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(251)))), ((int)(((byte)(252)))));
            this.pnlRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRight.Controls.Add(this.dgvExportItems);
            this.pnlRight.Controls.Add(this.pnlPayment);
            this.pnlRight.Controls.Add(this.pnlInfo);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlRight.Location = new System.Drawing.Point(600, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(440, 700);
            this.pnlRight.TabIndex = 1;
            // 
            // dgvExportItems
            // 
            this.dgvExportItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvExportItems.Location = new System.Drawing.Point(0, 73);
            this.dgvExportItems.Name = "dgvExportItems";
            this.dgvExportItems.Size = new System.Drawing.Size(438, 485);
            this.dgvExportItems.TabIndex = 0;
            // 
            // pnlPayment
            // 
            this.pnlPayment.BackColor = System.Drawing.Color.White;
            this.pnlPayment.Controls.Add(this.lblTotalLabel);
            this.pnlPayment.Controls.Add(this.lblTotalMoney);
            this.pnlPayment.Controls.Add(this.btnSave);
            this.pnlPayment.Controls.Add(this.btnCancel);
            this.pnlPayment.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlPayment.Location = new System.Drawing.Point(0, 558);
            this.pnlPayment.Name = "pnlPayment";
            this.pnlPayment.Size = new System.Drawing.Size(438, 140);
            this.pnlPayment.TabIndex = 1;
            // 
            // lblTotalLabel
            // 
            this.lblTotalLabel.Location = new System.Drawing.Point(15, 15);
            this.lblTotalLabel.Name = "lblTotalLabel";
            this.lblTotalLabel.Size = new System.Drawing.Size(100, 23);
            this.lblTotalLabel.TabIndex = 0;
            this.lblTotalLabel.Text = "TỔNG GIÁ TRỊ XUẤT:";
            // 
            // lblTotalMoney
            // 
            this.lblTotalMoney.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTotalMoney.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(81)))), ((int)(((byte)(0)))));
            this.lblTotalMoney.Location = new System.Drawing.Point(150, 5);
            this.lblTotalMoney.Name = "lblTotalMoney";
            this.lblTotalMoney.Size = new System.Drawing.Size(275, 45);
            this.lblTotalMoney.TabIndex = 1;
            this.lblTotalMoney.Text = "0 đ";
            this.lblTotalMoney.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnSave
            // 
            this.btnSave.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(57)))), ((int)(((byte)(142)))));
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(215, 70);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(210, 55);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "XUẤT KHO (F5)";
            // 
            // btnCancel
            // 
            this.btnCancel.FillColor = System.Drawing.Color.Gray;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(15, 70);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(190, 55);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "HỦY";
            // 
            // pnlInfo
            // 
            this.pnlInfo.Controls.Add(this.lblTitleRight);
            this.pnlInfo.Controls.Add(this.dtpExportDate);
            this.pnlInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlInfo.Location = new System.Drawing.Point(0, 0);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Size = new System.Drawing.Size(438, 73);
            this.pnlInfo.TabIndex = 2;
            // 
            // lblTitleRight
            // 
            this.lblTitleRight.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitleRight.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(57)))), ((int)(((byte)(142)))));
            this.lblTitleRight.Location = new System.Drawing.Point(15, 15);
            this.lblTitleRight.Name = "lblTitleRight";
            this.lblTitleRight.Size = new System.Drawing.Size(100, 23);
            this.lblTitleRight.TabIndex = 0;
            this.lblTitleRight.Text = "THÔNG TIN PHIẾU XUẤT";
            // 
            // dtpExportDate
            // 
            this.dtpExportDate.Checked = true;
            this.dtpExportDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpExportDate.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpExportDate.Location = new System.Drawing.Point(285, 10);
            this.dtpExportDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpExportDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpExportDate.Name = "dtpExportDate";
            this.dtpExportDate.Size = new System.Drawing.Size(145, 36);
            this.dtpExportDate.TabIndex = 1;
            this.dtpExportDate.Value = new System.DateTime(2025, 12, 22, 22, 13, 31, 695);
            // 
            // frmStockOut
            // 
            this.ClientSize = new System.Drawing.Size(1040, 700);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlRight);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmStockOut";
            this.Text = "Xuất Kho";
            this.pnlLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            this.pnlRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExportItems)).EndInit();
            this.pnlPayment.ResumeLayout(false);
            this.pnlInfo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Label lblTitleLeft;
        private System.Windows.Forms.DataGridView dgvProducts;
        private Guna.UI2.WinForms.Guna2TextBox txtSearchProduct;

        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Panel pnlInfo;
        private System.Windows.Forms.Label lblTitleRight;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpExportDate;

        private System.Windows.Forms.DataGridView dgvExportItems;
        private System.Windows.Forms.Panel pnlPayment;
        private System.Windows.Forms.Label lblTotalLabel;
        private System.Windows.Forms.Label lblTotalMoney;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private Guna.UI2.WinForms.Guna2Button btnCancel;
    }
}