using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;

namespace CoolMaster.Common
{
    public partial class UCPagination : UserControl
    {
        public event EventHandler<PageChangedEventArgs> OnPageChanged;

        private int _totalRecords;
        public int CurrentPage { get; private set; } = 1;
        public int PageSize { get; private set; } = 20; // Mặc định
        public int TotalPages { get; private set; } = 0;
        public UCPagination()
        {
            InitializeComponent();
            btnPrev.Click += (s, e) => ChangePage(-1);
            btnNext.Click += (s, e) => ChangePage(1);
        }

        // Hàm quan trọng: Tự động tính số dòng dựa trên chiều cao DataGridView
        public void CalculatePageSize(DataGridView dgv)
        {
            try
            {
                if (dgv.Height <= 0 || dgv.RowTemplate.Height <= 0) return;

                // Chiều cao khả dụng = Chiều cao bảng - Chiều cao Header
                int availableHeight = dgv.Height - dgv.ColumnHeadersHeight;

                // Tính số dòng
                int calculatedSize = availableHeight / dgv.RowTemplate.Height;

                // Trừ hao 1 dòng để không bị thanh cuộn che mất dòng cuối
                calculatedSize = calculatedSize > 1 ? calculatedSize - 1 : 1;

                // Nếu số dòng thay đổi đáng kể thì mới cập nhật và load lại
                if (this.PageSize != calculatedSize)
                {
                    this.PageSize = calculatedSize;
                    // Reset về trang 1 khi thay đổi kích thước màn hình
                    this.CurrentPage = 1;
                    TriggerLoadData();
                }
            }
            catch { }
        }

        public void UpdateState(int totalRecords)
        {
            _totalRecords = totalRecords;
            TotalPages = (int)Math.Ceiling((double)_totalRecords / PageSize);

            if (TotalPages == 0) TotalPages = 1;
            if (CurrentPage > TotalPages) CurrentPage = TotalPages;

            lblPageInfo.Text = $"Trang {CurrentPage} / {TotalPages} (Tổng: {_totalRecords})";

            btnPrev.Enabled = CurrentPage > 1;
            btnNext.Enabled = CurrentPage < TotalPages;
        }

        private void ChangePage(int delta)
        {
            CurrentPage += delta;
            TriggerLoadData();
        }

        private void TriggerLoadData()
        {
            OnPageChanged?.Invoke(this, new PageChangedEventArgs(CurrentPage, PageSize));
        }

        public void ResetToFirstPage()
        {
            CurrentPage = 1;
            // Không tự gọi LoadData ở đây để tránh gọi 2 lần nếu form cha chủ động gọi
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {

        }

        private void btnNext_Click(object sender, EventArgs e)
        {

        }
    }


    public class PageChangedEventArgs : EventArgs
    {
        public int PageIndex { get; }
        public int PageSize { get; }
        public PageChangedEventArgs(int index, int size)
        {
            PageIndex = index;
            PageSize = size;
        }
    }
}
