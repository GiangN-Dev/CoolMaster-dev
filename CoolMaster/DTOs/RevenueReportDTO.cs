using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolMaster.DTOs
{
    public class RevenueReportDTO
    {
        public string TimeLabel { get; set; } // Ngày/Tháng
        public int OrderCount { get; set; }   // Số đơn
        public decimal TotalRevenue { get; set; } // Tổng tiền
    }

    // DTO cho thống kê hiệu suất sản phẩm (Bán chạy / Doanh thu cao)
    public class ProductPerformanceDTO
    {
        public int ProductId { get; set; }
        public string Barcode { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public int QuantitySold { get; set; }     // Số lượng bán
        public decimal RevenueGenerated { get; set; } // Doanh thu mang lại
    }

    // Enum loại báo cáo
    public enum ReportType
    {
        RevenueByDay = 0,       // Doanh thu theo ngày
        RevenueByMonth = 1,     // Doanh thu theo tháng
        TopSellingQuantity = 2, // Sản phẩm bán chạy (theo SL)
        TopSellingRevenue = 3   // Sản phẩm doanh thu cao nhất
    }
}
