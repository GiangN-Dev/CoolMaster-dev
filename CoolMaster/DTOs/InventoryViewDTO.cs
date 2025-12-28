using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolMaster.DTOs
{
    public class InventoryViewDTO
    {
        public int ProductId { get; set; }
        public string Barcode { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public string Unit { get; set; }

        // Tồn kho chi tiết
        public int StockWarehouse { get; set; } // Tồn trong kho
        public int StockCounter { get; set; }   // Tồn ngoài quầy
        public int TotalStock { get; set; }     // Tổng tài sản

        public decimal UnitPrice { get; set; }
        public DateTime? LastImportDate { get; set; } // Ngày nhập cuối (nếu cần)
    }
}
