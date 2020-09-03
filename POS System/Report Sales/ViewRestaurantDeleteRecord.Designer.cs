namespace POS_System
{
    partial class ViewRestaurantDeleteRecord
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_back = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label23 = new System.Windows.Forms.Label();
            this.searchPanel = new System.Windows.Forms.Panel();
            this.txt_searchText = new System.Windows.Forms.ComboBox();
            this.cbo_searchTYpe = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnbackpage = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_exit = new System.Windows.Forms.Button();
            this.btn_show = new System.Windows.Forms.Button();
            this.dtp_to = new System.Windows.Forms.DateTimePicker();
            this.dtp_from = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.backPanel = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.lblgrandtotal = new System.Windows.Forms.Label();
            this.lbltaotal_quantity = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.calbill_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_table_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_category_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calitem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calquantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.caltotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.caldate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calpaymode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_discount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_sub_total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calcashamt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calcardamount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_grand_total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calcashier_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_sales_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.cal_date2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_sales_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbn_export_to_excel = new DevComponents.DotNetBar.ButtonX();
            this.btn_export_to_pdf = new DevComponents.DotNetBar.ButtonX();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.searchPanel.SuspendLayout();
            this.panel3.SuspendLayout();
            this.backPanel.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
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
            this.panel2.Size = new System.Drawing.Size(1027, 73);
            this.panel2.TabIndex = 131;
            // 
            // btn_back
            // 
            this.btn_back.FlatAppearance.BorderSize = 0;
            this.btn_back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_back.Image = global::POS_System.Properties.Resources.back36;
            this.btn_back.Location = new System.Drawing.Point(3, 3);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(92, 65);
            this.btn_back.TabIndex = 20;
            this.btn_back.UseVisualStyleBackColor = true;
            this.btn_back.Click += new System.EventHandler(this.btn_back_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::POS_System.Properties.Resources.check__1_;
            this.pictureBox1.Location = new System.Drawing.Point(242, 5);
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
            this.label23.Location = new System.Drawing.Point(309, 19);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(424, 39);
            this.label23.TabIndex = 18;
            this.label23.Text = "View  Delete Sales Report ";
            // 
            // searchPanel
            // 
            this.searchPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchPanel.Controls.Add(this.txt_searchText);
            this.searchPanel.Controls.Add(this.cbo_searchTYpe);
            this.searchPanel.Controls.Add(this.label1);
            this.searchPanel.Controls.Add(this.label2);
            this.searchPanel.Controls.Add(this.panel3);
            this.searchPanel.Controls.Add(this.btn_exit);
            this.searchPanel.Controls.Add(this.btn_show);
            this.searchPanel.Controls.Add(this.dtp_to);
            this.searchPanel.Controls.Add(this.dtp_from);
            this.searchPanel.Controls.Add(this.label5);
            this.searchPanel.Controls.Add(this.label6);
            this.searchPanel.Location = new System.Drawing.Point(285, 3);
            this.searchPanel.Name = "searchPanel";
            this.searchPanel.Size = new System.Drawing.Size(418, 250);
            this.searchPanel.TabIndex = 146;
            // 
            // txt_searchText
            // 
            this.txt_searchText.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txt_searchText.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.txt_searchText.FormattingEnabled = true;
            this.txt_searchText.Items.AddRange(new object[] {
            "Choose Type",
            "Product",
            "Category"});
            this.txt_searchText.Location = new System.Drawing.Point(134, 113);
            this.txt_searchText.Name = "txt_searchText";
            this.txt_searchText.Size = new System.Drawing.Size(218, 21);
            this.txt_searchText.TabIndex = 124;
            // 
            // cbo_searchTYpe
            // 
            this.cbo_searchTYpe.FormattingEnabled = true;
            this.cbo_searchTYpe.Items.AddRange(new object[] {
            "Choose Type",
            "Product",
            "Category",
            "Bill No",
            "ALL",
            "Payment Mode",
            "Sales Type",
            "User"});
            this.cbo_searchTYpe.Location = new System.Drawing.Point(134, 89);
            this.cbo_searchTYpe.Name = "cbo_searchTYpe";
            this.cbo_searchTYpe.Size = new System.Drawing.Size(218, 21);
            this.cbo_searchTYpe.TabIndex = 123;
            this.cbo_searchTYpe.SelectedIndexChanged += new System.EventHandler(this.cbo_searchTYpe_SelectedIndexChanged_1);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(99, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 121;
            this.label1.Text = "Find:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(59, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 122;
            this.label2.Text = "Search Type:";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(81)))), ((int)(((byte)(126)))));
            this.panel3.Controls.Add(this.btnbackpage);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(416, 73);
            this.panel3.TabIndex = 120;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
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
            this.btnbackpage.Click += new System.EventHandler(this.btnbackpage_Click);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(134, 25);
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
            this.btn_exit.Location = new System.Drawing.Point(245, 200);
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
            this.btn_show.Location = new System.Drawing.Point(134, 200);
            this.btn_show.Name = "btn_show";
            this.btn_show.Size = new System.Drawing.Size(107, 36);
            this.btn_show.TabIndex = 118;
            this.btn_show.Text = "Show";
            this.btn_show.UseVisualStyleBackColor = false;
            this.btn_show.Click += new System.EventHandler(this.btn_show_Click);
            // 
            // dtp_to
            // 
            this.dtp_to.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dtp_to.Location = new System.Drawing.Point(134, 169);
            this.dtp_to.Name = "dtp_to";
            this.dtp_to.Size = new System.Drawing.Size(218, 20);
            this.dtp_to.TabIndex = 117;
            this.dtp_to.Value = new System.DateTime(2016, 7, 18, 12, 44, 51, 0);
            // 
            // dtp_from
            // 
            this.dtp_from.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dtp_from.Location = new System.Drawing.Point(134, 143);
            this.dtp_from.Name = "dtp_from";
            this.dtp_from.Size = new System.Drawing.Size(218, 20);
            this.dtp_from.TabIndex = 116;
            this.dtp_from.Value = new System.DateTime(2016, 7, 18, 12, 44, 38, 0);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(79, 170);
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
            this.label6.Location = new System.Drawing.Point(69, 144);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 115;
            this.label6.Text = "Date From:";
            // 
            // backPanel
            // 
            this.backPanel.Controls.Add(this.btn_export_to_pdf);
            this.backPanel.Controls.Add(this.tbn_export_to_excel);
            this.backPanel.Controls.Add(this.panel4);
            this.backPanel.Controls.Add(this.dataGridView1);
            this.backPanel.Controls.Add(this.panel2);
            this.backPanel.Location = new System.Drawing.Point(1, 1);
            this.backPanel.Name = "backPanel";
            this.backPanel.Size = new System.Drawing.Size(1027, 720);
            this.backPanel.TabIndex = 147;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.lblgrandtotal);
            this.panel4.Controls.Add(this.lbltaotal_quantity);
            this.panel4.Location = new System.Drawing.Point(-49, 625);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1079, 39);
            this.panel4.TabIndex = 141;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Black;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Lime;
            this.label3.Location = new System.Drawing.Point(51, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Total";
            // 
            // lblgrandtotal
            // 
            this.lblgrandtotal.AutoSize = true;
            this.lblgrandtotal.BackColor = System.Drawing.Color.Black;
            this.lblgrandtotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblgrandtotal.ForeColor = System.Drawing.Color.Lime;
            this.lblgrandtotal.Location = new System.Drawing.Point(320, 9);
            this.lblgrandtotal.Name = "lblgrandtotal";
            this.lblgrandtotal.Size = new System.Drawing.Size(24, 25);
            this.lblgrandtotal.TabIndex = 1;
            this.lblgrandtotal.Text = "0";
            // 
            // lbltaotal_quantity
            // 
            this.lbltaotal_quantity.AutoSize = true;
            this.lbltaotal_quantity.BackColor = System.Drawing.Color.Black;
            this.lbltaotal_quantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltaotal_quantity.ForeColor = System.Drawing.Color.Lime;
            this.lbltaotal_quantity.Location = new System.Drawing.Point(234, 8);
            this.lbltaotal_quantity.Name = "lbltaotal_quantity";
            this.lbltaotal_quantity.Size = new System.Drawing.Size(24, 25);
            this.lbltaotal_quantity.TabIndex = 0;
            this.lbltaotal_quantity.Text = "0";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.calbill_no,
            this.cal_table_no,
            this.cal_category_name,
            this.calitem,
            this.calquantity,
            this.cal_cost,
            this.caltotal,
            this.caldate,
            this.calpaymode,
            this.cal_discount,
            this.cal_sub_total,
            this.calcashamt,
            this.calcardamount,
            this.cal_grand_total,
            this.calcashier_name,
            this.cal_sales_type,
            this.cal_delete,
            this.cal_date2,
            this.cal_sales_id});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.Location = new System.Drawing.Point(3, 71);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(1020, 548);
            this.dataGridView1.TabIndex = 142;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // calbill_no
            // 
            this.calbill_no.FillWeight = 5F;
            this.calbill_no.HeaderText = "Bill No";
            this.calbill_no.Name = "calbill_no";
            this.calbill_no.ReadOnly = true;
            // 
            // cal_table_no
            // 
            this.cal_table_no.HeaderText = "table_no";
            this.cal_table_no.Name = "cal_table_no";
            this.cal_table_no.ReadOnly = true;
            this.cal_table_no.Visible = false;
            // 
            // cal_category_name
            // 
            this.cal_category_name.HeaderText = "Category Name";
            this.cal_category_name.Name = "cal_category_name";
            this.cal_category_name.ReadOnly = true;
            this.cal_category_name.Visible = false;
            // 
            // calitem
            // 
            this.calitem.FillWeight = 11.37467F;
            this.calitem.HeaderText = "Item";
            this.calitem.Name = "calitem";
            this.calitem.ReadOnly = true;
            // 
            // calquantity
            // 
            this.calquantity.FillWeight = 3F;
            this.calquantity.HeaderText = "QTY";
            this.calquantity.Name = "calquantity";
            this.calquantity.ReadOnly = true;
            // 
            // cal_cost
            // 
            this.cal_cost.HeaderText = "Cost";
            this.cal_cost.Name = "cal_cost";
            this.cal_cost.ReadOnly = true;
            this.cal_cost.Visible = false;
            // 
            // caltotal
            // 
            this.caltotal.FillWeight = 5F;
            this.caltotal.HeaderText = "Total";
            this.caltotal.Name = "caltotal";
            this.caltotal.ReadOnly = true;
            // 
            // caldate
            // 
            this.caldate.FillWeight = 6.43112F;
            this.caldate.HeaderText = "Date";
            this.caldate.Name = "caldate";
            this.caldate.ReadOnly = true;
            // 
            // calpaymode
            // 
            this.calpaymode.FillWeight = 4F;
            this.calpaymode.HeaderText = "Payment Mode";
            this.calpaymode.Name = "calpaymode";
            this.calpaymode.ReadOnly = true;
            // 
            // cal_discount
            // 
            this.cal_discount.HeaderText = "Discount";
            this.cal_discount.Name = "cal_discount";
            this.cal_discount.ReadOnly = true;
            this.cal_discount.Visible = false;
            // 
            // cal_sub_total
            // 
            this.cal_sub_total.HeaderText = "Sub Total";
            this.cal_sub_total.Name = "cal_sub_total";
            this.cal_sub_total.ReadOnly = true;
            this.cal_sub_total.Visible = false;
            // 
            // calcashamt
            // 
            this.calcashamt.FillWeight = 6.43112F;
            this.calcashamt.HeaderText = "Cash Amount";
            this.calcashamt.Name = "calcashamt";
            this.calcashamt.ReadOnly = true;
            // 
            // calcardamount
            // 
            this.calcardamount.FillWeight = 6.43112F;
            this.calcardamount.HeaderText = "Card Amount";
            this.calcardamount.Name = "calcardamount";
            this.calcardamount.ReadOnly = true;
            // 
            // cal_grand_total
            // 
            this.cal_grand_total.FillWeight = 7F;
            this.cal_grand_total.HeaderText = "Grand Total";
            this.cal_grand_total.Name = "cal_grand_total";
            this.cal_grand_total.ReadOnly = true;
            // 
            // calcashier_name
            // 
            this.calcashier_name.FillWeight = 6.43112F;
            this.calcashier_name.HeaderText = "Cashier Name";
            this.calcashier_name.Name = "calcashier_name";
            this.calcashier_name.ReadOnly = true;
            // 
            // cal_sales_type
            // 
            this.cal_sales_type.FillWeight = 5.687336F;
            this.cal_sales_type.HeaderText = "Sales Type";
            this.cal_sales_type.Name = "cal_sales_type";
            this.cal_sales_type.ReadOnly = true;
            // 
            // cal_delete
            // 
            this.cal_delete.FillWeight = 7F;
            this.cal_delete.HeaderText = "Recover";
            this.cal_delete.Name = "cal_delete";
            this.cal_delete.ReadOnly = true;
            this.cal_delete.Text = "Recover";
            this.cal_delete.UseColumnTextForButtonValue = true;
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
            this.cal_sales_id.HeaderText = "Sale_id";
            this.cal_sales_id.Name = "cal_sales_id";
            this.cal_sales_id.ReadOnly = true;
            this.cal_sales_id.Visible = false;
            // 
            // tbn_export_to_excel
            // 
            this.tbn_export_to_excel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.tbn_export_to_excel.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.tbn_export_to_excel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbn_export_to_excel.Location = new System.Drawing.Point(238, 674);
            this.tbn_export_to_excel.Name = "tbn_export_to_excel";
            this.tbn_export_to_excel.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(14);
            this.tbn_export_to_excel.Size = new System.Drawing.Size(175, 43);
            this.tbn_export_to_excel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.tbn_export_to_excel.Symbol = "";
            this.tbn_export_to_excel.TabIndex = 143;
            this.tbn_export_to_excel.Text = "Export to Excel";
            this.tbn_export_to_excel.Click += new System.EventHandler(this.tbn_export_to_excel_Click);
            // 
            // btn_export_to_pdf
            // 
            this.btn_export_to_pdf.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_export_to_pdf.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btn_export_to_pdf.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_export_to_pdf.Location = new System.Drawing.Point(7, 674);
            this.btn_export_to_pdf.Name = "btn_export_to_pdf";
            this.btn_export_to_pdf.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(14);
            this.btn_export_to_pdf.Size = new System.Drawing.Size(190, 42);
            this.btn_export_to_pdf.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_export_to_pdf.Symbol = "";
            this.btn_export_to_pdf.TabIndex = 144;
            this.btn_export_to_pdf.Text = "Export to PDF";
            this.btn_export_to_pdf.Click += new System.EventHandler(this.btn_export_to_pdf_Click);
            // 
            // ViewRestaurantDeleteRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.backPanel);
            this.Controls.Add(this.searchPanel);
            this.Name = "ViewRestaurantDeleteRecord";
            this.Size = new System.Drawing.Size(1027, 720);
            this.Load += new System.EventHandler(this.ViewRestaurantDeleteRecord_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.searchPanel.ResumeLayout(false);
            this.searchPanel.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.backPanel.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_back;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Panel searchPanel;
        private System.Windows.Forms.ComboBox txt_searchText;
        private System.Windows.Forms.ComboBox cbo_searchTYpe;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnbackpage;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Button btn_show;
        private System.Windows.Forms.DateTimePicker dtp_to;
        private System.Windows.Forms.DateTimePicker dtp_from;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel backPanel;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblgrandtotal;
        private System.Windows.Forms.Label lbltaotal_quantity;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn calbill_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_table_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_category_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn calitem;
        private System.Windows.Forms.DataGridViewTextBoxColumn calquantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_cost;
        private System.Windows.Forms.DataGridViewTextBoxColumn caltotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn caldate;
        private System.Windows.Forms.DataGridViewTextBoxColumn calpaymode;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_discount;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_sub_total;
        private System.Windows.Forms.DataGridViewTextBoxColumn calcashamt;
        private System.Windows.Forms.DataGridViewTextBoxColumn calcardamount;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_grand_total;
        private System.Windows.Forms.DataGridViewTextBoxColumn calcashier_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_sales_type;
        private System.Windows.Forms.DataGridViewButtonColumn cal_delete;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_date2;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_sales_id;
        private DevComponents.DotNetBar.ButtonX tbn_export_to_excel;
        private DevComponents.DotNetBar.ButtonX btn_export_to_pdf;
    }
}