using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolMaster.DTOs
{
    public class ProductViewDTO
    {
        public int ProductId { get; set; } // Để ẩn đi, dùng khi user click Sửa/Xóa
        public string Barcode { get; set; } // Mã vạch (Quan trọng để bán hàng)
        public string ProductName { get; set; }
        public string CategoryName { get; set; } // Tên danh mục (thay vì CategoryId)
        public decimal UnitPrice { get; set; } // Giá bán
        public int StockWarehouse { get; set; } // SL Trong kho
        public int StockCounter { get; set; }   // SL Ngoài quầy (kệ trưng bày)
        public int TotalStock { get; set; }     // Tổng tồn (để xem tổng tài sản)
        public string Unit { get; set; } // Đơn vị tính (Cái, Bộ, Hộp)
        public string ImageUrl { get; set; } // Ảnh sản phẩm (URL hoặc Base64)
    }
}
