namespace POS_System
{
    partial class UserControl_product_add
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btn_back = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtaddcategory = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dgv_category = new System.Windows.Forms.DataGridView();
            this.cal_category_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calcategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_edit = new DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtcategory_search = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btncategoryadd = new DevComponents.DotNetBar.ButtonX();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_category)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(81)))), ((int)(((byte)(126)))));
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.btn_back);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1024, 72);
            this.panel1.TabIndex = 61;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::POS_System.Properties.Resources.circle;
            this.pictureBox2.Location = new System.Drawing.Point(313, 6);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(69, 62);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 26;
            this.pictureBox2.TabStop = false;
            // 
            // btn_back
            // 
            this.btn_back.FlatAppearance.BorderSize = 0;
            this.btn_back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_back.Image = global::POS_System.Properties.Resources.back36;
            this.btn_back.Location = new System.Drawing.Point(3, 3);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(92, 65);
            this.btn_back.TabIndex = 20;
            this.btn_back.UseVisualStyleBackColor = true;
            this.btn_back.Click += new System.EventHandler(this.btn_back_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(388, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(249, 39);
            this.label8.TabIndex = 18;
            this.label8.Text = "Stock Category";
            // 
            // txtaddcategory
            // 
            this.txtaddcategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtaddcategory.Location = new System.Drawing.Point(716, 181);
            this.txtaddcategory.Name = "txtaddcategory";
            this.txtaddcategory.Size = new System.Drawing.Size(265, 30);
            this.txtaddcategory.TabIndex = 0;
            this.txtaddcategory.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtaddcategory_KeyDown);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(573, 185);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(119, 20);
            this.label9.TabIndex = 65;
            this.label9.Text = "Category Name";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(90, 4);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(125, 24);
            this.label10.TabIndex = 66;
            this.label10.Text = "Add Category";
            // 
            // dgv_category
            // 
            this.dgv_category.AllowUserToAddRows = false;
            this.dgv_category.AllowUserToDeleteRows = false;
            this.dgv_category.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_category.BackgroundColor = System.Drawing.Color.White;
            this.dgv_category.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_category.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cal_category_id,
            this.calcategory,
            this.cal_edit});
            this.dgv_category.Location = new System.Drawing.Point(47, 119);
            this.dgv_category.Name = "dgv_category";
            this.dgv_category.ReadOnly = true;
            this.dgv_category.RowHeadersVisible = false;
            this.dgv_category.Size = new System.Drawing.Size(443, 550);
            this.dgv_category.TabIndex = 67;
            this.dgv_category.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_category_CellContentClick);
   
         
            // 
            // cal_category_id
            // 
            this.cal_category_id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cal_category_id.FillWeight = 0.2830142F;
            this.cal_category_id.HeaderText = "Category Id";
            this.cal_category_id.Name = "cal_category_id";
            this.cal_category_id.ReadOnly = true;
            this.cal_category_id.Width = 70;
            // 
            // calcategory
            // 
            this.calcategory.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.calcategory.FillWeight = 9.880351F;
            this.calcategory.HeaderText = "Category Name";
            this.calcategory.Name = "calcategory";
            this.calcategory.ReadOnly = true;
            this.calcategory.Width = 285;
            // 
            // cal_edit
            // 
            this.cal_edit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cal_edit.FillWeight = 0.2453462F;
            this.cal_edit.HeaderText = "Edit";
            this.cal_edit.Name = "cal_edit";
            this.cal_edit.ReadOnly = true;
            this.cal_edit.Text = "Edit";
            this.cal_edit.UseColumnTextForButtonValue = true;
            this.cal_edit.Width = 80;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(81)))), ((int)(((byte)(126)))));
            this.panel2.Controls.Add(this.label10);
            this.panel2.Location = new System.Drawing.Point(716, 119);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(265, 34);
            this.panel2.TabIndex = 84;
            // 
            // txtcategory_search
            // 
            this.txtcategory_search.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcategory_search.Location = new System.Drawing.Point(161, 78);
            this.txtcategory_search.Name = "txtcategory_search";
            this.txtcategory_search.Size = new System.Drawing.Size(329, 29);
            this.txtcategory_search.TabIndex = 139;
            this.txtcategory_search.TextChanged += new System.EventHandler(this.txtcategory_search_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(36, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 20);
            this.label6.TabIndex = 138;
            this.label6.Text = "Category Name";
            // 
            // btncategoryadd
            // 
            this.btncategoryadd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btncategoryadd.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btncategoryadd.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncategoryadd.Location = new System.Drawing.Point(716, 225);
            this.btncategoryadd.Name = "btncategoryadd";
            this.btncategoryadd.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(15);
            this.btncategoryadd.Size = new System.Drawing.Size(159, 47);
            this.btncategoryadd.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btncategoryadd.Symbol = "";
            this.btncategoryadd.TabIndex = 143;
            this.btncategoryadd.Text = "Add Category";
            this.btncategoryadd.Click += new System.EventHandler(this.btncategoryadd_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(546, 90);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(467, 216);
            this.groupBox1.TabIndex = 144;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Stock Category";
            // 
            // UserControl_product_add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1011, 681);
            this.Controls.Add(this.btncategoryadd);
            this.Controls.Add(this.txtcategory_search);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dgv_category);
            this.Controls.Add(this.txtaddcategory);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Name = "UserControl_product_add";
            this.Load += new System.EventHandler(this.UserControl_product_add_Load_1);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_category)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btn_back;
        private System.Windows.Forms.TextBox txtaddcategory;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dgv_category;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox txtcategory_search;
        private System.Windows.Forms.Label label6;
        private DevComponents.DotNetBar.ButtonX btncategoryadd;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_category_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn calcategory;
        private DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn cal_edit;
    }
}
