using CoolMaster.DTOs;
using CoolMaster.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoolMaster.Common;

namespace CoolMaster.Data.Repositories
{
    // Interface này kế thừa các hàm chung, và định nghĩa thêm hàm riêng
    public interface IProductRepository : IRepository<Product>
    {
        Task<PagedResult<ProductViewDTO>> GetPagedViewsAsync(string keyword, int pageIndex, int pageSize);
        Task<List<string>> GetDistinctBrandsAsync();
        Task<List<string>> GetDistinctCategoriesAsync();
        Task<PagedResult<ProductViewDTO>> GetPagedAdvancedAsync(ProductFilterRequest filter, int pageIndex, int pageSize);
        Task<IEnumerable<ProductViewDTO>> GetAllViewsAsync();
    }
}
