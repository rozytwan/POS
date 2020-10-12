using System.Windows.Forms;

namespace POS_System
{
    partial class Viewrestaurant_sales_report
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_back = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label23 = new System.Windows.Forms.Label();
            this.backPanel = new System.Windows.Forms.Panel();
            this.btn_text_export = new DevComponents.DotNetBar.ButtonX();
            this.btn_export_XML = new DevComponents.DotNetBar.ButtonX();
            this.btn_export_to_pdf = new DevComponents.DotNetBar.ButtonX();
            this.btn_excel = new DevComponents.DotNetBar.ButtonX();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lbl_total_with_discount = new System.Windows.Forms.Label();
            this.lbl_discount = new System.Windows.Forms.Label();
            this.lbl_sub_total = new System.Windows.Forms.Label();
            this.lbl_service_charge = new System.Windows.Forms.Label();
            this.lbl_net_sales = new System.Windows.Forms.Label();
            this.lbl_tax_amount = new System.Windows.Forms.Label();
            this.lblgrand_total = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.caldate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calbill_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_sub_total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_discount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_total_sales_amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_service_charge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_net_sales = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_tax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_grand_total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_service_provider = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calcashamt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calcardamount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.caltotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calitem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calquantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calpaymode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calcashier_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_sales_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_kot_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_print = new System.Windows.Forms.DataGridViewButtonColumn();
            this.cal_date2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_sales_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_table_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_category_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_tax_back = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.backPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.searchPanel.SuspendLayout();
            this.panel3.SuspendLayout();
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
            this.panel2.Size = new System.Drawing.Size(1021, 73);
            this.panel2.TabIndex = 130;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
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
            this.btn_back.Click += new System.EventHandler(this.btn_back_Click_1);
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
            this.label23.Size = new System.Drawing.Size(325, 39);
            this.label23.TabIndex = 18;
            this.label23.Text = "View  Sales  Report ";
            // 
            // backPanel
            // 
            this.backPanel.Controls.Add(this.btn_text_export);
            this.backPanel.Controls.Add(this.btn_export_XML);
            this.backPanel.Controls.Add(this.btn_export_to_pdf);
            this.backPanel.Controls.Add(this.btn_excel);
            this.backPanel.Controls.Add(this.panel1);
            this.backPanel.Controls.Add(this.panel2);
            this.backPanel.Controls.Add(this.dataGridView1);
            this.backPanel.Location = new System.Drawing.Point(3, 3);
            this.backPanel.Name = "backPanel";
            this.backPanel.Size = new System.Drawing.Size(1021, 720);
            this.backPanel.TabIndex = 2;
            // 
            // btn_text_export
            // 
            this.btn_text_export.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_text_export.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btn_text_export.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_text_export.Location = new System.Drawing.Point(608, 606);
            this.btn_text_export.Name = "btn_text_export";
            this.btn_text_export.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(14);
            this.btn_text_export.Size = new System.Drawing.Size(203, 50);
            this.btn_text_export.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_text_export.Symbol = "";
            this.btn_text_export.TabIndex = 143;
            this.btn_text_export.Text = "Export to Text";
            // 
            // btn_export_XML
            // 
            this.btn_export_XML.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_export_XML.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btn_export_XML.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_export_XML.Location = new System.Drawing.Point(393, 605);
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
            this.btn_export_to_pdf.Location = new System.Drawing.Point(178, 605);
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
            this.btn_excel.Location = new System.Drawing.Point(823, 603);
            this.btn_excel.Name = "btn_excel";
            this.btn_excel.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(14);
            this.btn_excel.Size = new System.Drawing.Size(182, 52);
            this.btn_excel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_excel.Symbol = "";
            this.btn_excel.TabIndex = 140;
            this.btn_excel.Text = "Export to Excel";
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
            this.panel4.Controls.Add(this.lbl_total_with_discount);
            this.panel4.Controls.Add(this.lbl_discount);
            this.panel4.Controls.Add(this.lbl_sub_total);
            this.panel4.Controls.Add(this.lbl_service_charge);
            this.panel4.Controls.Add(this.lbl_net_sales);
            this.panel4.Controls.Add(this.lbl_tax_amount);
            this.panel4.Controls.Add(this.lblgrand_total);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1039, 39);
            this.panel4.TabIndex = 137;
            // 
            // lbl_total_with_discount
            // 
            this.lbl_total_with_discount.AutoSize = true;
            this.lbl_total_with_discount.BackColor = System.Drawing.Color.Black;
            this.lbl_total_with_discount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_total_with_discount.ForeColor = System.Drawing.Color.Lime;
            this.lbl_total_with_discount.Location = new System.Drawing.Point(361, 6);
            this.lbl_total_with_discount.Name = "lbl_total_with_discount";
            this.lbl_total_with_discount.Size = new System.Drawing.Size(19, 20);
            this.lbl_total_with_discount.TabIndex = 9;
            this.lbl_total_with_discount.Text = "0";
            // 
            // lbl_discount
            // 
            this.lbl_discount.AutoSize = true;
            this.lbl_discount.BackColor = System.Drawing.Color.Black;
            this.lbl_discount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_discount.ForeColor = System.Drawing.Color.Lime;
            this.lbl_discount.Location = new System.Drawing.Point(269, 6);
            this.lbl_discount.Name = "lbl_discount";
            this.lbl_discount.Size = new System.Drawing.Size(19, 20);
            this.lbl_discount.TabIndex = 8;
            this.lbl_discount.Text = "0";
            // 
            // lbl_sub_total
            // 
            this.lbl_sub_total.AutoSize = true;
            this.lbl_sub_total.BackColor = System.Drawing.Color.Black;
            this.lbl_sub_total.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_sub_total.ForeColor = System.Drawing.Color.Lime;
            this.lbl_sub_total.Location = new System.Drawing.Point(148, 6);
            this.lbl_sub_total.Name = "lbl_sub_total";
            this.lbl_sub_total.Size = new System.Drawing.Size(19, 20);
            this.lbl_sub_total.TabIndex = 7;
            this.lbl_sub_total.Text = "0";
            // 
            // lbl_service_charge
            // 
            this.lbl_service_charge.AutoSize = true;
            this.lbl_service_charge.BackColor = System.Drawing.Color.Black;
            this.lbl_service_charge.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_service_charge.ForeColor = System.Drawing.Color.Lime;
            this.lbl_service_charge.Location = new System.Drawing.Point(478, 7);
            this.lbl_service_charge.Name = "lbl_service_charge";
            this.lbl_service_charge.Size = new System.Drawing.Size(19, 20);
            this.lbl_service_charge.TabIndex = 6;
            this.lbl_service_charge.Text = "0";
            // 
            // lbl_net_sales
            // 
            this.lbl_net_sales.AutoSize = true;
            this.lbl_net_sales.BackColor = System.Drawing.Color.Black;
            this.lbl_net_sales.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_net_sales.ForeColor = System.Drawing.Color.Lime;
            this.lbl_net_sales.Location = new System.Drawing.Point(570, 7);
            this.lbl_net_sales.Name = "lbl_net_sales";
            this.lbl_net_sales.Size = new System.Drawing.Size(19, 20);
            this.lbl_net_sales.TabIndex = 5;
            this.lbl_net_sales.Text = "0";
            // 
            // lbl_tax_amount
            // 
            this.lbl_tax_amount.AutoSize = true;
            this.lbl_tax_amount.BackColor = System.Drawing.Color.Black;
            this.lbl_tax_amount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_tax_amount.ForeColor = System.Drawing.Color.Lime;
            this.lbl_tax_amount.Location = new System.Drawing.Point(683, 6);
            this.lbl_tax_amount.Name = "lbl_tax_amount";
            this.lbl_tax_amount.Size = new System.Drawing.Size(19, 20);
            this.lbl_tax_amount.TabIndex = 4;
            this.lbl_tax_amount.Text = "0";
            // 
            // lblgrand_total
            // 
            this.lblgrand_total.AutoSize = true;
            this.lblgrand_total.BackColor = System.Drawing.Color.Black;
            this.lblgrand_total.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblgrand_total.ForeColor = System.Drawing.Color.Lime;
            this.lblgrand_total.Location = new System.Drawing.Point(788, 6);
            this.lblgrand_total.Name = "lblgrand_total";
            this.lblgrand_total.Size = new System.Drawing.Size(19, 20);
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
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.caldate,
            this.calbill_no,
            this.cal_sub_total,
            this.cal_discount,
            this.cal_total_sales_amount,
            this.cal_service_charge,
            this.cal_net_sales,
            this.cal_tax,
            this.cal_grand_total,
            this.col_service_provider,
            this.calcashamt,
            this.calcardamount,
            this.caltotal,
            this.calitem,
            this.calquantity,
            this.calpaymode,
            this.calcashier_name,
            this.cal_sales_type,
            this.cal_kot_type,
            this.cal_print,
            this.cal_date2,
            this.cal_sales_id,
            this.cal_table_no,
            this.cal_cost,
            this.cal_category_name,
            this.cal_tax_back});
            this.dataGridView1.Location = new System.Drawing.Point(3, 76);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(1018, 466);
            this.dataGridView1.TabIndex = 139;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // caldate
            // 
            this.caldate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.caldate.FillWeight = 72.52538F;
            this.caldate.HeaderText = "Date";
            this.caldate.Name = "caldate";
            this.caldate.ReadOnly = true;
            // 
            // calbill_no
            // 
            this.calbill_no.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.calbill_no.FillWeight = 319.797F;
            this.calbill_no.HeaderText = "Bill No";
            this.calbill_no.Name = "calbill_no";
            this.calbill_no.ReadOnly = true;
            this.calbill_no.Width = 70;
            // 
            // cal_sub_total
            // 
            this.cal_sub_total.FillWeight = 76F;
            this.cal_sub_total.HeaderText = "Sub Total";
            this.cal_sub_total.Name = "cal_sub_total";
            this.cal_sub_total.ReadOnly = true;
            // 
            // cal_discount
            // 
            this.cal_discount.FillWeight = 65F;
            this.cal_discount.HeaderText = "Tax Sales Discount";
            this.cal_discount.Name = "cal_discount";
            this.cal_discount.ReadOnly = true;
            // 
            // cal_total_sales_amount
            // 
            this.cal_total_sales_amount.FillWeight = 80F;
            this.cal_total_sales_amount.HeaderText = "Total Sales Amount";
            this.cal_total_sales_amount.Name = "cal_total_sales_amount";
            this.cal_total_sales_amount.ReadOnly = true;
            // 
            // cal_service_charge
            // 
            this.cal_service_charge.FillWeight = 65F;
            this.cal_service_charge.HeaderText = "Service Charge";
            this.cal_service_charge.Name = "cal_service_charge";
            this.cal_service_charge.ReadOnly = true;
            // 
            // cal_net_sales
            // 
            this.cal_net_sales.FillWeight = 80F;
            this.cal_net_sales.HeaderText = "Net Sales";
            this.cal_net_sales.Name = "cal_net_sales";
            this.cal_net_sales.ReadOnly = true;
            // 
            // cal_tax
            // 
            this.cal_tax.FillWeight = 72.52538F;
            this.cal_tax.HeaderText = "Taxable Sale Tax (Rs)";
            this.cal_tax.Name = "cal_tax";
            this.cal_tax.ReadOnly = true;
            // 
            // cal_grand_total
            // 
            this.cal_grand_total.FillWeight = 90F;
            this.cal_grand_total.HeaderText = "Grand Total";
            this.cal_grand_total.Name = "cal_grand_total";
            this.cal_grand_total.ReadOnly = true;
            // 
            // col_service_provider
            // 
            this.col_service_provider.HeaderText = "Service Provider";
            this.col_service_provider.Name = "col_service_provider";
            this.col_service_provider.ReadOnly = true;
            // 
            // calcashamt
            // 
            this.calcashamt.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.calcashamt.HeaderText = "Cash Amt.";
            this.calcashamt.Name = "calcashamt";
            this.calcashamt.ReadOnly = true;
            this.calcashamt.Visible = false;
            this.calcashamt.Width = 73;
            // 
            // calcardamount
            // 
            this.calcardamount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.calcardamount.HeaderText = "Card Amt.";
            this.calcardamount.Name = "calcardamount";
            this.calcardamount.ReadOnly = true;
            this.calcardamount.Visible = false;
            this.calcardamount.Width = 73;
            // 
            // caltotal
            // 
            this.caltotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.caltotal.HeaderText = "Total";
            this.caltotal.Name = "caltotal";
            this.caltotal.ReadOnly = true;
            this.caltotal.Visible = false;
            this.caltotal.Width = 73;
            // 
            // calitem
            // 
            this.calitem.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.calitem.HeaderText = "Item";
            this.calitem.Name = "calitem";
            this.calitem.ReadOnly = true;
            this.calitem.Visible = false;
            // 
            // calquantity
            // 
            this.calquantity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.calquantity.HeaderText = "Quantity";
            this.calquantity.Name = "calquantity";
            this.calquantity.ReadOnly = true;
            this.calquantity.Visible = false;
            this.calquantity.Width = 50;
            // 
            // calpaymode
            // 
            this.calpaymode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.calpaymode.HeaderText = "PayMode";
            this.calpaymode.Name = "calpaymode";
            this.calpaymode.ReadOnly = true;
            this.calpaymode.Visible = false;
            this.calpaymode.Width = 72;
            // 
            // calcashier_name
            // 
            this.calcashier_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.calcashier_name.HeaderText = "Cashier";
            this.calcashier_name.Name = "calcashier_name";
            this.calcashier_name.ReadOnly = true;
            this.calcashier_name.Visible = false;
            this.calcashier_name.Width = 73;
            // 
            // cal_sales_type
            // 
            this.cal_sales_type.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cal_sales_type.HeaderText = "Sales Type";
            this.cal_sales_type.Name = "cal_sales_type";
            this.cal_sales_type.ReadOnly = true;
            this.cal_sales_type.Visible = false;
            this.cal_sales_type.Width = 72;
            // 
            // cal_kot_type
            // 
            this.cal_kot_type.HeaderText = "Kot Type";
            this.cal_kot_type.Name = "cal_kot_type";
            this.cal_kot_type.ReadOnly = true;
            this.cal_kot_type.Visible = false;
            // 
            // cal_print
            // 
            this.cal_print.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cal_print.HeaderText = "Print";
            this.cal_print.Name = "cal_print";
            this.cal_print.ReadOnly = true;
            this.cal_print.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cal_print.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.cal_print.Text = "Print";
            this.cal_print.UseColumnTextForButtonValue = true;
            this.cal_print.Visible = false;
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
            // cal_tax_back
            // 
            this.cal_tax_back.HeaderText = "Tax Back";
            this.cal_tax_back.Name = "cal_tax_back";
            this.cal_tax_back.ReadOnly = true;
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
            this.searchPanel.Location = new System.Drawing.Point(350, 3);
            this.searchPanel.Name = "searchPanel";
            this.searchPanel.Size = new System.Drawing.Size(418, 289);
            this.searchPanel.TabIndex = 145;
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
            "Payment Mode",
            "Sales Type",
            "User",
            "Customer Name",
            "Service Provider"});
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
            this.panel3.Location = new System.Drawing.Point(6, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(405, 73);
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
            this.label4.Location = new System.Drawing.Point(128, 25);
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
            this.btn_show.Click += new System.EventHandler(this.btn_show_Click_1);
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
            // Viewrestaurant_sales_report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.backPanel);
            this.Controls.Add(this.searchPanel);
            this.Name = "Viewrestaurant_sales_report";
            this.Size = new System.Drawing.Size(1027, 720);
            this.Load += new System.EventHandler(this.Viewrestaurant_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.backPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.searchPanel.ResumeLayout(false);
            this.searchPanel.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_back;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Panel backPanel;
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
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label3;
        private Label lblgrand_total;
        private DevComponents.DotNetBar.ButtonX btn_excel;
        private DevComponents.DotNetBar.ButtonX btn_export_to_pdf;
        private DevComponents.DotNetBar.ButtonX btn_export_XML;
        private DevComponents.DotNetBar.ButtonX btn_text_export;
        private Label lbl_tax_amount;
        private Label lbl_service_charge;
        private Label lbl_net_sales;
        private Label lbl_total_with_discount;
        private Label lbl_discount;
        private Label lbl_sub_total;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn cal_tax_back;
        private DataGridViewTextBoxColumn cal_category_name;
        private DataGridViewTextBoxColumn cal_cost;
        private DataGridViewTextBoxColumn cal_table_no;
        private DataGridViewTextBoxColumn cal_sales_id;
        private DataGridViewTextBoxColumn cal_date2;
        private DataGridViewButtonColumn cal_print;
        private DataGridViewTextBoxColumn cal_kot_type;
        private DataGridViewTextBoxColumn cal_sales_type;
        private DataGridViewTextBoxColumn calcashier_name;
        private DataGridViewTextBoxColumn calpaymode;
        private DataGridViewTextBoxColumn calquantity;
        private DataGridViewTextBoxColumn calitem;
        private DataGridViewTextBoxColumn caltotal;
        private DataGridViewTextBoxColumn calcardamount;
        private DataGridViewTextBoxColumn calcashamt;
        private DataGridViewTextBoxColumn col_service_provider;
        private DataGridViewTextBoxColumn cal_grand_total;
        private DataGridViewTextBoxColumn cal_tax;
        private DataGridViewTextBoxColumn cal_net_sales;
        private DataGridViewTextBoxColumn cal_service_charge;
        private DataGridViewTextBoxColumn cal_total_sales_amount;
        private DataGridViewTextBoxColumn cal_discount;
        private DataGridViewTextBoxColumn cal_sub_total;
        private DataGridViewTextBoxColumn calbill_no;
        private DataGridViewTextBoxColumn caldate;
    }
}
