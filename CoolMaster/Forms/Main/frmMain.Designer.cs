namespace CoolMaster.Forms.Main
{
    partial class frmMain
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
            this.pnlMenu = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.btnSettings = new FontAwesome.Sharp.IconButton();
            this.pnlSystemSubMenu = new System.Windows.Forms.Panel();
            this.btnStats = new FontAwesome.Sharp.IconButton();
            this.btnStaff = new FontAwesome.Sharp.IconButton();
            this.btnSystem = new FontAwesome.Sharp.IconButton();
            this.btnService = new FontAwesome.Sharp.IconButton();
            this.pnlPartnerSubMenu = new System.Windows.Forms.Panel();
            this.btnSupplier = new FontAwesome.Sharp.IconButton();
            this.btnCustomer = new FontAwesome.Sharp.IconButton();
            this.btnPartners = new FontAwesome.Sharp.IconButton();
            this.pnlInventorySubMenu = new System.Windows.Forms.Panel();
            this.btnStockOut = new FontAwesome.Sharp.IconButton();
            this.btnStockIn = new FontAwesome.Sharp.IconButton();
            this.btnInventory = new FontAwesome.Sharp.IconButton();
            this.pnlSaleSubMenu = new System.Windows.Forms.Panel();
            this.btnProduct = new FontAwesome.Sharp.IconButton();
            this.btnOrderList = new FontAwesome.Sharp.IconButton();
            this.btnPOS = new FontAwesome.Sharp.IconButton();
            this.btnSales = new FontAwesome.Sharp.IconButton();
            this.btnDashboard = new FontAwesome.Sharp.IconButton();
            this.btnLogoCoolMaster = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.pnlTitleBar = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnUser = new FontAwesome.Sharp.IconButton();
            this.btnCloseMain = new System.Windows.Forms.Button();
            this.btnMaximize = new System.Windows.Forms.Button();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.iconCurrentChildForm = new FontAwesome.Sharp.IconButton();
            this.lblTitleChildForm = new System.Windows.Forms.Label();
            this.pnlDesktop = new System.Windows.Forms.Panel();
            this.pnlDisplay = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblDateFull = new System.Windows.Forms.Label();
            this.lblTimeDate = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.guna2CirclePictureBox1 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SalesTimer = new System.Windows.Forms.Timer(this.components);
            this.pnlMenu.SuspendLayout();
            this.pnlSystemSubMenu.SuspendLayout();
            this.pnlPartnerSubMenu.SuspendLayout();
            this.pnlInventorySubMenu.SuspendLayout();
            this.pnlSaleSubMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnLogoCoolMaster)).BeginInit();
            this.pnlTitleBar.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlDesktop.SuspendLayout();
            this.pnlDisplay.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMenu
            // 
            this.pnlMenu.Controls.Add(this.btnSettings);
            this.pnlMenu.Controls.Add(this.pnlSystemSubMenu);
            this.pnlMenu.Controls.Add(this.btnSystem);
            this.pnlMenu.Controls.Add(this.btnService);
            this.pnlMenu.Controls.Add(this.pnlPartnerSubMenu);
            this.pnlMenu.Controls.Add(this.btnPartners);
            this.pnlMenu.Controls.Add(this.pnlInventorySubMenu);
            this.pnlMenu.Controls.Add(this.btnInventory);
            this.pnlMenu.Controls.Add(this.pnlSaleSubMenu);
            this.pnlMenu.Controls.Add(this.btnSales);
            this.pnlMenu.Controls.Add(this.btnDashboard);
            this.pnlMenu.Controls.Add(this.btnLogoCoolMaster);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenu.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(57)))), ((int)(((byte)(142)))));
            this.pnlMenu.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(57)))), ((int)(((byte)(142)))));
            this.pnlMenu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(210)))), ((int)(((byte)(216)))));
            this.pnlMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(210, 670);
            this.pnlMenu.TabIndex = 0;
            // 
            // btnSettings
            // 
            this.btnSettings.BackColor = System.Drawing.Color.Transparent;
            this.btnSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSettings.FlatAppearance.BorderSize = 0;
            this.btnSettings.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(60)))), ((int)(((byte)(184)))));
            this.btnSettings.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(60)))), ((int)(((byte)(184)))));
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSettings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(234)))), ((int)(((byte)(254)))));
            this.btnSettings.IconChar = FontAwesome.Sharp.IconChar.Cog;
            this.btnSettings.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(234)))), ((int)(((byte)(254)))));
            this.btnSettings.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSettings.IconSize = 40;
            this.btnSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSettings.Location = new System.Drawing.Point(0, 491);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnSettings.Size = new System.Drawing.Size(210, 60);
            this.btnSettings.TabIndex = 19;
            this.btnSettings.Text = "Cài đặt";
            this.btnSettings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSettings.UseVisualStyleBackColor = false;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // pnlSystemSubMenu
            // 
            this.pnlSystemSubMenu.BackColor = System.Drawing.Color.Transparent;
            this.pnlSystemSubMenu.Controls.Add(this.btnStats);
            this.pnlSystemSubMenu.Controls.Add(this.btnStaff);
            this.pnlSystemSubMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSystemSubMenu.Location = new System.Drawing.Point(0, 481);
            this.pnlSystemSubMenu.MaximumSize = new System.Drawing.Size(210, 120);
            this.pnlSystemSubMenu.MinimumSize = new System.Drawing.Size(210, 0);
            this.pnlSystemSubMenu.Name = "pnlSystemSubMenu";
            this.pnlSystemSubMenu.Size = new System.Drawing.Size(210, 10);
            this.pnlSystemSubMenu.TabIndex = 18;
            // 
            // btnStats
            // 
            this.btnStats.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(128)))));
            this.btnStats.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnStats.FlatAppearance.BorderSize = 0;
            this.btnStats.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(60)))), ((int)(((byte)(184)))));
            this.btnStats.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(60)))), ((int)(((byte)(184)))));
            this.btnStats.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStats.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStats.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(234)))), ((int)(((byte)(254)))));
            this.btnStats.IconChar = FontAwesome.Sharp.IconChar.ChartLine;
            this.btnStats.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(234)))), ((int)(((byte)(254)))));
            this.btnStats.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnStats.IconSize = 40;
            this.btnStats.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStats.Location = new System.Drawing.Point(0, 60);
            this.btnStats.Name = "btnStats";
            this.btnStats.Padding = new System.Windows.Forms.Padding(30, 0, 10, 0);
            this.btnStats.Size = new System.Drawing.Size(210, 60);
            this.btnStats.TabIndex = 21;
            this.btnStats.Text = "Doanh thu";
            this.btnStats.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStats.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnStats.UseVisualStyleBackColor = false;
            this.btnStats.Click += new System.EventHandler(this.btnStats_Click);
            // 
            // btnStaff
            // 
            this.btnStaff.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(128)))));
            this.btnStaff.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnStaff.FlatAppearance.BorderSize = 0;
            this.btnStaff.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(60)))), ((int)(((byte)(184)))));
            this.btnStaff.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(60)))), ((int)(((byte)(184)))));
            this.btnStaff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStaff.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStaff.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(234)))), ((int)(((byte)(254)))));
            this.btnStaff.IconChar = FontAwesome.Sharp.IconChar.UserTie;
            this.btnStaff.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(234)))), ((int)(((byte)(254)))));
            this.btnStaff.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnStaff.IconSize = 40;
            this.btnStaff.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStaff.Location = new System.Drawing.Point(0, 0);
            this.btnStaff.Name = "btnStaff";
            this.btnStaff.Padding = new System.Windows.Forms.Padding(30, 0, 10, 0);
            this.btnStaff.Size = new System.Drawing.Size(210, 60);
            this.btnStaff.TabIndex = 20;
            this.btnStaff.Text = "Nhân sự";
            this.btnStaff.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStaff.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnStaff.UseVisualStyleBackColor = false;
            this.btnStaff.Click += new System.EventHandler(this.btnStaff_Click);
            // 
            // btnSystem
            // 
            this.btnSystem.BackColor = System.Drawing.Color.Transparent;
            this.btnSystem.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSystem.FlatAppearance.BorderSize = 0;
            this.btnSystem.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(60)))), ((int)(((byte)(184)))));
            this.btnSystem.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(60)))), ((int)(((byte)(184)))));
            this.btnSystem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSystem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSystem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(234)))), ((int)(((byte)(254)))));
            this.btnSystem.IconChar = FontAwesome.Sharp.IconChar.Computer;
            this.btnSystem.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(234)))), ((int)(((byte)(254)))));
            this.btnSystem.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSystem.IconSize = 40;
            this.btnSystem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSystem.Location = new System.Drawing.Point(0, 421);
            this.btnSystem.Name = "btnSystem";
            this.btnSystem.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnSystem.Size = new System.Drawing.Size(210, 60);
            this.btnSystem.TabIndex = 17;
            this.btnSystem.Text = "Hệ thống";
            this.btnSystem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSystem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSystem.UseVisualStyleBackColor = false;
            this.btnSystem.Click += new System.EventHandler(this.btnSystem_Click);
            // 
            // btnService
            // 
            this.btnService.BackColor = System.Drawing.Color.Transparent;
            this.btnService.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnService.FlatAppearance.BorderSize = 0;
            this.btnService.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(60)))), ((int)(((byte)(184)))));
            this.btnService.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(60)))), ((int)(((byte)(184)))));
            this.btnService.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnService.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnService.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(234)))), ((int)(((byte)(254)))));
            this.btnService.IconChar = FontAwesome.Sharp.IconChar.Screwdriver;
            this.btnService.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(234)))), ((int)(((byte)(254)))));
            this.btnService.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnService.IconSize = 40;
            this.btnService.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnService.Location = new System.Drawing.Point(0, 361);
            this.btnService.Name = "btnService";
            this.btnService.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnService.Size = new System.Drawing.Size(210, 60);
            this.btnService.TabIndex = 16;
            this.btnService.Text = "Kĩ thuật";
            this.btnService.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnService.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnService.UseVisualStyleBackColor = false;
            this.btnService.Click += new System.EventHandler(this.btnService_Click);
            // 
            // pnlPartnerSubMenu
            // 
            this.pnlPartnerSubMenu.BackColor = System.Drawing.Color.Transparent;
            this.pnlPartnerSubMenu.Controls.Add(this.btnSupplier);
            this.pnlPartnerSubMenu.Controls.Add(this.btnCustomer);
            this.pnlPartnerSubMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPartnerSubMenu.Location = new System.Drawing.Point(0, 351);
            this.pnlPartnerSubMenu.MaximumSize = new System.Drawing.Size(210, 120);
            this.pnlPartnerSubMenu.MinimumSize = new System.Drawing.Size(210, 0);
            this.pnlPartnerSubMenu.Name = "pnlPartnerSubMenu";
            this.pnlPartnerSubMenu.Size = new System.Drawing.Size(210, 10);
            this.pnlPartnerSubMenu.TabIndex = 15;
            // 
            // btnSupplier
            // 
            this.btnSupplier.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(128)))));
            this.btnSupplier.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSupplier.FlatAppearance.BorderSize = 0;
            this.btnSupplier.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(60)))), ((int)(((byte)(184)))));
            this.btnSupplier.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(60)))), ((int)(((byte)(184)))));
            this.btnSupplier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSupplier.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSupplier.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(234)))), ((int)(((byte)(254)))));
            this.btnSupplier.IconChar = FontAwesome.Sharp.IconChar.TruckField;
            this.btnSupplier.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(234)))), ((int)(((byte)(254)))));
            this.btnSupplier.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSupplier.IconSize = 40;
            this.btnSupplier.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSupplier.Location = new System.Drawing.Point(0, 60);
            this.btnSupplier.Name = "btnSupplier";
            this.btnSupplier.Padding = new System.Windows.Forms.Padding(30, 0, 10, 0);
            this.btnSupplier.Size = new System.Drawing.Size(210, 60);
            this.btnSupplier.TabIndex = 20;
            this.btnSupplier.Text = "Nhà cung cấp";
            this.btnSupplier.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSupplier.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSupplier.UseVisualStyleBackColor = false;
            this.btnSupplier.Click += new System.EventHandler(this.btnSupplier_Click);
            // 
            // btnCustomer
            // 
            this.btnCustomer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(128)))));
            this.btnCustomer.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCustomer.FlatAppearance.BorderSize = 0;
            this.btnCustomer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(60)))), ((int)(((byte)(184)))));
            this.btnCustomer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(60)))), ((int)(((byte)(184)))));
            this.btnCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustomer.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCustomer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(234)))), ((int)(((byte)(254)))));
            this.btnCustomer.IconChar = FontAwesome.Sharp.IconChar.Users;
            this.btnCustomer.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(234)))), ((int)(((byte)(254)))));
            this.btnCustomer.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCustomer.IconSize = 40;
            this.btnCustomer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCustomer.Location = new System.Drawing.Point(0, 0);
            this.btnCustomer.Name = "btnCustomer";
            this.btnCustomer.Padding = new System.Windows.Forms.Padding(30, 0, 10, 0);
            this.btnCustomer.Size = new System.Drawing.Size(210, 60);
            this.btnCustomer.TabIndex = 19;
            this.btnCustomer.Text = "Khách hàng";
            this.btnCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCustomer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCustomer.UseVisualStyleBackColor = false;
            this.btnCustomer.Click += new System.EventHandler(this.btnCustomer_Click);
            // 
            // btnPartners
            // 
            this.btnPartners.BackColor = System.Drawing.Color.Transparent;
            this.btnPartners.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPartners.FlatAppearance.BorderSize = 0;
            this.btnPartners.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(60)))), ((int)(((byte)(184)))));
            this.btnPartners.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(60)))), ((int)(((byte)(184)))));
            this.btnPartners.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPartners.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPartners.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(234)))), ((int)(((byte)(254)))));
            this.btnPartners.IconChar = FontAwesome.Sharp.IconChar.Handshake;
            this.btnPartners.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(234)))), ((int)(((byte)(254)))));
            this.btnPartners.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnPartners.IconSize = 40;
            this.btnPartners.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPartners.Location = new System.Drawing.Point(0, 291);
            this.btnPartners.Name = "btnPartners";
            this.btnPartners.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnPartners.Size = new System.Drawing.Size(210, 60);
            this.btnPartners.TabIndex = 14;
            this.btnPartners.Text = "Đối tác";
            this.btnPartners.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPartners.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPartners.UseVisualStyleBackColor = false;
            this.btnPartners.Click += new System.EventHandler(this.btnPartners_Click);
            // 
            // pnlInventorySubMenu
            // 
            this.pnlInventorySubMenu.BackColor = System.Drawing.Color.Transparent;
            this.pnlInventorySubMenu.Controls.Add(this.btnStockOut);
            this.pnlInventorySubMenu.Controls.Add(this.btnStockIn);
            this.pnlInventorySubMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlInventorySubMenu.Location = new System.Drawing.Point(0, 281);
            this.pnlInventorySubMenu.MaximumSize = new System.Drawing.Size(210, 120);
            this.pnlInventorySubMenu.MinimumSize = new System.Drawing.Size(210, 0);
            this.pnlInventorySubMenu.Name = "pnlInventorySubMenu";
            this.pnlInventorySubMenu.Size = new System.Drawing.Size(210, 10);
            this.pnlInventorySubMenu.TabIndex = 12;
            // 
            // btnStockOut
            // 
            this.btnStockOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(128)))));
            this.btnStockOut.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnStockOut.FlatAppearance.BorderSize = 0;
            this.btnStockOut.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(60)))), ((int)(((byte)(184)))));
            this.btnStockOut.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(60)))), ((int)(((byte)(184)))));
            this.btnStockOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStockOut.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStockOut.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(234)))), ((int)(((byte)(254)))));
            this.btnStockOut.IconChar = FontAwesome.Sharp.IconChar.FileExport;
            this.btnStockOut.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(234)))), ((int)(((byte)(254)))));
            this.btnStockOut.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnStockOut.IconSize = 40;
            this.btnStockOut.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStockOut.Location = new System.Drawing.Point(0, 60);
            this.btnStockOut.Name = "btnStockOut";
            this.btnStockOut.Padding = new System.Windows.Forms.Padding(30, 0, 10, 0);
            this.btnStockOut.Size = new System.Drawing.Size(210, 60);
            this.btnStockOut.TabIndex = 19;
            this.btnStockOut.Text = "Xuất kho";
            this.btnStockOut.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStockOut.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnStockOut.UseVisualStyleBackColor = false;
            this.btnStockOut.Click += new System.EventHandler(this.btnStockOut_Click);
            // 
            // btnStockIn
            // 
            this.btnStockIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(128)))));
            this.btnStockIn.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnStockIn.FlatAppearance.BorderSize = 0;
            this.btnStockIn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(60)))), ((int)(((byte)(184)))));
            this.btnStockIn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(60)))), ((int)(((byte)(184)))));
            this.btnStockIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStockIn.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStockIn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(234)))), ((int)(((byte)(254)))));
            this.btnStockIn.IconChar = FontAwesome.Sharp.IconChar.FileImport;
            this.btnStockIn.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(234)))), ((int)(((byte)(254)))));
            this.btnStockIn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnStockIn.IconSize = 40;
            this.btnStockIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStockIn.Location = new System.Drawing.Point(0, 0);
            this.btnStockIn.Name = "btnStockIn";
            this.btnStockIn.Padding = new System.Windows.Forms.Padding(30, 0, 10, 0);
            this.btnStockIn.Size = new System.Drawing.Size(210, 60);
            this.btnStockIn.TabIndex = 18;
            this.btnStockIn.Text = "Nhập kho";
            this.btnStockIn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStockIn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnStockIn.UseVisualStyleBackColor = false;
            this.btnStockIn.Click += new System.EventHandler(this.btnStockIn_Click);
            // 
            // btnInventory
            // 
            this.btnInventory.BackColor = System.Drawing.Color.Transparent;
            this.btnInventory.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnInventory.FlatAppearance.BorderSize = 0;
            this.btnInventory.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(60)))), ((int)(((byte)(184)))));
            this.btnInventory.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(60)))), ((int)(((byte)(184)))));
            this.btnInventory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInventory.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInventory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(234)))), ((int)(((byte)(254)))));
            this.btnInventory.IconChar = FontAwesome.Sharp.IconChar.Warehouse;
            this.btnInventory.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(234)))), ((int)(((byte)(254)))));
            this.btnInventory.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnInventory.IconSize = 40;
            this.btnInventory.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInventory.Location = new System.Drawing.Point(0, 221);
            this.btnInventory.Name = "btnInventory";
            this.btnInventory.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnInventory.Size = new System.Drawing.Size(210, 60);
            this.btnInventory.TabIndex = 13;
            this.btnInventory.Text = "Quản lý kho";
            this.btnInventory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInventory.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnInventory.UseVisualStyleBackColor = false;
            this.btnInventory.Click += new System.EventHandler(this.btnInventory_Click);
            // 
            // pnlSaleSubMenu
            // 
            this.pnlSaleSubMenu.BackColor = System.Drawing.Color.Transparent;
            this.pnlSaleSubMenu.Controls.Add(this.btnProduct);
            this.pnlSaleSubMenu.Controls.Add(this.btnOrderList);
            this.pnlSaleSubMenu.Controls.Add(this.btnPOS);
            this.pnlSaleSubMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSaleSubMenu.Location = new System.Drawing.Point(0, 211);
            this.pnlSaleSubMenu.MaximumSize = new System.Drawing.Size(210, 180);
            this.pnlSaleSubMenu.MinimumSize = new System.Drawing.Size(210, 0);
            this.pnlSaleSubMenu.Name = "pnlSaleSubMenu";
            this.pnlSaleSubMenu.Size = new System.Drawing.Size(210, 10);
            this.pnlSaleSubMenu.TabIndex = 11;
            // 
            // btnProduct
            // 
            this.btnProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(128)))));
            this.btnProduct.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnProduct.FlatAppearance.BorderSize = 0;
            this.btnProduct.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(60)))), ((int)(((byte)(184)))));
            this.btnProduct.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(60)))), ((int)(((byte)(184)))));
            this.btnProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProduct.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProduct.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(234)))), ((int)(((byte)(254)))));
            this.btnProduct.IconChar = FontAwesome.Sharp.IconChar.BoxesStacked;
            this.btnProduct.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(234)))), ((int)(((byte)(254)))));
            this.btnProduct.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnProduct.IconSize = 40;
            this.btnProduct.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProduct.Location = new System.Drawing.Point(0, 120);
            this.btnProduct.Name = "btnProduct";
            this.btnProduct.Padding = new System.Windows.Forms.Padding(30, 0, 10, 0);
            this.btnProduct.Size = new System.Drawing.Size(210, 60);
            this.btnProduct.TabIndex = 18;
            this.btnProduct.Text = "Sản phẩm";
            this.btnProduct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProduct.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnProduct.UseVisualStyleBackColor = false;
            this.btnProduct.Click += new System.EventHandler(this.btnProduct_Click);
            // 
            // btnOrderList
            // 
            this.btnOrderList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(128)))));
            this.btnOrderList.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnOrderList.FlatAppearance.BorderSize = 0;
            this.btnOrderList.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(60)))), ((int)(((byte)(184)))));
            this.btnOrderList.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(60)))), ((int)(((byte)(184)))));
            this.btnOrderList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrderList.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrderList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(234)))), ((int)(((byte)(254)))));
            this.btnOrderList.IconChar = FontAwesome.Sharp.IconChar.FileInvoiceDollar;
            this.btnOrderList.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(234)))), ((int)(((byte)(254)))));
            this.btnOrderList.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnOrderList.IconSize = 40;
            this.btnOrderList.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOrderList.Location = new System.Drawing.Point(0, 60);
            this.btnOrderList.Name = "btnOrderList";
            this.btnOrderList.Padding = new System.Windows.Forms.Padding(30, 0, 10, 0);
            this.btnOrderList.Size = new System.Drawing.Size(210, 60);
            this.btnOrderList.TabIndex = 17;
            this.btnOrderList.Text = "Hóa đơn";
            this.btnOrderList.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOrderList.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnOrderList.UseVisualStyleBackColor = false;
            this.btnOrderList.Click += new System.EventHandler(this.btnOrderList_Click);
            // 
            // btnPOS
            // 
            this.btnPOS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(128)))));
            this.btnPOS.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPOS.FlatAppearance.BorderSize = 0;
            this.btnPOS.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(60)))), ((int)(((byte)(184)))));
            this.btnPOS.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(60)))), ((int)(((byte)(184)))));
            this.btnPOS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPOS.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPOS.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(234)))), ((int)(((byte)(254)))));
            this.btnPOS.IconChar = FontAwesome.Sharp.IconChar.CashRegister;
            this.btnPOS.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(234)))), ((int)(((byte)(254)))));
            this.btnPOS.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnPOS.IconSize = 40;
            this.btnPOS.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPOS.Location = new System.Drawing.Point(0, 0);
            this.btnPOS.Name = "btnPOS";
            this.btnPOS.Padding = new System.Windows.Forms.Padding(30, 0, 10, 0);
            this.btnPOS.Size = new System.Drawing.Size(210, 60);
            this.btnPOS.TabIndex = 16;
            this.btnPOS.Text = "Máy POS";
            this.btnPOS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPOS.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPOS.UseVisualStyleBackColor = false;
            this.btnPOS.Click += new System.EventHandler(this.btnPOS_Click);
            // 
            // btnSales
            // 
            this.btnSales.BackColor = System.Drawing.Color.Transparent;
            this.btnSales.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSales.FlatAppearance.BorderSize = 0;
            this.btnSales.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(60)))), ((int)(((byte)(184)))));
            this.btnSales.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(60)))), ((int)(((byte)(184)))));
            this.btnSales.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSales.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSales.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(234)))), ((int)(((byte)(254)))));
            this.btnSales.IconChar = FontAwesome.Sharp.IconChar.StoreAlt;
            this.btnSales.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(234)))), ((int)(((byte)(254)))));
            this.btnSales.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSales.IconSize = 40;
            this.btnSales.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSales.Location = new System.Drawing.Point(0, 151);
            this.btnSales.Name = "btnSales";
            this.btnSales.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnSales.Size = new System.Drawing.Size(210, 60);
            this.btnSales.TabIndex = 10;
            this.btnSales.Text = "Bán hàng";
            this.btnSales.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSales.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSales.UseVisualStyleBackColor = false;
            this.btnSales.Click += new System.EventHandler(this.btnSales_Click);
            // 
            // btnDashboard
            // 
            this.btnDashboard.BackColor = System.Drawing.Color.Transparent;
            this.btnDashboard.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDashboard.FlatAppearance.BorderSize = 0;
            this.btnDashboard.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(60)))), ((int)(((byte)(184)))));
            this.btnDashboard.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(60)))), ((int)(((byte)(184)))));
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDashboard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(234)))), ((int)(((byte)(254)))));
            this.btnDashboard.IconChar = FontAwesome.Sharp.IconChar.House;
            this.btnDashboard.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(234)))), ((int)(((byte)(254)))));
            this.btnDashboard.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnDashboard.IconSize = 40;
            this.btnDashboard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.Location = new System.Drawing.Point(0, 91);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnDashboard.Size = new System.Drawing.Size(210, 60);
            this.btnDashboard.TabIndex = 3;
            this.btnDashboard.Text = "Trang chủ";
            this.btnDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDashboard.UseVisualStyleBackColor = false;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // btnLogoCoolMaster
            // 
            this.btnLogoCoolMaster.BackColor = System.Drawing.Color.Transparent;
            this.btnLogoCoolMaster.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnLogoCoolMaster.Image = global::CoolMaster.Properties.Resources.Logo_CoolMaster;
            this.btnLogoCoolMaster.ImageRotate = 0F;
            this.btnLogoCoolMaster.Location = new System.Drawing.Point(0, 0);
            this.btnLogoCoolMaster.Name = "btnLogoCoolMaster";
            this.btnLogoCoolMaster.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnLogoCoolMaster.Size = new System.Drawing.Size(210, 91);
            this.btnLogoCoolMaster.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnLogoCoolMaster.TabIndex = 1;
            this.btnLogoCoolMaster.TabStop = false;
            this.btnLogoCoolMaster.Click += new System.EventHandler(this.btnLogoCoolMaster_Click);
            // 
            // pnlTitleBar
            // 
            this.pnlTitleBar.BackColor = System.Drawing.Color.White;
            this.pnlTitleBar.Controls.Add(this.panel1);
            this.pnlTitleBar.Controls.Add(this.btnCloseMain);
            this.pnlTitleBar.Controls.Add(this.btnMaximize);
            this.pnlTitleBar.Controls.Add(this.btnMinimize);
            this.pnlTitleBar.Controls.Add(this.iconCurrentChildForm);
            this.pnlTitleBar.Controls.Add(this.lblTitleChildForm);
            this.pnlTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitleBar.Location = new System.Drawing.Point(210, 0);
            this.pnlTitleBar.Name = "pnlTitleBar";
            this.pnlTitleBar.Size = new System.Drawing.Size(990, 75);
            this.pnlTitleBar.TabIndex = 1;
            this.pnlTitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTitleBar_MouseDown);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.btnUser);
            this.panel1.Location = new System.Drawing.Point(804, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(183, 40);
            this.panel1.TabIndex = 21;
            // 
            // btnUser
            // 
            this.btnUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUser.BackColor = System.Drawing.Color.Transparent;
            this.btnUser.FlatAppearance.BorderSize = 0;
            this.btnUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(57)))), ((int)(((byte)(142)))));
            this.btnUser.IconChar = FontAwesome.Sharp.IconChar.UserCircle;
            this.btnUser.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(57)))), ((int)(((byte)(142)))));
            this.btnUser.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnUser.Location = new System.Drawing.Point(138, 0);
            this.btnUser.Name = "btnUser";
            this.btnUser.Size = new System.Drawing.Size(45, 40);
            this.btnUser.TabIndex = 22;
            this.btnUser.UseVisualStyleBackColor = false;
            // 
            // btnCloseMain
            // 
            this.btnCloseMain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCloseMain.FlatAppearance.BorderSize = 0;
            this.btnCloseMain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseMain.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCloseMain.ForeColor = System.Drawing.Color.DimGray;
            this.btnCloseMain.Location = new System.Drawing.Point(957, 1);
            this.btnCloseMain.Name = "btnCloseMain";
            this.btnCloseMain.Size = new System.Drawing.Size(30, 30);
            this.btnCloseMain.TabIndex = 4;
            this.btnCloseMain.Text = "O";
            this.btnCloseMain.UseVisualStyleBackColor = true;
            this.btnCloseMain.Click += new System.EventHandler(this.btnCloseMain_Click);
            // 
            // btnMaximize
            // 
            this.btnMaximize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMaximize.FlatAppearance.BorderSize = 0;
            this.btnMaximize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaximize.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMaximize.ForeColor = System.Drawing.Color.DimGray;
            this.btnMaximize.Location = new System.Drawing.Point(916, 1);
            this.btnMaximize.Name = "btnMaximize";
            this.btnMaximize.Size = new System.Drawing.Size(30, 30);
            this.btnMaximize.TabIndex = 3;
            this.btnMaximize.Text = "O";
            this.btnMaximize.UseVisualStyleBackColor = true;
            this.btnMaximize.Click += new System.EventHandler(this.btnMaximize_Click);
            // 
            // btnMinimize
            // 
            this.btnMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMinimize.ForeColor = System.Drawing.Color.DimGray;
            this.btnMinimize.Location = new System.Drawing.Point(875, 1);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(30, 30);
            this.btnMinimize.TabIndex = 2;
            this.btnMinimize.Text = "O";
            this.btnMinimize.UseVisualStyleBackColor = true;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // iconCurrentChildForm
            // 
            this.iconCurrentChildForm.BackColor = System.Drawing.Color.White;
            this.iconCurrentChildForm.FlatAppearance.BorderSize = 0;
            this.iconCurrentChildForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconCurrentChildForm.IconChar = FontAwesome.Sharp.IconChar.Snowflake;
            this.iconCurrentChildForm.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(57)))), ((int)(((byte)(142)))));
            this.iconCurrentChildForm.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconCurrentChildForm.IconSize = 40;
            this.iconCurrentChildForm.Location = new System.Drawing.Point(16, 15);
            this.iconCurrentChildForm.Name = "iconCurrentChildForm";
            this.iconCurrentChildForm.Size = new System.Drawing.Size(45, 45);
            this.iconCurrentChildForm.TabIndex = 1;
            this.iconCurrentChildForm.UseVisualStyleBackColor = false;
            // 
            // lblTitleChildForm
            // 
            this.lblTitleChildForm.AutoSize = true;
            this.lblTitleChildForm.Font = new System.Drawing.Font("Segoe UI", 21F);
            this.lblTitleChildForm.ForeColor = System.Drawing.Color.Black;
            this.lblTitleChildForm.Location = new System.Drawing.Point(68, 14);
            this.lblTitleChildForm.Name = "lblTitleChildForm";
            this.lblTitleChildForm.Size = new System.Drawing.Size(168, 38);
            this.lblTitleChildForm.TabIndex = 0;
            this.lblTitleChildForm.Text = "Chào mừng!";
            // 
            // pnlDesktop
            // 
            this.pnlDesktop.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDesktop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.pnlDesktop.Controls.Add(this.pnlDisplay);
            this.pnlDesktop.Location = new System.Drawing.Point(210, 75);
            this.pnlDesktop.Name = "pnlDesktop";
            this.pnlDesktop.Size = new System.Drawing.Size(990, 595);
            this.pnlDesktop.TabIndex = 2;
            // 
            // pnlDisplay
            // 
            this.pnlDisplay.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlDisplay.Controls.Add(this.panel2);
            this.pnlDisplay.Controls.Add(this.guna2CirclePictureBox1);
            this.pnlDisplay.Location = new System.Drawing.Point(167, 171);
            this.pnlDisplay.Name = "pnlDisplay";
            this.pnlDisplay.Size = new System.Drawing.Size(656, 253);
            this.pnlDisplay.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblDateFull);
            this.panel2.Controls.Add(this.lblTimeDate);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(206, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(450, 253);
            this.panel2.TabIndex = 7;
            // 
            // lblDateFull
            // 
            this.lblDateFull.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDateFull.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblDateFull.ForeColor = System.Drawing.Color.Black;
            this.lblDateFull.Location = new System.Drawing.Point(3, 177);
            this.lblDateFull.Name = "lblDateFull";
            this.lblDateFull.Size = new System.Drawing.Size(444, 21);
            this.lblDateFull.TabIndex = 8;
            this.lblDateFull.Text = "DateFull";
            this.lblDateFull.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTimeDate
            // 
            this.lblTimeDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTimeDate.Font = new System.Drawing.Font("Segoe UI", 36F);
            this.lblTimeDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(57)))), ((int)(((byte)(142)))));
            this.lblTimeDate.Location = new System.Drawing.Point(3, 112);
            this.lblTimeDate.Name = "lblTimeDate";
            this.lblTimeDate.Size = new System.Drawing.Size(444, 65);
            this.lblTimeDate.TabIndex = 7;
            this.lblTimeDate.Text = "00:00:00";
            this.lblTimeDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(3, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(444, 65);
            this.label4.TabIndex = 6;
            this.label4.Text = "COOL MASTER";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // guna2CirclePictureBox1
            // 
            this.guna2CirclePictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2CirclePictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.guna2CirclePictureBox1.Image = global::CoolMaster.Properties.Resources.Logo_CoolMaster;
            this.guna2CirclePictureBox1.ImageRotate = 0F;
            this.guna2CirclePictureBox1.Location = new System.Drawing.Point(0, 0);
            this.guna2CirclePictureBox1.Name = "guna2CirclePictureBox1";
            this.guna2CirclePictureBox1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CirclePictureBox1.Size = new System.Drawing.Size(206, 253);
            this.guna2CirclePictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2CirclePictureBox1.TabIndex = 6;
            this.guna2CirclePictureBox1.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // SalesTimer
            // 
            this.SalesTimer.Interval = 10;
            this.SalesTimer.Tick += new System.EventHandler(this.SalesTimer_Tick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 670);
            this.Controls.Add(this.pnlDesktop);
            this.Controls.Add(this.pnlTitleBar);
            this.Controls.Add(this.pnlMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMain";
            this.Text = "CoolMaster";
            this.pnlMenu.ResumeLayout(false);
            this.pnlSystemSubMenu.ResumeLayout(false);
            this.pnlPartnerSubMenu.ResumeLayout(false);
            this.pnlInventorySubMenu.ResumeLayout(false);
            this.pnlSaleSubMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnLogoCoolMaster)).EndInit();
            this.pnlTitleBar.ResumeLayout(false);
            this.pnlTitleBar.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.pnlDesktop.ResumeLayout(false);
            this.pnlDisplay.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GradientPanel pnlMenu;
        private Guna.UI2.WinForms.Guna2CirclePictureBox btnLogoCoolMaster;
        private System.Windows.Forms.Panel pnlTitleBar;
        private System.Windows.Forms.Panel pnlDesktop;
        private System.Windows.Forms.Label lblTitleChildForm;
        private FontAwesome.Sharp.IconButton iconCurrentChildForm;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Button btnCloseMain;
        private System.Windows.Forms.Button btnMaximize;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblTimeDate;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2CirclePictureBox guna2CirclePictureBox1;
        private System.Windows.Forms.Label lblDateFull;
        private System.Windows.Forms.Panel pnlDisplay;
        private FontAwesome.Sharp.IconButton btnDashboard;
        private System.Windows.Forms.Timer SalesTimer;
        private System.Windows.Forms.Panel pnlSaleSubMenu;
        private FontAwesome.Sharp.IconButton btnOrderList;
        private FontAwesome.Sharp.IconButton btnPOS;
        private FontAwesome.Sharp.IconButton btnSales;
        private FontAwesome.Sharp.IconButton btnProduct;
        private System.Windows.Forms.Panel pnlInventorySubMenu;
        private FontAwesome.Sharp.IconButton btnStockOut;
        private FontAwesome.Sharp.IconButton btnStockIn;
        private FontAwesome.Sharp.IconButton btnInventory;
        private FontAwesome.Sharp.IconButton btnPartners;
        private System.Windows.Forms.Panel pnlPartnerSubMenu;
        private FontAwesome.Sharp.IconButton btnSupplier;
        private FontAwesome.Sharp.IconButton btnCustomer;
        private System.Windows.Forms.Panel pnlSystemSubMenu;
        private FontAwesome.Sharp.IconButton btnStats;
        private FontAwesome.Sharp.IconButton btnStaff;
        private FontAwesome.Sharp.IconButton btnSystem;
        private FontAwesome.Sharp.IconButton btnService;
        private System.Windows.Forms.Panel panel1;
        private FontAwesome.Sharp.IconButton btnUser;
        private FontAwesome.Sharp.IconButton btnSettings;
    }
}