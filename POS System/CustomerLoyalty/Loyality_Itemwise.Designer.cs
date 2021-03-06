﻿namespace POS_System.Loyality
{
    partial class Loyality_Itemwise
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_back = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.txt_searchbox = new System.Windows.Forms.TextBox();
            this.lbl_search = new System.Windows.Forms.Label();
            this.btn_delete = new DevComponents.DotNetBar.ButtonX();
            this.btn_edit = new DevComponents.DotNetBar.ButtonX();
            this.dgv_productitems = new System.Windows.Forms.DataGridView();
            this.col_itemid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_imagecolor = new System.Windows.Forms.DataGridViewImageColumn();
            this.col_productitem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_costprice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_sellingprice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_kotprint = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_applicable_time_period = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_loyality = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_productitems)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgv_productitems);
            this.panel1.Controls.Add(this.btn_delete);
            this.panel1.Controls.Add(this.btn_edit);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.txt_searchbox);
            this.panel1.Controls.Add(this.lbl_search);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(0, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(961, 628);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(81)))), ((int)(((byte)(126)))));
            this.panel2.Controls.Add(this.btn_back);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(961, 65);
            this.panel2.TabIndex = 2;
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(344, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 20);
            this.label2.TabIndex = 15;
            this.label2.Text = "Product/Category";
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(482, 73);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(197, 32);
            this.comboBox1.TabIndex = 14;
            // 
            // txt_searchbox
            // 
            this.txt_searchbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_searchbox.Location = new System.Drawing.Point(751, 73);
            this.txt_searchbox.Name = "txt_searchbox";
            this.txt_searchbox.Size = new System.Drawing.Size(176, 29);
            this.txt_searchbox.TabIndex = 12;
            this.txt_searchbox.TextChanged += new System.EventHandler(this.txt_searchbox_TextChanged);
            // 
            // lbl_search
            // 
            this.lbl_search.AutoSize = true;
            this.lbl_search.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_search.Location = new System.Drawing.Point(685, 79);
            this.lbl_search.Name = "lbl_search";
            this.lbl_search.Size = new System.Drawing.Size(60, 20);
            this.lbl_search.TabIndex = 13;
            this.lbl_search.Text = "Search";
            // 
            // btn_delete
            // 
            this.btn_delete.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_delete.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btn_delete.Location = new System.Drawing.Point(91, 574);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(15);
            this.btn_delete.Size = new System.Drawing.Size(51, 51);
            this.btn_delete.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_delete.Symbol = "";
            this.btn_delete.TabIndex = 20;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // btn_edit
            // 
            this.btn_edit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_edit.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btn_edit.Location = new System.Drawing.Point(24, 574);
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(15);
            this.btn_edit.Size = new System.Drawing.Size(51, 51);
            this.btn_edit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_edit.Symbol = "";
            this.btn_edit.TabIndex = 19;
            this.btn_edit.Click += new System.EventHandler(this.btn_edit_Click);
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
            this.col_applicable_time_period,
            this.col_loyality});
            this.dgv_productitems.Location = new System.Drawing.Point(3, 119);
            this.dgv_productitems.Name = "dgv_productitems";
            this.dgv_productitems.ReadOnly = true;
            this.dgv_productitems.RowTemplate.Height = 55;
            this.dgv_productitems.Size = new System.Drawing.Size(949, 452);
            this.dgv_productitems.TabIndex = 42;
            this.dgv_productitems.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_productitems_CellClick);
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
            this.col_applicable_time_period.Visible = false;
            this.col_applicable_time_period.Width = 150;
            // 
            // col_loyality
            // 
            this.col_loyality.HeaderText = "Loyality Point";
            this.col_loyality.Name = "col_loyality";
            this.col_loyality.ReadOnly = true;
            this.col_loyality.Text = "Loyality Point";
            this.col_loyality.ToolTipText = "Loyality Point";
            this.col_loyality.UseColumnTextForButtonValue = true;
            this.col_loyality.Width = 150;
            // 
            // Loyality_Itemwise
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(965, 635);
            this.Controls.Add(this.panel1);
            this.Name = "Loyality_Itemwise";
            this.Text = "Loyality_Itemwise";
            this.Load += new System.EventHandler(this.Loyality_Itemwise_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_productitems)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_back;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox txt_searchbox;
        private System.Windows.Forms.Label lbl_search;
        private DevComponents.DotNetBar.ButtonX btn_delete;
        private DevComponents.DotNetBar.ButtonX btn_edit;
        private System.Windows.Forms.DataGridView dgv_productitems;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_itemid;
        private System.Windows.Forms.DataGridViewImageColumn col_imagecolor;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_productitem;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_category;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_costprice;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_sellingprice;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_kotprint;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_applicable_time_period;
        private System.Windows.Forms.DataGridViewButtonColumn col_loyality;
    }
}