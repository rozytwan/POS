namespace POS_System
{
    partial class HotelUserAccess
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_edit = new DevComponents.DotNetBar.ButtonX();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btn_add_new = new DevComponents.DotNetBar.ButtonX();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label24 = new System.Windows.Forms.Label();
            this.cal_user_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_sales = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cal_report = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cal_room_access = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cal_discount = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cal_admin = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cal_all = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cal_update = new System.Windows.Forms.DataGridViewButtonColumn();
            this.cal_user_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_edit);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.btn_add_new);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1031, 607);
            this.panel1.TabIndex = 0;
            // 
            // btn_edit
            // 
            this.btn_edit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_edit.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btn_edit.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_edit.Location = new System.Drawing.Point(896, 65);
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(15);
            this.btn_edit.Size = new System.Drawing.Size(110, 39);
            this.btn_edit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_edit.TabIndex = 301;
            this.btn_edit.Text = "Edit";
            this.btn_edit.Click += new System.EventHandler(this.btn_edit_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeight = 35;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cal_user_name,
            this.cal_sales,
            this.cal_report,
            this.cal_room_access,
            this.cal_discount,
            this.cal_admin,
            this.cal_all,
            this.cal_update,
            this.cal_user_id});
            this.dataGridView1.Location = new System.Drawing.Point(2, 110);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 30;
            this.dataGridView1.Size = new System.Drawing.Size(1026, 492);
            this.dataGridView1.TabIndex = 300;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // btn_add_new
            // 
            this.btn_add_new.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_add_new.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btn_add_new.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add_new.Location = new System.Drawing.Point(3, 65);
            this.btn_add_new.Name = "btn_add_new";
            this.btn_add_new.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(15);
            this.btn_add_new.Size = new System.Drawing.Size(168, 39);
            this.btn_add_new.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_add_new.TabIndex = 299;
            this.btn_add_new.Text = "Add New User";
            this.btn_add_new.Click += new System.EventHandler(this.btn_add_new_Click);
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
            this.panel2.Size = new System.Drawing.Size(1031, 59);
            this.panel2.TabIndex = 297;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::POS_System.Properties.Resources.back36;
            this.pictureBox5.Location = new System.Drawing.Point(3, 0);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(64, 59);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 26;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::POS_System.Properties.Resources.people;
            this.pictureBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox1.Location = new System.Drawing.Point(335, 2);
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
            this.label24.Location = new System.Drawing.Point(402, 11);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(246, 31);
            this.label24.TabIndex = 6;
            this.label24.Text = " Hotel User Access";
            // 
            // cal_user_name
            // 
            this.cal_user_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cal_user_name.HeaderText = "User Name";
            this.cal_user_name.Name = "cal_user_name";
            // 
            // cal_sales
            // 
            this.cal_sales.HeaderText = "Sales";
            this.cal_sales.Name = "cal_sales";
            // 
            // cal_report
            // 
            this.cal_report.HeaderText = "Report";
            this.cal_report.Name = "cal_report";
            // 
            // cal_room_access
            // 
            this.cal_room_access.HeaderText = "Room Access";
            this.cal_room_access.Name = "cal_room_access";
            // 
            // cal_discount
            // 
            this.cal_discount.HeaderText = "Discount";
            this.cal_discount.Name = "cal_discount";
            this.cal_discount.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cal_discount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // cal_admin
            // 
            this.cal_admin.HeaderText = "Admin";
            this.cal_admin.Name = "cal_admin";
            // 
            // cal_all
            // 
            this.cal_all.HeaderText = "ALL";
            this.cal_all.Name = "cal_all";
            this.cal_all.Visible = false;
            // 
            // cal_update
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.cal_update.DefaultCellStyle = dataGridViewCellStyle1;
            this.cal_update.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cal_update.HeaderText = "Update";
            this.cal_update.Name = "cal_update";
            this.cal_update.Text = "Update";
            this.cal_update.ToolTipText = "Update";
            this.cal_update.UseColumnTextForButtonValue = true;
            this.cal_update.Visible = false;
            // 
            // cal_user_id
            // 
            this.cal_user_id.HeaderText = "User Id";
            this.cal_user_id.Name = "cal_user_id";
            this.cal_user_id.Visible = false;
            // 
            // HotelUserAccess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "HotelUserAccess";
            this.Size = new System.Drawing.Size(1038, 615);
            this.Load += new System.EventHandler(this.HotelUserAccess_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label24;
        private DevComponents.DotNetBar.ButtonX btn_add_new;
        private DevComponents.DotNetBar.ButtonX btn_edit;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_user_name;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cal_sales;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cal_report;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cal_room_access;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cal_discount;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cal_admin;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cal_all;
        private System.Windows.Forms.DataGridViewButtonColumn cal_update;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_user_id;
    }
}