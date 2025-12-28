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
        public interface ISupplierRepository : IRepository<Supplier>
        {
            // Hàm lấy danh sách phân trang & tìm kiếm
            Task<PagedResult<SupplierViewDTO>> GetPagedViewsAsync(string keyword, int pageIndex, int pageSize);
        }
    }
