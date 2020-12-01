namespace POS_System
{
    partial class home
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cbo_delivery = new System.Windows.Forms.ComboBox();
            this.txt_adress = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label23 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cal_item_category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_item_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_order_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calkot_print = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbo_home_id = new System.Windows.Forms.ComboBox();
            this.txt_total = new System.Windows.Forms.TextBox();
            this.txt_delivery_charge = new System.Windows.Forms.TextBox();
            this.txt_grand_total = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btntable_transfer = new System.Windows.Forms.GroupBox();
            this.txtcashier = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_phone = new System.Windows.Forms.ComboBox();
            this.txt_customer = new System.Windows.Forms.ComboBox();
            this.btnminus = new System.Windows.Forms.Button();
            this.btnaadd = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.txt_discount = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btn_save = new DevComponents.DotNetBar.ButtonX();
            this.txt_tax_amount = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btn_add = new System.Windows.Forms.Button();
            this.rbtn_cash = new System.Windows.Forms.RadioButton();
            this.rbtn_card = new System.Windows.Forms.RadioButton();
            this.rbtn_zomato_pre_paid = new System.Windows.Forms.RadioButton();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.btntable_transfer.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbo_delivery
            // 
            this.cbo_delivery.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbo_delivery.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbo_delivery.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.HistoryList;
            this.cbo_delivery.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_delivery.FormattingEnabled = true;
            this.cbo_delivery.Location = new System.Drawing.Point(663, 584);
            this.cbo_delivery.Name = "cbo_delivery";
            this.cbo_delivery.Size = new System.Drawing.Size(218, 28);
            this.cbo_delivery.TabIndex = 6;
            // 
            // txt_adress
            // 
            this.txt_adress.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_adress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_adress.Location = new System.Drawing.Point(163, 451);
            this.txt_adress.Name = "txt_adress";
            this.txt_adress.Size = new System.Drawing.Size(259, 26);
            this.txt_adress.TabIndex = 3;
            this.txt_adress.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_adress_KeyDown);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(81)))), ((int)(((byte)(126)))));
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.label23);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1012, 73);
            this.panel2.TabIndex = 103;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::POS_System.Properties.Resources.transport__2_;
            this.pictureBox1.Location = new System.Drawing.Point(336, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(71, 68);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 23;
            this.pictureBox1.TabStop = false;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.White;
            this.label23.Location = new System.Drawing.Point(403, 19);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(329, 39);
            this.label23.TabIndex = 18;
            this.label23.Text = "Home Delivery Entry";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cal_item_category,
            this.cal_item_name,
            this.cal_order_id,
            this.cal_qty,
            this.cal_cost,
            this.cal_total,
            this.calkot_print});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Location = new System.Drawing.Point(14, 163);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.dataGridView1.Size = new System.Drawing.Size(867, 239);
            this.dataGridView1.TabIndex = 1;
            // 
            // cal_item_category
            // 
            this.cal_item_category.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cal_item_category.HeaderText = "Category Name";
            this.cal_item_category.Name = "cal_item_category";
            // 
            // cal_item_name
            // 
            this.cal_item_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cal_item_name.HeaderText = "Item Name";
            this.cal_item_name.Name = "cal_item_name";
            // 
            // cal_order_id
            // 
            this.cal_order_id.HeaderText = "order_id";
            this.cal_order_id.Name = "cal_order_id";
            // 
            // cal_qty
            // 
            this.cal_qty.HeaderText = "QTY";
            this.cal_qty.Name = "cal_qty";
            this.cal_qty.Width = 60;
            // 
            // cal_cost
            // 
            this.cal_cost.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cal_cost.HeaderText = "Cost";
            this.cal_cost.Name = "cal_cost";
            // 
            // cal_total
            // 
            this.cal_total.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cal_total.HeaderText = "Total";
            this.cal_total.Name = "cal_total";
            this.cal_total.Width = 150;
            // 
            // calkot_print
            // 
            this.calkot_print.HeaderText = "Kot Print";
            this.calkot_print.Name = "calkot_print";
            this.calkot_print.Visible = false;
            // 
            // cbo_home_id
            // 
            this.cbo_home_id.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbo_home_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_home_id.FormattingEnabled = true;
            this.cbo_home_id.Location = new System.Drawing.Point(424, 121);
            this.cbo_home_id.Name = "cbo_home_id";
            this.cbo_home_id.Size = new System.Drawing.Size(236, 24);
            this.cbo_home_id.TabIndex = 0;
            this.cbo_home_id.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.cbo_home_id.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbo_home_id_KeyDown);
            // 
            // txt_total
            // 
            this.txt_total.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_total.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_total.Location = new System.Drawing.Point(663, 413);
            this.txt_total.Name = "txt_total";
            this.txt_total.ReadOnly = true;
            this.txt_total.Size = new System.Drawing.Size(218, 26);
            this.txt_total.TabIndex = 5;
            this.txt_total.Text = "0.00";
            this.txt_total.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_total_KeyDown);
            this.txt_total.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_total_KeyPress);
            // 
            // txt_delivery_charge
            // 
            this.txt_delivery_charge.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_delivery_charge.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_delivery_charge.Location = new System.Drawing.Point(663, 518);
            this.txt_delivery_charge.Name = "txt_delivery_charge";
            this.txt_delivery_charge.Size = new System.Drawing.Size(218, 26);
            this.txt_delivery_charge.TabIndex = 108;
            this.txt_delivery_charge.Text = "0.00";
            this.txt_delivery_charge.TextChanged += new System.EventHandler(this.txt_delivery_charge_TextChanged);
            this.txt_delivery_charge.Enter += new System.EventHandler(this.txt_delivery_charge_Enter);
            this.txt_delivery_charge.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_delivery_charge_KeyDown);
            this.txt_delivery_charge.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_delivery_charge_KeyPress);
            this.txt_delivery_charge.Leave += new System.EventHandler(this.txt_delivery_charge_Leave);
            // 
            // txt_grand_total
            // 
            this.txt_grand_total.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_grand_total.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_grand_total.Location = new System.Drawing.Point(663, 552);
            this.txt_grand_total.Name = "txt_grand_total";
            this.txt_grand_total.ReadOnly = true;
            this.txt_grand_total.Size = new System.Drawing.Size(218, 26);
            this.txt_grand_total.TabIndex = 110;
            this.txt_grand_total.Text = "0.00";
            this.txt_grand_total.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_grand_total_KeyDown);
            this.txt_grand_total.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_grand_total_KeyPress);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 419);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Customer Name";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(17, 451);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Customer Address";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(21, 486);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "Customer Phone";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(561, 588);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Delivery Man";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(567, 416);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "Sub Total";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(526, 518);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 20);
            this.label6.TabIndex = 107;
            this.label6.Text = "Delivery Charge";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(551, 552);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 20);
            this.label7.TabIndex = 109;
            this.label7.Text = "Grand Total";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(418, 94);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 20);
            this.label8.TabIndex = 111;
            this.label8.Text = "KOT ID";
            // 
            // btntable_transfer
            // 
            this.btntable_transfer.Controls.Add(this.txtcashier);
            this.btntable_transfer.Controls.Add(this.label9);
            this.btntable_transfer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btntable_transfer.ForeColor = System.Drawing.Color.Black;
            this.btntable_transfer.Location = new System.Drawing.Point(15, 79);
            this.btntable_transfer.Name = "btntable_transfer";
            this.btntable_transfer.Size = new System.Drawing.Size(177, 78);
            this.btntable_transfer.TabIndex = 283;
            this.btntable_transfer.TabStop = false;
            this.btntable_transfer.Text = "Bill Info";
            this.btntable_transfer.Enter += new System.EventHandler(this.btntable_transfer_Enter);
            // 
            // txtcashier
            // 
            this.txtcashier.FormattingEnabled = true;
            this.txtcashier.Location = new System.Drawing.Point(19, 42);
            this.txtcashier.Name = "txtcashier";
            this.txtcashier.Size = new System.Drawing.Size(147, 24);
            this.txtcashier.TabIndex = 93;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(14, 18);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 15);
            this.label9.TabIndex = 91;
            this.label9.Text = "Cashier";
            // 
            // txt_phone
            // 
            this.txt_phone.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txt_phone.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.txt_phone.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_phone.FormattingEnabled = true;
            this.txt_phone.Location = new System.Drawing.Point(162, 484);
            this.txt_phone.Name = "txt_phone";
            this.txt_phone.Size = new System.Drawing.Size(260, 28);
            this.txt_phone.TabIndex = 288;
            this.txt_phone.SelectedIndexChanged += new System.EventHandler(this.cbo_customer_no_SelectedIndexChanged);
            // 
            // txt_customer
            // 
            this.txt_customer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txt_customer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.txt_customer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_customer.FormattingEnabled = true;
            this.txt_customer.Location = new System.Drawing.Point(163, 417);
            this.txt_customer.Name = "txt_customer";
            this.txt_customer.Size = new System.Drawing.Size(260, 28);
            this.txt_customer.TabIndex = 287;
            this.txt_customer.SelectedIndexChanged += new System.EventHandler(this.cbo_customer_name_SelectedIndexChanged);
            // 
            // btnminus
            // 
            this.btnminus.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnminus.BackColor = System.Drawing.Color.Red;
            this.btnminus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnminus.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnminus.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnminus.Image = global::POS_System.Properties.Resources.minus_symbol;
            this.btnminus.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnminus.Location = new System.Drawing.Point(886, 163);
            this.btnminus.Name = "btnminus";
            this.btnminus.Size = new System.Drawing.Size(126, 60);
            this.btnminus.TabIndex = 291;
            this.btnminus.Text = "Minus";
            this.btnminus.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnminus.UseVisualStyleBackColor = false;
            this.btnminus.Click += new System.EventHandler(this.btnminus_Click);
            // 
            // btnaadd
            // 
            this.btnaadd.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnaadd.BackColor = System.Drawing.Color.Red;
            this.btnaadd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnaadd.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnaadd.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnaadd.Image = global::POS_System.Properties.Resources.alpha;
            this.btnaadd.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnaadd.Location = new System.Drawing.Point(887, 359);
            this.btnaadd.Name = "btnaadd";
            this.btnaadd.Size = new System.Drawing.Size(126, 59);
            this.btnaadd.TabIndex = 290;
            this.btnaadd.Text = "Cancel All";
            this.btnaadd.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnaadd.UseVisualStyleBackColor = false;
            this.btnaadd.Click += new System.EventHandler(this.btnaadd_Click);
            // 
            // button3
            // 
            this.button3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button3.BackColor = System.Drawing.Color.Red;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button3.Image = global::POS_System.Properties.Resources.delete;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button3.Location = new System.Drawing.Point(887, 295);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(126, 58);
            this.button3.TabIndex = 289;
            this.button3.Text = "Cancel";
            this.button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // txt_discount
            // 
            this.txt_discount.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_discount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_discount.Location = new System.Drawing.Point(663, 446);
            this.txt_discount.Name = "txt_discount";
            this.txt_discount.Size = new System.Drawing.Size(218, 26);
            this.txt_discount.TabIndex = 293;
            this.txt_discount.Text = "0.00";
            this.txt_discount.TextChanged += new System.EventHandler(this.txt_discount_TextChanged);
            this.txt_discount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_discount_KeyPress);
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(571, 448);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 20);
            this.label10.TabIndex = 292;
            this.label10.Text = "Discount";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // btn_save
            // 
            this.btn_save.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_save.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btn_save.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save.Location = new System.Drawing.Point(907, 577);
            this.btn_save.Name = "btn_save";
            this.btn_save.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(14);
            this.btn_save.Size = new System.Drawing.Size(97, 41);
            this.btn_save.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_save.Symbol = "";
            this.btn_save.TabIndex = 294;
            this.btn_save.Text = "Send";
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // txt_tax_amount
            // 
            this.txt_tax_amount.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_tax_amount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_tax_amount.Location = new System.Drawing.Point(663, 481);
            this.txt_tax_amount.Name = "txt_tax_amount";
            this.txt_tax_amount.ReadOnly = true;
            this.txt_tax_amount.Size = new System.Drawing.Size(218, 26);
            this.txt_tax_amount.TabIndex = 296;
            this.txt_tax_amount.Text = "0.00";
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(609, 481);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(34, 20);
            this.label12.TabIndex = 295;
            this.label12.Text = "Tax";
            // 
            // btn_add
            // 
            this.btn_add.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_add.BackColor = System.Drawing.Color.Red;
            this.btn_add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_add.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_add.Image = global::POS_System.Properties.Resources.add139;
            this.btn_add.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_add.Location = new System.Drawing.Point(887, 229);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(126, 60);
            this.btn_add.TabIndex = 297;
            this.btn_add.Text = "Add Item";
            this.btn_add.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_add.UseVisualStyleBackColor = false;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // rbtn_cash
            // 
            this.rbtn_cash.AutoSize = true;
            this.rbtn_cash.Checked = true;
            this.rbtn_cash.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtn_cash.Location = new System.Drawing.Point(34, 569);
            this.rbtn_cash.Name = "rbtn_cash";
            this.rbtn_cash.Size = new System.Drawing.Size(77, 29);
            this.rbtn_cash.TabIndex = 284;
            this.rbtn_cash.TabStop = true;
            this.rbtn_cash.Text = "Cash";
            this.rbtn_cash.UseVisualStyleBackColor = true;
            // 
            // rbtn_card
            // 
            this.rbtn_card.AutoSize = true;
            this.rbtn_card.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtn_card.Location = new System.Drawing.Point(142, 570);
            this.rbtn_card.Name = "rbtn_card";
            this.rbtn_card.Size = new System.Drawing.Size(73, 29);
            this.rbtn_card.TabIndex = 285;
            this.rbtn_card.TabStop = true;
            this.rbtn_card.Text = "Card";
            this.rbtn_card.UseVisualStyleBackColor = true;
            // 
            // rbtn_zomato_pre_paid
            // 
            this.rbtn_zomato_pre_paid.AutoSize = true;
            this.rbtn_zomato_pre_paid.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtn_zomato_pre_paid.Location = new System.Drawing.Point(34, 598);
            this.rbtn_zomato_pre_paid.Name = "rbtn_zomato_pre_paid";
            this.rbtn_zomato_pre_paid.Size = new System.Drawing.Size(186, 30);
            this.rbtn_zomato_pre_paid.TabIndex = 286;
            this.rbtn_zomato_pre_paid.TabStop = true;
            this.rbtn_zomato_pre_paid.Text = "Online Payment";
            this.rbtn_zomato_pre_paid.UseVisualStyleBackColor = true;
            // 
            // home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1012, 641);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.txt_tax_amount);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.txt_discount);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnminus);
            this.Controls.Add(this.btnaadd);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.txt_phone);
            this.Controls.Add(this.txt_customer);
            this.Controls.Add(this.rbtn_zomato_pre_paid);
            this.Controls.Add(this.rbtn_card);
            this.Controls.Add(this.rbtn_cash);
            this.Controls.Add(this.btntable_transfer);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txt_grand_total);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txt_delivery_charge);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbo_home_id);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.txt_adress);
            this.Controls.Add(this.txt_total);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbo_delivery);
            this.Controls.Add(this.label1);
            this.Name = "home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home Delivery";
            this.Load += new System.EventHandler(this.usercontrol_home_delivery_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.btntable_transfer.ResumeLayout(false);
            this.btntable_transfer.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cbo_delivery;
        private System.Windows.Forms.TextBox txt_adress;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txt_total;
        private System.Windows.Forms.TextBox txt_delivery_charge;
        private System.Windows.Forms.TextBox txt_grand_total;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox btntable_transfer;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox txtcashier;
        private System.Windows.Forms.ComboBox txt_phone;
        private System.Windows.Forms.ComboBox txt_customer;
        private System.Windows.Forms.Button btnminus;
        private System.Windows.Forms.Button btnaadd;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox txt_discount;
        private System.Windows.Forms.Label label10;
        private DevComponents.DotNetBar.ButtonX btn_save;
        private System.Windows.Forms.TextBox txt_tax_amount;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_item_category;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_item_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_order_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_cost;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_total;
        private System.Windows.Forms.DataGridViewTextBoxColumn calkot_print;
        public System.Windows.Forms.ComboBox cbo_home_id;
        private System.Windows.Forms.RadioButton rbtn_zomato_pre_paid;
        private System.Windows.Forms.RadioButton rbtn_card;
        private System.Windows.Forms.RadioButton rbtn_cash;
    }
}
