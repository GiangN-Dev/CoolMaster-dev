using CoolMaster.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoolMaster.Forms.Sales
{
    public partial class frmBill : Form
    {
        private readonly OrderService _orderService;
        private readonly int _orderId;

        // Constructor mặc định cho Designer (tránh lỗi)
        public frmBill()
        {
            InitializeComponent();
        }

        public frmBill(OrderService service, int orderId) : this()
        {
            _orderService = service;
            _orderId = orderId;

            InitializeGrid();
            this.Load += async (s, e) => await LoadData();
            dgvItems.ClearSelection();
        }

        private void InitializeGrid()
        {
            dgvItems.AutoGenerateColumns = false;
            dgvItems.Columns.Clear();

            // Tên SP
            dgvItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Sản phẩm",
                DataPropertyName = "ProductName",
                Width = 160
            });

            // SL
            dgvItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "SL",
                DataPropertyName = "Quantity",
                Width = 40,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            // Đơn giá
            dgvItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Đơn giá",
                DataPropertyName = "SalePrice",
                Width = 80,
                DefaultCellStyle = { Format = "N0", Alignment = DataGridViewContentAlignment.MiddleRight }
            });

            // Thành tiền
            dgvItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "T.Tiền",
                DataPropertyName = "Total",
                Width = 90,
                DefaultCellStyle = { Format = "N0", Alignment = DataGridViewContentAlignment.MiddleRight }
            });
        }

        private async Task LoadData()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                var bill = await _orderService.GetBillDetail(_orderId);

                lblOrderId.Text = $"Số phiếu: {bill.OrderCode}";
                lblDate.Text = $"Ngày: {bill.CreatedAt:dd/MM/yyyy HH:mm}";

                lblCustomer.Text = $"Khách hàng: {bill.CustomerName ?? "Khách lẻ"}";
                lblAddress.Text = $"Địa chỉ: {bill.Address ?? "-"}";

                lblStaff.Text = $"Thu ngân: {bill.StaffName} | TT: {bill.PaymentMethodText}";

                if (bill.OrderStatus == (int)CoolMaster.Common.OrderStatus.Cancelled)
                {
                    lblTitle.Text = "HÓA ĐƠN ĐÃ HỦY"; 
                    lblTitle.ForeColor = Color.Red;
                }

                dgvItems.DataSource = bill.Items;
                lblTotalAmount.Text = $"{bill.TotalAmount:N0} đ";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải hóa đơn: " + ex.Message);
                this.Close();
            }
            finally { Cursor = Cursors.Default; }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Không tìm thấy máy in...", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
