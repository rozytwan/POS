namespace POS_System

{
    partial class SupplierPurchase
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
            this.col_sup_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_supplier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_contact = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_grand_total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_remain = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_details = new System.Windows.Forms.DataGridViewButtonColumn();
            this.col_payment = new System.Windows.Forms.DataGridViewButtonColumn();
            this.col_view = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btn_back = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label20 = new System.Windows.Forms.Label();
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
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1027, 768);
            this.panel1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_sup_id,
            this.col_supplier,
            this.col_address,
            this.col_contact,
            this.col_grand_total,
            this.col_remain,
            this.col_details,
            this.col_payment,
            this.col_view});
            this.dataGridView1.Location = new System.Drawing.Point(0, 65);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(1027, 700);
            this.dataGridView1.TabIndex = 104;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // col_sup_id
            // 
            this.col_sup_id.HeaderText = "Supplier Id";
            this.col_sup_id.Name = "col_sup_id";
            this.col_sup_id.ReadOnly = true;
            this.col_sup_id.Visible = false;
            // 
            // col_supplier
            // 
            this.col_supplier.HeaderText = "Supplier";
            this.col_supplier.Name = "col_supplier";
            this.col_supplier.ReadOnly = true;
            this.col_supplier.Width = 150;
            // 
            // col_address
            // 
            this.col_address.HeaderText = "Address";
            this.col_address.Name = "col_address";
            this.col_address.ReadOnly = true;
            this.col_address.Width = 150;
            // 
            // col_contact
            // 
            this.col_contact.HeaderText = "Contact";
            this.col_contact.Name = "col_contact";
            this.col_contact.ReadOnly = true;
            this.col_contact.Width = 150;
            // 
            // col_grand_total
            // 
            this.col_grand_total.HeaderText = "Grand Total";
            this.col_grand_total.Name = "col_grand_total";
            this.col_grand_total.ReadOnly = true;
            this.col_grand_total.Width = 110;
            // 
            // col_remain
            // 
            this.col_remain.HeaderText = "Remaining Payment";
            this.col_remain.Name = "col_remain";
            this.col_remain.ReadOnly = true;
            // 
            // col_details
            // 
            this.col_details.HeaderText = "Details";
            this.col_details.Name = "col_details";
            this.col_details.ReadOnly = true;
            this.col_details.Text = "Details";
            this.col_details.ToolTipText = "Details";
            this.col_details.UseColumnTextForButtonValue = true;
            this.col_details.Width = 110;
            // 
            // col_payment
            // 
            this.col_payment.HeaderText = "Payment";
            this.col_payment.Name = "col_payment";
            this.col_payment.ReadOnly = true;
            this.col_payment.Text = "Payment";
            this.col_payment.ToolTipText = "Payment";
            this.col_payment.UseColumnTextForButtonValue = true;
            this.col_payment.Width = 110;
            // 
            // col_view
            // 
            this.col_view.HeaderText = "View Pay";
            this.col_view.Name = "col_view";
            this.col_view.ReadOnly = true;
            this.col_view.Text = "View Pay";
            this.col_view.ToolTipText = "View Pay";
            this.col_view.UseColumnTextForButtonValue = true;
            this.col_view.Width = 110;
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
            this.panel4.Size = new System.Drawing.Size(1027, 62);
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
            this.label20.Size = new System.Drawing.Size(334, 29);
            this.label20.TabIndex = 0;
            this.label20.Text = "Supplier\'s Purchase Details";
            // 
            // SupplierPurchase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "SupplierPurchase";
            this.Size = new System.Drawing.Size(1032, 772);
            this.Load += new System.EventHandler(this.SupplierPurchase_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btn_back;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_sup_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_supplier;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_address;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_contact;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_grand_total;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_remain;
        private System.Windows.Forms.DataGridViewButtonColumn col_details;
        private System.Windows.Forms.DataGridViewButtonColumn col_payment;
        private System.Windows.Forms.DataGridViewButtonColumn col_view;
    }
}