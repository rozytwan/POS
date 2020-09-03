namespace POS_System.Void
{
    partial class AddItemForVoid
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddItemForVoid));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.flwpln_item = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnnext = new System.Windows.Forms.PictureBox();
            this.btnitem_next = new System.Windows.Forms.PictureBox();
            this.btn_item_preview = new System.Windows.Forms.PictureBox();
            this.btnpre = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.lblcategory_name = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.flwpln_category = new System.Windows.Forms.FlowLayoutPanel();
            this.btn_ok = new DevComponents.DotNetBar.ButtonX();
            this.btn_cancel = new DevComponents.DotNetBar.ButtonX();
            this.cal_item_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_category_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_order_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calkot_print = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_note = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnnext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnitem_next)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_item_preview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnpre)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cal_item_name,
            this.cal_category_name,
            this.cal_order_id,
            this.cal_qty,
            this.cal_cost,
            this.cal_total,
            this.calkot_print,
            this.cal_description,
            this.cal_note});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Location = new System.Drawing.Point(616, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.dataGridView1.RowTemplate.Height = 35;
            this.dataGridView1.Size = new System.Drawing.Size(401, 487);
            this.dataGridView1.TabIndex = 277;
            // 
            // flwpln_item
            // 
            this.flwpln_item.AutoScroll = true;
            this.flwpln_item.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flwpln_item.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.flwpln_item.Location = new System.Drawing.Point(3, 40);
            this.flwpln_item.Name = "flwpln_item";
            this.flwpln_item.Size = new System.Drawing.Size(607, 525);
            this.flwpln_item.TabIndex = 278;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.panel2.Controls.Add(this.btnnext);
            this.panel2.Controls.Add(this.btnitem_next);
            this.panel2.Controls.Add(this.btn_item_preview);
            this.panel2.Controls.Add(this.btnpre);
            this.panel2.Controls.Add(this.pictureBox4);
            this.panel2.Controls.Add(this.lblcategory_name);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Location = new System.Drawing.Point(1, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(606, 36);
            this.panel2.TabIndex = 279;
            // 
            // btnnext
            // 
            this.btnnext.Image = ((System.Drawing.Image)(resources.GetObject("btnnext.Image")));
            this.btnnext.Location = new System.Drawing.Point(506, 2);
            this.btnnext.Name = "btnnext";
            this.btnnext.Size = new System.Drawing.Size(31, 34);
            this.btnnext.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnnext.TabIndex = 277;
            this.btnnext.TabStop = false;
            this.btnnext.Click += new System.EventHandler(this.btnnext_Click);
            // 
            // btnitem_next
            // 
            this.btnitem_next.Image = global::POS_System.Properties.Resources.move_to_next__1_;
            this.btnitem_next.Location = new System.Drawing.Point(454, 1);
            this.btnitem_next.Name = "btnitem_next";
            this.btnitem_next.Size = new System.Drawing.Size(31, 34);
            this.btnitem_next.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnitem_next.TabIndex = 278;
            this.btnitem_next.TabStop = false;
            this.btnitem_next.Click += new System.EventHandler(this.btnpre_Click);
            // 
            // btn_item_preview
            // 
            this.btn_item_preview.Image = global::POS_System.Properties.Resources.previous;
            this.btn_item_preview.Location = new System.Drawing.Point(85, 2);
            this.btn_item_preview.Name = "btn_item_preview";
            this.btn_item_preview.Size = new System.Drawing.Size(32, 32);
            this.btn_item_preview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btn_item_preview.TabIndex = 276;
            this.btn_item_preview.TabStop = false;
            // 
            // btnpre
            // 
            this.btnpre.Image = global::POS_System.Properties.Resources.previous;
            this.btnpre.Location = new System.Drawing.Point(33, 2);
            this.btnpre.Name = "btnpre";
            this.btnpre.Size = new System.Drawing.Size(32, 32);
            this.btnpre.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btnpre.TabIndex = 275;
            this.btnpre.TabStop = false;
            this.btnpre.Click += new System.EventHandler(this.btnpre_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::POS_System.Properties.Resources.icon__1_;
            this.pictureBox4.Location = new System.Drawing.Point(244, 1);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(35, 33);
            this.pictureBox4.TabIndex = 261;
            this.pictureBox4.TabStop = false;
            // 
            // lblcategory_name
            // 
            this.lblcategory_name.AutoSize = true;
            this.lblcategory_name.BackColor = System.Drawing.Color.Transparent;
            this.lblcategory_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcategory_name.ForeColor = System.Drawing.Color.White;
            this.lblcategory_name.Location = new System.Drawing.Point(285, 2);
            this.lblcategory_name.Name = "lblcategory_name";
            this.lblcategory_name.Size = new System.Drawing.Size(110, 29);
            this.lblcategory_name.TabIndex = 260;
            this.lblcategory_name.Text = "Category";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::POS_System.Properties.Resources.previous__1_;
            this.pictureBox1.Location = new System.Drawing.Point(571, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 257;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // flwpln_category
            // 
            this.flwpln_category.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flwpln_category.BackColor = System.Drawing.Color.Black;
            this.flwpln_category.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flwpln_category.ForeColor = System.Drawing.Color.Transparent;
            this.flwpln_category.Location = new System.Drawing.Point(4, 40);
            this.flwpln_category.Name = "flwpln_category";
            this.flwpln_category.Size = new System.Drawing.Size(606, 525);
            this.flwpln_category.TabIndex = 271;
            // 
            // btn_ok
            // 
            this.btn_ok.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_ok.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btn_ok.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ok.Location = new System.Drawing.Point(919, 489);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(15);
            this.btn_ok.Size = new System.Drawing.Size(88, 80);
            this.btn_ok.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2010;
            this.btn_ok.TabIndex = 280;
            this.btn_ok.Text = "OK";
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btn_cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancel.Location = new System.Drawing.Point(810, 489);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(15);
            this.btn_cancel.Size = new System.Drawing.Size(88, 80);
            this.btn_cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2010;
            this.btn_cancel.TabIndex = 281;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // cal_item_name
            // 
            this.cal_item_name.HeaderText = "Item Name";
            this.cal_item_name.Name = "cal_item_name";
            this.cal_item_name.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cal_item_name.Width = 150;
            // 
            // cal_category_name
            // 
            this.cal_category_name.HeaderText = "Category Name";
            this.cal_category_name.Name = "cal_category_name";
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
            this.cal_qty.Width = 55;
            // 
            // cal_cost
            // 
            this.cal_cost.HeaderText = "Cost";
            this.cal_cost.Name = "cal_cost";
            this.cal_cost.Width = 75;
            // 
            // cal_total
            // 
            this.cal_total.HeaderText = "Total";
            this.cal_total.Name = "cal_total";
            this.cal_total.Width = 90;
            // 
            // calkot_print
            // 
            this.calkot_print.HeaderText = "Kot print";
            this.calkot_print.Name = "calkot_print";
            this.calkot_print.Visible = false;
            // 
            // cal_description
            // 
            this.cal_description.HeaderText = "cal_modifier";
            this.cal_description.Name = "cal_description";
            this.cal_description.Visible = false;
            // 
            // cal_note
            // 
            this.cal_note.HeaderText = "Note";
            this.cal_note.Name = "cal_note";
            this.cal_note.Visible = false;
            // 
            // AddItemForVoid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1019, 571);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.flwpln_category);
            this.Controls.Add(this.flwpln_item);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddItemForVoid";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddItemForVoid";
            this.Load += new System.EventHandler(this.AddItemForVoid_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnnext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnitem_next)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_item_preview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnpre)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flwpln_item;
        public System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox btnnext;
        private System.Windows.Forms.PictureBox btnitem_next;
        private System.Windows.Forms.PictureBox btn_item_preview;
        private System.Windows.Forms.PictureBox btnpre;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label lblcategory_name;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.FlowLayoutPanel flwpln_category;
        private DevComponents.DotNetBar.ButtonX btn_ok;
        private DevComponents.DotNetBar.ButtonX btn_cancel;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_item_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_category_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_order_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_cost;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_total;
        private System.Windows.Forms.DataGridViewTextBoxColumn calkot_print;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_description;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_note;
    }
}