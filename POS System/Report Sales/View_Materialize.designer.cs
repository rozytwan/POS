namespace POS_System
{
    partial class View_Materialize
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.backPanel = new System.Windows.Forms.Panel();
            this.btn_text_export = new DevComponents.DotNetBar.ButtonX();
            this.btn_export_XML = new DevComponents.DotNetBar.ButtonX();
            this.btn_export_to_pdf = new DevComponents.DotNetBar.ButtonX();
            this.btn_excel = new DevComponents.DotNetBar.ButtonX();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblgrand_total = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_taxable_amount = new System.Windows.Forms.Label();
            this.lbl_tax_amount = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_back = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label23 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cal_fiscal_year = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calbill_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_customer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_customer_pan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_bill_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_discount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_taxable_amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_tax_amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_total_amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_is_printed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_is_active = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_printed_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_enter_by = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_printed_by = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_sync_with_ird = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_is_real_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.backPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.searchPanel.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // backPanel
            // 
            this.backPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.backPanel.Controls.Add(this.btn_text_export);
            this.backPanel.Controls.Add(this.btn_export_XML);
            this.backPanel.Controls.Add(this.btn_export_to_pdf);
            this.backPanel.Controls.Add(this.btn_excel);
            this.backPanel.Controls.Add(this.panel1);
            this.backPanel.Controls.Add(this.panel2);
            this.backPanel.Controls.Add(this.dataGridView1);
            this.backPanel.Location = new System.Drawing.Point(0, 3);
            this.backPanel.Name = "backPanel";
            this.backPanel.Size = new System.Drawing.Size(1011, 681);
            this.backPanel.TabIndex = 3;
            // 
            // btn_text_export
            // 
            this.btn_text_export.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_text_export.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btn_text_export.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_text_export.Location = new System.Drawing.Point(565, 606);
            this.btn_text_export.Name = "btn_text_export";
            this.btn_text_export.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(14);
            this.btn_text_export.Size = new System.Drawing.Size(203, 50);
            this.btn_text_export.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_text_export.Symbol = "";
            this.btn_text_export.TabIndex = 143;
            this.btn_text_export.Text = "Export to Text";
            this.btn_text_export.Click += new System.EventHandler(this.btn_text_export_Click);
            // 
            // btn_export_XML
            // 
            this.btn_export_XML.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_export_XML.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btn_export_XML.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_export_XML.Location = new System.Drawing.Point(270, 605);
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
            this.btn_export_to_pdf.Location = new System.Drawing.Point(3, 605);
            this.btn_export_to_pdf.Name = "btn_export_to_pdf";
            this.btn_export_to_pdf.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(14);
            this.btn_export_to_pdf.Size = new System.Drawing.Size(203, 50);
            this.btn_export_to_pdf.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_export_to_pdf.Symbol = "";
            this.btn_export_to_pdf.TabIndex = 141;
            this.btn_export_to_pdf.Text = "Export to PDF";
            this.btn_export_to_pdf.Click += new System.EventHandler(this.btn_export_to_pdf_Click);
            // 
            // btn_excel
            // 
            this.btn_excel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_excel.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btn_excel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_excel.Location = new System.Drawing.Point(817, 604);
            this.btn_excel.Name = "btn_excel";
            this.btn_excel.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(14);
            this.btn_excel.Size = new System.Drawing.Size(182, 52);
            this.btn_excel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_excel.Symbol = "";
            this.btn_excel.TabIndex = 140;
            this.btn_excel.Text = "Export to Excel";
            this.btn_excel.Visible = false;
            this.btn_excel.Click += new System.EventHandler(this.btn_excel_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Location = new System.Drawing.Point(1, 560);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1042, 39);
            this.panel1.TabIndex = 138;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel4.Controls.Add(this.lblgrand_total);
            this.panel4.Controls.Add(this.lbl_tax_amount);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.lbl_taxable_amount);
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1039, 39);
            this.panel4.TabIndex = 137;
            // 
            // lblgrand_total
            // 
            this.lblgrand_total.AutoSize = true;
            this.lblgrand_total.BackColor = System.Drawing.Color.Black;
            this.lblgrand_total.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblgrand_total.ForeColor = System.Drawing.Color.Lime;
            this.lblgrand_total.Location = new System.Drawing.Point(586, 7);
            this.lblgrand_total.Name = "lblgrand_total";
            this.lblgrand_total.Size = new System.Drawing.Size(24, 25);
            this.lblgrand_total.TabIndex = 3;
            this.lblgrand_total.Text = "0";
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
            // lbl_taxable_amount
            // 
            this.lbl_taxable_amount.AutoSize = true;
            this.lbl_taxable_amount.BackColor = System.Drawing.Color.Black;
            this.lbl_taxable_amount.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_taxable_amount.ForeColor = System.Drawing.Color.Lime;
            this.lbl_taxable_amount.Location = new System.Drawing.Point(382, 7);
            this.lbl_taxable_amount.Name = "lbl_taxable_amount";
            this.lbl_taxable_amount.Size = new System.Drawing.Size(24, 25);
            this.lbl_taxable_amount.TabIndex = 1;
            this.lbl_taxable_amount.Text = "0";
            // 
            // lbl_tax_amount
            // 
            this.lbl_tax_amount.AutoSize = true;
            this.lbl_tax_amount.BackColor = System.Drawing.Color.Black;
            this.lbl_tax_amount.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_tax_amount.ForeColor = System.Drawing.Color.Lime;
            this.lbl_tax_amount.Location = new System.Drawing.Point(469, 7);
            this.lbl_tax_amount.Name = "lbl_tax_amount";
            this.lbl_tax_amount.Size = new System.Drawing.Size(24, 25);
            this.lbl_tax_amount.TabIndex = 0;
            this.lbl_tax_amount.Text = "0";
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
            this.panel2.Size = new System.Drawing.Size(1011, 73);
            this.panel2.TabIndex = 130;
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
            this.label23.Size = new System.Drawing.Size(414, 39);
            this.label23.TabIndex = 18;
            this.label23.Text = "View  Materialized Report ";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cal_fiscal_year,
            this.calbill_no,
            this.cal_customer,
            this.cal_customer_pan,
            this.cal_bill_date,
            this.cal_amount,
            this.cal_discount,
            this.cal_taxable_amount,
            this.cal_tax_amount,
            this.cal_total_amount,
            this.cal_is_printed,
            this.cal_is_active,
            this.cal_printed_time,
            this.cal_enter_by,
            this.cal_printed_by,
            this.cal_sync_with_ird,
            this.cal_is_real_time});
            this.dataGridView1.Location = new System.Drawing.Point(1, 73);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(1010, 491);
            this.dataGridView1.TabIndex = 139;
            // 
            // cal_fiscal_year
            // 
            this.cal_fiscal_year.HeaderText = "Fiscal Year";
            this.cal_fiscal_year.Name = "cal_fiscal_year";
            this.cal_fiscal_year.ReadOnly = true;
            // 
            // calbill_no
            // 
            this.calbill_no.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.calbill_no.HeaderText = "Bill No";
            this.calbill_no.Name = "calbill_no";
            this.calbill_no.ReadOnly = true;
            this.calbill_no.Width = 60;
            // 
            // cal_customer
            // 
            this.cal_customer.HeaderText = "Customer Name";
            this.cal_customer.Name = "cal_customer";
            this.cal_customer.ReadOnly = true;
            // 
            // cal_customer_pan
            // 
            this.cal_customer_pan.HeaderText = "Customer Pan";
            this.cal_customer_pan.Name = "cal_customer_pan";
            this.cal_customer_pan.ReadOnly = true;
            // 
            // cal_bill_date
            // 
            this.cal_bill_date.HeaderText = "Billing Date";
            this.cal_bill_date.Name = "cal_bill_date";
            this.cal_bill_date.ReadOnly = true;
            // 
            // cal_amount
            // 
            this.cal_amount.HeaderText = "Amount";
            this.cal_amount.Name = "cal_amount";
            this.cal_amount.ReadOnly = true;
            // 
            // cal_discount
            // 
            this.cal_discount.HeaderText = "Discount";
            this.cal_discount.Name = "cal_discount";
            this.cal_discount.ReadOnly = true;
            // 
            // cal_taxable_amount
            // 
            this.cal_taxable_amount.HeaderText = "Taxable Amount";
            this.cal_taxable_amount.Name = "cal_taxable_amount";
            this.cal_taxable_amount.ReadOnly = true;
            // 
            // cal_tax_amount
            // 
            this.cal_tax_amount.HeaderText = "Tax Amount";
            this.cal_tax_amount.Name = "cal_tax_amount";
            this.cal_tax_amount.ReadOnly = true;
            // 
            // cal_total_amount
            // 
            this.cal_total_amount.HeaderText = "Total Amount";
            this.cal_total_amount.Name = "cal_total_amount";
            this.cal_total_amount.ReadOnly = true;
            // 
            // cal_is_printed
            // 
            this.cal_is_printed.HeaderText = "Is Printed";
            this.cal_is_printed.Name = "cal_is_printed";
            this.cal_is_printed.ReadOnly = true;
            // 
            // cal_is_active
            // 
            this.cal_is_active.HeaderText = "Is Active";
            this.cal_is_active.Name = "cal_is_active";
            this.cal_is_active.ReadOnly = true;
            // 
            // cal_printed_time
            // 
            this.cal_printed_time.HeaderText = "Printed Time";
            this.cal_printed_time.Name = "cal_printed_time";
            this.cal_printed_time.ReadOnly = true;
            // 
            // cal_enter_by
            // 
            this.cal_enter_by.HeaderText = "Enter By";
            this.cal_enter_by.Name = "cal_enter_by";
            this.cal_enter_by.ReadOnly = true;
            // 
            // cal_printed_by
            // 
            this.cal_printed_by.HeaderText = "Printed By";
            this.cal_printed_by.Name = "cal_printed_by";
            this.cal_printed_by.ReadOnly = true;
            // 
            // cal_sync_with_ird
            // 
            this.cal_sync_with_ird.HeaderText = "Sync IRD";
            this.cal_sync_with_ird.Name = "cal_sync_with_ird";
            this.cal_sync_with_ird.ReadOnly = true;
            // 
            // cal_is_real_time
            // 
            this.cal_is_real_time.HeaderText = "Is Real Time";
            this.cal_is_real_time.Name = "cal_is_real_time";
            this.cal_is_real_time.ReadOnly = true;
            // 
            // searchPanel
            // 
            this.searchPanel.BackColor = System.Drawing.Color.White;
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
            this.searchPanel.Location = new System.Drawing.Point(315, 3);
            this.searchPanel.Name = "searchPanel";
            this.searchPanel.Size = new System.Drawing.Size(418, 289);
            this.searchPanel.TabIndex = 147;
            // 
            // txt_searchText
            // 
            this.txt_searchText.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txt_searchText.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.txt_searchText.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_searchText.FormattingEnabled = true;
            this.txt_searchText.Items.AddRange(new object[] {
            "Choose Type",
            "Product",
            "Category"});
            this.txt_searchText.Location = new System.Drawing.Point(134, 132);
            this.txt_searchText.Name = "txt_searchText";
            this.txt_searchText.Size = new System.Drawing.Size(218, 33);
            this.txt_searchText.TabIndex = 124;
            // 
            // cbo_searchTYpe
            // 
            this.cbo_searchTYpe.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_searchTYpe.FormattingEnabled = true;
            this.cbo_searchTYpe.Items.AddRange(new object[] {
            "Choose Type",
            "Bill No",
            "ALL",
            "Fiscal Year"});
            this.cbo_searchTYpe.Location = new System.Drawing.Point(134, 89);
            this.cbo_searchTYpe.Name = "cbo_searchTYpe";
            this.cbo_searchTYpe.Size = new System.Drawing.Size(218, 33);
            this.cbo_searchTYpe.TabIndex = 123;
            this.cbo_searchTYpe.SelectedIndexChanged += new System.EventHandler(this.cbo_searchTYpe_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(92, 144);
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
            this.label2.Location = new System.Drawing.Point(57, 101);
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
            this.panel3.Location = new System.Drawing.Point(-1, -1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(412, 73);
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
            this.btnbackpage.Click += new System.EventHandler(this.btnbackpage_Click);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(132, 25);
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
            this.btn_exit.Location = new System.Drawing.Point(245, 247);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(107, 36);
            this.btn_exit.TabIndex = 119;
            this.btn_exit.Text = "Exit";
            this.btn_exit.UseVisualStyleBackColor = false;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // btn_show
            // 
            this.btn_show.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_show.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.btn_show.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_show.ForeColor = System.Drawing.Color.White;
            this.btn_show.Location = new System.Drawing.Point(134, 247);
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
            this.dtp_to.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_to.Location = new System.Drawing.Point(134, 211);
            this.dtp_to.Name = "dtp_to";
            this.dtp_to.Size = new System.Drawing.Size(218, 30);
            this.dtp_to.TabIndex = 117;
            this.dtp_to.Value = new System.DateTime(2016, 7, 18, 12, 44, 51, 0);
            // 
            // dtp_from
            // 
            this.dtp_from.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dtp_from.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_from.Location = new System.Drawing.Point(134, 175);
            this.dtp_from.Name = "dtp_from";
            this.dtp_from.Size = new System.Drawing.Size(218, 30);
            this.dtp_from.TabIndex = 116;
            this.dtp_from.Value = new System.DateTime(2016, 7, 18, 12, 44, 38, 0);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(79, 220);
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
            this.label6.Location = new System.Drawing.Point(69, 189);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 115;
            this.label6.Text = "Date From:";
            // 
            // View_Materialize
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.backPanel);
            this.Controls.Add(this.searchPanel);
            this.Name = "View_Materialize";
            this.Size = new System.Drawing.Size(1011, 681);
            this.Load += new System.EventHandler(this.View_Materialize_Load);
            this.backPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.searchPanel.ResumeLayout(false);
            this.searchPanel.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel backPanel;
        private DevComponents.DotNetBar.ButtonX btn_text_export;
        private DevComponents.DotNetBar.ButtonX btn_export_XML;
        private DevComponents.DotNetBar.ButtonX btn_export_to_pdf;
        private DevComponents.DotNetBar.ButtonX btn_excel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblgrand_total;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_taxable_amount;
        private System.Windows.Forms.Label lbl_tax_amount;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_back;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.DataGridView dataGridView1;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_fiscal_year;
        private System.Windows.Forms.DataGridViewTextBoxColumn calbill_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_customer;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_customer_pan;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_bill_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_discount;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_taxable_amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_tax_amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_total_amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_is_printed;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_is_active;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_printed_time;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_enter_by;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_printed_by;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_sync_with_ird;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_is_real_time;
    }
}
