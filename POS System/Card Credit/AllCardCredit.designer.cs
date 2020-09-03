namespace POS_System
{
    partial class AllCardCredit
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
            this.contentpanel = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbl_total = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lbl_pay = new System.Windows.Forms.Label();
            this.lbl_paid = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.lbl_remain = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lbl_logger = new System.Windows.Forms.Label();
            this.lbl_id = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btn_clearall = new System.Windows.Forms.Button();
            this.Show_paid_credits = new System.Windows.Forms.Button();
            this.lbl_email = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lbl_city = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lbl_phone = new System.Windows.Forms.Label();
            this.picbox_user = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lbl_address = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbl_name = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_back = new System.Windows.Forms.Button();
            this.label23 = new System.Windows.Forms.Label();
            this.col_customername = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_bill_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_credit_amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_credit_by = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_credit_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_refer_by = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_reprint = new System.Windows.Forms.DataGridViewButtonColumn();
            this.contentpanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbox_user)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // contentpanel
            // 
            this.contentpanel.BackColor = System.Drawing.Color.White;
            this.contentpanel.Controls.Add(this.dataGridView1);
            this.contentpanel.Controls.Add(this.groupBox1);
            this.contentpanel.Controls.Add(this.groupBox4);
            this.contentpanel.Controls.Add(this.groupBox5);
            this.contentpanel.Controls.Add(this.groupBox3);
            this.contentpanel.Controls.Add(this.label2);
            this.contentpanel.Location = new System.Drawing.Point(3, 70);
            this.contentpanel.Name = "contentpanel";
            this.contentpanel.Size = new System.Drawing.Size(1031, 589);
            this.contentpanel.TabIndex = 125;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_customername,
            this.col_bill_no,
            this.col_credit_amount,
            this.col_credit_by,
            this.col_credit_date,
            this.col_refer_by,
            this.col_reprint});
            this.dataGridView1.Location = new System.Drawing.Point(321, 51);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(687, 436);
            this.dataGridView1.TabIndex = 65;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbl_total);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(386, 503);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(194, 74);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // lbl_total
            // 
            this.lbl_total.AutoSize = true;
            this.lbl_total.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_total.ForeColor = System.Drawing.Color.Black;
            this.lbl_total.Location = new System.Drawing.Point(15, 40);
            this.lbl_total.Name = "lbl_total";
            this.lbl_total.Size = new System.Drawing.Size(49, 24);
            this.lbl_total.TabIndex = 1;
            this.lbl_total.Text = "0.00";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Total Credit Amount:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lbl_pay);
            this.groupBox4.Controls.Add(this.lbl_paid);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Location = new System.Drawing.Point(610, 503);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(182, 74);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            // 
            // lbl_pay
            // 
            this.lbl_pay.AutoSize = true;
            this.lbl_pay.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_pay.Location = new System.Drawing.Point(33, 43);
            this.lbl_pay.Name = "lbl_pay";
            this.lbl_pay.Size = new System.Drawing.Size(49, 24);
            this.lbl_pay.TabIndex = 2;
            this.lbl_pay.Text = "0.00";
            // 
            // lbl_paid
            // 
            this.lbl_paid.AutoSize = true;
            this.lbl_paid.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_paid.Location = new System.Drawing.Point(16, 40);
            this.lbl_paid.Name = "lbl_paid";
            this.lbl_paid.Size = new System.Drawing.Size(0, 24);
            this.lbl_paid.TabIndex = 1;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(6, 16);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(138, 24);
            this.label14.TabIndex = 0;
            this.label14.Text = "Total cash Paid";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.lbl_remain);
            this.groupBox5.Controls.Add(this.label15);
            this.groupBox5.Location = new System.Drawing.Point(816, 503);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(192, 74);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            // 
            // lbl_remain
            // 
            this.lbl_remain.AutoSize = true;
            this.lbl_remain.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_remain.Location = new System.Drawing.Point(15, 40);
            this.lbl_remain.Name = "lbl_remain";
            this.lbl_remain.Size = new System.Drawing.Size(49, 24);
            this.lbl_remain.TabIndex = 1;
            this.lbl_remain.Text = "0.00";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(3, 16);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(177, 24);
            this.label15.TabIndex = 0;
            this.label15.Text = "Remaining Amount:";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox3.Controls.Add(this.lbl_logger);
            this.groupBox3.Controls.Add(this.lbl_id);
            this.groupBox3.Controls.Add(this.flowLayoutPanel1);
            this.groupBox3.Controls.Add(this.lbl_email);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.lbl_city);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.lbl_phone);
            this.groupBox3.Controls.Add(this.picbox_user);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.lbl_address);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.lbl_name);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(3, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(312, 486);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Customer Details";
            // 
            // lbl_logger
            // 
            this.lbl_logger.AutoSize = true;
            this.lbl_logger.Location = new System.Drawing.Point(199, 465);
            this.lbl_logger.Name = "lbl_logger";
            this.lbl_logger.Size = new System.Drawing.Size(51, 16);
            this.lbl_logger.TabIndex = 21;
            this.lbl_logger.Text = "Logger";
            this.lbl_logger.Visible = false;
            // 
            // lbl_id
            // 
            this.lbl_id.AutoSize = true;
            this.lbl_id.Location = new System.Drawing.Point(276, 467);
            this.lbl_id.Name = "lbl_id";
            this.lbl_id.Size = new System.Drawing.Size(21, 16);
            this.lbl_id.TabIndex = 20;
            this.lbl_id.Text = "ID";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btn_clearall);
            this.flowLayoutPanel1.Controls.Add(this.Show_paid_credits);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(212, 21);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(94, 122);
            this.flowLayoutPanel1.TabIndex = 19;
            // 
            // btn_clearall
            // 
            this.btn_clearall.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(81)))), ((int)(((byte)(126)))));
            this.btn_clearall.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_clearall.ForeColor = System.Drawing.Color.White;
            this.btn_clearall.Location = new System.Drawing.Point(3, 3);
            this.btn_clearall.Name = "btn_clearall";
            this.btn_clearall.Size = new System.Drawing.Size(87, 56);
            this.btn_clearall.TabIndex = 0;
            this.btn_clearall.Text = "Pay Credit";
            this.btn_clearall.UseVisualStyleBackColor = false;
            this.btn_clearall.Click += new System.EventHandler(this.btn_clearall_Click);
            // 
            // Show_paid_credits
            // 
            this.Show_paid_credits.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(81)))), ((int)(((byte)(126)))));
            this.Show_paid_credits.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Show_paid_credits.ForeColor = System.Drawing.Color.White;
            this.Show_paid_credits.Location = new System.Drawing.Point(3, 65);
            this.Show_paid_credits.Name = "Show_paid_credits";
            this.Show_paid_credits.Size = new System.Drawing.Size(87, 52);
            this.Show_paid_credits.TabIndex = 1;
            this.Show_paid_credits.Text = "Show Paid Credits";
            this.Show_paid_credits.UseVisualStyleBackColor = false;
            this.Show_paid_credits.Click += new System.EventHandler(this.Show_paid_credits_Click);
            // 
            // lbl_email
            // 
            this.lbl_email.AutoSize = true;
            this.lbl_email.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_email.Location = new System.Drawing.Point(87, 310);
            this.lbl_email.Name = "lbl_email";
            this.lbl_email.Size = new System.Drawing.Size(55, 20);
            this.lbl_email.TabIndex = 18;
            this.lbl_email.Text = "Phone";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(24, 310);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(52, 20);
            this.label13.TabIndex = 17;
            this.label13.Text = "Email:";
            // 
            // lbl_city
            // 
            this.lbl_city.AutoSize = true;
            this.lbl_city.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_city.Location = new System.Drawing.Point(87, 255);
            this.lbl_city.Name = "lbl_city";
            this.lbl_city.Size = new System.Drawing.Size(68, 20);
            this.lbl_city.TabIndex = 16;
            this.lbl_city.Text = "Address";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(25, 255);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(39, 20);
            this.label12.TabIndex = 15;
            this.label12.Text = "City:";
            // 
            // lbl_phone
            // 
            this.lbl_phone.AutoSize = true;
            this.lbl_phone.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_phone.Location = new System.Drawing.Point(87, 290);
            this.lbl_phone.Name = "lbl_phone";
            this.lbl_phone.Size = new System.Drawing.Size(55, 20);
            this.lbl_phone.TabIndex = 12;
            this.lbl_phone.Text = "Phone";
            // 
            // picbox_user
            // 
            this.picbox_user.Location = new System.Drawing.Point(10, 21);
            this.picbox_user.Name = "picbox_user";
            this.picbox_user.Size = new System.Drawing.Size(187, 172);
            this.picbox_user.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picbox_user.TabIndex = 11;
            this.picbox_user.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(17, 290);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 20);
            this.label9.TabIndex = 10;
            this.label9.Text = "Phone:";
            // 
            // lbl_address
            // 
            this.lbl_address.AutoSize = true;
            this.lbl_address.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_address.Location = new System.Drawing.Point(84, 222);
            this.lbl_address.Name = "lbl_address";
            this.lbl_address.Size = new System.Drawing.Size(68, 20);
            this.lbl_address.TabIndex = 9;
            this.lbl_address.Text = "Address";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(6, 222);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 20);
            this.label8.TabIndex = 8;
            this.label8.Text = "Address:";
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_name.Location = new System.Drawing.Point(87, 202);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(49, 20);
            this.lbl_name.TabIndex = 6;
            this.lbl_name.Text = "name";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(21, 201);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 20);
            this.label7.TabIndex = 7;
            this.label7.Text = "Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(81)))), ((int)(((byte)(126)))));
            this.label2.Location = new System.Drawing.Point(580, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(197, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "Credit Record Detail";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.contentpanel);
            this.panel1.Location = new System.Drawing.Point(2, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1037, 662);
            this.panel1.TabIndex = 126;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(81)))), ((int)(((byte)(126)))));
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.btn_back);
            this.panel2.Controls.Add(this.label23);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1037, 67);
            this.panel2.TabIndex = 126;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::POS_System.Properties.Resources.check__1_;
            this.pictureBox1.Location = new System.Drawing.Point(317, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(59, 62);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 26;
            this.pictureBox1.TabStop = false;
            // 
            // btn_back
            // 
            this.btn_back.FlatAppearance.BorderSize = 0;
            this.btn_back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_back.Image = global::POS_System.Properties.Resources.back36;
            this.btn_back.Location = new System.Drawing.Point(3, 2);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(76, 65);
            this.btn_back.TabIndex = 20;
            this.btn_back.UseVisualStyleBackColor = true;
            this.btn_back.Click += new System.EventHandler(this.btn_back_Click);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.White;
            this.label23.Location = new System.Drawing.Point(382, 20);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(288, 39);
            this.label23.TabIndex = 18;
            this.label23.Text = "Card Credit Detail";
            // 
            // col_customername
            // 
            this.col_customername.HeaderText = "Customer Name";
            this.col_customername.Name = "col_customername";
            this.col_customername.ReadOnly = true;
            this.col_customername.Width = 140;
            // 
            // col_bill_no
            // 
            this.col_bill_no.HeaderText = "Bill_No";
            this.col_bill_no.Name = "col_bill_no";
            this.col_bill_no.ReadOnly = true;
            this.col_bill_no.Visible = false;
            this.col_bill_no.Width = 120;
            // 
            // col_credit_amount
            // 
            this.col_credit_amount.HeaderText = "Credit Amount";
            this.col_credit_amount.Name = "col_credit_amount";
            this.col_credit_amount.ReadOnly = true;
            this.col_credit_amount.Width = 130;
            // 
            // col_credit_by
            // 
            this.col_credit_by.HeaderText = "Credit By";
            this.col_credit_by.Name = "col_credit_by";
            this.col_credit_by.ReadOnly = true;
            this.col_credit_by.Width = 120;
            // 
            // col_credit_date
            // 
            this.col_credit_date.HeaderText = "Credit Date";
            this.col_credit_date.Name = "col_credit_date";
            this.col_credit_date.ReadOnly = true;
            this.col_credit_date.Width = 120;
            // 
            // col_refer_by
            // 
            this.col_refer_by.HeaderText = "Refer By";
            this.col_refer_by.Name = "col_refer_by";
            this.col_refer_by.ReadOnly = true;
            this.col_refer_by.Width = 130;
            // 
            // col_reprint
            // 
            this.col_reprint.HeaderText = "Re Print";
            this.col_reprint.Name = "col_reprint";
            this.col_reprint.ReadOnly = true;
            this.col_reprint.Text = "Re Print";
            this.col_reprint.ToolTipText = "Re Print";
            this.col_reprint.UseColumnTextForButtonValue = true;
            this.col_reprint.Visible = false;
            // 
            // AllCardCredit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "AllCardCredit";
            this.Size = new System.Drawing.Size(1045, 680);
            this.Load += new System.EventHandler(this.AllCardCredit_Load);
            this.contentpanel.ResumeLayout(false);
            this.contentpanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picbox_user)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel contentpanel;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbl_total;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label lbl_pay;
        private System.Windows.Forms.Label lbl_paid;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label lbl_remain;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.GroupBox groupBox3;
        public System.Windows.Forms.Label lbl_logger;
        private System.Windows.Forms.Label lbl_id;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btn_clearall;
        private System.Windows.Forms.Button Show_paid_credits;
        private System.Windows.Forms.Label lbl_email;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lbl_city;
        private System.Windows.Forms.Label label12;
        public System.Windows.Forms.Label lbl_phone;
        private System.Windows.Forms.PictureBox picbox_user;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lbl_address;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_back;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_customername;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_bill_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_credit_amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_credit_by;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_credit_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_refer_by;
        private System.Windows.Forms.DataGridViewButtonColumn col_reprint;
    }
}