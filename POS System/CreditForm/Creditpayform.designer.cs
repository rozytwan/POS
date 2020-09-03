namespace POS_System
{
    partial class Creditpayform
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbn_cheque = new System.Windows.Forms.RadioButton();
            this.rbn_card = new System.Windows.Forms.RadioButton();
            this.rbn_cash = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_remaining = new System.Windows.Forms.TextBox();
            this.Edit = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_remain = new System.Windows.Forms.TextBox();
            this.rdo_partial = new System.Windows.Forms.RadioButton();
            this.rdo_full = new System.Windows.Forms.RadioButton();
            this.lbl_Payment = new System.Windows.Forms.Label();
            this.txt_payment = new System.Windows.Forms.TextBox();
            this.txt_allitems = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lbl_customerId = new System.Windows.Forms.Label();
            this.lbl_bill_no = new System.Windows.Forms.Label();
            this.lbl_names = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_checkedby = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_save = new System.Windows.Forms.Button();
            this.txt_amount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txt_remaining);
            this.groupBox1.Controls.Add(this.Edit);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txt_remain);
            this.groupBox1.Controls.Add(this.rdo_partial);
            this.groupBox1.Controls.Add(this.rdo_full);
            this.groupBox1.Controls.Add(this.lbl_Payment);
            this.groupBox1.Controls.Add(this.txt_payment);
            this.groupBox1.Controls.Add(this.txt_allitems);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.lbl_customerId);
            this.groupBox1.Controls.Add(this.lbl_bill_no);
            this.groupBox1.Controls.Add(this.lbl_names);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txt_checkedby);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btn_save);
            this.groupBox1.Controls.Add(this.txt_amount);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(1, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(383, 378);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbn_cheque);
            this.panel1.Controls.Add(this.rbn_card);
            this.panel1.Controls.Add(this.rbn_cash);
            this.panel1.Location = new System.Drawing.Point(124, 164);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(217, 38);
            this.panel1.TabIndex = 26;
            // 
            // rbn_cheque
            // 
            this.rbn_cheque.AutoSize = true;
            this.rbn_cheque.Location = new System.Drawing.Point(74, 11);
            this.rbn_cheque.Name = "rbn_cheque";
            this.rbn_cheque.Size = new System.Drawing.Size(62, 17);
            this.rbn_cheque.TabIndex = 28;
            this.rbn_cheque.Text = "Cheque";
            this.rbn_cheque.UseVisualStyleBackColor = true;
            this.rbn_cheque.Click += new System.EventHandler(this.rbn_cheque_Click);
            // 
            // rbn_card
            // 
            this.rbn_card.AutoSize = true;
            this.rbn_card.Location = new System.Drawing.Point(165, 11);
            this.rbn_card.Name = "rbn_card";
            this.rbn_card.Size = new System.Drawing.Size(47, 17);
            this.rbn_card.TabIndex = 27;
            this.rbn_card.Text = "Card";
            this.rbn_card.UseVisualStyleBackColor = true;
            // 
            // rbn_cash
            // 
            this.rbn_cash.AutoSize = true;
            this.rbn_cash.Checked = true;
            this.rbn_cash.Location = new System.Drawing.Point(6, 11);
            this.rbn_cash.Name = "rbn_cash";
            this.rbn_cash.Size = new System.Drawing.Size(49, 17);
            this.rbn_cash.TabIndex = 26;
            this.rbn_cash.TabStop = true;
            this.rbn_cash.Text = "Cash";
            this.rbn_cash.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 178);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 20);
            this.label4.TabIndex = 23;
            this.label4.Text = "Paymet Mode";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 96);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 20);
            this.label6.TabIndex = 22;
            this.label6.Text = "Remaining";
            // 
            // txt_remaining
            // 
            this.txt_remaining.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_remaining.Location = new System.Drawing.Point(124, 95);
            this.txt_remaining.Name = "txt_remaining";
            this.txt_remaining.ReadOnly = true;
            this.txt_remaining.Size = new System.Drawing.Size(214, 26);
            this.txt_remaining.TabIndex = 21;
            // 
            // Edit
            // 
            this.Edit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(81)))), ((int)(((byte)(126)))));
            this.Edit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Edit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Edit.ForeColor = System.Drawing.Color.White;
            this.Edit.Location = new System.Drawing.Point(236, 312);
            this.Edit.Name = "Edit";
            this.Edit.Size = new System.Drawing.Size(93, 38);
            this.Edit.TabIndex = 20;
            this.Edit.Text = "Edit";
            this.Edit.UseVisualStyleBackColor = false;
            this.Edit.Click += new System.EventHandler(this.Edit_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(-1, 242);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 20);
            this.label5.TabIndex = 18;
            this.label5.Text = "Remain Charge:";
            // 
            // txt_remain
            // 
            this.txt_remain.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_remain.Location = new System.Drawing.Point(127, 240);
            this.txt_remain.Name = "txt_remain";
            this.txt_remain.Size = new System.Drawing.Size(214, 26);
            this.txt_remain.TabIndex = 17;
            // 
            // rdo_partial
            // 
            this.rdo_partial.AutoSize = true;
            this.rdo_partial.Checked = true;
            this.rdo_partial.Location = new System.Drawing.Point(130, 141);
            this.rdo_partial.Name = "rdo_partial";
            this.rdo_partial.Size = new System.Drawing.Size(75, 17);
            this.rdo_partial.TabIndex = 16;
            this.rdo_partial.TabStop = true;
            this.rdo_partial.Text = "Partial Pay";
            this.rdo_partial.UseVisualStyleBackColor = true;
            this.rdo_partial.Click += new System.EventHandler(this.rdo_partial_Click);
            // 
            // rdo_full
            // 
            this.rdo_full.AutoSize = true;
            this.rdo_full.Location = new System.Drawing.Point(212, 141);
            this.rdo_full.Name = "rdo_full";
            this.rdo_full.Size = new System.Drawing.Size(62, 17);
            this.rdo_full.TabIndex = 15;
            this.rdo_full.TabStop = true;
            this.rdo_full.Text = "Full Pay";
            this.rdo_full.UseVisualStyleBackColor = true;
            this.rdo_full.Click += new System.EventHandler(this.rdo_full_Click);
            // 
            // lbl_Payment
            // 
            this.lbl_Payment.AutoSize = true;
            this.lbl_Payment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Payment.Location = new System.Drawing.Point(48, 209);
            this.lbl_Payment.Name = "lbl_Payment";
            this.lbl_Payment.Size = new System.Drawing.Size(65, 20);
            this.lbl_Payment.TabIndex = 14;
            this.lbl_Payment.Text = "Amount";
            // 
            // txt_payment
            // 
            this.txt_payment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_payment.Location = new System.Drawing.Point(127, 208);
            this.txt_payment.Name = "txt_payment";
            this.txt_payment.Size = new System.Drawing.Size(214, 26);
            this.txt_payment.TabIndex = 13;
            this.txt_payment.TextChanged += new System.EventHandler(this.txt_payment_TextChanged);
            this.txt_payment.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_payment_KeyPress);
            // 
            // txt_allitems
            // 
            this.txt_allitems.Location = new System.Drawing.Point(209, 11);
            this.txt_allitems.Multiline = true;
            this.txt_allitems.Name = "txt_allitems";
            this.txt_allitems.Size = new System.Drawing.Size(117, 46);
            this.txt_allitems.TabIndex = 12;
            this.txt_allitems.Visible = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(342, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(32, 31);
            this.button1.TabIndex = 11;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbl_customerId
            // 
            this.lbl_customerId.AutoSize = true;
            this.lbl_customerId.Location = new System.Drawing.Point(7, 326);
            this.lbl_customerId.Name = "lbl_customerId";
            this.lbl_customerId.Size = new System.Drawing.Size(16, 13);
            this.lbl_customerId.TabIndex = 10;
            this.lbl_customerId.Text = "Id";
            this.lbl_customerId.Visible = false;
            // 
            // lbl_bill_no
            // 
            this.lbl_bill_no.AutoSize = true;
            this.lbl_bill_no.Location = new System.Drawing.Point(35, 326);
            this.lbl_bill_no.Name = "lbl_bill_no";
            this.lbl_bill_no.Size = new System.Drawing.Size(35, 13);
            this.lbl_bill_no.TabIndex = 9;
            this.lbl_bill_no.Text = "label5";
            this.lbl_bill_no.Visible = false;
            // 
            // lbl_names
            // 
            this.lbl_names.AutoSize = true;
            this.lbl_names.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_names.Location = new System.Drawing.Point(9, 39);
            this.lbl_names.Name = "lbl_names";
            this.lbl_names.Size = new System.Drawing.Size(58, 18);
            this.lbl_names.TabIndex = 8;
            this.lbl_names.Text = "names";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(20, 274);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Checked By:";
            // 
            // txt_checkedby
            // 
            this.txt_checkedby.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_checkedby.Location = new System.Drawing.Point(124, 274);
            this.txt_checkedby.Name = "txt_checkedby";
            this.txt_checkedby.Size = new System.Drawing.Size(217, 26);
            this.txt_checkedby.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Credit Amount:";
            // 
            // btn_save
            // 
            this.btn_save.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(81)))), ((int)(((byte)(126)))));
            this.btn_save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_save.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save.ForeColor = System.Drawing.Color.White;
            this.btn_save.Location = new System.Drawing.Point(124, 312);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(93, 38);
            this.btn_save.TabIndex = 2;
            this.btn_save.Text = "Save";
            this.btn_save.UseVisualStyleBackColor = false;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // txt_amount
            // 
            this.txt_amount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_amount.Location = new System.Drawing.Point(124, 63);
            this.txt_amount.Name = "txt_amount";
            this.txt_amount.ReadOnly = true;
            this.txt_amount.Size = new System.Drawing.Size(214, 26);
            this.txt_amount.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(81)))), ((int)(((byte)(126)))));
            this.label1.Location = new System.Drawing.Point(6, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Credit Amount Left for:";
            // 
            // Creditpayform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(81)))), ((int)(((byte)(126)))));
            this.ClientSize = new System.Drawing.Size(384, 377);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Creditpayform";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Creditpayform";
            this.Load += new System.EventHandler(this.Creditpayform_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txt_checkedby;
        public System.Windows.Forms.Button btn_save;
        public System.Windows.Forms.TextBox txt_amount;
        public System.Windows.Forms.Label lbl_names;
        public System.Windows.Forms.Label lbl_bill_no;
        public System.Windows.Forms.Label lbl_customerId;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.TextBox txt_allitems;
        private System.Windows.Forms.Label lbl_Payment;
        public System.Windows.Forms.TextBox txt_payment;
        private System.Windows.Forms.RadioButton rdo_partial;
        private System.Windows.Forms.RadioButton rdo_full;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox txt_remain;
        public System.Windows.Forms.Button Edit;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox txt_remaining;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rbn_card;
        private System.Windows.Forms.RadioButton rbn_cash;
        private System.Windows.Forms.RadioButton rbn_cheque;
    }
}