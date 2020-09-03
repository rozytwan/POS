namespace POS_System.Customer_Management
{
    partial class Mess_detail_record
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
            this.components = new System.ComponentModel.Container();
            this.lbl_cusId = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tb_breakfast = new System.Windows.Forms.TabPage();
            this.dgv_br = new System.Windows.Forms.DataGridView();
            this.colid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coldate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colpackagename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tb_lunch = new System.Windows.Forms.TabPage();
            this.dgv_lunch = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tb_snacks = new System.Windows.Forms.TabPage();
            this.dgv_snacks = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tb_dinner = new System.Windows.Forms.TabPage();
            this.dgv_dinner = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbl_dates = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_packages = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_time = new System.Windows.Forms.Label();
            this.lbl_now = new System.Windows.Forms.Label();
            this.lbl_Phone = new System.Windows.Forms.Label();
            this.lbl_adress = new System.Windows.Forms.Label();
            this.lbl_Fullname = new System.Windows.Forms.Label();
            this.panel_extra = new System.Windows.Forms.Panel();
            this.dgv_extras = new System.Windows.Forms.DataGridView();
            this.col_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colpackage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coldates = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_day = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coldesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colatetime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colamount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel_bottom = new System.Windows.Forms.Panel();
            this.lbl_totalamount = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lbl_packageCost = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbl_noofdays = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbl_sum = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tb_breakfast.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_br)).BeginInit();
            this.tb_lunch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_lunch)).BeginInit();
            this.tb_snacks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_snacks)).BeginInit();
            this.tb_dinner.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_dinner)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel_extra.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_extras)).BeginInit();
            this.panel_bottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_cusId
            // 
            this.lbl_cusId.AutoSize = true;
            this.lbl_cusId.Location = new System.Drawing.Point(12, 9);
            this.lbl_cusId.Name = "lbl_cusId";
            this.lbl_cusId.Size = new System.Drawing.Size(18, 13);
            this.lbl_cusId.TabIndex = 1;
            this.lbl_cusId.Text = "ID";
            this.lbl_cusId.TextChanged += new System.EventHandler(this.lbl_cusId_TextChanged);
            this.lbl_cusId.Click += new System.EventHandler(this.lbl_cusId_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tb_breakfast);
            this.tabControl1.Controls.Add(this.tb_lunch);
            this.tabControl1.Controls.Add(this.tb_snacks);
            this.tabControl1.Controls.Add(this.tb_dinner);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(7, 92);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(399, 364);
            this.tabControl1.TabIndex = 2;
            // 
            // tb_breakfast
            // 
            this.tb_breakfast.Controls.Add(this.dgv_br);
            this.tb_breakfast.Location = new System.Drawing.Point(4, 27);
            this.tb_breakfast.Name = "tb_breakfast";
            this.tb_breakfast.Padding = new System.Windows.Forms.Padding(3);
            this.tb_breakfast.Size = new System.Drawing.Size(391, 333);
            this.tb_breakfast.TabIndex = 0;
            this.tb_breakfast.Text = "Breakfast";
            this.tb_breakfast.UseVisualStyleBackColor = true;
            // 
            // dgv_br
            // 
            this.dgv_br.AllowUserToAddRows = false;
            this.dgv_br.AllowUserToDeleteRows = false;
            this.dgv_br.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_br.BackgroundColor = System.Drawing.Color.White;
            this.dgv_br.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_br.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colid,
            this.coldate,
            this.colday,
            this.colpackagename});
            this.dgv_br.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_br.Location = new System.Drawing.Point(3, 3);
            this.dgv_br.Name = "dgv_br";
            this.dgv_br.ReadOnly = true;
            this.dgv_br.RowHeadersVisible = false;
            this.dgv_br.Size = new System.Drawing.Size(385, 327);
            this.dgv_br.TabIndex = 0;
            // 
            // colid
            // 
            this.colid.HeaderText = "Id";
            this.colid.Name = "colid";
            this.colid.ReadOnly = true;
            this.colid.Visible = false;
            // 
            // coldate
            // 
            this.coldate.HeaderText = "Date";
            this.coldate.Name = "coldate";
            this.coldate.ReadOnly = true;
            // 
            // colday
            // 
            this.colday.HeaderText = "Day";
            this.colday.Name = "colday";
            this.colday.ReadOnly = true;
            // 
            // colpackagename
            // 
            this.colpackagename.HeaderText = "Package";
            this.colpackagename.Name = "colpackagename";
            this.colpackagename.ReadOnly = true;
            // 
            // tb_lunch
            // 
            this.tb_lunch.Controls.Add(this.dgv_lunch);
            this.tb_lunch.Location = new System.Drawing.Point(4, 27);
            this.tb_lunch.Name = "tb_lunch";
            this.tb_lunch.Padding = new System.Windows.Forms.Padding(3);
            this.tb_lunch.Size = new System.Drawing.Size(391, 333);
            this.tb_lunch.TabIndex = 1;
            this.tb_lunch.Text = "Lunch";
            this.tb_lunch.UseVisualStyleBackColor = true;
            // 
            // dgv_lunch
            // 
            this.dgv_lunch.AllowUserToAddRows = false;
            this.dgv_lunch.AllowUserToDeleteRows = false;
            this.dgv_lunch.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_lunch.BackgroundColor = System.Drawing.Color.White;
            this.dgv_lunch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_lunch.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.dgv_lunch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_lunch.Location = new System.Drawing.Point(3, 3);
            this.dgv_lunch.Name = "dgv_lunch";
            this.dgv_lunch.ReadOnly = true;
            this.dgv_lunch.RowHeadersVisible = false;
            this.dgv_lunch.Size = new System.Drawing.Size(385, 327);
            this.dgv_lunch.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Id";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Date";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Day";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Package";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // tb_snacks
            // 
            this.tb_snacks.Controls.Add(this.dgv_snacks);
            this.tb_snacks.Location = new System.Drawing.Point(4, 27);
            this.tb_snacks.Name = "tb_snacks";
            this.tb_snacks.Padding = new System.Windows.Forms.Padding(3);
            this.tb_snacks.Size = new System.Drawing.Size(391, 333);
            this.tb_snacks.TabIndex = 2;
            this.tb_snacks.Text = "Snacks";
            this.tb_snacks.UseVisualStyleBackColor = true;
            // 
            // dgv_snacks
            // 
            this.dgv_snacks.AllowUserToAddRows = false;
            this.dgv_snacks.AllowUserToDeleteRows = false;
            this.dgv_snacks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_snacks.BackgroundColor = System.Drawing.Color.White;
            this.dgv_snacks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_snacks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8});
            this.dgv_snacks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_snacks.Location = new System.Drawing.Point(3, 3);
            this.dgv_snacks.Name = "dgv_snacks";
            this.dgv_snacks.ReadOnly = true;
            this.dgv_snacks.RowHeadersVisible = false;
            this.dgv_snacks.Size = new System.Drawing.Size(385, 327);
            this.dgv_snacks.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Id";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Visible = false;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Date";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "Day";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "Package";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // tb_dinner
            // 
            this.tb_dinner.Controls.Add(this.dgv_dinner);
            this.tb_dinner.Location = new System.Drawing.Point(4, 27);
            this.tb_dinner.Name = "tb_dinner";
            this.tb_dinner.Padding = new System.Windows.Forms.Padding(3);
            this.tb_dinner.Size = new System.Drawing.Size(391, 333);
            this.tb_dinner.TabIndex = 3;
            this.tb_dinner.Text = "Dinner";
            this.tb_dinner.UseVisualStyleBackColor = true;
            // 
            // dgv_dinner
            // 
            this.dgv_dinner.AllowUserToAddRows = false;
            this.dgv_dinner.AllowUserToDeleteRows = false;
            this.dgv_dinner.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_dinner.BackgroundColor = System.Drawing.Color.White;
            this.dgv_dinner.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_dinner.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn12});
            this.dgv_dinner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_dinner.Location = new System.Drawing.Point(3, 3);
            this.dgv_dinner.Name = "dgv_dinner";
            this.dgv_dinner.ReadOnly = true;
            this.dgv_dinner.RowHeadersVisible = false;
            this.dgv_dinner.Size = new System.Drawing.Size(385, 327);
            this.dgv_dinner.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "Id";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Visible = false;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.HeaderText = "Date";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.HeaderText = "Day";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.HeaderText = "Package";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(81)))), ((int)(((byte)(126)))));
            this.panel2.Controls.Add(this.lbl_dates);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.lbl_packages);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.lbl_time);
            this.panel2.Controls.Add(this.lbl_now);
            this.panel2.Controls.Add(this.lbl_Phone);
            this.panel2.Controls.Add(this.lbl_adress);
            this.panel2.Controls.Add(this.lbl_Fullname);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(883, 78);
            this.panel2.TabIndex = 105;
            // 
            // lbl_dates
            // 
            this.lbl_dates.AutoSize = true;
            this.lbl_dates.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_dates.ForeColor = System.Drawing.Color.White;
            this.lbl_dates.Location = new System.Drawing.Point(488, 35);
            this.lbl_dates.Name = "lbl_dates";
            this.lbl_dates.Size = new System.Drawing.Size(43, 18);
            this.lbl_dates.TabIndex = 24;
            this.lbl_dates.Text = "Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(298, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(188, 18);
            this.label3.TabIndex = 23;
            this.label3.Text = "Registered Package on:";
            // 
            // lbl_packages
            // 
            this.lbl_packages.AutoSize = true;
            this.lbl_packages.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_packages.ForeColor = System.Drawing.Color.White;
            this.lbl_packages.Location = new System.Drawing.Point(463, 9);
            this.lbl_packages.Name = "lbl_packages";
            this.lbl_packages.Size = new System.Drawing.Size(90, 24);
            this.lbl_packages.TabIndex = 22;
            this.lbl_packages.Text = "Package";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(297, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(171, 24);
            this.label2.TabIndex = 21;
            this.label2.Text = "Current Package:";
            // 
            // lbl_time
            // 
            this.lbl_time.AutoSize = true;
            this.lbl_time.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_time.ForeColor = System.Drawing.Color.White;
            this.lbl_time.Location = new System.Drawing.Point(11, 37);
            this.lbl_time.Name = "lbl_time";
            this.lbl_time.Size = new System.Drawing.Size(52, 20);
            this.lbl_time.TabIndex = 20;
            this.lbl_time.Text = "Time:";
            // 
            // lbl_now
            // 
            this.lbl_now.AutoSize = true;
            this.lbl_now.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_now.ForeColor = System.Drawing.Color.White;
            this.lbl_now.Location = new System.Drawing.Point(11, 9);
            this.lbl_now.Name = "lbl_now";
            this.lbl_now.Size = new System.Drawing.Size(48, 20);
            this.lbl_now.TabIndex = 19;
            this.lbl_now.Text = "Now:";
            // 
            // lbl_Phone
            // 
            this.lbl_Phone.AutoSize = true;
            this.lbl_Phone.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Phone.ForeColor = System.Drawing.Color.White;
            this.lbl_Phone.Location = new System.Drawing.Point(625, 55);
            this.lbl_Phone.Name = "lbl_Phone";
            this.lbl_Phone.Size = new System.Drawing.Size(61, 18);
            this.lbl_Phone.TabIndex = 18;
            this.lbl_Phone.Text = "Phone:";
            // 
            // lbl_adress
            // 
            this.lbl_adress.AutoSize = true;
            this.lbl_adress.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_adress.ForeColor = System.Drawing.Color.White;
            this.lbl_adress.Location = new System.Drawing.Point(625, 35);
            this.lbl_adress.Name = "lbl_adress";
            this.lbl_adress.Size = new System.Drawing.Size(69, 18);
            this.lbl_adress.TabIndex = 17;
            this.lbl_adress.Text = "Address";
            // 
            // lbl_Fullname
            // 
            this.lbl_Fullname.AutoSize = true;
            this.lbl_Fullname.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Fullname.ForeColor = System.Drawing.Color.White;
            this.lbl_Fullname.Location = new System.Drawing.Point(625, 7);
            this.lbl_Fullname.Name = "lbl_Fullname";
            this.lbl_Fullname.Size = new System.Drawing.Size(106, 24);
            this.lbl_Fullname.TabIndex = 16;
            this.lbl_Fullname.Text = "Full Name";
            // 
            // panel_extra
            // 
            this.panel_extra.Controls.Add(this.dgv_extras);
            this.panel_extra.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel_extra.Location = new System.Drawing.Point(417, 121);
            this.panel_extra.Name = "panel_extra";
            this.panel_extra.Size = new System.Drawing.Size(455, 330);
            this.panel_extra.TabIndex = 106;
            // 
            // dgv_extras
            // 
            this.dgv_extras.AllowUserToAddRows = false;
            this.dgv_extras.AllowUserToDeleteRows = false;
            this.dgv_extras.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_extras.BackgroundColor = System.Drawing.Color.White;
            this.dgv_extras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_extras.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_id,
            this.colpackage,
            this.coldates,
            this.col_day,
            this.coldesc,
            this.colatetime,
            this.colamount});
            this.dgv_extras.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_extras.Location = new System.Drawing.Point(0, 0);
            this.dgv_extras.Name = "dgv_extras";
            this.dgv_extras.ReadOnly = true;
            this.dgv_extras.RowHeadersVisible = false;
            this.dgv_extras.Size = new System.Drawing.Size(455, 330);
            this.dgv_extras.TabIndex = 0;
            // 
            // col_id
            // 
            this.col_id.HeaderText = "Id";
            this.col_id.Name = "col_id";
            this.col_id.ReadOnly = true;
            this.col_id.Visible = false;
            // 
            // colpackage
            // 
            this.colpackage.HeaderText = "Package";
            this.colpackage.Name = "colpackage";
            this.colpackage.ReadOnly = true;
            this.colpackage.Visible = false;
            // 
            // coldates
            // 
            this.coldates.HeaderText = "Date";
            this.coldates.Name = "coldates";
            this.coldates.ReadOnly = true;
            // 
            // col_day
            // 
            this.col_day.HeaderText = "Day";
            this.col_day.Name = "col_day";
            this.col_day.ReadOnly = true;
            // 
            // coldesc
            // 
            this.coldesc.HeaderText = "Description";
            this.coldesc.Name = "coldesc";
            this.coldesc.ReadOnly = true;
            // 
            // colatetime
            // 
            this.colatetime.HeaderText = "At";
            this.colatetime.Name = "colatetime";
            this.colatetime.ReadOnly = true;
            // 
            // colamount
            // 
            this.colamount.HeaderText = "Amount";
            this.colamount.Name = "colamount";
            this.colamount.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(588, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 18);
            this.label1.TabIndex = 107;
            this.label1.Text = "Extra Payables";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel_bottom
            // 
            this.panel_bottom.Controls.Add(this.lbl_totalamount);
            this.panel_bottom.Controls.Add(this.label9);
            this.panel_bottom.Controls.Add(this.lbl_packageCost);
            this.panel_bottom.Controls.Add(this.label5);
            this.panel_bottom.Controls.Add(this.label7);
            this.panel_bottom.Controls.Add(this.lbl_noofdays);
            this.panel_bottom.Controls.Add(this.label6);
            this.panel_bottom.Controls.Add(this.lbl_sum);
            this.panel_bottom.Controls.Add(this.label4);
            this.panel_bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_bottom.Location = new System.Drawing.Point(0, 471);
            this.panel_bottom.Name = "panel_bottom";
            this.panel_bottom.Size = new System.Drawing.Size(883, 64);
            this.panel_bottom.TabIndex = 108;
            // 
            // lbl_totalamount
            // 
            this.lbl_totalamount.AutoSize = true;
            this.lbl_totalamount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_totalamount.Location = new System.Drawing.Point(753, 29);
            this.lbl_totalamount.Name = "lbl_totalamount";
            this.lbl_totalamount.Size = new System.Drawing.Size(40, 18);
            this.lbl_totalamount.TabIndex = 8;
            this.lbl_totalamount.Text = "0.00";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(585, 29);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(168, 18);
            this.label9.TabIndex = 7;
            this.label9.Text = "Total Paying Amount:";
            // 
            // lbl_packageCost
            // 
            this.lbl_packageCost.AutoSize = true;
            this.lbl_packageCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_packageCost.Location = new System.Drawing.Point(753, 9);
            this.lbl_packageCost.Name = "lbl_packageCost";
            this.lbl_packageCost.Size = new System.Drawing.Size(40, 18);
            this.lbl_packageCost.TabIndex = 6;
            this.lbl_packageCost.Text = "0.00";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(772, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 18);
            this.label5.TabIndex = 5;
            this.label5.Text = "0.00";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(571, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(182, 18);
            this.label7.TabIndex = 4;
            this.label7.Text = "Package Cost per Day:";
            // 
            // lbl_noofdays
            // 
            this.lbl_noofdays.AutoSize = true;
            this.lbl_noofdays.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_noofdays.Location = new System.Drawing.Point(117, 28);
            this.lbl_noofdays.Name = "lbl_noofdays";
            this.lbl_noofdays.Size = new System.Drawing.Size(40, 18);
            this.lbl_noofdays.TabIndex = 3;
            this.lbl_noofdays.Text = "0.00";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(21, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 18);
            this.label6.TabIndex = 2;
            this.label6.Text = "No of Days:";
            // 
            // lbl_sum
            // 
            this.lbl_sum.AutoSize = true;
            this.lbl_sum.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_sum.Location = new System.Drawing.Point(236, 8);
            this.lbl_sum.Name = "lbl_sum";
            this.lbl_sum.Size = new System.Drawing.Size(40, 18);
            this.lbl_sum.TabIndex = 1;
            this.lbl_sum.Text = "0.00";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(11, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(227, 18);
            this.label4.TabIndex = 0;
            this.label4.Text = "Total Sum of Extra Payables:";
            // 
            // Mess_detail_record
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(883, 535);
            this.Controls.Add(this.panel_bottom);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel_extra);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lbl_cusId);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Mess_detail_record";
            this.Text = "Mess_detail_record";
            this.Load += new System.EventHandler(this.Mess_detail_record_Load);
            this.tabControl1.ResumeLayout(false);
            this.tb_breakfast.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_br)).EndInit();
            this.tb_lunch.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_lunch)).EndInit();
            this.tb_snacks.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_snacks)).EndInit();
            this.tb_dinner.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_dinner)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel_extra.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_extras)).EndInit();
            this.panel_bottom.ResumeLayout(false);
            this.panel_bottom.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tb_breakfast;
        private System.Windows.Forms.TabPage tb_lunch;
        private System.Windows.Forms.TabPage tb_snacks;
        private System.Windows.Forms.TabPage tb_dinner;
        private System.Windows.Forms.DataGridView dgv_br;
        private System.Windows.Forms.DataGridViewTextBoxColumn colid;
        private System.Windows.Forms.DataGridViewTextBoxColumn coldate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colday;
        private System.Windows.Forms.DataGridViewTextBoxColumn colpackagename;
        private System.Windows.Forms.DataGridView dgv_lunch;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridView dgv_snacks;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridView dgv_dinner;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        public System.Windows.Forms.Label lbl_cusId;
        private System.Windows.Forms.Panel panel_extra;
        private System.Windows.Forms.DataGridView dgv_extras;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn colpackage;
        private System.Windows.Forms.DataGridViewTextBoxColumn coldates;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_day;
        private System.Windows.Forms.DataGridViewTextBoxColumn coldesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colatetime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colamount;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label lbl_Phone;
        public System.Windows.Forms.Label lbl_adress;
        public System.Windows.Forms.Label lbl_Fullname;
        public System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Label lbl_time;
        public System.Windows.Forms.Label lbl_now;
        public System.Windows.Forms.Label lbl_packages;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label lbl_dates;
        private System.Windows.Forms.Timer timer1;
        public System.Windows.Forms.Panel panel_bottom;
        private System.Windows.Forms.Label lbl_sum;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbl_packageCost;
        public System.Windows.Forms.Label lbl_noofdays;
        private System.Windows.Forms.Label lbl_totalamount;
        private System.Windows.Forms.Label label9;
    }
}