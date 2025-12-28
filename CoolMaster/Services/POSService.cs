using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoolMaster.Common;
using CoolMaster.Data.Repositories;
using CoolMaster.DTOs;
using CoolMaster.Model;

namespace CoolMaster.Services
{
    public class POSService
    {
        private readonly IProductRepository _productRepo;
        private readonly IOrderRepository _orderRepo;
        private readonly IRepository<Category> _categoryRepo;
        private readonly IRepository<Customer> _customerRepo;

        public POSService(IProductRepository productRepo, IOrderRepository orderRepo, IRepository<Category> cateRepo, IRepository<Customer> custRepo)
        {
            _productRepo = productRepo;
            _orderRepo = orderRepo;
            _categoryRepo = cateRepo;
            _customerRepo = custRepo;
        }

        // 1. Lấy danh sách sản phẩm hiển thị (Chỉ lấy hàng còn tồn ở quầy > 0 hoặc tất cả tùy logic)
        public async Task<List<POSProductDTO>> GetProductsForPOS(string keyword = "", int? categoryId = null)
        {
            var views = await _productRepo.GetAllViewsAsync();

            var query = views.AsQueryable();

            if (!string.IsNullOrEmpty(keyword))
                query = query.Where(p => p.ProductName.ToLower().Contains(keyword.ToLower()) || p.Barcode.Contains(keyword));

            if (categoryId.HasValue && categoryId.Value > 0)
                query = query.Where(p => p.CategoryName == ""); // Lưu ý: ViewDTO đang trả về CategoryName, cần sửa Repo nếu muốn filter theo ID chuẩn

            return query.Select(p => new POSProductDTO
            {
                ProductId = p.ProductId,
                Barcode = p.Barcode,
                ProductName = p.ProductName,
                UnitPrice = p.UnitPrice,
                StockCounter = p.StockCounter,
                Unit = p.Unit,
                ImageUrl = p.ImageUrl,
                CategoryName = p.CategoryName
            }).ToList();
        }

        public POSProductDTO GetProductByBarcode(string barcode)
        {
            // Tìm chính xác (dùng In-Memory list đã cache ở Form hoặc gọi Repo nếu cần)
            // Ở đây ta giả định Form đã cache list, Service chỉ hỗ trợ logic Checkout.
            return null;
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _categoryRepo.GetAllAsync();
        }

        public async Task<IEnumerable<Customer>> SearchCustomers(string keyword)
        {
            // Cần implement hàm tìm kiếm bên CustomerRepo, tạm thời lấy all
            var all = await _customerRepo.GetAllAsync();
            return all.Where(c => c.FullName.Contains(keyword) || c.PhoneNumber.Contains(keyword));
        }

        // 2. Xử lý Thanh toán
        public async Task<int> Checkout(CheckoutRequestDTO request, OrderStatus status, PaymentMethod method)
        {
            if (request.Items == null || !request.Items.Any())
                throw new Exception("Giỏ hàng trống.");

            var order = new Order
            {
                TotalAmount = request.TotalAmount,
                PaymentMethod = method, // Lấy từ ComboBox
                OrderStatus = status,   // Completed hoặc Cancelled
                Note = status == OrderStatus.Cancelled ? "Đơn bị khách hủy" : "Bán lẻ tại quầy",
                CustomerId = request.CustomerId,
                StaffId = request.StaffId,
                IsDeleted = false
            };

            var details = request.Items.Select(i => new OrderDetail
            {
                ProductId = i.ProductId,
                Quantity = i.Quantity,
                SalePrice = i.UnitPrice
            }).ToList();

            return await _orderRepo.CreateOrderTransactionAsync(order, details, request.StaffId);
        }
    }
}
