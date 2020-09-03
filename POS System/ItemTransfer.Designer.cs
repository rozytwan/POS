namespace POS_System
{
    partial class ItemTransfer
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cal_item_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_category_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_order_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_kot_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_move = new System.Windows.Forms.PictureBox();
            this.btn_move_all_row = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_table_no = new System.Windows.Forms.Label();
            this.btn_move_all_rows_left = new System.Windows.Forms.PictureBox();
            this.btn_move_left = new System.Windows.Forms.PictureBox();
            this.cbo_table_no_choose = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_item_transfer = new DevComponents.DotNetBar.ButtonX();
            this.tbn_cancle = new DevComponents.DotNetBar.ButtonX();
            this.cal_item_name2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_qty_2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_cost_2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_total_2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_kot_type_2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_delete_status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_order_id_2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_status_2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_category_name2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_move)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_move_all_row)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_move_all_rows_left)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_move_left)).BeginInit();
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
            this.cal_kot_type,
            this.cal_status});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Location = new System.Drawing.Point(12, 167);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.dataGridView1.RowTemplate.Height = 35;
            this.dataGridView1.Size = new System.Drawing.Size(382, 469);
            this.dataGridView1.TabIndex = 283;
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
            // cal_kot_type
            // 
            this.cal_kot_type.HeaderText = "Kot Type";
            this.cal_kot_type.Name = "cal_kot_type";
            this.cal_kot_type.ReadOnly = true;
            this.cal_kot_type.Visible = false;
            // 
            // cal_status
            // 
            this.cal_status.HeaderText = "Status";
            this.cal_status.Name = "cal_status";
            this.cal_status.ReadOnly = true;
            this.cal_status.Visible = false;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView2.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cal_item_name2,
            this.cal_qty_2,
            this.cal_cost_2,
            this.cal_total_2,
            this.cal_kot_type_2,
            this.cal_delete_status,
            this.cal_order_id_2,
            this.cal_status_2,
            this.cal_category_name2});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView2.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView2.Location = new System.Drawing.Point(508, 167);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.dataGridView2.RowTemplate.Height = 35;
            this.dataGridView2.Size = new System.Drawing.Size(441, 469);
            this.dataGridView2.TabIndex = 284;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(81)))), ((int)(((byte)(126)))));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(973, 69);
            this.panel3.TabIndex = 285;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(315, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(189, 31);
            this.label2.TabIndex = 1;
            this.label2.Text = "Item Transfer";
            // 
            // btn_move
            // 
            this.btn_move.Image = global::POS_System.Properties.Resources.right_chevron;
            this.btn_move.Location = new System.Drawing.Point(425, 268);
            this.btn_move.Name = "btn_move";
            this.btn_move.Size = new System.Drawing.Size(30, 28);
            this.btn_move.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btn_move.TabIndex = 286;
            this.btn_move.TabStop = false;
            this.btn_move.Click += new System.EventHandler(this.btn_move_Click);
            // 
            // btn_move_all_row
            // 
            this.btn_move_all_row.Image = global::POS_System.Properties.Resources.NextFast1;
            this.btn_move_all_row.Location = new System.Drawing.Point(425, 310);
            this.btn_move_all_row.Name = "btn_move_all_row";
            this.btn_move_all_row.Size = new System.Drawing.Size(30, 28);
            this.btn_move_all_row.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btn_move_all_row.TabIndex = 287;
            this.btn_move_all_row.TabStop = false;
            this.btn_move_all_row.Click += new System.EventHandler(this.btn_move_all_row_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(49, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 25);
            this.label1.TabIndex = 288;
            this.label1.Text = "Table No :-";
            // 
            // lbl_table_no
            // 
            this.lbl_table_no.AutoSize = true;
            this.lbl_table_no.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_table_no.Location = new System.Drawing.Point(165, 111);
            this.lbl_table_no.Name = "lbl_table_no";
            this.lbl_table_no.Size = new System.Drawing.Size(110, 25);
            this.lbl_table_no.TabIndex = 289;
            this.lbl_table_no.Text = "Table No :-";
            // 
            // btn_move_all_rows_left
            // 
            this.btn_move_all_rows_left.Image = global::POS_System.Properties.Resources.rewind_button;
            this.btn_move_all_rows_left.Location = new System.Drawing.Point(425, 417);
            this.btn_move_all_rows_left.Name = "btn_move_all_rows_left";
            this.btn_move_all_rows_left.Size = new System.Drawing.Size(30, 28);
            this.btn_move_all_rows_left.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btn_move_all_rows_left.TabIndex = 291;
            this.btn_move_all_rows_left.TabStop = false;
            this.btn_move_all_rows_left.Click += new System.EventHandler(this.btn_move_all_rows_left_Click);
            // 
            // btn_move_left
            // 
            this.btn_move_left.Image = global::POS_System.Properties.Resources.arrow_left_direction;
            this.btn_move_left.Location = new System.Drawing.Point(425, 375);
            this.btn_move_left.Name = "btn_move_left";
            this.btn_move_left.Size = new System.Drawing.Size(30, 28);
            this.btn_move_left.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btn_move_left.TabIndex = 290;
            this.btn_move_left.TabStop = false;
            this.btn_move_left.Click += new System.EventHandler(this.btn_move_left_Click);
            // 
            // cbo_table_no_choose
            // 
            this.cbo_table_no_choose.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_table_no_choose.FormattingEnabled = true;
            this.cbo_table_no_choose.Location = new System.Drawing.Point(645, 103);
            this.cbo_table_no_choose.Name = "cbo_table_no_choose";
            this.cbo_table_no_choose.Size = new System.Drawing.Size(220, 33);
            this.cbo_table_no_choose.TabIndex = 292;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(529, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 25);
            this.label3.TabIndex = 293;
            this.label3.Text = "Table No :-";
            // 
            // btn_item_transfer
            // 
            this.btn_item_transfer.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_item_transfer.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btn_item_transfer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_item_transfer.Location = new System.Drawing.Point(751, 677);
            this.btn_item_transfer.Name = "btn_item_transfer";
            this.btn_item_transfer.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(15);
            this.btn_item_transfer.Size = new System.Drawing.Size(163, 54);
            this.btn_item_transfer.TabIndex = 294;
            this.btn_item_transfer.Text = "Item Transfer";
            this.btn_item_transfer.Click += new System.EventHandler(this.btn_item_transfer_Click);
            // 
            // tbn_cancle
            // 
            this.tbn_cancle.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.tbn_cancle.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.tbn_cancle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbn_cancle.Location = new System.Drawing.Point(594, 678);
            this.tbn_cancle.Name = "tbn_cancle";
            this.tbn_cancle.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(15);
            this.tbn_cancle.Size = new System.Drawing.Size(131, 53);
            this.tbn_cancle.TabIndex = 295;
            this.tbn_cancle.Text = "Cancel";
            this.tbn_cancle.Click += new System.EventHandler(this.tbn_cancle_Click);
            // 
            // cal_item_name2
            // 
            this.cal_item_name2.HeaderText = "Item_name";
            this.cal_item_name2.Name = "cal_item_name2";
            this.cal_item_name2.ReadOnly = true;
            // 
            // cal_qty_2
            // 
            this.cal_qty_2.HeaderText = "QTY";
            this.cal_qty_2.Name = "cal_qty_2";
            this.cal_qty_2.ReadOnly = true;
            // 
            // cal_cost_2
            // 
            this.cal_cost_2.HeaderText = "Cost";
            this.cal_cost_2.Name = "cal_cost_2";
            this.cal_cost_2.ReadOnly = true;
            // 
            // cal_total_2
            // 
            this.cal_total_2.HeaderText = "Total";
            this.cal_total_2.Name = "cal_total_2";
            this.cal_total_2.ReadOnly = true;
            // 
            // cal_kot_type_2
            // 
            this.cal_kot_type_2.HeaderText = "Kot Type";
            this.cal_kot_type_2.Name = "cal_kot_type_2";
            this.cal_kot_type_2.ReadOnly = true;
            this.cal_kot_type_2.Visible = false;
            // 
            // cal_delete_status
            // 
            this.cal_delete_status.HeaderText = "deletestatus";
            this.cal_delete_status.Name = "cal_delete_status";
            this.cal_delete_status.ReadOnly = true;
            // 
            // cal_order_id_2
            // 
            this.cal_order_id_2.HeaderText = "Order Id";
            this.cal_order_id_2.Name = "cal_order_id_2";
            this.cal_order_id_2.ReadOnly = true;
            this.cal_order_id_2.Visible = false;
            // 
            // cal_status_2
            // 
            this.cal_status_2.HeaderText = "Status";
            this.cal_status_2.Name = "cal_status_2";
            this.cal_status_2.ReadOnly = true;
            this.cal_status_2.Visible = false;
            // 
            // cal_category_name2
            // 
            this.cal_category_name2.HeaderText = "Category Name";
            this.cal_category_name2.Name = "cal_category_name2";
            this.cal_category_name2.ReadOnly = true;
            this.cal_category_name2.Visible = false;
            // 
            // ItemTransfer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(973, 758);
            this.Controls.Add(this.tbn_cancle);
            this.Controls.Add(this.btn_item_transfer);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbo_table_no_choose);
            this.Controls.Add(this.btn_move_all_rows_left);
            this.Controls.Add(this.btn_move_left);
            this.Controls.Add(this.lbl_table_no);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_move_all_row);
            this.Controls.Add(this.btn_move);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ItemTransfer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.ItemTransfer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_move)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_move_all_row)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_move_all_rows_left)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_move_left)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView dataGridView1;
        public System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox btn_move;
        private System.Windows.Forms.PictureBox btn_move_all_row;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_table_no;
        private System.Windows.Forms.PictureBox btn_move_all_rows_left;
        private System.Windows.Forms.PictureBox btn_move_left;
        private System.Windows.Forms.ComboBox cbo_table_no_choose;
        private System.Windows.Forms.Label label3;
        private DevComponents.DotNetBar.ButtonX btn_item_transfer;
        private DevComponents.DotNetBar.ButtonX tbn_cancle;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_item_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_category_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_order_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_cost;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_total;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_kot_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_status;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_delete_status;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_category_name2;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_status_2;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_order_id_2;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_kot_type_2;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_total_2;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_cost_2;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_qty_2;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_item_name2;
    }
}
