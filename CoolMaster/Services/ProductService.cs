using CoolMaster.Common;
using CoolMaster.Data.Repositories;
using CoolMaster.DTOs;
using CoolMaster.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; // Dùng để validate model
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolMaster.Services
{
    public class ProductService
    {
        private readonly IProductRepository _productRepo;

        // Dependency Injection via Constructor
        public ProductService(IProductRepository productRepo)
        {
            _productRepo = productRepo;
        }

        public async Task CreateProduct(Product product)
        {
            // Validate Business Rules
            if (product.UnitPrice < 0) throw new Exception("Giá bán không được âm.");

            // Set Default Values
            product.CreatedAt = DateTime.Now;
            product.ProductName = product.ProductName?.Trim();
            product.IsDeleted = false;

            await _productRepo.AddAsync(product);
        }

        // Hàm lấy dữ liệu phân trang
        public async Task<PagedResult<ProductViewDTO>> GetProductList(string keyword, int pageIndex, int pageSize)
        {
            // Xử lý keyword null
            keyword = keyword?.Trim();

            // Mặc định pageIndex là 1 nếu truyền sai
            if (pageIndex < 1) pageIndex = 1;
            if (pageSize < 1) pageSize = 10;

            return await _productRepo.GetPagedViewsAsync(keyword, pageIndex, pageSize);
        }

        public async Task<List<string>> GetCategoryNames()
        {
            return await _productRepo.GetDistinctCategoriesAsync();
        }

        public async Task<List<string>> GetBrandNames()
        {
            return await _productRepo.GetDistinctBrandsAsync();
        }

        // Hàm tìm kiếm nâng cao
        public async Task<PagedResult<ProductViewDTO>> SearchProducts(ProductFilterRequest filter, int pageIndex = 1, int pageSize = 20)
        {
            // Có thể thêm logic validate filter ở đây nếu cần
            return await _productRepo.GetPagedAdvancedAsync(filter, pageIndex, pageSize);
        }

        /*
         khi update tồn kho sản phẩm, hãy đảm bảo rằng số lượng tồn kho không bao giờ âm.
         Nếu RowsAffected == 0 -> Báo lỗi "Hết hàng".
            UPDATE Products 
            SET StockQuantity = StockQuantity - @Quantity, UpdatedAt = GETDATE()
            WHERE ProductId = @Id AND StockQuantity >= @Quantity -- Chặn không cho âm kho 
         */
    }
}
