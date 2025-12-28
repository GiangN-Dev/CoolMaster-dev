using CoolMaster.Properties;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolMaster.Common
{
    public static class UIHelper
    {
        public static void TogglePasswordVisibility(Guna2TextBox txt)
        {
            if (txt.UseSystemPasswordChar)
            {
                // Đang ẩn -> Chuyển sang hiện
                txt.UseSystemPasswordChar = false;
                txt.PasswordChar = '\0'; // Ký tự null để hiện text bình thường
                txt.IconRight = Resources.IconEyeOff; // Đổi icon thành "Mắt gạch chéo"
            }
            else
            {
                // Đang hiện -> Chuyển sang ẩn
                txt.UseSystemPasswordChar = true;
                txt.IconRight = Resources.IconEye; // Đổi icon thành "Mắt mở"
            }
        }
    }
}
