using CoolMaster.DTOs;
using CoolMaster.Model;
using CoolMaster.Services;
using CoolMaster.Forms.Sales; // <-- add this to reuse frmAddCustomer
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoolMaster.Utils;

namespace CoolMaster.Forms.Suppliers
{
    public partial class frmCustomer : Form
    {
        private readonly CustomerService _customerService;
        private int _currentPage = 1;
        private int _pageSize = 20;
        private int _totalPages = 0;

        // sorter
        private DataGridViewSorter<CustomerDTO> _gridSorter;

        public frmCustomer(CustomerService service)
        {
            InitializeComponent();
            _customerService = service;
            InitializeGridConfig();
        }

        private void InitializeGridConfig()
        {
            dgvCustomers.AutoGenerateColumns = false;

            // Map cột
            colId.DataPropertyName = "CustomerId";
            colName.DataPropertyName = "FullName";
            colPhone.DataPropertyName = "PhoneNumber";
            colAddress.DataPropertyName = "Address";
            colDate.DataPropertyName = "CreatedAt";
            colDate.DefaultCellStyle.Format = "dd/MM/yyyy";

            // Create sorter
            _gridSorter = new DataGridViewSorter<CustomerDTO>(dgvCustomers);

            // Events
            this.Load += async (s, e) => await LoadData();
            txtSearch.TextChanged += async (s, e) => { _currentPage = 1; await LoadData(); };
            btnNext.Click += async (s, e) => { if (_currentPage < _totalPages) { _currentPage++; await LoadData(); } };
            btnPrev.Click += async (s, e) => { if (_currentPage > 1) { _currentPage--; await LoadData(); } };

            // CRUD Events
            btnAdd.Click += btnAdd_Click;
            btnDelete.Click += btnDelete_Click;
            btnEdit.Click += btnEdit_Click;
        }

        private async Task LoadData()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                var result = await _customerService.GetList(txtSearch.Text.Trim(), _currentPage, _pageSize);

                // Use sorter
                _gridSorter.UpdateItems(result.Items?.ToList() ?? new List<CustomerDTO>());

                _totalPages = result.TotalPages;
                lblPageInfo.Text = $"Trang {_currentPage}/{_totalPages} (Tổng: {result.TotalCount})";

                btnPrev.Enabled = _currentPage > 1;
                btnNext.Enabled = _currentPage < _totalPages;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            // Mở frmAddCustomer (giao diện đẹp hơn, form đã xử lý lưu)
            using (var frm = new frmAddCustomer(_customerService))
            {
                frm.StartPosition = FormStartPosition.CenterParent;
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    // frm đã lưu customer, chỉ cần reload danh sách
                    await LoadData();
                }
            }
        }

        private bool _isProcessing = false;

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            // Chặn nếu đang xử lý
            if (_isProcessing) return;
            _isProcessing = true;

            try
            {
                if (dgvCustomers.CurrentRow == null) return;
                var item = (CustomerDTO)dgvCustomers.CurrentRow.DataBoundItem;

                if (MessageBox.Show($"Xóa khách hàng {item.FullName}?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    await _customerService.DeleteCustomer(item.CustomerId);
                    await LoadData();
                }
            }
            finally
            {
                // Giải phóng sau khi xong
                _isProcessing = false;
            }
        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.CurrentRow == null) return;
            var item = dgvCustomers.CurrentRow.DataBoundItem as CustomerDTO;
            if (item == null) return;

            try
            {
                // Lấy entity từ DB để có đủ trường và state để Update
                var entity = await _customerService.GetById(item.CustomerId);
                if (entity == null)
                {
                    MessageBox.Show("Không tìm thấy khách hàng để sửa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Mở frmAddCustomer ở chế độ Edit bằng constructor mới
                using (var frm = new frmAddCustomer(_customerService, entity))
                {
                    frm.StartPosition = FormStartPosition.CenterParent;
                    if (frm.ShowDialog(this) == DialogResult.OK)
                    {
                        // frm đã cập nhật customer, chỉ cần reload danh sách
                        await LoadData();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
