namespace POS_System
{
    partial class SupplierPayment
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btn_back = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label20 = new System.Windows.Forms.Label();
            this.col_purchaseid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_supplier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_bill_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_grand_total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_categoryname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_productname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_purhasedate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_return = new System.Windows.Forms.DataGridViewButtonColumn();
            this.col_payment = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1032, 772);
            this.panel1.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_purchaseid,
            this.col_supplier,
            this.col_bill_no,
            this.col_grand_total,
            this.col_categoryname,
            this.col_productname,
            this.col_purhasedate,
            this.col_return,
            this.col_payment});
            this.dataGridView1.Location = new System.Drawing.Point(0, 65);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(1029, 665);
            this.dataGridView1.TabIndex = 104;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(81)))), ((int)(((byte)(126)))));
            this.panel4.Controls.Add(this.btn_back);
            this.panel4.Controls.Add(this.pictureBox1);
            this.panel4.Controls.Add(this.label20);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1032, 62);
            this.panel4.TabIndex = 103;
            // 
            // btn_back
            // 
            this.btn_back.FlatAppearance.BorderSize = 0;
            this.btn_back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_back.Image = global::POS_System.Properties.Resources.back36;
            this.btn_back.Location = new System.Drawing.Point(0, -1);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(92, 62);
            this.btn_back.TabIndex = 21;
            this.btn_back.UseVisualStyleBackColor = true;
            this.btn_back.Click += new System.EventHandler(this.btn_back_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::POS_System.Properties.Resources.hotel_supplier__1_;
            this.pictureBox1.Location = new System.Drawing.Point(341, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(59, 56);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.White;
            this.label20.Location = new System.Drawing.Point(428, 18);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(219, 29);
            this.label20.TabIndex = 0;
            this.label20.Text = "Supplier Payment";
            // 
            // col_purchaseid
            // 
            this.col_purchaseid.HeaderText = "Purchase Id";
            this.col_purchaseid.Name = "col_purchaseid";
            this.col_purchaseid.ReadOnly = true;
            this.col_purchaseid.Visible = false;
            this.col_purchaseid.Width = 160;
            // 
            // col_supplier
            // 
            this.col_supplier.HeaderText = "Supplier Name";
            this.col_supplier.Name = "col_supplier";
            this.col_supplier.ReadOnly = true;
            this.col_supplier.Width = 170;
            // 
            // col_bill_no
            // 
            this.col_bill_no.HeaderText = "Bill No";
            this.col_bill_no.Name = "col_bill_no";
            this.col_bill_no.ReadOnly = true;
            // 
            // col_grand_total
            // 
            this.col_grand_total.HeaderText = "Grand Total";
            this.col_grand_total.Name = "col_grand_total";
            this.col_grand_total.ReadOnly = true;
            this.col_grand_total.Width = 150;
            // 
            // col_categoryname
            // 
            this.col_categoryname.HeaderText = "Category Name";
            this.col_categoryname.Name = "col_categoryname";
            this.col_categoryname.ReadOnly = true;
            this.col_categoryname.Width = 170;
            // 
            // col_productname
            // 
            this.col_productname.HeaderText = "Product Name";
            this.col_productname.Name = "col_productname";
            this.col_productname.ReadOnly = true;
            this.col_productname.Width = 150;
            // 
            // col_purhasedate
            // 
            this.col_purhasedate.HeaderText = "Purchase Date";
            this.col_purhasedate.Name = "col_purhasedate";
            this.col_purhasedate.ReadOnly = true;
            this.col_purhasedate.Width = 150;
            // 
            // col_return
            // 
            this.col_return.HeaderText = "Return";
            this.col_return.Name = "col_return";
            this.col_return.ReadOnly = true;
            this.col_return.Text = "Return";
            this.col_return.ToolTipText = "Return";
            this.col_return.UseColumnTextForButtonValue = true;
            // 
            // col_payment
            // 
            this.col_payment.HeaderText = "Payment";
            this.col_payment.Name = "col_payment";
            this.col_payment.ReadOnly = true;
            this.col_payment.Text = "Payment";
            this.col_payment.ToolTipText = "Payment";
            this.col_payment.UseColumnTextForButtonValue = true;
            this.col_payment.Visible = false;
            // 
            // SupplierPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "SupplierPayment";
            this.Size = new System.Drawing.Size(1032, 772);
            this.Load += new System.EventHandler(this.SupplierPayment_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btn_back;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_purchaseid;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_supplier;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_bill_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_grand_total;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_categoryname;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_productname;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_purhasedate;
        private System.Windows.Forms.DataGridViewButtonColumn col_return;
        private System.Windows.Forms.DataGridViewButtonColumn col_payment;
    }
}