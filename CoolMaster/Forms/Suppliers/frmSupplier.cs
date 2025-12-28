using CoolMaster.DTOs;
using CoolMaster.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace CoolMaster.Forms.Suppliers
{
    public partial class frmSupplier : Form
    {
        private readonly SupplierService _service;
        private BindingSource _bindingSource = new BindingSource();
        private CancellationTokenSource _searchCts;

        private int _currentPage = 1;
        private int _pageSize = 20;
        private int _totalPages = 0;
        private string _currentKeyword = "";

        public frmSupplier(SupplierService service)
        {
            InitializeComponent(); // Gọi giao diện Designer mới
            _service = service;

            // Tắt chế độ tự sinh cột để dùng cột mình tự định nghĩa
            dgvSuppliers.AutoGenerateColumns = false;
            dgvSuppliers.AllowUserToAddRows = false;
            dgvSuppliers.DataSource = _bindingSource;
        }

        private async void frmSupplier_Load(object sender, EventArgs e)
        {
            await LoadData();
        }

        private async Task LoadData(string keyword = "", int pageIndex = 1)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                _currentKeyword = keyword;
                _currentPage = pageIndex;

                var result = await _service.GetList(keyword, pageIndex, _pageSize);

                // Quan trọng: Gán List vào BindingSource
                _bindingSource.DataSource = result.Items;
                _totalPages = result.TotalPages;

                dgvSuppliers.ClearSelection(); // Bỏ chọn bôi xanh dòng đầu
                dgvSuppliers.CurrentCell = null;

                // Update UI Paging
                int total = result.TotalCount;
                int start = total == 0 ? 0 : (_currentPage - 1) * _pageSize + 1;
                int end = Math.Min(_currentPage * _pageSize, total);
                lblPageInfo.Text = $"Hiển thị {start} - {end} trên {total}";

                btnPrev.Enabled = _currentPage > 1;
                btnNext.Enabled = _currentPage < _totalPages;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        // --- EVENTS ---

        private async void txtSearch_TextChanged(object sender, EventArgs e)
        {
            _searchCts?.Cancel();
            _searchCts = new CancellationTokenSource();
            try
            {
                await Task.Delay(300, _searchCts.Token);
                await LoadData(txtSearch.Text.Trim(), 1); // Reset về trang 1 khi tìm kiếm
            }
            catch (TaskCanceledException) { }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            using (var frm = new frmSupplierDetail(null))
            {
                // Sửa lỗi popup bị lệch: CenterParent
                frm.StartPosition = FormStartPosition.CenterParent;
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    try
                    {
                        await _service.CreateSupplier(frm.SupplierData);
                        MessageBox.Show("Thêm thành công!");
                        await LoadData(); // Refresh grid
                    }
                    catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
                }
            }
        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            var selectedRows = dgvSuppliers.SelectedRows;
            if (selectedRows.Count == 0) return;

            // Lấy DTO từ dòng được chọn (an toàn hơn dùng SelectedRows)
            var row = selectedRows[0];
            if (!(row.DataBoundItem is SupplierViewDTO dto)) return;

            try
            {
                var entity = await _service.GetById(dto.SupplierId);
                if (entity == null)
                {
                    MessageBox.Show("Không tìm thấy Nhà cung cấp để sửa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (var frm = new frmSupplierDetail(entity))
                {
                    // Center popup relative to parent to avoid misalignment
                    frm.StartPosition = FormStartPosition.CenterParent;
                    if (frm.ShowDialog(this) == DialogResult.OK)
                    {
                        await _service.UpdateSupplier(frm.SupplierData);
                        MessageBox.Show("Cập nhật thành công!");
                        await LoadData(_currentKeyword, _currentPage); // Giữ nguyên trang đang đứng
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            var selectedRows = dgvSuppliers.SelectedRows;
            if (selectedRows.Count == 0) return;

            if (MessageBox.Show($"Xóa {selectedRows.Count} dòng đã chọn?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    foreach (DataGridViewRow row in selectedRows)
                    {
                        // Lấy DTO từ DataBoundItem
                        if (row.DataBoundItem is SupplierViewDTO dto)
                        {
                            await _service.DeleteSupplier(dto.SupplierId);
                        }
                    }
                    await LoadData();
                    MessageBox.Show("Đã xóa thành công.");
                }
                catch (Exception ex) { MessageBox.Show("Lỗi xóa: " + ex.Message); }
            }
        }

        private async void btnPrev_Click(object sender, EventArgs e)
        {
            if (_currentPage > 1) await LoadData(_currentKeyword, _currentPage - 1);
        }

        private async void btnNext_Click(object sender, EventArgs e)
        {
            if (_currentPage < _totalPages) await LoadData(_currentKeyword, _currentPage + 1);
        }

      
    }
}
