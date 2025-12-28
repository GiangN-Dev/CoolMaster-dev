using FontAwesome.Sharp;
using System.Windows.Media.Media3D;

namespace CoolMaster.Forms.Sales
{
    partial class frmOrderHistory
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlTool = new System.Windows.Forms.Panel();
            this.btnReload = new FontAwesome.Sharp.IconButton();
            this.lblDateSep = new System.Windows.Forms.Label();
            this.dtpToDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.dtpFromDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.btnExportExcel = new Guna.UI2.WinForms.Guna2Button();
            this.btnViewDetail = new Guna.UI2.WinForms.Guna2Button();
            this.btnFilter = new FontAwesome.Sharp.IconButton();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCustomer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPaymentStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colServiceStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ucPager = new CoolMaster.Common.UCPagination();
            this.pnlHeader.SuspendLayout();
            this.pnlTool.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(990, 54);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(57)))), ((int)(((byte)(142)))));
            this.lblTitle.Location = new System.Drawing.Point(19, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(282, 31);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "LỊCH SỬ ĐƠN HÀNG";
            // 
            // pnlTool
            // 
            this.pnlTool.Controls.Add(this.btnReload);
            this.pnlTool.Controls.Add(this.lblDateSep);
            this.pnlTool.Controls.Add(this.dtpToDate);
            this.pnlTool.Controls.Add(this.dtpFromDate);
            this.pnlTool.Controls.Add(this.btnExportExcel);
            this.pnlTool.Controls.Add(this.btnViewDetail);
            this.pnlTool.Controls.Add(this.btnFilter);
            this.pnlTool.Controls.Add(this.txtSearch);
            this.pnlTool.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTool.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.pnlTool.Location = new System.Drawing.Point(0, 54);
            this.pnlTool.Name = "pnlTool";
            this.pnlTool.Size = new System.Drawing.Size(990, 60);
            this.pnlTool.TabIndex = 1;
            // 
            // btnReload
            // 
            this.btnReload.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.btnReload.FlatAppearance.BorderSize = 0;
            this.btnReload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReload.IconChar = FontAwesome.Sharp.IconChar.Redo;
            this.btnReload.IconColor = System.Drawing.Color.Black;
            this.btnReload.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnReload.Location = new System.Drawing.Point(701, 12);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(40, 40);
            this.btnReload.TabIndex = 9;
            this.btnReload.UseVisualStyleBackColor = false;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // lblDateSep
            // 
            this.lblDateSep.AutoSize = true;
            this.lblDateSep.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateSep.ForeColor = System.Drawing.Color.Black;
            this.lblDateSep.Location = new System.Drawing.Point(528, 20);
            this.lblDateSep.Name = "lblDateSep";
            this.lblDateSep.Size = new System.Drawing.Size(21, 21);
            this.lblDateSep.TabIndex = 8;
            this.lblDateSep.Text = "~";
            // 
            // dtpToDate
            // 
            this.dtpToDate.BorderRadius = 10;
            this.dtpToDate.Checked = true;
            this.dtpToDate.FillColor = System.Drawing.Color.White;
            this.dtpToDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpToDate.ForeColor = System.Drawing.Color.Black;
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpToDate.Location = new System.Drawing.Point(558, 11);
            this.dtpToDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpToDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(130, 40);
            this.dtpToDate.TabIndex = 7;
            this.dtpToDate.Value = new System.DateTime(2023, 10, 26, 0, 0, 0, 0);
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.BorderRadius = 10;
            this.dtpFromDate.Checked = true;
            this.dtpFromDate.FillColor = System.Drawing.Color.White;
            this.dtpFromDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpFromDate.ForeColor = System.Drawing.Color.Black;
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFromDate.Location = new System.Drawing.Point(388, 11);
            this.dtpFromDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpFromDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(130, 40);
            this.dtpFromDate.TabIndex = 6;
            this.dtpFromDate.Value = new System.DateTime(2023, 10, 1, 0, 0, 0, 0);
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportExcel.BorderRadius = 10;
            this.btnExportExcel.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnExportExcel.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnExportExcel.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnExportExcel.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnExportExcel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnExportExcel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnExportExcel.ForeColor = System.Drawing.Color.White;
            this.btnExportExcel.Location = new System.Drawing.Point(753, 11);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(110, 40);
            this.btnExportExcel.TabIndex = 5;
            this.btnExportExcel.Text = "Xuất Excell";
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // btnViewDetail
            // 
            this.btnViewDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewDetail.BorderRadius = 10;
            this.btnViewDetail.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnViewDetail.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnViewDetail.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnViewDetail.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnViewDetail.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(57)))), ((int)(((byte)(142)))));
            this.btnViewDetail.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnViewDetail.ForeColor = System.Drawing.Color.White;
            this.btnViewDetail.Location = new System.Drawing.Point(869, 11);
            this.btnViewDetail.Name = "btnViewDetail";
            this.btnViewDetail.Size = new System.Drawing.Size(110, 40);
            this.btnViewDetail.TabIndex = 4;
            this.btnViewDetail.Text = "Chi tiết";
            this.btnViewDetail.Click += new System.EventHandler(this.btnViewDetail_Click);
            // 
            // btnFilter
            // 
            this.btnFilter.BackColor = System.Drawing.Color.Transparent;
            this.btnFilter.FlatAppearance.BorderSize = 0;
            this.btnFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilter.ForeColor = System.Drawing.Color.Black;
            this.btnFilter.IconChar = FontAwesome.Sharp.IconChar.Filter;
            this.btnFilter.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(57)))), ((int)(((byte)(142)))));
            this.btnFilter.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.btnFilter.IconSize = 45;
            this.btnFilter.Location = new System.Drawing.Point(18, 7);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(41, 49);
            this.btnFilter.TabIndex = 3;
            this.btnFilter.UseVisualStyleBackColor = false;
            // 
            // txtSearch
            // 
            this.txtSearch.BorderRadius = 10;
            this.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearch.DefaultText = "";
            this.txtSearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearch.Location = new System.Drawing.Point(70, 11);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PlaceholderText = "Mã đơn, Tên khách hàng, SĐT...";
            this.txtSearch.SelectedText = "";
            this.txtSearch.Size = new System.Drawing.Size(302, 40);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextOffset = new System.Drawing.Point(6, 0);
            // 
            // dgvOrders
            // 
            this.dgvOrders.AllowUserToAddRows = false;
            this.dgvOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrders.BackgroundColor = System.Drawing.Color.White;
            this.dgvOrders.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvOrders.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvOrders.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(57)))), ((int)(((byte)(142)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(57)))), ((int)(((byte)(142)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOrders.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvOrders.ColumnHeadersHeight = 40;
            this.dgvOrders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colCode,
            this.colDate,
            this.colCustomer,
            this.colTotal,
            this.colPaymentStatus,
            this.colServiceStatus});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvOrders.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOrders.EnableHeadersVisualStyles = false;
            this.dgvOrders.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvOrders.Location = new System.Drawing.Point(0, 114);
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.ReadOnly = true;
            this.dgvOrders.RowHeadersVisible = false;
            this.dgvOrders.RowTemplate.Height = 35;
            this.dgvOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrders.Size = new System.Drawing.Size(990, 481);
            this.dgvOrders.TabIndex = 4;
            // 
            // colId
            // 
            this.colId.HeaderText = "ID";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Visible = false;
            // 
            // colCode
            // 
            this.colCode.FillWeight = 80F;
            this.colCode.HeaderText = "Mã HĐ";
            this.colCode.Name = "colCode";
            this.colCode.ReadOnly = true;
            // 
            // colDate
            // 
            this.colDate.FillWeight = 80F;
            this.colDate.HeaderText = "Ngày bán";
            this.colDate.Name = "colDate";
            this.colDate.ReadOnly = true;
            // 
            // colCustomer
            // 
            this.colCustomer.FillWeight = 150F;
            this.colCustomer.HeaderText = "Khách hàng";
            this.colCustomer.Name = "colCustomer";
            this.colCustomer.ReadOnly = true;
            // 
            // colTotal
            // 
            this.colTotal.FillWeight = 120F;
            this.colTotal.HeaderText = "Tổng tiền";
            this.colTotal.Name = "colTotal";
            this.colTotal.ReadOnly = true;
            // 
            // colPaymentStatus
            // 
            this.colPaymentStatus.HeaderText = "Thanh toán";
            this.colPaymentStatus.Name = "colPaymentStatus";
            this.colPaymentStatus.ReadOnly = true;
            // 
            // colServiceStatus
            // 
            this.colServiceStatus.HeaderText = "Lắp đặt/Dịch vụ";
            this.colServiceStatus.Name = "colServiceStatus";
            this.colServiceStatus.ReadOnly = true;
            // 
            // ucPager
            // 
            this.ucPager.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucPager.Location = new System.Drawing.Point(0, 545);
            this.ucPager.Name = "ucPager";
            this.ucPager.Size = new System.Drawing.Size(990, 50);
            this.ucPager.TabIndex = 5;
            // 
            // frmOrderHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.ClientSize = new System.Drawing.Size(990, 595);
            this.Controls.Add(this.ucPager);
            this.Controls.Add(this.dgvOrders);
            this.Controls.Add(this.pnlTool);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmOrderHistory";
            this.Text = "Lịch sử Đơn hàng";
            this.Load += new System.EventHandler(this.frmOrderHistory_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlTool.ResumeLayout(false);
            this.pnlTool.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlTool;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private FontAwesome.Sharp.IconButton btnFilter;
        private System.Windows.Forms.DataGridView dgvOrders;
        private Guna.UI2.WinForms.Guna2Button btnViewDetail;
        private Guna.UI2.WinForms.Guna2Button btnExportExcel;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpToDate;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpFromDate;
        private System.Windows.Forms.Label lblDateSep;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPaymentStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colServiceStatus;
        private IconButton btnReload;
        private Common.UCPagination ucPager;
    }
}