namespace POS_System.Customer_Management
{
    partial class ViewCardReport
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
            this.cbo_minuts = new System.Windows.Forms.ComboBox();
            this.cbo_to_hours = new System.Windows.Forms.ComboBox();
            this.cbo_minuts_from = new System.Windows.Forms.ComboBox();
            this.cbo_from_hours = new System.Windows.Forms.ComboBox();
            this.chk_time = new System.Windows.Forms.CheckBox();
            this.txt_searchText = new System.Windows.Forms.ComboBox();
            this.btn_show_all = new DevComponents.DotNetBar.ButtonX();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnbackpage = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cbo_searchTYpe = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtp_to = new System.Windows.Forms.DateTimePicker();
            this.dtp_from = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.backpanel = new System.Windows.Forms.Panel();
            this.btn_export_to_pdf = new DevComponents.DotNetBar.ButtonX();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lbl_atm = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_credit = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lbl_cash = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lbl_cash_back = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbl_add_balance = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.col_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_customer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_card_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_add_balance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_recharge_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_user = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label24 = new System.Windows.Forms.Label();
            this.searchPanel.SuspendLayout();
            this.panel3.SuspendLayout();
            this.backpanel.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
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
            this.searchPanel.Controls.Add(this.btn_show_all);
            this.searchPanel.Controls.Add(this.panel3);
            this.searchPanel.Controls.Add(this.cbo_searchTYpe);
            this.searchPanel.Controls.Add(this.label1);
            this.searchPanel.Controls.Add(this.dtp_to);
            this.searchPanel.Controls.Add(this.dtp_from);
            this.searchPanel.Controls.Add(this.label2);
            this.searchPanel.Controls.Add(this.label5);
            this.searchPanel.Controls.Add(this.label6);
            this.searchPanel.Location = new System.Drawing.Point(287, 1);
            this.searchPanel.Name = "searchPanel";
            this.searchPanel.Size = new System.Drawing.Size(443, 281);
            this.searchPanel.TabIndex = 149;
            // 
            // cbo_minuts
            // 
            this.cbo_minuts.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.cbo_minuts.Location = new System.Drawing.Point(381, 189);
            this.cbo_minuts.Name = "cbo_minuts";
            this.cbo_minuts.Size = new System.Drawing.Size(43, 26);
            this.cbo_minuts.TabIndex = 318;
            // 
            // cbo_to_hours
            // 
            this.cbo_to_hours.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.cbo_to_hours.Location = new System.Drawing.Point(334, 189);
            this.cbo_to_hours.Name = "cbo_to_hours";
            this.cbo_to_hours.Size = new System.Drawing.Size(42, 26);
            this.cbo_to_hours.TabIndex = 317;
            // 
            // cbo_minuts_from
            // 
            this.cbo_minuts_from.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.cbo_minuts_from.Location = new System.Drawing.Point(381, 147);
            this.cbo_minuts_from.Name = "cbo_minuts_from";
            this.cbo_minuts_from.Size = new System.Drawing.Size(43, 26);
            this.cbo_minuts_from.TabIndex = 316;
            // 
            // cbo_from_hours
            // 
            this.cbo_from_hours.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.cbo_from_hours.Location = new System.Drawing.Point(332, 147);
            this.cbo_from_hours.Name = "cbo_from_hours";
            this.cbo_from_hours.Size = new System.Drawing.Size(42, 26);
            this.cbo_from_hours.TabIndex = 315;
            // 
            // chk_time
            // 
            this.chk_time.AutoSize = true;
            this.chk_time.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_time.Location = new System.Drawing.Point(332, 112);
            this.chk_time.Name = "chk_time";
            this.chk_time.Size = new System.Drawing.Size(62, 24);
            this.chk_time.TabIndex = 314;
            this.chk_time.Text = "Time";
            this.chk_time.UseVisualStyleBackColor = true;
            this.chk_time.CheckedChanged += new System.EventHandler(this.chk_time_CheckedChanged);
            // 
            // txt_searchText
            // 
            this.txt_searchText.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txt_searchText.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.txt_searchText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_searchText.FormattingEnabled = true;
            this.txt_searchText.Items.AddRange(new object[] {
            "Choose Type",
            "Product",
            "Category"});
            this.txt_searchText.Location = new System.Drawing.Point(96, 121);
            this.txt_searchText.Name = "txt_searchText";
            this.txt_searchText.Size = new System.Drawing.Size(230, 32);
            this.txt_searchText.TabIndex = 313;
            // 
            // btn_show_all
            // 
            this.btn_show_all.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_show_all.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btn_show_all.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_show_all.Location = new System.Drawing.Point(174, 225);
            this.btn_show_all.Name = "btn_show_all";
            this.btn_show_all.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(15);
            this.btn_show_all.Size = new System.Drawing.Size(122, 44);
            this.btn_show_all.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_show_all.TabIndex = 309;
            this.btn_show_all.Text = "Show All";
            this.btn_show_all.Click += new System.EventHandler(this.btn_show_all_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(81)))), ((int)(((byte)(126)))));
            this.panel3.Controls.Add(this.btnbackpage);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(441, 73);
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
            this.label4.Location = new System.Drawing.Point(146, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(208, 25);
            this.label4.TabIndex = 0;
            this.label4.Text = "Choose Between Date";
            // 
            // cbo_searchTYpe
            // 
            this.cbo_searchTYpe.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_searchTYpe.FormattingEnabled = true;
            this.cbo_searchTYpe.Items.AddRange(new object[] {
            "Choose Type",
            "Balance Topup",
            "Cash Back",
            "User",
            "All"});
            this.cbo_searchTYpe.Location = new System.Drawing.Point(96, 86);
            this.cbo_searchTYpe.Name = "cbo_searchTYpe";
            this.cbo_searchTYpe.Size = new System.Drawing.Size(230, 32);
            this.cbo_searchTYpe.TabIndex = 312;
            this.cbo_searchTYpe.SelectedIndexChanged += new System.EventHandler(this.cbo_searchTYpe_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(41, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 310;
            this.label1.Text = "Find:";
            // 
            // dtp_to
            // 
            this.dtp_to.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dtp_to.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_to.Location = new System.Drawing.Point(96, 195);
            this.dtp_to.Name = "dtp_to";
            this.dtp_to.Size = new System.Drawing.Size(230, 24);
            this.dtp_to.TabIndex = 117;
            this.dtp_to.Value = new System.DateTime(2017, 11, 22, 0, 0, 0, 0);
            // 
            // dtp_from
            // 
            this.dtp_from.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dtp_from.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_from.Location = new System.Drawing.Point(96, 159);
            this.dtp_from.Name = "dtp_from";
            this.dtp_from.Size = new System.Drawing.Size(230, 24);
            this.dtp_from.TabIndex = 116;
            this.dtp_from.Value = new System.DateTime(2017, 11, 22, 0, 0, 0, 0);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(0, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 311;
            this.label2.Text = "Search Type:";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(20, 199);
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
            this.label6.Location = new System.Drawing.Point(2, 164);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 18);
            this.label6.TabIndex = 115;
            this.label6.Text = "Date From:";
            // 
            // backpanel
            // 
            this.backpanel.BackColor = System.Drawing.Color.White;
            this.backpanel.Controls.Add(this.btn_export_to_pdf);
            this.backpanel.Controls.Add(this.panel4);
            this.backpanel.Controls.Add(this.dataGridView1);
            this.backpanel.Controls.Add(this.panel2);
            this.backpanel.Location = new System.Drawing.Point(1, 1);
            this.backpanel.Name = "backpanel";
            this.backpanel.Size = new System.Drawing.Size(1029, 716);
            this.backpanel.TabIndex = 150;
            this.backpanel.Paint += new System.Windows.Forms.PaintEventHandler(this.backpanel_Paint);
            // 
            // btn_export_to_pdf
            // 
            this.btn_export_to_pdf.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_export_to_pdf.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btn_export_to_pdf.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_export_to_pdf.Location = new System.Drawing.Point(821, 661);
            this.btn_export_to_pdf.Name = "btn_export_to_pdf";
            this.btn_export_to_pdf.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(15);
            this.btn_export_to_pdf.Size = new System.Drawing.Size(186, 52);
            this.btn_export_to_pdf.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_export_to_pdf.TabIndex = 317;
            this.btn_export_to_pdf.Text = "Export to PDF";
            this.btn_export_to_pdf.Click += new System.EventHandler(this.btn_export_to_pdf_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel4.Controls.Add(this.lbl_atm);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.lbl_credit);
            this.panel4.Controls.Add(this.label12);
            this.panel4.Controls.Add(this.lbl_cash);
            this.panel4.Controls.Add(this.label10);
            this.panel4.Controls.Add(this.lbl_cash_back);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.lbl_add_balance);
            this.panel4.Controls.Add(this.label9);
            this.panel4.Location = new System.Drawing.Point(3, 601);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1024, 54);
            this.panel4.TabIndex = 315;
            // 
            // lbl_atm
            // 
            this.lbl_atm.AutoSize = true;
            this.lbl_atm.BackColor = System.Drawing.Color.Black;
            this.lbl_atm.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_atm.ForeColor = System.Drawing.Color.Lime;
            this.lbl_atm.Location = new System.Drawing.Point(323, 28);
            this.lbl_atm.Name = "lbl_atm";
            this.lbl_atm.Size = new System.Drawing.Size(24, 25);
            this.lbl_atm.TabIndex = 15;
            this.lbl_atm.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Black;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Lime;
            this.label3.Location = new System.Drawing.Point(490, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 20);
            this.label3.TabIndex = 14;
            this.label3.Text = "Total Topup :";
            // 
            // lbl_credit
            // 
            this.lbl_credit.AutoSize = true;
            this.lbl_credit.BackColor = System.Drawing.Color.Black;
            this.lbl_credit.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_credit.ForeColor = System.Drawing.Color.Lime;
            this.lbl_credit.Location = new System.Drawing.Point(175, 28);
            this.lbl_credit.Name = "lbl_credit";
            this.lbl_credit.Size = new System.Drawing.Size(24, 25);
            this.lbl_credit.TabIndex = 13;
            this.lbl_credit.Text = "0";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Black;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Lime;
            this.label12.Location = new System.Drawing.Point(164, 3);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(67, 20);
            this.label12.TabIndex = 12;
            this.label12.Text = "Credit :";
            // 
            // lbl_cash
            // 
            this.lbl_cash.AutoSize = true;
            this.lbl_cash.BackColor = System.Drawing.Color.Black;
            this.lbl_cash.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_cash.ForeColor = System.Drawing.Color.Lime;
            this.lbl_cash.Location = new System.Drawing.Point(8, 28);
            this.lbl_cash.Name = "lbl_cash";
            this.lbl_cash.Size = new System.Drawing.Size(24, 25);
            this.lbl_cash.TabIndex = 11;
            this.lbl_cash.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Black;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Lime;
            this.label10.Location = new System.Drawing.Point(8, 3);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 20);
            this.label10.TabIndex = 10;
            this.label10.Text = "Cash :";
            // 
            // lbl_cash_back
            // 
            this.lbl_cash_back.AutoSize = true;
            this.lbl_cash_back.BackColor = System.Drawing.Color.Black;
            this.lbl_cash_back.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_cash_back.ForeColor = System.Drawing.Color.Lime;
            this.lbl_cash_back.Location = new System.Drawing.Point(684, 28);
            this.lbl_cash_back.Name = "lbl_cash_back";
            this.lbl_cash_back.Size = new System.Drawing.Size(24, 25);
            this.lbl_cash_back.TabIndex = 9;
            this.lbl_cash_back.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Black;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Lime;
            this.label7.Location = new System.Drawing.Point(675, 3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 20);
            this.label7.TabIndex = 8;
            this.label7.Text = "Cash Back :";
            // 
            // lbl_add_balance
            // 
            this.lbl_add_balance.AutoSize = true;
            this.lbl_add_balance.BackColor = System.Drawing.Color.Black;
            this.lbl_add_balance.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_add_balance.ForeColor = System.Drawing.Color.Lime;
            this.lbl_add_balance.Location = new System.Drawing.Point(501, 28);
            this.lbl_add_balance.Name = "lbl_add_balance";
            this.lbl_add_balance.Size = new System.Drawing.Size(24, 25);
            this.lbl_add_balance.TabIndex = 7;
            this.lbl_add_balance.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Black;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Lime;
            this.label9.Location = new System.Drawing.Point(318, 3);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(91, 20);
            this.label9.TabIndex = 6;
            this.label9.Text = "Atm card :";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_id,
            this.col_customer,
            this.col_card_no,
            this.col_add_balance,
            this.col_status,
            this.col_recharge_type,
            this.col_user,
            this.col_date});
            this.dataGridView1.Location = new System.Drawing.Point(3, 62);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(1021, 533);
            this.dataGridView1.TabIndex = 312;
            // 
            // col_id
            // 
            this.col_id.HeaderText = "customer_id";
            this.col_id.Name = "col_id";
            this.col_id.ReadOnly = true;
            this.col_id.Visible = false;
            // 
            // col_customer
            // 
            this.col_customer.HeaderText = "Customer Name";
            this.col_customer.Name = "col_customer";
            this.col_customer.ReadOnly = true;
            this.col_customer.Width = 170;
            // 
            // col_card_no
            // 
            this.col_card_no.HeaderText = "Card No.";
            this.col_card_no.Name = "col_card_no";
            this.col_card_no.ReadOnly = true;
            this.col_card_no.Width = 150;
            // 
            // col_add_balance
            // 
            this.col_add_balance.HeaderText = "Amount";
            this.col_add_balance.Name = "col_add_balance";
            this.col_add_balance.ReadOnly = true;
            this.col_add_balance.Width = 150;
            // 
            // col_status
            // 
            this.col_status.HeaderText = "Status";
            this.col_status.Name = "col_status";
            this.col_status.ReadOnly = true;
            // 
            // col_recharge_type
            // 
            this.col_recharge_type.HeaderText = "Payment Mode";
            this.col_recharge_type.Name = "col_recharge_type";
            this.col_recharge_type.ReadOnly = true;
            this.col_recharge_type.Width = 150;
            // 
            // col_user
            // 
            this.col_user.HeaderText = "User";
            this.col_user.Name = "col_user";
            this.col_user.ReadOnly = true;
            this.col_user.Width = 150;
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
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(81)))), ((int)(((byte)(126)))));
            this.panel2.Controls.Add(this.pictureBox5);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.label24);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1029, 61);
            this.panel2.TabIndex = 311;
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
            // ViewCardReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1033, 718);
            this.Controls.Add(this.backpanel);
            this.Controls.Add(this.searchPanel);
            this.Name = "ViewCardReport";
            this.Text = "ViewCardReport";
            this.Load += new System.EventHandler(this.ViewCardReport_Load);
            this.searchPanel.ResumeLayout(false);
            this.searchPanel.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.backpanel.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
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
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnbackpage;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtp_to;
        private System.Windows.Forms.DateTimePicker dtp_from;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel backpanel;
        private DevComponents.DotNetBar.ButtonX btn_export_to_pdf;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lbl_add_balance;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.ComboBox txt_searchText;
        private System.Windows.Forms.ComboBox cbo_searchTYpe;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_customer;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_card_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_add_balance;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_status;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_recharge_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_user;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_date;
        private System.Windows.Forms.ComboBox cbo_minuts;
        private System.Windows.Forms.ComboBox cbo_to_hours;
        private System.Windows.Forms.ComboBox cbo_minuts_from;
        private System.Windows.Forms.ComboBox cbo_from_hours;
        private System.Windows.Forms.CheckBox chk_time;
        private System.Windows.Forms.Label lbl_cash_back;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbl_credit;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lbl_cash;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lbl_atm;
        private System.Windows.Forms.Label label3;
    }
}