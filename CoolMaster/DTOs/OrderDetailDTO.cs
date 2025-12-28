using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolMaster.DTOs
{
    public class OrderDetailDTO
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal SalePrice { get; set; }
        public decimal Total => Quantity * SalePrice;
        public string Unit { get; set; } // Đơn vị tính
    }

    // DTO chứa toàn bộ thông tin hóa đơn để in
    public class BillViewModel
    {
        public int OrderId { get; set; }
        public string OrderCode => $"#{OrderId:D4}";
        public System.DateTime CreatedAt { get; set; }

        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string StaffName { get; set; }
        public int PaymentMethod { get; set; } 
        public int OrderStatus { get; set; }   

        public string PaymentMethodText => PaymentMethod == 0 ? "Tiền mặt" : (PaymentMethod == 1 ? "Chuyển khoản" : "Thẻ");

        public System.Collections.Generic.List<OrderDetailDTO> Items { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
