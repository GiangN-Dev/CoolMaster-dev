using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Khách hàng

namespace CoolMaster.Model
{
    public class Customer : BaseEntity
    {
        [Key] public int CustomerId { get; set; }

        [Required]
        [MaxLength(100)]
        public string FullName { get; set; }

        [MaxLength(15)]
        public string PhoneNumber { get; set; }

        [MaxLength(200)]
        public string Address { get; set; }

        // Navigation Properties (Quan trọng cho ORM)
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<ServiceTicket> ServiceTickets { get; set; }
    }
}
