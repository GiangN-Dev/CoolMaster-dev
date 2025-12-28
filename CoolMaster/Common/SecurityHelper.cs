using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;

namespace CoolMaster.Common
{
    internal class SecurityHelper
    {
        // Hàm mã hóa mật khẩu (Dùng khi Đăng ký hoặc Quên mật khẩu)
        public static string HashPassword(string plainPassword)
        {
            return BCrypt.Net.BCrypt.HashPassword(plainPassword);
        }

        // Hàm kiểm tra mật khẩu (Dùng khi Đăng nhập)
        public static bool VerifyPassword(string plainPassword, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(plainPassword, hashedPassword);
        }
    }
}
