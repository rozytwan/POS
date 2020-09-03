namespace POS_System.Customer_Management
{
    partial class CustomerAttendance
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
            this.dgv_customers = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_package = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_customername = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colgender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colpakagename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coladdress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colphone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colmobile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colstartingdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colnoofdays = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colsetAttendance = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colViewDetails = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_customers)).BeginInit();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_customers
            // 
            this.dgv_customers.AllowUserToAddRows = false;
            this.dgv_customers.AllowUserToDeleteRows = false;
            this.dgv_customers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_customers.BackgroundColor = System.Drawing.Color.White;
            this.dgv_customers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_customers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.colImage,
            this.colName,
            this.colLastName,
            this.colgender,
            this.colpakagename,
            this.coladdress,
            this.colphone,
            this.colmobile,
            this.colstartingdate,
            this.colnoofdays,
            this.colsetAttendance,
            this.colViewDetails});
            this.dgv_customers.Location = new System.Drawing.Point(6, 119);
            this.dgv_customers.Name = "dgv_customers";
            this.dgv_customers.ReadOnly = true;
            this.dgv_customers.RowHeadersVisible = false;
            this.dgv_customers.RowTemplate.Height = 60;
            this.dgv_customers.Size = new System.Drawing.Size(774, 510);
            this.dgv_customers.TabIndex = 5;
            this.dgv_customers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_customers_CellClick);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(81)))), ((int)(((byte)(126)))));
            this.panel2.Controls.Add(this.label9);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(786, 59);
            this.panel2.TabIndex = 103;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(318, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(180, 25);
            this.label9.TabIndex = 0;
            this.label9.Text = "Mess Attendance";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_package);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txt_customername);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(47, 64);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(689, 50);
            this.groupBox1.TabIndex = 104;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search By";
            // 
            // txt_package
            // 
            this.txt_package.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_package.Location = new System.Drawing.Point(445, 13);
            this.txt_package.Name = "txt_package";
            this.txt_package.Size = new System.Drawing.Size(238, 24);
            this.txt_package.TabIndex = 3;
            this.txt_package.TextChanged += new System.EventHandler(this.txt_package_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(376, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Package:";
            // 
            // txt_customername
            // 
            this.txt_customername.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_customername.Location = new System.Drawing.Point(77, 16);
            this.txt_customername.Name = "txt_customername";
            this.txt_customername.Size = new System.Drawing.Size(238, 24);
            this.txt_customername.TabIndex = 1;
            this.txt_customername.TextChanged += new System.EventHandler(this.txt_customername_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // colID
            // 
            this.colID.HeaderText = "Customer Id";
            this.colID.Name = "colID";
            this.colID.ReadOnly = true;
            this.colID.Visible = false;
            // 
            // colImage
            // 
            this.colImage.HeaderText = "Image";
            this.colImage.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.colImage.Name = "colImage";
            this.colImage.ReadOnly = true;
            // 
            // colName
            // 
            this.colName.HeaderText = "Name";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            // 
            // colLastName
            // 
            this.colLastName.HeaderText = "LastName";
            this.colLastName.Name = "colLastName";
            this.colLastName.ReadOnly = true;
            // 
            // colgender
            // 
            this.colgender.HeaderText = "Gender";
            this.colgender.Name = "colgender";
            this.colgender.ReadOnly = true;
            // 
            // colpakagename
            // 
            this.colpakagename.HeaderText = "Pakage";
            this.colpakagename.Name = "colpakagename";
            this.colpakagename.ReadOnly = true;
            // 
            // coladdress
            // 
            this.coladdress.HeaderText = "Address";
            this.coladdress.Name = "coladdress";
            this.coladdress.ReadOnly = true;
            this.coladdress.Visible = false;
            // 
            // colphone
            // 
            this.colphone.HeaderText = "Phone";
            this.colphone.Name = "colphone";
            this.colphone.ReadOnly = true;
            this.colphone.Visible = false;
            // 
            // colmobile
            // 
            this.colmobile.HeaderText = "Mobile";
            this.colmobile.Name = "colmobile";
            this.colmobile.ReadOnly = true;
            this.colmobile.Visible = false;
            // 
            // colstartingdate
            // 
            this.colstartingdate.HeaderText = "Starting Date";
            this.colstartingdate.Name = "colstartingdate";
            this.colstartingdate.ReadOnly = true;
            // 
            // colnoofdays
            // 
            this.colnoofdays.HeaderText = "No of days";
            this.colnoofdays.Name = "colnoofdays";
            this.colnoofdays.ReadOnly = true;
            // 
            // colsetAttendance
            // 
            this.colsetAttendance.HeaderText = "Attendance";
            this.colsetAttendance.Name = "colsetAttendance";
            this.colsetAttendance.ReadOnly = true;
            this.colsetAttendance.Text = "Set Attendance";
            this.colsetAttendance.ToolTipText = "set Attendance to selected Customer";
            this.colsetAttendance.UseColumnTextForButtonValue = true;
            // 
            // colViewDetails
            // 
            this.colViewDetails.HeaderText = "View Details";
            this.colViewDetails.Name = "colViewDetails";
            this.colViewDetails.ReadOnly = true;
            this.colViewDetails.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colViewDetails.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colViewDetails.Text = "View Details";
            this.colViewDetails.ToolTipText = "View Customer Report on Mess Packages";
            this.colViewDetails.UseColumnTextForButtonValue = true;
            // 
            // CustomerAttendance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dgv_customers);
            this.Name = "CustomerAttendance";
            this.Size = new System.Drawing.Size(786, 641);
            this.Load += new System.EventHandler(this.CustomerAttendance_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_customers)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_customers;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_package;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_customername;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewImageColumn colImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colgender;
        private System.Windows.Forms.DataGridViewTextBoxColumn colpakagename;
        private System.Windows.Forms.DataGridViewTextBoxColumn coladdress;
        private System.Windows.Forms.DataGridViewTextBoxColumn colphone;
        private System.Windows.Forms.DataGridViewTextBoxColumn colmobile;
        private System.Windows.Forms.DataGridViewTextBoxColumn colstartingdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colnoofdays;
        private System.Windows.Forms.DataGridViewButtonColumn colsetAttendance;
        private System.Windows.Forms.DataGridViewButtonColumn colViewDetails;
    }
}