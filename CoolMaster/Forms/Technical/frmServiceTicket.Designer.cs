namespace CoolMaster.Forms.Technical
{
    partial class frmServiceTicket
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlTool = new System.Windows.Forms.Panel();
            this.btnDeleteTicket = new Guna.UI2.WinForms.Guna2Button();
            this.btnUpdateTicket = new Guna.UI2.WinForms.Guna2Button();
            this.btnAddTicket = new Guna.UI2.WinForms.Guna2Button();
            this.btnSearch = new Guna.UI2.WinForms.Guna2Button();
            this.btnFilter = new FontAwesome.Sharp.IconButton();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnNext = new FontAwesome.Sharp.IconButton();
            this.btnPrev = new FontAwesome.Sharp.IconButton();
            this.dgvTickets = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCustomer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDevice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIssue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCreatedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlHeader.SuspendLayout();
            this.pnlTool.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTickets)).BeginInit();
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
            this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(19, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(381, 31);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "QUẢN LÝ PHIẾU SỬA CHỮA";
            this.lblTitle.Click += new System.EventHandler(this.lblTitle_Click);
            // 
            // pnlTool
            // 
            this.pnlTool.Controls.Add(this.btnDeleteTicket);
            this.pnlTool.Controls.Add(this.btnUpdateTicket);
            this.pnlTool.Controls.Add(this.btnAddTicket);
            this.pnlTool.Controls.Add(this.btnSearch);
            this.pnlTool.Controls.Add(this.btnFilter);
            this.pnlTool.Controls.Add(this.txtSearch);
            this.pnlTool.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTool.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.pnlTool.Location = new System.Drawing.Point(0, 54);
            this.pnlTool.Name = "pnlTool";
            this.pnlTool.Size = new System.Drawing.Size(990, 60);
            this.pnlTool.TabIndex = 1;
            // 
            // btnDeleteTicket
            // 
            this.btnDeleteTicket.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteTicket.BorderRadius = 10;
            this.btnDeleteTicket.FillColor = System.Drawing.Color.Crimson;
            this.btnDeleteTicket.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnDeleteTicket.ForeColor = System.Drawing.Color.White;
            this.btnDeleteTicket.Location = new System.Drawing.Point(900, 11);
            this.btnDeleteTicket.Name = "btnDeleteTicket";
            this.btnDeleteTicket.Size = new System.Drawing.Size(75, 39);
            this.btnDeleteTicket.TabIndex = 6;
            this.btnDeleteTicket.Text = "Hủy";
            this.btnDeleteTicket.Click += new System.EventHandler(this.btnDeleteTicket_Click);
            // 
            // btnUpdateTicket
            // 
            this.btnUpdateTicket.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdateTicket.BorderRadius = 10;
            this.btnUpdateTicket.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(57)))), ((int)(((byte)(142)))));
            this.btnUpdateTicket.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnUpdateTicket.ForeColor = System.Drawing.Color.White;
            this.btnUpdateTicket.Location = new System.Drawing.Point(808, 11);
            this.btnUpdateTicket.Name = "btnUpdateTicket";
            this.btnUpdateTicket.Size = new System.Drawing.Size(86, 39);
            this.btnUpdateTicket.TabIndex = 5;
            this.btnUpdateTicket.Text = "Sửa";
            this.btnUpdateTicket.Click += new System.EventHandler(this.btnUpdateTicket_Click);
            // 
            // btnAddTicket
            // 
            this.btnAddTicket.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddTicket.BorderRadius = 10;
            this.btnAddTicket.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnAddTicket.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnAddTicket.ForeColor = System.Drawing.Color.White;
            this.btnAddTicket.Location = new System.Drawing.Point(719, 11);
            this.btnAddTicket.Name = "btnAddTicket";
            this.btnAddTicket.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.btnAddTicket.Size = new System.Drawing.Size(83, 39);
            this.btnAddTicket.TabIndex = 4;
            this.btnAddTicket.Text = "Tạo Phiếu";
            this.btnAddTicket.Click += new System.EventHandler(this.btnAddTicket_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BorderRadius = 10;
            this.btnSearch.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(57)))), ((int)(((byte)(142)))));
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(462, 11);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 39);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "Tìm";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
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
            this.btnFilter.IconSize = 40;
            this.btnFilter.Location = new System.Drawing.Point(18, 11);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(36, 39);
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
            this.txtSearch.Location = new System.Drawing.Point(63, 11);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PlaceholderText = "Tìm kiếm phiếu / tên khách...";
            this.txtSearch.SelectedText = "";
            this.txtSearch.Size = new System.Drawing.Size(390, 39);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextOffset = new System.Drawing.Point(6, 0);
            // 
            // pnlFooter
            // 
            this.pnlFooter.Controls.Add(this.btnNext);
            this.pnlFooter.Controls.Add(this.btnPrev);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 545);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(990, 50);
            this.pnlFooter.TabIndex = 3;
            this.pnlFooter.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlFooter_Paint);
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.FlatAppearance.BorderSize = 0;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold);
            this.btnNext.IconChar = FontAwesome.Sharp.IconChar.AngleRight;
            this.btnNext.IconColor = System.Drawing.Color.Black;
            this.btnNext.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnNext.IconSize = 35;
            this.btnNext.Location = new System.Drawing.Point(921, 3);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(40, 40);
            this.btnNext.TabIndex = 1;
            this.btnNext.UseVisualStyleBackColor = true;
            // 
            // btnPrev
            // 
            this.btnPrev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrev.FlatAppearance.BorderSize = 0;
            this.btnPrev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrev.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold);
            this.btnPrev.IconChar = FontAwesome.Sharp.IconChar.AngleLeft;
            this.btnPrev.IconColor = System.Drawing.Color.Black;
            this.btnPrev.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnPrev.IconSize = 35;
            this.btnPrev.Location = new System.Drawing.Point(795, 3);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(40, 40);
            this.btnPrev.TabIndex = 0;
            this.btnPrev.UseVisualStyleBackColor = true;
            // 
            // dgvTickets
            // 
            this.dgvTickets.AllowUserToAddRows = false;
            this.dgvTickets.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTickets.BackgroundColor = System.Drawing.Color.White;
            this.dgvTickets.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTickets.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvTickets.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(57)))), ((int)(((byte)(142)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            this.dgvTickets.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTickets.ColumnHeadersHeight = 40;
            this.dgvTickets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvTickets.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colCustomer,
            this.colPhone,
            this.colDevice,
            this.colIssue,
            this.colStatus,
            this.colCreatedDate});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTickets.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvTickets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTickets.EnableHeadersVisualStyles = false;
            this.dgvTickets.Location = new System.Drawing.Point(0, 114);
            this.dgvTickets.Name = "dgvTickets";
            this.dgvTickets.ReadOnly = true;
            this.dgvTickets.RowHeadersVisible = false;
            this.dgvTickets.RowHeadersWidth = 51;
            this.dgvTickets.RowTemplate.Height = 35;
            this.dgvTickets.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTickets.Size = new System.Drawing.Size(990, 431);
            this.dgvTickets.TabIndex = 4;
            this.dgvTickets.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTickets_CellContentClick);
            // 
            // colId
            // 
            this.colId.HeaderText = "ID";
            this.colId.MinimumWidth = 6;
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Visible = false;
            // 
            // colCustomer
            // 
            this.colCustomer.DataPropertyName = "CustomerName";
            this.colCustomer.FillWeight = 160F;
            this.colCustomer.HeaderText = "Khách hàng";
            this.colCustomer.MinimumWidth = 6;
            this.colCustomer.Name = "colCustomer";
            this.colCustomer.ReadOnly = true;
            // 
            // colPhone
            // 
            this.colPhone.DataPropertyName = "PhoneNumber";
            this.colPhone.FillWeight = 80F;
            this.colPhone.HeaderText = "SĐT";
            this.colPhone.MinimumWidth = 6;
            this.colPhone.Name = "colPhone";
            this.colPhone.ReadOnly = true;
            // 
            // colDevice
            // 
            this.colDevice.DataPropertyName = "DeviceName";
            this.colDevice.FillWeight = 140F;
            this.colDevice.HeaderText = "Thiết bị";
            this.colDevice.MinimumWidth = 6;
            this.colDevice.Name = "colDevice";
            this.colDevice.ReadOnly = true;
            // 
            // colIssue
            // 
            this.colIssue.DataPropertyName = "IssueDescription";
            this.colIssue.FillWeight = 200F;
            this.colIssue.HeaderText = "Mô tả lỗi";
            this.colIssue.MinimumWidth = 6;
            this.colIssue.Name = "colIssue";
            this.colIssue.ReadOnly = true;
            // 
            // colStatus
            // 
            this.colStatus.DataPropertyName = "Status";
            this.colStatus.FillWeight = 80F;
            this.colStatus.HeaderText = "Trạng thái";
            this.colStatus.MinimumWidth = 6;
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            // 
            // colCreatedDate
            // 
            this.colCreatedDate.DataPropertyName = "CreatedDate";
            dataGridViewCellStyle2.Format = "dd/MM/yyyy HH:mm";
            this.colCreatedDate.DefaultCellStyle = dataGridViewCellStyle2;
            this.colCreatedDate.FillWeight = 120F;
            this.colCreatedDate.HeaderText = "Ngày tạo";
            this.colCreatedDate.MinimumWidth = 6;
            this.colCreatedDate.Name = "colCreatedDate";
            this.colCreatedDate.ReadOnly = true;
            // 
            // frmServiceTicket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.ClientSize = new System.Drawing.Size(990, 595);
            this.Controls.Add(this.dgvTickets);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlTool);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmServiceTicket";
            this.Text = "Phiếu sửa chữa";
            this.Load += new System.EventHandler(this.frmServiceTicket_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlTool.ResumeLayout(false);
            this.pnlFooter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTickets)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlTool;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private FontAwesome.Sharp.IconButton btnFilter;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.DataGridView dgvTickets;
        private System.Windows.Forms.Label lblTitle;
        private Guna.UI2.WinForms.Guna2Button btnAddTicket;
        private Guna.UI2.WinForms.Guna2Button btnUpdateTicket;
        private Guna.UI2.WinForms.Guna2Button btnDeleteTicket;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private FontAwesome.Sharp.IconButton btnNext;
        private FontAwesome.Sharp.IconButton btnPrev;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDevice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIssue;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCreatedDate;
        private Guna.UI2.WinForms.Guna2Button btnSearch;
    }
}