namespace POS_System
{
    partial class AddMenuItemList
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonX2 = new DevComponents.DotNetBar.ButtonX();
            this.btn_delete = new DevComponents.DotNetBar.ButtonX();
            this.btn_edit = new DevComponents.DotNetBar.ButtonX();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.txt_searchbox = new System.Windows.Forms.TextBox();
            this.lbl_search = new System.Windows.Forms.Label();
            this.dgv_productitems = new System.Windows.Forms.DataGridView();
            this.col_itemid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_imagecolor = new System.Windows.Forms.DataGridViewImageColumn();
            this.col_productitem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_costprice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_sellingprice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_kotprint = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_applicable_time_period = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_back = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_productitems)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonX2);
            this.panel1.Controls.Add(this.btn_delete);
            this.panel1.Controls.Add(this.btn_edit);
            this.panel1.Controls.Add(this.buttonX1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.txt_searchbox);
            this.panel1.Controls.Add(this.lbl_search);
            this.panel1.Controls.Add(this.dgv_productitems);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(976, 641);
            this.panel1.TabIndex = 0;
            // 
            // buttonX2
            // 
            this.buttonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX2.Location = new System.Drawing.Point(3, 71);
            this.buttonX2.Name = "buttonX2";
            this.buttonX2.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(15);
            this.buttonX2.Size = new System.Drawing.Size(48, 42);
            this.buttonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX2.Symbol = "";
            this.buttonX2.TabIndex = 11;
            this.buttonX2.Click += new System.EventHandler(this.btn_refresh_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_delete.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btn_delete.Location = new System.Drawing.Point(83, 577);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(15);
            this.btn_delete.Size = new System.Drawing.Size(51, 51);
            this.btn_delete.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_delete.Symbol = "";
            this.btn_delete.TabIndex = 10;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click_1);
            // 
            // btn_edit
            // 
            this.btn_edit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_edit.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btn_edit.Location = new System.Drawing.Point(16, 577);
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(15);
            this.btn_edit.Size = new System.Drawing.Size(51, 51);
            this.btn_edit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_edit.Symbol = "";
            this.btn_edit.TabIndex = 9;
            this.btn_edit.Click += new System.EventHandler(this.btn_edit_Click);
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.buttonX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonX1.Location = new System.Drawing.Point(57, 74);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(15);
            this.buttonX1.Size = new System.Drawing.Size(154, 35);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 8;
            this.buttonX1.Text = "+Product/Items";
            this.buttonX1.Click += new System.EventHandler(this.btn_productitems_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(346, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Product/Category";
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(484, 76);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(197, 32);
            this.comboBox1.TabIndex = 6;
            // 
            // txt_searchbox
            // 
            this.txt_searchbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_searchbox.Location = new System.Drawing.Point(753, 76);
            this.txt_searchbox.Name = "txt_searchbox";
            this.txt_searchbox.Size = new System.Drawing.Size(176, 29);
            this.txt_searchbox.TabIndex = 2;
            this.txt_searchbox.TextChanged += new System.EventHandler(this.txt_searchbox_TextChanged);
            // 
            // lbl_search
            // 
            this.lbl_search.AutoSize = true;
            this.lbl_search.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_search.Location = new System.Drawing.Point(687, 82);
            this.lbl_search.Name = "lbl_search";
            this.lbl_search.Size = new System.Drawing.Size(60, 20);
            this.lbl_search.TabIndex = 5;
            this.lbl_search.Text = "Search";
            // 
            // dgv_productitems
            // 
            this.dgv_productitems.AllowUserToAddRows = false;
            this.dgv_productitems.AllowUserToDeleteRows = false;
            this.dgv_productitems.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv_productitems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_productitems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_itemid,
            this.col_imagecolor,
            this.col_productitem,
            this.col_category,
            this.col_costprice,
            this.col_sellingprice,
            this.col_kotprint,
            this.col_applicable_time_period});
            this.dgv_productitems.Location = new System.Drawing.Point(0, 119);
            this.dgv_productitems.Name = "dgv_productitems";
            this.dgv_productitems.ReadOnly = true;
            this.dgv_productitems.RowTemplate.Height = 55;
            this.dgv_productitems.Size = new System.Drawing.Size(973, 452);
            this.dgv_productitems.TabIndex = 4;
            this.dgv_productitems.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_productitems_CellContentClick);
            // 
            // col_itemid
            // 
            this.col_itemid.HeaderText = "Item Id";
            this.col_itemid.Name = "col_itemid";
            this.col_itemid.ReadOnly = true;
            this.col_itemid.Visible = false;
            this.col_itemid.Width = 125;
            // 
            // col_imagecolor
            // 
            this.col_imagecolor.HeaderText = "Image/Color";
            this.col_imagecolor.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.col_imagecolor.Name = "col_imagecolor";
            this.col_imagecolor.ReadOnly = true;
            this.col_imagecolor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.col_imagecolor.Visible = false;
            this.col_imagecolor.Width = 90;
            // 
            // col_productitem
            // 
            this.col_productitem.HeaderText = "Product/Item";
            this.col_productitem.Name = "col_productitem";
            this.col_productitem.ReadOnly = true;
            this.col_productitem.Width = 195;
            // 
            // col_category
            // 
            this.col_category.HeaderText = "Category";
            this.col_category.Name = "col_category";
            this.col_category.ReadOnly = true;
            this.col_category.Width = 150;
            // 
            // col_costprice
            // 
            this.col_costprice.HeaderText = "Cost Price";
            this.col_costprice.Name = "col_costprice";
            this.col_costprice.ReadOnly = true;
            this.col_costprice.Width = 130;
            // 
            // col_sellingprice
            // 
            this.col_sellingprice.HeaderText = "Selling Price";
            this.col_sellingprice.Name = "col_sellingprice";
            this.col_sellingprice.ReadOnly = true;
            this.col_sellingprice.Width = 130;
            // 
            // col_kotprint
            // 
            this.col_kotprint.HeaderText = "KOT Print";
            this.col_kotprint.Name = "col_kotprint";
            this.col_kotprint.ReadOnly = true;
            this.col_kotprint.Width = 150;
            // 
            // col_applicable_time_period
            // 
            this.col_applicable_time_period.HeaderText = "Applicable Time Period";
            this.col_applicable_time_period.Name = "col_applicable_time_period";
            this.col_applicable_time_period.ReadOnly = true;
            this.col_applicable_time_period.Width = 150;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(81)))), ((int)(((byte)(126)))));
            this.panel2.Controls.Add(this.btn_back);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(976, 65);
            this.panel2.TabIndex = 1;
            // 
            // btn_back
            // 
            this.btn_back.FlatAppearance.BorderSize = 0;
            this.btn_back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_back.Image = global::POS_System.Properties.Resources.back36;
            this.btn_back.Location = new System.Drawing.Point(1, -1);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(92, 65);
            this.btn_back.TabIndex = 21;
            this.btn_back.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(398, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Product/Items";
            // 
            // AddMenuItemList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "AddMenuItemList";
            this.Size = new System.Drawing.Size(976, 641);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_productitems)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_searchbox;
        private System.Windows.Forms.Label lbl_search;
        private System.Windows.Forms.DataGridView dgv_productitems;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_back;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_itemid;
        private System.Windows.Forms.DataGridViewImageColumn col_imagecolor;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_productitem;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_category;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_costprice;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_sellingprice;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_kotprint;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_applicable_time_period;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.ButtonX btn_edit;
        private DevComponents.DotNetBar.ButtonX btn_delete;
        private DevComponents.DotNetBar.ButtonX buttonX2;
    }
}

