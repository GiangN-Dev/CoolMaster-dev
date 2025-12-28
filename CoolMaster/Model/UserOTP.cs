using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoolMaster.Model
{
    [Table("UserOTPs")]
    public class UserOTP : BaseEntity
    {
        [Key]
        public int RecordId { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; } // Liên kết với User qua Email

        [Required]
        [StringLength(100)]
        public string OTP_Code { get; set; }

        public DateTime ExpireTime { get; set; } // Thời gian hết hạn

        public bool IsUsed { get; set; } // Đã dùng chưa?
    }
}
