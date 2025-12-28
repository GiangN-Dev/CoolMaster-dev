using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoolMaster.Model
{
    [Table("Users")]
    public class User : BaseEntity
    {
        [Key]
        public int UserId { get; set; }  // Id tự tăng

        [Required]
        [StringLength(20)]
        public string StaffCode { get; set; } // Đây là mã hiển thị (N001)

        [Required]
        [StringLength(100)]
        public string Password { get; set; }

        [StringLength(100)]
        public string FullName { get; set; }

        [StringLength(50)]
        public string Role { get; set; } // Quản lý, Thu ngân...

        [StringLength(100)]
        public string Email { get; set; } 

        [StringLength(200)]
        public string Address { get; set; } 

        [StringLength(20)]
        public string PhoneNumber { get; set; }
    }
}