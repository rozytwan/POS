namespace POS_System.Void
{
    partial class VoidBill
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
            this.txt_void_bill_no = new System.Windows.Forms.TextBox();
            this.btn_exit = new System.Windows.Forms.PictureBox();
            this.btn_ok = new DevComponents.DotNetBar.ButtonX();
            ((System.ComponentModel.ISupportInitialize)(this.btn_exit)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_void_bill_no
            // 
            this.txt_void_bill_no.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_void_bill_no.Location = new System.Drawing.Point(0, 2);
            this.txt_void_bill_no.Name = "txt_void_bill_no";
            this.txt_void_bill_no.Size = new System.Drawing.Size(342, 30);
            this.txt_void_bill_no.TabIndex = 0;
            this.txt_void_bill_no.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_void_bill_no_KeyPress);
            // 
            // btn_exit
            // 
            this.btn_exit.Image = global::POS_System.Properties.Resources.cancel;
            this.btn_exit.Location = new System.Drawing.Point(404, 3);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(30, 28);
            this.btn_exit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btn_exit.TabIndex = 1;
            this.btn_exit.TabStop = false;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // btn_ok
            // 
            this.btn_ok.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_ok.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btn_ok.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ok.Location = new System.Drawing.Point(345, 0);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(15);
            this.btn_ok.Size = new System.Drawing.Size(49, 34);
            this.btn_ok.TabIndex = 309;
            this.btn_ok.Text = "OK";
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // VoidBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(441, 34);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.txt_void_bill_no);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "VoidBill";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VoidBill";
            ((System.ComponentModel.ISupportInitialize)(this.btn_exit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox btn_exit;
        private DevComponents.DotNetBar.ButtonX btn_ok;
        public System.Windows.Forms.TextBox txt_void_bill_no;
    }
}