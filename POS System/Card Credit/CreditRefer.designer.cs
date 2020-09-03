namespace POS_System

{
    partial class CreditRefer
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_phone = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmb_last = new System.Windows.Forms.ComboBox();
            this.cmb_first = new System.Windows.Forms.ComboBox();
            this.lbl_card_no = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_add = new DevComponents.DotNetBar.ButtonX();
            this.txt_refer_balance = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.lbl_cutomerId = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label23 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(2, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(340, 438);
            this.panel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.txt_phone);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmb_last);
            this.groupBox1.Controls.Add(this.cmb_first);
            this.groupBox1.Controls.Add(this.lbl_card_no);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btn_add);
            this.groupBox1.Controls.Add(this.txt_refer_balance);
            this.groupBox1.Controls.Add(this.label26);
            this.groupBox1.Controls.Add(this.lbl_cutomerId);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 71);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(334, 364);
            this.groupBox1.TabIndex = 128;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Balance Refer";
            // 
            // txt_phone
            // 
            this.txt_phone.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_phone.Location = new System.Drawing.Point(130, 157);
            this.txt_phone.Name = "txt_phone";
            this.txt_phone.Size = new System.Drawing.Size(198, 29);
            this.txt_phone.TabIndex = 184;
            this.txt_phone.TextChanged += new System.EventHandler(this.txt_phone_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(55, 164);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 18);
            this.label2.TabIndex = 183;
            this.label2.Text = "Phone :";
            // 
            // cmb_last
            // 
            this.cmb_last.FormattingEnabled = true;
            this.cmb_last.Location = new System.Drawing.Point(130, 114);
            this.cmb_last.Name = "cmb_last";
            this.cmb_last.Size = new System.Drawing.Size(198, 28);
            this.cmb_last.TabIndex = 182;
            this.cmb_last.SelectedIndexChanged += new System.EventHandler(this.cmb_last_SelectedIndexChanged);
            this.cmb_last.TextChanged += new System.EventHandler(this.cmb_last_TextChanged);
            this.cmb_last.Click += new System.EventHandler(this.cmb_last_Click);
            // 
            // cmb_first
            // 
            this.cmb_first.FormattingEnabled = true;
            this.cmb_first.Location = new System.Drawing.Point(130, 70);
            this.cmb_first.Name = "cmb_first";
            this.cmb_first.Size = new System.Drawing.Size(198, 28);
            this.cmb_first.TabIndex = 181;
            this.cmb_first.SelectedIndexChanged += new System.EventHandler(this.cmb_first_SelectedIndexChanged);
            // 
            // lbl_card_no
            // 
            this.lbl_card_no.AutoSize = true;
            this.lbl_card_no.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_card_no.Location = new System.Drawing.Point(109, 31);
            this.lbl_card_no.Name = "lbl_card_no";
            this.lbl_card_no.Size = new System.Drawing.Size(19, 16);
            this.lbl_card_no.TabIndex = 180;
            this.lbl_card_no.Text = "Id";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(30, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 18);
            this.label1.TabIndex = 172;
            this.label1.Text = "Last Name:";
            // 
            // btn_add
            // 
            this.btn_add.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_add.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btn_add.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add.Location = new System.Drawing.Point(212, 246);
            this.btn_add.Name = "btn_add";
            this.btn_add.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(15);
            this.btn_add.Size = new System.Drawing.Size(116, 48);
            this.btn_add.Symbol = "";
            this.btn_add.TabIndex = 171;
            this.btn_add.Text = "Refer";
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // txt_refer_balance
            // 
            this.txt_refer_balance.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_refer_balance.Location = new System.Drawing.Point(130, 202);
            this.txt_refer_balance.Name = "txt_refer_balance";
            this.txt_refer_balance.ReadOnly = true;
            this.txt_refer_balance.Size = new System.Drawing.Size(198, 29);
            this.txt_refer_balance.TabIndex = 121;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(7, 209);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(109, 18);
            this.label26.TabIndex = 117;
            this.label26.Text = "Refer Balance :";
            // 
            // lbl_cutomerId
            // 
            this.lbl_cutomerId.AutoSize = true;
            this.lbl_cutomerId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_cutomerId.Location = new System.Drawing.Point(27, 31);
            this.lbl_cutomerId.Name = "lbl_cutomerId";
            this.lbl_cutomerId.Size = new System.Drawing.Size(19, 16);
            this.lbl_cutomerId.TabIndex = 51;
            this.lbl_cutomerId.Text = "Id";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(29, 74);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(85, 18);
            this.label16.TabIndex = 19;
            this.label16.Text = "First Name:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(81)))), ((int)(((byte)(126)))));
            this.panel2.Controls.Add(this.label23);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(340, 65);
            this.panel2.TabIndex = 117;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.White;
            this.label23.Location = new System.Drawing.Point(68, 18);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(186, 31);
            this.label23.TabIndex = 21;
            this.label23.Text = "Balance Refer";
            // 
            // CreditRefer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 447);
            this.Controls.Add(this.panel1);
            this.Name = "CreditRefer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CreditRefer";
            this.Load += new System.EventHandler(this.CreditRefer_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.TextBox txt_phone;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmb_last;
        private System.Windows.Forms.ComboBox cmb_first;
        public System.Windows.Forms.Label lbl_card_no;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.ButtonX btn_add;
        public System.Windows.Forms.TextBox txt_refer_balance;
        private System.Windows.Forms.Label label26;
        public System.Windows.Forms.Label lbl_cutomerId;
        private System.Windows.Forms.Label label16;
    }
}