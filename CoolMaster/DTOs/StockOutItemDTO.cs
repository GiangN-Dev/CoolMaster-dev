using System;

namespace CoolMaster.DTOs
{
    public class StockOutItemDTO
    {
        public int ProductId { get; set; }      // ID để máy tính biết là sản phẩm nào
        public string Barcode { get; set; }     // Mã vạch để hiển thị
        public string ProductName { get; set; } // Tên sản phẩm
        public string Unit { get; set; }        // Đơn vị tính (Cái, Bộ, Lần...)

        public int Quantity { get; set; }       // Số lượng bạn nhập để xuất
        public decimal Price { get; set; }      // Giá vốn hoặc giá xuất tại thời điểm đó

        // Cột này tự động tính toán: Thành tiền = Số lượng x Đơn giá
        public decimal Total => Quantity * Price;
    }
}