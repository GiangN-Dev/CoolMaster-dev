namespace CoolMaster.Forms.Technical
{
    partial class frmWarrantyLookup
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
            this.btnDelete = new Guna.UI2.WinForms.Guna2Button();
            this.btnCreateTicket = new Guna.UI2.WinForms.Guna2Button();
            this.btnCheck = new Guna.UI2.WinForms.Guna2Button();
            this.btnFilter = new FontAwesome.Sharp.IconButton();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnNext = new FontAwesome.Sharp.IconButton();
            this.btnPrev = new FontAwesome.Sharp.IconButton();
            this.dgvWarranty = new System.Windows.Forms.DataGridView();
            this.colSerial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCustomer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDevice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCreatedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlHeader.SuspendLayout();
            this.pnlTool.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWarranty)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(748, 54);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(14, 15);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(291, 31);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "TRA CỨU BẢO HÀNH";
            // 
            // pnlTool
            // 
            this.pnlTool.Controls.Add(this.btnDelete);
            this.pnlTool.Controls.Add(this.btnCreateTicket);
            this.pnlTool.Controls.Add(this.btnCheck);
            this.pnlTool.Controls.Add(this.btnFilter);
            this.pnlTool.Controls.Add(this.txtSearch);
            this.pnlTool.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTool.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.pnlTool.Location = new System.Drawing.Point(0, 54);
            this.pnlTool.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlTool.Name = "pnlTool";
            this.pnlTool.Size = new System.Drawing.Size(748, 60);
            this.pnlTool.TabIndex = 1;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.BorderRadius = 10;
            this.btnDelete.FillColor = System.Drawing.Color.Crimson;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(657, 11);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Padding = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.btnDelete.Size = new System.Drawing.Size(89, 41);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "Xóa";
            // 
            // btnCreateTicket
            // 
            this.btnCreateTicket.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateTicket.BorderRadius = 10;
            this.btnCreateTicket.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(57)))), ((int)(((byte)(142)))));
            this.btnCreateTicket.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnCreateTicket.ForeColor = System.Drawing.Color.White;
            this.btnCreateTicket.Location = new System.Drawing.Point(538, 11);
            this.btnCreateTicket.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCreateTicket.Name = "btnCreateTicket";
            this.btnCreateTicket.Padding = new System.Windows.Forms.Padding(6, 6, 6, 0);
            this.btnCreateTicket.Size = new System.Drawing.Size(105, 41);
            this.btnCreateTicket.TabIndex = 5;
            this.btnCreateTicket.Text = "Tạo phiếu";
            // 
            // btnCheck
            // 
            this.btnCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCheck.BorderRadius = 10;
            this.btnCheck.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnCheck.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnCheck.ForeColor = System.Drawing.Color.White;
            this.btnCheck.Location = new System.Drawing.Point(428, 11);
            this.btnCheck.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Padding = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.btnCheck.Size = new System.Drawing.Size(105, 41);
            this.btnCheck.TabIndex = 4;
            this.btnCheck.Text = "Tra cứu";
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click_1);
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
            this.btnFilter.Location = new System.Drawing.Point(14, 14);
            this.btnFilter.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
            this.txtSearch.Location = new System.Drawing.Point(54, 11);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PlaceholderText = "Nhập Serial/IMEI/SĐT để tra cứu...";
            this.txtSearch.SelectedText = "";
            this.txtSearch.Size = new System.Drawing.Size(360, 41);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextOffset = new System.Drawing.Point(6, 0);
            // 
            // pnlFooter
            // 
            this.pnlFooter.Controls.Add(this.btnNext);
            this.pnlFooter.Controls.Add(this.btnPrev);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 442);
            this.pnlFooter.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(748, 41);
            this.pnlFooter.TabIndex = 3;
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
            this.btnNext.Location = new System.Drawing.Point(697, 2);
            this.btnNext.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(30, 32);
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
            this.btnPrev.Location = new System.Drawing.Point(602, 2);
            this.btnPrev.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(30, 32);
            this.btnPrev.TabIndex = 0;
            this.btnPrev.UseVisualStyleBackColor = true;
            // 
            // dgvWarranty
            // 
            this.dgvWarranty.AllowUserToAddRows = false;
            this.dgvWarranty.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvWarranty.BackgroundColor = System.Drawing.Color.White;
            this.dgvWarranty.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvWarranty.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvWarranty.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(57)))), ((int)(((byte)(142)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            this.dgvWarranty.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvWarranty.ColumnHeadersHeight = 40;
            this.dgvWarranty.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvWarranty.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSerial,
            this.colCustomer,
            this.colPhone,
            this.colDevice,
            this.colStatus,
            this.colCreatedDate});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvWarranty.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvWarranty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvWarranty.EnableHeadersVisualStyles = false;
            this.dgvWarranty.Location = new System.Drawing.Point(0, 114);
            this.dgvWarranty.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvWarranty.Name = "dgvWarranty";
            this.dgvWarranty.ReadOnly = true;
            this.dgvWarranty.RowHeadersVisible = false;
            this.dgvWarranty.RowHeadersWidth = 51;
            this.dgvWarranty.RowTemplate.Height = 35;
            this.dgvWarranty.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvWarranty.Size = new System.Drawing.Size(748, 328);
            this.dgvWarranty.TabIndex = 4;
            // 
            // colSerial
            // 
            this.colSerial.DataPropertyName = "Serial";
            this.colSerial.HeaderText = "Serial/IMEI";
            this.colSerial.MinimumWidth = 6;
            this.colSerial.Name = "colSerial";
            this.colSerial.ReadOnly = true;
            // 
            // colCustomer
            // 
            this.colCustomer.DataPropertyName = "CustomerName";
            this.colCustomer.FillWeight = 150F;
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
            this.colCreatedDate.HeaderText = "Ngày nhập";
            this.colCreatedDate.MinimumWidth = 6;
            this.colCreatedDate.Name = "colCreatedDate";
            this.colCreatedDate.ReadOnly = true;
            // 
            // frmWarrantyLookup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.ClientSize = new System.Drawing.Size(748, 483);
            this.Controls.Add(this.dgvWarranty);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlTool);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmWarrantyLookup";
            this.Text = "Tra cứu bảo hành";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlTool.ResumeLayout(false);
            this.pnlFooter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWarranty)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlTool;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private FontAwesome.Sharp.IconButton btnFilter;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.DataGridView dgvWarranty;
        private System.Windows.Forms.Label lblTitle;
        private Guna.UI2.WinForms.Guna2Button btnCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSerial;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDevice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCreatedDate;
        private Guna.UI2.WinForms.Guna2Button btnCreateTicket;
        private Guna.UI2.WinForms.Guna2Button btnDelete;
        private FontAwesome.Sharp.IconButton btnNext;
        private FontAwesome.Sharp.IconButton btnPrev;
    }
}