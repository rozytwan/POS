namespace POS_System
{
    partial class CustomerDetail
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_back = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btn_excel = new DevComponents.DotNetBar.ButtonX();
            this.btn_export_to_pdf = new DevComponents.DotNetBar.ButtonX();
            this.txt_search = new System.Windows.Forms.TextBox();
            this.lbl_search = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lbl_remaining = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbl_credit = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_paid = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.col_customer_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_customer_phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_customer_address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_credit_amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_paid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_remaining = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_customer_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_view = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(81)))), ((int)(((byte)(126)))));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.btn_back);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1027, 75);
            this.panel1.TabIndex = 62;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::POS_System.Properties.Resources.controls1;
            this.pictureBox1.Location = new System.Drawing.Point(302, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(71, 68);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // btn_back
            // 
            this.btn_back.FlatAppearance.BorderSize = 0;
            this.btn_back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_back.Image = global::POS_System.Properties.Resources.back36;
            this.btn_back.Location = new System.Drawing.Point(-5, 5);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(92, 65);
            this.btn_back.TabIndex = 20;
            this.btn_back.UseVisualStyleBackColor = true;
            this.btn_back.Click += new System.EventHandler(this.btn_back_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(379, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(326, 39);
            this.label2.TabIndex = 18;
            this.label2.Text = "Customer Credit List";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_customer_name,
            this.col_customer_phone,
            this.col_customer_address,
            this.col_credit_amount,
            this.col_paid,
            this.col_remaining,
            this.col_customer_id,
            this.col_view});
            this.dataGridView1.Location = new System.Drawing.Point(3, 116);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(1021, 463);
            this.dataGridView1.TabIndex = 63;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // btn_excel
            // 
            this.btn_excel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_excel.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btn_excel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_excel.Location = new System.Drawing.Point(598, 639);
            this.btn_excel.Name = "btn_excel";
            this.btn_excel.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(14);
            this.btn_excel.Size = new System.Drawing.Size(182, 50);
            this.btn_excel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_excel.Symbol = "";
            this.btn_excel.TabIndex = 145;
            this.btn_excel.Text = "Export to Excel";
            this.btn_excel.Click += new System.EventHandler(this.btn_excel_Click);
            // 
            // btn_export_to_pdf
            // 
            this.btn_export_to_pdf.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_export_to_pdf.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btn_export_to_pdf.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_export_to_pdf.Location = new System.Drawing.Point(795, 640);
            this.btn_export_to_pdf.Name = "btn_export_to_pdf";
            this.btn_export_to_pdf.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(14);
            this.btn_export_to_pdf.Size = new System.Drawing.Size(203, 50);
            this.btn_export_to_pdf.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_export_to_pdf.Symbol = "";
            this.btn_export_to_pdf.TabIndex = 144;
            this.btn_export_to_pdf.Text = "Export to PDF";
            this.btn_export_to_pdf.Click += new System.EventHandler(this.btn_export_to_pdf_Click);
            // 
            // txt_search
            // 
            this.txt_search.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_search.Location = new System.Drawing.Point(772, 81);
            this.txt_search.Name = "txt_search";
            this.txt_search.Size = new System.Drawing.Size(243, 29);
            this.txt_search.TabIndex = 146;
            this.txt_search.TextChanged += new System.EventHandler(this.txt_search_TextChanged);
            // 
            // lbl_search
            // 
            this.lbl_search.AutoSize = true;
            this.lbl_search.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_search.ForeColor = System.Drawing.Color.White;
            this.lbl_search.Location = new System.Drawing.Point(660, 87);
            this.lbl_search.Name = "lbl_search";
            this.lbl_search.Size = new System.Drawing.Size(106, 20);
            this.lbl_search.TabIndex = 147;
            this.lbl_search.Text = "Search Name";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel4.Controls.Add(this.lbl_paid);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.lbl_remaining);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.lbl_credit);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Location = new System.Drawing.Point(3, 585);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1024, 49);
            this.panel4.TabIndex = 148;
            // 
            // lbl_remaining
            // 
            this.lbl_remaining.AutoSize = true;
            this.lbl_remaining.BackColor = System.Drawing.Color.Black;
            this.lbl_remaining.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_remaining.ForeColor = System.Drawing.Color.Lime;
            this.lbl_remaining.Location = new System.Drawing.Point(840, 18);
            this.lbl_remaining.Name = "lbl_remaining";
            this.lbl_remaining.Size = new System.Drawing.Size(17, 18);
            this.lbl_remaining.TabIndex = 5;
            this.lbl_remaining.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Black;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Lime;
            this.label7.Location = new System.Drawing.Point(745, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 18);
            this.label7.TabIndex = 4;
            this.label7.Text = "Remaining :";
            // 
            // lbl_credit
            // 
            this.lbl_credit.AutoSize = true;
            this.lbl_credit.BackColor = System.Drawing.Color.Black;
            this.lbl_credit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_credit.ForeColor = System.Drawing.Color.Lime;
            this.lbl_credit.Location = new System.Drawing.Point(467, 18);
            this.lbl_credit.Name = "lbl_credit";
            this.lbl_credit.Size = new System.Drawing.Size(17, 18);
            this.lbl_credit.TabIndex = 3;
            this.lbl_credit.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Black;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Lime;
            this.label3.Location = new System.Drawing.Point(398, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Credit :";
            // 
            // lbl_paid
            // 
            this.lbl_paid.AutoSize = true;
            this.lbl_paid.BackColor = System.Drawing.Color.Black;
            this.lbl_paid.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_paid.ForeColor = System.Drawing.Color.Lime;
            this.lbl_paid.Location = new System.Drawing.Point(641, 18);
            this.lbl_paid.Name = "lbl_paid";
            this.lbl_paid.Size = new System.Drawing.Size(17, 18);
            this.lbl_paid.TabIndex = 7;
            this.lbl_paid.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Black;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Lime;
            this.label4.Location = new System.Drawing.Point(592, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 18);
            this.label4.TabIndex = 6;
            this.label4.Text = "Paid :";
            // 
            // col_customer_name
            // 
            this.col_customer_name.HeaderText = "Customer Name";
            this.col_customer_name.Name = "col_customer_name";
            this.col_customer_name.ReadOnly = true;
            this.col_customer_name.Width = 200;
            // 
            // col_customer_phone
            // 
            this.col_customer_phone.HeaderText = "Phone";
            this.col_customer_phone.Name = "col_customer_phone";
            this.col_customer_phone.ReadOnly = true;
            // 
            // col_customer_address
            // 
            this.col_customer_address.HeaderText = "Customer Address";
            this.col_customer_address.Name = "col_customer_address";
            this.col_customer_address.ReadOnly = true;
            this.col_customer_address.Width = 120;
            // 
            // col_credit_amount
            // 
            this.col_credit_amount.HeaderText = "credit_amount";
            this.col_credit_amount.Name = "col_credit_amount";
            this.col_credit_amount.ReadOnly = true;
            this.col_credit_amount.Width = 160;
            // 
            // col_paid
            // 
            this.col_paid.HeaderText = "Credit Paid";
            this.col_paid.Name = "col_paid";
            this.col_paid.ReadOnly = true;
            this.col_paid.Width = 140;
            // 
            // col_remaining
            // 
            this.col_remaining.HeaderText = "Credit Remaining";
            this.col_remaining.Name = "col_remaining";
            this.col_remaining.ReadOnly = true;
            this.col_remaining.Width = 140;
            // 
            // col_customer_id
            // 
            this.col_customer_id.HeaderText = "customer_id";
            this.col_customer_id.Name = "col_customer_id";
            this.col_customer_id.ReadOnly = true;
            this.col_customer_id.Visible = false;
            // 
            // col_view
            // 
            this.col_view.HeaderText = "View";
            this.col_view.Name = "col_view";
            this.col_view.ReadOnly = true;
            this.col_view.Text = "View ";
            this.col_view.ToolTipText = "View";
            this.col_view.UseColumnTextForButtonValue = true;
            // 
            // CustomerDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.txt_search);
            this.Controls.Add(this.lbl_search);
            this.Controls.Add(this.btn_excel);
            this.Controls.Add(this.btn_export_to_pdf);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Name = "CustomerDetail";
            this.Size = new System.Drawing.Size(1027, 696);
            this.Load += new System.EventHandler(this.CustomerDetail_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_back;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private DevComponents.DotNetBar.ButtonX btn_excel;
        private DevComponents.DotNetBar.ButtonX btn_export_to_pdf;
        private System.Windows.Forms.TextBox txt_search;
        private System.Windows.Forms.Label lbl_search;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lbl_remaining;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbl_credit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_customer_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_customer_phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_customer_address;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_credit_amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_paid;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_remaining;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_customer_id;
        private System.Windows.Forms.DataGridViewButtonColumn col_view;
        private System.Windows.Forms.Label lbl_paid;
        private System.Windows.Forms.Label label4;
    }
}