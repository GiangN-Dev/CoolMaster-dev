using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Chi tiết hóa đơn bán hàng

namespace CoolMaster.Model
{
    [Table("OrderDetails")]
    public class OrderDetail : BaseEntity
    {
        [Key]
        public int OrderDetailId { get; set; }

        public int Quantity { get; set; }

        public decimal SalePrice { get; set; } // Giá tại thời điểm bán (đề phòng giá gốc thay đổi)

        // Tính toán nhanh: Quantity * SalePrice
        [NotMapped]
        public decimal SubTotal => Quantity * SalePrice;

        // --- Foreign Keys ---
        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public virtual Order Order { get; set; }

        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
    }
}
