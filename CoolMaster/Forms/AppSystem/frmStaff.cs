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
using System.Windows.Forms;
using CoolMaster.DTOs;
using CoolMaster.Model;
using CoolMaster.Forms.AppSystem;

namespace CoolMaster.Forms.AppSystem
{
    public partial class frmStaff : Form
    {
        private readonly StaffService _service;
        private BindingSource _bindingSource = new BindingSource();
        private CancellationTokenSource _searchCts;

        private int _currentPage = 1;
        private int _pageSize = 20;
        private int _totalPages = 0;
        private string _currentKeyword = "";
        public frmStaff(StaffService service)
        {
            InitializeComponent();
            _service = service;

            // Setup DataGridView
            dgvStaff.AutoGenerateColumns = false;
            dgvStaff.DataSource = _bindingSource;
        }

        private async void frmStaff_Load(object sender, EventArgs e)
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

                _bindingSource.DataSource = result.Items;
                _totalPages = result.TotalPages;

                dgvStaff.ClearSelection();
                dgvStaff.CurrentCell = null;

                // Update Footer info
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

        // --- SEARCH (DEBOUNCE) ---
        private async void txtSearch_TextChanged(object sender, EventArgs e)
        {
            _searchCts?.Cancel();
            _searchCts = new CancellationTokenSource();
            try
            {
                await Task.Delay(300, _searchCts.Token);
                await LoadData(txtSearch.Text.Trim(), 1);
            }
            catch (TaskCanceledException) { }
        }

        // --- BUTTON EVENTS ---

        // 1. Thêm mới (Đăng ký)
        private async void btnAdd_Click(object sender, EventArgs e)
        {
            using (var frm = new frmStaffDetail(null))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    await _service.CreateStaff(frm.StaffData);
                    await LoadData();
                }
            }
        }

        // 2. Sửa
        private async void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvStaff.SelectedRows.Count == 0) return;

            if (_bindingSource.Current is UserViewDTO dto)
            {
                var entity = await _service.GetById(dto.UserId);

                using (var frm = new frmStaffDetail(entity))
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        await _service.UpdateStaff(frm.StaffData);
                        await LoadData(_currentKeyword, _currentPage);
                    }
                }

                MessageBox.Show($"Đang sửa nhân viên: {entity.FullName}");
            }
        }

        // 3. Xóa (Hỗ trợ chọn nhiều dòng)
        private async void btnDelete_Click(object sender, EventArgs e)
        {
            var selectedRows = dgvStaff.SelectedRows;
            if (selectedRows.Count == 0) return;

            if (MessageBox.Show($"Bạn có chắc muốn xóa {selectedRows.Count} nhân viên đã chọn?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    int successCount = 0;
                    foreach (DataGridViewRow row in selectedRows)
                    {
                        if (row.DataBoundItem is UserViewDTO dto)
                        {
                            await _service.DeleteStaff(dto.UserId);
                            successCount++;
                        }
                    }
                    await LoadData();
                    MessageBox.Show($"Đã xóa thành công {successCount} nhân viên.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa: " + ex.Message);
                }
            }
        }

        // --- PAGINATION ---
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
