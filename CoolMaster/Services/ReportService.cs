using CoolMaster.Data.Repositories;
using CoolMaster.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolMaster.Services
{
    public class ReportService
    {
        private readonly IReportRepository _repo;

        public ReportService(IReportRepository repo)
        {
            _repo = repo;
        }

        public async Task<object> GetReportData(ReportType type, DateTime from, DateTime to, string keyword, int page, int size)
        {
            // Xử lý ngày giờ: From lấy 00:00, To lấy 23:59:59
            var startDate = from.Date;
            var endDate = to.Date.AddDays(1).AddTicks(-1);

            switch (type)
            {
                case ReportType.RevenueByDay:
                    return await _repo.GetRevenueReportAsync(startDate, endDate, false, page, size);

                case ReportType.RevenueByMonth:
                    return await _repo.GetRevenueReportAsync(startDate, endDate, true, page, size);

                case ReportType.TopSellingQuantity:
                    return await _repo.GetProductPerformanceAsync(startDate, endDate, keyword, false, page, size);

                case ReportType.TopSellingRevenue:
                    return await _repo.GetProductPerformanceAsync(startDate, endDate, keyword, true, page, size);

                default:
                    throw new ArgumentException("Loại báo cáo không hợp lệ");
            }
        }

        public async Task<Tuple<decimal, int>> GetTotalSummary(DateTime from, DateTime to)
        {
            var startDate = from.Date;
            var endDate = to.Date.AddDays(1).AddTicks(-1);
            return await _repo.GetSummaryAsync(startDate, endDate);
        }
    }
}
