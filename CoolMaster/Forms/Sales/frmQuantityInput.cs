using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoolMaster.Forms.Sales
{
    public partial class frmQuantityInput : Form
    {
        public int Quantity { get; private set; } = 1;

        public frmQuantityInput(string productName)
        {
            InitializeComponent();
            lblTitle.Text = $"Nhập SL cho:\n{productName}";
        }

        // Tự động focus và bôi đen số khi mở form
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            numQty.Focus();
        }

        // Vẽ viền cho Form (Vì FormBorderStyle = None)
        private void frmQuantityInput_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle, Color.Silver, ButtonBorderStyle.Solid);
        }
            
        private void btnOK_Click(object sender, EventArgs e)
        {
            ConfirmQuantity();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // Xử lý phím Enter trên ô nhập số
        private void numQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ConfirmQuantity();
            }
        }

        private void ConfirmQuantity()
        {
            Quantity = (int)numQty.Value;
            if (Quantity <= 0)
            {
                MessageBox.Show("Số lượng phải lớn hơn 0", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
