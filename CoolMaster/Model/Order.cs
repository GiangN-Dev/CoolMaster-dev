using CoolMaster.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Hóa đơn bán hàng

namespace CoolMaster.Model
{
    [Table("Orders")]
    public class Order : BaseEntity
    {
        [Key] public int OrderId { get; set; }

        public decimal TotalAmount { get; set; }

        [Required] public PaymentMethod PaymentMethod { get; set; }
        [Required] public OrderStatus OrderStatus { get; set; }
        public string Note { get; set; }

        // Foreign Keys
        public int? CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }

        public int StaffId { get; set; } // Người tạo đơn
        [ForeignKey("StaffId")]
        public virtual User Staff { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
