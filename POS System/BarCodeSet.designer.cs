namespace POS_System
{
    partial class BarCodeSet
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cal_sn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calitem_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_bar_code_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calitem_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_product_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_product_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_bar_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_update = new System.Windows.Forms.DataGridViewButtonColumn();
            this.cal_delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnadd = new DevComponents.DotNetBar.ButtonX();
            this.label6 = new System.Windows.Forms.Label();
            this.txtbar_code = new System.Windows.Forms.TextBox();
            this.cboItem_Name = new System.Windows.Forms.ComboBox();
            this.cboitemcategory = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cbocategorynamess = new System.Windows.Forms.ComboBox();
            this.cboproductname = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label24 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cal_sn,
            this.calitem_id,
            this.cal_bar_code_id,
            this.calitem_name,
            this.cal_product_name,
            this.cal_product_id,
            this.cal_bar_code,
            this.cal_update,
            this.cal_delete});
            this.dataGridView1.Location = new System.Drawing.Point(2, 71);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 50;
            this.dataGridView1.Size = new System.Drawing.Size(515, 567);
            this.dataGridView1.TabIndex = 108;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // cal_sn
            // 
            this.cal_sn.FillWeight = 50F;
            this.cal_sn.HeaderText = "S.N";
            this.cal_sn.Name = "cal_sn";
            // 
            // calitem_id
            // 
            this.calitem_id.FillWeight = 58.31595F;
            this.calitem_id.HeaderText = "Item ID";
            this.calitem_id.Name = "calitem_id";
            this.calitem_id.ReadOnly = true;
            this.calitem_id.Visible = false;
            // 
            // cal_bar_code_id
            // 
            this.cal_bar_code_id.HeaderText = "Barcode Id";
            this.cal_bar_code_id.Name = "cal_bar_code_id";
            this.cal_bar_code_id.Visible = false;
            // 
            // calitem_name
            // 
            this.calitem_name.FillWeight = 136.802F;
            this.calitem_name.HeaderText = "Item Name";
            this.calitem_name.Name = "calitem_name";
            // 
            // cal_product_name
            // 
            this.cal_product_name.HeaderText = "Product Name";
            this.cal_product_name.Name = "cal_product_name";
            // 
            // cal_product_id
            // 
            this.cal_product_id.HeaderText = "Product Id";
            this.cal_product_id.Name = "cal_product_id";
            this.cal_product_id.Visible = false;
            // 
            // cal_bar_code
            // 
            this.cal_bar_code.HeaderText = "Bar Code";
            this.cal_bar_code.Name = "cal_bar_code";
            // 
            // cal_update
            // 
            this.cal_update.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cal_update.HeaderText = "Update";
            this.cal_update.Name = "cal_update";
            this.cal_update.Text = "Update";
            this.cal_update.UseColumnTextForButtonValue = true;
            // 
            // cal_delete
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            this.cal_delete.DefaultCellStyle = dataGridViewCellStyle1;
            this.cal_delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cal_delete.HeaderText = "Delete";
            this.cal_delete.Name = "cal_delete";
            this.cal_delete.Text = "Delete";
            this.cal_delete.UseColumnTextForButtonValue = true;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.btnadd);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.txtbar_code);
            this.panel4.Controls.Add(this.cboItem_Name);
            this.panel4.Controls.Add(this.cboitemcategory);
            this.panel4.Controls.Add(this.label10);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.panel6);
            this.panel4.Location = new System.Drawing.Point(523, 230);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(463, 235);
            this.panel4.TabIndex = 110;
            // 
            // btnadd
            // 
            this.btnadd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnadd.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btnadd.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnadd.Location = new System.Drawing.Point(350, 181);
            this.btnadd.Name = "btnadd";
            this.btnadd.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(15);
            this.btnadd.Size = new System.Drawing.Size(90, 49);
            this.btnadd.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnadd.Symbol = "";
            this.btnadd.TabIndex = 151;
            this.btnadd.Text = "Add";
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(75, 152);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 20);
            this.label6.TabIndex = 150;
            this.label6.Text = "Bar Code";
            // 
            // txtbar_code
            // 
            this.txtbar_code.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbar_code.Location = new System.Drawing.Point(167, 145);
            this.txtbar_code.Name = "txtbar_code";
            this.txtbar_code.Size = new System.Drawing.Size(273, 30);
            this.txtbar_code.TabIndex = 149;
            // 
            // cboItem_Name
            // 
            this.cboItem_Name.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboItem_Name.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboItem_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboItem_Name.FormattingEnabled = true;
            this.cboItem_Name.Location = new System.Drawing.Point(167, 95);
            this.cboItem_Name.Name = "cboItem_Name";
            this.cboItem_Name.Size = new System.Drawing.Size(273, 32);
            this.cboItem_Name.TabIndex = 108;
            // 
            // cboitemcategory
            // 
            this.cboitemcategory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboitemcategory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboitemcategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboitemcategory.FormattingEnabled = true;
            this.cboitemcategory.Location = new System.Drawing.Point(167, 47);
            this.cboitemcategory.Name = "cboitemcategory";
            this.cboitemcategory.Size = new System.Drawing.Size(273, 32);
            this.cboitemcategory.TabIndex = 104;
            this.cboitemcategory.SelectedIndexChanged += new System.EventHandler(this.cboitemcategory_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(6, 53);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(155, 20);
            this.label10.TabIndex = 107;
            this.label10.Text = "Item Category Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(71, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 20);
            this.label2.TabIndex = 106;
            this.label2.Text = "Item Name";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(81)))), ((int)(((byte)(126)))));
            this.panel6.Controls.Add(this.label1);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(461, 34);
            this.panel6.TabIndex = 110;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(156, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Restaurant (Menu)";
            // 
            // cbocategorynamess
            // 
            this.cbocategorynamess.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbocategorynamess.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbocategorynamess.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbocategorynamess.FormattingEnabled = true;
            this.cbocategorynamess.Location = new System.Drawing.Point(155, 40);
            this.cbocategorynamess.Name = "cbocategorynamess";
            this.cbocategorynamess.Size = new System.Drawing.Size(273, 33);
            this.cbocategorynamess.TabIndex = 138;
            this.cbocategorynamess.SelectedIndexChanged += new System.EventHandler(this.cbocategorynamess_SelectedIndexChanged);
            // 
            // cboproductname
            // 
            this.cboproductname.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboproductname.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboproductname.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboproductname.FormattingEnabled = true;
            this.cboproductname.Location = new System.Drawing.Point(155, 88);
            this.cboproductname.Name = "cboproductname";
            this.cboproductname.Size = new System.Drawing.Size(273, 33);
            this.cboproductname.TabIndex = 139;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(33, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 20);
            this.label4.TabIndex = 140;
            this.label4.Text = "Product Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(19, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 20);
            this.label5.TabIndex = 141;
            this.label5.Text = "Catagory Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(150, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(164, 25);
            this.label3.TabIndex = 0;
            this.label3.Text = "Inventory Product";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.cbocategorynamess);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.cboproductname);
            this.panel3.Location = new System.Drawing.Point(523, 71);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(463, 153);
            this.panel3.TabIndex = 109;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(81)))), ((int)(((byte)(126)))));
            this.panel5.Controls.Add(this.label3);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(461, 34);
            this.panel5.TabIndex = 109;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(81)))), ((int)(((byte)(126)))));
            this.panel2.Controls.Add(this.pictureBox5);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.label24);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(992, 66);
            this.panel2.TabIndex = 296;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::POS_System.Properties.Resources.back36;
            this.pictureBox5.Location = new System.Drawing.Point(3, 4);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(64, 59);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 26;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.Click += new System.EventHandler(this.pictureBox5_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::POS_System.Properties.Resources.bar_code__1_;
            this.pictureBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox1.Location = new System.Drawing.Point(421, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(52, 53);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label24.ForeColor = System.Drawing.Color.White;
            this.label24.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label24.Location = new System.Drawing.Point(488, 18);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(128, 31);
            this.label24.TabIndex = 6;
            this.label24.Text = "Bar Code";
            // 
            // BarCodeSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.dataGridView1);
            this.Name = "BarCodeSet";
            this.Size = new System.Drawing.Size(992, 642);
            this.Load += new System.EventHandler(this.BarCodeSet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ComboBox cbocategorynamess;
        private System.Windows.Forms.ComboBox cboproductname;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboItem_Name;
        private System.Windows.Forms.ComboBox cboitemcategory;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtbar_code;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_sn;
        private System.Windows.Forms.DataGridViewTextBoxColumn calitem_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_bar_code_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn calitem_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_product_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_product_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_bar_code;
        private System.Windows.Forms.DataGridViewButtonColumn cal_update;
        private System.Windows.Forms.DataGridViewButtonColumn cal_delete;
        private DevComponents.DotNetBar.ButtonX btnadd;
    }
}