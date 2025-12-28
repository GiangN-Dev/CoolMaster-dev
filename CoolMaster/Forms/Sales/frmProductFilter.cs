using CoolMaster.DTOs;
using Guna.UI2.WinForms;
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
    public partial class frmProductFilter : Form
    {
        public ProductFilterRequest FilterResult { get; private set; }

        private List<string> _categories;
        private List<string> _brands;
        public frmProductFilter()
        {
            InitializeComponent();
        }

        public frmProductFilter(List<string> categories, List<string> brands) : this()
        {
            _categories = categories;
            _brands = brands;

            // Tạo bóng đổ cho form (Tùy chọn)
            Guna2ShadowForm shadow = new Guna2ShadowForm(this);

            LoadInitData();
        }

        // Hàm khởi tạo dữ liệu
        private void LoadInitData()
        {
            // 1. Load Categories
            cboCategory.Items.Clear();
            cboCategory.Items.Add("Tất cả");
            if (_categories != null) cboCategory.Items.AddRange(_categories.ToArray());
            cboCategory.StartIndex = 0;

            // 2. Load Brands
            cboBrand.Items.Clear();
            cboBrand.Items.Add("Tất cả");
            if (_brands != null) cboBrand.Items.AddRange(_brands.ToArray());
            cboBrand.StartIndex = 0;

            // 3. Load Stock Status
            cboStockStatus.Items.Clear();
            cboStockStatus.Items.AddRange(new object[] { "Tất cả", "Còn hàng", "Sắp hết", "Hết hàng" });
            cboStockStatus.StartIndex = 0;
        }

        // --- CÁC HÀM SỰ KIỆN (EVENT HANDLERS) ---

        // 1. Xử lý nút Áp dụng
        private void btnApply_Click(object sender, EventArgs e)
        {
            // Validate
            if (numPriceTo.Value > 0 && numPriceFrom.Value > numPriceTo.Value)
            {
                MessageBox.Show("Giá 'Đến' phải lớn hơn hoặc bằng giá 'Từ'.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Đóng gói dữ liệu
            FilterResult = new ProductFilterRequest
            {
                Keyword = txtKeyword.Text.Trim(),
                CategoryName = cboCategory.SelectedIndex > 0 ? cboCategory.SelectedItem.ToString() : null,
                Brand = cboBrand.SelectedIndex > 0 ? cboBrand.SelectedItem.ToString() : null,
                StockStatus = cboStockStatus.SelectedIndex > 0 ? cboStockStatus.SelectedItem.ToString() : null,
                PriceFrom = numPriceFrom.Value > 0 ? (decimal?)numPriceFrom.Value : null,
                PriceTo = numPriceTo.Value > 0 ? (decimal?)numPriceTo.Value : null
            };

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // 2. Xử lý nút Làm mới
        private void btnReset_Click(object sender, EventArgs e)
        {
            txtKeyword.Clear();
            cboCategory.StartIndex = 0;
            cboBrand.StartIndex = 0;
            cboStockStatus.StartIndex = 0;
            numPriceFrom.Value = 0;
            numPriceTo.Value = 0;
            txtKeyword.Focus();
        }

        // 3. Xử lý nút Đóng
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

    }
}
