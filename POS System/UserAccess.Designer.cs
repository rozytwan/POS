namespace POS_System
{
    partial class UserAccess
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label24 = new System.Windows.Forms.Label();
            this.btn_edit = new DevComponents.DotNetBar.ButtonX();
            this.btn_add_new = new DevComponents.DotNetBar.ButtonX();
            this.cal_user_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_account = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cal_sales = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cal_report = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cal_stock = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cal_discount = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cal_admin = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.col_billing = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.col_bill_save = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.col_multibilling = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.col_itemtransfer = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.col_restaurant = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.col_hotel = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cal_all = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.col_table_transfer = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.col_dayend = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.col_cashdrop = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.col_itemcancel = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.col_menuupdate = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.col_takeaway = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.col_homedelivery = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cal_update = new System.Windows.Forms.DataGridViewButtonColumn();
            this.cal_user_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cal_user_name,
            this.cal_account,
            this.cal_sales,
            this.cal_report,
            this.cal_stock,
            this.cal_discount,
            this.cal_admin,
            this.col_billing,
            this.col_bill_save,
            this.col_multibilling,
            this.col_itemtransfer,
            this.col_restaurant,
            this.col_hotel,
            this.cal_all,
            this.col_table_transfer,
            this.col_dayend,
            this.col_cashdrop,
            this.col_itemcancel,
            this.col_menuupdate,
            this.col_takeaway,
            this.col_homedelivery,
            this.cal_update,
            this.cal_user_id});
            this.dataGridView1.Location = new System.Drawing.Point(1, 111);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 30;
            this.dataGridView1.Size = new System.Drawing.Size(1026, 492);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellMouseEnter);
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
            this.panel2.Size = new System.Drawing.Size(1027, 59);
            this.panel2.TabIndex = 296;
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
            this.pictureBox5.Click += new System.EventHandler(this.pictureBox5_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::POS_System.Properties.Resources.people;
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
            this.label24.Location = new System.Drawing.Point(488, 13);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(168, 31);
            this.label24.TabIndex = 6;
            this.label24.Text = "User Access";
            // 
            // btn_edit
            // 
            this.btn_edit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_edit.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btn_edit.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_edit.Location = new System.Drawing.Point(914, 66);
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(15);
            this.btn_edit.Size = new System.Drawing.Size(110, 39);
            this.btn_edit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_edit.TabIndex = 297;
            this.btn_edit.Text = "Edit";
            this.btn_edit.Click += new System.EventHandler(this.btn_edit_Click);
            // 
            // btn_add_new
            // 
            this.btn_add_new.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_add_new.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btn_add_new.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add_new.Location = new System.Drawing.Point(4, 66);
            this.btn_add_new.Name = "btn_add_new";
            this.btn_add_new.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(15);
            this.btn_add_new.Size = new System.Drawing.Size(168, 39);
            this.btn_add_new.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_add_new.TabIndex = 298;
            this.btn_add_new.Text = "Add New User";
            this.btn_add_new.Click += new System.EventHandler(this.btn_add_new_Click);
            // 
            // cal_user_name
            // 
            this.cal_user_name.HeaderText = "User Name";
            this.cal_user_name.Name = "cal_user_name";
            this.cal_user_name.Width = 120;
            // 
            // cal_account
            // 
            this.cal_account.HeaderText = "Account";
            this.cal_account.Name = "cal_account";
            this.cal_account.Width = 70;
            // 
            // cal_sales
            // 
            this.cal_sales.HeaderText = "Sales";
            this.cal_sales.Name = "cal_sales";
            this.cal_sales.Width = 70;
            // 
            // cal_report
            // 
            this.cal_report.HeaderText = "Report";
            this.cal_report.Name = "cal_report";
            this.cal_report.Width = 70;
            // 
            // cal_stock
            // 
            this.cal_stock.HeaderText = "Stock";
            this.cal_stock.Name = "cal_stock";
            this.cal_stock.Width = 70;
            // 
            // cal_discount
            // 
            this.cal_discount.HeaderText = "Discount";
            this.cal_discount.Name = "cal_discount";
            this.cal_discount.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cal_discount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.cal_discount.Width = 70;
            // 
            // cal_admin
            // 
            this.cal_admin.HeaderText = "Admin";
            this.cal_admin.Name = "cal_admin";
            this.cal_admin.Width = 70;
            // 
            // col_billing
            // 
            this.col_billing.HeaderText = "Billing";
            this.col_billing.Name = "col_billing";
            this.col_billing.Width = 70;
            // 
            // col_bill_save
            // 
            this.col_bill_save.HeaderText = "Billing(Save)";
            this.col_bill_save.Name = "col_bill_save";
            // 
            // col_multibilling
            // 
            this.col_multibilling.HeaderText = "Multi Billing";
            this.col_multibilling.Name = "col_multibilling";
            this.col_multibilling.Width = 70;
            // 
            // col_itemtransfer
            // 
            this.col_itemtransfer.HeaderText = "Item Transfer";
            this.col_itemtransfer.Name = "col_itemtransfer";
            this.col_itemtransfer.Width = 70;
            // 
            // col_restaurant
            // 
            this.col_restaurant.HeaderText = "Restaurant";
            this.col_restaurant.Name = "col_restaurant";
            this.col_restaurant.Width = 70;
            // 
            // col_hotel
            // 
            this.col_hotel.HeaderText = "Hotel";
            this.col_hotel.Name = "col_hotel";
            this.col_hotel.Width = 70;
            // 
            // cal_all
            // 
            this.cal_all.HeaderText = "ALL";
            this.cal_all.Name = "cal_all";
            this.cal_all.Visible = false;
            this.cal_all.Width = 70;
            // 
            // col_table_transfer
            // 
            this.col_table_transfer.HeaderText = "Table Transfer";
            this.col_table_transfer.Name = "col_table_transfer";
            this.col_table_transfer.Width = 70;
            // 
            // col_dayend
            // 
            this.col_dayend.HeaderText = "DayEnd";
            this.col_dayend.Name = "col_dayend";
            this.col_dayend.Width = 70;
            // 
            // col_cashdrop
            // 
            this.col_cashdrop.HeaderText = "Cash Drop";
            this.col_cashdrop.Name = "col_cashdrop";
            this.col_cashdrop.Width = 70;
            // 
            // col_itemcancel
            // 
            this.col_itemcancel.HeaderText = "Item Cancel";
            this.col_itemcancel.Name = "col_itemcancel";
            this.col_itemcancel.Width = 70;
            // 
            // col_menuupdate
            // 
            this.col_menuupdate.HeaderText = "Menu Update";
            this.col_menuupdate.Name = "col_menuupdate";
            this.col_menuupdate.Width = 70;
            // 
            // col_takeaway
            // 
            this.col_takeaway.HeaderText = "Take Away";
            this.col_takeaway.Name = "col_takeaway";
            this.col_takeaway.Width = 70;
            // 
            // col_homedelivery
            // 
            this.col_homedelivery.HeaderText = "Home Delivery";
            this.col_homedelivery.Name = "col_homedelivery";
            this.col_homedelivery.Width = 70;
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
            this.cal_update.Width = 80;
            // 
            // cal_user_id
            // 
            this.cal_user_id.HeaderText = "User Id";
            this.cal_user_id.Name = "cal_user_id";
            this.cal_user_id.Visible = false;
            // 
            // UserAccess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btn_add_new);
            this.Controls.Add(this.btn_edit);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dataGridView1);
            this.Name = "UserAccess";
            this.Size = new System.Drawing.Size(1027, 720);
            this.Load += new System.EventHandler(this.UserAccess_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label24;
        private DevComponents.DotNetBar.ButtonX btn_edit;
        private DevComponents.DotNetBar.ButtonX btn_add_new;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_user_name;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cal_account;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cal_sales;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cal_report;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cal_stock;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cal_discount;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cal_admin;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_billing;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_bill_save;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_multibilling;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_itemtransfer;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_restaurant;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_hotel;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cal_all;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_table_transfer;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_dayend;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_cashdrop;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_itemcancel;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_menuupdate;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_takeaway;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_homedelivery;
        private System.Windows.Forms.DataGridViewButtonColumn cal_update;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_user_id;
    }
}