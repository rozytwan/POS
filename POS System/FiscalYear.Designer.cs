namespace POS_System
{
    partial class FiscalYear
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btn_new_fiscal_year = new DevComponents.DotNetBar.ButtonX();
            this.btn_end_fiscal_year = new DevComponents.DotNetBar.ButtonX();
            this.cal_fiscal_year_start = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_fiscal_year_to_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_is_active = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cal_fiscal_year_start,
            this.cal_fiscal_year_to_date,
            this.cal_is_active,
            this.col_id});
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(353, 397);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // btn_new_fiscal_year
            // 
            this.btn_new_fiscal_year.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_new_fiscal_year.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btn_new_fiscal_year.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_new_fiscal_year.Location = new System.Drawing.Point(12, 415);
            this.btn_new_fiscal_year.Name = "btn_new_fiscal_year";
            this.btn_new_fiscal_year.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(15);
            this.btn_new_fiscal_year.Size = new System.Drawing.Size(171, 48);
            this.btn_new_fiscal_year.TabIndex = 385;
            this.btn_new_fiscal_year.Text = "Add New Fiscal Year";
            this.btn_new_fiscal_year.Click += new System.EventHandler(this.btn_new_fiscal_year_Click);
            // 
            // btn_end_fiscal_year
            // 
            this.btn_end_fiscal_year.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_end_fiscal_year.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btn_end_fiscal_year.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_end_fiscal_year.Location = new System.Drawing.Point(189, 415);
            this.btn_end_fiscal_year.Name = "btn_end_fiscal_year";
            this.btn_end_fiscal_year.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(15);
            this.btn_end_fiscal_year.Size = new System.Drawing.Size(176, 48);
            this.btn_end_fiscal_year.TabIndex = 386;
            this.btn_end_fiscal_year.Text = "End Fiscal Year";
            this.btn_end_fiscal_year.Click += new System.EventHandler(this.btn_end_fiscal_year_Click);
            // 
            // cal_fiscal_year_start
            // 
            this.cal_fiscal_year_start.HeaderText = "Fiscal Year From Date";
            this.cal_fiscal_year_start.Name = "cal_fiscal_year_start";
            this.cal_fiscal_year_start.ReadOnly = true;
            this.cal_fiscal_year_start.Width = 126;
            // 
            // cal_fiscal_year_to_date
            // 
            this.cal_fiscal_year_to_date.HeaderText = "Fiscal Year To Date";
            this.cal_fiscal_year_to_date.Name = "cal_fiscal_year_to_date";
            this.cal_fiscal_year_to_date.ReadOnly = true;
            this.cal_fiscal_year_to_date.Width = 127;
            // 
            // cal_is_active
            // 
            this.cal_is_active.HeaderText = "Is Active";
            this.cal_is_active.Name = "cal_is_active";
            this.cal_is_active.ReadOnly = true;
            // 
            // col_id
            // 
            this.col_id.HeaderText = "id";
            this.col_id.Name = "col_id";
            this.col_id.ReadOnly = true;
            // 
            // FiscalYear
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(387, 475);
            this.Controls.Add(this.btn_end_fiscal_year);
            this.Controls.Add(this.btn_new_fiscal_year);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FiscalYear";
            this.Text = "FiscalYear";
            this.Load += new System.EventHandler(this.FiscalYear_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevComponents.DotNetBar.ButtonX btn_new_fiscal_year;
        private DevComponents.DotNetBar.ButtonX btn_end_fiscal_year;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_fiscal_year_start;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_fiscal_year_to_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_is_active;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_id;
    }
}