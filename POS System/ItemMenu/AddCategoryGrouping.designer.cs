namespace POS_System
{
    partial class AddCategoryGrouping
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
            this.btn_edit = new DevComponents.DotNetBar.ButtonX();
            this.btn_refresh = new DevComponents.DotNetBar.ButtonX();
            this.btn_save = new DevComponents.DotNetBar.ButtonX();
            this.btn_update = new DevComponents.DotNetBar.ButtonX();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel13 = new System.Windows.Forms.Panel();
            this.pn_displaybutton = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel23 = new System.Windows.Forms.Panel();
            this.btn_firebrick = new System.Windows.Forms.Button();
            this.btn_goldenrod = new System.Windows.Forms.Button();
            this.btn_darkblue = new System.Windows.Forms.Button();
            this.btn_limegreen = new System.Windows.Forms.Button();
            this.btn_darkgreen = new System.Windows.Forms.Button();
            this.btn_mediumblue = new System.Windows.Forms.Button();
            this.btn_maroon = new System.Windows.Forms.Button();
            this.btn_red = new System.Windows.Forms.Button();
            this.btn_blue = new System.Windows.Forms.Button();
            this.panel11 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.txt_group_name = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_back = new System.Windows.Forms.Button();
            this.lbl_addcategory = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.col_category_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_applicable_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel23.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel10.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.btn_edit);
            this.panel1.Controls.Add(this.btn_refresh);
            this.panel1.Controls.Add(this.btn_save);
            this.panel1.Controls.Add(this.btn_update);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.panel13);
            this.panel1.Controls.Add(this.panel11);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel10);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(960, 602);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btn_edit
            // 
            this.btn_edit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_edit.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btn_edit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_edit.Location = new System.Drawing.Point(20, 545);
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(15);
            this.btn_edit.Size = new System.Drawing.Size(116, 48);
            this.btn_edit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_edit.Symbol = "";
            this.btn_edit.TabIndex = 48;
            this.btn_edit.Text = "Edit";
            this.btn_edit.Click += new System.EventHandler(this.btn_edit_Click);
            // 
            // btn_refresh
            // 
            this.btn_refresh.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_refresh.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btn_refresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_refresh.Location = new System.Drawing.Point(535, 307);
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(15);
            this.btn_refresh.Size = new System.Drawing.Size(116, 48);
            this.btn_refresh.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_refresh.Symbol = "";
            this.btn_refresh.TabIndex = 47;
            this.btn_refresh.Text = "Refresh";
            this.btn_refresh.Click += new System.EventHandler(this.btn_refresh_Click);
            // 
            // btn_save
            // 
            this.btn_save.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_save.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btn_save.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save.Location = new System.Drawing.Point(672, 307);
            this.btn_save.Name = "btn_save";
            this.btn_save.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(15);
            this.btn_save.Size = new System.Drawing.Size(116, 48);
            this.btn_save.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_save.Symbol = "";
            this.btn_save.TabIndex = 46;
            this.btn_save.Text = "Save";
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_update
            // 
            this.btn_update.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_update.BackColor = System.Drawing.Color.Transparent;
            this.btn_update.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btn_update.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_update.Location = new System.Drawing.Point(809, 307);
            this.btn_update.Name = "btn_update";
            this.btn_update.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(15);
            this.btn_update.Size = new System.Drawing.Size(116, 48);
            this.btn_update.Symbol = "";
            this.btn_update.TabIndex = 45;
            this.btn_update.Text = "Update";
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_category_id,
            this.col_category,
            this.col_applicable_time});
            this.dataGridView1.Location = new System.Drawing.Point(20, 74);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(370, 453);
            this.dataGridView1.TabIndex = 41;
            // 
            // panel13
            // 
            this.panel13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel13.Controls.Add(this.pn_displaybutton);
            this.panel13.Controls.Add(this.pictureBox1);
            this.panel13.Controls.Add(this.panel23);
            this.panel13.Location = new System.Drawing.Point(592, 121);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(326, 180);
            this.panel13.TabIndex = 27;
            // 
            // pn_displaybutton
            // 
            this.pn_displaybutton.Location = new System.Drawing.Point(8, 9);
            this.pn_displaybutton.Name = "pn_displaybutton";
            this.pn_displaybutton.Size = new System.Drawing.Size(145, 152);
            this.pn_displaybutton.TabIndex = 9;
            // 
            // pictureBox1
            // 
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(8, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(145, 152);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // panel23
            // 
            this.panel23.Controls.Add(this.btn_firebrick);
            this.panel23.Controls.Add(this.btn_goldenrod);
            this.panel23.Controls.Add(this.btn_darkblue);
            this.panel23.Controls.Add(this.btn_limegreen);
            this.panel23.Controls.Add(this.btn_darkgreen);
            this.panel23.Controls.Add(this.btn_mediumblue);
            this.panel23.Controls.Add(this.btn_maroon);
            this.panel23.Controls.Add(this.btn_red);
            this.panel23.Controls.Add(this.btn_blue);
            this.panel23.Location = new System.Drawing.Point(160, 3);
            this.panel23.Name = "panel23";
            this.panel23.Size = new System.Drawing.Size(156, 137);
            this.panel23.TabIndex = 15;
            // 
            // btn_firebrick
            // 
            this.btn_firebrick.BackColor = System.Drawing.Color.Firebrick;
            this.btn_firebrick.FlatAppearance.BorderSize = 0;
            this.btn_firebrick.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_firebrick.Location = new System.Drawing.Point(56, 48);
            this.btn_firebrick.Name = "btn_firebrick";
            this.btn_firebrick.Size = new System.Drawing.Size(40, 40);
            this.btn_firebrick.TabIndex = 9;
            this.btn_firebrick.UseVisualStyleBackColor = false;
            this.btn_firebrick.Click += new System.EventHandler(this.btn_firebrick_Click);
            // 
            // btn_goldenrod
            // 
            this.btn_goldenrod.BackColor = System.Drawing.Color.Goldenrod;
            this.btn_goldenrod.FlatAppearance.BorderSize = 0;
            this.btn_goldenrod.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_goldenrod.Location = new System.Drawing.Point(102, 93);
            this.btn_goldenrod.Name = "btn_goldenrod";
            this.btn_goldenrod.Size = new System.Drawing.Size(40, 40);
            this.btn_goldenrod.TabIndex = 13;
            this.btn_goldenrod.UseVisualStyleBackColor = false;
            this.btn_goldenrod.Click += new System.EventHandler(this.btn_goldenrod_Click);
            // 
            // btn_darkblue
            // 
            this.btn_darkblue.BackColor = System.Drawing.Color.DarkBlue;
            this.btn_darkblue.FlatAppearance.BorderSize = 0;
            this.btn_darkblue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_darkblue.Location = new System.Drawing.Point(10, 2);
            this.btn_darkblue.Name = "btn_darkblue";
            this.btn_darkblue.Size = new System.Drawing.Size(40, 40);
            this.btn_darkblue.TabIndex = 5;
            this.btn_darkblue.UseVisualStyleBackColor = false;
            this.btn_darkblue.Click += new System.EventHandler(this.btn_darkblue_Click);
            // 
            // btn_limegreen
            // 
            this.btn_limegreen.BackColor = System.Drawing.Color.LimeGreen;
            this.btn_limegreen.FlatAppearance.BorderSize = 0;
            this.btn_limegreen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_limegreen.Location = new System.Drawing.Point(56, 93);
            this.btn_limegreen.Name = "btn_limegreen";
            this.btn_limegreen.Size = new System.Drawing.Size(40, 40);
            this.btn_limegreen.TabIndex = 12;
            this.btn_limegreen.UseVisualStyleBackColor = false;
            this.btn_limegreen.Click += new System.EventHandler(this.btn_limegreen_Click);
            // 
            // btn_darkgreen
            // 
            this.btn_darkgreen.BackColor = System.Drawing.Color.DarkGreen;
            this.btn_darkgreen.FlatAppearance.BorderSize = 0;
            this.btn_darkgreen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_darkgreen.Location = new System.Drawing.Point(10, 93);
            this.btn_darkgreen.Name = "btn_darkgreen";
            this.btn_darkgreen.Size = new System.Drawing.Size(40, 40);
            this.btn_darkgreen.TabIndex = 11;
            this.btn_darkgreen.UseVisualStyleBackColor = false;
            this.btn_darkgreen.Click += new System.EventHandler(this.btn_darkgreen_Click);
            // 
            // btn_mediumblue
            // 
            this.btn_mediumblue.BackColor = System.Drawing.Color.MediumBlue;
            this.btn_mediumblue.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_mediumblue.FlatAppearance.BorderSize = 0;
            this.btn_mediumblue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_mediumblue.Location = new System.Drawing.Point(56, 2);
            this.btn_mediumblue.Name = "btn_mediumblue";
            this.btn_mediumblue.Size = new System.Drawing.Size(40, 40);
            this.btn_mediumblue.TabIndex = 6;
            this.btn_mediumblue.UseVisualStyleBackColor = false;
            this.btn_mediumblue.Click += new System.EventHandler(this.btn_mediumblue_Click);
            // 
            // btn_maroon
            // 
            this.btn_maroon.BackColor = System.Drawing.Color.Maroon;
            this.btn_maroon.FlatAppearance.BorderSize = 0;
            this.btn_maroon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_maroon.Location = new System.Drawing.Point(10, 48);
            this.btn_maroon.Name = "btn_maroon";
            this.btn_maroon.Size = new System.Drawing.Size(40, 40);
            this.btn_maroon.TabIndex = 8;
            this.btn_maroon.UseVisualStyleBackColor = false;
            this.btn_maroon.Click += new System.EventHandler(this.btn_maroon_Click);
            // 
            // btn_red
            // 
            this.btn_red.BackColor = System.Drawing.Color.Red;
            this.btn_red.FlatAppearance.BorderSize = 0;
            this.btn_red.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_red.Location = new System.Drawing.Point(102, 48);
            this.btn_red.Name = "btn_red";
            this.btn_red.Size = new System.Drawing.Size(40, 40);
            this.btn_red.TabIndex = 10;
            this.btn_red.UseVisualStyleBackColor = false;
            this.btn_red.Click += new System.EventHandler(this.btn_red_Click);
            // 
            // btn_blue
            // 
            this.btn_blue.BackColor = System.Drawing.Color.Blue;
            this.btn_blue.FlatAppearance.BorderSize = 0;
            this.btn_blue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_blue.Location = new System.Drawing.Point(102, 2);
            this.btn_blue.Name = "btn_blue";
            this.btn_blue.Size = new System.Drawing.Size(40, 40);
            this.btn_blue.TabIndex = 7;
            this.btn_blue.UseVisualStyleBackColor = false;
            this.btn_blue.Click += new System.EventHandler(this.btn_blue_Click);
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.Gainsboro;
            this.panel11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel11.Controls.Add(this.label7);
            this.panel11.Location = new System.Drawing.Point(435, 121);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(155, 180);
            this.panel11.TabIndex = 28;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(27, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(112, 20);
            this.label7.TabIndex = 5;
            this.label7.Text = "Display Button";
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.txt_group_name);
            this.panel6.Location = new System.Drawing.Point(592, 74);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(326, 46);
            this.panel6.TabIndex = 27;
            // 
            // txt_group_name
            // 
            this.txt_group_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_group_name.Location = new System.Drawing.Point(3, 7);
            this.txt_group_name.Name = "txt_group_name";
            this.txt_group_name.Size = new System.Drawing.Size(318, 30);
            this.txt_group_name.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(81)))), ((int)(((byte)(126)))));
            this.panel2.Controls.Add(this.btn_back);
            this.panel2.Controls.Add(this.lbl_addcategory);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(960, 68);
            this.panel2.TabIndex = 26;
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
            this.lbl_addcategory.Size = new System.Drawing.Size(233, 29);
            this.lbl_addcategory.TabIndex = 0;
            this.lbl_addcategory.Text = "Category Grouping";
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.Gainsboro;
            this.panel10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel10.Controls.Add(this.label4);
            this.panel10.Location = new System.Drawing.Point(435, 74);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(155, 46);
            this.panel10.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(29, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "Group Name";
            // 
            // col_category_id
            // 
            this.col_category_id.HeaderText = "ID";
            this.col_category_id.Name = "col_category_id";
            this.col_category_id.ReadOnly = true;
            // 
            // col_category
            // 
            this.col_category.HeaderText = "Group Name";
            this.col_category.Name = "col_category";
            this.col_category.ReadOnly = true;
            this.col_category.Width = 225;
            // 
            // col_applicable_time
            // 
            this.col_applicable_time.HeaderText = "Applicable Time";
            this.col_applicable_time.Name = "col_applicable_time";
            this.col_applicable_time.ReadOnly = true;
            this.col_applicable_time.Visible = false;
            this.col_applicable_time.Width = 150;
            // 
            // AddCategoryGrouping
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 602);
            this.Controls.Add(this.panel1);
            this.Name = "AddCategoryGrouping";
            this.Load += new System.EventHandler(this.AddCategory_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel13.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel23.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbl_addcategory;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Panel panel23;
        private System.Windows.Forms.Button btn_firebrick;
        private System.Windows.Forms.Button btn_goldenrod;
        private System.Windows.Forms.Button btn_darkblue;
        private System.Windows.Forms.Button btn_limegreen;
        private System.Windows.Forms.Button btn_darkgreen;
        private System.Windows.Forms.Button btn_mediumblue;
        private System.Windows.Forms.Button btn_maroon;
        private System.Windows.Forms.Button btn_red;
        private System.Windows.Forms.Button btn_blue;
        private System.Windows.Forms.Panel pn_displaybutton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txt_group_name;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btn_back;
        private DevComponents.DotNetBar.ButtonX btn_update;
        private DevComponents.DotNetBar.ButtonX btn_refresh;
        private DevComponents.DotNetBar.ButtonX btn_save;
        private DevComponents.DotNetBar.ButtonX btn_edit;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_applicable_time;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_category;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_category_id;
    }
}
