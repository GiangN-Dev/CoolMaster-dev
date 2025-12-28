namespace CoolMaster
{
    partial class frmDashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.picboxCat = new Guna.UI2.WinForms.Guna2PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picboxCat)).BeginInit();
            this.SuspendLayout();
            // 
            // picboxCat
            // 
            this.picboxCat.Image = global::CoolMaster.Properties.Resources.cat;
            this.picboxCat.ImageRotate = 0F;
            this.picboxCat.Location = new System.Drawing.Point(250, 32);
            this.picboxCat.Name = "picboxCat";
            this.picboxCat.Size = new System.Drawing.Size(476, 522);
            this.picboxCat.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picboxCat.TabIndex = 0;
            this.picboxCat.TabStop = false;
            // 
            // frmDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.ClientSize = new System.Drawing.Size(990, 595);
            this.Controls.Add(this.picboxCat);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmDashboard";
            this.Text = "Trang chủ";
            ((System.ComponentModel.ISupportInitialize)(this.picboxCat)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2PictureBox picboxCat;
    }
}