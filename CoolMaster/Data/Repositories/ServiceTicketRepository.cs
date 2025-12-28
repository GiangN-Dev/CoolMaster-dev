using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoolMaster.DTOs;

namespace CoolMaster.Repositories
{
    public class ServiceTicketRepository : IServiceTicketRepository
    {
        // Allow construction with or without a connection string.
        private readonly string _connectionString;

        public ServiceTicketRepository()
        {
            // default - in-memory mode (used by tests or simple run)
            _connectionString = null;
        }

        public ServiceTicketRepository(string connectionString)
        {
            // store connection string for future DB implementation
            _connectionString = connectionString;
            // currently ignored because repository uses in-memory data
        }

        // Database giả lập (để test logic)
        private static List<ServiceTicketDTO> _data = new List<ServiceTicketDTO>()
        {
            new ServiceTicketDTO { Id = 1, CustomerName = "Nguyễn Văn Test", DeviceName = "Máy lạnh", Status = "Mới", CreatedDate = DateTime.Now }
        };

        public async Task<List<ServiceTicketDTO>> GetAllAsync()
        {
            await Task.Delay(100); // Giả lập độ trễ mạng
            return _data.OrderByDescending(x => x.CreatedDate).ToList();
        }

        public async Task AddAsync(ServiceTicketDTO ticket)
        {
            await Task.Delay(100);
            // Tự động tăng ID
            ticket.Id = _data.Any() ? _data.Max(x => x.Id) + 1 : 1;
            ticket.CreatedDate = DateTime.Now;
            _data.Add(ticket);
        }

        public async Task UpdateAsync(ServiceTicketDTO ticket)
        {
            await Task.Delay(100);
            var item = _data.FirstOrDefault(x => x.Id == ticket.Id);
            if (item != null)
            {
                item.CustomerName = ticket.CustomerName;
                item.DeviceName = ticket.DeviceName;
                item.Status = ticket.Status;
                item.IssueDescription = ticket.IssueDescription;
            }
        }

        public async Task DeleteAsync(int id)
        {
            await Task.Delay(100);
            var item = _data.FirstOrDefault(x => x.Id == id);
            if (item != null) _data.Remove(item);
        }

        public async Task<ServiceTicketDTO> GetByIdAsync(int id)
        {
            await Task.Delay(50);
            return _data.FirstOrDefault(x => x.Id == id);
        }
    }
}