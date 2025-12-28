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
    public class SupplierService
    {
        private readonly ISupplierRepository _supplierRepo;

        public SupplierService(ISupplierRepository supplierRepo)
        {
            _supplierRepo = supplierRepo;
        }

        public async Task<PagedResult<SupplierViewDTO>> GetList(string keyword, int pageIndex, int pageSize)
        {
            if (pageIndex < 1) pageIndex = 1;
            return await _supplierRepo.GetPagedViewsAsync(keyword?.Trim(), pageIndex, pageSize);
        }

        public async Task CreateSupplier(Supplier supplier)
        {
            // Validate
            if (string.IsNullOrWhiteSpace(supplier.SupplierName))
                throw new Exception("Tên nhà cung cấp không được để trống.");

            if (string.IsNullOrWhiteSpace(supplier.Phone))
                throw new Exception("Số điện thoại không được để trống.");

            supplier.CreatedAt = DateTime.Now;
            supplier.IsDeleted = false;

            await _supplierRepo.AddAsync(supplier);
        }

        public async Task UpdateSupplier(Supplier supplier)
        {
            if (supplier.SupplierId <= 0) throw new Exception("Nhà cung cấp không hợp lệ.");
            if (string.IsNullOrWhiteSpace(supplier.SupplierName)) throw new Exception("Tên không được để trống.");

            supplier.UpdatedAt = DateTime.Now;
            await _supplierRepo.UpdateAsync(supplier);
        }

        public async Task DeleteSupplier(int id)
        {
            await _supplierRepo.DeleteAsync(id);
        }

        public async Task<Supplier> GetById(int id)
        {
            return await _supplierRepo.GetByIdAsync(id);
        }
    }
}
