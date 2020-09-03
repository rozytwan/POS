namespace POS_System
{
    partial class TakeAway
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cal_item_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Calckeck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cal_category_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_order_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtremainingamount = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtcardamount = new System.Windows.Forms.TextBox();
            this.txtcashamount = new System.Windows.Forms.TextBox();
            this.txtdiscount = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtsubtotal = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkcash_card = new System.Windows.Forms.RadioButton();
            this.chkcard = new System.Windows.Forms.RadioButton();
            this.chkcredit = new System.Windows.Forms.RadioButton();
            this.chkcash = new System.Windows.Forms.RadioButton();
            this.btntable_transfer = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtnewbillno = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtcashier = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.lbltable = new System.Windows.Forms.Label();
            this.txtgrandtotal = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.btntable_transfer.SuspendLayout();
            this.SuspendLayout();
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
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cal_item_name,
            this.Calckeck,
            this.cal_category_name,
            this.cal_order_id,
            this.cal_qty,
            this.cal_cost,
            this.cal_total});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Location = new System.Drawing.Point(72, 155);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.dataGridView1.RowTemplate.Height = 35;
            this.dataGridView1.Size = new System.Drawing.Size(49, 47);
            this.dataGridView1.TabIndex = 282;
            // 
            // cal_item_name
            // 
            this.cal_item_name.HeaderText = "Item Name";
            this.cal_item_name.Name = "cal_item_name";
            this.cal_item_name.ReadOnly = true;
            this.cal_item_name.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cal_item_name.Width = 150;
            // 
            // Calckeck
            // 
            this.Calckeck.HeaderText = "CheckBox";
            this.Calckeck.Name = "Calckeck";
            this.Calckeck.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Calckeck.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Calckeck.Visible = false;
            this.Calckeck.Width = 25;
            // 
            // cal_category_name
            // 
            this.cal_category_name.HeaderText = "Category Name";
            this.cal_category_name.Name = "cal_category_name";
            this.cal_category_name.ReadOnly = true;
            this.cal_category_name.Visible = false;
            // 
            // cal_order_id
            // 
            this.cal_order_id.HeaderText = "order_id";
            this.cal_order_id.Name = "cal_order_id";
            this.cal_order_id.Visible = false;
            // 
            // cal_qty
            // 
            this.cal_qty.HeaderText = "QTY";
            this.cal_qty.Name = "cal_qty";
            this.cal_qty.Width = 40;
            // 
            // cal_cost
            // 
            this.cal_cost.HeaderText = "Cost";
            this.cal_cost.Name = "cal_cost";
            this.cal_cost.ReadOnly = true;
            this.cal_cost.Width = 60;
            // 
            // cal_total
            // 
            this.cal_total.HeaderText = "Total";
            this.cal_total.Name = "cal_total";
            this.cal_total.ReadOnly = true;
            this.cal_total.Width = 90;
            // 
            // txtremainingamount
            // 
            this.txtremainingamount.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtremainingamount.Location = new System.Drawing.Point(140, 231);
            this.txtremainingamount.Name = "txtremainingamount";
            this.txtremainingamount.Size = new System.Drawing.Size(30, 30);
            this.txtremainingamount.TabIndex = 298;
            this.txtremainingamount.Text = "0.00";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(137, 155);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(111, 17);
            this.label12.TabIndex = 304;
            this.label12.Text = "Recived Amount";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(138, 269);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(122, 17);
            this.label15.TabIndex = 303;
            this.label15.Text = "Card Paid Amount";
            // 
            // txtcardamount
            // 
            this.txtcardamount.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcardamount.Location = new System.Drawing.Point(140, 292);
            this.txtcardamount.Name = "txtcardamount";
            this.txtcardamount.Size = new System.Drawing.Size(30, 30);
            this.txtcardamount.TabIndex = 299;
            this.txtcardamount.Text = "0.00";
            // 
            // txtcashamount
            // 
            this.txtcashamount.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcashamount.Location = new System.Drawing.Point(138, 181);
            this.txtcashamount.Name = "txtcashamount";
            this.txtcashamount.Size = new System.Drawing.Size(32, 30);
            this.txtcashamount.TabIndex = 297;
            // 
            // txtdiscount
            // 
            this.txtdiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdiscount.Location = new System.Drawing.Point(138, 356);
            this.txtdiscount.Name = "txtdiscount";
            this.txtdiscount.Size = new System.Drawing.Size(32, 30);
            this.txtdiscount.TabIndex = 300;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(140, 329);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(63, 17);
            this.label16.TabIndex = 302;
            this.label16.Text = "Discount";
            // 
            // txtsubtotal
            // 
            this.txtsubtotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsubtotal.Location = new System.Drawing.Point(138, 118);
            this.txtsubtotal.Name = "txtsubtotal";
            this.txtsubtotal.Size = new System.Drawing.Size(32, 30);
            this.txtsubtotal.TabIndex = 296;
            this.txtsubtotal.Text = "0.00";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(137, 98);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(69, 17);
            this.label17.TabIndex = 301;
            this.label17.Text = "Sub Total";
            // 
            // groupBox2
            // 
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(266, 72);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(35, 139);
            this.groupBox2.TabIndex = 295;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Payment Mode";
            // 
            // chkcash_card
            // 
            this.chkcash_card.AutoSize = true;
            this.chkcash_card.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.chkcash_card.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkcash_card.ForeColor = System.Drawing.Color.White;
            this.chkcash_card.Location = new System.Drawing.Point(266, 337);
            this.chkcash_card.Name = "chkcash_card";
            this.chkcash_card.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.chkcash_card.Size = new System.Drawing.Size(211, 24);
            this.chkcash_card.TabIndex = 8;
            this.chkcash_card.Text = "            Cash/Card       ";
            this.chkcash_card.UseVisualStyleBackColor = false;
            // 
            // chkcard
            // 
            this.chkcard.AutoSize = true;
            this.chkcard.BackColor = System.Drawing.Color.Red;
            this.chkcard.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkcard.ForeColor = System.Drawing.Color.White;
            this.chkcard.Location = new System.Drawing.Point(267, 308);
            this.chkcard.Name = "chkcard";
            this.chkcard.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.chkcard.Size = new System.Drawing.Size(220, 24);
            this.chkcard.TabIndex = 7;
            this.chkcard.Text = "            Card                  ";
            this.chkcard.UseVisualStyleBackColor = false;
            // 
            // chkcredit
            // 
            this.chkcredit.AutoSize = true;
            this.chkcredit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(81)))), ((int)(((byte)(126)))));
            this.chkcredit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkcredit.ForeColor = System.Drawing.Color.White;
            this.chkcredit.Location = new System.Drawing.Point(266, 279);
            this.chkcredit.Name = "chkcredit";
            this.chkcredit.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.chkcredit.Size = new System.Drawing.Size(225, 24);
            this.chkcredit.TabIndex = 6;
            this.chkcredit.Text = "            Credit                 ";
            this.chkcredit.UseVisualStyleBackColor = false;
            // 
            // chkcash
            // 
            this.chkcash.AutoSize = true;
            this.chkcash.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.chkcash.Checked = true;
            this.chkcash.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkcash.ForeColor = System.Drawing.Color.White;
            this.chkcash.Location = new System.Drawing.Point(266, 249);
            this.chkcash.Name = "chkcash";
            this.chkcash.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.chkcash.Size = new System.Drawing.Size(203, 24);
            this.chkcash.TabIndex = 5;
            this.chkcash.TabStop = true;
            this.chkcash.Text = "            Cash              ";
            this.chkcash.UseVisualStyleBackColor = false;
            // 
            // btntable_transfer
            // 
            this.btntable_transfer.Controls.Add(this.label8);
            this.btntable_transfer.Controls.Add(this.txtnewbillno);
            this.btntable_transfer.Controls.Add(this.label11);
            this.btntable_transfer.Controls.Add(this.txtcashier);
            this.btntable_transfer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btntable_transfer.ForeColor = System.Drawing.Color.Black;
            this.btntable_transfer.Location = new System.Drawing.Point(307, 72);
            this.btntable_transfer.Name = "btntable_transfer";
            this.btntable_transfer.Size = new System.Drawing.Size(37, 121);
            this.btntable_transfer.TabIndex = 294;
            this.btntable_transfer.TabStop = false;
            this.btntable_transfer.Text = "Bill Info";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(6, 68);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 15);
            this.label8.TabIndex = 91;
            this.label8.Text = "Cashier";
            // 
            // txtnewbillno
            // 
            this.txtnewbillno.Location = new System.Drawing.Point(9, 42);
            this.txtnewbillno.Name = "txtnewbillno";
            this.txtnewbillno.Size = new System.Drawing.Size(175, 23);
            this.txtnewbillno.TabIndex = 88;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(11, 20);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(50, 15);
            this.label11.TabIndex = 90;
            this.label11.Text = "Bill No";
            // 
            // txtcashier
            // 
            this.txtcashier.Location = new System.Drawing.Point(9, 91);
            this.txtcashier.Name = "txtcashier";
            this.txtcashier.ReadOnly = true;
            this.txtcashier.Size = new System.Drawing.Size(177, 23);
            this.txtcashier.TabIndex = 89;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(140, 213);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(109, 17);
            this.label14.TabIndex = 305;
            this.label14.Text = "Change Amount";
            // 
            // lbltable
            // 
            this.lbltable.AutoSize = true;
            this.lbltable.BackColor = System.Drawing.Color.Transparent;
            this.lbltable.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltable.ForeColor = System.Drawing.Color.Lime;
            this.lbltable.Location = new System.Drawing.Point(42, 38);
            this.lbltable.Name = "lbltable";
            this.lbltable.Size = new System.Drawing.Size(37, 39);
            this.lbltable.TabIndex = 306;
            this.lbltable.Text = "1";
            // 
            // txtgrandtotal
            // 
            this.txtgrandtotal.AutoSize = true;
            this.txtgrandtotal.BackColor = System.Drawing.Color.Transparent;
            this.txtgrandtotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtgrandtotal.ForeColor = System.Drawing.Color.Lime;
            this.txtgrandtotal.Location = new System.Drawing.Point(55, 19);
            this.txtgrandtotal.Name = "txtgrandtotal";
            this.txtgrandtotal.Size = new System.Drawing.Size(50, 25);
            this.txtgrandtotal.TabIndex = 307;
            this.txtgrandtotal.Text = "0.00";
            // 
            // TakeAway
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(180, 21);
            this.Controls.Add(this.txtgrandtotal);
            this.Controls.Add(this.lbltable);
            this.Controls.Add(this.chkcash_card);
            this.Controls.Add(this.chkcard);
            this.Controls.Add(this.txtremainingamount);
            this.Controls.Add(this.chkcredit);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.chkcash);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtcardamount);
            this.Controls.Add(this.txtcashamount);
            this.Controls.Add(this.txtdiscount);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txtsubtotal);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btntable_transfer);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TakeAway";
            this.Text = "TakeAway";
            this.Load += new System.EventHandler(this.TakeAway_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.btntable_transfer.ResumeLayout(false);
            this.btntable_transfer.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_item_name;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Calckeck;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_category_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_order_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_cost;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_total;
        private System.Windows.Forms.TextBox txtremainingamount;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtcardamount;
        private System.Windows.Forms.TextBox txtcashamount;
        private System.Windows.Forms.TextBox txtdiscount;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtsubtotal;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton chkcash_card;
        private System.Windows.Forms.RadioButton chkcard;
        private System.Windows.Forms.RadioButton chkcredit;
        private System.Windows.Forms.RadioButton chkcash;
        private System.Windows.Forms.GroupBox btntable_transfer;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtnewbillno;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtcashier;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lbltable;
        private System.Windows.Forms.Label txtgrandtotal;
    }
}