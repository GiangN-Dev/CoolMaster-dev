using CoolMaster.Common;
using CoolMaster.Data.Repositories;
using CoolMaster.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolMaster.Services
{
    public class OrderService
    {
        private readonly IOrderRepository _orderRepo;

        public OrderService(IOrderRepository orderRepo)
        {
            _orderRepo = orderRepo;
        }

        public async Task<PagedResult<OrderHistoryDTO>> GetOrderHistory(string keyword, DateTime fromDate, DateTime toDate, int pageIndex, int pageSize)
        {
            // Logic: Chuẩn hóa ngày tháng
            // Từ ngày: Lấy 00:00:00
            var start = fromDate.Date;

            // Đến ngày: Lấy 23:59:59 của ngày đó để bao gồm cả các đơn cuối ngày
            var end = toDate.Date.AddDays(1).AddTicks(-1);

            if (pageIndex < 1) pageIndex = 1;

            return await _orderRepo.GetPagedHistoryAsync(keyword.Trim(), start, end, pageIndex, pageSize);
        }

        public async Task<BillViewModel> GetBillDetail(int orderId)
        {
            var bill = await _orderRepo.GetBillDetailAsync(orderId);
            if (bill == null) throw new Exception("Không tìm thấy hóa đơn.");

            // Convert Enum PaymentMethod sang string hiển thị nếu cần (hoặc làm ở Repository)
            // Ở đây Repository Dapper map thẳng int sang string nếu trùng tên, 
            // nhưng tốt nhất nên xử lý hiển thị ở đây.

            return bill;
        }

    }
}
