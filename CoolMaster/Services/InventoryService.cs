using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoolMaster.Common;
using CoolMaster.Data.Repositories;
using CoolMaster.DTOs;
using CoolMaster.Model;

namespace CoolMaster.Services
{
    public class InventoryService
    {
        private readonly IInventoryRepository _inventoryRepo;
        private readonly IRepository<Product> _productRepo; // Để lấy thông tin gốc trước khi tính toán

        public InventoryService(IInventoryRepository inventoryRepo, IRepository<Product> productRepo)
        {
            _inventoryRepo = inventoryRepo;
            _productRepo = productRepo;
        }

        public async Task<PagedResult<InventoryViewDTO>> GetInventoryList(string keyword, int? catId, int page, int size)
        {
            if (page < 1) page = 1;
            return await _inventoryRepo.GetInventoryStatusAsync(keyword, catId, page, size);
        }

        // Nghiệp vụ 1: Nhập hàng từ Nhà cung cấp vào Kho
        // NOTE: supplierId cho phép null (nhiều trường hợp có thể không muốn gán supplier)
        public async Task ImportToWarehouse(int productId, int quantity, int? supplierId, string note, int userId)
        {
            if (quantity <= 0) throw new ArgumentException("Số lượng nhập phải lớn hơn 0.");

            var product = await _productRepo.GetByIdAsync(productId);
            if (product == null) throw new Exception("Sản phẩm không tồn tại.");

            int oldTotalStock = product.StockWarehouse + product.StockCounter; // Ghi nhận tổng tồn trước khi thay đổi

            // Logic Domain: Gọi method của Model để tính toán
            product.ImportToWarehouse(quantity);

            // Chuẩn bị Log
            var log = new InventoryLog
            {
                ProductId = productId,
                SupplierId = supplierId,
                QuantityChange = quantity,
                StockBefore = oldTotalStock,
                StockAfter = product.StockWarehouse + product.StockCounter, // Tổng tồn mới
                ChangeType = CoolMaster.Common.InventoryChangeType.Import, // Đã sửa để dùng enum từ Common
                Note = note,
                CreatedByUserId = userId,
                ReferenceId = $"IMP-{DateTime.Now:yyyyMMddHHmm}"
            };

            // Thực thi Transaction
            await _inventoryRepo.ProcessStockTransactionAsync(log, product.StockWarehouse, product.StockCounter);
        }

        // Nghiệp vụ 2: Chuyển hàng từ Kho ra Quầy
        public async Task TransferToCounter(int productId, int quantity, string note, int userId)
        {
            if (quantity <= 0) throw new ArgumentException("Số lượng chuyển phải lớn hơn 0.");

            var product = await _productRepo.GetByIdAsync(productId);
            if (product == null) throw new Exception("Sản phẩm không tồn tại.");

            if (product.StockWarehouse < quantity)
                throw new Exception($"Kho chỉ còn {product.StockWarehouse}, không đủ để chuyển {quantity}.");

            int oldTotalStock = product.StockWarehouse + product.StockCounter; // Tổng tồn trước (không đổi)

            // Logic Domain
            product.TransferToCounter(quantity);

            var log = new InventoryLog
            {
                ProductId = productId,
                QuantityChange = quantity, // Số lượng chuyển
                StockBefore = oldTotalStock,
                StockAfter = oldTotalStock, // Tổng tồn không đổi, chỉ thay đổi vị trí
                ChangeType = CoolMaster.Common.InventoryChangeType.TransferToCounter, // Đã sửa để dùng enum từ Common
                Note = note,
                CreatedByUserId = userId,
                ReferenceId = $"TRF-{DateTime.Now:yyyyMMddHHmm}"
            };

            await _inventoryRepo.ProcessStockTransactionAsync(log, product.StockWarehouse, product.StockCounter);
        }
    }
}
