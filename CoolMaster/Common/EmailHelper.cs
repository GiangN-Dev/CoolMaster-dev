using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoolMaster.Common
{
    /// <summary>
    /// Hàm gửi email chung cho toàn hệ thống
    /// </summary>
    /// <param name="toEmail">Địa chỉ người nhận</param>
    /// <param name="subject">Tiêu đề email</param>
    /// <param name="body">Nội dung email</param>
    /// <param name="attachmentStream">Stream ảnh (nếu có, VD: mã QR)</param>
    /// <param name="attachmentName">Tên file đính kèm (VD: qr.png)</param>
    internal class EmailHelper
    {
        public static bool Send(string toEmail, string subject, string body, MemoryStream attachmentStream = null, string attachmentName = "")
        {
            try
            {
                // 1. Đọc cấu hình từ App.config
                string fromEmail = ConfigurationManager.AppSettings["SmtpEmail"];
                string password = ConfigurationManager.AppSettings["SmtpPassword"];
                string host = ConfigurationManager.AppSettings["SmtpHost"];

                // Kiểm tra kỹ nếu config bị lỗi
                if (!int.TryParse(ConfigurationManager.AppSettings["SmtpPort"], out int port))
                {
                    port = 587;
                }

                // 2. Tạo nội dung thư
                MailMessage message = new MailMessage();
                message.From = new MailAddress(fromEmail, "CoolMaster Support");
                message.To.Add(toEmail);
                message.Subject = subject;
                message.Body = body;
                message.IsBodyHtml = false;

                // 3. Xử lý file đính kèm (nếu có)
                if (attachmentStream != null && !string.IsNullOrEmpty(attachmentName))
                {
                    attachmentStream.Position = 0;
                    message.Attachments.Add(new Attachment(attachmentStream, attachmentName, "image/png"));
                }

                // 4. Cấu hình Server gửi đi
                using (SmtpClient smtp = new SmtpClient(host, port))
                {
                    smtp.EnableSsl = true;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(fromEmail, password);

                    smtp.Send(message);
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gửi mail thất bại: " + ex.Message + "\n(Vui lòng kiểm tra kết nối mạng)");
                return false;
            }
        }
    }
}
