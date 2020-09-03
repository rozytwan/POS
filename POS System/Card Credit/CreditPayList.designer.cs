namespace POS_System
{
    partial class CreditPayList
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
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.col_credit_pay_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_customername = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_creditamount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_creditpaid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_creditleft = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_checkedby = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_checkeddate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_view = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.dataGridView2.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_credit_pay_id,
            this.col_customername,
            this.col_creditamount,
            this.col_creditpaid,
            this.col_creditleft,
            this.col_checkedby,
            this.col_checkeddate,
            this.col_view});
            this.dataGridView2.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.dataGridView2.Location = new System.Drawing.Point(3, 69);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.Size = new System.Drawing.Size(963, 500);
            this.dataGridView2.TabIndex = 128;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(81)))), ((int)(((byte)(126)))));
            this.panel2.Controls.Add(this.pictureBox5);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(1, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(967, 64);
            this.panel2.TabIndex = 129;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::POS_System.Properties.Resources.back36;
            this.pictureBox5.Location = new System.Drawing.Point(8, 3);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(64, 59);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 27;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.Click += new System.EventHandler(this.pictureBox5_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(403, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Credit Pay List ";
            // 
            // col_credit_pay_id
            // 
            this.col_credit_pay_id.HeaderText = "creditpay_id";
            this.col_credit_pay_id.Name = "col_credit_pay_id";
            this.col_credit_pay_id.ReadOnly = true;
            this.col_credit_pay_id.Visible = false;
            // 
            // col_customername
            // 
            this.col_customername.HeaderText = "Customer Name";
            this.col_customername.Name = "col_customername";
            this.col_customername.ReadOnly = true;
            this.col_customername.Width = 180;
            // 
            // col_creditamount
            // 
            this.col_creditamount.HeaderText = "Credit Amount";
            this.col_creditamount.Name = "col_creditamount";
            this.col_creditamount.ReadOnly = true;
            this.col_creditamount.Width = 155;
            // 
            // col_creditpaid
            // 
            this.col_creditpaid.HeaderText = "Credit Paid";
            this.col_creditpaid.Name = "col_creditpaid";
            this.col_creditpaid.ReadOnly = true;
            this.col_creditpaid.Width = 155;
            // 
            // col_creditleft
            // 
            this.col_creditleft.HeaderText = "Credit Left";
            this.col_creditleft.Name = "col_creditleft";
            this.col_creditleft.ReadOnly = true;
            this.col_creditleft.Width = 155;
            // 
            // col_checkedby
            // 
            this.col_checkedby.HeaderText = "Checked By";
            this.col_checkedby.Name = "col_checkedby";
            this.col_checkedby.ReadOnly = true;
            this.col_checkedby.Width = 155;
            // 
            // col_checkeddate
            // 
            this.col_checkeddate.HeaderText = "Checked Date";
            this.col_checkeddate.Name = "col_checkeddate";
            this.col_checkeddate.ReadOnly = true;
            this.col_checkeddate.Width = 155;
            // 
            // col_view
            // 
            this.col_view.HeaderText = "View";
            this.col_view.Name = "col_view";
            this.col_view.ReadOnly = true;
            this.col_view.Text = "View";
            this.col_view.UseColumnTextForButtonValue = true;
            this.col_view.Visible = false;
            // 
            // CreditPayList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dataGridView2);
            this.Name = "CreditPayList";
            this.Size = new System.Drawing.Size(969, 578);
            this.Load += new System.EventHandler(this.CreditPayList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_credit_pay_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_customername;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_creditamount;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_creditpaid;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_creditleft;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_checkedby;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_checkeddate;
        private System.Windows.Forms.DataGridViewButtonColumn col_view;
    }
}