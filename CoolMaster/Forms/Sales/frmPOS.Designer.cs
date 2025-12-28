namespace CoolMaster.Forms.Sales
{
    partial class frmPOS
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
            this.pnlInvoice = new System.Windows.Forms.Panel();
            this.dgvInvoice = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlPayment = new System.Windows.Forms.Panel();
            this.cboPaymentMethod = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblTotalLabel = new System.Windows.Forms.Label();
            this.lblTotalMoney = new System.Windows.Forms.Label();
            this.btnPay = new Guna.UI2.WinForms.Guna2Button();
            this.btnCancel = new Guna.UI2.WinForms.Guna2Button();
            this.pnlCustomer = new System.Windows.Forms.Panel();
            this.btnAddCustomer = new FontAwesome.Sharp.IconButton();
            this.txtCustomerSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.pnlProductList = new System.Windows.Forms.Panel();
            this.flpProducts = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.btnScanBarcode = new FontAwesome.Sharp.IconButton();
            this.txtSearchProduct = new Guna.UI2.WinForms.Guna2TextBox();
            this.cboCategory = new Guna.UI2.WinForms.Guna2ComboBox();
            this.pnlInvoice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoice)).BeginInit();
            this.pnlPayment.SuspendLayout();
            this.pnlCustomer.SuspendLayout();
            this.pnlProductList.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlInvoice
            // 
            this.pnlInvoice.BackColor = System.Drawing.Color.White;
            this.pnlInvoice.Controls.Add(this.dgvInvoice);
            this.pnlInvoice.Controls.Add(this.pnlPayment);
            this.pnlInvoice.Controls.Add(this.pnlCustomer);
            this.pnlInvoice.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlInvoice.Location = new System.Drawing.Point(529, 0);
            this.pnlInvoice.Name = "pnlInvoice";
            this.pnlInvoice.Size = new System.Drawing.Size(461, 595);
            this.pnlInvoice.TabIndex = 0;
            // 
            // dgvInvoice
            // 
            this.dgvInvoice.AllowUserToAddRows = false;
            this.dgvInvoice.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInvoice.BackgroundColor = System.Drawing.Color.White;
            this.dgvInvoice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvInvoice.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvInvoice.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInvoice.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvInvoice.ColumnHeadersHeight = 40;
            this.dgvInvoice.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colName,
            this.colQty,
            this.colPrice,
            this.colTotal});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvInvoice.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvInvoice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInvoice.EnableHeadersVisualStyles = false;
            this.dgvInvoice.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(231)))), ((int)(((byte)(231)))));
            this.dgvInvoice.Location = new System.Drawing.Point(0, 60);
            this.dgvInvoice.Name = "dgvInvoice";
            this.dgvInvoice.ReadOnly = true;
            this.dgvInvoice.RowHeadersVisible = false;
            this.dgvInvoice.RowTemplate.Height = 35;
            this.dgvInvoice.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInvoice.Size = new System.Drawing.Size(461, 360);
            this.dgvInvoice.TabIndex = 2;
            this.dgvInvoice.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInvoice_CellEndEdit);
            // 
            // colId
            // 
            this.colId.HeaderText = "ID";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Visible = false;
            // 
            // colName
            // 
            this.colName.FillWeight = 150F;
            this.colName.HeaderText = "Sản phẩm";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            // 
            // colQty
            // 
            this.colQty.FillWeight = 40F;
            this.colQty.HeaderText = "SL";
            this.colQty.Name = "colQty";
            this.colQty.ReadOnly = true;
            // 
            // colPrice
            // 
            this.colPrice.HeaderText = "Đơn giá";
            this.colPrice.Name = "colPrice";
            this.colPrice.ReadOnly = true;
            // 
            // colTotal
            // 
            this.colTotal.HeaderText = "T.Tiền";
            this.colTotal.Name = "colTotal";
            this.colTotal.ReadOnly = true;
            // 
            // pnlPayment
            // 
            this.pnlPayment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.pnlPayment.Controls.Add(this.cboPaymentMethod);
            this.pnlPayment.Controls.Add(this.lblTotalLabel);
            this.pnlPayment.Controls.Add(this.lblTotalMoney);
            this.pnlPayment.Controls.Add(this.btnPay);
            this.pnlPayment.Controls.Add(this.btnCancel);
            this.pnlPayment.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlPayment.Location = new System.Drawing.Point(0, 420);
            this.pnlPayment.Name = "pnlPayment";
            this.pnlPayment.Size = new System.Drawing.Size(461, 175);
            this.pnlPayment.TabIndex = 1;
            // 
            // cboPaymentMethod
            // 
            this.cboPaymentMethod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboPaymentMethod.BackColor = System.Drawing.Color.Transparent;
            this.cboPaymentMethod.BorderRadius = 10;
            this.cboPaymentMethod.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboPaymentMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPaymentMethod.FocusedColor = System.Drawing.Color.Empty;
            this.cboPaymentMethod.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboPaymentMethod.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboPaymentMethod.ItemHeight = 30;
            this.cboPaymentMethod.Location = new System.Drawing.Point(263, 58);
            this.cboPaymentMethod.Name = "cboPaymentMethod";
            this.cboPaymentMethod.Size = new System.Drawing.Size(184, 36);
            this.cboPaymentMethod.TabIndex = 0;
            // 
            // lblTotalLabel
            // 
            this.lblTotalLabel.AutoSize = true;
            this.lblTotalLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalLabel.Location = new System.Drawing.Point(15, 15);
            this.lblTotalLabel.Name = "lblTotalLabel";
            this.lblTotalLabel.Size = new System.Drawing.Size(125, 21);
            this.lblTotalLabel.TabIndex = 8;
            this.lblTotalLabel.Text = "TỔNG PHẢI THU";
            // 
            // lblTotalMoney
            // 
            this.lblTotalMoney.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalMoney.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalMoney.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(57)))), ((int)(((byte)(142)))));
            this.lblTotalMoney.Location = new System.Drawing.Point(206, 10);
            this.lblTotalMoney.Name = "lblTotalMoney";
            this.lblTotalMoney.Size = new System.Drawing.Size(243, 37);
            this.lblTotalMoney.TabIndex = 9;
            this.lblTotalMoney.Text = "0 đ";
            this.lblTotalMoney.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnPay
            // 
            this.btnPay.BorderRadius = 10;
            this.btnPay.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnPay.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnPay.ForeColor = System.Drawing.Color.White;
            this.btnPay.Location = new System.Drawing.Point(14, 112);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(440, 60);
            this.btnPay.TabIndex = 7;
            this.btnPay.Text = "THANH TOÁN (F9)";
            this.btnPay.Click += new System.EventHandler(this.btnPay_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BorderRadius = 10;
            this.btnCancel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(14, 52);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(243, 47);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Hủy đơn (F4)";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // pnlCustomer
            // 
            this.pnlCustomer.Controls.Add(this.btnAddCustomer);
            this.pnlCustomer.Controls.Add(this.txtCustomerSearch);
            this.pnlCustomer.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCustomer.Location = new System.Drawing.Point(0, 0);
            this.pnlCustomer.Name = "pnlCustomer";
            this.pnlCustomer.Size = new System.Drawing.Size(461, 60);
            this.pnlCustomer.TabIndex = 0;
            // 
            // btnAddCustomer
            // 
            this.btnAddCustomer.BackColor = System.Drawing.Color.Transparent;
            this.btnAddCustomer.FlatAppearance.BorderSize = 0;
            this.btnAddCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddCustomer.IconChar = FontAwesome.Sharp.IconChar.UserPlus;
            this.btnAddCustomer.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(57)))), ((int)(((byte)(142)))));
            this.btnAddCustomer.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.btnAddCustomer.IconSize = 40;
            this.btnAddCustomer.Location = new System.Drawing.Point(403, 8);
            this.btnAddCustomer.Name = "btnAddCustomer";
            this.btnAddCustomer.Size = new System.Drawing.Size(44, 44);
            this.btnAddCustomer.TabIndex = 4;
            this.btnAddCustomer.UseVisualStyleBackColor = false;
            this.btnAddCustomer.Click += new System.EventHandler(this.btnAddCustomer_Click);
            // 
            // txtCustomerSearch
            // 
            this.txtCustomerSearch.BorderRadius = 10;
            this.txtCustomerSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCustomerSearch.DefaultText = "";
            this.txtCustomerSearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtCustomerSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtCustomerSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCustomerSearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCustomerSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCustomerSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCustomerSearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCustomerSearch.Location = new System.Drawing.Point(12, 10);
            this.txtCustomerSearch.Name = "txtCustomerSearch";
            this.txtCustomerSearch.PlaceholderText = "Tìm khách hàng (F2)";
            this.txtCustomerSearch.SelectedText = "";
            this.txtCustomerSearch.Size = new System.Drawing.Size(376, 40);
            this.txtCustomerSearch.TabIndex = 2;
            this.txtCustomerSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCustomerSearch_KeyDown);
            // 
            // pnlProductList
            // 
            this.pnlProductList.Controls.Add(this.flpProducts);
            this.pnlProductList.Controls.Add(this.pnlSearch);
            this.pnlProductList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlProductList.Location = new System.Drawing.Point(0, 0);
            this.pnlProductList.Name = "pnlProductList";
            this.pnlProductList.Size = new System.Drawing.Size(529, 595);
            this.pnlProductList.TabIndex = 1;
            // 
            // flpProducts
            // 
            this.flpProducts.AutoScroll = true;
            this.flpProducts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.flpProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpProducts.Location = new System.Drawing.Point(0, 60);
            this.flpProducts.Name = "flpProducts";
            this.flpProducts.Padding = new System.Windows.Forms.Padding(10);
            this.flpProducts.Size = new System.Drawing.Size(529, 535);
            this.flpProducts.TabIndex = 1;
            // 
            // pnlSearch
            // 
            this.pnlSearch.BackColor = System.Drawing.Color.White;
            this.pnlSearch.Controls.Add(this.btnScanBarcode);
            this.pnlSearch.Controls.Add(this.txtSearchProduct);
            this.pnlSearch.Controls.Add(this.cboCategory);
            this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearch.Location = new System.Drawing.Point(0, 0);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(529, 60);
            this.pnlSearch.TabIndex = 0;
            // 
            // btnScanBarcode
            // 
            this.btnScanBarcode.BackColor = System.Drawing.Color.Transparent;
            this.btnScanBarcode.FlatAppearance.BorderSize = 0;
            this.btnScanBarcode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnScanBarcode.IconChar = FontAwesome.Sharp.IconChar.Barcode;
            this.btnScanBarcode.IconColor = System.Drawing.Color.Black;
            this.btnScanBarcode.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.btnScanBarcode.IconSize = 40;
            this.btnScanBarcode.Location = new System.Drawing.Point(479, 8);
            this.btnScanBarcode.Name = "btnScanBarcode";
            this.btnScanBarcode.Size = new System.Drawing.Size(44, 44);
            this.btnScanBarcode.TabIndex = 5;
            this.btnScanBarcode.UseVisualStyleBackColor = false;
            this.btnScanBarcode.Click += new System.EventHandler(this.btnScanBarcode_Click);
            // 
            // txtSearchProduct
            // 
            this.txtSearchProduct.BorderRadius = 10;
            this.txtSearchProduct.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearchProduct.DefaultText = "";
            this.txtSearchProduct.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSearchProduct.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSearchProduct.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearchProduct.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearchProduct.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearchProduct.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSearchProduct.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearchProduct.Location = new System.Drawing.Point(181, 10);
            this.txtSearchProduct.Name = "txtSearchProduct";
            this.txtSearchProduct.PlaceholderText = "Tìm sản phẩm (F1)";
            this.txtSearchProduct.SelectedText = "";
            this.txtSearchProduct.Size = new System.Drawing.Size(292, 40);
            this.txtSearchProduct.TabIndex = 3;
            this.txtSearchProduct.TextChanged += new System.EventHandler(this.txtSearchProduct_TextChanged);
            // 
            // cboCategory
            // 
            this.cboCategory.BackColor = System.Drawing.Color.Transparent;
            this.cboCategory.BorderRadius = 10;
            this.cboCategory.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategory.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboCategory.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboCategory.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboCategory.ItemHeight = 30;
            this.cboCategory.Location = new System.Drawing.Point(12, 12);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(163, 36);
            this.cboCategory.TabIndex = 0;
            this.cboCategory.SelectedIndexChanged += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmPOS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.ClientSize = new System.Drawing.Size(990, 595);
            this.Controls.Add(this.pnlProductList);
            this.Controls.Add(this.pnlInvoice);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPOS";
            this.Text = "Máy POS";
            this.Load += new System.EventHandler(this.frmPOS_Load);
            this.pnlInvoice.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoice)).EndInit();
            this.pnlPayment.ResumeLayout(false);
            this.pnlPayment.PerformLayout();
            this.pnlCustomer.ResumeLayout(false);
            this.pnlProductList.ResumeLayout(false);
            this.pnlSearch.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlInvoice;
        private System.Windows.Forms.Panel pnlProductList;
        private System.Windows.Forms.Panel pnlPayment;
        private System.Windows.Forms.DataGridView dgvInvoice;
        private System.Windows.Forms.Panel pnlCustomer;
        private System.Windows.Forms.Panel pnlSearch;
        private Guna.UI2.WinForms.Guna2TextBox txtCustomerSearch;
        private FontAwesome.Sharp.IconButton btnAddCustomer;
        private Guna.UI2.WinForms.Guna2Button btnPay;
        private Guna.UI2.WinForms.Guna2Button btnCancel;
        private System.Windows.Forms.Label lblTotalMoney;
        private System.Windows.Forms.Label lblTotalLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
        private Guna.UI2.WinForms.Guna2TextBox txtSearchProduct;
        private Guna.UI2.WinForms.Guna2ComboBox cboCategory;
        private System.Windows.Forms.FlowLayoutPanel flpProducts;
        private FontAwesome.Sharp.IconButton btnScanBarcode;
        private Guna.UI2.WinForms.Guna2ComboBox cboPaymentMethod;
    }
}