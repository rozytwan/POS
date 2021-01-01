namespace POS_System
{
    partial class RoomCategory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RoomCategory));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btn_edit = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btn_delete = new Bunifu.Framework.UI.BunifuFlatButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rich_description = new System.Windows.Forms.RichTextBox();
            this.txt_beds = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.txt_category = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.btn_update = new Bunifu.Framework.UI.BunifuFlatButton();
            this.bunifuCustomLabel25 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel27 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.btn_save = new Bunifu.Framework.UI.BunifuFlatButton();
            this.bunifuCustomLabel2 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel3 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.col_category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_bed_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.btn_back = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(30)))), ((int)(((byte)(66)))));
            this.panel1.Controls.Add(this.btn_back);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.bunifuCustomLabel3);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.bunifuCustomLabel1);
            this.panel1.Location = new System.Drawing.Point(3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(757, 641);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(30)))), ((int)(((byte)(66)))));
            this.panel3.Controls.Add(this.btn_edit);
            this.panel3.Controls.Add(this.btn_delete);
            this.panel3.Location = new System.Drawing.Point(0, 580);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(452, 58);
            this.panel3.TabIndex = 27;
            // 
            // btn_edit
            // 
            this.btn_edit.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btn_edit.BackColor = System.Drawing.Color.Transparent;
            this.btn_edit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_edit.BorderRadius = 2;
            this.btn_edit.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.btn_edit.ButtonText = "Edit";
            this.btn_edit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_edit.DisabledColor = System.Drawing.Color.Gray;
            this.btn_edit.Iconcolor = System.Drawing.Color.Transparent;
            this.btn_edit.Iconimage = ((System.Drawing.Image)(resources.GetObject("btn_edit.Iconimage")));
            this.btn_edit.Iconimage_right = null;
            this.btn_edit.Iconimage_right_Selected = null;
            this.btn_edit.Iconimage_Selected = null;
            this.btn_edit.IconMarginLeft = 0;
            this.btn_edit.IconMarginRight = 0;
            this.btn_edit.IconRightVisible = true;
            this.btn_edit.IconRightZoom = 0D;
            this.btn_edit.IconVisible = true;
            this.btn_edit.IconZoom = 70D;
            this.btn_edit.IsTab = false;
            this.btn_edit.Location = new System.Drawing.Point(10, 3);
            this.btn_edit.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Normalcolor = System.Drawing.Color.Transparent;
            this.btn_edit.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btn_edit.OnHoverTextColor = System.Drawing.Color.White;
            this.btn_edit.selected = false;
            this.btn_edit.Size = new System.Drawing.Size(117, 40);
            this.btn_edit.TabIndex = 23;
            this.btn_edit.Text = "Edit";
            this.btn_edit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_edit.Textcolor = System.Drawing.Color.White;
            this.btn_edit.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_edit.Click += new System.EventHandler(this.btn_edit_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btn_delete.BackColor = System.Drawing.Color.Transparent;
            this.btn_delete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_delete.BorderRadius = 2;
            this.btn_delete.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.btn_delete.ButtonText = "Delete";
            this.btn_delete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_delete.DisabledColor = System.Drawing.Color.Gray;
            this.btn_delete.Iconcolor = System.Drawing.Color.Transparent;
            this.btn_delete.Iconimage = ((System.Drawing.Image)(resources.GetObject("btn_delete.Iconimage")));
            this.btn_delete.Iconimage_right = null;
            this.btn_delete.Iconimage_right_Selected = null;
            this.btn_delete.Iconimage_Selected = null;
            this.btn_delete.IconMarginLeft = 0;
            this.btn_delete.IconMarginRight = 0;
            this.btn_delete.IconRightVisible = true;
            this.btn_delete.IconRightZoom = 0D;
            this.btn_delete.IconVisible = true;
            this.btn_delete.IconZoom = 70D;
            this.btn_delete.IsTab = false;
            this.btn_delete.Location = new System.Drawing.Point(148, 3);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Normalcolor = System.Drawing.Color.Transparent;
            this.btn_delete.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btn_delete.OnHoverTextColor = System.Drawing.Color.White;
            this.btn_delete.selected = false;
            this.btn_delete.Size = new System.Drawing.Size(113, 40);
            this.btn_delete.TabIndex = 24;
            this.btn_delete.Text = "Delete";
            this.btn_delete.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_delete.Textcolor = System.Drawing.Color.White;
            this.btn_delete.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(80)))), ((int)(((byte)(86)))));
            this.panel2.Controls.Add(this.rich_description);
            this.panel2.Controls.Add(this.txt_beds);
            this.panel2.Controls.Add(this.txt_category);
            this.panel2.Controls.Add(this.btn_update);
            this.panel2.Controls.Add(this.bunifuCustomLabel25);
            this.panel2.Controls.Add(this.bunifuCustomLabel27);
            this.panel2.Controls.Add(this.btn_save);
            this.panel2.Controls.Add(this.bunifuCustomLabel2);
            this.panel2.Location = new System.Drawing.Point(458, 65);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(296, 573);
            this.panel2.TabIndex = 26;
            // 
            // rich_description
            // 
            this.rich_description.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(80)))), ((int)(((byte)(86)))));
            this.rich_description.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rich_description.ForeColor = System.Drawing.Color.White;
            this.rich_description.Location = new System.Drawing.Point(4, 209);
            this.rich_description.Name = "rich_description";
            this.rich_description.Size = new System.Drawing.Size(266, 96);
            this.rich_description.TabIndex = 19;
            this.rich_description.Text = "";
            // 
            // txt_beds
            // 
            this.txt_beds.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(80)))), ((int)(((byte)(86)))));
            this.txt_beds.BorderColorFocused = System.Drawing.Color.Lavender;
            this.txt_beds.BorderColorIdle = System.Drawing.Color.White;
            this.txt_beds.BorderColorMouseHover = System.Drawing.Color.Blue;
            this.txt_beds.BorderThickness = 1;
            this.txt_beds.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_beds.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_beds.ForeColor = System.Drawing.Color.White;
            this.txt_beds.isPassword = false;
            this.txt_beds.Location = new System.Drawing.Point(4, 130);
            this.txt_beds.Margin = new System.Windows.Forms.Padding(4);
            this.txt_beds.Name = "txt_beds";
            this.txt_beds.Size = new System.Drawing.Size(266, 32);
            this.txt_beds.TabIndex = 16;
            this.txt_beds.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txt_beds.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_beds_KeyPress);
            // 
            // txt_category
            // 
            this.txt_category.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(80)))), ((int)(((byte)(86)))));
            this.txt_category.BorderColorFocused = System.Drawing.Color.Lavender;
            this.txt_category.BorderColorIdle = System.Drawing.Color.White;
            this.txt_category.BorderColorMouseHover = System.Drawing.Color.Blue;
            this.txt_category.BorderThickness = 1;
            this.txt_category.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_category.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_category.ForeColor = System.Drawing.Color.White;
            this.txt_category.isPassword = false;
            this.txt_category.Location = new System.Drawing.Point(4, 51);
            this.txt_category.Margin = new System.Windows.Forms.Padding(4);
            this.txt_category.Name = "txt_category";
            this.txt_category.Size = new System.Drawing.Size(266, 32);
            this.txt_category.TabIndex = 14;
            this.txt_category.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // btn_update
            // 
            this.btn_update.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btn_update.BackColor = System.Drawing.Color.Transparent;
            this.btn_update.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_update.BorderRadius = 2;
            this.btn_update.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.btn_update.ButtonText = "Update";
            this.btn_update.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_update.DisabledColor = System.Drawing.Color.Gray;
            this.btn_update.Iconcolor = System.Drawing.Color.Transparent;
            this.btn_update.Iconimage = ((System.Drawing.Image)(resources.GetObject("btn_update.Iconimage")));
            this.btn_update.Iconimage_right = null;
            this.btn_update.Iconimage_right_Selected = null;
            this.btn_update.Iconimage_Selected = null;
            this.btn_update.IconMarginLeft = 0;
            this.btn_update.IconMarginRight = 0;
            this.btn_update.IconRightVisible = true;
            this.btn_update.IconRightZoom = 0D;
            this.btn_update.IconVisible = true;
            this.btn_update.IconZoom = 70D;
            this.btn_update.IsTab = false;
            this.btn_update.Location = new System.Drawing.Point(20, 325);
            this.btn_update.Name = "btn_update";
            this.btn_update.Normalcolor = System.Drawing.Color.Transparent;
            this.btn_update.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btn_update.OnHoverTextColor = System.Drawing.Color.White;
            this.btn_update.selected = false;
            this.btn_update.Size = new System.Drawing.Size(113, 40);
            this.btn_update.TabIndex = 22;
            this.btn_update.Text = "Update";
            this.btn_update.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_update.Textcolor = System.Drawing.Color.White;
            this.btn_update.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // bunifuCustomLabel25
            // 
            this.bunifuCustomLabel25.AutoSize = true;
            this.bunifuCustomLabel25.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel25.ForeColor = System.Drawing.Color.White;
            this.bunifuCustomLabel25.Location = new System.Drawing.Point(1, 108);
            this.bunifuCustomLabel25.Name = "bunifuCustomLabel25";
            this.bunifuCustomLabel25.Size = new System.Drawing.Size(95, 18);
            this.bunifuCustomLabel25.TabIndex = 13;
            this.bunifuCustomLabel25.Text = "No. of Bed/s";
            // 
            // bunifuCustomLabel27
            // 
            this.bunifuCustomLabel27.AutoSize = true;
            this.bunifuCustomLabel27.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel27.ForeColor = System.Drawing.Color.White;
            this.bunifuCustomLabel27.Location = new System.Drawing.Point(1, 29);
            this.bunifuCustomLabel27.Name = "bunifuCustomLabel27";
            this.bunifuCustomLabel27.Size = new System.Drawing.Size(117, 18);
            this.bunifuCustomLabel27.TabIndex = 12;
            this.bunifuCustomLabel27.Text = "Room Cateogry";
            // 
            // btn_save
            // 
            this.btn_save.Activecolor = System.Drawing.Color.Green;
            this.btn_save.BackColor = System.Drawing.Color.Transparent;
            this.btn_save.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_save.BorderRadius = 2;
            this.btn_save.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.btn_save.ButtonText = "Save";
            this.btn_save.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_save.DisabledColor = System.Drawing.Color.Gray;
            this.btn_save.Iconcolor = System.Drawing.Color.Transparent;
            this.btn_save.Iconimage = ((System.Drawing.Image)(resources.GetObject("btn_save.Iconimage")));
            this.btn_save.Iconimage_right = null;
            this.btn_save.Iconimage_right_Selected = null;
            this.btn_save.Iconimage_Selected = null;
            this.btn_save.IconMarginLeft = 0;
            this.btn_save.IconMarginRight = 0;
            this.btn_save.IconRightVisible = true;
            this.btn_save.IconRightZoom = 0D;
            this.btn_save.IconVisible = true;
            this.btn_save.IconZoom = 70D;
            this.btn_save.IsTab = false;
            this.btn_save.Location = new System.Drawing.Point(157, 325);
            this.btn_save.Name = "btn_save";
            this.btn_save.Normalcolor = System.Drawing.Color.Transparent;
            this.btn_save.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btn_save.OnHoverTextColor = System.Drawing.Color.White;
            this.btn_save.selected = false;
            this.btn_save.Size = new System.Drawing.Size(113, 40);
            this.btn_save.TabIndex = 20;
            this.btn_save.Text = "Save";
            this.btn_save.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_save.Textcolor = System.Drawing.Color.White;
            this.btn_save.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // bunifuCustomLabel2
            // 
            this.bunifuCustomLabel2.AutoSize = true;
            this.bunifuCustomLabel2.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel2.ForeColor = System.Drawing.Color.White;
            this.bunifuCustomLabel2.Location = new System.Drawing.Point(1, 179);
            this.bunifuCustomLabel2.Name = "bunifuCustomLabel2";
            this.bunifuCustomLabel2.Size = new System.Drawing.Size(88, 18);
            this.bunifuCustomLabel2.TabIndex = 18;
            this.bunifuCustomLabel2.Text = "Description";
            // 
            // bunifuCustomLabel3
            // 
            this.bunifuCustomLabel3.AutoSize = true;
            this.bunifuCustomLabel3.Font = new System.Drawing.Font("Georgia", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel3.ForeColor = System.Drawing.Color.White;
            this.bunifuCustomLabel3.Location = new System.Drawing.Point(484, 25);
            this.bunifuCustomLabel3.Name = "bunifuCustomLabel3";
            this.bunifuCustomLabel3.Size = new System.Drawing.Size(226, 23);
            this.bunifuCustomLabel3.TabIndex = 25;
            this.bunifuCustomLabel3.Text = "+ Add Room Category";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(30)))), ((int)(((byte)(66)))));
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_category,
            this.col_price,
            this.col_bed_no,
            this.col_id,
            this.col_description});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(30)))), ((int)(((byte)(66)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(80)))), ((int)(((byte)(86)))));
            this.dataGridView1.Location = new System.Drawing.Point(3, 65);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(449, 509);
            this.dataGridView1.TabIndex = 21;
            // 
            // col_category
            // 
            this.col_category.HeaderText = "Room Category";
            this.col_category.Name = "col_category";
            this.col_category.ReadOnly = true;
            this.col_category.Width = 155;
            // 
            // col_price
            // 
            this.col_price.HeaderText = "Room Price";
            this.col_price.Name = "col_price";
            this.col_price.ReadOnly = true;
            this.col_price.Visible = false;
            this.col_price.Width = 135;
            // 
            // col_bed_no
            // 
            this.col_bed_no.HeaderText = "No. Of Beds";
            this.col_bed_no.Name = "col_bed_no";
            this.col_bed_no.ReadOnly = true;
            this.col_bed_no.Width = 120;
            // 
            // col_id
            // 
            this.col_id.HeaderText = "Room Category Id";
            this.col_id.Name = "col_id";
            this.col_id.ReadOnly = true;
            this.col_id.Visible = false;
            // 
            // col_description
            // 
            this.col_description.HeaderText = "Description";
            this.col_description.Name = "col_description";
            this.col_description.ReadOnly = true;
            this.col_description.Width = 130;
            // 
            // bunifuCustomLabel1
            // 
            this.bunifuCustomLabel1.AutoSize = true;
            this.bunifuCustomLabel1.Font = new System.Drawing.Font("Georgia", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel1.ForeColor = System.Drawing.Color.White;
            this.bunifuCustomLabel1.Location = new System.Drawing.Point(96, 25);
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(165, 23);
            this.bunifuCustomLabel1.TabIndex = 17;
            this.bunifuCustomLabel1.Text = "Room Category";
            // 
            // btn_back
            // 
            this.btn_back.BackColor = System.Drawing.Color.MintCream;
            this.btn_back.FlatAppearance.BorderSize = 0;
            this.btn_back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_back.Image = global::POS_System.Properties.Resources.left_arrow_angle;
            this.btn_back.Location = new System.Drawing.Point(3, 3);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(66, 53);
            this.btn_back.TabIndex = 31;
            this.btn_back.UseVisualStyleBackColor = false;
            this.btn_back.Click += new System.EventHandler(this.btn_back_Click);
            // 
            // RoomCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "RoomCategory";
            this.Size = new System.Drawing.Size(752, 664);
            this.Load += new System.EventHandler(this.RoomCategory_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel27;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel25;
        private Bunifu.Framework.UI.BunifuMetroTextbox txt_category;
        private Bunifu.Framework.UI.BunifuMetroTextbox txt_beds;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel1;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel2;
        private System.Windows.Forms.RichTextBox rich_description;
        private Bunifu.Framework.UI.BunifuFlatButton btn_save;
        private System.Windows.Forms.DataGridView dataGridView1;
        private Bunifu.Framework.UI.BunifuFlatButton btn_delete;
        private Bunifu.Framework.UI.BunifuFlatButton btn_edit;
        private Bunifu.Framework.UI.BunifuFlatButton btn_update;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_category;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_price;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_bed_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_description;
        private System.Windows.Forms.Button btn_back;
    }
}