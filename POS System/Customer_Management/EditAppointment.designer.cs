namespace POS_System.Customer_Management
{
    partial class EditAppointment
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_back = new System.Windows.Forms.Button();
            this.lbl_addcategory = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.col_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_customerid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_tableno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_starttime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_endtime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_remaining = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_remaintime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_edit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.col_delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Location = new System.Drawing.Point(0, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(944, 612);
            this.panel1.TabIndex = 13;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(81)))), ((int)(((byte)(126)))));
            this.panel2.Controls.Add(this.btn_back);
            this.panel2.Controls.Add(this.lbl_addcategory);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(944, 68);
            this.panel2.TabIndex = 27;
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
            // 
            // lbl_addcategory
            // 
            this.lbl_addcategory.AutoSize = true;
            this.lbl_addcategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_addcategory.ForeColor = System.Drawing.Color.White;
            this.lbl_addcategory.Location = new System.Drawing.Point(341, 16);
            this.lbl_addcategory.Name = "lbl_addcategory";
            this.lbl_addcategory.Size = new System.Drawing.Size(207, 29);
            this.lbl_addcategory.TabIndex = 0;
            this.lbl_addcategory.Text = "Appointment List";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_id,
            this.col_customerid,
            this.col_tableno,
            this.col_starttime,
            this.col_endtime,
            this.col_remaining,
            this.col_remaintime,
            this.col_remark,
            this.col_status,
            this.col_edit,
            this.col_delete});
            this.dataGridView1.Location = new System.Drawing.Point(0, 75);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(944, 534);
            this.dataGridView1.TabIndex = 13;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // col_id
            // 
            this.col_id.HeaderText = "Id";
            this.col_id.Name = "col_id";
            this.col_id.ReadOnly = true;
            this.col_id.Visible = false;
            // 
            // col_customerid
            // 
            this.col_customerid.HeaderText = "Customer";
            this.col_customerid.Name = "col_customerid";
            this.col_customerid.ReadOnly = true;
            // 
            // col_tableno
            // 
            this.col_tableno.HeaderText = "Table No";
            this.col_tableno.Name = "col_tableno";
            this.col_tableno.ReadOnly = true;
            // 
            // col_starttime
            // 
            this.col_starttime.HeaderText = "Start Time";
            this.col_starttime.Name = "col_starttime";
            this.col_starttime.ReadOnly = true;
            this.col_starttime.Width = 80;
            // 
            // col_endtime
            // 
            this.col_endtime.HeaderText = "End Time";
            this.col_endtime.Name = "col_endtime";
            this.col_endtime.ReadOnly = true;
            this.col_endtime.Width = 80;
            // 
            // col_remaining
            // 
            this.col_remaining.HeaderText = "Remaining";
            this.col_remaining.Name = "col_remaining";
            this.col_remaining.ReadOnly = true;
            this.col_remaining.Width = 80;
            // 
            // col_remaintime
            // 
            this.col_remaintime.HeaderText = "Remain Time";
            this.col_remaintime.Name = "col_remaintime";
            this.col_remaintime.ReadOnly = true;
            this.col_remaintime.Width = 80;
            // 
            // col_remark
            // 
            this.col_remark.HeaderText = "Remarks";
            this.col_remark.Name = "col_remark";
            this.col_remark.ReadOnly = true;
            // 
            // col_status
            // 
            this.col_status.HeaderText = "Status";
            this.col_status.Name = "col_status";
            this.col_status.ReadOnly = true;
            // 
            // col_edit
            // 
            this.col_edit.HeaderText = "Edit";
            this.col_edit.Name = "col_edit";
            this.col_edit.ReadOnly = true;
            this.col_edit.Text = "Edit";
            this.col_edit.ToolTipText = "Edit";
            this.col_edit.UseColumnTextForButtonValue = true;
            // 
            // col_delete
            // 
            this.col_delete.HeaderText = "Delete";
            this.col_delete.Name = "col_delete";
            this.col_delete.ReadOnly = true;
            this.col_delete.Text = "Delete";
            this.col_delete.ToolTipText = "Delete";
            this.col_delete.UseColumnTextForButtonValue = true;
            // 
            // EditAppointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 616);
            this.Controls.Add(this.panel1);
            this.Name = "EditAppointment";
            this.Text = "ViewAppointment";
            this.Load += new System.EventHandler(this.ViewAppointment_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_back;
        private System.Windows.Forms.Label lbl_addcategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_customerid;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_tableno;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_starttime;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_endtime;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_remaining;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_remaintime;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_remark;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_status;
        private System.Windows.Forms.DataGridViewButtonColumn col_edit;
        private System.Windows.Forms.DataGridViewButtonColumn col_delete;
    }
}