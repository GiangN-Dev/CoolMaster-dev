using CoolMaster.Common;
using CoolMaster.DTOs;
using CoolMaster.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolMaster.Data.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        // Hàm xử lý transaction thanh toán
        Task<int> CreateOrderTransactionAsync(Order order, List<OrderDetail> details, int userId);
        Task<PagedResult<OrderHistoryDTO>> GetPagedHistoryAsync(string keyword, DateTime? fromDate, DateTime? toDate, int pageIndex, int pageSize);
        Task<BillViewModel> GetBillDetailAsync(int orderId);
    }
}
