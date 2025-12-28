using CoolMaster.Model;
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

namespace CoolMaster.Forms.Suppliers
{
    public partial class frmSupplierDetail : Form
    {
        // Property để form cha nhận dữ liệu
        public Supplier SupplierData { get; private set; }

        // 1. Constructor mặc định (Bắt buộc phải có để Designer chạy ổn định)
        public frmSupplierDetail()
        {
            InitializeComponent();
        }

        // 2. Constructor chính (Dùng để truyền dữ liệu)
        public frmSupplierDetail(Supplier existingSupplier) : this() // Gọi constructor mặc định trước để Init Component
        {
            if (existingSupplier != null)
            {
                // Mode Sửa
                SupplierData = existingSupplier;
                lblHeader.Text = "CẬP NHẬT NHÀ CUNG CẤP";

                // Đổ dữ liệu vào controls
                txtName.Text = existingSupplier.SupplierName;
                txtContact.Text = existingSupplier.ContactPerson;
                txtPhone.Text = existingSupplier.Phone;
                txtAddress.Text = existingSupplier.Address;
            }
            else
            {
                // Mode Thêm mới
                SupplierData = new Supplier();
                lblHeader.Text = "THÊM NHÀ CUNG CẤP MỚI";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validate dữ liệu
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên Nhà Cung Cấp.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Vui lòng nhập Số điện thoại.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhone.Focus();
                return;
            }

            // Gán dữ liệu từ TextBox vào Object
            SupplierData.SupplierName = txtName.Text.Trim();
            SupplierData.ContactPerson = txtContact.Text.Trim();
            SupplierData.Phone = txtPhone.Text.Trim();
            SupplierData.Address = txtAddress.Text.Trim();

            // Trả về kết quả OK để form cha biết là đã bấm Lưu
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}