namespace POS_System.Hotel
{
    partial class Room_Transfer
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtfrom = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtto = new System.Windows.Forms.ComboBox();
            this.btn_transfer = new DevComponents.DotNetBar.ButtonX();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.txtfrom);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtto);
            this.panel1.Controls.Add(this.btn_transfer);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(291, 208);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(81)))), ((int)(((byte)(126)))));
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(1, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(299, 59);
            this.panel2.TabIndex = 105;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::POS_System.Properties.Resources.up_arrow;
            this.pictureBox1.Location = new System.Drawing.Point(18, 8);
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
            this.label4.Location = new System.Drawing.Point(74, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(195, 31);
            this.label4.TabIndex = 6;
            this.label4.Text = "Room Transfer";
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
            this.txtfrom.TabIndex = 118;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 17);
            this.label1.TabIndex = 117;
            this.label1.Text = "From Room :";
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
            this.txtto.TabIndex = 116;
            // 
            // btn_transfer
            // 
            this.btn_transfer.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_transfer.BackColor = System.Drawing.Color.White;
            this.btn_transfer.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btn_transfer.Image = global::POS_System.Properties.Resources.interface__1_;
            this.btn_transfer.Location = new System.Drawing.Point(163, 155);
            this.btn_transfer.Name = "btn_transfer";
            this.btn_transfer.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(15);
            this.btn_transfer.Size = new System.Drawing.Size(109, 43);
            this.btn_transfer.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_transfer.TabIndex = 114;
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
            this.label2.TabIndex = 115;
            this.label2.Text = "To Room :";
            // 
            // Room_Transfer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 214);
            this.Controls.Add(this.panel1);
            this.Name = "Room_Transfer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Room_Transfer";
            this.Load += new System.EventHandler(this.Room_Transfer_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox txtfrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox txtto;
        private DevComponents.DotNetBar.ButtonX btn_transfer;
        private System.Windows.Forms.Label label2;
    }
}