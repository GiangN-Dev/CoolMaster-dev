using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CoolMaster.DTOs;
using CoolMaster.Repositories;

namespace CoolMaster.Services
{
    // Tạo Interface ngay trong file này cho gọn (hoặc tách ra nếu muốn chuẩn 100%)
    public interface IServiceTicketService
    {
        Task<List<ServiceTicketDTO>> GetAllTicketsAsync();
        Task CreateTicketAsync(ServiceTicketDTO ticket);
        Task UpdateTicketAsync(ServiceTicketDTO ticket);
        Task DeleteTicketAsync(int id);
    }

    public class ServiceTicketService : IServiceTicketService
    {
        private readonly IServiceTicketRepository _repo;

        // Constructor Injection (Điểm mấu chốt của DI)
        public ServiceTicketService(IServiceTicketRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<ServiceTicketDTO>> GetAllTicketsAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task CreateTicketAsync(ServiceTicketDTO ticket)
        {
            // Logic kiểm tra nghiệp vụ
            if (string.IsNullOrEmpty(ticket.CustomerName))
                throw new Exception("Tên khách hàng không được để trống!");

            if (string.IsNullOrEmpty(ticket.DeviceName))
                throw new Exception("Phải nhập tên thiết bị cần sửa!");

            ticket.Status = "Tiếp nhận"; // Mặc định trạng thái đầu
            await _repo.AddAsync(ticket);
        }

        public async Task UpdateTicketAsync(ServiceTicketDTO ticket)
        {
            // Có thể thêm logic: Nếu trạng thái là "Đã xong" thì không cho sửa nữa...
            await _repo.UpdateAsync(ticket);
        }

        public async Task DeleteTicketAsync(int id)
        {
            var ticket = await _repo.GetByIdAsync(id);
            if (ticket != null && ticket.Status == "Đang sửa")
            {
                throw new Exception("Không thể xóa phiếu đang sửa chữa!");
            }
            await _repo.DeleteAsync(id);
        }
    }
}