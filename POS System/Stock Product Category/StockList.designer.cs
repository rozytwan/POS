namespace POS_System
{
    partial class StockList
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
            this.btn_back = new System.Windows.Forms.Button();
            this.lbl_addcategory = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cal_sn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_category_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_product_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_department_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_location = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_qty1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_qty2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_qty3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_transfer = new System.Windows.Forms.DataGridViewButtonColumn();
            this.col_unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_stock_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.cmb_choose = new System.Windows.Forms.ComboBox();
            this.txt_search = new System.Windows.Forms.TextBox();
            this.cmb_location = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_excel = new DevComponents.DotNetBar.ButtonX();
            this.flwpln_categoryGrouping = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(81)))), ((int)(((byte)(126)))));
            this.panel2.Controls.Add(this.flwpln_categoryGrouping);
            this.panel2.Controls.Add(this.btn_back);
            this.panel2.Controls.Add(this.lbl_addcategory);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1034, 68);
            this.panel2.TabIndex = 27;
            // 
            // btn_back
            // 
            this.btn_back.FlatAppearance.BorderSize = 0;
            this.btn_back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_back.Image = global::POS_System.Properties.Resources.back36;
            this.btn_back.Location = new System.Drawing.Point(3, 2);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(70, 64);
            this.btn_back.TabIndex = 22;
            this.btn_back.UseVisualStyleBackColor = true;
            this.btn_back.Click += new System.EventHandler(this.btn_back_Click);
            // 
            // lbl_addcategory
            // 
            this.lbl_addcategory.AutoSize = true;
            this.lbl_addcategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_addcategory.ForeColor = System.Drawing.Color.White;
            this.lbl_addcategory.Location = new System.Drawing.Point(385, 19);
            this.lbl_addcategory.Name = "lbl_addcategory";
            this.lbl_addcategory.Size = new System.Drawing.Size(126, 29);
            this.lbl_addcategory.TabIndex = 0;
            this.lbl_addcategory.Text = "Stock List";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cal_sn,
            this.col_category_name,
            this.col_product_name,
            this.col_department_name,
            this.col_location,
            this.col_qty,
            this.col_qty1,
            this.col_qty2,
            this.col_qty3,
            this.col_transfer,
            this.col_unit,
            this.col_stock_id});
            this.dataGridView1.Location = new System.Drawing.Point(3, 135);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(1028, 485);
            this.dataGridView1.TabIndex = 28;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // cal_sn
            // 
            this.cal_sn.HeaderText = "SN";
            this.cal_sn.Name = "cal_sn";
            this.cal_sn.ReadOnly = true;
            this.cal_sn.Width = 50;
            // 
            // col_category_name
            // 
            this.col_category_name.HeaderText = "Category Name";
            this.col_category_name.Name = "col_category_name";
            this.col_category_name.ReadOnly = true;
            this.col_category_name.Width = 140;
            // 
            // col_product_name
            // 
            this.col_product_name.HeaderText = "Product Name";
            this.col_product_name.Name = "col_product_name";
            this.col_product_name.ReadOnly = true;
            this.col_product_name.Width = 140;
            // 
            // col_department_name
            // 
            this.col_department_name.HeaderText = "Department Name";
            this.col_department_name.Name = "col_department_name";
            this.col_department_name.ReadOnly = true;
            this.col_department_name.Width = 80;
            // 
            // col_location
            // 
            this.col_location.HeaderText = "Location";
            this.col_location.Name = "col_location";
            this.col_location.ReadOnly = true;
            this.col_location.Width = 80;
            // 
            // col_qty
            // 
            this.col_qty.HeaderText = "Quantity";
            this.col_qty.Name = "col_qty";
            this.col_qty.ReadOnly = true;
            // 
            // col_qty1
            // 
            this.col_qty1.HeaderText = "QTY1";
            this.col_qty1.Name = "col_qty1";
            this.col_qty1.ReadOnly = true;
            // 
            // col_qty2
            // 
            this.col_qty2.HeaderText = "QTY2";
            this.col_qty2.Name = "col_qty2";
            this.col_qty2.ReadOnly = true;
            // 
            // col_qty3
            // 
            this.col_qty3.HeaderText = "QTY3";
            this.col_qty3.Name = "col_qty3";
            this.col_qty3.ReadOnly = true;
            // 
            // col_transfer
            // 
            this.col_transfer.HeaderText = "Transfer";
            this.col_transfer.Name = "col_transfer";
            this.col_transfer.ReadOnly = true;
            this.col_transfer.Text = "Transfer";
            this.col_transfer.ToolTipText = "Transfer";
            this.col_transfer.UseColumnTextForButtonValue = true;
            // 
            // col_unit
            // 
            this.col_unit.HeaderText = "Unit";
            this.col_unit.Name = "col_unit";
            this.col_unit.ReadOnly = true;
            this.col_unit.Visible = false;
            this.col_unit.Width = 130;
            // 
            // col_stock_id
            // 
            this.col_stock_id.HeaderText = "Stock Id";
            this.col_stock_id.Name = "col_stock_id";
            this.col_stock_id.ReadOnly = true;
            this.col_stock_id.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(633, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 20);
            this.label2.TabIndex = 32;
            this.label2.Text = "Search By";
            // 
            // cmb_choose
            // 
            this.cmb_choose.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmb_choose.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_choose.FormattingEnabled = true;
            this.cmb_choose.Items.AddRange(new object[] {
            "Product Name",
            "Category Name",
            "Department "});
            this.cmb_choose.Location = new System.Drawing.Point(715, 77);
            this.cmb_choose.Name = "cmb_choose";
            this.cmb_choose.Size = new System.Drawing.Size(150, 32);
            this.cmb_choose.TabIndex = 31;
            // 
            // txt_search
            // 
            this.txt_search.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_search.Location = new System.Drawing.Point(871, 77);
            this.txt_search.Name = "txt_search";
            this.txt_search.Size = new System.Drawing.Size(160, 29);
            this.txt_search.TabIndex = 29;
            this.txt_search.TextChanged += new System.EventHandler(this.txt_search_TextChanged);
            // 
            // cmb_location
            // 
            this.cmb_location.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmb_location.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_location.FormattingEnabled = true;
            this.cmb_location.Items.AddRange(new object[] {
            "M",
            "K1",
            "K2",
            "BOT",
            "S1",
            "S2",
            "S3",
            "Branch 1",
            "Branch 2",
            "Branch 3"});
            this.cmb_location.Location = new System.Drawing.Point(499, 97);
            this.cmb_location.Name = "cmb_location";
            this.cmb_location.Size = new System.Drawing.Size(102, 32);
            this.cmb_location.TabIndex = 33;
            this.cmb_location.SelectedIndexChanged += new System.EventHandler(this.cmb_location_SelectedIndexChanged);
            this.cmb_location.Enter += new System.EventHandler(this.cmb_location_Enter);
            this.cmb_location.Leave += new System.EventHandler(this.cmb_location_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(495, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 20);
            this.label1.TabIndex = 34;
            this.label1.Text = "Location";
            // 
            // btn_excel
            // 
            this.btn_excel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_excel.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btn_excel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_excel.Location = new System.Drawing.Point(829, 628);
            this.btn_excel.Name = "btn_excel";
            this.btn_excel.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(14);
            this.btn_excel.Size = new System.Drawing.Size(182, 52);
            this.btn_excel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_excel.Symbol = "";
            this.btn_excel.TabIndex = 141;
            this.btn_excel.Text = "Export to Excel";
            this.btn_excel.Click += new System.EventHandler(this.btn_excel_Click);
            // 
            // flwpln_categoryGrouping
            // 
            this.flwpln_categoryGrouping.AutoScroll = true;
            this.flwpln_categoryGrouping.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flwpln_categoryGrouping.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.flwpln_categoryGrouping.Location = new System.Drawing.Point(184, 74);
            this.flwpln_categoryGrouping.Name = "flwpln_categoryGrouping";
            this.flwpln_categoryGrouping.Size = new System.Drawing.Size(443, 57);
            this.flwpln_categoryGrouping.TabIndex = 272;
            this.flwpln_categoryGrouping.Visible = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 72);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(486, 57);
            this.flowLayoutPanel1.TabIndex = 272;
            // 
            // StockList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.btn_excel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmb_location);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmb_choose);
            this.Controls.Add(this.txt_search);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel2);
            this.Name = "StockList";
            this.Size = new System.Drawing.Size(1034, 683);
            this.Load += new System.EventHandler(this.StockList_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_back;
        private System.Windows.Forms.Label lbl_addcategory;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmb_choose;
        private System.Windows.Forms.TextBox txt_search;
        private System.Windows.Forms.ComboBox cmb_location;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.ButtonX btn_excel;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_sn;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_category_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_product_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_department_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_location;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_qty1;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_qty2;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_qty3;
        private System.Windows.Forms.DataGridViewButtonColumn col_transfer;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_stock_id;
        private System.Windows.Forms.FlowLayoutPanel flwpln_categoryGrouping;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}