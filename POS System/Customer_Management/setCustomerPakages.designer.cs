namespace POS_System.Customer_Management
{
    partial class setCustomerPakages
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv_customers = new System.Windows.Forms.DataGridView();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colgender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colphone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMobile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNationality = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colpakagename = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colStartingDate = new DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn();
            this.colnoofdays = new DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn();
            this.colSet = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colcancel = new System.Windows.Forms.DataGridViewButtonColumn();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_customers)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(81)))), ((int)(((byte)(126)))));
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(925, 54);
            this.panel1.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(891, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(34, 30);
            this.button1.TabIndex = 7;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(301, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(289, 24);
            this.label1.TabIndex = 6;
            this.label1.Text = "Choose Package For Member";
            // 
            // dgv_customers
            // 
            this.dgv_customers.AllowUserToAddRows = false;
            this.dgv_customers.AllowUserToDeleteRows = false;
            this.dgv_customers.AllowUserToOrderColumns = true;
            this.dgv_customers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_customers.BackgroundColor = System.Drawing.Color.White;
            this.dgv_customers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_customers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.colName,
            this.colLastName,
            this.colgender,
            this.colAddress,
            this.colphone,
            this.colMobile,
            this.colNationality,
            this.colpakagename,
            this.colStartingDate,
            this.colnoofdays,
            this.colSet,
            this.colcancel});
            this.dgv_customers.Location = new System.Drawing.Point(0, 54);
            this.dgv_customers.Name = "dgv_customers";
            this.dgv_customers.Size = new System.Drawing.Size(925, 505);
            this.dgv_customers.TabIndex = 8;
            this.dgv_customers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_customers_CellClick);
            // 
            // colID
            // 
            this.colID.HeaderText = "ID";
            this.colID.Name = "colID";
            this.colID.Visible = false;
            // 
            // colName
            // 
            this.colName.HeaderText = "Name";
            this.colName.Name = "colName";
            // 
            // colLastName
            // 
            this.colLastName.HeaderText = "Lastname";
            this.colLastName.Name = "colLastName";
            // 
            // colgender
            // 
            this.colgender.HeaderText = "Gender";
            this.colgender.Name = "colgender";
            // 
            // colAddress
            // 
            this.colAddress.HeaderText = "Address";
            this.colAddress.Name = "colAddress";
            // 
            // colphone
            // 
            this.colphone.HeaderText = "Phone";
            this.colphone.Name = "colphone";
            this.colphone.Visible = false;
            // 
            // colMobile
            // 
            this.colMobile.HeaderText = "Mobile";
            this.colMobile.Name = "colMobile";
            // 
            // colNationality
            // 
            this.colNationality.HeaderText = "Nationality";
            this.colNationality.Name = "colNationality";
            this.colNationality.Visible = false;
            // 
            // colpakagename
            // 
            this.colpakagename.DropDownWidth = 2;
            this.colpakagename.HeaderText = "Choose Package";
            this.colpakagename.Items.AddRange(new object[] {
            "a",
            "s",
            "d",
            "v",
            "v",
            "f",
            "g",
            "g"});
            this.colpakagename.Name = "colpakagename";
            this.colpakagename.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colpakagename.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colStartingDate
            // 
            // 
            // 
            // 
            this.colStartingDate.BackgroundStyle.Class = "DataGridViewDateTimeBorder";
            this.colStartingDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.colStartingDate.ButtonDropDown.Visible = true;
            this.colStartingDate.HeaderText = "From";
            this.colStartingDate.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left;
            // 
            // 
            // 
            this.colStartingDate.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.colStartingDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.colStartingDate.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            // 
            // 
            // 
            this.colStartingDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.colStartingDate.MonthCalendar.DisplayMonth = new System.DateTime(2016, 12, 1, 0, 0, 0, 0);
            this.colStartingDate.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.colStartingDate.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.colStartingDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.colStartingDate.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.colStartingDate.Name = "colStartingDate";
            // 
            // colnoofdays
            // 
            // 
            // 
            // 
            this.colnoofdays.BackgroundStyle.Class = "DataGridViewNumericBorder";
            this.colnoofdays.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.colnoofdays.HeaderText = "No. Of Days";
            this.colnoofdays.Name = "colnoofdays";
            this.colnoofdays.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // colSet
            // 
            this.colSet.HeaderText = "Set";
            this.colSet.Name = "colSet";
            this.colSet.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colSet.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colSet.Text = "Set";
            this.colSet.ToolTipText = "Set pakage for selectedCustomer";
            this.colSet.UseColumnTextForButtonValue = true;
            // 
            // colcancel
            // 
            this.colcancel.HeaderText = "Package Cancel";
            this.colcancel.Name = "colcancel";
            this.colcancel.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colcancel.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colcancel.Text = "Cancel";
            this.colcancel.ToolTipText = "Cancel Package for Selected Customer";
            this.colcancel.UseColumnTextForButtonValue = true;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // setCustomerPakages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(925, 560);
            this.Controls.Add(this.dgv_customers);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "setCustomerPakages";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pakage Choose Form";
            this.Load += new System.EventHandler(this.setCustomerPakages_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_customers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv_customers;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colgender;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn colphone;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMobile;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNationality;
        private System.Windows.Forms.DataGridViewComboBoxColumn colpakagename;
        private DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn colStartingDate;
        private DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn colnoofdays;
        private System.Windows.Forms.DataGridViewButtonColumn colSet;
        private System.Windows.Forms.DataGridViewButtonColumn colcancel;
    }
}