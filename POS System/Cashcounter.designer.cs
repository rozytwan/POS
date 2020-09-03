namespace POS_System
{
    partial class Cashcounter
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
            this.lbl_datatime_now = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_opening = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_closing = new System.Windows.Forms.TextBox();
            this.btn_set = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_todays = new System.Windows.Forms.Label();
            this.btn_closing = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label_sale = new System.Windows.Forms.Label();
            this.dgv_all = new System.Windows.Forms.DataGridView();
            this.caldate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calamount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calstatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.caldesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_all)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_datatime_now
            // 
            this.lbl_datatime_now.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_datatime_now.AutoSize = true;
            this.lbl_datatime_now.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_datatime_now.Location = new System.Drawing.Point(142, 40);
            this.lbl_datatime_now.Name = "lbl_datatime_now";
            this.lbl_datatime_now.Size = new System.Drawing.Size(112, 24);
            this.lbl_datatime_now.TabIndex = 0;
            this.lbl_datatime_now.Text = "00-00-0000";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(54, 126);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Set  Balance ";
            // 
            // txt_opening
            // 
            this.txt_opening.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_opening.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_opening.Location = new System.Drawing.Point(161, 123);
            this.txt_opening.Name = "txt_opening";
            this.txt_opening.Size = new System.Drawing.Size(178, 26);
            this.txt_opening.TabIndex = 0;
            this.txt_opening.Text = "0";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(36, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Closing Balance";
            // 
            // txt_closing
            // 
            this.txt_closing.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_closing.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_closing.Location = new System.Drawing.Point(161, 84);
            this.txt_closing.Name = "txt_closing";
            this.txt_closing.Size = new System.Drawing.Size(178, 26);
            this.txt_closing.TabIndex = 3;
            this.txt_closing.Text = "0";
            // 
            // btn_set
            // 
            this.btn_set.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_set.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_set.Location = new System.Drawing.Point(339, 123);
            this.btn_set.Name = "btn_set";
            this.btn_set.Size = new System.Drawing.Size(60, 26);
            this.btn_set.TabIndex = 1;
            this.btn_set.Text = "Set";
            this.btn_set.UseVisualStyleBackColor = true;
            this.btn_set.Click += new System.EventHandler(this.btn_set_Click);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(44, 171);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(174, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "Today\'s Opening balance";
            // 
            // lbl_todays
            // 
            this.lbl_todays.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_todays.AutoSize = true;
            this.lbl_todays.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_todays.Location = new System.Drawing.Point(223, 172);
            this.lbl_todays.Name = "lbl_todays";
            this.lbl_todays.Size = new System.Drawing.Size(44, 18);
            this.lbl_todays.TabIndex = 4;
            this.lbl_todays.Text = "0000";
            // 
            // btn_closing
            // 
            this.btn_closing.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_closing.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_closing.Location = new System.Drawing.Point(339, 83);
            this.btn_closing.Name = "btn_closing";
            this.btn_closing.Size = new System.Drawing.Size(60, 26);
            this.btn_closing.TabIndex = 1;
            this.btn_closing.Text = "Set";
            this.btn_closing.UseVisualStyleBackColor = true;
            this.btn_closing.Click += new System.EventHandler(this.btn_closing_Click);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(307, 172);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Total Sales:";
            // 
            // label_sale
            // 
            this.label_sale.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label_sale.AutoSize = true;
            this.label_sale.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_sale.Location = new System.Drawing.Point(394, 172);
            this.label_sale.Name = "label_sale";
            this.label_sale.Size = new System.Drawing.Size(44, 20);
            this.label_sale.TabIndex = 6;
            this.label_sale.Text = "0.00";
            // 
            // dgv_all
            // 
            this.dgv_all.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dgv_all.BackgroundColor = System.Drawing.Color.White;
            this.dgv_all.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_all.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.caldate,
            this.calname,
            this.calamount,
            this.calstatus,
            this.caldesc});
            this.dgv_all.Location = new System.Drawing.Point(8, 230);
            this.dgv_all.Name = "dgv_all";
            this.dgv_all.Size = new System.Drawing.Size(515, 158);
            this.dgv_all.TabIndex = 9;
            this.dgv_all.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_all_RowHeaderMouseDoubleClick);
            // 
            // caldate
            // 
            this.caldate.HeaderText = "Date";
            this.caldate.Name = "caldate";
            // 
            // calname
            // 
            this.calname.HeaderText = "Name";
            this.calname.Name = "calname";
            // 
            // calamount
            // 
            this.calamount.HeaderText = "Amount";
            this.calamount.Name = "calamount";
            this.calamount.Width = 70;
            // 
            // calstatus
            // 
            this.calstatus.HeaderText = "Status";
            this.calstatus.Name = "calstatus";
            this.calstatus.Width = 50;
            // 
            // caldesc
            // 
            this.caldesc.HeaderText = "Description";
            this.caldesc.Name = "caldesc";
            this.caldesc.Width = 150;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(8, 208);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(196, 17);
            this.label6.TabIndex = 13;
            this.label6.Text = "List of Withdrawn and Deposit";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(11, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 24);
            this.label5.TabIndex = 14;
            this.label5.Text = "Set Balances";
            // 
            // Cashcounter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(532, 399);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dgv_all);
            this.Controls.Add(this.label_sale);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbl_todays);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_closing);
            this.Controls.Add(this.btn_set);
            this.Controls.Add(this.txt_closing);
            this.Controls.Add(this.txt_opening);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_datatime_now);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Cashcounter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Day to Day Counter Opening Balance";
            this.Load += new System.EventHandler(this.Cashcounter_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_all)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_datatime_now;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_opening;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_closing;
        private System.Windows.Forms.Button btn_set;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_todays;
        private System.Windows.Forms.Button btn_closing;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label_sale;
        private System.Windows.Forms.DataGridView dgv_all;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn caldate;
        private System.Windows.Forms.DataGridViewTextBoxColumn calname;
        private System.Windows.Forms.DataGridViewTextBoxColumn calamount;
        private System.Windows.Forms.DataGridViewTextBoxColumn calstatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn caldesc;
        private System.Windows.Forms.Label label5;
    }
}