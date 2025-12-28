using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolMaster.DTOs
{
    public class ProductFilterRequest
    {
        public string Keyword { get; set; }
        public string CategoryName { get; set; } // Hoặc CategoryId tùy logic
        public string Brand { get; set; }
        public string StockStatus { get; set; } // "All", "InStock", "LowStock", "OutStock"
        public decimal? PriceFrom { get; set; }
        public decimal? PriceTo { get; set; }

        // Kiểm tra xem có áp dụng bộ lọc nào không
        public bool IsFiltering => !string.IsNullOrEmpty(Keyword) ||
                                   !string.IsNullOrEmpty(CategoryName) ||
                                   !string.IsNullOrEmpty(Brand) ||
                                   (PriceFrom > 0 || PriceTo > 0);
        
    
    }
}
