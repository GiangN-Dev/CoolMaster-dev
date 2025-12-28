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
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task<PagedResult<CustomerDTO>> GetPagedListAsync(string keyword, int pageIndex, int pageSize);
    }
}
