using System.Collections.Generic;
using System.Threading.Tasks;
using CoolMaster.DTOs;

namespace CoolMaster.Repositories
{
    public interface IServiceTicketRepository
    {
        Task<List<ServiceTicketDTO>> GetAllAsync();
        Task AddAsync(ServiceTicketDTO ticket);
        Task UpdateAsync(ServiceTicketDTO ticket);
        Task DeleteAsync(int id);
        Task<ServiceTicketDTO> GetByIdAsync(int id);
    }
}