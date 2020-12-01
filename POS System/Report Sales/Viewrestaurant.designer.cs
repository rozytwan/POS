using System.Windows.Forms;

namespace POS_System
{
    partial class Viewrestaurant
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btn_previous = new DevComponents.DotNetBar.ButtonX();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.btn_text_export = new DevComponents.DotNetBar.ButtonX();
            this.btn_export_XML = new DevComponents.DotNetBar.ButtonX();
            this.btn_export_to_pdf = new DevComponents.DotNetBar.ButtonX();
            this.btn_excel = new DevComponents.DotNetBar.ButtonX();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btn_next = new DevComponents.DotNetBar.ButtonX();
            this.lbl_grand_total = new System.Windows.Forms.Label();
            this.lbl_tax = new System.Windows.Forms.Label();
            this.lbl_service_charge = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblsubtotal = new System.Windows.Forms.Label();
            this.lbltaotal_quantity = new System.Windows.Forms.Label();
            this.searchPanel = new System.Windows.Forms.Panel();
            this.cbo_minuts = new System.Windows.Forms.ComboBox();
            this.cbo_to_hours = new System.Windows.Forms.ComboBox();
            this.cbo_minuts_from = new System.Windows.Forms.ComboBox();
            this.cbo_from_hours = new System.Windows.Forms.ComboBox();
            this.chk_time = new System.Windows.Forms.CheckBox();
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
            this.calbill_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_fiscal_year = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calitem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calquantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.caltotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.caldate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_sub_total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_discount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_service_charge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_tax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_grand_total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calpaymode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calcardamount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calcashamt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_credit_amt = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.backPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
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
            this.panel2.Size = new System.Drawing.Size(1007, 73);
            this.panel2.TabIndex = 130;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
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
            this.label23.Size = new System.Drawing.Size(430, 39);
            this.label23.TabIndex = 18;
            this.label23.Text = "View Details  Sales Report ";
            // 
            // backPanel
            // 
            this.backPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.backPanel.Controls.Add(this.dataGridView1);
            this.backPanel.Controls.Add(this.btn_previous);
            this.backPanel.Controls.Add(this.buttonX1);
            this.backPanel.Controls.Add(this.btn_text_export);
            this.backPanel.Controls.Add(this.btn_export_XML);
            this.backPanel.Controls.Add(this.btn_export_to_pdf);
            this.backPanel.Controls.Add(this.btn_excel);
            this.backPanel.Controls.Add(this.panel1);
            this.backPanel.Controls.Add(this.panel2);
            this.backPanel.Location = new System.Drawing.Point(3, 3);
            this.backPanel.Name = "backPanel";
            this.backPanel.Size = new System.Drawing.Size(1007, 680);
            this.backPanel.TabIndex = 2;
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
            this.col_fiscal_year,
            this.calitem,
            this.calquantity,
            this.caltotal,
            this.caldate,
            this.cal_sub_total,
            this.cal_discount,
            this.cal_service_charge,
            this.cal_tax,
            this.cal_grand_total,
            this.calpaymode,
            this.calcardamount,
            this.calcashamt,
            this.cal_credit_amt,
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
            this.dataGridView1.Location = new System.Drawing.Point(0, 74);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(1007, 489);
            this.dataGridView1.TabIndex = 139;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // btn_previous
            // 
            this.btn_previous.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_previous.BackColor = System.Drawing.Color.Black;
            this.btn_previous.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btn_previous.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_previous.Location = new System.Drawing.Point(912, 565);
            this.btn_previous.Name = "btn_previous";
            this.btn_previous.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(14);
            this.btn_previous.Size = new System.Drawing.Size(37, 31);
            this.btn_previous.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_previous.Symbol = "";
            this.btn_previous.TabIndex = 147;
            this.btn_previous.Click += new System.EventHandler(this.btn_previous_Click);
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.buttonX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonX1.Location = new System.Drawing.Point(846, 610);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(14);
            this.buttonX1.Size = new System.Drawing.Size(156, 52);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.Symbol = "";
            this.buttonX1.TabIndex = 144;
            this.buttonX1.Text = "Print Item";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // btn_text_export
            // 
            this.btn_text_export.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_text_export.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btn_text_export.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_text_export.Location = new System.Drawing.Point(431, 613);
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
            this.btn_export_XML.Location = new System.Drawing.Point(217, 616);
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
            this.btn_export_to_pdf.Location = new System.Drawing.Point(3, 616);
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
            this.btn_excel.Location = new System.Drawing.Point(658, 610);
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
            this.panel4.Controls.Add(this.btn_next);
            this.panel4.Controls.Add(this.lbl_grand_total);
            this.panel4.Controls.Add(this.lbl_tax);
            this.panel4.Controls.Add(this.lbl_service_charge);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.lblsubtotal);
            this.panel4.Controls.Add(this.lbltaotal_quantity);
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1039, 39);
            this.panel4.TabIndex = 137;
            // 
            // btn_next
            // 
            this.btn_next.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_next.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btn_next.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_next.Location = new System.Drawing.Point(954, 5);
            this.btn_next.Name = "btn_next";
            this.btn_next.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(14);
            this.btn_next.Size = new System.Drawing.Size(37, 31);
            this.btn_next.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_next.Symbol = "";
            this.btn_next.TabIndex = 146;
            this.btn_next.Click += new System.EventHandler(this.btn_next_Click);
            // 
            // lbl_grand_total
            // 
            this.lbl_grand_total.AutoSize = true;
            this.lbl_grand_total.BackColor = System.Drawing.Color.Black;
            this.lbl_grand_total.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_grand_total.ForeColor = System.Drawing.Color.Lime;
            this.lbl_grand_total.Location = new System.Drawing.Point(548, 6);
            this.lbl_grand_total.Name = "lbl_grand_total";
            this.lbl_grand_total.Size = new System.Drawing.Size(24, 25);
            this.lbl_grand_total.TabIndex = 5;
            this.lbl_grand_total.Text = "0";
            // 
            // lbl_tax
            // 
            this.lbl_tax.AutoSize = true;
            this.lbl_tax.BackColor = System.Drawing.Color.Black;
            this.lbl_tax.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_tax.ForeColor = System.Drawing.Color.Lime;
            this.lbl_tax.Location = new System.Drawing.Point(421, 8);
            this.lbl_tax.Name = "lbl_tax";
            this.lbl_tax.Size = new System.Drawing.Size(19, 20);
            this.lbl_tax.TabIndex = 4;
            this.lbl_tax.Text = "0";
            this.lbl_tax.Visible = false;
            // 
            // lbl_service_charge
            // 
            this.lbl_service_charge.AutoSize = true;
            this.lbl_service_charge.BackColor = System.Drawing.Color.Black;
            this.lbl_service_charge.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_service_charge.ForeColor = System.Drawing.Color.Lime;
            this.lbl_service_charge.Location = new System.Drawing.Point(344, 8);
            this.lbl_service_charge.Name = "lbl_service_charge";
            this.lbl_service_charge.Size = new System.Drawing.Size(19, 20);
            this.lbl_service_charge.TabIndex = 3;
            this.lbl_service_charge.Text = "0";
            this.lbl_service_charge.Visible = false;
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
            // lblsubtotal
            // 
            this.lblsubtotal.AutoSize = true;
            this.lblsubtotal.BackColor = System.Drawing.Color.Black;
            this.lblsubtotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsubtotal.ForeColor = System.Drawing.Color.Lime;
            this.lblsubtotal.Location = new System.Drawing.Point(211, 7);
            this.lblsubtotal.Name = "lblsubtotal";
            this.lblsubtotal.Size = new System.Drawing.Size(19, 20);
            this.lblsubtotal.TabIndex = 1;
            this.lblsubtotal.Text = "0";
            // 
            // lbltaotal_quantity
            // 
            this.lbltaotal_quantity.AutoSize = true;
            this.lbltaotal_quantity.BackColor = System.Drawing.Color.Black;
            this.lbltaotal_quantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltaotal_quantity.ForeColor = System.Drawing.Color.Lime;
            this.lbltaotal_quantity.Location = new System.Drawing.Point(158, 7);
            this.lbltaotal_quantity.Name = "lbltaotal_quantity";
            this.lbltaotal_quantity.Size = new System.Drawing.Size(19, 20);
            this.lbltaotal_quantity.TabIndex = 0;
            this.lbltaotal_quantity.Text = "0";
            // 
            // searchPanel
            // 
            this.searchPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchPanel.Controls.Add(this.cbo_minuts);
            this.searchPanel.Controls.Add(this.cbo_to_hours);
            this.searchPanel.Controls.Add(this.cbo_minuts_from);
            this.searchPanel.Controls.Add(this.cbo_from_hours);
            this.searchPanel.Controls.Add(this.chk_time);
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
            this.searchPanel.Size = new System.Drawing.Size(496, 289);
            this.searchPanel.TabIndex = 145;
            // 
            // cbo_minuts
            // 
            this.cbo_minuts.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_minuts.FormattingEnabled = true;
            this.cbo_minuts.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59",
            "60",
            "00"});
            this.cbo_minuts.Location = new System.Drawing.Point(375, 217);
            this.cbo_minuts.Name = "cbo_minuts";
            this.cbo_minuts.Size = new System.Drawing.Size(40, 28);
            this.cbo_minuts.TabIndex = 133;
            this.cbo_minuts.SelectedIndexChanged += new System.EventHandler(this.cbo_minuts_SelectedIndexChanged);
            // 
            // cbo_to_hours
            // 
            this.cbo_to_hours.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_to_hours.FormattingEnabled = true;
            this.cbo_to_hours.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "00"});
            this.cbo_to_hours.Location = new System.Drawing.Point(328, 217);
            this.cbo_to_hours.Name = "cbo_to_hours";
            this.cbo_to_hours.Size = new System.Drawing.Size(39, 28);
            this.cbo_to_hours.TabIndex = 132;
            this.cbo_to_hours.SelectedIndexChanged += new System.EventHandler(this.cbo_to_hours_SelectedIndexChanged);
            // 
            // cbo_minuts_from
            // 
            this.cbo_minuts_from.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_minuts_from.FormattingEnabled = true;
            this.cbo_minuts_from.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59",
            "60",
            "00"});
            this.cbo_minuts_from.Location = new System.Drawing.Point(375, 175);
            this.cbo_minuts_from.Name = "cbo_minuts_from";
            this.cbo_minuts_from.Size = new System.Drawing.Size(40, 28);
            this.cbo_minuts_from.TabIndex = 131;
            // 
            // cbo_from_hours
            // 
            this.cbo_from_hours.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_from_hours.FormattingEnabled = true;
            this.cbo_from_hours.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "00"});
            this.cbo_from_hours.Location = new System.Drawing.Point(326, 175);
            this.cbo_from_hours.Name = "cbo_from_hours";
            this.cbo_from_hours.Size = new System.Drawing.Size(39, 28);
            this.cbo_from_hours.TabIndex = 130;
            // 
            // chk_time
            // 
            this.chk_time.AutoSize = true;
            this.chk_time.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_time.Location = new System.Drawing.Point(326, 140);
            this.chk_time.Name = "chk_time";
            this.chk_time.Size = new System.Drawing.Size(62, 24);
            this.chk_time.TabIndex = 125;
            this.chk_time.Text = "Time";
            this.chk_time.UseVisualStyleBackColor = true;
            this.chk_time.CheckedChanged += new System.EventHandler(this.chk_time_CheckedChanged);
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
            this.txt_searchText.Location = new System.Drawing.Point(101, 132);
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
            "ALL",
            "Category",
            "Category Group",
            "Item",
            "Bill No",
            "Payment Mode",
            "Service Provider",
            "Sales Type",
            "KOT Type",
            "User"});
            this.cbo_searchTYpe.Location = new System.Drawing.Point(100, 90);
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
            this.label1.Location = new System.Drawing.Point(58, 144);
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
            this.label2.Location = new System.Drawing.Point(23, 101);
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
            this.panel3.Size = new System.Drawing.Size(494, 73);
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
            this.label4.Location = new System.Drawing.Point(173, 25);
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
            this.btn_exit.Location = new System.Drawing.Point(212, 247);
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
            this.btn_show.Location = new System.Drawing.Point(101, 247);
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
            this.dtp_to.Location = new System.Drawing.Point(101, 211);
            this.dtp_to.Name = "dtp_to";
            this.dtp_to.Size = new System.Drawing.Size(218, 30);
            this.dtp_to.TabIndex = 117;
            this.dtp_to.Value = new System.DateTime(2016, 7, 18, 12, 44, 51, 0);
            // 
            // dtp_from
            // 
            this.dtp_from.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dtp_from.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_from.Location = new System.Drawing.Point(101, 175);
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
            this.label5.Location = new System.Drawing.Point(49, 220);
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
            this.label6.Location = new System.Drawing.Point(39, 189);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 115;
            this.label6.Text = "Date From:";
            // 
            // calbill_no
            // 
            this.calbill_no.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.calbill_no.HeaderText = "Bill No";
            this.calbill_no.Name = "calbill_no";
            this.calbill_no.ReadOnly = true;
            this.calbill_no.Width = 60;
            // 
            // col_fiscal_year
            // 
            this.col_fiscal_year.HeaderText = "Fiscal Year";
            this.col_fiscal_year.Name = "col_fiscal_year";
            this.col_fiscal_year.ReadOnly = true;
            this.col_fiscal_year.Visible = false;
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
            this.cal_discount.HeaderText = "Bill Discount";
            this.cal_discount.Name = "cal_discount";
            this.cal_discount.ReadOnly = true;
            this.cal_discount.Width = 60;
            // 
            // cal_service_charge
            // 
            this.cal_service_charge.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cal_service_charge.HeaderText = "Bill Service Charge";
            this.cal_service_charge.Name = "cal_service_charge";
            this.cal_service_charge.ReadOnly = true;
            this.cal_service_charge.Width = 72;
            // 
            // cal_tax
            // 
            this.cal_tax.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cal_tax.HeaderText = "Bill Tax";
            this.cal_tax.Name = "cal_tax";
            this.cal_tax.ReadOnly = true;
            this.cal_tax.Width = 73;
            // 
            // cal_grand_total
            // 
            this.cal_grand_total.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cal_grand_total.HeaderText = "Bill Grand total";
            this.cal_grand_total.Name = "cal_grand_total";
            this.cal_grand_total.ReadOnly = true;
            this.cal_grand_total.Width = 73;
            // 
            // calpaymode
            // 
            this.calpaymode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.calpaymode.HeaderText = "PayMode";
            this.calpaymode.Name = "calpaymode";
            this.calpaymode.ReadOnly = true;
            this.calpaymode.Width = 72;
            // 
            // calcardamount
            // 
            this.calcardamount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.calcardamount.HeaderText = "Card Amt.";
            this.calcardamount.Name = "calcardamount";
            this.calcardamount.ReadOnly = true;
            this.calcardamount.Width = 73;
            // 
            // calcashamt
            // 
            this.calcashamt.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.calcashamt.HeaderText = "Cash Amt.";
            this.calcashamt.Name = "calcashamt";
            this.calcashamt.ReadOnly = true;
            this.calcashamt.Width = 73;
            // 
            // cal_credit_amt
            // 
            this.cal_credit_amt.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cal_credit_amt.HeaderText = "Credit Amt";
            this.cal_credit_amt.Name = "cal_credit_amt";
            this.cal_credit_amt.ReadOnly = true;
            this.cal_credit_amt.Width = 60;
            // 
            // calcashier_name
            // 
            this.calcashier_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.calcashier_name.HeaderText = "Cashier";
            this.calcashier_name.Name = "calcashier_name";
            this.calcashier_name.ReadOnly = true;
            this.calcashier_name.Width = 60;
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
            // Viewrestaurant
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.backPanel);
            this.Controls.Add(this.searchPanel);
            this.Name = "Viewrestaurant";
            this.Size = new System.Drawing.Size(1011, 681);
            this.Load += new System.EventHandler(this.Viewrestaurant_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.backPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
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
        private System.Windows.Forms.Label lblsubtotal;
        private System.Windows.Forms.Label lbltaotal_quantity;
        private DataGridView dataGridView1;
        private Label lbl_service_charge;
        private DevComponents.DotNetBar.ButtonX btn_excel;
        private DevComponents.DotNetBar.ButtonX btn_export_to_pdf;
        private DevComponents.DotNetBar.ButtonX btn_export_XML;
        private DevComponents.DotNetBar.ButtonX btn_text_export;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private Label lbl_grand_total;
        private Label lbl_tax;
        private CheckBox chk_time;
        private ComboBox cbo_minuts_from;
        private ComboBox cbo_from_hours;
        private ComboBox cbo_minuts;
        private ComboBox cbo_to_hours;
        private DevComponents.DotNetBar.ButtonX btn_previous;
        private DevComponents.DotNetBar.ButtonX btn_next;
        private DataGridViewTextBoxColumn calbill_no;
        private DataGridViewTextBoxColumn col_fiscal_year;
        private DataGridViewTextBoxColumn calitem;
        private DataGridViewTextBoxColumn calquantity;
        private DataGridViewTextBoxColumn caltotal;
        private DataGridViewTextBoxColumn caldate;
        private DataGridViewTextBoxColumn cal_sub_total;
        private DataGridViewTextBoxColumn cal_discount;
        private DataGridViewTextBoxColumn cal_service_charge;
        private DataGridViewTextBoxColumn cal_tax;
        private DataGridViewTextBoxColumn cal_grand_total;
        private DataGridViewTextBoxColumn calpaymode;
        private DataGridViewTextBoxColumn calcardamount;
        private DataGridViewTextBoxColumn calcashamt;
        private DataGridViewTextBoxColumn cal_credit_amt;
        private DataGridViewTextBoxColumn calcashier_name;
        private DataGridViewTextBoxColumn cal_sales_type;
        private DataGridViewButtonColumn cal_print;
        private DataGridViewTextBoxColumn cal_date2;
        private DataGridViewTextBoxColumn cal_sales_id;
        private DataGridViewTextBoxColumn cal_table_no;
        private DataGridViewTextBoxColumn cal_cost;
        private DataGridViewTextBoxColumn cal_category_name;
        private DataGridViewTextBoxColumn cal_customer_name;
        private DataGridViewTextBoxColumn cal_customer_pan;
    }
}
