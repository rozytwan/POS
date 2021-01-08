namespace POS_System
{
    partial class AdvanceDiscount
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cal_item_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_discount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Calckeck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cal_category_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_order_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_item_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_estimate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_kot_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbl_discount = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbl_estimate = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.pnlHotDiscount = new System.Windows.Forms.FlowLayoutPanel();
            this.switch_discount_checker = new DevExpress.XtraEditors.ToggleSwitch();
            this.lbl_total_discount = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btn_close = new DevComponents.DotNetBar.ButtonX();
            this.lbl_total = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_ok = new DevComponents.DotNetBar.ButtonX();
            this.txt_discount_percent = new System.Windows.Forms.TextBox();
            this.txt_discount_amount = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.rbtn_k1 = new System.Windows.Forms.RadioButton();
            this.rbtn_all = new System.Windows.Forms.RadioButton();
            this.rbtn_bot = new System.Windows.Forms.RadioButton();
            this.rbtn_k2 = new System.Windows.Forms.RadioButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.switch_discount_checker.Properties)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Location = new System.Drawing.Point(0, 79);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(392, 593);
            this.panel1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cal_item_name,
            this.col_discount,
            this.Calckeck,
            this.cal_category_name,
            this.cal_order_id,
            this.col_item_id,
            this.cal_qty,
            this.cal_cost,
            this.cal_total,
            this.col_estimate,
            this.cal_kot_type});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Location = new System.Drawing.Point(5, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.dataGridView1.RowTemplate.Height = 35;
            this.dataGridView1.Size = new System.Drawing.Size(382, 587);
            this.dataGridView1.TabIndex = 282;
            // 
            // cal_item_name
            // 
            this.cal_item_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cal_item_name.FillWeight = 150F;
            this.cal_item_name.HeaderText = "Item Name";
            this.cal_item_name.Name = "cal_item_name";
            this.cal_item_name.ReadOnly = true;
            this.cal_item_name.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // col_discount
            // 
            this.col_discount.HeaderText = "Discount";
            this.col_discount.Name = "col_discount";
            this.col_discount.ReadOnly = true;
            this.col_discount.Visible = false;
            // 
            // Calckeck
            // 
            this.Calckeck.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Calckeck.HeaderText = "CheckBox";
            this.Calckeck.Name = "Calckeck";
            this.Calckeck.ReadOnly = true;
            this.Calckeck.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Calckeck.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Calckeck.Visible = false;
            // 
            // cal_category_name
            // 
            this.cal_category_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cal_category_name.HeaderText = "Category Name";
            this.cal_category_name.Name = "cal_category_name";
            this.cal_category_name.ReadOnly = true;
            this.cal_category_name.Visible = false;
            // 
            // cal_order_id
            // 
            this.cal_order_id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cal_order_id.HeaderText = "order_id";
            this.cal_order_id.Name = "cal_order_id";
            this.cal_order_id.ReadOnly = true;
            this.cal_order_id.Visible = false;
            // 
            // col_item_id
            // 
            this.col_item_id.HeaderText = "item id";
            this.col_item_id.Name = "col_item_id";
            this.col_item_id.ReadOnly = true;
            this.col_item_id.Visible = false;
            // 
            // cal_qty
            // 
            this.cal_qty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cal_qty.FillWeight = 50F;
            this.cal_qty.HeaderText = "QTY";
            this.cal_qty.Name = "cal_qty";
            this.cal_qty.ReadOnly = true;
            // 
            // cal_cost
            // 
            this.cal_cost.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cal_cost.FillWeight = 80F;
            this.cal_cost.HeaderText = "Cost";
            this.cal_cost.Name = "cal_cost";
            this.cal_cost.ReadOnly = true;
            // 
            // cal_total
            // 
            this.cal_total.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cal_total.HeaderText = "Total";
            this.cal_total.Name = "cal_total";
            this.cal_total.ReadOnly = true;
            // 
            // col_estimate
            // 
            this.col_estimate.HeaderText = "Estimate cost";
            this.col_estimate.Name = "col_estimate";
            this.col_estimate.ReadOnly = true;
            this.col_estimate.Visible = false;
            // 
            // cal_kot_type
            // 
            this.cal_kot_type.HeaderText = "Kot Type";
            this.cal_kot_type.Name = "cal_kot_type";
            this.cal_kot_type.ReadOnly = true;
            this.cal_kot_type.Visible = false;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lbl_discount);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.lbl_estimate);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.pnlHotDiscount);
            this.panel2.Controls.Add(this.switch_discount_checker);
            this.panel2.Controls.Add(this.lbl_total_discount);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.btn_close);
            this.panel2.Controls.Add(this.lbl_total);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.btn_ok);
            this.panel2.Controls.Add(this.txt_discount_percent);
            this.panel2.Controls.Add(this.txt_discount_amount);
            this.panel2.Location = new System.Drawing.Point(392, 83);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(594, 384);
            this.panel2.TabIndex = 2;
            // 
            // lbl_discount
            // 
            this.lbl_discount.AutoSize = true;
            this.lbl_discount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_discount.Location = new System.Drawing.Point(187, 212);
            this.lbl_discount.Name = "lbl_discount";
            this.lbl_discount.Size = new System.Drawing.Size(45, 24);
            this.lbl_discount.TabIndex = 288;
            this.lbl_discount.Text = "0.00";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Gray;
            this.label8.Location = new System.Drawing.Point(1, 212);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(186, 24);
            this.label8.TabIndex = 287;
            this.label8.Text = "Calculated Discount :";
            // 
            // lbl_estimate
            // 
            this.lbl_estimate.AutoSize = true;
            this.lbl_estimate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_estimate.Location = new System.Drawing.Point(147, 188);
            this.lbl_estimate.Name = "lbl_estimate";
            this.lbl_estimate.Size = new System.Drawing.Size(45, 24);
            this.lbl_estimate.TabIndex = 286;
            this.lbl_estimate.Text = "0.00";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Gray;
            this.label12.Location = new System.Drawing.Point(1, 188);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(149, 24);
            this.label12.TabIndex = 285;
            this.label12.Text = " Estimated Cost :";
            // 
            // pnlHotDiscount
            // 
            this.pnlHotDiscount.Location = new System.Drawing.Point(321, 6);
            this.pnlHotDiscount.Name = "pnlHotDiscount";
            this.pnlHotDiscount.Size = new System.Drawing.Size(259, 359);
            this.pnlHotDiscount.TabIndex = 284;
            // 
            // switch_discount_checker
            // 
            this.switch_discount_checker.EditValue = true;
            this.switch_discount_checker.Location = new System.Drawing.Point(6, 25);
            this.switch_discount_checker.Name = "switch_discount_checker";
            this.switch_discount_checker.Properties.OffText = "Amount";
            this.switch_discount_checker.Properties.OnText = "Percent";
            this.switch_discount_checker.Properties.Click += new System.EventHandler(this.toggleSwitch1_Properties_Click);
            this.switch_discount_checker.Size = new System.Drawing.Size(131, 24);
            this.switch_discount_checker.TabIndex = 283;
            // 
            // lbl_total_discount
            // 
            this.lbl_total_discount.AutoSize = true;
            this.lbl_total_discount.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_total_discount.Location = new System.Drawing.Point(199, 290);
            this.lbl_total_discount.Name = "lbl_total_discount";
            this.lbl_total_discount.Size = new System.Drawing.Size(62, 29);
            this.lbl_total_discount.TabIndex = 281;
            this.lbl_total_discount.Text = "0.00";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(3, 290);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(195, 29);
            this.label7.TabIndex = 282;
            this.label7.Text = "Total Discount :";
            // 
            // btn_close
            // 
            this.btn_close.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_close.BackColor = System.Drawing.Color.Transparent;
            this.btn_close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_close.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_close.Location = new System.Drawing.Point(163, 328);
            this.btn_close.Name = "btn_close";
            this.btn_close.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(15);
            this.btn_close.Size = new System.Drawing.Size(142, 50);
            this.btn_close.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2010;
            this.btn_close.Symbol = "";
            this.btn_close.TabIndex = 279;
            this.btn_close.Text = "Close";
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // lbl_total
            // 
            this.lbl_total.AutoSize = true;
            this.lbl_total.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_total.Location = new System.Drawing.Point(104, 247);
            this.lbl_total.Name = "lbl_total";
            this.lbl_total.Size = new System.Drawing.Size(71, 31);
            this.lbl_total.TabIndex = 1;
            this.lbl_total.Text = "0.00";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 247);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 31);
            this.label5.TabIndex = 1;
            this.label5.Text = "Total :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(7, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 20);
            this.label4.TabIndex = 274;
            this.label4.Text = "Discount %";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 20);
            this.label3.TabIndex = 273;
            this.label3.Text = "Discount Amount";
            // 
            // btn_ok
            // 
            this.btn_ok.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_ok.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btn_ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_ok.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ok.Location = new System.Drawing.Point(13, 328);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(15);
            this.btn_ok.Size = new System.Drawing.Size(142, 50);
            this.btn_ok.Symbol = "";
            this.btn_ok.TabIndex = 272;
            this.btn_ok.Text = "OK";
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // txt_discount_percent
            // 
            this.txt_discount_percent.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_discount_percent.Location = new System.Drawing.Point(5, 150);
            this.txt_discount_percent.Name = "txt_discount_percent";
            this.txt_discount_percent.Size = new System.Drawing.Size(170, 35);
            this.txt_discount_percent.TabIndex = 1;
            this.txt_discount_percent.Text = "0.00";
            this.txt_discount_percent.TextChanged += new System.EventHandler(this.txt_discount_percent_TextChanged);
            this.txt_discount_percent.Enter += new System.EventHandler(this.txt_discount_percent_Enter);
            this.txt_discount_percent.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_discount_percent_KeyPress);
            this.txt_discount_percent.Leave += new System.EventHandler(this.txt_discount_percent_Leave);
            // 
            // txt_discount_amount
            // 
            this.txt_discount_amount.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_discount_amount.Location = new System.Drawing.Point(5, 81);
            this.txt_discount_amount.Name = "txt_discount_amount";
            this.txt_discount_amount.ReadOnly = true;
            this.txt_discount_amount.Size = new System.Drawing.Size(170, 35);
            this.txt_discount_amount.TabIndex = 0;
            this.txt_discount_amount.Text = "0.00";
            this.txt_discount_amount.TextChanged += new System.EventHandler(this.txt_discount_amount_TextChanged);
            this.txt_discount_amount.Enter += new System.EventHandler(this.txt_discount_amount_Enter);
            this.txt_discount_amount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_discount_amount_KeyPress);
            this.txt_discount_amount.Leave += new System.EventHandler(this.txt_discount_amount_Leave);
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.rbtn_k1);
            this.panel5.Controls.Add(this.rbtn_all);
            this.panel5.Controls.Add(this.rbtn_bot);
            this.panel5.Controls.Add(this.rbtn_k2);
            this.panel5.Location = new System.Drawing.Point(392, 468);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(257, 204);
            this.panel5.TabIndex = 280;
            // 
            // rbtn_k1
            // 
            this.rbtn_k1.AutoSize = true;
            this.rbtn_k1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtn_k1.Location = new System.Drawing.Point(44, 69);
            this.rbtn_k1.Name = "rbtn_k1";
            this.rbtn_k1.Size = new System.Drawing.Size(50, 28);
            this.rbtn_k1.TabIndex = 276;
            this.rbtn_k1.Text = "K1";
            this.rbtn_k1.UseVisualStyleBackColor = true;
            this.rbtn_k1.Click += new System.EventHandler(this.radioButton2_Click);
            // 
            // rbtn_all
            // 
            this.rbtn_all.AutoSize = true;
            this.rbtn_all.Checked = true;
            this.rbtn_all.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtn_all.Location = new System.Drawing.Point(44, 25);
            this.rbtn_all.Name = "rbtn_all";
            this.rbtn_all.Size = new System.Drawing.Size(61, 28);
            this.rbtn_all.TabIndex = 275;
            this.rbtn_all.TabStop = true;
            this.rbtn_all.Text = "ALL";
            this.rbtn_all.UseVisualStyleBackColor = true;
            this.rbtn_all.Click += new System.EventHandler(this.radioButton1_Click);
            // 
            // rbtn_bot
            // 
            this.rbtn_bot.AutoSize = true;
            this.rbtn_bot.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtn_bot.Location = new System.Drawing.Point(44, 157);
            this.rbtn_bot.Name = "rbtn_bot";
            this.rbtn_bot.Size = new System.Drawing.Size(67, 28);
            this.rbtn_bot.TabIndex = 278;
            this.rbtn_bot.Text = "BOT";
            this.rbtn_bot.UseVisualStyleBackColor = true;
            this.rbtn_bot.Click += new System.EventHandler(this.radioButton4_Click);
            // 
            // rbtn_k2
            // 
            this.rbtn_k2.AutoSize = true;
            this.rbtn_k2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtn_k2.Location = new System.Drawing.Point(44, 113);
            this.rbtn_k2.Name = "rbtn_k2";
            this.rbtn_k2.Size = new System.Drawing.Size(50, 28);
            this.rbtn_k2.TabIndex = 277;
            this.rbtn_k2.Text = "K2";
            this.rbtn_k2.UseVisualStyleBackColor = true;
            this.rbtn_k2.Click += new System.EventHandler(this.radioButton3_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(81)))), ((int)(((byte)(126)))));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(392, 1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(594, 82);
            this.panel3.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(185, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(250, 31);
            this.label2.TabIndex = 1;
            this.label2.Text = "Advance Discount";
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.label1);
            this.panel4.Location = new System.Drawing.Point(0, 1);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(392, 81);
            this.panel4.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(93, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Items";
            // 
            // AdvanceDiscount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(985, 674);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AdvanceDiscount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdvanceDiscount";
            this.Load += new System.EventHandler(this.AdvanceDiscount_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.switch_discount_checker.Properties)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private DevComponents.DotNetBar.ButtonX btn_ok;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_total;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton rbtn_bot;
        private System.Windows.Forms.RadioButton rbtn_k2;
        private System.Windows.Forms.RadioButton rbtn_k1;
        private System.Windows.Forms.RadioButton rbtn_all;
        private DevComponents.DotNetBar.ButtonX btn_close;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lbl_total_discount;
        private System.Windows.Forms.Label label7;
        private DevExpress.XtraEditors.ToggleSwitch switch_discount_checker;
        public System.Windows.Forms.TextBox txt_discount_percent;
        public System.Windows.Forms.TextBox txt_discount_amount;
        private System.Windows.Forms.FlowLayoutPanel pnlHotDiscount;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lbl_estimate;
        private System.Windows.Forms.Label lbl_discount;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_item_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_discount;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Calckeck;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_category_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_order_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_item_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_cost;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_total;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_estimate;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_kot_type;
    }
}