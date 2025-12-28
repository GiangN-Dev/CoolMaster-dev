using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoolMaster.Common;

namespace CoolMaster.DTOs
{
    public class OrderHistoryDTO
    {
        public int OrderId { get; set; }

        // Tạo mã đơn hàng hiển thị (VD: #1005)
        public string OrderCode
        {
            get
            {
                // Nếu có CreatedAt thì dùng, không thì dùng ngày hiện tại (demo)
                // Nhưng DTO này thường được map từ SQL nên CreatedAt sẽ có giá trị
                string datePart = CreatedAt.ToString("yyMMdd");
                return $"HD{datePart}-{OrderId:D4}";
            }
        }

        public DateTime CreatedAt { get; set; }
        public string CustomerName { get; set; }
        public string StaffName { get; set; } // Tên nhân viên bán
        public decimal TotalAmount { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public PaymentMethod PaymentMethod { get; set; }

        // Hiển thị trạng thái thanh toán dạng chữ
        public string PaymentStatusText => PaymentMethod == PaymentMethod.Cash ? "Tiền mặt" :
                                           PaymentMethod == PaymentMethod.BankTransfer ? "Chuyển khoản" : "Thẻ";

        // Hiển thị trạng thái đơn hàng dạng chữ
        public string OrderStatusText => OrderStatus == OrderStatus.Completed ? "Hoàn thành" :
                                         OrderStatus == OrderStatus.Cancelled ? "Đã hủy" : "Chờ xử lý";
    }
}
