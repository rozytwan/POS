namespace POS_System
{
    partial class CustomerDisplayModified
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
            this.cbo_RTS_enable = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbo_HandShake = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbo_databits = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbo_parity = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbo_Baud_rate = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbo_serial_port_name = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbo_status = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_test_port = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label23 = new System.Windows.Forms.Label();
            this.txt_text = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.rbtn_price = new System.Windows.Forms.RadioButton();
            this.rbtn_total = new System.Windows.Forms.RadioButton();
            this.rbtn_collection = new System.Windows.Forms.RadioButton();
            this.rbtn_change = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbtn_vfd = new System.Windows.Forms.RadioButton();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbo_RTS_enable
            // 
            this.cbo_RTS_enable.FormattingEnabled = true;
            this.cbo_RTS_enable.Items.AddRange(new object[] {
            "True",
            "False"});
            this.cbo_RTS_enable.Location = new System.Drawing.Point(104, 272);
            this.cbo_RTS_enable.Name = "cbo_RTS_enable";
            this.cbo_RTS_enable.Size = new System.Drawing.Size(257, 21);
            this.cbo_RTS_enable.TabIndex = 35;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 280);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 34;
            this.label6.Text = "Rts Enable";
            // 
            // cbo_HandShake
            // 
            this.cbo_HandShake.FormattingEnabled = true;
            this.cbo_HandShake.Items.AddRange(new object[] {
            "None",
            "XOnXOff",
            "RequestToSend",
            "RequestToSendXOnXOff"});
            this.cbo_HandShake.Location = new System.Drawing.Point(104, 231);
            this.cbo_HandShake.Name = "cbo_HandShake";
            this.cbo_HandShake.Size = new System.Drawing.Size(257, 21);
            this.cbo_HandShake.TabIndex = 33;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 239);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 32;
            this.label5.Text = "Hand Shake";
            // 
            // cbo_databits
            // 
            this.cbo_databits.FormattingEnabled = true;
            this.cbo_databits.Items.AddRange(new object[] {
            "7",
            "8"});
            this.cbo_databits.Location = new System.Drawing.Point(104, 187);
            this.cbo_databits.Name = "cbo_databits";
            this.cbo_databits.Size = new System.Drawing.Size(257, 21);
            this.cbo_databits.TabIndex = 31;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 194);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "Data Bits";
            // 
            // cbo_parity
            // 
            this.cbo_parity.FormattingEnabled = true;
            this.cbo_parity.Items.AddRange(new object[] {
            "None",
            "Even",
            "Mark",
            "Odd",
            "Space"});
            this.cbo_parity.Location = new System.Drawing.Point(104, 148);
            this.cbo_parity.Name = "cbo_parity";
            this.cbo_parity.Size = new System.Drawing.Size(257, 21);
            this.cbo_parity.TabIndex = 29;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 28;
            this.label3.Text = "Parity";
            // 
            // cbo_Baud_rate
            // 
            this.cbo_Baud_rate.FormattingEnabled = true;
            this.cbo_Baud_rate.Items.AddRange(new object[] {
            "300",
            "600",
            "1200",
            "2400",
            "9600",
            "14400",
            "19200",
            "38400",
            "57600",
            "115200)"});
            this.cbo_Baud_rate.Location = new System.Drawing.Point(104, 109);
            this.cbo_Baud_rate.Name = "cbo_Baud_rate";
            this.cbo_Baud_rate.Size = new System.Drawing.Size(257, 21);
            this.cbo_Baud_rate.TabIndex = 27;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "Baud Rate";
            // 
            // cbo_serial_port_name
            // 
            this.cbo_serial_port_name.FormattingEnabled = true;
            this.cbo_serial_port_name.Location = new System.Drawing.Point(104, 67);
            this.cbo_serial_port_name.Name = "cbo_serial_port_name";
            this.cbo_serial_port_name.Size = new System.Drawing.Size(257, 21);
            this.cbo_serial_port_name.TabIndex = 25;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Serial Port";
            // 
            // cbo_status
            // 
            this.cbo_status.FormattingEnabled = true;
            this.cbo_status.Items.AddRange(new object[] {
            "Active",
            "Unactive"});
            this.cbo_status.Location = new System.Drawing.Point(104, 313);
            this.cbo_status.Name = "cbo_status";
            this.cbo_status.Size = new System.Drawing.Size(257, 21);
            this.cbo_status.TabIndex = 37;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 321);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 13);
            this.label7.TabIndex = 36;
            this.label7.Text = "Status";
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(270, 430);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(91, 55);
            this.btn_save.TabIndex = 38;
            this.btn_save.Text = "Save To File";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_test_port
            // 
            this.btn_test_port.Location = new System.Drawing.Point(159, 430);
            this.btn_test_port.Name = "btn_test_port";
            this.btn_test_port.Size = new System.Drawing.Size(91, 55);
            this.btn_test_port.TabIndex = 39;
            this.btn_test_port.Text = "Test Port";
            this.btn_test_port.UseVisualStyleBackColor = true;
            this.btn_test_port.Click += new System.EventHandler(this.btn_test_port_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(81)))), ((int)(((byte)(126)))));
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.label23);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(398, 44);
            this.panel2.TabIndex = 131;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::POS_System.Properties.Resources.check__1_;
            this.pictureBox1.Location = new System.Drawing.Point(25, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(47, 41);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 26;
            this.pictureBox1.TabStop = false;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.White;
            this.label23.Location = new System.Drawing.Point(106, 7);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(226, 31);
            this.label23.TabIndex = 18;
            this.label23.Text = "Serial Port Config";
            // 
            // txt_text
            // 
            this.txt_text.Location = new System.Drawing.Point(104, 348);
            this.txt_text.Name = "txt_text";
            this.txt_text.Size = new System.Drawing.Size(257, 20);
            this.txt_text.TabIndex = 132;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(22, 355);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(28, 13);
            this.label8.TabIndex = 133;
            this.label8.Text = "Text";
            // 
            // rbtn_price
            // 
            this.rbtn_price.AutoSize = true;
            this.rbtn_price.Location = new System.Drawing.Point(83, 19);
            this.rbtn_price.Name = "rbtn_price";
            this.rbtn_price.Size = new System.Drawing.Size(49, 17);
            this.rbtn_price.TabIndex = 134;
            this.rbtn_price.Text = "Price";
            this.rbtn_price.UseVisualStyleBackColor = true;
            this.rbtn_price.CheckedChanged += new System.EventHandler(this.rbtn_price_CheckedChanged);
            // 
            // rbtn_total
            // 
            this.rbtn_total.AutoSize = true;
            this.rbtn_total.Location = new System.Drawing.Point(152, 19);
            this.rbtn_total.Name = "rbtn_total";
            this.rbtn_total.Size = new System.Drawing.Size(49, 17);
            this.rbtn_total.TabIndex = 135;
            this.rbtn_total.Text = "Total";
            this.rbtn_total.UseVisualStyleBackColor = true;
            this.rbtn_total.CheckedChanged += new System.EventHandler(this.rbtn_total_CheckedChanged);
            // 
            // rbtn_collection
            // 
            this.rbtn_collection.AutoSize = true;
            this.rbtn_collection.Location = new System.Drawing.Point(217, 19);
            this.rbtn_collection.Name = "rbtn_collection";
            this.rbtn_collection.Size = new System.Drawing.Size(71, 17);
            this.rbtn_collection.TabIndex = 136;
            this.rbtn_collection.Text = "Collection";
            this.rbtn_collection.UseVisualStyleBackColor = true;
            this.rbtn_collection.CheckedChanged += new System.EventHandler(this.rbtn_collection_CheckedChanged);
            // 
            // rbtn_change
            // 
            this.rbtn_change.AutoSize = true;
            this.rbtn_change.Location = new System.Drawing.Point(303, 19);
            this.rbtn_change.Name = "rbtn_change";
            this.rbtn_change.Size = new System.Drawing.Size(62, 17);
            this.rbtn_change.TabIndex = 137;
            this.rbtn_change.Text = "Change";
            this.rbtn_change.UseVisualStyleBackColor = true;
            this.rbtn_change.CheckedChanged += new System.EventHandler(this.rbtn_change_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbtn_vfd);
            this.panel1.Controls.Add(this.rbtn_change);
            this.panel1.Controls.Add(this.rbtn_price);
            this.panel1.Controls.Add(this.rbtn_collection);
            this.panel1.Controls.Add(this.rbtn_total);
            this.panel1.Location = new System.Drawing.Point(12, 371);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(373, 55);
            this.panel1.TabIndex = 138;
            // 
            // rbtn_vfd
            // 
            this.rbtn_vfd.AutoSize = true;
            this.rbtn_vfd.Checked = true;
            this.rbtn_vfd.Location = new System.Drawing.Point(16, 19);
            this.rbtn_vfd.Name = "rbtn_vfd";
            this.rbtn_vfd.Size = new System.Drawing.Size(46, 17);
            this.rbtn_vfd.TabIndex = 138;
            this.rbtn_vfd.Text = "VFD";
            this.rbtn_vfd.UseVisualStyleBackColor = true;
            // 
            // CustomerDisplayModified
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 506);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txt_text);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btn_test_port);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.cbo_status);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbo_RTS_enable);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbo_HandShake);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbo_databits);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbo_parity);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbo_Baud_rate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbo_serial_port_name);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CustomerDisplayModified";
            this.Text = "CustomerDisplayModified";
            this.Load += new System.EventHandler(this.CustomerDisplayModified_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbo_RTS_enable;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbo_HandShake;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbo_databits;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbo_parity;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbo_Baud_rate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbo_serial_port_name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbo_status;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_test_port;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox txt_text;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton rbtn_price;
        private System.Windows.Forms.RadioButton rbtn_total;
        private System.Windows.Forms.RadioButton rbtn_collection;
        private System.Windows.Forms.RadioButton rbtn_change;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rbtn_vfd;
    }
}