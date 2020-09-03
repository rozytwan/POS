namespace POS_System
{
    partial class ItemSales
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
            this.backPanel = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.calbill_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calitem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calquantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.caltotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.caldate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calpaymode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_sub_total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_discount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calcashamt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calcardamount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_service_charge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_tax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_grand_total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calcashier_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_sales_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_print = new System.Windows.Forms.DataGridViewButtonColumn();
            this.cal_date2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_sales_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_table_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_category_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_customer_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_customer_pan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_back = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label23 = new System.Windows.Forms.Label();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.searchPanel = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnbackpage = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_exit = new System.Windows.Forms.Button();
            this.btn_show = new System.Windows.Forms.Button();
            this.dtp_to = new System.Windows.Forms.DateTimePicker();
            this.dtp_from = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbl_card_no = new System.Windows.Forms.Label();
            this.backPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.searchPanel.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // backPanel
            // 
            this.backPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.backPanel.Controls.Add(this.lbl_card_no);
            this.backPanel.Controls.Add(this.buttonX1);
            this.backPanel.Controls.Add(this.dataGridView1);
            this.backPanel.Controls.Add(this.panel2);
            this.backPanel.Location = new System.Drawing.Point(2, 7);
            this.backPanel.Name = "backPanel";
            this.backPanel.Size = new System.Drawing.Size(1007, 675);
            this.backPanel.TabIndex = 149;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.calbill_no,
            this.calitem,
            this.calquantity,
            this.caltotal,
            this.caldate,
            this.calpaymode,
            this.cal_sub_total,
            this.cal_discount,
            this.calcashamt,
            this.calcardamount,
            this.cal_service_charge,
            this.cal_tax,
            this.cal_grand_total,
            this.calcashier_name,
            this.cal_sales_type,
            this.cal_print,
            this.cal_date2,
            this.cal_sales_id,
            this.cal_table_no,
            this.cal_cost,
            this.cal_category_name,
            this.cal_customer_name,
            this.cal_customer_pan});
            this.dataGridView1.Location = new System.Drawing.Point(3, 123);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(1007, 543);
            this.dataGridView1.TabIndex = 143;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // calbill_no
            // 
            this.calbill_no.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.calbill_no.HeaderText = "Bill No";
            this.calbill_no.Name = "calbill_no";
            this.calbill_no.ReadOnly = true;
            this.calbill_no.Width = 60;
            // 
            // calitem
            // 
            this.calitem.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.calitem.HeaderText = "Item";
            this.calitem.Name = "calitem";
            this.calitem.ReadOnly = true;
            // 
            // calquantity
            // 
            this.calquantity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.calquantity.HeaderText = "Quantity";
            this.calquantity.Name = "calquantity";
            this.calquantity.ReadOnly = true;
            this.calquantity.Width = 50;
            // 
            // caltotal
            // 
            this.caltotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.caltotal.HeaderText = "Total";
            this.caltotal.Name = "caltotal";
            this.caltotal.ReadOnly = true;
            this.caltotal.Width = 73;
            // 
            // caldate
            // 
            this.caldate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.caldate.HeaderText = "Date";
            this.caldate.Name = "caldate";
            this.caldate.ReadOnly = true;
            this.caldate.Width = 73;
            // 
            // calpaymode
            // 
            this.calpaymode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.calpaymode.HeaderText = "PayMode";
            this.calpaymode.Name = "calpaymode";
            this.calpaymode.ReadOnly = true;
            this.calpaymode.Width = 72;
            // 
            // cal_sub_total
            // 
            this.cal_sub_total.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cal_sub_total.HeaderText = "Subtotal";
            this.cal_sub_total.Name = "cal_sub_total";
            this.cal_sub_total.ReadOnly = true;
            this.cal_sub_total.Visible = false;
            // 
            // cal_discount
            // 
            this.cal_discount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cal_discount.HeaderText = "Discount";
            this.cal_discount.Name = "cal_discount";
            this.cal_discount.ReadOnly = true;
            this.cal_discount.Visible = false;
            // 
            // calcashamt
            // 
            this.calcashamt.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.calcashamt.HeaderText = "Cash Amt.";
            this.calcashamt.Name = "calcashamt";
            this.calcashamt.ReadOnly = true;
            this.calcashamt.Width = 73;
            // 
            // calcardamount
            // 
            this.calcardamount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.calcardamount.HeaderText = "Card Amt.";
            this.calcardamount.Name = "calcardamount";
            this.calcardamount.ReadOnly = true;
            this.calcardamount.Width = 73;
            // 
            // cal_service_charge
            // 
            this.cal_service_charge.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cal_service_charge.HeaderText = "Service Charge";
            this.cal_service_charge.Name = "cal_service_charge";
            this.cal_service_charge.ReadOnly = true;
            this.cal_service_charge.Width = 72;
            // 
            // cal_tax
            // 
            this.cal_tax.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cal_tax.HeaderText = "Tax";
            this.cal_tax.Name = "cal_tax";
            this.cal_tax.ReadOnly = true;
            this.cal_tax.Width = 73;
            // 
            // cal_grand_total
            // 
            this.cal_grand_total.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cal_grand_total.HeaderText = "Grand total";
            this.cal_grand_total.Name = "cal_grand_total";
            this.cal_grand_total.ReadOnly = true;
            this.cal_grand_total.Width = 73;
            // 
            // calcashier_name
            // 
            this.calcashier_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.calcashier_name.HeaderText = "Cashier";
            this.calcashier_name.Name = "calcashier_name";
            this.calcashier_name.ReadOnly = true;
            this.calcashier_name.Width = 73;
            // 
            // cal_sales_type
            // 
            this.cal_sales_type.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cal_sales_type.HeaderText = "Sales Type";
            this.cal_sales_type.Name = "cal_sales_type";
            this.cal_sales_type.ReadOnly = true;
            this.cal_sales_type.Width = 72;
            // 
            // cal_print
            // 
            this.cal_print.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cal_print.HeaderText = "Re Print";
            this.cal_print.Name = "cal_print";
            this.cal_print.ReadOnly = true;
            this.cal_print.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cal_print.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.cal_print.Text = "Re Print";
            this.cal_print.UseColumnTextForButtonValue = true;
            this.cal_print.Width = 73;
            // 
            // cal_date2
            // 
            this.cal_date2.HeaderText = "Date2";
            this.cal_date2.Name = "cal_date2";
            this.cal_date2.ReadOnly = true;
            this.cal_date2.Visible = false;
            // 
            // cal_sales_id
            // 
            this.cal_sales_id.HeaderText = "Sales Id";
            this.cal_sales_id.Name = "cal_sales_id";
            this.cal_sales_id.ReadOnly = true;
            this.cal_sales_id.Visible = false;
            // 
            // cal_table_no
            // 
            this.cal_table_no.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cal_table_no.HeaderText = "Table no.";
            this.cal_table_no.Name = "cal_table_no";
            this.cal_table_no.ReadOnly = true;
            this.cal_table_no.Visible = false;
            // 
            // cal_cost
            // 
            this.cal_cost.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cal_cost.HeaderText = "Cost";
            this.cal_cost.Name = "cal_cost";
            this.cal_cost.ReadOnly = true;
            this.cal_cost.Visible = false;
            // 
            // cal_category_name
            // 
            this.cal_category_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cal_category_name.HeaderText = "Category";
            this.cal_category_name.Name = "cal_category_name";
            this.cal_category_name.ReadOnly = true;
            this.cal_category_name.Visible = false;
            // 
            // cal_customer_name
            // 
            this.cal_customer_name.HeaderText = "Customer Name";
            this.cal_customer_name.Name = "cal_customer_name";
            this.cal_customer_name.ReadOnly = true;
            this.cal_customer_name.Visible = false;
            // 
            // cal_customer_pan
            // 
            this.cal_customer_pan.HeaderText = "Customer Pan";
            this.cal_customer_pan.Name = "cal_customer_pan";
            this.cal_customer_pan.ReadOnly = true;
            this.cal_customer_pan.Visible = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(81)))), ((int)(((byte)(126)))));
            this.panel2.Controls.Add(this.btn_back);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.label23);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1007, 73);
            this.panel2.TabIndex = 130;
            // 
            // btn_back
            // 
            this.btn_back.FlatAppearance.BorderSize = 0;
            this.btn_back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_back.Image = global::POS_System.Properties.Resources.back36;
            this.btn_back.Location = new System.Drawing.Point(3, 5);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(92, 65);
            this.btn_back.TabIndex = 20;
            this.btn_back.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::POS_System.Properties.Resources.check__1_;
            this.pictureBox1.Location = new System.Drawing.Point(306, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(71, 68);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 26;
            this.pictureBox1.TabStop = false;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.White;
            this.label23.Location = new System.Drawing.Point(373, 19);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(262, 39);
            this.label23.TabIndex = 18;
            this.label23.Text = "View Item Sales";
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.buttonX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonX1.Location = new System.Drawing.Point(844, 79);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(15);
            this.buttonX1.Size = new System.Drawing.Size(160, 38);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 361;
            this.buttonX1.Text = "search by date";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // searchPanel
            // 
            this.searchPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchPanel.Controls.Add(this.panel3);
            this.searchPanel.Controls.Add(this.btn_exit);
            this.searchPanel.Controls.Add(this.btn_show);
            this.searchPanel.Controls.Add(this.dtp_to);
            this.searchPanel.Controls.Add(this.dtp_from);
            this.searchPanel.Controls.Add(this.label5);
            this.searchPanel.Controls.Add(this.label6);
            this.searchPanel.Location = new System.Drawing.Point(284, 7);
            this.searchPanel.Name = "searchPanel";
            this.searchPanel.Size = new System.Drawing.Size(388, 211);
            this.searchPanel.TabIndex = 150;
            // 
            // panel3
            // 
            this.panel3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(81)))), ((int)(((byte)(126)))));
            this.panel3.Controls.Add(this.btnbackpage);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(384, 73);
            this.panel3.TabIndex = 120;
            // 
            // btnbackpage
            // 
            this.btnbackpage.FlatAppearance.BorderSize = 0;
            this.btnbackpage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnbackpage.Image = global::POS_System.Properties.Resources.back36;
            this.btnbackpage.Location = new System.Drawing.Point(0, 1);
            this.btnbackpage.Name = "btnbackpage";
            this.btnbackpage.Size = new System.Drawing.Size(85, 69);
            this.btnbackpage.TabIndex = 28;
            this.btnbackpage.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(118, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(208, 25);
            this.label4.TabIndex = 0;
            this.label4.Text = "Choose Between Date";
            // 
            // btn_exit
            // 
            this.btn_exit.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_exit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.btn_exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_exit.ForeColor = System.Drawing.Color.White;
            this.btn_exit.Location = new System.Drawing.Point(218, 166);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(107, 36);
            this.btn_exit.TabIndex = 119;
            this.btn_exit.Text = "Exit";
            this.btn_exit.UseVisualStyleBackColor = false;
            // 
            // btn_show
            // 
            this.btn_show.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_show.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.btn_show.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_show.ForeColor = System.Drawing.Color.White;
            this.btn_show.Location = new System.Drawing.Point(107, 166);
            this.btn_show.Name = "btn_show";
            this.btn_show.Size = new System.Drawing.Size(107, 36);
            this.btn_show.TabIndex = 118;
            this.btn_show.Text = "Show";
            this.btn_show.UseVisualStyleBackColor = false;
            this.btn_show.Click += new System.EventHandler(this.btn_show_Click_1);
            // 
            // dtp_to
            // 
            this.dtp_to.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dtp_to.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_to.Location = new System.Drawing.Point(107, 130);
            this.dtp_to.Name = "dtp_to";
            this.dtp_to.Size = new System.Drawing.Size(218, 24);
            this.dtp_to.TabIndex = 117;
            this.dtp_to.Value = new System.DateTime(2017, 11, 22, 0, 0, 0, 0);
            // 
            // dtp_from
            // 
            this.dtp_from.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dtp_from.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_from.Location = new System.Drawing.Point(107, 94);
            this.dtp_from.Name = "dtp_from";
            this.dtp_from.Size = new System.Drawing.Size(218, 24);
            this.dtp_from.TabIndex = 116;
            this.dtp_from.Value = new System.DateTime(2017, 11, 22, 0, 0, 0, 0);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(52, 139);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 114;
            this.label5.Text = "Date To:";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(42, 108);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 115;
            this.label6.Text = "Date From:";
            // 
            // lbl_card_no
            // 
            this.lbl_card_no.AutoSize = true;
            this.lbl_card_no.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_card_no.Location = new System.Drawing.Point(676, 95);
            this.lbl_card_no.Name = "lbl_card_no";
            this.lbl_card_no.Size = new System.Drawing.Size(71, 20);
            this.lbl_card_no.TabIndex = 362;
            this.lbl_card_no.Text = "Card No.";
            // 
            // ItemSales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 681);
            this.Controls.Add(this.searchPanel);
            this.Controls.Add(this.backPanel);
            this.Name = "ItemSales";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ItemSales";
            this.Load += new System.EventHandler(this.ItemSales_Load);
            this.backPanel.ResumeLayout(false);
            this.backPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.searchPanel.ResumeLayout(false);
            this.searchPanel.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel backPanel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_back;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.DataGridViewTextBoxColumn calbill_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn calitem;
        private System.Windows.Forms.DataGridViewTextBoxColumn calquantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn caltotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn caldate;
        private System.Windows.Forms.DataGridViewTextBoxColumn calpaymode;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_sub_total;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_discount;
        private System.Windows.Forms.DataGridViewTextBoxColumn calcashamt;
        private System.Windows.Forms.DataGridViewTextBoxColumn calcardamount;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_service_charge;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_tax;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_grand_total;
        private System.Windows.Forms.DataGridViewTextBoxColumn calcashier_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_sales_type;
        private System.Windows.Forms.DataGridViewButtonColumn cal_print;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_date2;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_sales_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_table_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_cost;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_category_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_customer_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_customer_pan;
        public System.Windows.Forms.DataGridView dataGridView1;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private System.Windows.Forms.Panel searchPanel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnbackpage;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Button btn_show;
        private System.Windows.Forms.DateTimePicker dtp_to;
        private System.Windows.Forms.DateTimePicker dtp_from;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.Label lbl_card_no;
    }
}