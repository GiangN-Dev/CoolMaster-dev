using QRCoder;

using System.Drawing;

namespace CoolMaster.Common
{
    internal class QRHelper
    {
        // Tạo ảnh QR
        public static Bitmap GenerateQRCode(string text, int pixelsPerModule = 20)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(text, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            return qrCode.GetGraphic(pixelsPerModule);
        }
    }
}
