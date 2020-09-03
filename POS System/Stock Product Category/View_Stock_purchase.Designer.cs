﻿namespace POS_System
{ 
    partial class View_Stock_Purchase
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
            this.searchPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cmb_search = new System.Windows.Forms.ComboBox();
            this.cbo_searchTYpe = new System.Windows.Forms.ComboBox();
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
            this.btn_excel = new DevComponents.DotNetBar.ButtonX();
            this.btn_export_XML = new DevComponents.DotNetBar.ButtonX();
            this.btn_export_to_pdf = new DevComponents.DotNetBar.ButtonX();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblgt = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbl_qty_total = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_back = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label23 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.col_category_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calBillNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_product_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_discount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_grand_total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_tax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_supplier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_purchase_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_expire_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.searchPanel.SuspendLayout();
            this.panel3.SuspendLayout();
            this.backPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // searchPanel
            // 
            this.searchPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchPanel.Controls.Add(this.label1);
            this.searchPanel.Controls.Add(this.cmb_search);
            this.searchPanel.Controls.Add(this.cbo_searchTYpe);
            this.searchPanel.Controls.Add(this.label2);
            this.searchPanel.Controls.Add(this.panel3);
            this.searchPanel.Controls.Add(this.btn_exit);
            this.searchPanel.Controls.Add(this.btn_show);
            this.searchPanel.Controls.Add(this.dtp_to);
            this.searchPanel.Controls.Add(this.dtp_from);
            this.searchPanel.Controls.Add(this.label5);
            this.searchPanel.Controls.Add(this.label6);
            this.searchPanel.Location = new System.Drawing.Point(291, 2);
            this.searchPanel.Name = "searchPanel";
            this.searchPanel.Size = new System.Drawing.Size(388, 270);
            this.searchPanel.TabIndex = 147;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(68, 129);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 125;
            this.label1.Text = "Find :";
            // 
            // cmb_search
            // 
            this.cmb_search.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_search.FormattingEnabled = true;
            this.cmb_search.Location = new System.Drawing.Point(109, 122);
            this.cmb_search.Name = "cmb_search";
            this.cmb_search.Size = new System.Drawing.Size(218, 26);
            this.cmb_search.TabIndex = 124;
            // 
            // cbo_searchTYpe
            // 
            this.cbo_searchTYpe.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_searchTYpe.FormattingEnabled = true;
            this.cbo_searchTYpe.Items.AddRange(new object[] {
            "Choose Type",
            "Product Name",
            "Category Name",
            "ALL"});
            this.cbo_searchTYpe.Location = new System.Drawing.Point(109, 88);
            this.cbo_searchTYpe.Name = "cbo_searchTYpe";
            this.cbo_searchTYpe.Size = new System.Drawing.Size(218, 26);
            this.cbo_searchTYpe.TabIndex = 123;
            this.cbo_searchTYpe.SelectedIndexChanged += new System.EventHandler(this.cbo_searchTYpe_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(32, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 122;
            this.label2.Text = "Search Type:";
            // 
            // panel3
            // 
            this.panel3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(81)))), ((int)(((byte)(126)))));
            this.panel3.Controls.Add(this.btnbackpage);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Location = new System.Drawing.Point(-1, 3);
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
            this.btn_exit.Location = new System.Drawing.Point(220, 226);
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
            this.btn_show.Location = new System.Drawing.Point(109, 226);
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
            this.dtp_to.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_to.Location = new System.Drawing.Point(109, 190);
            this.dtp_to.Name = "dtp_to";
            this.dtp_to.Size = new System.Drawing.Size(218, 24);
            this.dtp_to.TabIndex = 117;
            this.dtp_to.Value = new System.DateTime(2017, 11, 22, 0, 0, 0, 0);
            // 
            // dtp_from
            // 
            this.dtp_from.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dtp_from.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_from.Location = new System.Drawing.Point(109, 154);
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
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(54, 199);
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
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(44, 168);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 115;
            this.label6.Text = "Date From:";
            // 
            // backPanel
            // 
            this.backPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.backPanel.Controls.Add(this.btn_excel);
            this.backPanel.Controls.Add(this.btn_export_XML);
            this.backPanel.Controls.Add(this.btn_export_to_pdf);
            this.backPanel.Controls.Add(this.panel1);
            this.backPanel.Controls.Add(this.panel2);
            this.backPanel.Controls.Add(this.dataGridView1);
            this.backPanel.Location = new System.Drawing.Point(3, 3);
            this.backPanel.Name = "backPanel";
            this.backPanel.Size = new System.Drawing.Size(1008, 720);
            this.backPanel.TabIndex = 148;
            this.backPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.backPanel_Paint);
            // 
            // btn_excel
            // 
            this.btn_excel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_excel.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btn_excel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_excel.Location = new System.Drawing.Point(590, 652);
            this.btn_excel.Name = "btn_excel";
            this.btn_excel.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(14);
            this.btn_excel.Size = new System.Drawing.Size(182, 50);
            this.btn_excel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_excel.Symbol = "";
            this.btn_excel.TabIndex = 143;
            this.btn_excel.Text = "Export to Excel";
            this.btn_excel.Click += new System.EventHandler(this.btn_excel_Click);
            // 
            // btn_export_XML
            // 
            this.btn_export_XML.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_export_XML.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btn_export_XML.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_export_XML.Location = new System.Drawing.Point(363, 652);
            this.btn_export_XML.Name = "btn_export_XML";
            this.btn_export_XML.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(14);
            this.btn_export_XML.Size = new System.Drawing.Size(203, 50);
            this.btn_export_XML.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_export_XML.Symbol = "";
            this.btn_export_XML.TabIndex = 142;
            this.btn_export_XML.Text = "Export to XML";
            this.btn_export_XML.Click += new System.EventHandler(this.btn_export_XML_Click);
            // 
            // btn_export_to_pdf
            // 
            this.btn_export_to_pdf.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_export_to_pdf.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btn_export_to_pdf.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_export_to_pdf.Location = new System.Drawing.Point(787, 653);
            this.btn_export_to_pdf.Name = "btn_export_to_pdf";
            this.btn_export_to_pdf.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(14);
            this.btn_export_to_pdf.Size = new System.Drawing.Size(203, 50);
            this.btn_export_to_pdf.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_export_to_pdf.Symbol = "";
            this.btn_export_to_pdf.TabIndex = 141;
            this.btn_export_to_pdf.Text = "Export to PDF";
            this.btn_export_to_pdf.Click += new System.EventHandler(this.btn_export_to_pdf_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Location = new System.Drawing.Point(0, 604);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1042, 39);
            this.panel1.TabIndex = 138;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel4.Controls.Add(this.lblgt);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.lbl_qty_total);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1002, 36);
            this.panel4.TabIndex = 137;
            // 
            // lblgt
            // 
            this.lblgt.AutoSize = true;
            this.lblgt.BackColor = System.Drawing.Color.Black;
            this.lblgt.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblgt.ForeColor = System.Drawing.Color.Lime;
            this.lblgt.Location = new System.Drawing.Point(511, 3);
            this.lblgt.Name = "lblgt";
            this.lblgt.Size = new System.Drawing.Size(24, 25);
            this.lblgt.TabIndex = 5;
            this.lblgt.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Black;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Lime;
            this.label7.Location = new System.Drawing.Point(385, 3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(125, 25);
            this.label7.TabIndex = 4;
            this.label7.Text = "Grandtotal :";
            // 
            // lbl_qty_total
            // 
            this.lbl_qty_total.AutoSize = true;
            this.lbl_qty_total.BackColor = System.Drawing.Color.Black;
            this.lbl_qty_total.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_qty_total.ForeColor = System.Drawing.Color.Lime;
            this.lbl_qty_total.Location = new System.Drawing.Point(248, 3);
            this.lbl_qty_total.Name = "lbl_qty_total";
            this.lbl_qty_total.Size = new System.Drawing.Size(24, 25);
            this.lbl_qty_total.TabIndex = 3;
            this.lbl_qty_total.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Black;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Lime;
            this.label3.Location = new System.Drawing.Point(149, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Quantity :";
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
            this.panel2.Size = new System.Drawing.Size(1008, 73);
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
            this.btn_back.Click += new System.EventHandler(this.btn_back_Click);
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
            this.label23.Size = new System.Drawing.Size(245, 39);
            this.label23.TabIndex = 18;
            this.label23.Text = "View Purchase";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_category_name,
            this.calBillNo,
            this.col_product_name,
            this.col_qty,
            this.col_price,
            this.col_discount,
            this.col_grand_total,
            this.col_tax,
            this.col_supplier,
            this.col_purchase_date,
            this.col_expire_date});
            this.dataGridView1.Location = new System.Drawing.Point(0, 76);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(1008, 526);
            this.dataGridView1.TabIndex = 139;
            // 
            // col_category_name
            // 
            this.col_category_name.HeaderText = "Category Name";
            this.col_category_name.Name = "col_category_name";
            this.col_category_name.ReadOnly = true;
            // 
            // calBillNo
            // 
            this.calBillNo.HeaderText = "Bill No";
            this.calBillNo.Name = "calBillNo";
            this.calBillNo.ReadOnly = true;
            // 
            // col_product_name
            // 
            this.col_product_name.HeaderText = "Product Name";
            this.col_product_name.Name = "col_product_name";
            this.col_product_name.ReadOnly = true;
            // 
            // col_qty
            // 
            this.col_qty.HeaderText = "Quantity";
            this.col_qty.Name = "col_qty";
            this.col_qty.ReadOnly = true;
            // 
            // col_price
            // 
            this.col_price.HeaderText = "Price";
            this.col_price.Name = "col_price";
            this.col_price.ReadOnly = true;
            // 
            // col_discount
            // 
            this.col_discount.HeaderText = "Discount";
            this.col_discount.Name = "col_discount";
            this.col_discount.ReadOnly = true;
            // 
            // col_grand_total
            // 
            this.col_grand_total.HeaderText = "Grand Total";
            this.col_grand_total.Name = "col_grand_total";
            this.col_grand_total.ReadOnly = true;
            // 
            // col_tax
            // 
            this.col_tax.HeaderText = "Tax";
            this.col_tax.Name = "col_tax";
            this.col_tax.ReadOnly = true;
            // 
            // col_supplier
            // 
            this.col_supplier.HeaderText = "Supplier";
            this.col_supplier.Name = "col_supplier";
            this.col_supplier.ReadOnly = true;
            // 
            // col_purchase_date
            // 
            this.col_purchase_date.HeaderText = "Purchase Date";
            this.col_purchase_date.Name = "col_purchase_date";
            this.col_purchase_date.ReadOnly = true;
            // 
            // col_expire_date
            // 
            this.col_expire_date.HeaderText = "Expire Date";
            this.col_expire_date.Name = "col_expire_date";
            this.col_expire_date.ReadOnly = true;
            this.col_expire_date.Visible = false;
            // 
            // View_Stock_Purchase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.backPanel);
            this.Controls.Add(this.searchPanel);
            this.Name = "View_Stock_Purchase";
            this.Size = new System.Drawing.Size(1014, 734);
            this.Load += new System.EventHandler(this.View_Stock_Purchase_Load);
            this.searchPanel.ResumeLayout(false);
            this.searchPanel.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.backPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel searchPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmb_search;
        private System.Windows.Forms.ComboBox cbo_searchTYpe;
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
        private DevComponents.DotNetBar.ButtonX btn_export_XML;
        private DevComponents.DotNetBar.ButtonX btn_export_to_pdf;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblgt;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbl_qty_total;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_back;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.DataGridView dataGridView1;
        private DevComponents.DotNetBar.ButtonX btn_excel;
        private System.Windows.Forms.DataGridViewTextBoxColumn calBillNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_expire_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_purchase_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_supplier;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_tax;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_grand_total;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_discount;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_price;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_product_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_category_name;
    }
}