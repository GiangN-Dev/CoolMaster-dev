using CoolMaster.DTOs;
using CoolMaster.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoolMaster.Data.Repositories;
using CoolMaster.Common;

namespace CoolMaster.Services
{
    public class StaffService
    {
        private readonly UserRepository _repo;

        public StaffService(UserRepository repo)
        {
            _repo = repo;
        }

        // Lấy danh sách (Service gọi Repo)
        public async Task<(IEnumerable<UserViewDTO> Items, int TotalCount, int TotalPages)> GetList(string keyword, int pageIndex, int pageSize)
        {
            var data = await _repo.GetUsersAsync(keyword ?? "", pageIndex, pageSize);
            int totalPages = (int)Math.Ceiling((double)data.TotalCount / pageSize);
            return (data.Items, data.TotalCount, totalPages);
        }

        public Task<User> GetById(int id) => _repo.GetByIdAsync(id);

        // --- LOGIC NGHIỆP VỤ NẰM Ở ĐÂY ---
        public Task CreateStaff(User user)
        {
            // 1. Validate dữ liệu
            if (string.IsNullOrWhiteSpace(user.StaffCode))
                throw new Exception("Mã nhân viên không được để trống.");

            // 2. Xử lý Logic: Hash mật khẩu trước khi lưu xuống DB
            // Nếu không nhập pass thì lấy mặc định, nếu nhập thì hash
            string rawPassword = string.IsNullOrEmpty(user.Password) ? "123456" : user.Password;
            user.Password = SecurityHelper.HashPassword(rawPassword);

            // 3. Gọi Repo để lưu
            return _repo.AddAsync(user);
        }

        public Task UpdateStaff(User user)
        {
            // Logic kiểm tra nếu cần (VD: Không được sửa Mã NV)
            return _repo.UpdateAsync(user);
        }

        public Task DeleteStaff(int id) => _repo.DeleteAsync(id);
    }
}
