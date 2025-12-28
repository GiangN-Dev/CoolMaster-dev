using FontAwesome.Sharp;
using System.Drawing;
using System.Windows.Forms;

namespace CoolMaster.Forms.Inventory
{
    partial class frmStockTransfer
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.dgvTransferItems = new System.Windows.Forms.DataGridView();
            this.pnlAction = new System.Windows.Forms.Panel();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.btnCancel = new Guna.UI2.WinForms.Guna2Button();
            this.pnlInfo = new System.Windows.Forms.Panel();
            this.lblArrow = new System.Windows.Forms.Label();
            this.dtpTransferDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.txtNote = new Guna.UI2.WinForms.Guna2TextBox();
            this.cboToLocation = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cboFromLocation = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblTitleRight = new System.Windows.Forms.Label();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.txtSearchProduct = new Guna.UI2.WinForms.Guna2TextBox();
            this.cboCategory = new Guna.UI2.WinForms.Guna2ComboBox();
            this.colProdId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProdCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProdName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProdStockMain = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProdStockCounter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTransId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTransName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTransUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTransCurrentStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTransQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBtnDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.pnlRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransferItems)).BeginInit();
            this.pnlAction.SuspendLayout();
            this.pnlInfo.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.pnlSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlRight
            // 
            this.pnlRight.BackColor = System.Drawing.Color.White;
            this.pnlRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRight.Controls.Add(this.dgvTransferItems);
            this.pnlRight.Controls.Add(this.pnlAction);
            this.pnlRight.Controls.Add(this.pnlInfo);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlRight.Location = new System.Drawing.Point(550, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(440, 595);
            this.pnlRight.TabIndex = 1;
            // 
            // dgvTransferItems
            // 
            this.dgvTransferItems.AllowUserToAddRows = false;
            this.dgvTransferItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTransferItems.BackgroundColor = System.Drawing.Color.White;
            this.dgvTransferItems.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.dgvTransferItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTransferItems.ColumnHeadersHeight = 35;
            this.dgvTransferItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTransId,
            this.colTransName,
            this.colTransUnit,
            this.colTransCurrentStock,
            this.colTransQty,
            this.colBtnDelete});
            this.dgvTransferItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTransferItems.Location = new System.Drawing.Point(0, 200);
            this.dgvTransferItems.Name = "dgvTransferItems";
            this.dgvTransferItems.RowHeadersVisible = false;
            this.dgvTransferItems.Size = new System.Drawing.Size(438, 293);
            this.dgvTransferItems.TabIndex = 0;
            this.dgvTransferItems.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTransferItems_CellContentClick);
            // 
            // pnlAction
            // 
            this.pnlAction.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.pnlAction.Controls.Add(this.btnSave);
            this.pnlAction.Controls.Add(this.btnCancel);
            this.pnlAction.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlAction.Location = new System.Drawing.Point(0, 493);
            this.pnlAction.Name = "pnlAction";
            this.pnlAction.Size = new System.Drawing.Size(438, 100);
            this.pnlAction.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.BorderRadius = 8;
            this.btnSave.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(162)))), ((int)(((byte)(184)))));
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(200, 25);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(220, 50);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "THỰC HIỆN";
            // 
            // btnCancel
            // 
            this.btnCancel.BorderRadius = 8;
            this.btnCancel.FillColor = System.Drawing.Color.Gray;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(15, 25);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(160, 50);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Đóng";
            // 
            // pnlInfo
            // 
            this.pnlInfo.Controls.Add(this.lblArrow);
            this.pnlInfo.Controls.Add(this.dtpTransferDate);
            this.pnlInfo.Controls.Add(this.txtNote);
            this.pnlInfo.Controls.Add(this.cboToLocation);
            this.pnlInfo.Controls.Add(this.cboFromLocation);
            this.pnlInfo.Controls.Add(this.lblTitleRight);
            this.pnlInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlInfo.Location = new System.Drawing.Point(0, 0);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Size = new System.Drawing.Size(438, 200);
            this.pnlInfo.TabIndex = 2;
            // 
            // lblArrow
            // 
            this.lblArrow.AutoSize = true;
            this.lblArrow.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblArrow.ForeColor = System.Drawing.Color.Gray;
            this.lblArrow.Location = new System.Drawing.Point(205, 58);
            this.lblArrow.Name = "lblArrow";
            this.lblArrow.Size = new System.Drawing.Size(33, 28);
            this.lblArrow.TabIndex = 0;
            this.lblArrow.Text = "➜";
            // 
            // dtpTransferDate
            // 
            this.dtpTransferDate.BorderRadius = 5;
            this.dtpTransferDate.Checked = true;
            this.dtpTransferDate.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.dtpTransferDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpTransferDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTransferDate.Location = new System.Drawing.Point(285, 10);
            this.dtpTransferDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpTransferDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpTransferDate.Name = "dtpTransferDate";
            this.dtpTransferDate.Size = new System.Drawing.Size(140, 36);
            this.dtpTransferDate.TabIndex = 1;
            this.dtpTransferDate.Value = new System.DateTime(2025, 12, 22, 20, 23, 55, 515);
            // 
            // txtNote
            // 
            this.txtNote.BorderRadius = 5;
            this.txtNote.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNote.DefaultText = "";
            this.txtNote.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNote.Location = new System.Drawing.Point(15, 105);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.PlaceholderText = "Ghi chú (Lý do chuyển...)";
            this.txtNote.SelectedText = "";
            this.txtNote.Size = new System.Drawing.Size(410, 60);
            this.txtNote.TabIndex = 2;
            // 
            // cboToLocation
            // 
            this.cboToLocation.BackColor = System.Drawing.Color.Transparent;
            this.cboToLocation.BorderRadius = 5;
            this.cboToLocation.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboToLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboToLocation.FocusedColor = System.Drawing.Color.Empty;
            this.cboToLocation.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboToLocation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboToLocation.ItemHeight = 30;
            this.cboToLocation.Location = new System.Drawing.Point(245, 55);
            this.cboToLocation.Name = "cboToLocation";
            this.cboToLocation.Size = new System.Drawing.Size(180, 36);
            this.cboToLocation.TabIndex = 3;
            // 
            // cboFromLocation
            // 
            this.cboFromLocation.BackColor = System.Drawing.Color.Transparent;
            this.cboFromLocation.BorderRadius = 5;
            this.cboFromLocation.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboFromLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFromLocation.FocusedColor = System.Drawing.Color.Empty;
            this.cboFromLocation.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboFromLocation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboFromLocation.ItemHeight = 30;
            this.cboFromLocation.Location = new System.Drawing.Point(19, 55);
            this.cboFromLocation.Name = "cboFromLocation";
            this.cboFromLocation.Size = new System.Drawing.Size(180, 36);
            this.cboFromLocation.TabIndex = 4;
            // 
            // lblTitleRight
            // 
            this.lblTitleRight.AutoSize = true;
            this.lblTitleRight.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitleRight.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(162)))), ((int)(((byte)(184)))));
            this.lblTitleRight.Location = new System.Drawing.Point(10, 10);
            this.lblTitleRight.Name = "lblTitleRight";
            this.lblTitleRight.Size = new System.Drawing.Size(210, 25);
            this.lblTitleRight.TabIndex = 5;
            this.lblTitleRight.Text = "ĐIỀU CHUYỂN NỘI BỘ";
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.dgvProducts);
            this.pnlLeft.Controls.Add(this.pnlSearch);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(550, 595);
            this.pnlLeft.TabIndex = 0;
            // 
            // dgvProducts
            // 
            this.dgvProducts.BackgroundColor = System.Drawing.Color.White;
            this.dgvProducts.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvProducts.ColumnHeadersHeight = 40;
            this.dgvProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colProdId,
            this.colProdCode,
            this.colProdName,
            this.colProdStockMain,
            this.colProdStockCounter});
            this.dgvProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProducts.Location = new System.Drawing.Point(0, 70);
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.RowHeadersVisible = false;
            this.dgvProducts.Size = new System.Drawing.Size(550, 525);
            this.dgvProducts.TabIndex = 0;
            this.dgvProducts.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProducts_CellContentClick);
            // 
            // pnlSearch
            // 
            this.pnlSearch.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlSearch.Controls.Add(this.txtSearchProduct);
            this.pnlSearch.Controls.Add(this.cboCategory);
            this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearch.Location = new System.Drawing.Point(0, 0);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(550, 70);
            this.pnlSearch.TabIndex = 1;
            // 
            // txtSearchProduct
            // 
            this.txtSearchProduct.BorderRadius = 5;
            this.txtSearchProduct.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearchProduct.DefaultText = "";
            this.txtSearchProduct.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSearchProduct.Location = new System.Drawing.Point(170, 15);
            this.txtSearchProduct.Name = "txtSearchProduct";
            this.txtSearchProduct.PlaceholderText = "Tìm tên, mã vạch...";
            this.txtSearchProduct.SelectedText = "";
            this.txtSearchProduct.Size = new System.Drawing.Size(370, 36);
            this.txtSearchProduct.TabIndex = 0;
            // 
            // cboCategory
            // 
            this.cboCategory.BackColor = System.Drawing.Color.Transparent;
            this.cboCategory.BorderRadius = 5;
            this.cboCategory.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategory.FocusedColor = System.Drawing.Color.Empty;
            this.cboCategory.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboCategory.ItemHeight = 30;
            this.cboCategory.Location = new System.Drawing.Point(10, 15);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(150, 36);
            this.cboCategory.TabIndex = 1;
            // 
            // colProdId
            // 
            this.colProdId.HeaderText = "ID sản phẩm";
            this.colProdId.Name = "colProdId";
            // 
            // colProdCode
            // 
            this.colProdCode.FillWeight = 60F;
            this.colProdCode.HeaderText = "Mã";
            this.colProdCode.Name = "colProdCode";
            // 
            // colProdName
            // 
            this.colProdName.FillWeight = 180F;
            this.colProdName.HeaderText = "Tên sản phẩm";
            this.colProdName.Name = "colProdName";
            // 
            // colProdStockMain
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colProdStockMain.DefaultCellStyle = dataGridViewCellStyle4;
            this.colProdStockMain.FillWeight = 50F;
            this.colProdStockMain.HeaderText = "Kho";
            this.colProdStockMain.Name = "colProdStockMain";
            // 
            // colProdStockCounter
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colProdStockCounter.DefaultCellStyle = dataGridViewCellStyle5;
            this.colProdStockCounter.FillWeight = 50F;
            this.colProdStockCounter.HeaderText = "Quầy";
            this.colProdStockCounter.Name = "colProdStockCounter";
            // 
            // colTransId
            // 
            this.colTransId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colTransId.FillWeight = 50F;
            this.colTransId.HeaderText = "Phiếu chuyển";
            this.colTransId.Name = "colTransId";
            this.colTransId.Width = 106;
            // 
            // colTransName
            // 
            this.colTransName.FillWeight = 120F;
            this.colTransName.HeaderText = "Tên hàng";
            this.colTransName.Name = "colTransName";
            this.colTransName.ReadOnly = true;
            // 
            // colTransUnit
            // 
            this.colTransUnit.FillWeight = 40F;
            this.colTransUnit.HeaderText = "ĐVT";
            this.colTransUnit.Name = "colTransUnit";
            this.colTransUnit.ReadOnly = true;
            // 
            // colTransCurrentStock
            // 
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Gray;
            this.colTransCurrentStock.DefaultCellStyle = dataGridViewCellStyle2;
            this.colTransCurrentStock.FillWeight = 60F;
            this.colTransCurrentStock.HeaderText = "Tồn nguồn";
            this.colTransCurrentStock.Name = "colTransCurrentStock";
            this.colTransCurrentStock.ReadOnly = true;
            // 
            // colTransQty
            // 
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Blue;
            this.colTransQty.DefaultCellStyle = dataGridViewCellStyle3;
            this.colTransQty.FillWeight = 60F;
            this.colTransQty.HeaderText = "SL Chuyển";
            // Set AutoSizeMode for each column to ensure columns fit their content
            this.colTransId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colTransName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTransUnit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colTransCurrentStock.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colTransQty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colBtnDelete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colTransQty.Name = "colTransQty";
            // 
            // colBtnDelete
            // 
            this.colBtnDelete.FillWeight = 30F;
            this.colBtnDelete.HeaderText = "";
            this.colBtnDelete.Name = "colBtnDelete";
            this.colBtnDelete.Text = "X";
            this.colBtnDelete.UseColumnTextForButtonValue = true;
            // 
            // frmStockTransfer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 595);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlRight);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmStockTransfer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chuyển Kho/Quầy";
            this.pnlRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransferItems)).EndInit();
            this.pnlAction.ResumeLayout(false);
            this.pnlInfo.ResumeLayout(false);
            this.pnlInfo.PerformLayout();
            this.pnlLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.pnlSearch.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        // Controls
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Panel pnlInfo;
        private System.Windows.Forms.Panel pnlAction;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel pnlSearch;

        private Guna.UI2.WinForms.Guna2ComboBox cboFromLocation;
        private Guna.UI2.WinForms.Guna2ComboBox cboToLocation;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpTransferDate;
        private Guna.UI2.WinForms.Guna2TextBox txtNote;
        private System.Windows.Forms.Label lblTitleRight;
        private System.Windows.Forms.Label lblArrow;

        private Guna.UI2.WinForms.Guna2Button btnSave;
        private Guna.UI2.WinForms.Guna2Button btnCancel;

        private System.Windows.Forms.DataGridView dgvTransferItems;
        private System.Windows.Forms.DataGridView dgvProducts;
        private Guna.UI2.WinForms.Guna2TextBox txtSearchProduct;
        private Guna.UI2.WinForms.Guna2ComboBox cboCategory;
        private DataGridViewTextBoxColumn colProdId;
        private DataGridViewTextBoxColumn colProdCode;
        private DataGridViewTextBoxColumn colProdName;
        private DataGridViewTextBoxColumn colProdStockMain;
        private DataGridViewTextBoxColumn colProdStockCounter;
        private DataGridViewTextBoxColumn colTransId;
        private DataGridViewTextBoxColumn colTransName;
        private DataGridViewTextBoxColumn colTransUnit;
        private DataGridViewTextBoxColumn colTransCurrentStock;
        private DataGridViewTextBoxColumn colTransQty;
        private DataGridViewButtonColumn colBtnDelete;
    }
}