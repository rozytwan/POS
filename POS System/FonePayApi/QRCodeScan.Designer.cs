namespace POS_System.FonePayApi
{
    partial class QRCodeScan
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_disconnect = new DevComponents.DotNetBar.ButtonX();
            this.btn_qr_print = new DevComponents.DotNetBar.ButtonX();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::POS_System.Properties.Resources.no_qr;
            this.pictureBox1.Location = new System.Drawing.Point(-1, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(328, 327);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btn_disconnect
            // 
            this.btn_disconnect.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_disconnect.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btn_disconnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_disconnect.Location = new System.Drawing.Point(189, 334);
            this.btn_disconnect.Name = "btn_disconnect";
            this.btn_disconnect.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(15);
            this.btn_disconnect.Size = new System.Drawing.Size(129, 48);
            this.btn_disconnect.TabIndex = 304;
            this.btn_disconnect.Text = "Disconnect";
            this.btn_disconnect.Click += new System.EventHandler(this.btn_disconnect_Click);
            // 
            // btn_qr_print
            // 
            this.btn_qr_print.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_qr_print.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btn_qr_print.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_qr_print.Location = new System.Drawing.Point(12, 334);
            this.btn_qr_print.Name = "btn_qr_print";
            this.btn_qr_print.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(15);
            this.btn_qr_print.Size = new System.Drawing.Size(129, 48);
            this.btn_qr_print.TabIndex = 305;
            this.btn_qr_print.Text = "QR Code Print";
            this.btn_qr_print.Click += new System.EventHandler(this.btn_qr_print_Click);
            // 
            // QRCodeScan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 389);
            this.Controls.Add(this.btn_qr_print);
            this.Controls.Add(this.btn_disconnect);
            this.Controls.Add(this.pictureBox1);
            this.Name = "QRCodeScan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QRCodeScan";
            this.Load += new System.EventHandler(this.Test_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private DevComponents.DotNetBar.ButtonX btn_disconnect;
        private DevComponents.DotNetBar.ButtonX btn_qr_print;
    }
}