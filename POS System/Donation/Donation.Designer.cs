namespace POS_System.Donation
{
    partial class Donation
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
            this.cbo_event = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_done = new DevComponents.DotNetBar.ButtonX();
            this.txt_contribution_amount = new System.Windows.Forms.TextBox();
            this.lbl_remaining_amount = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rbtn_phonepay = new System.Windows.Forms.RadioButton();
            this.rbtn_billing = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.rbtn_manually = new System.Windows.Forms.RadioButton();
            this.rbtn_all = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label24 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.cbo_event);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btn_done);
            this.panel1.Controls.Add(this.txt_contribution_amount);
            this.panel1.Controls.Add(this.lbl_remaining_amount);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.rbtn_manually);
            this.panel1.Controls.Add(this.rbtn_all);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(-1, 46);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(336, 318);
            this.panel1.TabIndex = 0;
            // 
            // cbo_event
            // 
            this.cbo_event.FormattingEnabled = true;
            this.cbo_event.Location = new System.Drawing.Point(171, 48);
            this.cbo_event.Name = "cbo_event";
            this.cbo_event.Size = new System.Drawing.Size(162, 21);
            this.cbo_event.TabIndex = 306;
            this.cbo_event.SelectedIndexChanged += new System.EventHandler(this.cbo_event_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(4, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 20);
            this.label2.TabIndex = 305;
            this.label2.Text = "Event";
            // 
            // btn_done
            // 
            this.btn_done.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_done.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btn_done.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_done.Location = new System.Drawing.Point(166, 231);
            this.btn_done.Name = "btn_done";
            this.btn_done.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(15);
            this.btn_done.Size = new System.Drawing.Size(96, 48);
            this.btn_done.TabIndex = 304;
            this.btn_done.Text = "Done";
            this.btn_done.Click += new System.EventHandler(this.btn_done_Click);
            // 
            // txt_contribution_amount
            // 
            this.txt_contribution_amount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_contribution_amount.Location = new System.Drawing.Point(165, 114);
            this.txt_contribution_amount.Name = "txt_contribution_amount";
            this.txt_contribution_amount.Size = new System.Drawing.Size(149, 26);
            this.txt_contribution_amount.TabIndex = 14;
            this.txt_contribution_amount.TextChanged += new System.EventHandler(this.txt_contribution_amount_TextChanged);
            // 
            // lbl_remaining_amount
            // 
            this.lbl_remaining_amount.AutoSize = true;
            this.lbl_remaining_amount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_remaining_amount.ForeColor = System.Drawing.Color.Black;
            this.lbl_remaining_amount.Location = new System.Drawing.Point(167, 15);
            this.lbl_remaining_amount.Name = "lbl_remaining_amount";
            this.lbl_remaining_amount.Size = new System.Drawing.Size(85, 20);
            this.lbl_remaining_amount.TabIndex = 13;
            this.lbl_remaining_amount.Text = "Remaining";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rbtn_phonepay);
            this.panel2.Controls.Add(this.rbtn_billing);
            this.panel2.Location = new System.Drawing.Point(165, 157);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(97, 68);
            this.panel2.TabIndex = 12;
            // 
            // rbtn_phonepay
            // 
            this.rbtn_phonepay.AutoSize = true;
            this.rbtn_phonepay.ForeColor = System.Drawing.Color.Black;
            this.rbtn_phonepay.Location = new System.Drawing.Point(10, 43);
            this.rbtn_phonepay.Name = "rbtn_phonepay";
            this.rbtn_phonepay.Size = new System.Drawing.Size(67, 17);
            this.rbtn_phonepay.TabIndex = 11;
            this.rbtn_phonepay.Text = "FonePay";
            this.rbtn_phonepay.UseVisualStyleBackColor = true;
            this.rbtn_phonepay.Click += new System.EventHandler(this.rbtn_phonepay_Click);
            // 
            // rbtn_billing
            // 
            this.rbtn_billing.AutoSize = true;
            this.rbtn_billing.Checked = true;
            this.rbtn_billing.ForeColor = System.Drawing.Color.Black;
            this.rbtn_billing.Location = new System.Drawing.Point(10, 11);
            this.rbtn_billing.Name = "rbtn_billing";
            this.rbtn_billing.Size = new System.Drawing.Size(52, 17);
            this.rbtn_billing.TabIndex = 10;
            this.rbtn_billing.TabStop = true;
            this.rbtn_billing.Text = "Billing";
            this.rbtn_billing.UseVisualStyleBackColor = true;
            this.rbtn_billing.CheckedChanged += new System.EventHandler(this.rbtn_billing_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(4, 157);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Payment Type";
            // 
            // rbtn_manually
            // 
            this.rbtn_manually.AutoSize = true;
            this.rbtn_manually.ForeColor = System.Drawing.Color.Black;
            this.rbtn_manually.Location = new System.Drawing.Point(258, 81);
            this.rbtn_manually.Name = "rbtn_manually";
            this.rbtn_manually.Size = new System.Drawing.Size(67, 17);
            this.rbtn_manually.TabIndex = 8;
            this.rbtn_manually.Text = "Manually";
            this.rbtn_manually.UseVisualStyleBackColor = true;
            // 
            // rbtn_all
            // 
            this.rbtn_all.AutoSize = true;
            this.rbtn_all.Checked = true;
            this.rbtn_all.ForeColor = System.Drawing.Color.Black;
            this.rbtn_all.Location = new System.Drawing.Point(165, 84);
            this.rbtn_all.Name = "rbtn_all";
            this.rbtn_all.Size = new System.Drawing.Size(36, 17);
            this.rbtn_all.TabIndex = 7;
            this.rbtn_all.TabStop = true;
            this.rbtn_all.Text = "All";
            this.rbtn_all.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(4, 81);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(112, 20);
            this.label7.TabIndex = 6;
            this.label7.Text = "Donation Type";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(3, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "Remaining";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(3, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(155, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Contribution Amount";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(81)))), ((int)(((byte)(126)))));
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Controls.Add(this.label24);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(336, 59);
            this.panel3.TabIndex = 296;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::POS_System.Properties.Resources.business__2_;
            this.pictureBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox1.Location = new System.Drawing.Point(40, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(52, 53);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label24.ForeColor = System.Drawing.Color.White;
            this.label24.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label24.Location = new System.Drawing.Point(107, 15);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(123, 31);
            this.label24.TabIndex = 6;
            this.label24.Text = "Donation";
            // 
            // Donation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 363);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Donation";
            this.Text = "Donation";
            this.Load += new System.EventHandler(this.Donation_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton rbtn_manually;
        private System.Windows.Forms.RadioButton rbtn_all;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton rbtn_phonepay;
        private System.Windows.Forms.RadioButton rbtn_billing;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbl_remaining_amount;
        private System.Windows.Forms.TextBox txt_contribution_amount;
        private DevComponents.DotNetBar.ButtonX btn_done;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbo_event;
    }
}