using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoolMaster.Common;
// Lịch sử nhập xuất kho

namespace CoolMaster.Model
{
    [Table("InventoryLogs")]
    public class InventoryLog : BaseEntity
    {
        [Key] public int LogId { get; set; }

        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        // Thêm Supplier cho trường hợp nhập hàng (Import)
        public int? SupplierId { get; set; }
        [ForeignKey("SupplierId")]
        public virtual Supplier Supplier { get; set; }

        [Required] public int QuantityChange { get; set; }
        public int StockBefore { get; set; }
        public int StockAfter { get; set; }

        [Required] public InventoryChangeType ChangeType { get; set; }

        [MaxLength(50)]
        public string ReferenceId { get; set; } // Mã Order hoặc Mã Phiếu Nhập

        public string Note { get; set; }

        public int? CreatedByUserId { get; set; }
        [ForeignKey("CreatedByUserId")]
        public virtual User User { get; set; }
    }
}

