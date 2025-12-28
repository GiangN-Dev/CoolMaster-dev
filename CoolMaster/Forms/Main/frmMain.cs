using CoolMaster.Data.Repositories;
using CoolMaster.Forms;
using CoolMaster.Forms.AppSystem;
using CoolMaster.Forms.Inventory;
using CoolMaster.Forms.Sales;
using CoolMaster.Forms.Settings;
using CoolMaster.Forms.Suppliers;
using CoolMaster.Forms.Technical;
using CoolMaster.Model;
using CoolMaster.Services;
using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoolMaster.Forms.Main
{
    public partial class frmMain : Form
    {
        // Fields - Dữ liệu hệ thống
        private readonly string _connectionString;
        private readonly IServiceTicketService _ticketService;

        // Thông tin user đăng nhập (Giải quyết lỗi 'CurrentUser' does not contain definition)
        public User CurrentUser { get; private set; }

        // Fields - Giao diện
        private IconButton currentBtn;
        private Form currentChildForm;
        private Panel currentChildPanel = null;
        private Panel panelToAnimate;
        private bool isMenuExpanded;
        private Panel previousPanel = null;

        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(219, 234, 254);
            public static Color color2 = Color.FromArgb(0, 211, 243);
            public static Color color3 = Color.FromArgb(28, 57, 142);
            public static Color color4 = Color.FromArgb(17, 45, 128);
            public static Color color5 = Color.FromArgb(249, 88, 155);
            public static Color color6 = Color.FromArgb(25, 60, 184);
        }

        public frmMain(string connectionString, IServiceTicketService ticketService, User user)
        {
            InitializeComponent();
            _connectionString = connectionString;
            _ticketService = ticketService;

            // Gán user và kiểm tra null
            CurrentUser = user ?? throw new ArgumentNullException(nameof(user));

            ConfigureFormInitialState();
            DisplayUserInfo();
        }

        public frmMain(string connectionString)
        {
            InitializeComponent();
            _connectionString = connectionString;
            ConfigureFormInitialState();
        }


        private void ConfigureFormInitialState()
        {
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            this.Size = new Size(1200, 670);
            this.StartPosition = FormStartPosition.CenterScreen;

            SalesTimer.Interval = 10;

            // Đóng tất cả menu con khi khởi động
            pnlSaleSubMenu.Height = 0;
            pnlInventorySubMenu.Height = 0;
            pnlPartnerSubMenu.Height = 0;
            pnlSystemSubMenu.Height = 0;
        }

        private void DisplayUserInfo()
        {
            try
            {
                if (CurrentUser != null)
                {
                    lblTitleChildForm.Text = $"Xin chào {CurrentUser.FullName}";
                    if (iconCurrentChildForm != null)
                        iconCurrentChildForm.IconChar = IconChar.User;
                }
            }
            catch { /* Bỏ qua nếu các control giao diện chưa load kịp */ }
        }

        // --- LOGIC GIAO DIỆN (DRAG FORM, ANIMATION) ---

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void pnlTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                this.SuspendLayout();
                DisableButton();
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = RGBColors.color2;
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;

                if (iconCurrentChildForm != null)
                {
                    iconCurrentChildForm.IconChar = currentBtn.IconChar;
                    iconCurrentChildForm.IconColor = RGBColors.color3;
                }
                this.ResumeLayout();
            }
        }

        private void DisableButton()
        {
            if (currentBtn != null)
            {
                if (currentBtn.Parent != pnlMenu)
                    currentBtn.BackColor = RGBColors.color4;
                else
                    currentBtn.BackColor = Color.Transparent;

                currentBtn.ForeColor = RGBColors.color1;
                currentBtn.IconColor = RGBColors.color1;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            }
        }

        private void ToggleMenu(Panel panel)
        {
            if (panel.Height <= 0) isMenuExpanded = false;
            else isMenuExpanded = true;

            if (currentChildPanel != null && currentChildPanel != panel)
                previousPanel = currentChildPanel;
            else
                previousPanel = null;

            panelToAnimate = panel;
            SalesTimer.Start();
        }

        private void OpenChildForm(Form childForm)
        {
            if (currentChildForm != null) currentChildForm.Close();
            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnlDesktop.Controls.Add(childForm);
            pnlDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitleChildForm.Text = childForm.Text;
        }

        // --- CÁC SỰ KIỆN CLICK NÚT ---

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            HideSubMenu();
            OpenChildForm(new frmDashboard());

        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            ToggleMenu(pnlSaleSubMenu);
        }

        private void btnPOS_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            IProductRepository prodRepo = new ProductRepository(_connectionString);
            IOrderRepository orderRepo = new OrderRepository(_connectionString);
            ICustomerRepository custRepo = new CustomerRepository(_connectionString);
            IRepository<Category> catRepo = new CategoryRepository(_connectionString);

            POSService posService = new POSService(prodRepo, orderRepo, catRepo, custRepo);
            CustomerService custService = new CustomerService(custRepo);
            OpenChildForm(new frmPOS(posService, custService));
        }

        private void btnOrderList_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            IOrderRepository orderRepo = new OrderRepository(_connectionString);
            OrderService service = new OrderService(orderRepo);
            OpenChildForm(new frmOrderHistory(service));
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            ToggleMenu(pnlInventorySubMenu);
        }

        private void btnStockIn_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            IInventoryRepository inventoryRepo = new InventoryRepository(_connectionString);
            IProductRepository productRepo = new ProductRepository(_connectionString);
            InventoryService service = new InventoryService(inventoryRepo, productRepo);
            OpenChildForm(new frmStockIn(service));
        }

        private void btnStockOut_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            IInventoryRepository inventoryRepo = new InventoryRepository(_connectionString);
            IProductRepository productRepo = new ProductRepository(_connectionString);
            InventoryService service = new InventoryService(inventoryRepo, productRepo);

            int currentUserId = CurrentUser != null ? CurrentUser.UserId : 1;
            OpenChildForm(new frmStockOut(service, currentUserId));
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            IProductRepository repo = new ProductRepository(_connectionString);
            ProductService service = new ProductService(repo);
            OpenChildForm(new frmProductList(service));
        }

        private void btnPartners_Click(object sender, EventArgs e)
        {
            ToggleMenu(pnlPartnerSubMenu);
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            ICustomerRepository repo = new CustomerRepository(_connectionString);
            CustomerService service = new CustomerService(repo);
            OpenChildForm(new frmCustomer(service));
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            ISupplierRepository repo = new SupplierRepository(_connectionString);
            SupplierService service = new SupplierService(repo);
            OpenChildForm(new frmSupplier(service));
        }

        private void btnService_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            HideSubMenu();

            // 1. Kiểm tra xem service đã được khởi tạo chưa (tránh lỗi NullReference)
            if (_ticketService != null)
            {
                // 2. Khởi tạo Form kỹ thuật và truyền Service vào qua Constructor của nó
                // Lưu ý: Đảm bảo tên form của bạn là frmServiceTicket (hoặc đổi lại cho đúng)
                frmServiceTicket techForm = new frmServiceTicket(_ticketService);

                // 3. Mở form con lên panel chính
                OpenChildForm(techForm);
            }
            else
            {
                MessageBox.Show("Dịch vụ Kỹ thuật chưa được khởi tạo!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSystem_Click(object sender, EventArgs e)
        {
            ToggleMenu(pnlSystemSubMenu);
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            UserRepository repo = new UserRepository(_connectionString);
            StaffService service = new StaffService(repo);
            OpenChildForm(new frmStaff(service));
        }

        private void btnStats_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            IReportRepository repo = new ReportRepository(_connectionString);
            ReportService service = new ReportService(repo);
            OpenChildForm(new frmRevenueReport(service));
        }

        // --- HỆ THỐNG TIMER VÀ ĐÓNG MỞ WINDOWS ---

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTimeDate.Text = DateTime.Now.ToString("HH:mm:ss");
            lblDateFull.Text = DateTime.Now.ToString("dddd, MMMM dd, yyyy");
        }

        private void SalesTimer_Tick(object sender, EventArgs e)
        {
            int step = 15;
            if (previousPanel != null && previousPanel.Height > 0)
            {
                previousPanel.Height -= step;
                if (previousPanel.Height <= 0)
                {
                    previousPanel.Height = 0;
                    previousPanel = null;
                }
                return;
            }

            if (panelToAnimate != null)
            {
                if (!isMenuExpanded)
                {
                    panelToAnimate.Height += step;
                    if (panelToAnimate.Height >= panelToAnimate.MaximumSize.Height)
                    {
                        panelToAnimate.Height = panelToAnimate.MaximumSize.Height;
                        currentChildPanel = panelToAnimate;
                        SalesTimer.Stop();
                    }
                }
                else
                {
                    panelToAnimate.Height -= step;
                    if (panelToAnimate.Height <= 0)
                    {
                        panelToAnimate.Height = 0;
                        if (currentChildPanel == panelToAnimate) currentChildPanel = null;
                        SalesTimer.Stop();
                    }
                }
            }
            else SalesTimer.Stop();
        }

        private void HideSubMenu()
        {
            if (currentChildPanel != null)
            {
                previousPanel = currentChildPanel;
                panelToAnimate = null;
                currentChildPanel = null;
                SalesTimer.Start();
            }
        }

        private void btnCloseMain_Click(object sender, EventArgs e) => Application.Exit();

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            this.WindowState = WindowState == FormWindowState.Normal ? FormWindowState.Maximized : FormWindowState.Normal;
        }

        private void btnMinimize_Click(object sender, EventArgs e) => this.WindowState = FormWindowState.Minimized;

        private void btnLogoCoolMaster_Click(object sender, EventArgs e)
        {
            DisableButton();
            HideSubMenu();
            lblTitleChildForm.Text = "Chào mừng";
            iconCurrentChildForm.IconChar = IconChar.Snowflake;
            currentBtn = null;
            if (currentChildForm != null) { currentChildForm.Close(); currentChildForm = null; }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            
            OpenChildForm(new frmSettings(this.CurrentUser));
        }
    }
}