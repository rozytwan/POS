namespace POS_System
{
    partial class StockProductList
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
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.col_product_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_category_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_product_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_department_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_qty1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_unit1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_qty2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_unit2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_qty3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_unit3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_edit = new DevComponents.DotNetBar.ButtonX();
            this.btn_delete = new DevComponents.DotNetBar.ButtonX();
            this.label2 = new System.Windows.Forms.Label();
            this.cmb_choose = new System.Windows.Forms.ComboBox();
            this.txt_search = new System.Windows.Forms.TextBox();
            this.lbl_search = new System.Windows.Forms.Label();
            this.Addproduct = new DevComponents.DotNetBar.ButtonX();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(81)))), ((int)(((byte)(126)))));
            this.panel2.Controls.Add(this.btn_back);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1010, 67);
            this.panel2.TabIndex = 1;
            // 
            // btn_back
            // 
            this.btn_back.FlatAppearance.BorderSize = 0;
            this.btn_back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_back.Image = global::POS_System.Properties.Resources.back36;
            this.btn_back.Location = new System.Drawing.Point(2, -1);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(71, 67);
            this.btn_back.TabIndex = 0;
            this.btn_back.UseVisualStyleBackColor = true;
            this.btn_back.Click += new System.EventHandler(this.btn_back_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(376, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Product List";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_product_id,
            this.col_category_name,
            this.col_product_name,
            this.col_department_name,
            this.col_qty1,
            this.col_unit1,
            this.col_qty2,
            this.col_unit2,
            this.col_qty3,
            this.col_unit3});
            this.dataGridView1.Location = new System.Drawing.Point(0, 130);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(1005, 474);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // col_product_id
            // 
            this.col_product_id.HeaderText = "Product Id";
            this.col_product_id.Name = "col_product_id";
            this.col_product_id.ReadOnly = true;
            this.col_product_id.Visible = false;
            // 
            // col_category_name
            // 
            this.col_category_name.HeaderText = "Category Name";
            this.col_category_name.Name = "col_category_name";
            this.col_category_name.ReadOnly = true;
            // 
            // col_product_name
            // 
            this.col_product_name.HeaderText = "Product Name";
            this.col_product_name.Name = "col_product_name";
            this.col_product_name.ReadOnly = true;
            // 
            // col_department_name
            // 
            this.col_department_name.HeaderText = "Department Name";
            this.col_department_name.Name = "col_department_name";
            this.col_department_name.ReadOnly = true;
            // 
            // col_qty1
            // 
            this.col_qty1.HeaderText = "Quantity1";
            this.col_qty1.Name = "col_qty1";
            this.col_qty1.ReadOnly = true;
            // 
            // col_unit1
            // 
            this.col_unit1.HeaderText = "Unit1";
            this.col_unit1.Name = "col_unit1";
            this.col_unit1.ReadOnly = true;
            // 
            // col_qty2
            // 
            this.col_qty2.HeaderText = "Quantity2";
            this.col_qty2.Name = "col_qty2";
            this.col_qty2.ReadOnly = true;
            // 
            // col_unit2
            // 
            this.col_unit2.HeaderText = "Unit2";
            this.col_unit2.Name = "col_unit2";
            this.col_unit2.ReadOnly = true;
            // 
            // col_qty3
            // 
            this.col_qty3.HeaderText = "Quantity3";
            this.col_qty3.Name = "col_qty3";
            this.col_qty3.ReadOnly = true;
            // 
            // col_unit3
            // 
            this.col_unit3.HeaderText = "Unit3";
            this.col_unit3.Name = "col_unit3";
            this.col_unit3.ReadOnly = true;
            // 
            // btn_edit
            // 
            this.btn_edit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_edit.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btn_edit.Location = new System.Drawing.Point(4, 611);
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(15);
            this.btn_edit.Size = new System.Drawing.Size(51, 51);
            this.btn_edit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_edit.Symbol = "";
            this.btn_edit.TabIndex = 10;
            this.btn_edit.Click += new System.EventHandler(this.btn_edit_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_delete.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btn_delete.Location = new System.Drawing.Point(84, 611);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(15);
            this.btn_delete.Size = new System.Drawing.Size(51, 51);
            this.btn_delete.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_delete.Symbol = "";
            this.btn_delete.TabIndex = 11;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(566, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 18);
            this.label2.TabIndex = 15;
            this.label2.Text = "Search By";
            // 
            // cmb_choose
            // 
            this.cmb_choose.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_choose.FormattingEnabled = true;
            this.cmb_choose.Items.AddRange(new object[] {
            "Product Name\t",
            "Department"});
            this.cmb_choose.Location = new System.Drawing.Point(644, 82);
            this.cmb_choose.Name = "cmb_choose";
            this.cmb_choose.Size = new System.Drawing.Size(149, 32);
            this.cmb_choose.TabIndex = 14;
            // 
            // txt_search
            // 
            this.txt_search.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_search.Location = new System.Drawing.Point(855, 85);
            this.txt_search.Name = "txt_search";
            this.txt_search.Size = new System.Drawing.Size(153, 29);
            this.txt_search.TabIndex = 12;
            this.txt_search.TextChanged += new System.EventHandler(this.txt_search_TextChanged);
            // 
            // lbl_search
            // 
            this.lbl_search.AutoSize = true;
            this.lbl_search.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_search.ForeColor = System.Drawing.Color.White;
            this.lbl_search.Location = new System.Drawing.Point(796, 88);
            this.lbl_search.Name = "lbl_search";
            this.lbl_search.Size = new System.Drawing.Size(60, 20);
            this.lbl_search.TabIndex = 13;
            this.lbl_search.Text = "Search";
            // 
            // Addproduct
            // 
            this.Addproduct.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.Addproduct.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.Addproduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Addproduct.Location = new System.Drawing.Point(2, 72);
            this.Addproduct.Name = "Addproduct";
            this.Addproduct.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(15);
            this.Addproduct.Size = new System.Drawing.Size(111, 52);
            this.Addproduct.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.Addproduct.TabIndex = 16;
            this.Addproduct.Text = "+Product";
            this.Addproduct.Click += new System.EventHandler(this.Addproduct_Click);
            // 
            // StockProductList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Addproduct);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmb_choose);
            this.Controls.Add(this.txt_search);
            this.Controls.Add(this.lbl_search);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.btn_edit);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel2);
            this.Name = "StockProductList";
            this.Size = new System.Drawing.Size(1010, 665);
            this.Load += new System.EventHandler(this.tbl_stock_product_list_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_back;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private DevComponents.DotNetBar.ButtonX btn_edit;
        private DevComponents.DotNetBar.ButtonX btn_delete;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmb_choose;
        private System.Windows.Forms.TextBox txt_search;
        private System.Windows.Forms.Label lbl_search;
        private DevComponents.DotNetBar.ButtonX Addproduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_product_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_category_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_product_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_department_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_qty1;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_unit1;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_qty2;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_unit2;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_qty3;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_unit3;
    }
}