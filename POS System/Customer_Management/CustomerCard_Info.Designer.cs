namespace POS_System.Customer_Management
{
    partial class CustomerCard_Info
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
            this.label23 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel_fix = new System.Windows.Forms.Panel();
            this.txt_fix_blc = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chk_fix = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbn_credit = new System.Windows.Forms.RadioButton();
            this.rbn_atmcard = new System.Windows.Forms.RadioButton();
            this.rbn_cash = new System.Windows.Forms.RadioButton();
            this.lbl_card_no = new System.Windows.Forms.Label();
            this.txt_fix_spend = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rdo_non_refundable = new System.Windows.Forms.RadioButton();
            this.rdo_refundable = new System.Windows.Forms.RadioButton();
            this.txt_pre_balance = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_card_type = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_add = new DevComponents.DotNetBar.ButtonX();
            this.txt_card_balance = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.lbl_cutomerId = new System.Windows.Forms.Label();
            this.txt_name = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.panel_remarks = new System.Windows.Forms.Panel();
            this.txt_remarks = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel_fix.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel_remarks.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(81)))), ((int)(((byte)(126)))));
            this.panel2.Controls.Add(this.label23);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(375, 54);
            this.panel2.TabIndex = 116;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.White;
            this.label23.Location = new System.Drawing.Point(99, 9);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(167, 31);
            this.label23.TabIndex = 21;
            this.label23.Text = "Balance Add";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.panel_remarks);
            this.groupBox1.Controls.Add(this.panel_fix);
            this.groupBox1.Controls.Add(this.btn_add);
            this.groupBox1.Controls.Add(this.chk_fix);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.lbl_card_no);
            this.groupBox1.Controls.Add(this.txt_fix_spend);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.rdo_non_refundable);
            this.groupBox1.Controls.Add(this.rdo_refundable);
            this.groupBox1.Controls.Add(this.txt_pre_balance);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txt_card_type);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txt_card_balance);
            this.groupBox1.Controls.Add(this.label26);
            this.groupBox1.Controls.Add(this.lbl_cutomerId);
            this.groupBox1.Controls.Add(this.txt_name);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 54);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(375, 485);
            this.groupBox1.TabIndex = 127;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Balance Info";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // panel_fix
            // 
            this.panel_fix.Controls.Add(this.txt_fix_blc);
            this.panel_fix.Controls.Add(this.label4);
            this.panel_fix.Location = new System.Drawing.Point(18, 353);
            this.panel_fix.Name = "panel_fix";
            this.panel_fix.Size = new System.Drawing.Size(354, 39);
            this.panel_fix.TabIndex = 187;
            // 
            // txt_fix_blc
            // 
            this.txt_fix_blc.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_fix_blc.Location = new System.Drawing.Point(133, 3);
            this.txt_fix_blc.Name = "txt_fix_blc";
            this.txt_fix_blc.Size = new System.Drawing.Size(215, 29);
            this.txt_fix_blc.TabIndex = 185;
            this.txt_fix_blc.Text = "0.00";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(35, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 18);
            this.label4.TabIndex = 184;
            this.label4.Text = "Fix Balance :";
            // 
            // chk_fix
            // 
            this.chk_fix.AutoSize = true;
            this.chk_fix.BackColor = System.Drawing.Color.White;
            this.chk_fix.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_fix.ForeColor = System.Drawing.Color.Black;
            this.chk_fix.Location = new System.Drawing.Point(26, 325);
            this.chk_fix.Name = "chk_fix";
            this.chk_fix.Size = new System.Drawing.Size(129, 22);
            this.chk_fix.TabIndex = 186;
            this.chk_fix.Text = "Set Fix Balance";
            this.chk_fix.UseVisualStyleBackColor = false;
            this.chk_fix.Click += new System.EventHandler(this.chk_fix_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbn_credit);
            this.panel1.Controls.Add(this.rbn_atmcard);
            this.panel1.Controls.Add(this.rbn_cash);
            this.panel1.Location = new System.Drawing.Point(62, 173);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(307, 33);
            this.panel1.TabIndex = 183;
            // 
            // rbn_credit
            // 
            this.rbn_credit.AutoSize = true;
            this.rbn_credit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(81)))), ((int)(((byte)(126)))));
            this.rbn_credit.ForeColor = System.Drawing.Color.White;
            this.rbn_credit.Location = new System.Drawing.Point(219, 3);
            this.rbn_credit.Name = "rbn_credit";
            this.rbn_credit.Size = new System.Drawing.Size(85, 24);
            this.rbn_credit.TabIndex = 185;
            this.rbn_credit.Text = "Credit    ";
            this.rbn_credit.UseVisualStyleBackColor = false;
            // 
            // rbn_atmcard
            // 
            this.rbn_atmcard.AutoSize = true;
            this.rbn_atmcard.BackColor = System.Drawing.Color.Red;
            this.rbn_atmcard.ForeColor = System.Drawing.Color.White;
            this.rbn_atmcard.Location = new System.Drawing.Point(115, 3);
            this.rbn_atmcard.Name = "rbn_atmcard";
            this.rbn_atmcard.Size = new System.Drawing.Size(98, 24);
            this.rbn_atmcard.TabIndex = 184;
            this.rbn_atmcard.Text = "ATM Card";
            this.rbn_atmcard.UseVisualStyleBackColor = false;
            // 
            // rbn_cash
            // 
            this.rbn_cash.AutoSize = true;
            this.rbn_cash.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.rbn_cash.Checked = true;
            this.rbn_cash.ForeColor = System.Drawing.Color.White;
            this.rbn_cash.Location = new System.Drawing.Point(5, 3);
            this.rbn_cash.Name = "rbn_cash";
            this.rbn_cash.Size = new System.Drawing.Size(104, 24);
            this.rbn_cash.TabIndex = 183;
            this.rbn_cash.TabStop = true;
            this.rbn_cash.Text = "Cash          ";
            this.rbn_cash.UseVisualStyleBackColor = false;
            // 
            // lbl_card_no
            // 
            this.lbl_card_no.AutoSize = true;
            this.lbl_card_no.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_card_no.Location = new System.Drawing.Point(136, 22);
            this.lbl_card_no.Name = "lbl_card_no";
            this.lbl_card_no.Size = new System.Drawing.Size(19, 16);
            this.lbl_card_no.TabIndex = 180;
            this.lbl_card_no.Text = "Id";
            // 
            // txt_fix_spend
            // 
            this.txt_fix_spend.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_fix_spend.Location = new System.Drawing.Point(144, 294);
            this.txt_fix_spend.Name = "txt_fix_spend";
            this.txt_fix_spend.Size = new System.Drawing.Size(222, 29);
            this.txt_fix_spend.TabIndex = 179;
            this.txt_fix_spend.Text = "0.00";
            this.txt_fix_spend.Enter += new System.EventHandler(this.txt_fix_spend_Enter);
            this.txt_fix_spend.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_fix_spend_KeyPress);
            this.txt_fix_spend.Leave += new System.EventHandler(this.txt_fix_spend_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(47, 301);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 18);
            this.label3.TabIndex = 178;
            this.label3.Text = "Fix Spend :";
            // 
            // rdo_non_refundable
            // 
            this.rdo_non_refundable.AutoSize = true;
            this.rdo_non_refundable.Location = new System.Drawing.Point(108, 264);
            this.rdo_non_refundable.Name = "rdo_non_refundable";
            this.rdo_non_refundable.Size = new System.Drawing.Size(143, 24);
            this.rdo_non_refundable.TabIndex = 177;
            this.rdo_non_refundable.Text = "Non Refundable";
            this.rdo_non_refundable.UseVisualStyleBackColor = true;
            this.rdo_non_refundable.CheckedChanged += new System.EventHandler(this.rdo_non_refundable_CheckedChanged);
            this.rdo_non_refundable.Click += new System.EventHandler(this.rdo_non_refundable_Click);
            // 
            // rdo_refundable
            // 
            this.rdo_refundable.AutoSize = true;
            this.rdo_refundable.Checked = true;
            this.rdo_refundable.Location = new System.Drawing.Point(257, 264);
            this.rdo_refundable.Name = "rdo_refundable";
            this.rdo_refundable.Size = new System.Drawing.Size(110, 24);
            this.rdo_refundable.TabIndex = 176;
            this.rdo_refundable.TabStop = true;
            this.rdo_refundable.Text = "Refundable";
            this.rdo_refundable.UseVisualStyleBackColor = true;
            this.rdo_refundable.CheckedChanged += new System.EventHandler(this.rdo_refundable_CheckedChanged);
            this.rdo_refundable.Click += new System.EventHandler(this.rdo_refundable_Click);
            // 
            // txt_pre_balance
            // 
            this.txt_pre_balance.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_pre_balance.Location = new System.Drawing.Point(147, 138);
            this.txt_pre_balance.Name = "txt_pre_balance";
            this.txt_pre_balance.ReadOnly = true;
            this.txt_pre_balance.Size = new System.Drawing.Size(222, 29);
            this.txt_pre_balance.TabIndex = 175;
            this.txt_pre_balance.Text = "0.00";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 18);
            this.label2.TabIndex = 174;
            this.label2.Text = "Previous Balance :";
            // 
            // txt_card_type
            // 
            this.txt_card_type.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_card_type.Location = new System.Drawing.Point(147, 94);
            this.txt_card_type.Name = "txt_card_type";
            this.txt_card_type.ReadOnly = true;
            this.txt_card_type.Size = new System.Drawing.Size(222, 29);
            this.txt_card_type.TabIndex = 173;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(47, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 18);
            this.label1.TabIndex = 172;
            this.label1.Text = "Card Type:";
            // 
            // btn_add
            // 
            this.btn_add.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_add.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btn_add.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add.Location = new System.Drawing.Point(253, 398);
            this.btn_add.Name = "btn_add";
            this.btn_add.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(15);
            this.btn_add.Size = new System.Drawing.Size(116, 48);
            this.btn_add.Symbol = "";
            this.btn_add.TabIndex = 171;
            this.btn_add.Text = "ADD";
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // txt_card_balance
            // 
            this.txt_card_balance.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_card_balance.Location = new System.Drawing.Point(145, 220);
            this.txt_card_balance.Name = "txt_card_balance";
            this.txt_card_balance.Size = new System.Drawing.Size(222, 29);
            this.txt_card_balance.TabIndex = 121;
            this.txt_card_balance.Text = "0.00";
            this.txt_card_balance.Enter += new System.EventHandler(this.txt_card_balance_Enter);
            this.txt_card_balance.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_card_balance_KeyPress);
            this.txt_card_balance.Leave += new System.EventHandler(this.txt_card_balance_Leave);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(23, 227);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(105, 18);
            this.label26.TabIndex = 117;
            this.label26.Text = "Card Balance :";
            // 
            // lbl_cutomerId
            // 
            this.lbl_cutomerId.AutoSize = true;
            this.lbl_cutomerId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_cutomerId.Location = new System.Drawing.Point(35, 22);
            this.lbl_cutomerId.Name = "lbl_cutomerId";
            this.lbl_cutomerId.Size = new System.Drawing.Size(19, 16);
            this.lbl_cutomerId.TabIndex = 51;
            this.lbl_cutomerId.Text = "Id";
            // 
            // txt_name
            // 
            this.txt_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_name.Location = new System.Drawing.Point(147, 50);
            this.txt_name.Name = "txt_name";
            this.txt_name.ReadOnly = true;
            this.txt_name.Size = new System.Drawing.Size(222, 29);
            this.txt_name.TabIndex = 20;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(9, 57);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(122, 18);
            this.label16.TabIndex = 19;
            this.label16.Text = "Customer Name:";
            // 
            // panel_remarks
            // 
            this.panel_remarks.Controls.Add(this.label5);
            this.panel_remarks.Controls.Add(this.txt_remarks);
            this.panel_remarks.Location = new System.Drawing.Point(18, 398);
            this.panel_remarks.Name = "panel_remarks";
            this.panel_remarks.Size = new System.Drawing.Size(229, 72);
            this.panel_remarks.TabIndex = 188;
            // 
            // txt_remarks
            // 
            this.txt_remarks.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_remarks.Location = new System.Drawing.Point(3, 28);
            this.txt_remarks.Multiline = true;
            this.txt_remarks.Name = "txt_remarks";
            this.txt_remarks.Size = new System.Drawing.Size(223, 41);
            this.txt_remarks.TabIndex = 185;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(8, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 18);
            this.label5.TabIndex = 186;
            this.label5.Text = "Remarks :";
            // 
            // CustomerCard_Info
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 543);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CustomerCard_Info";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.CustomerCard_Info_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel_fix.ResumeLayout(false);
            this.panel_fix.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel_remarks.ResumeLayout(false);
            this.panel_remarks.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.TextBox txt_card_balance;
        private System.Windows.Forms.Label label26;
        public System.Windows.Forms.Label lbl_cutomerId;
        public System.Windows.Forms.TextBox txt_name;
        private System.Windows.Forms.Label label16;
        private DevComponents.DotNetBar.ButtonX btn_add;
        public System.Windows.Forms.TextBox txt_card_type;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txt_pre_balance;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label23;
        public System.Windows.Forms.TextBox txt_fix_spend;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rdo_refundable;
        public System.Windows.Forms.Label lbl_card_no;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rbn_atmcard;
        private System.Windows.Forms.RadioButton rbn_cash;
        private System.Windows.Forms.RadioButton rbn_credit;
        private System.Windows.Forms.Panel panel_fix;
        public System.Windows.Forms.TextBox txt_fix_blc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chk_fix;
        private System.Windows.Forms.RadioButton rdo_non_refundable;
        private System.Windows.Forms.Panel panel_remarks;
        public System.Windows.Forms.TextBox txt_remarks;
        private System.Windows.Forms.Label label5;
    }
}