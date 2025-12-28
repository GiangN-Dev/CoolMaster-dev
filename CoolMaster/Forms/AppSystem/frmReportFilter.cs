using CoolMaster.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoolMaster.Forms.AppSystem
{
    public partial class frmReportFilter : Form
    {
        public ReportFilterRequest FilterResult { get; private set; }

        public frmReportFilter()
        {
            InitializeComponent();

            // Set mặc định: Đầu tháng đến hiện tại
            dtpFrom.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpTo.Value = DateTime.Now;
        }

        public frmReportFilter(ReportFilterRequest currentFilter) : this()
        {
            if (currentFilter != null)
            {
                cboReportType.SelectedIndex = (int)currentFilter.ReportType;
                dtpFrom.Value = currentFilter.FromDate;
                dtpTo.Value = currentFilter.ToDate;
                txtKeyword.Text = currentFilter.Keyword;

                // Kích hoạt ô tìm kiếm nếu cần
                cboReportType_SelectedIndexChanged(null, null);
            }
        }

        private void cboReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Index 2 (TopSellingQuantity) và 3 (TopSellingRevenue) là báo cáo sản phẩm
            bool isProductReport = (cboReportType.SelectedIndex == 2 || cboReportType.SelectedIndex == 3);
            txtKeyword.Enabled = isProductReport;

            if (!isProductReport) txtKeyword.Clear();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (dtpFrom.Value > dtpTo.Value)
            {
                MessageBox.Show("Ngày bắt đầu không được lớn hơn ngày kết thúc.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            FilterResult = new ReportFilterRequest
            {
                ReportType = (ReportType)cboReportType.SelectedIndex,
                FromDate = dtpFrom.Value,
                ToDate = dtpTo.Value,
                Keyword = txtKeyword.Text.Trim()
            };

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            cboReportType.SelectedIndex = 0;
            dtpFrom.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpTo.Value = DateTime.Now;
            txtKeyword.Clear();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

    }
}
