namespace POS_System.Customer_Management
{
    partial class CustomerList
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.txt_location = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_back = new System.Windows.Forms.Button();
            this.label23 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.col_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_last_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_card_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_card_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_balance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_add = new System.Windows.Forms.DataGridViewButtonColumn();
            this.col_cash_back = new System.Windows.Forms.DataGridViewButtonColumn();
            this.col_replace = new System.Windows.Forms.DataGridViewButtonColumn();
            this.txt_searchbox = new System.Windows.Forms.TextBox();
            this.lbl_search = new System.Windows.Forms.Label();
            this.lbl_balance = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_export_to_pdf = new DevComponents.DotNetBar.ButtonX();
            this.btn_excel = new DevComponents.DotNetBar.ButtonX();
            this.txt_search_by = new System.Windows.Forms.TextBox();
            this.cmb_search = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_previous = new DevComponents.DotNetBar.ButtonX();
            this.btn_next = new DevComponents.DotNetBar.ButtonX();
            this.panel_replace = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_change = new DevComponents.DotNetBar.ButtonX();
            this.label12 = new System.Windows.Forms.Label();
            this.lbl_blc = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbl_cardno = new System.Windows.Forms.Label();
            this.txt_newcard = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_topup = new DevComponents.DotNetBar.ButtonX();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel_replace.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(81)))), ((int)(((byte)(126)))));
            this.panel2.Controls.Add(this.txt_location);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.btn_back);
            this.panel2.Controls.Add(this.label23);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(995, 73);
            this.panel2.TabIndex = 115;
            // 
            // txt_location
            // 
            this.txt_location.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(81)))), ((int)(((byte)(126)))));
            this.txt_location.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_location.Location = new System.Drawing.Point(920, 39);
            this.txt_location.Name = "txt_location";
            this.txt_location.Size = new System.Drawing.Size(72, 29);
            this.txt_location.TabIndex = 150;
            this.txt_location.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::POS_System.Properties.Resources.arrows__5_;
            this.pictureBox1.Location = new System.Drawing.Point(311, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(67, 68);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
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
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.White;
            this.label23.Location = new System.Drawing.Point(395, 17);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(278, 39);
            this.label23.TabIndex = 18;
            this.label23.Text = "Customer Details";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_name,
            this.col_last_name,
            this.col_phone,
            this.col_card_no,
            this.col_card_type,
            this.col_balance,
            this.col_id,
            this.col_add,
            this.col_cash_back,
            this.col_replace});
            this.dataGridView1.Location = new System.Drawing.Point(3, 112);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(989, 529);
            this.dataGridView1.TabIndex = 116;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // col_name
            // 
            this.col_name.HeaderText = "Name";
            this.col_name.Name = "col_name";
            this.col_name.ReadOnly = true;
            this.col_name.Width = 120;
            // 
            // col_last_name
            // 
            this.col_last_name.HeaderText = "Last Name";
            this.col_last_name.Name = "col_last_name";
            this.col_last_name.ReadOnly = true;
            this.col_last_name.Width = 145;
            // 
            // col_phone
            // 
            this.col_phone.HeaderText = "Phone";
            this.col_phone.Name = "col_phone";
            this.col_phone.ReadOnly = true;
            // 
            // col_card_no
            // 
            this.col_card_no.HeaderText = "Card no.";
            this.col_card_no.Name = "col_card_no";
            this.col_card_no.ReadOnly = true;
            this.col_card_no.Width = 140;
            // 
            // col_card_type
            // 
            this.col_card_type.HeaderText = "Card Type";
            this.col_card_type.Name = "col_card_type";
            this.col_card_type.ReadOnly = true;
            this.col_card_type.Width = 80;
            // 
            // col_balance
            // 
            this.col_balance.HeaderText = "Card Balance";
            this.col_balance.Name = "col_balance";
            this.col_balance.ReadOnly = true;
            // 
            // col_id
            // 
            this.col_id.HeaderText = "Id";
            this.col_id.Name = "col_id";
            this.col_id.ReadOnly = true;
            this.col_id.Visible = false;
            // 
            // col_add
            // 
            this.col_add.HeaderText = "Add Balance";
            this.col_add.Name = "col_add";
            this.col_add.ReadOnly = true;
            this.col_add.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_add.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.col_add.Text = "Add Balance";
            this.col_add.ToolTipText = "Add Balance";
            this.col_add.UseColumnTextForButtonValue = true;
            this.col_add.Width = 85;
            // 
            // col_cash_back
            // 
            this.col_cash_back.HeaderText = "Cash Back";
            this.col_cash_back.Name = "col_cash_back";
            this.col_cash_back.ReadOnly = true;
            this.col_cash_back.Text = "Cash Back";
            this.col_cash_back.ToolTipText = "Cash Back";
            this.col_cash_back.UseColumnTextForButtonValue = true;
            this.col_cash_back.Width = 85;
            // 
            // col_replace
            // 
            this.col_replace.HeaderText = "Replace Card";
            this.col_replace.Name = "col_replace";
            this.col_replace.ReadOnly = true;
            this.col_replace.Text = "Replace Card";
            this.col_replace.ToolTipText = "Replace Card";
            this.col_replace.UseColumnTextForButtonValue = true;
            this.col_replace.Width = 85;
            // 
            // txt_searchbox
            // 
            this.txt_searchbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_searchbox.Location = new System.Drawing.Point(530, 78);
            this.txt_searchbox.Name = "txt_searchbox";
            this.txt_searchbox.Size = new System.Drawing.Size(237, 29);
            this.txt_searchbox.TabIndex = 117;
            this.txt_searchbox.TextChanged += new System.EventHandler(this.txt_searchbox_TextChanged);
            // 
            // lbl_search
            // 
            this.lbl_search.AutoSize = true;
            this.lbl_search.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_search.Location = new System.Drawing.Point(456, 82);
            this.lbl_search.Name = "lbl_search";
            this.lbl_search.Size = new System.Drawing.Size(71, 20);
            this.lbl_search.TabIndex = 118;
            this.lbl_search.Text = "Card No.";
            // 
            // lbl_balance
            // 
            this.lbl_balance.AutoSize = true;
            this.lbl_balance.Location = new System.Drawing.Point(910, 88);
            this.lbl_balance.Name = "lbl_balance";
            this.lbl_balance.Size = new System.Drawing.Size(0, 13);
            this.lbl_balance.TabIndex = 119;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(782, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 18);
            this.label1.TabIndex = 120;
            this.label1.Text = "Balance Avilable :";
            // 
            // btn_export_to_pdf
            // 
            this.btn_export_to_pdf.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_export_to_pdf.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btn_export_to_pdf.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_export_to_pdf.Location = new System.Drawing.Point(205, 648);
            this.btn_export_to_pdf.Name = "btn_export_to_pdf";
            this.btn_export_to_pdf.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(14);
            this.btn_export_to_pdf.Size = new System.Drawing.Size(165, 50);
            this.btn_export_to_pdf.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_export_to_pdf.Symbol = "";
            this.btn_export_to_pdf.TabIndex = 142;
            this.btn_export_to_pdf.Text = "Export to PDF";
            this.btn_export_to_pdf.Click += new System.EventHandler(this.btn_export_to_pdf_Click);
            // 
            // btn_excel
            // 
            this.btn_excel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_excel.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btn_excel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_excel.Location = new System.Drawing.Point(7, 646);
            this.btn_excel.Name = "btn_excel";
            this.btn_excel.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(14);
            this.btn_excel.Size = new System.Drawing.Size(182, 52);
            this.btn_excel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_excel.Symbol = "";
            this.btn_excel.TabIndex = 143;
            this.btn_excel.Text = "Export to Excel";
            this.btn_excel.Click += new System.EventHandler(this.btn_excel_Click);
            // 
            // txt_search_by
            // 
            this.txt_search_by.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_search_by.Location = new System.Drawing.Point(228, 78);
            this.txt_search_by.Name = "txt_search_by";
            this.txt_search_by.Size = new System.Drawing.Size(183, 29);
            this.txt_search_by.TabIndex = 144;
            this.txt_search_by.TextChanged += new System.EventHandler(this.txt_search_by_TextChanged);
            // 
            // cmb_search
            // 
            this.cmb_search.AutoCompleteCustomSource.AddRange(new string[] {
            "Search",
            "Name",
            "Phone"});
            this.cmb_search.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_search.FormattingEnabled = true;
            this.cmb_search.Items.AddRange(new object[] {
            "Search",
            "Name",
            "Phone"});
            this.cmb_search.Location = new System.Drawing.Point(91, 81);
            this.cmb_search.Name = "cmb_search";
            this.cmb_search.Size = new System.Drawing.Size(121, 26);
            this.cmb_search.TabIndex = 145;
            this.cmb_search.SelectedIndexChanged += new System.EventHandler(this.cmb_search_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 20);
            this.label2.TabIndex = 146;
            this.label2.Text = "Search By";
            // 
            // btn_previous
            // 
            this.btn_previous.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_previous.BackColor = System.Drawing.Color.Transparent;
            this.btn_previous.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btn_previous.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_previous.Location = new System.Drawing.Point(875, 648);
            this.btn_previous.Name = "btn_previous";
            this.btn_previous.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(14);
            this.btn_previous.Size = new System.Drawing.Size(37, 31);
            this.btn_previous.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_previous.Symbol = "";
            this.btn_previous.TabIndex = 149;
            this.btn_previous.Click += new System.EventHandler(this.btn_previous_Click);
            // 
            // btn_next
            // 
            this.btn_next.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_next.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btn_next.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_next.Location = new System.Drawing.Point(918, 648);
            this.btn_next.Name = "btn_next";
            this.btn_next.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(14);
            this.btn_next.Size = new System.Drawing.Size(37, 31);
            this.btn_next.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_next.Symbol = "";
            this.btn_next.TabIndex = 148;
            this.btn_next.Click += new System.EventHandler(this.btn_next_Click);
            // 
            // panel_replace
            // 
            this.panel_replace.BackColor = System.Drawing.SystemColors.Control;
            this.panel_replace.Controls.Add(this.button1);
            this.panel_replace.Controls.Add(this.label3);
            this.panel_replace.Controls.Add(this.btn_change);
            this.panel_replace.Controls.Add(this.label12);
            this.panel_replace.Controls.Add(this.lbl_blc);
            this.panel_replace.Controls.Add(this.label5);
            this.panel_replace.Controls.Add(this.lbl_cardno);
            this.panel_replace.Controls.Add(this.txt_newcard);
            this.panel_replace.Controls.Add(this.label4);
            this.panel_replace.Location = new System.Drawing.Point(361, 189);
            this.panel_replace.Name = "panel_replace";
            this.panel_replace.Size = new System.Drawing.Size(280, 305);
            this.panel_replace.TabIndex = 150;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(254, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(26, 27);
            this.button1.TabIndex = 151;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Georgia", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(81)))), ((int)(((byte)(126)))));
            this.label3.Location = new System.Drawing.Point(9, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(241, 29);
            this.label3.TabIndex = 19;
            this.label3.Text = "Card Replacement";
            // 
            // btn_change
            // 
            this.btn_change.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_change.BackColor = System.Drawing.Color.Transparent;
            this.btn_change.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btn_change.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_change.Location = new System.Drawing.Point(145, 239);
            this.btn_change.Name = "btn_change";
            this.btn_change.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor();
            this.btn_change.Size = new System.Drawing.Size(113, 36);
            this.btn_change.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_change.Symbol = "";
            this.btn_change.TabIndex = 150;
            this.btn_change.Text = "Change";
            this.btn_change.Click += new System.EventHandler(this.btn_change_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(9, 111);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(140, 18);
            this.label12.TabIndex = 124;
            this.label12.Text = "Balance Avialable :";
            // 
            // lbl_blc
            // 
            this.lbl_blc.AutoSize = true;
            this.lbl_blc.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_blc.Location = new System.Drawing.Point(155, 111);
            this.lbl_blc.Name = "lbl_blc";
            this.lbl_blc.Size = new System.Drawing.Size(84, 18);
            this.lbl_blc.TabIndex = 123;
            this.lbl_blc.Text = "                   ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(9, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 18);
            this.label5.TabIndex = 122;
            this.label5.Text = "Card No.";
            // 
            // lbl_cardno
            // 
            this.lbl_cardno.AutoSize = true;
            this.lbl_cardno.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_cardno.Location = new System.Drawing.Point(86, 78);
            this.lbl_cardno.Name = "lbl_cardno";
            this.lbl_cardno.Size = new System.Drawing.Size(164, 18);
            this.lbl_cardno.TabIndex = 121;
            this.lbl_cardno.Text = "                                       ";
            // 
            // txt_newcard
            // 
            this.txt_newcard.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_newcard.Location = new System.Drawing.Point(6, 188);
            this.txt_newcard.Name = "txt_newcard";
            this.txt_newcard.Size = new System.Drawing.Size(252, 29);
            this.txt_newcard.TabIndex = 119;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(11, 165);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 18);
            this.label4.TabIndex = 120;
            this.label4.Text = "New Card No.";
            // 
            // btn_topup
            // 
            this.btn_topup.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_topup.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btn_topup.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_topup.Location = new System.Drawing.Point(710, 646);
            this.btn_topup.Name = "btn_topup";
            this.btn_topup.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(14);
            this.btn_topup.Size = new System.Drawing.Size(148, 50);
            this.btn_topup.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_topup.Symbol = "";
            this.btn_topup.TabIndex = 151;
            this.btn_topup.Text = "Topup All";
            // 
            // CustomerList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btn_topup);
            this.Controls.Add(this.panel_replace);
            this.Controls.Add(this.btn_previous);
            this.Controls.Add(this.btn_next);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmb_search);
            this.Controls.Add(this.txt_search_by);
            this.Controls.Add(this.btn_excel);
            this.Controls.Add(this.btn_export_to_pdf);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_balance);
            this.Controls.Add(this.txt_searchbox);
            this.Controls.Add(this.lbl_search);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel2);
            this.Name = "CustomerList";
            this.Size = new System.Drawing.Size(995, 705);
            this.Load += new System.EventHandler(this.CutomerList_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel_replace.ResumeLayout(false);
            this.panel_replace.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_back;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txt_searchbox;
        private System.Windows.Forms.Label lbl_search;
        private System.Windows.Forms.Label lbl_balance;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.ButtonX btn_export_to_pdf;
        private DevComponents.DotNetBar.ButtonX btn_excel;
        private System.Windows.Forms.TextBox txt_search_by;
        private System.Windows.Forms.ComboBox cmb_search;
        private System.Windows.Forms.Label label2;
        private DevComponents.DotNetBar.ButtonX btn_previous;
        private DevComponents.DotNetBar.ButtonX btn_next;
        private System.Windows.Forms.TextBox txt_location;
        private System.Windows.Forms.Panel panel_replace;
        private System.Windows.Forms.Label lbl_cardno;
        private System.Windows.Forms.TextBox txt_newcard;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lbl_blc;
        private System.Windows.Forms.Label label5;
        private DevComponents.DotNetBar.ButtonX btn_change;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_last_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_card_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_card_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_balance;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_id;
        private System.Windows.Forms.DataGridViewButtonColumn col_add;
        private System.Windows.Forms.DataGridViewButtonColumn col_cash_back;
        private System.Windows.Forms.DataGridViewButtonColumn col_replace;
        private System.Windows.Forms.Button button1;
        private DevComponents.DotNetBar.ButtonX btn_topup;
    }
}