using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Danh mục hàng hóa

namespace CoolMaster.Model
{
    [Table("Categories")]
    public class Category : BaseEntity
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [MaxLength(50)]
        public string CategoryName { get; set; }

        public string Description { get; set; }

        // Quan hệ 1-nhiều với Product
        public virtual ICollection<Product> Products { get; set; }
    }
}
