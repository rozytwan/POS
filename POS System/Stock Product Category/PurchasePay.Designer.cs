﻿namespace POS_System
{
    partial class PurchasePay
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
            this.rbn_card = new System.Windows.Forms.RadioButton();
            this.rbn_cash = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_remaining = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_remain = new System.Windows.Forms.TextBox();
            this.rdo_partial = new System.Windows.Forms.RadioButton();
            this.rdo_full = new System.Windows.Forms.RadioButton();
            this.lbl_Payment = new System.Windows.Forms.Label();
            this.txt_payment = new System.Windows.Forms.TextBox();
            this.txt_allitems = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lbl_bill_no = new System.Windows.Forms.Label();
            this.lbl_names = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_checkedby = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_save = new System.Windows.Forms.Button();
            this.txt_amount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txt_remaining);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txt_remain);
            this.panel1.Controls.Add(this.rdo_partial);
            this.panel1.Controls.Add(this.rdo_full);
            this.panel1.Controls.Add(this.lbl_Payment);
            this.panel1.Controls.Add(this.txt_payment);
            this.panel1.Controls.Add(this.txt_allitems);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.lbl_bill_no);
            this.panel1.Controls.Add(this.lbl_names);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txt_checkedby);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btn_save);
            this.panel1.Controls.Add(this.txt_amount);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(2, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(360, 420);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rbn_card);
            this.panel2.Controls.Add(this.rbn_cash);
            this.panel2.Location = new System.Drawing.Point(127, 162);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(205, 38);
            this.panel2.TabIndex = 47;
            // 
            // rbn_card
            // 
            this.rbn_card.AutoSize = true;
            this.rbn_card.Location = new System.Drawing.Point(88, 11);
            this.rbn_card.Name = "rbn_card";
            this.rbn_card.Size = new System.Drawing.Size(62, 17);
            this.rbn_card.TabIndex = 27;
            this.rbn_card.Text = "Cheque";
            this.rbn_card.UseVisualStyleBackColor = true;
            this.rbn_card.CheckedChanged += new System.EventHandler(this.rbn_card_CheckedChanged);
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
            this.label4.Location = new System.Drawing.Point(15, 176);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 20);
            this.label4.TabIndex = 46;
            this.label4.Text = "Paymet Mode";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(9, 94);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 20);
            this.label6.TabIndex = 45;
            this.label6.Text = "Remaining";
            // 
            // txt_remaining
            // 
            this.txt_remaining.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_remaining.Location = new System.Drawing.Point(127, 93);
            this.txt_remaining.Name = "txt_remaining";
            this.txt_remaining.ReadOnly = true;
            this.txt_remaining.Size = new System.Drawing.Size(202, 26);
            this.txt_remaining.TabIndex = 44;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(2, 240);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 20);
            this.label5.TabIndex = 42;
            this.label5.Text = "Remain Charge:";
            // 
            // txt_remain
            // 
            this.txt_remain.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_remain.Location = new System.Drawing.Point(130, 238);
            this.txt_remain.Name = "txt_remain";
            this.txt_remain.Size = new System.Drawing.Size(202, 26);
            this.txt_remain.TabIndex = 41;
            // 
            // rdo_partial
            // 
            this.rdo_partial.AutoSize = true;
            this.rdo_partial.Checked = true;
            this.rdo_partial.Location = new System.Drawing.Point(133, 139);
            this.rdo_partial.Name = "rdo_partial";
            this.rdo_partial.Size = new System.Drawing.Size(75, 17);
            this.rdo_partial.TabIndex = 40;
            this.rdo_partial.TabStop = true;
            this.rdo_partial.Text = "Partial Pay";
            this.rdo_partial.UseVisualStyleBackColor = true;
            // 
            // rdo_full
            // 
            this.rdo_full.AutoSize = true;
            this.rdo_full.Location = new System.Drawing.Point(215, 139);
            this.rdo_full.Name = "rdo_full";
            this.rdo_full.Size = new System.Drawing.Size(62, 17);
            this.rdo_full.TabIndex = 39;
            this.rdo_full.TabStop = true;
            this.rdo_full.Text = "Full Pay";
            this.rdo_full.UseVisualStyleBackColor = true;
            this.rdo_full.Click += new System.EventHandler(this.rdo_full_Click);
            // 
            // lbl_Payment
            // 
            this.lbl_Payment.AutoSize = true;
            this.lbl_Payment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Payment.Location = new System.Drawing.Point(51, 207);
            this.lbl_Payment.Name = "lbl_Payment";
            this.lbl_Payment.Size = new System.Drawing.Size(65, 20);
            this.lbl_Payment.TabIndex = 38;
            this.lbl_Payment.Text = "Amount";
            // 
            // txt_payment
            // 
            this.txt_payment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_payment.Location = new System.Drawing.Point(130, 206);
            this.txt_payment.Name = "txt_payment";
            this.txt_payment.Size = new System.Drawing.Size(202, 26);
            this.txt_payment.TabIndex = 37;
            this.txt_payment.TextChanged += new System.EventHandler(this.txt_payment_TextChanged);
            this.txt_payment.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_payment_KeyPress);
            // 
            // txt_allitems
            // 
            this.txt_allitems.Location = new System.Drawing.Point(212, 9);
            this.txt_allitems.Multiline = true;
            this.txt_allitems.Name = "txt_allitems";
            this.txt_allitems.Size = new System.Drawing.Size(83, 46);
            this.txt_allitems.TabIndex = 36;
            this.txt_allitems.Visible = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(325, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(32, 31);
            this.button1.TabIndex = 35;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbl_bill_no
            // 
            this.lbl_bill_no.AutoSize = true;
            this.lbl_bill_no.Location = new System.Drawing.Point(10, 392);
            this.lbl_bill_no.Name = "lbl_bill_no";
            this.lbl_bill_no.Size = new System.Drawing.Size(0, 13);
            this.lbl_bill_no.TabIndex = 34;
            this.lbl_bill_no.Visible = false;
            // 
            // lbl_names
            // 
            this.lbl_names.AutoSize = true;
            this.lbl_names.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_names.Location = new System.Drawing.Point(12, 37);
            this.lbl_names.Name = "lbl_names";
            this.lbl_names.Size = new System.Drawing.Size(58, 18);
            this.lbl_names.TabIndex = 33;
            this.lbl_names.Text = "names";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(23, 272);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 20);
            this.label3.TabIndex = 32;
            this.label3.Text = "Checked By:";
            // 
            // txt_checkedby
            // 
            this.txt_checkedby.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_checkedby.Location = new System.Drawing.Point(127, 272);
            this.txt_checkedby.Name = "txt_checkedby";
            this.txt_checkedby.Size = new System.Drawing.Size(205, 26);
            this.txt_checkedby.TabIndex = 31;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 20);
            this.label2.TabIndex = 30;
            this.label2.Text = "Purchase Amt:";
            // 
            // btn_save
            // 
            this.btn_save.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(81)))), ((int)(((byte)(126)))));
            this.btn_save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_save.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save.ForeColor = System.Drawing.Color.White;
            this.btn_save.Location = new System.Drawing.Point(226, 319);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(93, 38);
            this.btn_save.TabIndex = 29;
            this.btn_save.Text = "Save";
            this.btn_save.UseVisualStyleBackColor = false;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // txt_amount
            // 
            this.txt_amount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_amount.Location = new System.Drawing.Point(127, 61);
            this.txt_amount.Name = "txt_amount";
            this.txt_amount.ReadOnly = true;
            this.txt_amount.Size = new System.Drawing.Size(202, 26);
            this.txt_amount.TabIndex = 28;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(81)))), ((int)(((byte)(126)))));
            this.label1.Location = new System.Drawing.Point(9, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 18);
            this.label1.TabIndex = 27;
            this.label1.Text = "Purchase Credit Amount :";
            // 
            // PurchasePay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 426);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PurchasePay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.PurchasePay_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rbn_card;
        private System.Windows.Forms.RadioButton rbn_cash;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox txt_remaining;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox txt_remain;
        private System.Windows.Forms.RadioButton rdo_partial;
        private System.Windows.Forms.RadioButton rdo_full;
        private System.Windows.Forms.Label lbl_Payment;
        public System.Windows.Forms.TextBox txt_payment;
        public System.Windows.Forms.TextBox txt_allitems;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.Label lbl_bill_no;
        public System.Windows.Forms.Label lbl_names;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txt_checkedby;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Button btn_save;
        public System.Windows.Forms.TextBox txt_amount;
        private System.Windows.Forms.Label label1;
    }
}