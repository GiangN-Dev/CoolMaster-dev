using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoolMaster.DTOs;
using CoolMaster.Model;
using CoolMaster.Common;

namespace CoolMaster.Data.Repositories
{
    public interface IInventoryRepository : IRepository<InventoryLog>
    {
        // Lấy danh sách tồn kho (View)
        Task<PagedResult<InventoryViewDTO>> GetInventoryStatusAsync(string keyword, int? categoryId, int pageIndex, int pageSize);

        // Hàm quan trọng: Cập nhật kho và Ghi log trong cùng 1 Transaction
        // return: true nếu thành công
        Task<bool> ProcessStockTransactionAsync(InventoryLog log, int newStockWarehouse, int newStockCounter);
    }
}
