namespace POS_System.Bakery
{
    partial class OrderDetailsForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_shape = new System.Windows.Forms.TextBox();
            this.txt_advance_amount = new System.Windows.Forms.TextBox();
            this.txt_note = new System.Windows.Forms.TextBox();
            this.txt_message = new System.Windows.Forms.TextBox();
            this.cbo_coating_type = new System.Windows.Forms.ComboBox();
            this.btn_save = new DevComponents.DotNetBar.ButtonX();
            this.dtp_date = new System.Windows.Forms.DateTimePicker();
            this.cbo_minuts_from = new System.Windows.Forms.ComboBox();
            this.cbo_from_hours = new System.Windows.Forms.ComboBox();
            this.rbtn_Cash = new System.Windows.Forms.RadioButton();
            this.rbtn_card = new System.Windows.Forms.RadioButton();
            this.btn_print_and_save = new DevComponents.DotNetBar.ButtonX();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label24 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Shape";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Receving Time";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 173);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Message";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 254);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Coating Type";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 286);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Advance Amount";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 311);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Payment Mode";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 336);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(30, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Note";
            // 
            // txt_shape
            // 
            this.txt_shape.Location = new System.Drawing.Point(124, 109);
            this.txt_shape.Name = "txt_shape";
            this.txt_shape.Size = new System.Drawing.Size(221, 20);
            this.txt_shape.TabIndex = 0;
            // 
            // txt_advance_amount
            // 
            this.txt_advance_amount.Location = new System.Drawing.Point(124, 279);
            this.txt_advance_amount.Name = "txt_advance_amount";
            this.txt_advance_amount.Size = new System.Drawing.Size(221, 20);
            this.txt_advance_amount.TabIndex = 6;
            this.txt_advance_amount.Text = "0.00";
            this.txt_advance_amount.Enter += new System.EventHandler(this.txt_advance_amount_Enter);
            this.txt_advance_amount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_advance_amount_KeyPress);
            this.txt_advance_amount.Leave += new System.EventHandler(this.txt_advance_amount_Leave);
            // 
            // txt_note
            // 
            this.txt_note.Location = new System.Drawing.Point(124, 333);
            this.txt_note.Name = "txt_note";
            this.txt_note.Size = new System.Drawing.Size(221, 20);
            this.txt_note.TabIndex = 9;
            // 
            // txt_message
            // 
            this.txt_message.Location = new System.Drawing.Point(124, 173);
            this.txt_message.Multiline = true;
            this.txt_message.Name = "txt_message";
            this.txt_message.Size = new System.Drawing.Size(221, 68);
            this.txt_message.TabIndex = 4;
            // 
            // cbo_coating_type
            // 
            this.cbo_coating_type.FormattingEnabled = true;
            this.cbo_coating_type.Items.AddRange(new object[] {
            "1st Coating",
            "2nd Coating"});
            this.cbo_coating_type.Location = new System.Drawing.Point(124, 249);
            this.cbo_coating_type.Name = "cbo_coating_type";
            this.cbo_coating_type.Size = new System.Drawing.Size(221, 21);
            this.cbo_coating_type.TabIndex = 5;
            // 
            // btn_save
            // 
            this.btn_save.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_save.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btn_save.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.btn_save.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save.Location = new System.Drawing.Point(235, 360);
            this.btn_save.Name = "btn_save";
            this.btn_save.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(15);
            this.btn_save.Size = new System.Drawing.Size(115, 57);
            this.btn_save.TabIndex = 10;
            this.btn_save.Text = "Save";
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // dtp_date
            // 
            this.dtp_date.Location = new System.Drawing.Point(124, 142);
            this.dtp_date.Name = "dtp_date";
            this.dtp_date.Size = new System.Drawing.Size(124, 20);
            this.dtp_date.TabIndex = 1;
            // 
            // cbo_minuts_from
            // 
            this.cbo_minuts_from.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_minuts_from.FormattingEnabled = true;
            this.cbo_minuts_from.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59",
            "60",
            "00"});
            this.cbo_minuts_from.Location = new System.Drawing.Point(305, 138);
            this.cbo_minuts_from.Name = "cbo_minuts_from";
            this.cbo_minuts_from.Size = new System.Drawing.Size(40, 28);
            this.cbo_minuts_from.TabIndex = 3;
            // 
            // cbo_from_hours
            // 
            this.cbo_from_hours.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_from_hours.FormattingEnabled = true;
            this.cbo_from_hours.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "00"});
            this.cbo_from_hours.Location = new System.Drawing.Point(256, 138);
            this.cbo_from_hours.Name = "cbo_from_hours";
            this.cbo_from_hours.Size = new System.Drawing.Size(39, 28);
            this.cbo_from_hours.TabIndex = 2;
            // 
            // rbtn_Cash
            // 
            this.rbtn_Cash.AutoSize = true;
            this.rbtn_Cash.Checked = true;
            this.rbtn_Cash.Location = new System.Drawing.Point(124, 308);
            this.rbtn_Cash.Name = "rbtn_Cash";
            this.rbtn_Cash.Size = new System.Drawing.Size(49, 17);
            this.rbtn_Cash.TabIndex = 7;
            this.rbtn_Cash.TabStop = true;
            this.rbtn_Cash.Text = "Cash";
            this.rbtn_Cash.UseVisualStyleBackColor = true;
            this.rbtn_Cash.CheckedChanged += new System.EventHandler(this.rbtn_Cash_CheckedChanged);
            // 
            // rbtn_card
            // 
            this.rbtn_card.AutoSize = true;
            this.rbtn_card.Location = new System.Drawing.Point(210, 309);
            this.rbtn_card.Name = "rbtn_card";
            this.rbtn_card.Size = new System.Drawing.Size(47, 17);
            this.rbtn_card.TabIndex = 8;
            this.rbtn_card.TabStop = true;
            this.rbtn_card.Text = "Card";
            this.rbtn_card.UseVisualStyleBackColor = true;
            this.rbtn_card.CheckedChanged += new System.EventHandler(this.rbtn_card_CheckedChanged);
            // 
            // btn_print_and_save
            // 
            this.btn_print_and_save.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_print_and_save.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btn_print_and_save.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_print_and_save.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_print_and_save.Location = new System.Drawing.Point(114, 361);
            this.btn_print_and_save.Name = "btn_print_and_save";
            this.btn_print_and_save.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(15);
            this.btn_print_and_save.Size = new System.Drawing.Size(115, 57);
            this.btn_print_and_save.TabIndex = 11;
            this.btn_print_and_save.Text = "Print and Save";
            this.btn_print_and_save.Click += new System.EventHandler(this.btn_print_and_save_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(81)))), ((int)(((byte)(126)))));
            this.panel2.Controls.Add(this.label24);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(357, 59);
            this.panel2.TabIndex = 311;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label24.ForeColor = System.Drawing.Color.White;
            this.label24.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label24.Location = new System.Drawing.Point(95, 14);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(174, 31);
            this.label24.TabIndex = 6;
            this.label24.Text = "Order Details";
            // 
            // OrderDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 429);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btn_print_and_save);
            this.Controls.Add(this.rbtn_card);
            this.Controls.Add(this.rbtn_Cash);
            this.Controls.Add(this.cbo_minuts_from);
            this.Controls.Add(this.cbo_from_hours);
            this.Controls.Add(this.dtp_date);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.cbo_coating_type);
            this.Controls.Add(this.txt_message);
            this.Controls.Add(this.txt_note);
            this.Controls.Add(this.txt_advance_amount);
            this.Controls.Add(this.txt_shape);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OrderDetailsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OrderDetailsForm";
            this.Load += new System.EventHandler(this.OrderDetailsForm_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_shape;
        private System.Windows.Forms.TextBox txt_advance_amount;
        private System.Windows.Forms.TextBox txt_note;
        private System.Windows.Forms.TextBox txt_message;
        private System.Windows.Forms.ComboBox cbo_coating_type;
        private DevComponents.DotNetBar.ButtonX btn_save;
        private System.Windows.Forms.DateTimePicker dtp_date;
        private System.Windows.Forms.ComboBox cbo_minuts_from;
        private System.Windows.Forms.ComboBox cbo_from_hours;
        private System.Windows.Forms.RadioButton rbtn_Cash;
        private System.Windows.Forms.RadioButton rbtn_card;
        private DevComponents.DotNetBar.ButtonX btn_print_and_save;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label24;
    }
}