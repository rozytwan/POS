namespace POS_System
{
    partial class Puchase_Book
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cal_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_bill_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_supplier_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_supplier_number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_total_purchase_amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_tax_discount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_taxable_purcahse_amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_taxable_purchase_tax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_tax_import_amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_tax_import_tax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_back = new System.Windows.Forms.Button();
            this.label23 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cal_date,
            this.cal_bill_no,
            this.cal_supplier_name,
            this.cal_supplier_number,
            this.cal_total_purchase_amount,
            this.cal_tax_discount,
            this.cal_taxable_purcahse_amount,
            this.cal_taxable_purchase_tax,
            this.cal_tax_import_amount,
            this.cal_tax_import_tax});
            this.dataGridView1.Location = new System.Drawing.Point(0, 69);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1024, 641);
            this.dataGridView1.TabIndex = 0;
            // 
            // cal_date
            // 
            this.cal_date.HeaderText = "Date";
            this.cal_date.Name = "cal_date";
            // 
            // cal_bill_no
            // 
            this.cal_bill_no.HeaderText = "Bill No";
            this.cal_bill_no.Name = "cal_bill_no";
            // 
            // cal_supplier_name
            // 
            this.cal_supplier_name.HeaderText = "Supplier\'s Name";
            this.cal_supplier_name.Name = "cal_supplier_name";
            // 
            // cal_supplier_number
            // 
            this.cal_supplier_number.HeaderText = "Supplier\'s Number";
            this.cal_supplier_number.Name = "cal_supplier_number";
            // 
            // cal_total_purchase_amount
            // 
            this.cal_total_purchase_amount.HeaderText = "Total Purcahse Amount";
            this.cal_total_purchase_amount.Name = "cal_total_purchase_amount";
            // 
            // cal_tax_discount
            // 
            this.cal_tax_discount.HeaderText = "Tax Discount";
            this.cal_tax_discount.Name = "cal_tax_discount";
            // 
            // cal_taxable_purcahse_amount
            // 
            this.cal_taxable_purcahse_amount.HeaderText = "Taxable Purchase Amount";
            this.cal_taxable_purcahse_amount.Name = "cal_taxable_purcahse_amount";
            // 
            // cal_taxable_purchase_tax
            // 
            this.cal_taxable_purchase_tax.HeaderText = "Taxable Puchase Tax(Rs)";
            this.cal_taxable_purchase_tax.Name = "cal_taxable_purchase_tax";
            // 
            // cal_tax_import_amount
            // 
            this.cal_tax_import_amount.HeaderText = "Tax Import Amount";
            this.cal_tax_import_amount.Name = "cal_tax_import_amount";
            // 
            // cal_tax_import_tax
            // 
            this.cal_tax_import_tax.HeaderText = "Tax Import Tax(Rs)";
            this.cal_tax_import_tax.Name = "cal_tax_import_tax";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(81)))), ((int)(((byte)(126)))));
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.btn_back);
            this.panel2.Controls.Add(this.label23);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1027, 73);
            this.panel2.TabIndex = 114;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::POS_System.Properties.Resources.check__1_;
            this.pictureBox1.Location = new System.Drawing.Point(320, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(71, 68);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 24;
            this.pictureBox1.TabStop = false;
            // 
            // btn_back
            // 
            this.btn_back.FlatAppearance.BorderSize = 0;
            this.btn_back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_back.Image = global::POS_System.Properties.Resources.back36;
            this.btn_back.Location = new System.Drawing.Point(3, 5);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(92, 65);
            this.btn_back.TabIndex = 20;
            this.btn_back.UseVisualStyleBackColor = true;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.White;
            this.label23.Location = new System.Drawing.Point(388, 17);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(272, 39);
            this.label23.TabIndex = 18;
            this.label23.Text = "Purchase Report";
            // 
            // Puchase_Book
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Puchase_Book";
            this.Size = new System.Drawing.Size(1027, 713);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_bill_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_supplier_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_supplier_number;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_total_purchase_amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_tax_discount;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_taxable_purcahse_amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_taxable_purchase_tax;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_tax_import_amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_tax_import_tax;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_back;
        private System.Windows.Forms.Label label23;
    }
}
