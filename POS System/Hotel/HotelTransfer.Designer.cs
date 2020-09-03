namespace POS_System
{
    partial class HotelTransfer
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtto = new System.Windows.Forms.ComboBox();
            this.btn_transfer = new DevComponents.DotNetBar.ButtonX();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtfrom = new System.Windows.Forms.ComboBox();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(81)))), ((int)(((byte)(126)))));
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(0, -1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(311, 59);
            this.panel2.TabIndex = 104;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::POS_System.Properties.Resources.up_arrow;
            this.pictureBox1.Location = new System.Drawing.Point(6, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 43);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(56, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(187, 31);
            this.label4.TabIndex = 6;
            this.label4.Text = "Hotel Transfer";
            // 
            // txtto
            // 
            this.txtto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.txtto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtto.FormattingEnabled = true;
            this.txtto.Location = new System.Drawing.Point(113, 116);
            this.txtto.Name = "txtto";
            this.txtto.Size = new System.Drawing.Size(159, 28);
            this.txtto.TabIndex = 110;
            // 
            // btn_transfer
            // 
            this.btn_transfer.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_transfer.BackColor = System.Drawing.Color.White;
            this.btn_transfer.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btn_transfer.Image = global::POS_System.Properties.Resources.interface__1_;
            this.btn_transfer.Location = new System.Drawing.Point(168, 167);
            this.btn_transfer.Name = "btn_transfer";
            this.btn_transfer.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(15);
            this.btn_transfer.Size = new System.Drawing.Size(109, 43);
            this.btn_transfer.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_transfer.TabIndex = 107;
            this.btn_transfer.Text = "Transfer";
            this.btn_transfer.Click += new System.EventHandler(this.btn_transfer_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(33, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 17);
            this.label2.TabIndex = 108;
            this.label2.Text = "To Room :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 17);
            this.label1.TabIndex = 111;
            this.label1.Text = "From Table No :";
            // 
            // txtfrom
            // 
            this.txtfrom.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtfrom.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.txtfrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtfrom.FormattingEnabled = true;
            this.txtfrom.Location = new System.Drawing.Point(113, 75);
            this.txtfrom.Name = "txtfrom";
            this.txtfrom.Size = new System.Drawing.Size(159, 28);
            this.txtfrom.TabIndex = 113;
            // 
            // HotelTransfer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(308, 231);
            this.Controls.Add(this.txtfrom);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtto);
            this.Controls.Add(this.btn_transfer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HotelTransfer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HotelTransfer";
            this.Load += new System.EventHandler(this.HotelTransfer_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox txtto;
        private DevComponents.DotNetBar.ButtonX btn_transfer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox txtfrom;
    }
}