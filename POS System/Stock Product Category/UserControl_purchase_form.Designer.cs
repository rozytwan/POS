﻿namespace POS_System
{
    partial class UserControl_purchase_form
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
            this.txt_tax_amount = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.Total = new System.Windows.Forms.Label();
            this.txttotal = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.calcategoryid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_purchaseid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_bill_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calproductid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calcategoryname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calproductname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calprice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calquantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.caltotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calexpirydate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calponno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calpurchase_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calsupplier_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_remove = new DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn();
            this.cal_static_qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label9 = new System.Windows.Forms.Label();
            this.txtdiscount = new System.Windows.Forms.TextBox();
            this.lblmsg = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtgrandtotal = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btn_back = new System.Windows.Forms.Button();
            this.label23 = new System.Windows.Forms.Label();
            this.btncalculateamount = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.cboreceived_by = new System.Windows.Forms.ComboBox();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.btnadd = new DevComponents.DotNetBar.ButtonX();
            this.label13 = new System.Windows.Forms.Label();
            this.txtsingletotal = new System.Windows.Forms.TextBox();
            this.cbo_unit = new System.Windows.Forms.ComboBox();
            this.label25 = new System.Windows.Forms.Label();
            this.dtpexpirydate = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.cbocategorynamess = new System.Windows.Forms.ComboBox();
            this.cboproductname = new System.Windows.Forms.ComboBox();
            this.txtquanitity = new System.Windows.Forms.TextBox();
            this.txtprice = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            this.label12 = new System.Windows.Forms.Label();
            this.cbopono = new System.Windows.Forms.ComboBox();
            this.txt_bill_no = new System.Windows.Forms.TextBox();
            this.lblPOno = new System.Windows.Forms.Label();
            this.txtcustomername = new System.Windows.Forms.ComboBox();
            this.txtinvoicedate = new System.Windows.Forms.Label();
            this.txtinvoiceno = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnsave = new DevComponents.DotNetBar.ButtonX();
            this.btn_edit = new DevComponents.DotNetBar.ButtonX();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panelEx1.SuspendLayout();
            this.panelEx2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_tax_amount
            // 
            this.txt_tax_amount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_tax_amount.Location = new System.Drawing.Point(96, 676);
            this.txt_tax_amount.Name = "txt_tax_amount";
            this.txt_tax_amount.Size = new System.Drawing.Size(180, 26);
            this.txt_tax_amount.TabIndex = 6;
            this.txt_tax_amount.Text = "0.00";
            this.txt_tax_amount.TextChanged += new System.EventHandler(this.txt_tax_amount_TextChanged);
            this.txt_tax_amount.Enter += new System.EventHandler(this.txtpaidamount_Enter);
            this.txt_tax_amount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtpaidamount_KeyDown);
            this.txt_tax_amount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpaidamount_KeyPress);
            this.txt_tax_amount.Leave += new System.EventHandler(this.txtpaidamount_Leave);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(52, 682);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(39, 17);
            this.label11.TabIndex = 87;
            this.label11.Text = "Tax :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Lime;
            this.label8.Location = new System.Drawing.Point(64, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(157, 31);
            this.label8.TabIndex = 85;
            this.label8.Text = "Grand Total";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // Total
            // 
            this.Total.AutoSize = true;
            this.Total.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Total.Location = new System.Drawing.Point(14, 611);
            this.Total.Name = "Total";
            this.Total.Size = new System.Drawing.Size(77, 17);
            this.Total.TabIndex = 83;
            this.Total.Text = "Sub Total :";
            // 
            // txttotal
            // 
            this.txttotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttotal.Location = new System.Drawing.Point(97, 611);
            this.txttotal.Name = "txttotal";
            this.txttotal.Size = new System.Drawing.Size(180, 26);
            this.txttotal.TabIndex = 9;
            this.txttotal.Text = "0.00";
            this.txttotal.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txttotal_KeyDown);
            this.txttotal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txttotal_KeyPress);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.calcategoryid,
            this.col_purchaseid,
            this.cal_bill_no,
            this.calproductid,
            this.calcategoryname,
            this.calproductname,
            this.calprice,
            this.cal_unit,
            this.calquantity,
            this.caltotal,
            this.calexpirydate,
            this.calponno,
            this.calpurchase_date,
            this.calsupplier_name,
            this.cal_remove,
            this.cal_static_qty});
            this.dataGridView1.Location = new System.Drawing.Point(2, 285);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(991, 318);
            this.dataGridView1.TabIndex = 12;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.Click += new System.EventHandler(this.btnremove_Click);
            // 
            // calcategoryid
            // 
            this.calcategoryid.HeaderText = "Category ID";
            this.calcategoryid.Name = "calcategoryid";
            this.calcategoryid.ReadOnly = true;
            this.calcategoryid.Visible = false;
            // 
            // col_purchaseid
            // 
            this.col_purchaseid.HeaderText = "Purchase_id";
            this.col_purchaseid.Name = "col_purchaseid";
            this.col_purchaseid.ReadOnly = true;
            this.col_purchaseid.Visible = false;
            // 
            // cal_bill_no
            // 
            this.cal_bill_no.HeaderText = "Bill No";
            this.cal_bill_no.Name = "cal_bill_no";
            this.cal_bill_no.ReadOnly = true;
            this.cal_bill_no.Width = 80;
            // 
            // calproductid
            // 
            this.calproductid.HeaderText = "Procudt ID";
            this.calproductid.Name = "calproductid";
            this.calproductid.ReadOnly = true;
            this.calproductid.Visible = false;
            // 
            // calcategoryname
            // 
            this.calcategoryname.HeaderText = "Category Name";
            this.calcategoryname.Name = "calcategoryname";
            this.calcategoryname.ReadOnly = true;
            this.calcategoryname.Width = 150;
            // 
            // calproductname
            // 
            this.calproductname.HeaderText = "Product Name";
            this.calproductname.Name = "calproductname";
            this.calproductname.ReadOnly = true;
            this.calproductname.Width = 150;
            // 
            // calprice
            // 
            this.calprice.HeaderText = "Price";
            this.calprice.Name = "calprice";
            this.calprice.ReadOnly = true;
            this.calprice.Width = 70;
            // 
            // cal_unit
            // 
            this.cal_unit.HeaderText = "Unit";
            this.cal_unit.Name = "cal_unit";
            this.cal_unit.ReadOnly = true;
            this.cal_unit.Width = 70;
            // 
            // calquantity
            // 
            this.calquantity.HeaderText = "Quantity";
            this.calquantity.Name = "calquantity";
            this.calquantity.ReadOnly = true;
            this.calquantity.Width = 50;
            // 
            // caltotal
            // 
            this.caltotal.HeaderText = "Total";
            this.caltotal.Name = "caltotal";
            this.caltotal.ReadOnly = true;
            // 
            // calexpirydate
            // 
            this.calexpirydate.HeaderText = "Expiry Date";
            this.calexpirydate.Name = "calexpirydate";
            this.calexpirydate.ReadOnly = true;
            // 
            // calponno
            // 
            this.calponno.HeaderText = "PO NO";
            this.calponno.Name = "calponno";
            this.calponno.ReadOnly = true;
            this.calponno.Visible = false;
            this.calponno.Width = 70;
            // 
            // calpurchase_date
            // 
            this.calpurchase_date.HeaderText = "Purchase Date";
            this.calpurchase_date.Name = "calpurchase_date";
            this.calpurchase_date.ReadOnly = true;
            this.calpurchase_date.Visible = false;
            this.calpurchase_date.Width = 70;
            // 
            // calsupplier_name
            // 
            this.calsupplier_name.HeaderText = "Supplier Name";
            this.calsupplier_name.Name = "calsupplier_name";
            this.calsupplier_name.ReadOnly = true;
            // 
            // cal_remove
            // 
            this.cal_remove.HeaderText = "Remove";
            this.cal_remove.Name = "cal_remove";
            this.cal_remove.ReadOnly = true;
            this.cal_remove.Text = "Remove";
            this.cal_remove.UseColumnTextForButtonValue = true;
            // 
            // cal_static_qty
            // 
            this.cal_static_qty.HeaderText = "static_qty";
            this.cal_static_qty.Name = "cal_static_qty";
            this.cal_static_qty.ReadOnly = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(23, 645);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 17);
            this.label9.TabIndex = 80;
            this.label9.Text = "Discount :";
            // 
            // txtdiscount
            // 
            this.txtdiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdiscount.Location = new System.Drawing.Point(97, 643);
            this.txtdiscount.Name = "txtdiscount";
            this.txtdiscount.Size = new System.Drawing.Size(180, 26);
            this.txtdiscount.TabIndex = 5;
            this.txtdiscount.Text = "0.00";
            this.txtdiscount.TextChanged += new System.EventHandler(this.txtdiscount_TextChanged);
            this.txtdiscount.Enter += new System.EventHandler(this.txtdiscount_Enter);
            this.txtdiscount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtdiscount_KeyPress);
            this.txtdiscount.Leave += new System.EventHandler(this.txtdiscount_Leave);
            // 
            // lblmsg
            // 
            this.lblmsg.AutoSize = true;
            this.lblmsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblmsg.ForeColor = System.Drawing.Color.Red;
            this.lblmsg.Location = new System.Drawing.Point(40, 719);
            this.lblmsg.Name = "lblmsg";
            this.lblmsg.Size = new System.Drawing.Size(17, 20);
            this.lblmsg.TabIndex = 89;
            this.lblmsg.Text = "..";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.txtgrandtotal);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Location = new System.Drawing.Point(677, 609);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(316, 108);
            this.panel1.TabIndex = 90;
            // 
            // txtgrandtotal
            // 
            this.txtgrandtotal.AutoSize = true;
            this.txtgrandtotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtgrandtotal.ForeColor = System.Drawing.Color.Lime;
            this.txtgrandtotal.Location = new System.Drawing.Point(113, 54);
            this.txtgrandtotal.Name = "txtgrandtotal";
            this.txtgrandtotal.Size = new System.Drawing.Size(58, 29);
            this.txtgrandtotal.TabIndex = 86;
            this.txtgrandtotal.Text = "0.00";
            this.txtgrandtotal.Click += new System.EventHandler(this.txtgrandtotal_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(81)))), ((int)(((byte)(126)))));
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.btn_back);
            this.panel2.Controls.Add(this.label23);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(995, 71);
            this.panel2.TabIndex = 101;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::POS_System.Properties.Resources.circle;
            this.pictureBox2.Location = new System.Drawing.Point(329, 6);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(69, 62);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 27;
            this.pictureBox2.TabStop = false;
            // 
            // btn_back
            // 
            this.btn_back.FlatAppearance.BorderSize = 0;
            this.btn_back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_back.Image = global::POS_System.Properties.Resources.back36;
            this.btn_back.Location = new System.Drawing.Point(0, 2);
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
            this.label23.Location = new System.Drawing.Point(399, 18);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(337, 39);
            this.label23.TabIndex = 18;
            this.label23.Text = "Purchase Entry Form";
            // 
            // btncalculateamount
            // 
            this.btncalculateamount.BackColor = System.Drawing.Color.Red;
            this.btncalculateamount.FlatAppearance.BorderSize = 0;
            this.btncalculateamount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btncalculateamount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncalculateamount.ForeColor = System.Drawing.Color.White;
            this.btncalculateamount.Image = global::POS_System.Properties.Resources.plus94;
            this.btncalculateamount.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btncalculateamount.Location = new System.Drawing.Point(542, 664);
            this.btncalculateamount.Name = "btncalculateamount";
            this.btncalculateamount.Size = new System.Drawing.Size(117, 42);
            this.btncalculateamount.TabIndex = 7;
            this.btncalculateamount.Text = "Reset";
            this.btncalculateamount.UseVisualStyleBackColor = false;
            this.btncalculateamount.Click += new System.EventHandler(this.btncalculateamount_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(304, 620);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(95, 17);
            this.label14.TabIndex = 112;
            this.label14.Text = "Received By :";
            // 
            // cboreceived_by
            // 
            this.cboreceived_by.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboreceived_by.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboreceived_by.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboreceived_by.FormattingEnabled = true;
            this.cboreceived_by.Location = new System.Drawing.Point(406, 611);
            this.cboreceived_by.Name = "cboreceived_by";
            this.cboreceived_by.Size = new System.Drawing.Size(240, 28);
            this.cboreceived_by.TabIndex = 128;
            // 
            // panelEx1
            // 
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.btnadd);
            this.panelEx1.Controls.Add(this.label13);
            this.panelEx1.Controls.Add(this.txtsingletotal);
            this.panelEx1.Controls.Add(this.cbo_unit);
            this.panelEx1.Controls.Add(this.label25);
            this.panelEx1.Controls.Add(this.dtpexpirydate);
            this.panelEx1.Controls.Add(this.label10);
            this.panelEx1.Controls.Add(this.cbocategorynamess);
            this.panelEx1.Controls.Add(this.cboproductname);
            this.panelEx1.Controls.Add(this.txtquanitity);
            this.panelEx1.Controls.Add(this.txtprice);
            this.panelEx1.Controls.Add(this.label7);
            this.panelEx1.Controls.Add(this.label6);
            this.panelEx1.Controls.Add(this.label3);
            this.panelEx1.Controls.Add(this.label5);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Location = new System.Drawing.Point(14, 170);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(987, 115);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.Color = System.Drawing.Color.White;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.DoubleLine;
            this.panelEx1.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panelEx1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 132;
            this.panelEx1.Click += new System.EventHandler(this.btnadd_Click_1);
            // 
            // btnadd
            // 
            this.btnadd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnadd.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btnadd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnadd.Location = new System.Drawing.Point(713, 74);
            this.btnadd.Name = "btnadd";
            this.btnadd.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(12);
            this.btnadd.Size = new System.Drawing.Size(103, 30);
            this.btnadd.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnadd.Symbol = "";
            this.btnadd.TabIndex = 144;
            this.btnadd.Text = "Add";
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click_1);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(60, 78);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(48, 17);
            this.label13.TabIndex = 143;
            this.label13.Text = "Total :";
            // 
            // txtsingletotal
            // 
            this.txtsingletotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsingletotal.Location = new System.Drawing.Point(118, 74);
            this.txtsingletotal.Name = "txtsingletotal";
            this.txtsingletotal.ReadOnly = true;
            this.txtsingletotal.Size = new System.Drawing.Size(263, 26);
            this.txtsingletotal.TabIndex = 142;
            // 
            // cbo_unit
            // 
            this.cbo_unit.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbo_unit.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbo_unit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_unit.FormattingEnabled = true;
            this.cbo_unit.Location = new System.Drawing.Point(396, 43);
            this.cbo_unit.Name = "cbo_unit";
            this.cbo_unit.Size = new System.Drawing.Size(201, 28);
            this.cbo_unit.Sorted = true;
            this.cbo_unit.TabIndex = 130;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(344, 45);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(41, 17);
            this.label25.TabIndex = 141;
            this.label25.Text = "Unit :";
            // 
            // dtpexpirydate
            // 
            this.dtpexpirydate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpexpirydate.Location = new System.Drawing.Point(713, 7);
            this.dtpexpirydate.Name = "dtpexpirydate";
            this.dtpexpirydate.Size = new System.Drawing.Size(235, 23);
            this.dtpexpirydate.TabIndex = 134;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(619, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(88, 17);
            this.label10.TabIndex = 140;
            this.label10.Text = "Expiry Date :";
            // 
            // cbocategorynamess
            // 
            this.cbocategorynamess.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbocategorynamess.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbocategorynamess.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbocategorynamess.FormattingEnabled = true;
            this.cbocategorynamess.Location = new System.Drawing.Point(118, 7);
            this.cbocategorynamess.Name = "cbocategorynamess";
            this.cbocategorynamess.Size = new System.Drawing.Size(197, 28);
            this.cbocategorynamess.TabIndex = 128;
            this.cbocategorynamess.SelectedIndexChanged += new System.EventHandler(this.cbocategorynamess_SelectedIndexChanged);
            this.cbocategorynamess.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbocategorynamess_KeyDown);
            // 
            // cboproductname
            // 
            this.cboproductname.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboproductname.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboproductname.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboproductname.FormattingEnabled = true;
            this.cboproductname.Location = new System.Drawing.Point(396, 8);
            this.cboproductname.Name = "cboproductname";
            this.cboproductname.Size = new System.Drawing.Size(201, 28);
            this.cboproductname.TabIndex = 129;
            this.cboproductname.SelectedIndexChanged += new System.EventHandler(this.cboproductname_SelectedIndexChanged);
            // 
            // txtquanitity
            // 
            this.txtquanitity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtquanitity.Location = new System.Drawing.Point(118, 40);
            this.txtquanitity.Name = "txtquanitity";
            this.txtquanitity.Size = new System.Drawing.Size(195, 26);
            this.txtquanitity.TabIndex = 131;
            this.txtquanitity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtquanitity_KeyPress);
            // 
            // txtprice
            // 
            this.txtprice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtprice.Location = new System.Drawing.Point(713, 43);
            this.txtprice.Name = "txtprice";
            this.txtprice.Size = new System.Drawing.Size(241, 26);
            this.txtprice.TabIndex = 135;
            this.txtprice.TextChanged += new System.EventHandler(this.txtprice_TextChanged);
            this.txtprice.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtprice_KeyDown);
            this.txtprice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtprice_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(42, 40);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 17);
            this.label7.TabIndex = 139;
            this.label7.Text = "Quantity :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(657, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 17);
            this.label6.TabIndex = 138;
            this.label6.Text = "Price :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(323, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 17);
            this.label3.TabIndex = 136;
            this.label3.Text = "Product :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(38, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 17);
            this.label5.TabIndex = 137;
            this.label5.Text = "Catagory :";
            // 
            // panelEx2
            // 
            this.panelEx2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx2.Controls.Add(this.label12);
            this.panelEx2.Controls.Add(this.cbopono);
            this.panelEx2.Controls.Add(this.txt_bill_no);
            this.panelEx2.Controls.Add(this.lblPOno);
            this.panelEx2.Controls.Add(this.txtcustomername);
            this.panelEx2.Controls.Add(this.txtinvoicedate);
            this.panelEx2.Controls.Add(this.txtinvoiceno);
            this.panelEx2.Controls.Add(this.label4);
            this.panelEx2.Controls.Add(this.label2);
            this.panelEx2.Controls.Add(this.label1);
            this.panelEx2.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx2.Location = new System.Drawing.Point(15, 76);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Size = new System.Drawing.Size(980, 91);
            this.panelEx2.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx2.Style.BackColor1.Color = System.Drawing.Color.White;
            this.panelEx2.Style.Border = DevComponents.DotNetBar.eBorderType.DoubleLine;
            this.panelEx2.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panelEx2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.panelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx2.Style.GradientAngle = 90;
            this.panelEx2.TabIndex = 147;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(563, 56);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(52, 17);
            this.label12.TabIndex = 146;
            this.label12.Text = "Bill No:";
            // 
            // cbopono
            // 
            this.cbopono.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbopono.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbopono.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbopono.FormattingEnabled = true;
            this.cbopono.Location = new System.Drawing.Point(98, 3);
            this.cbopono.Name = "cbopono";
            this.cbopono.Size = new System.Drawing.Size(424, 28);
            this.cbopono.TabIndex = 137;
            this.cbopono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbopono_KeyPress);
            // 
            // txt_bill_no
            // 
            this.txt_bill_no.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_bill_no.Location = new System.Drawing.Point(621, 52);
            this.txt_bill_no.Name = "txt_bill_no";
            this.txt_bill_no.Size = new System.Drawing.Size(263, 26);
            this.txt_bill_no.TabIndex = 145;
            // 
            // lblPOno
            // 
            this.lblPOno.AutoSize = true;
            this.lblPOno.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPOno.Location = new System.Drawing.Point(28, 6);
            this.lblPOno.Name = "lblPOno";
            this.lblPOno.Size = new System.Drawing.Size(61, 17);
            this.lblPOno.TabIndex = 138;
            this.lblPOno.Text = "PO NO :";
            // 
            // txtcustomername
            // 
            this.txtcustomername.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtcustomername.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.txtcustomername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcustomername.FormattingEnabled = true;
            this.txtcustomername.Location = new System.Drawing.Point(98, 52);
            this.txtcustomername.Name = "txtcustomername";
            this.txtcustomername.Size = new System.Drawing.Size(424, 28);
            this.txtcustomername.TabIndex = 127;
            this.txtcustomername.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtcustomername_KeyDown);
            // 
            // txtinvoicedate
            // 
            this.txtinvoicedate.AutoSize = true;
            this.txtinvoicedate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtinvoicedate.Location = new System.Drawing.Point(822, 14);
            this.txtinvoicedate.Name = "txtinvoicedate";
            this.txtinvoicedate.Size = new System.Drawing.Size(11, 17);
            this.txtinvoicedate.TabIndex = 132;
            this.txtinvoicedate.Text = "l";
            // 
            // txtinvoiceno
            // 
            this.txtinvoiceno.AutoSize = true;
            this.txtinvoiceno.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtinvoiceno.Location = new System.Drawing.Point(650, 14);
            this.txtinvoiceno.Name = "txtinvoiceno";
            this.txtinvoiceno.Size = new System.Drawing.Size(11, 17);
            this.txtinvoiceno.TabIndex = 131;
            this.txtinvoiceno.Text = "l";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(25, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 17);
            this.label4.TabIndex = 130;
            this.label4.Text = "Supplier :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(729, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 17);
            this.label2.TabIndex = 129;
            this.label2.Text = "Invoice Date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(570, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 17);
            this.label1.TabIndex = 128;
            this.label1.Text = "Invoice No";
            // 
            // btnsave
            // 
            this.btnsave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnsave.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btnsave.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsave.Location = new System.Drawing.Point(410, 663);
            this.btnsave.Name = "btnsave";
            this.btnsave.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(13);
            this.btnsave.Size = new System.Drawing.Size(117, 43);
            this.btnsave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnsave.Symbol = "";
            this.btnsave.TabIndex = 148;
            this.btnsave.Text = "Save";
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // btn_edit
            // 
            this.btn_edit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_edit.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btn_edit.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_edit.Location = new System.Drawing.Point(413, 656);
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(13);
            this.btn_edit.Size = new System.Drawing.Size(117, 43);
            this.btn_edit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_edit.Symbol = "";
            this.btn_edit.TabIndex = 149;
            this.btn_edit.Text = "Update";
            this.btn_edit.Click += new System.EventHandler(this.btn_edit_Click);
            // 
            // UserControl_purchase_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btn_edit);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.panelEx2);
            this.Controls.Add(this.panelEx1);
            this.Controls.Add(this.cboreceived_by);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txt_tax_amount);
            this.Controls.Add(this.btncalculateamount);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblmsg);
            this.Controls.Add(this.Total);
            this.Controls.Add(this.txttotal);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtdiscount);
            this.Name = "UserControl_purchase_form";
            this.Size = new System.Drawing.Size(995, 729);
            this.Load += new System.EventHandler(this.UserControl_purchase_form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panelEx1.ResumeLayout(false);
            this.panelEx1.PerformLayout();
            this.panelEx2.ResumeLayout(false);
            this.panelEx2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txt_tax_amount;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label Total;
        private System.Windows.Forms.TextBox txttotal;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtdiscount;
        private System.Windows.Forms.Label lblmsg;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Button btn_back;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label txtgrandtotal;
        private System.Windows.Forms.Button btncalculateamount;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cboreceived_by;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtsingletotal;
        private System.Windows.Forms.ComboBox cbo_unit;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.DateTimePicker dtpexpirydate;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbocategorynamess;
        private System.Windows.Forms.ComboBox cboproductname;
        private System.Windows.Forms.TextBox txtquanitity;
        private System.Windows.Forms.TextBox txtprice;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private DevComponents.DotNetBar.PanelEx panelEx2;
        private System.Windows.Forms.Label lblPOno;
        private System.Windows.Forms.Label txtinvoicedate;
        private System.Windows.Forms.Label txtinvoiceno;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.ButtonX btnadd;
        private DevComponents.DotNetBar.ButtonX btnsave;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridViewTextBoxColumn calcategoryid;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_purchaseid;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_bill_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn calproductid;
        private System.Windows.Forms.DataGridViewTextBoxColumn calcategoryname;
        private System.Windows.Forms.DataGridViewTextBoxColumn calproductname;
        private System.Windows.Forms.DataGridViewTextBoxColumn calprice;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn calquantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn caltotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn calexpirydate;
        private System.Windows.Forms.DataGridViewTextBoxColumn calponno;
        private System.Windows.Forms.DataGridViewTextBoxColumn calpurchase_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn calsupplier_name;
        private DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn cal_remove;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_static_qty;
        private DevComponents.DotNetBar.ButtonX btn_edit;
        public System.Windows.Forms.ComboBox cbopono;
        public System.Windows.Forms.ComboBox txtcustomername;
        public System.Windows.Forms.TextBox txt_bill_no;
    }
}