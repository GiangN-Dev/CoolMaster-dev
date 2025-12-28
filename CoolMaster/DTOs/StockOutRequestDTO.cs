using System;
using System.Collections.Generic;

namespace CoolMaster.DTOs
{
    public class StockOutRequestDTO
    {
        // Thông tin chung của phiếu (Phần Header)
        public string Reason { get; set; }      // Lý do xuất (Công trình, bảo hành...)
        public string Receiver { get; set; }    // Người nhận hàng
        public string Note { get; set; }        // Ghi chú thêm
        public int UserId { get; set; }         // ID của nhân viên đang đăng nhập thực hiện xuất

        // Danh sách các mặt hàng nằm trong phiếu này
        // Sử dụng List để chứa nhiều StockOutItemDTO
        public List<StockOutItemDTO> Items { get; set; } = new List<StockOutItemDTO>();
    }
}