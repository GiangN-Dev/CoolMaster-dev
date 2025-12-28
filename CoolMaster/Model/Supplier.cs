using CoolMaster.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Nhà cung cấp

namespace CoolMaster.Model
{
    [Table("Suppliers")]
    public class Supplier : BaseEntity
    {
        [Key]
        public int SupplierId { get; set; }

        [Required]
        [MaxLength(100)]
        public string SupplierName { get; set; }

        [MaxLength(50)]
        public string ContactPerson { get; set; }

        [MaxLength(15)]
        public string Phone { get; set; }

        [MaxLength(200)]
        public string Address { get; set; }
    }
}
