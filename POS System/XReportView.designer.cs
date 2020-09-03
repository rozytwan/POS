namespace POS_System
{
    partial class XReportView
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
            this.cbo_searchTYpe = new System.Windows.Forms.ComboBox();
            this.btn_show = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnbackpage = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.searchPanel = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.calbill_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_sales_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calitem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calquantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.caltotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.caldate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calpaymode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calcashamt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calcardamount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_grand_total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calcashier_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_sales_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.cal_table_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_category_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_date2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_discount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_sub_total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_back = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label23 = new System.Windows.Forms.Label();
            this.backPanel = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lbl_grand_total = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblsub_total = new System.Windows.Forms.Label();
            this.lbltaotal_quantity = new System.Windows.Forms.Label();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.btn_export_to_excel = new DevComponents.DotNetBar.ButtonX();
            this.btn_export_to_pdf = new DevComponents.DotNetBar.ButtonX();
            this.panel3.SuspendLayout();
            this.searchPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.backPanel.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbo_searchTYpe
            // 
            this.cbo_searchTYpe.FormattingEnabled = true;
            this.cbo_searchTYpe.Items.AddRange(new object[] {
            "Choose Type",
            "ALL",
            "Cash",
            "Card",
            "Zomato",
            "Credit"});
            this.cbo_searchTYpe.Location = new System.Drawing.Point(133, 87);
            this.cbo_searchTYpe.Name = "cbo_searchTYpe";
            this.cbo_searchTYpe.Size = new System.Drawing.Size(218, 21);
            this.cbo_searchTYpe.TabIndex = 123;
            // 
            // btn_show
            // 
            this.btn_show.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_show.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.btn_show.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_show.ForeColor = System.Drawing.Color.White;
            this.btn_show.Location = new System.Drawing.Point(133, 114);
            this.btn_show.Name = "btn_show";
            this.btn_show.Size = new System.Drawing.Size(107, 36);
            this.btn_show.TabIndex = 118;
            this.btn_show.Text = "Show";
            this.btn_show.UseVisualStyleBackColor = false;
            this.btn_show.Click += new System.EventHandler(this.btn_show_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(57, 91);
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
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(417, 73);
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
            this.label4.Location = new System.Drawing.Point(182, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 25);
            this.label4.TabIndex = 0;
            this.label4.Text = "X report ";
            // 
            // searchPanel
            // 
            this.searchPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchPanel.Controls.Add(this.cbo_searchTYpe);
            this.searchPanel.Controls.Add(this.label2);
            this.searchPanel.Controls.Add(this.panel3);
            this.searchPanel.Controls.Add(this.btn_show);
            this.searchPanel.Location = new System.Drawing.Point(318, 1);
            this.searchPanel.Name = "searchPanel";
            this.searchPanel.Size = new System.Drawing.Size(418, 182);
            this.searchPanel.TabIndex = 147;
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
            this.cal_sales_id,
            this.calitem,
            this.calquantity,
            this.caltotal,
            this.caldate,
            this.calpaymode,
            this.calcashamt,
            this.calcardamount,
            this.cal_grand_total,
            this.calcashier_name,
            this.cal_sales_type,
            this.cal_delete,
            this.cal_table_no,
            this.cal_category_name,
            this.cal_date2,
            this.cal_discount,
            this.cal_sub_total});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.Location = new System.Drawing.Point(1, 74);
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
            this.dataGridView1.Size = new System.Drawing.Size(1024, 559);
            this.dataGridView1.TabIndex = 139;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // calbill_no
            // 
            this.calbill_no.FillWeight = 7.158634F;
            this.calbill_no.HeaderText = "Bill No";
            this.calbill_no.Name = "calbill_no";
            this.calbill_no.ReadOnly = true;
            // 
            // cal_sales_id
            // 
            this.cal_sales_id.HeaderText = "Sale_id";
            this.cal_sales_id.Name = "cal_sales_id";
            this.cal_sales_id.ReadOnly = true;
            this.cal_sales_id.Visible = false;
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
            this.calquantity.FillWeight = 4F;
            this.calquantity.HeaderText = "QTY";
            this.calquantity.Name = "calquantity";
            this.calquantity.ReadOnly = true;
            // 
            // caltotal
            // 
            this.caltotal.FillWeight = 6.43112F;
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
            this.calpaymode.FillWeight = 6.43112F;
            this.calpaymode.HeaderText = "Payment Mode";
            this.calpaymode.Name = "calpaymode";
            this.calpaymode.ReadOnly = true;
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
            this.cal_grand_total.FillWeight = 9.625305F;
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
            this.cal_delete.HeaderText = "Delete";
            this.cal_delete.Name = "cal_delete";
            this.cal_delete.ReadOnly = true;
            this.cal_delete.Text = "Delete";
            this.cal_delete.UseColumnTextForButtonValue = true;
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
            // cal_date2
            // 
            this.cal_date2.HeaderText = "Date2";
            this.cal_date2.Name = "cal_date2";
            this.cal_date2.ReadOnly = true;
            this.cal_date2.Visible = false;
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
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(81)))), ((int)(((byte)(126)))));
            this.panel2.Controls.Add(this.btn_back);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.label23);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1025, 73);
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
            this.label23.Size = new System.Drawing.Size(348, 39);
            this.label23.TabIndex = 18;
            this.label23.Text = "View  X Sales Report ";
            // 
            // backPanel
            // 
            this.backPanel.BackColor = System.Drawing.Color.White;
            this.backPanel.Controls.Add(this.btn_export_to_pdf);
            this.backPanel.Controls.Add(this.btn_export_to_excel);
            this.backPanel.Controls.Add(this.panel4);
            this.backPanel.Controls.Add(this.panel2);
            this.backPanel.Controls.Add(this.dataGridView1);
            this.backPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.backPanel.Location = new System.Drawing.Point(0, 0);
            this.backPanel.Name = "backPanel";
            this.backPanel.Size = new System.Drawing.Size(1025, 720);
            this.backPanel.TabIndex = 146;
            this.backPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.backPanel_Paint);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel4.Controls.Add(this.buttonX1);
            this.panel4.Controls.Add(this.lbl_grand_total);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.lblsub_total);
            this.panel4.Controls.Add(this.lbltaotal_quantity);
            this.panel4.Location = new System.Drawing.Point(1, 635);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1024, 39);
            this.panel4.TabIndex = 137;
            // 
            // lbl_grand_total
            // 
            this.lbl_grand_total.AutoSize = true;
            this.lbl_grand_total.BackColor = System.Drawing.Color.Black;
            this.lbl_grand_total.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_grand_total.ForeColor = System.Drawing.Color.Lime;
            this.lbl_grand_total.Location = new System.Drawing.Point(664, 6);
            this.lbl_grand_total.Name = "lbl_grand_total";
            this.lbl_grand_total.Size = new System.Drawing.Size(24, 25);
            this.lbl_grand_total.TabIndex = 3;
            this.lbl_grand_total.Text = "0";
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
            // lblsub_total
            // 
            this.lblsub_total.AutoSize = true;
            this.lblsub_total.BackColor = System.Drawing.Color.Black;
            this.lblsub_total.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsub_total.ForeColor = System.Drawing.Color.Lime;
            this.lblsub_total.Location = new System.Drawing.Point(320, 9);
            this.lblsub_total.Name = "lblsub_total";
            this.lblsub_total.Size = new System.Drawing.Size(24, 25);
            this.lblsub_total.TabIndex = 1;
            this.lblsub_total.Text = "0";
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
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Location = new System.Drawing.Point(823, 45);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(178, 33);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 140;
            this.buttonX1.Text = "buttonX1";
            // 
            // btn_export_to_excel
            // 
            this.btn_export_to_excel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_export_to_excel.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btn_export_to_excel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_export_to_excel.Location = new System.Drawing.Point(828, 680);
            this.btn_export_to_excel.Name = "btn_export_to_excel";
            this.btn_export_to_excel.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(13);
            this.btn_export_to_excel.Size = new System.Drawing.Size(194, 37);
            this.btn_export_to_excel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_export_to_excel.Symbol = "";
            this.btn_export_to_excel.TabIndex = 140;
            this.btn_export_to_excel.Text = "Export to Excel";
            this.btn_export_to_excel.Click += new System.EventHandler(this.btn_export_to_excel_Click);
            // 
            // btn_export_to_pdf
            // 
            this.btn_export_to_pdf.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_export_to_pdf.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btn_export_to_pdf.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_export_to_pdf.Location = new System.Drawing.Point(3, 680);
            this.btn_export_to_pdf.Name = "btn_export_to_pdf";
            this.btn_export_to_pdf.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(13);
            this.btn_export_to_pdf.Size = new System.Drawing.Size(189, 37);
            this.btn_export_to_pdf.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_export_to_pdf.Symbol = "";
            this.btn_export_to_pdf.TabIndex = 141;
            this.btn_export_to_pdf.Text = "Export to PDF";
            this.btn_export_to_pdf.Click += new System.EventHandler(this.btn_export_to_pdf_Click);
            // 
            // XReportView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.backPanel);
            this.Controls.Add(this.searchPanel);
            this.Name = "XReportView";
            this.Size = new System.Drawing.Size(1025, 720);
            this.Load += new System.EventHandler(this.XReportView_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.searchPanel.ResumeLayout(false);
            this.searchPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.backPanel.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbo_searchTYpe;
        private System.Windows.Forms.Button btn_show;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnbackpage;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel searchPanel;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_back;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Panel backPanel;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblsub_total;
        private System.Windows.Forms.Label lbltaotal_quantity;
        private System.Windows.Forms.Label lbl_grand_total;
        private System.Windows.Forms.DataGridViewTextBoxColumn calbill_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_sales_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn calitem;
        private System.Windows.Forms.DataGridViewTextBoxColumn calquantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn caltotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn caldate;
        private System.Windows.Forms.DataGridViewTextBoxColumn calpaymode;
        private System.Windows.Forms.DataGridViewTextBoxColumn calcashamt;
        private System.Windows.Forms.DataGridViewTextBoxColumn calcardamount;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_grand_total;
        private System.Windows.Forms.DataGridViewTextBoxColumn calcashier_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_sales_type;
        private System.Windows.Forms.DataGridViewButtonColumn cal_delete;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_table_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_category_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_date2;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_discount;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_sub_total;
        private DevComponents.DotNetBar.ButtonX btn_export_to_excel;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.ButtonX btn_export_to_pdf;
    }
}