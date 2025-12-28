using System;

namespace CoolMaster.DTOs
{
    public class ServiceTicketDTO
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }  // Tên khách hàng
        public string PhoneNumber { get; set; }   // Số điện thoại
        public string DeviceName { get; set; }    // Tên thiết bị (VD: Tủ lạnh, Máy giặt)
        public string IssueDescription { get; set; } // Lỗi gì? (VD: Không lạnh)
        public string Status { get; set; }        // Trạng thái: Mới, Đang sửa, Xong
        public DateTime CreatedDate { get; set; } // Ngày tạo phiếu
    }
}