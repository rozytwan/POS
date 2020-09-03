namespace POS_System.Customer_Management
{
    partial class CustomerCardDetail
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
            this.txt_searchbox = new System.Windows.Forms.TextBox();
            this.lbl_search = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label23 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbl_name = new System.Windows.Forms.Label();
            this.lbl_surname = new System.Windows.Forms.Label();
            this.lbl_phone = new System.Windows.Forms.Label();
            this.lbl_card_type = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_balance = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_useable = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbl_fix = new System.Windows.Forms.Label();
            this.btn_itemsales = new DevComponents.DotNetBar.ButtonX();
            this.btn_cash_back = new DevComponents.DotNetBar.ButtonX();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbl_refundable = new System.Windows.Forms.Label();
            this.lbl_nonrefundable = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.btn_add = new DevComponents.DotNetBar.ButtonX();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txt_searchbox);
            this.panel1.Controls.Add(this.lbl_search);
            this.panel1.Location = new System.Drawing.Point(9, 71);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(373, 46);
            this.panel1.TabIndex = 118;
            // 
            // txt_searchbox
            // 
            this.txt_searchbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_searchbox.Location = new System.Drawing.Point(94, 8);
            this.txt_searchbox.Name = "txt_searchbox";
            this.txt_searchbox.Size = new System.Drawing.Size(264, 35);
            this.txt_searchbox.TabIndex = 119;
            this.txt_searchbox.TextChanged += new System.EventHandler(this.txt_searchbox_TextChanged);
            this.txt_searchbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_searchbox_KeyDown);
            this.txt_searchbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_searchbox_KeyPress);
            // 
            // lbl_search
            // 
            this.lbl_search.AutoSize = true;
            this.lbl_search.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_search.Location = new System.Drawing.Point(9, 18);
            this.lbl_search.Name = "lbl_search";
            this.lbl_search.Size = new System.Drawing.Size(79, 20);
            this.lbl_search.TabIndex = 120;
            this.lbl_search.Text = "Card No. :";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(81)))), ((int)(((byte)(126)))));
            this.panel2.Controls.Add(this.label23);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(389, 60);
            this.panel2.TabIndex = 120;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.White;
            this.label23.Location = new System.Drawing.Point(65, 17);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(237, 31);
            this.label23.TabIndex = 22;
            this.label23.Text = "Customer Balance";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(3, 77);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(155, 20);
            this.label13.TabIndex = 342;
            this.label13.Text = "Customer Surname :";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(67, 122);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(91, 20);
            this.label14.TabIndex = 344;
            this.label14.Text = "Phone No. :";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(67, 159);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(89, 20);
            this.label17.TabIndex = 345;
            this.label17.Text = "Card Type :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(29, 43);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(132, 20);
            this.label8.TabIndex = 346;
            this.label8.Text = "Customer Name :";
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_name.Location = new System.Drawing.Point(173, 43);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(0, 20);
            this.lbl_name.TabIndex = 347;
            // 
            // lbl_surname
            // 
            this.lbl_surname.AutoSize = true;
            this.lbl_surname.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_surname.Location = new System.Drawing.Point(173, 77);
            this.lbl_surname.Name = "lbl_surname";
            this.lbl_surname.Size = new System.Drawing.Size(0, 20);
            this.lbl_surname.TabIndex = 348;
            // 
            // lbl_phone
            // 
            this.lbl_phone.AutoSize = true;
            this.lbl_phone.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_phone.Location = new System.Drawing.Point(173, 122);
            this.lbl_phone.Name = "lbl_phone";
            this.lbl_phone.Size = new System.Drawing.Size(0, 20);
            this.lbl_phone.TabIndex = 349;
            // 
            // lbl_card_type
            // 
            this.lbl_card_type.AutoSize = true;
            this.lbl_card_type.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_card_type.Location = new System.Drawing.Point(173, 159);
            this.lbl_card_type.Name = "lbl_card_type";
            this.lbl_card_type.Size = new System.Drawing.Size(0, 20);
            this.lbl_card_type.TabIndex = 350;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(25, 227);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 20);
            this.label2.TabIndex = 351;
            this.label2.Text = "Avilable Balance :";
            // 
            // lbl_balance
            // 
            this.lbl_balance.AutoSize = true;
            this.lbl_balance.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_balance.Location = new System.Drawing.Point(164, 227);
            this.lbl_balance.Name = "lbl_balance";
            this.lbl_balance.Size = new System.Drawing.Size(0, 29);
            this.lbl_balance.TabIndex = 352;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(90, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(165, 20);
            this.label3.TabIndex = 353;
            this.label3.Text = "Customer Summary";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 297);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 20);
            this.label1.TabIndex = 354;
            this.label1.Text = "Useable Balance :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(179, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 29);
            this.label4.TabIndex = 355;
            // 
            // lbl_useable
            // 
            this.lbl_useable.AutoSize = true;
            this.lbl_useable.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_useable.Location = new System.Drawing.Point(166, 297);
            this.lbl_useable.Name = "lbl_useable";
            this.lbl_useable.Size = new System.Drawing.Size(0, 29);
            this.lbl_useable.TabIndex = 356;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(57, 194);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 20);
            this.label6.TabIndex = 357;
            this.label6.Text = "Fix Balance :";
            // 
            // lbl_fix
            // 
            this.lbl_fix.AutoSize = true;
            this.lbl_fix.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_fix.Location = new System.Drawing.Point(173, 194);
            this.lbl_fix.Name = "lbl_fix";
            this.lbl_fix.Size = new System.Drawing.Size(0, 20);
            this.lbl_fix.TabIndex = 358;
            // 
            // btn_itemsales
            // 
            this.btn_itemsales.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_itemsales.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btn_itemsales.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_itemsales.Location = new System.Drawing.Point(250, 372);
            this.btn_itemsales.Name = "btn_itemsales";
            this.btn_itemsales.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(15);
            this.btn_itemsales.Size = new System.Drawing.Size(119, 38);
            this.btn_itemsales.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_itemsales.TabIndex = 359;
            this.btn_itemsales.Text = "Item Sales";
            this.btn_itemsales.Click += new System.EventHandler(this.btn_itemsales_Click);
            // 
            // btn_cash_back
            // 
            this.btn_cash_back.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_cash_back.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btn_cash_back.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cash_back.Location = new System.Drawing.Point(139, 372);
            this.btn_cash_back.Name = "btn_cash_back";
            this.btn_cash_back.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(15);
            this.btn_cash_back.Size = new System.Drawing.Size(105, 38);
            this.btn_cash_back.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_cash_back.TabIndex = 361;
            this.btn_cash_back.Text = "Cash Back";
            this.btn_cash_back.Click += new System.EventHandler(this.btn_cash_back_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.lbl_refundable);
            this.panel3.Controls.Add(this.lbl_nonrefundable);
            this.panel3.Controls.Add(this.label43);
            this.panel3.Controls.Add(this.label44);
            this.panel3.Controls.Add(this.btn_add);
            this.panel3.Controls.Add(this.btn_cash_back);
            this.panel3.Controls.Add(this.btn_itemsales);
            this.panel3.Controls.Add(this.lbl_fix);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.lbl_useable);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.lbl_balance);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.lbl_card_type);
            this.panel3.Controls.Add(this.lbl_phone);
            this.panel3.Controls.Add(this.lbl_surname);
            this.panel3.Controls.Add(this.lbl_name);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.label17);
            this.panel3.Controls.Add(this.label14);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3.Location = new System.Drawing.Point(7, 127);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(375, 417);
            this.panel3.TabIndex = 119;
            // 
            // lbl_refundable
            // 
            this.lbl_refundable.AutoSize = true;
            this.lbl_refundable.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_refundable.Location = new System.Drawing.Point(171, 333);
            this.lbl_refundable.Name = "lbl_refundable";
            this.lbl_refundable.Size = new System.Drawing.Size(0, 20);
            this.lbl_refundable.TabIndex = 366;
            // 
            // lbl_nonrefundable
            // 
            this.lbl_nonrefundable.AutoSize = true;
            this.lbl_nonrefundable.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_nonrefundable.Location = new System.Drawing.Point(173, 262);
            this.lbl_nonrefundable.Name = "lbl_nonrefundable";
            this.lbl_nonrefundable.Size = new System.Drawing.Size(0, 20);
            this.lbl_nonrefundable.TabIndex = 365;
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label43.Location = new System.Drawing.Point(56, 333);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(100, 20);
            this.label43.TabIndex = 364;
            this.label43.Text = "Refundable :";
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label44.Location = new System.Drawing.Point(23, 262);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(133, 20);
            this.label44.TabIndex = 363;
            this.label44.Text = "Non Refundable :";
            // 
            // btn_add
            // 
            this.btn_add.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_add.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btn_add.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add.Location = new System.Drawing.Point(12, 372);
            this.btn_add.Name = "btn_add";
            this.btn_add.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(15);
            this.btn_add.Size = new System.Drawing.Size(114, 38);
            this.btn_add.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_add.TabIndex = 362;
            this.btn_add.Text = "Add Balance";
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // CustomerCardDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 547);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CustomerCardDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CustomerCardDetail";
            this.Load += new System.EventHandler(this.CustomerCardDetail_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txt_searchbox;
        private System.Windows.Forms.Label lbl_search;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.Label lbl_surname;
        private System.Windows.Forms.Label lbl_phone;
        private System.Windows.Forms.Label lbl_card_type;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_balance;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_useable;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbl_fix;
        private DevComponents.DotNetBar.ButtonX btn_itemsales;
        private DevComponents.DotNetBar.ButtonX btn_cash_back;
        private System.Windows.Forms.Panel panel3;
        private DevComponents.DotNetBar.ButtonX btn_add;
        private System.Windows.Forms.Label lbl_refundable;
        private System.Windows.Forms.Label lbl_nonrefundable;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Label label44;
    }
}