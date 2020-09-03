namespace POS_System
{
    partial class CheckCard
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
            this.btn_show_all = new DevComponents.DotNetBar.ButtonX();
            this.txt_card = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.dtp_to = new System.Windows.Forms.DateTimePicker();
            this.dtp_from = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.backpanel = new System.Windows.Forms.Panel();
            this.lbl_to = new System.Windows.Forms.Label();
            this.lbl_from = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btn_sales = new DevComponents.DotNetBar.ButtonX();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_customer_no = new System.Windows.Forms.Label();
            this.lbl_customer_name = new System.Windows.Forms.Label();
            this.btn_export_to_pdf = new DevComponents.DotNetBar.ButtonX();
            this.btn_print = new DevComponents.DotNetBar.ButtonX();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lbl_add_balance = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lbl_cash_back = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbl_grand_total = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.col_date3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_cash_back = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.col_date2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_add_amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label24 = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnbackpage = new System.Windows.Forms.Button();
            this.col_bill_no = new System.Windows.Forms.DataGridViewButtonColumn();
            this.col_grand_total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.searchPanel.SuspendLayout();
            this.panel3.SuspendLayout();
            this.backpanel.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // searchPanel
            // 
            this.searchPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchPanel.Controls.Add(this.btn_show_all);
            this.searchPanel.Controls.Add(this.txt_card);
            this.searchPanel.Controls.Add(this.label1);
            this.searchPanel.Controls.Add(this.panel3);
            this.searchPanel.Controls.Add(this.dtp_to);
            this.searchPanel.Controls.Add(this.dtp_from);
            this.searchPanel.Controls.Add(this.label5);
            this.searchPanel.Controls.Add(this.label6);
            this.searchPanel.Location = new System.Drawing.Point(301, 3);
            this.searchPanel.Name = "searchPanel";
            this.searchPanel.Size = new System.Drawing.Size(388, 270);
            this.searchPanel.TabIndex = 148;
            // 
            // btn_show_all
            // 
            this.btn_show_all.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_show_all.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btn_show_all.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_show_all.Location = new System.Drawing.Point(240, 211);
            this.btn_show_all.Name = "btn_show_all";
            this.btn_show_all.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(15);
            this.btn_show_all.Size = new System.Drawing.Size(122, 44);
            this.btn_show_all.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_show_all.TabIndex = 309;
            this.btn_show_all.Text = "Show All";
            this.btn_show_all.Click += new System.EventHandler(this.btn_show_all_Click);
            // 
            // txt_card
            // 
            this.txt_card.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_card.Location = new System.Drawing.Point(98, 82);
            this.txt_card.Name = "txt_card";
            this.txt_card.Size = new System.Drawing.Size(264, 35);
            this.txt_card.TabIndex = 121;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(13, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 122;
            this.label1.Text = "Card No. :";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(81)))), ((int)(((byte)(126)))));
            this.panel3.Controls.Add(this.btnbackpage);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(386, 73);
            this.panel3.TabIndex = 120;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(119, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(208, 25);
            this.label4.TabIndex = 0;
            this.label4.Text = "Choose Between Date";
            // 
            // dtp_to
            // 
            this.dtp_to.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dtp_to.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_to.Location = new System.Drawing.Point(98, 159);
            this.dtp_to.Name = "dtp_to";
            this.dtp_to.Size = new System.Drawing.Size(264, 24);
            this.dtp_to.TabIndex = 117;
            this.dtp_to.Value = new System.DateTime(2017, 11, 22, 0, 0, 0, 0);
            // 
            // dtp_from
            // 
            this.dtp_from.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dtp_from.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_from.Location = new System.Drawing.Point(98, 123);
            this.dtp_from.Name = "dtp_from";
            this.dtp_from.Size = new System.Drawing.Size(264, 24);
            this.dtp_from.TabIndex = 116;
            this.dtp_from.Value = new System.DateTime(2017, 11, 22, 0, 0, 0, 0);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(27, 164);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 18);
            this.label5.TabIndex = 114;
            this.label5.Text = "Date To:";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(9, 129);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 18);
            this.label6.TabIndex = 115;
            this.label6.Text = "Date From:";
            // 
            // backpanel
            // 
            this.backpanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.backpanel.Controls.Add(this.lbl_to);
            this.backpanel.Controls.Add(this.lbl_from);
            this.backpanel.Controls.Add(this.label10);
            this.backpanel.Controls.Add(this.label8);
            this.backpanel.Controls.Add(this.btn_sales);
            this.backpanel.Controls.Add(this.label2);
            this.backpanel.Controls.Add(this.lbl_customer_no);
            this.backpanel.Controls.Add(this.lbl_customer_name);
            this.backpanel.Controls.Add(this.btn_export_to_pdf);
            this.backpanel.Controls.Add(this.btn_print);
            this.backpanel.Controls.Add(this.panel4);
            this.backpanel.Controls.Add(this.dataGridView3);
            this.backpanel.Controls.Add(this.dataGridView2);
            this.backpanel.Controls.Add(this.dataGridView1);
            this.backpanel.Controls.Add(this.panel2);
            this.backpanel.Location = new System.Drawing.Point(0, 2);
            this.backpanel.Name = "backpanel";
            this.backpanel.Size = new System.Drawing.Size(1038, 737);
            this.backpanel.TabIndex = 149;
            // 
            // lbl_to
            // 
            this.lbl_to.AutoSize = true;
            this.lbl_to.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_to.ForeColor = System.Drawing.Color.White;
            this.lbl_to.Location = new System.Drawing.Point(800, 72);
            this.lbl_to.Name = "lbl_to";
            this.lbl_to.Size = new System.Drawing.Size(74, 16);
            this.lbl_to.TabIndex = 325;
            this.lbl_to.Text = "                      ";
            // 
            // lbl_from
            // 
            this.lbl_from.AutoSize = true;
            this.lbl_from.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_from.ForeColor = System.Drawing.Color.White;
            this.lbl_from.Location = new System.Drawing.Point(546, 71);
            this.lbl_from.Name = "lbl_from";
            this.lbl_from.Size = new System.Drawing.Size(74, 16);
            this.lbl_from.TabIndex = 324;
            this.lbl_from.Text = "                      ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(735, 72);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 16);
            this.label10.TabIndex = 323;
            this.label10.Text = "To Date :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(463, 72);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 16);
            this.label8.TabIndex = 322;
            this.label8.Text = "From Date :";
            // 
            // btn_sales
            // 
            this.btn_sales.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_sales.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btn_sales.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_sales.Location = new System.Drawing.Point(267, 662);
            this.btn_sales.Name = "btn_sales";
            this.btn_sales.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(15);
            this.btn_sales.Size = new System.Drawing.Size(144, 44);
            this.btn_sales.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_sales.TabIndex = 321;
            this.btn_sales.Text = "Sales Detail";
            this.btn_sales.Click += new System.EventHandler(this.btn_sales_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(3, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 16);
            this.label2.TabIndex = 320;
            this.label2.Text = "Name :      ";
            // 
            // lbl_customer_no
            // 
            this.lbl_customer_no.AutoSize = true;
            this.lbl_customer_no.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_customer_no.ForeColor = System.Drawing.Color.White;
            this.lbl_customer_no.Location = new System.Drawing.Point(276, 72);
            this.lbl_customer_no.Name = "lbl_customer_no";
            this.lbl_customer_no.Size = new System.Drawing.Size(52, 15);
            this.lbl_customer_no.TabIndex = 319;
            this.lbl_customer_no.Text = "               ";
            // 
            // lbl_customer_name
            // 
            this.lbl_customer_name.AutoSize = true;
            this.lbl_customer_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_customer_name.ForeColor = System.Drawing.Color.White;
            this.lbl_customer_name.Location = new System.Drawing.Point(60, 71);
            this.lbl_customer_name.Name = "lbl_customer_name";
            this.lbl_customer_name.Size = new System.Drawing.Size(74, 16);
            this.lbl_customer_name.TabIndex = 318;
            this.lbl_customer_name.Text = "                      ";
            // 
            // btn_export_to_pdf
            // 
            this.btn_export_to_pdf.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_export_to_pdf.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btn_export_to_pdf.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_export_to_pdf.Location = new System.Drawing.Point(688, 662);
            this.btn_export_to_pdf.Name = "btn_export_to_pdf";
            this.btn_export_to_pdf.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(15);
            this.btn_export_to_pdf.Size = new System.Drawing.Size(186, 44);
            this.btn_export_to_pdf.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_export_to_pdf.TabIndex = 317;
            this.btn_export_to_pdf.Text = "Export to PDF";
            this.btn_export_to_pdf.Click += new System.EventHandler(this.btn_export_to_pdf_Click);
            // 
            // btn_print
            // 
            this.btn_print.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_print.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btn_print.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_print.Location = new System.Drawing.Point(880, 662);
            this.btn_print.Name = "btn_print";
            this.btn_print.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(15);
            this.btn_print.Size = new System.Drawing.Size(144, 44);
            this.btn_print.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_print.TabIndex = 316;
            this.btn_print.Text = " Print";
            this.btn_print.Click += new System.EventHandler(this.btn_print_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel4.Controls.Add(this.lbl_add_balance);
            this.panel4.Controls.Add(this.label9);
            this.panel4.Controls.Add(this.lbl_cash_back);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.lbl_grand_total);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Location = new System.Drawing.Point(3, 616);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1024, 40);
            this.panel4.TabIndex = 315;
            // 
            // lbl_add_balance
            // 
            this.lbl_add_balance.AutoSize = true;
            this.lbl_add_balance.BackColor = System.Drawing.Color.Black;
            this.lbl_add_balance.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_add_balance.ForeColor = System.Drawing.Color.Lime;
            this.lbl_add_balance.Location = new System.Drawing.Point(583, 6);
            this.lbl_add_balance.Name = "lbl_add_balance";
            this.lbl_add_balance.Size = new System.Drawing.Size(24, 25);
            this.lbl_add_balance.TabIndex = 7;
            this.lbl_add_balance.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Black;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Lime;
            this.label9.Location = new System.Drawing.Point(429, 6);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(148, 25);
            this.label9.TabIndex = 6;
            this.label9.Text = "Add Balance :";
            // 
            // lbl_cash_back
            // 
            this.lbl_cash_back.AutoSize = true;
            this.lbl_cash_back.BackColor = System.Drawing.Color.Black;
            this.lbl_cash_back.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_cash_back.ForeColor = System.Drawing.Color.Lime;
            this.lbl_cash_back.Location = new System.Drawing.Point(871, 6);
            this.lbl_cash_back.Name = "lbl_cash_back";
            this.lbl_cash_back.Size = new System.Drawing.Size(24, 25);
            this.lbl_cash_back.TabIndex = 5;
            this.lbl_cash_back.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Black;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Lime;
            this.label7.Location = new System.Drawing.Point(745, 6);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(130, 25);
            this.label7.TabIndex = 4;
            this.label7.Text = "Cash Back :";
            // 
            // lbl_grand_total
            // 
            this.lbl_grand_total.AutoSize = true;
            this.lbl_grand_total.BackColor = System.Drawing.Color.Black;
            this.lbl_grand_total.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_grand_total.ForeColor = System.Drawing.Color.Lime;
            this.lbl_grand_total.Location = new System.Drawing.Point(161, 6);
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
            this.label3.Location = new System.Drawing.Point(16, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Grand Total :";
            // 
            // dataGridView3
            // 
            this.dataGridView3.AllowUserToAddRows = false;
            this.dataGridView3.AllowUserToDeleteRows = false;
            this.dataGridView3.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_date3,
            this.col_cash_back});
            this.dataGridView3.GridColor = System.Drawing.Color.White;
            this.dataGridView3.Location = new System.Drawing.Point(738, 98);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.ReadOnly = true;
            this.dataGridView3.RowHeadersVisible = false;
            this.dataGridView3.Size = new System.Drawing.Size(286, 512);
            this.dataGridView3.TabIndex = 314;
            // 
            // col_date3
            // 
            this.col_date3.HeaderText = "Date";
            this.col_date3.Name = "col_date3";
            this.col_date3.ReadOnly = true;
            this.col_date3.Width = 130;
            // 
            // col_cash_back
            // 
            this.col_cash_back.HeaderText = "Cash Back";
            this.col_cash_back.Name = "col_cash_back";
            this.col_cash_back.ReadOnly = true;
            this.col_cash_back.Width = 150;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_date2,
            this.col_add_amount});
            this.dataGridView2.Location = new System.Drawing.Point(434, 96);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.Size = new System.Drawing.Size(298, 512);
            this.dataGridView2.TabIndex = 313;
            // 
            // col_date2
            // 
            this.col_date2.HeaderText = "Date";
            this.col_date2.Name = "col_date2";
            this.col_date2.ReadOnly = true;
            this.col_date2.Width = 130;
            // 
            // col_add_amount
            // 
            this.col_add_amount.HeaderText = "Add Amount";
            this.col_add_amount.Name = "col_add_amount";
            this.col_add_amount.ReadOnly = true;
            this.col_add_amount.Width = 160;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_bill_no,
            this.col_grand_total,
            this.col_date});
            this.dataGridView1.Location = new System.Drawing.Point(1, 98);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(428, 512);
            this.dataGridView1.TabIndex = 312;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(81)))), ((int)(((byte)(126)))));
            this.panel2.Controls.Add(this.pictureBox5);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.label24);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1038, 61);
            this.panel2.TabIndex = 311;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label24.ForeColor = System.Drawing.Color.White;
            this.label24.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label24.Location = new System.Drawing.Point(447, 17);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(188, 31);
            this.label24.TabIndex = 6;
            this.label24.Text = "Club Card Log";
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::POS_System.Properties.Resources.back36;
            this.pictureBox5.Location = new System.Drawing.Point(3, 0);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(64, 59);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 26;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.Click += new System.EventHandler(this.pictureBox5_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::POS_System.Properties.Resources.business__2_;
            this.pictureBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox1.Location = new System.Drawing.Point(380, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(52, 53);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
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
            // col_bill_no
            // 
            this.col_bill_no.HeaderText = "Bill No";
            this.col_bill_no.Name = "col_bill_no";
            this.col_bill_no.ReadOnly = true;
            this.col_bill_no.Width = 120;
            // 
            // col_grand_total
            // 
            this.col_grand_total.HeaderText = "Grand Total";
            this.col_grand_total.Name = "col_grand_total";
            this.col_grand_total.ReadOnly = true;
            this.col_grand_total.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_grand_total.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col_grand_total.Width = 150;
            // 
            // col_date
            // 
            this.col_date.HeaderText = "Date";
            this.col_date.Name = "col_date";
            this.col_date.ReadOnly = true;
            this.col_date.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_date.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col_date.Width = 150;
            // 
            // CheckCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.backpanel);
            this.Controls.Add(this.searchPanel);
            this.Name = "CheckCard";
            this.Size = new System.Drawing.Size(1038, 737);
            this.Load += new System.EventHandler(this.CheckCard_Load);
            this.searchPanel.ResumeLayout(false);
            this.searchPanel.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.backpanel.ResumeLayout(false);
            this.backpanel.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel searchPanel;
        private DevComponents.DotNetBar.ButtonX btn_show_all;
        private System.Windows.Forms.TextBox txt_card;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnbackpage;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtp_to;
        private System.Windows.Forms.DateTimePicker dtp_from;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel backpanel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lbl_add_balance;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lbl_cash_back;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbl_grand_total;
        private System.Windows.Forms.Label label3;
        private DevComponents.DotNetBar.ButtonX btn_print;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_date3;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_cash_back;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_date2;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_add_amount;
        private DevComponents.DotNetBar.ButtonX btn_export_to_pdf;
        private System.Windows.Forms.Label lbl_customer_no;
        private System.Windows.Forms.Label lbl_customer_name;
        private System.Windows.Forms.Label label2;
        private DevComponents.DotNetBar.ButtonX btn_sales;
        private System.Windows.Forms.Label lbl_to;
        private System.Windows.Forms.Label lbl_from;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridViewButtonColumn col_bill_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_grand_total;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_date;
    }
}