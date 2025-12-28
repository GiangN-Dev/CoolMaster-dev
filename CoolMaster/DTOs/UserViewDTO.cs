using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolMaster.DTOs
{
    public class UserViewDTO
    {
        public int UserId { get; set; }
        public string StaffCode { get; set; } // Mã NV (N001)
        public string FullName { get; set; }
        public string Role { get; set; }      // Chức vụ
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
}
