using AForge.Video;
using AForge.Video.DirectShow;
using CoolMaster.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ZXing;
using CoolMaster.Services;

namespace CoolMaster
{
    public partial class frmSignInQR : Form
    {
        private FilterInfoCollection _filterInfoCollection;
        private VideoCaptureDevice _videoCaptureDevice;
        private bool isProcessing = false;
        private BarcodeReader reader;
        private readonly AuthService _authService = new AuthService();

        public frmSignInQR()
        {
            InitializeComponent();

            reader = new BarcodeReader();
            reader.Options.PossibleFormats = new List<BarcodeFormat> { BarcodeFormat.QR_CODE };
        }

        private void frmSignInQR_Load(object sender, EventArgs e)
        {
            try
            {
                _filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                if (_filterInfoCollection.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy Camera!");
                    btnXacNhanQRLogin.Enabled = false;
                }

                // Đưa các control nhập liệu lên
                ToggleUI(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khởi động: " + ex.Message);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            StopCamera();
            base.OnFormClosing(e);
        }

        // HÀM ĐIỀU KHIỂN GIAO DIỆN
        private void ToggleUI(bool isTypingEmail)
        {
            if (pnlQRLogin != null)
            {
                pnlQRLogin.Visible = true;
                pnlQRLogin.SendToBack();
            }

            // nhóm nhập liệu
            txtEmailQR.Visible = isTypingEmail;
            lblEmailQR.Visible = isTypingEmail;
            btnXacNhanQRLogin.Visible = isTypingEmail;

            if (btnBackToSignIn != null) btnBackToSignIn.Visible = true;

            if (picQRCode != null) picQRCode.Visible = !isTypingEmail;
            if (lblInstruction != null) lblInstruction.Visible = !isTypingEmail;

            if (isTypingEmail)
            {
                txtEmailQR.BringToFront();
                btnXacNhanQRLogin.BringToFront();
                if (btnBackToSignIn != null) btnBackToSignIn.BringToFront();

                StopCamera();
            }
        }

        // BƯỚC 1: XÁC NHẬN EMAIL VÀ GỬI MÃ QR
        private void btnXacNhanQRLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmailQR.Text.Trim();
            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Vui lòng nhập Email!");
                return;
            }

            try
            {
                // Gọi Service: Service tự lo việc tạo QR và gửi mail
                bool isSent = _authService.RequestQRLogin(email);

                if (isSent)
                {
                    MessageBox.Show("Đã gửi mã QR về Email!", "Thành công");
                    ToggleUI(false);
                    StartCamera();
                }
                else
                {
                    MessageBox.Show("Email không tồn tại hoặc lỗi gửi mail.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống: " + ex.Message);
            }
        }

        // HÀM XỬ LÝ CAMERA
        private void StartCamera()
        {
            if (_filterInfoCollection.Count > 0)
            {
                _videoCaptureDevice = new VideoCaptureDevice(_filterInfoCollection[0].MonikerString);

                foreach (var capability in _videoCaptureDevice.VideoCapabilities)
                {
                    if (capability.FrameSize.Width >= 400 && capability.FrameSize.Height >= 400)
                    {
                        _videoCaptureDevice.VideoResolution = capability;
                        break; 
                    }
                }

                _videoCaptureDevice.NewFrame += VideoCaptureDevice_NewFrame;
                _videoCaptureDevice.Start();
                isProcessing = false;
            }
        }

        private void VideoCaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            // Chặn ngay nếu đang xử lý để không quét chồng chéo
            if (isProcessing) return;

            Bitmap bitmapForScanning = null;

            try
            {
                // Clone 1 bản để quét
                bitmapForScanning = (Bitmap)eventArgs.Frame.Clone();

                // Clone 1 bản để hiện lên màn hình
                Bitmap bitmapForUI = (Bitmap)eventArgs.Frame.Clone();

                // 1. Hiển thị ảnh
                picQRCode.Invoke((MethodInvoker)delegate
                {
                    if (picQRCode.Image != null)
                    {
                        var old = picQRCode.Image;
                        picQRCode.Image = null;
                        old.Dispose(); 
                    }
                    picQRCode.Image = bitmapForUI;
                });

                // 2. Quét mã
                var result = reader.Decode(bitmapForScanning);

                if (result != null)
                {
                    isProcessing = true;

                    // 3. Xử lý kết quả
                    this.BeginInvoke((MethodInvoker)delegate
                    {
                        StopCamera();
                        CheckLoginToken(result.Text);
                    });
                }
            }
            catch (Exception) { }
            finally
            {
                if (bitmapForScanning != null) bitmapForScanning.Dispose();
            }
        }

        // HÀM KIỂM TRA
        private void CheckLoginToken(string scannedToken)
        {
            try
            {
                // Gọi Service kiểm tra token
                var user = _authService.LoginWithQRToken(scannedToken);

                if (user != null)
                {
                    MessageBox.Show($"Xin chào {user.FullName}!", "Đăng nhập thành công");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    // Token sai, hết hạn hoặc đã dùng
                    MessageBox.Show("Mã QR không hợp lệ hoặc đã hết hạn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    // Nếu muốn cho thử lại camera:
                    isProcessing = false;
                    StartCamera();

                    // Hoặc bắt nhập lại từ đầu (như code cũ):
                    // ToggleUI(true); 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống: " + ex.Message);
            }
        }

        private void StopCamera()
        {
            if (_videoCaptureDevice != null && _videoCaptureDevice.IsRunning)
            {
                _videoCaptureDevice.SignalToStop();
                _videoCaptureDevice.WaitForStop();
                _videoCaptureDevice = null;
            }
            // Dọn sạch ảnh cuối cùng
            if (picQRCode.Image != null)
            {
                picQRCode.Image.Dispose();
                picQRCode.Image = null;
            }
        }
        
        private void frmSignInQR_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopCamera();
        }
        
        private void btnBackToSignIn_Click(object sender, EventArgs e)
        {
            StopCamera();
            this.Close();
        }
    }
}
