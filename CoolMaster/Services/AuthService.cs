using CoolMaster.Common;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoolMaster.Model;

namespace CoolMaster.Services
{
    internal class AuthService
    {
        public User Login(string staffCode, string password)
        {
            using (var db = new CoolMasterContext())
            {
                // Tìm user
                var user = db.Users.FirstOrDefault(u => u.StaffCode == staffCode && u.IsDeleted == false);

                // Nếu user không tồn tại
                if (user == null) return null;

                // Kiểm tra pass bằng SecurityHelper
                if (SecurityHelper.VerifyPassword(password, user.Password))
                {
                    return user;
                }

                return null; // Sai mật khẩu
            }
        }

        //Gửi OTP
        public bool ForgotPassword_SendOTP(string email)
        {
            using (var db = new CoolMasterContext())
            {
                var user = db.Users.FirstOrDefault(u => u.Email == email);
                if (user == null) return false; // Email không tồn tại

                string otpCode = new Random().Next(100000, 999999).ToString();

                // Xóa OTP cũ
                var oldOTPs = db.UserOTPs.Where(x => x.Email == email).ToList();
                db.UserOTPs.RemoveRange(oldOTPs);

                // Tạo mới
                db.UserOTPs.Add(new UserOTP
                {
                    Email = email,
                    OTP_Code = otpCode,
                    ExpireTime = DateTime.Now.AddSeconds(120),
                    IsUsed = false
                });
                db.SaveChanges();

                // Gửi mail
                string subject = "[CoolMaster] Mã xác nhận OTP";
                string body = $"Mã OTP của bạn là: {otpCode}\nMã này có hiệu lực trong 120 giây.";

                return EmailHelper.Send(email, subject, body);
            }
        }

        // Xác thực OTP
        public bool ForgotPassword_VerifyOTP(string email, string otp)
        {
            using (var db = new CoolMasterContext())
            {
                var token = db.UserOTPs.FirstOrDefault(x => x.Email == email
                                                         && x.OTP_Code == otp
                                                         && x.IsUsed == false);

                if (token != null && token.ExpireTime > DateTime.Now)
                {
                    token.IsUsed = true; // Đánh dấu đã dùng
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        // Đổi mk
        public bool ForgotPassword_ResetPassword(string email, string newPass)
        {
            using (var db = new CoolMasterContext())
            {
                var user = db.Users.FirstOrDefault(u => u.Email == email);
                if (user != null)
                {
                    user.Password = SecurityHelper.HashPassword(newPass);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        // Yêu cầu đăng nhập QR
        public bool RequestQRLogin(string email)
        {
            using (var db = new CoolMasterContext())
            {
                var user = db.Users.FirstOrDefault(u => u.Email == email);
                if (user == null) return false;

                string loginToken = Guid.NewGuid().ToString();

                // Dọn dẹp token cũ
                var oldOtps = db.UserOTPs.Where(x => x.Email == email).ToList();
                db.UserOTPs.RemoveRange(oldOtps);

                db.UserOTPs.Add(new UserOTP
                {
                    Email = email,
                    OTP_Code = loginToken,
                    ExpireTime = DateTime.Now.AddMinutes(5),
                    IsUsed = false
                });
                db.SaveChanges();

                // Tạo ảnh QR và gửi mail
                Bitmap qrImage = QRHelper.GenerateQRCode(loginToken);
                using (MemoryStream ms = new MemoryStream())
                {
                    qrImage.Save(ms, ImageFormat.Png);
                    return EmailHelper.Send(email, "CoolMaster - QR Đăng nhập nhanh",
                        "Đưa mã QR đính kèm vào trước Camera để đăng nhập.", ms, "LoginQR.png");
                }
            }
        }

        // Kiểm tra QR từ cam
        public User LoginWithQRToken(string token)
        {
            using (var db = new CoolMasterContext())
            {
                var tokenData = db.UserOTPs.FirstOrDefault(x => x.OTP_Code == token);

                // Check Token tồn tại, chưa dùng, còn hạn
                if (tokenData == null || tokenData.IsUsed || tokenData.ExpireTime < DateTime.Now)
                {
                    return null;
                }

                // Hợp lệ -> Đánh dấu đã dùng
                tokenData.IsUsed = true;
                db.SaveChanges();

                // Trả về User
                return db.Users.FirstOrDefault(u => u.Email == tokenData.Email);
            }
        }

        // Đăng ký tài khoản
        public User Register(User newUser, string rawPassword)
        {
            using (var db = new CoolMasterContext())
            {
                if (db.Users.Any(u => u.Email == newUser.Email))
                {
                    throw new Exception("Email này đã tồn tại trong hệ thống!");
                }

                newUser.StaffCode = GenerateNewStaffCode(db);
                // Mã hóa mật khẩu 
                newUser.Password = SecurityHelper.HashPassword(rawPassword);
                newUser.CreatedAt = DateTime.Now;
                newUser.IsDeleted = false;

                db.Users.Add(newUser);
                db.SaveChanges();

                return newUser; // Trả về user
            }
        }

        // Sinh ID
        private string GenerateNewStaffCode(CoolMasterContext db)
        {
            var allCode = db.Users.Select(u => u.StaffCode).ToList();

            if (allCode.Count == 0) return "N001";

            int maxNumber = 0;
            foreach (var code in allCode)
            {
                if (!string.IsNullOrEmpty(code) && code.Length > 1 && code.StartsWith("N"))
                {
                    string numberPart = code.Substring(1);
                    if (int.TryParse(numberPart, out int num))
                    {
                        if (num > maxNumber) maxNumber = num;
                    }
                }
            }

            return "N" + (maxNumber + 1).ToString("D3");
        }
    }
}
