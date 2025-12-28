using CoolMaster.Common;
using CoolMaster.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolMaster.Data.Repositories
{
    public interface IReportRepository
    {
        // Thống kê doanh thu (Ngày/Tháng)
        Task<PagedResult<RevenueReportDTO>> GetRevenueReportAsync(DateTime fromDate, DateTime toDate, bool byMonth, int page, int size);

        // Thống kê sản phẩm
        Task<PagedResult<ProductPerformanceDTO>> GetProductPerformanceAsync(DateTime fromDate, DateTime toDate, string keyword, bool orderByRevenue, int page, int size);

        // Lấy tổng số liệu nhanh để hiển thị lên Cards
        Task<Tuple<decimal, int>> GetSummaryAsync(DateTime fromDate, DateTime toDate);
    }
}
