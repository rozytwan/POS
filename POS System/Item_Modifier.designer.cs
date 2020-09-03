namespace POS_System
{
    partial class Item_Modifier
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
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.btnadd = new DevComponents.DotNetBar.ButtonX();
            this.cboitemcategory = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_kot_type = new System.Windows.Forms.TextBox();
            this.cbo_item_name = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_modifier_name = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtitemprice = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cal_modifier_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_sn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_item_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_category_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_item_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_modifier_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_update = new System.Windows.Forms.DataGridViewButtonColumn();
            this.cal_delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_back = new System.Windows.Forms.Button();
            this.label23 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbo_modifier_status = new System.Windows.Forms.ComboBox();
            this.panelEx1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panelEx2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.cbo_modifier_status);
            this.panelEx1.Controls.Add(this.label5);
            this.panelEx1.Controls.Add(this.btnadd);
            this.panelEx1.Controls.Add(this.cboitemcategory);
            this.panelEx1.Controls.Add(this.label10);
            this.panelEx1.Controls.Add(this.txt_kot_type);
            this.panelEx1.Controls.Add(this.cbo_item_name);
            this.panelEx1.Controls.Add(this.label4);
            this.panelEx1.Controls.Add(this.txt_modifier_name);
            this.panelEx1.Controls.Add(this.label6);
            this.panelEx1.Controls.Add(this.label11);
            this.panelEx1.Controls.Add(this.txtitemprice);
            this.panelEx1.Controls.Add(this.label3);
            this.panelEx1.Controls.Add(this.panel5);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelEx1.Location = new System.Drawing.Point(620, 77);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(385, 365);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.Color = System.Drawing.Color.White;
            this.panelEx1.Style.BackColor2.Color = System.Drawing.Color.White;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.Color = System.Drawing.Color.Silver;
            this.panelEx1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.panelEx1.Style.ForeColor.Color = System.Drawing.Color.White;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 4;
            // 
            // btnadd
            // 
            this.btnadd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnadd.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btnadd.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnadd.Location = new System.Drawing.Point(173, 304);
            this.btnadd.Name = "btnadd";
            this.btnadd.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(15);
            this.btnadd.Size = new System.Drawing.Size(96, 40);
            this.btnadd.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnadd.Symbol = "";
            this.btnadd.TabIndex = 156;
            this.btnadd.Text = "Add";
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // cboitemcategory
            // 
            this.cboitemcategory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboitemcategory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboitemcategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboitemcategory.FormattingEnabled = true;
            this.cboitemcategory.Location = new System.Drawing.Point(173, 53);
            this.cboitemcategory.Name = "cboitemcategory";
            this.cboitemcategory.Size = new System.Drawing.Size(203, 33);
            this.cboitemcategory.TabIndex = 154;
            this.cboitemcategory.SelectedIndexChanged += new System.EventHandler(this.cboitemcategory_SelectedIndexChanged);
            this.cboitemcategory.SelectionChangeCommitted += new System.EventHandler(this.cboitemcategory_SelectionChangeCommitted);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(3, 58);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(155, 20);
            this.label10.TabIndex = 155;
            this.label10.Text = "Item Category Name";
            // 
            // txt_kot_type
            // 
            this.txt_kot_type.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_kot_type.Location = new System.Drawing.Point(173, 180);
            this.txt_kot_type.Name = "txt_kot_type";
            this.txt_kot_type.ReadOnly = true;
            this.txt_kot_type.Size = new System.Drawing.Size(203, 31);
            this.txt_kot_type.TabIndex = 153;
            // 
            // cbo_item_name
            // 
            this.cbo_item_name.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbo_item_name.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbo_item_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_item_name.FormattingEnabled = true;
            this.cbo_item_name.Location = new System.Drawing.Point(173, 97);
            this.cbo_item_name.Name = "cbo_item_name";
            this.cbo_item_name.Size = new System.Drawing.Size(203, 33);
            this.cbo_item_name.TabIndex = 151;
            this.cbo_item_name.SelectedIndexChanged += new System.EventHandler(this.cbo_item_name_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(45, 230);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 20);
            this.label4.TabIndex = 150;
            this.label4.Text = "Modifier Name";
            // 
            // txt_modifier_name
            // 
            this.txt_modifier_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_modifier_name.Location = new System.Drawing.Point(173, 224);
            this.txt_modifier_name.Name = "txt_modifier_name";
            this.txt_modifier_name.Size = new System.Drawing.Size(203, 31);
            this.txt_modifier_name.TabIndex = 149;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(116, 190);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 20);
            this.label6.TabIndex = 148;
            this.label6.Text = "KOT";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(114, 146);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(44, 20);
            this.label11.TabIndex = 146;
            this.label11.Text = "Price";
            // 
            // txtitemprice
            // 
            this.txtitemprice.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtitemprice.Location = new System.Drawing.Point(173, 136);
            this.txtitemprice.Name = "txtitemprice";
            this.txtitemprice.ReadOnly = true;
            this.txtitemprice.Size = new System.Drawing.Size(203, 31);
            this.txtitemprice.TabIndex = 142;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(71, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 20);
            this.label3.TabIndex = 144;
            this.label3.Text = "Item Name";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(81)))), ((int)(((byte)(126)))));
            this.panel5.Controls.Add(this.label1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(385, 34);
            this.panel5.TabIndex = 110;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(90, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Add Menu Item Modifier";
            // 
            // panelEx2
            // 
            this.panelEx2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panelEx2.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx2.Controls.Add(this.dataGridView1);
            this.panelEx2.Controls.Add(this.panel1);
            this.panelEx2.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx2.Location = new System.Drawing.Point(4, 76);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Size = new System.Drawing.Size(615, 606);
            this.panelEx2.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx2.Style.BackColor1.Color = System.Drawing.Color.White;
            this.panelEx2.Style.BackColor2.Color = System.Drawing.Color.White;
            this.panelEx2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx2.Style.BorderColor.Color = System.Drawing.Color.Silver;
            this.panelEx2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.panelEx2.Style.ForeColor.Color = System.Drawing.Color.White;
            this.panelEx2.Style.GradientAngle = 90;
            this.panelEx2.TabIndex = 114;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cal_modifier_id,
            this.cal_sn,
            this.cal_item_id,
            this.cal_category_name,
            this.cal_item_name,
            this.cal_price,
            this.cal_modifier_name,
            this.cal_update,
            this.cal_delete});
            this.dataGridView1.Location = new System.Drawing.Point(0, 34);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 30;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.Size = new System.Drawing.Size(610, 569);
            this.dataGridView1.TabIndex = 111;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // cal_modifier_id
            // 
            this.cal_modifier_id.HeaderText = "Modifier Id";
            this.cal_modifier_id.Name = "cal_modifier_id";
            this.cal_modifier_id.Visible = false;
            // 
            // cal_sn
            // 
            this.cal_sn.HeaderText = "S.N";
            this.cal_sn.Name = "cal_sn";
            this.cal_sn.Width = 50;
            // 
            // cal_item_id
            // 
            this.cal_item_id.HeaderText = "Item Id";
            this.cal_item_id.Name = "cal_item_id";
            this.cal_item_id.Visible = false;
            // 
            // cal_category_name
            // 
            this.cal_category_name.HeaderText = "Cateogy Name";
            this.cal_category_name.Name = "cal_category_name";
            this.cal_category_name.Width = 125;
            // 
            // cal_item_name
            // 
            this.cal_item_name.HeaderText = "Item Name";
            this.cal_item_name.Name = "cal_item_name";
            this.cal_item_name.Width = 125;
            // 
            // cal_price
            // 
            this.cal_price.HeaderText = "Price";
            this.cal_price.Name = "cal_price";
            this.cal_price.Visible = false;
            // 
            // cal_modifier_name
            // 
            this.cal_modifier_name.HeaderText = "Modifier Name";
            this.cal_modifier_name.Name = "cal_modifier_name";
            this.cal_modifier_name.Width = 150;
            // 
            // cal_update
            // 
            this.cal_update.HeaderText = "Action";
            this.cal_update.Name = "cal_update";
            this.cal_update.Text = "Update";
            this.cal_update.UseColumnTextForButtonValue = true;
            this.cal_update.Width = 75;
            // 
            // cal_delete
            // 
            this.cal_delete.HeaderText = "Action";
            this.cal_delete.Name = "cal_delete";
            this.cal_delete.Text = "Delete";
            this.cal_delete.UseColumnTextForButtonValue = true;
            this.cal_delete.Width = 75;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(81)))), ((int)(((byte)(126)))));
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(615, 34);
            this.panel1.TabIndex = 110;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(216, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Table";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(81)))), ((int)(((byte)(126)))));
            this.panel4.Controls.Add(this.pictureBox1);
            this.panel4.Controls.Add(this.btn_back);
            this.panel4.Controls.Add(this.label23);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1008, 73);
            this.panel4.TabIndex = 121;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::POS_System.Properties.Resources.circle;
            this.pictureBox1.Location = new System.Drawing.Point(289, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(69, 62);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            // 
            // btn_back
            // 
            this.btn_back.FlatAppearance.BorderSize = 0;
            this.btn_back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_back.Image = global::POS_System.Properties.Resources.back36;
            this.btn_back.Location = new System.Drawing.Point(3, 5);
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
            this.label23.Location = new System.Drawing.Point(364, 14);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(307, 39);
            this.label23.TabIndex = 18;
            this.label23.Text = "Menu Item Modifier";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(45, 267);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 20);
            this.label5.TabIndex = 158;
            this.label5.Text = "Modifier Status";
            // 
            // cbo_modifier_status
            // 
            this.cbo_modifier_status.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbo_modifier_status.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbo_modifier_status.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_modifier_status.FormattingEnabled = true;
            this.cbo_modifier_status.Items.AddRange(new object[] {
            "None",
            "All"});
            this.cbo_modifier_status.Location = new System.Drawing.Point(173, 265);
            this.cbo_modifier_status.Name = "cbo_modifier_status";
            this.cbo_modifier_status.Size = new System.Drawing.Size(203, 33);
            this.cbo_modifier_status.TabIndex = 159;
            // 
            // Item_Modifier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panelEx2);
            this.Controls.Add(this.panelEx1);
            this.Name = "Item_Modifier";
            this.Size = new System.Drawing.Size(1008, 681);
            this.Load += new System.EventHandler(this.Item_Modifier_Load);
            this.panelEx1.ResumeLayout(false);
            this.panelEx1.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panelEx2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.PanelEx panelEx2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtitemprice;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_modifier_name;
        private System.Windows.Forms.TextBox txt_kot_type;
        private System.Windows.Forms.ComboBox cbo_item_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_modifier_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_sn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_item_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_category_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_item_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_price;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_modifier_name;
        private System.Windows.Forms.DataGridViewButtonColumn cal_update;
        private System.Windows.Forms.DataGridViewButtonColumn cal_delete;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_back;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.ComboBox cboitemcategory;
        private System.Windows.Forms.Label label10;
        private DevComponents.DotNetBar.ButtonX btnadd;
        private System.Windows.Forms.ComboBox cbo_modifier_status;
        private System.Windows.Forms.Label label5;
    }
}