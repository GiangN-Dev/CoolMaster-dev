using CoolMaster.Common;
using CoolMaster.Data.Repositories;
using CoolMaster.DTOs;
using CoolMaster.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolMaster.Services
{
    public class CustomerService
    {
        private readonly ICustomerRepository _customerRepo;

        public CustomerService(ICustomerRepository customerRepo)
        {
            _customerRepo = customerRepo;
        }

        public async Task<PagedResult<CustomerDTO>> GetList(string keyword, int page, int size)
        {
            return await _customerRepo.GetPagedListAsync(keyword, page, size);
        }

        public async Task AddCustomer(Customer customer)
        {
            // Validate
            if (string.IsNullOrWhiteSpace(customer.FullName)) throw new Exception("Tên không được để trống");
            if (string.IsNullOrWhiteSpace(customer.PhoneNumber)) throw new Exception("SĐT không được để trống");

            customer.CreatedAt = DateTime.Now;
            customer.IsDeleted = false;

            int newId = await _customerRepo.AddAsync(customer);
            customer.CustomerId = newId;
        }

        public async Task DeleteCustomer(int id)
        {
            // Logic xóa mềm
            var customer = await _customerRepo.GetByIdAsync(id);
            if (customer != null)
            {
                customer.IsDeleted = true;
                await _customerRepo.UpdateAsync(customer);
            }
        }

        // --- MỚI: hỗ trợ lấy và cập nhật khách hàng để phục vụ chức năng Sửa ---
        public async Task<Customer> GetById(int id)
        {
            return await _customerRepo.GetByIdAsync(id);
        }

        public async Task UpdateCustomer(Customer customer)
        {
            if (customer == null) throw new ArgumentNullException(nameof(customer));

            // Validate
            if (string.IsNullOrWhiteSpace(customer.FullName)) throw new Exception("Tên không được để trống");
            if (string.IsNullOrWhiteSpace(customer.PhoneNumber)) throw new Exception("SĐT không được để trống");

            await _customerRepo.UpdateAsync(customer);
        }
    }
}
