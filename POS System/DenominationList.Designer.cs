namespace POS_System
{
    partial class DenominationList
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.label23 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lbl_thousand = new System.Windows.Forms.Label();
            this.lbl_ic = new System.Windows.Forms.Label();
            this.col_ic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_thousand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_fivehundred = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_hundred = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_fifty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_twenty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ten = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_five = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbl_fivehundred = new System.Windows.Forms.Label();
            this.lbl_hundred = new System.Windows.Forms.Label();
            this.lbl_fifty = new System.Windows.Forms.Label();
            this.lbl_twenty = new System.Windows.Forms.Label();
            this.lbl_ten = new System.Windows.Forms.Label();
            this.lbl_five = new System.Windows.Forms.Label();
            this.lbl_total = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_ic,
            this.col_thousand,
            this.col_fivehundred,
            this.col_hundred,
            this.col_fifty,
            this.col_twenty,
            this.col_ten,
            this.col_five,
            this.col_total});
            this.dataGridView1.GridColor = System.Drawing.Color.DarkGray;
            this.dataGridView1.Location = new System.Drawing.Point(0, 63);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(984, 546);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // panel3
            // 
            this.panel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(81)))), ((int)(((byte)(126)))));
            this.panel3.Controls.Add(this.pictureBox5);
            this.panel3.Controls.Add(this.label23);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(984, 62);
            this.panel3.TabIndex = 266;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::POS_System.Properties.Resources.back36;
            this.pictureBox5.Location = new System.Drawing.Point(5, 3);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(59, 54);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 24;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.Click += new System.EventHandler(this.pictureBox5_Click);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.White;
            this.label23.Location = new System.Drawing.Point(425, 11);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(228, 39);
            this.label23.TabIndex = 18;
            this.label23.Text = "Denomination";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel4.Controls.Add(this.lbl_total);
            this.panel4.Controls.Add(this.lbl_five);
            this.panel4.Controls.Add(this.lbl_ten);
            this.panel4.Controls.Add(this.lbl_twenty);
            this.panel4.Controls.Add(this.lbl_fifty);
            this.panel4.Controls.Add(this.lbl_hundred);
            this.panel4.Controls.Add(this.lbl_fivehundred);
            this.panel4.Controls.Add(this.lbl_thousand);
            this.panel4.Controls.Add(this.lbl_ic);
            this.panel4.Location = new System.Drawing.Point(0, 573);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(984, 36);
            this.panel4.TabIndex = 267;
            // 
            // lbl_thousand
            // 
            this.lbl_thousand.AutoSize = true;
            this.lbl_thousand.BackColor = System.Drawing.Color.Black;
            this.lbl_thousand.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_thousand.ForeColor = System.Drawing.Color.Lime;
            this.lbl_thousand.Location = new System.Drawing.Point(160, 3);
            this.lbl_thousand.Name = "lbl_thousand";
            this.lbl_thousand.Size = new System.Drawing.Size(24, 25);
            this.lbl_thousand.TabIndex = 5;
            this.lbl_thousand.Text = "0";
            // 
            // lbl_ic
            // 
            this.lbl_ic.AutoSize = true;
            this.lbl_ic.BackColor = System.Drawing.Color.Black;
            this.lbl_ic.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ic.ForeColor = System.Drawing.Color.Lime;
            this.lbl_ic.Location = new System.Drawing.Point(40, 3);
            this.lbl_ic.Name = "lbl_ic";
            this.lbl_ic.Size = new System.Drawing.Size(24, 25);
            this.lbl_ic.TabIndex = 3;
            this.lbl_ic.Text = "0";
            // 
            // col_ic
            // 
            this.col_ic.HeaderText = "IC";
            this.col_ic.Name = "col_ic";
            this.col_ic.ReadOnly = true;
            // 
            // col_thousand
            // 
            this.col_thousand.HeaderText = "Thousand";
            this.col_thousand.Name = "col_thousand";
            this.col_thousand.ReadOnly = true;
            // 
            // col_fivehundred
            // 
            this.col_fivehundred.HeaderText = "Five Hundred";
            this.col_fivehundred.Name = "col_fivehundred";
            this.col_fivehundred.ReadOnly = true;
            // 
            // col_hundred
            // 
            this.col_hundred.HeaderText = "Hundred";
            this.col_hundred.Name = "col_hundred";
            this.col_hundred.ReadOnly = true;
            // 
            // col_fifty
            // 
            this.col_fifty.HeaderText = "Fifty";
            this.col_fifty.Name = "col_fifty";
            this.col_fifty.ReadOnly = true;
            // 
            // col_twenty
            // 
            this.col_twenty.HeaderText = "Twenty";
            this.col_twenty.Name = "col_twenty";
            this.col_twenty.ReadOnly = true;
            // 
            // col_ten
            // 
            this.col_ten.HeaderText = "Ten";
            this.col_ten.Name = "col_ten";
            this.col_ten.ReadOnly = true;
            // 
            // col_five
            // 
            this.col_five.HeaderText = "Five";
            this.col_five.Name = "col_five";
            this.col_five.ReadOnly = true;
            // 
            // col_total
            // 
            this.col_total.HeaderText = "Total";
            this.col_total.Name = "col_total";
            this.col_total.ReadOnly = true;
            // 
            // lbl_fivehundred
            // 
            this.lbl_fivehundred.AutoSize = true;
            this.lbl_fivehundred.BackColor = System.Drawing.Color.Black;
            this.lbl_fivehundred.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_fivehundred.ForeColor = System.Drawing.Color.Lime;
            this.lbl_fivehundred.Location = new System.Drawing.Point(259, 3);
            this.lbl_fivehundred.Name = "lbl_fivehundred";
            this.lbl_fivehundred.Size = new System.Drawing.Size(24, 25);
            this.lbl_fivehundred.TabIndex = 6;
            this.lbl_fivehundred.Text = "0";
            // 
            // lbl_hundred
            // 
            this.lbl_hundred.AutoSize = true;
            this.lbl_hundred.BackColor = System.Drawing.Color.Black;
            this.lbl_hundred.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_hundred.ForeColor = System.Drawing.Color.Lime;
            this.lbl_hundred.Location = new System.Drawing.Point(366, 3);
            this.lbl_hundred.Name = "lbl_hundred";
            this.lbl_hundred.Size = new System.Drawing.Size(24, 25);
            this.lbl_hundred.TabIndex = 7;
            this.lbl_hundred.Text = "0";
            // 
            // lbl_fifty
            // 
            this.lbl_fifty.AutoSize = true;
            this.lbl_fifty.BackColor = System.Drawing.Color.Black;
            this.lbl_fifty.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_fifty.ForeColor = System.Drawing.Color.Lime;
            this.lbl_fifty.Location = new System.Drawing.Point(473, 3);
            this.lbl_fifty.Name = "lbl_fifty";
            this.lbl_fifty.Size = new System.Drawing.Size(24, 25);
            this.lbl_fifty.TabIndex = 8;
            this.lbl_fifty.Text = "0";
            // 
            // lbl_twenty
            // 
            this.lbl_twenty.AutoSize = true;
            this.lbl_twenty.BackColor = System.Drawing.Color.Black;
            this.lbl_twenty.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_twenty.ForeColor = System.Drawing.Color.Lime;
            this.lbl_twenty.Location = new System.Drawing.Point(578, 3);
            this.lbl_twenty.Name = "lbl_twenty";
            this.lbl_twenty.Size = new System.Drawing.Size(24, 25);
            this.lbl_twenty.TabIndex = 9;
            this.lbl_twenty.Text = "0";
            // 
            // lbl_ten
            // 
            this.lbl_ten.AutoSize = true;
            this.lbl_ten.BackColor = System.Drawing.Color.Black;
            this.lbl_ten.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ten.ForeColor = System.Drawing.Color.Lime;
            this.lbl_ten.Location = new System.Drawing.Point(683, 3);
            this.lbl_ten.Name = "lbl_ten";
            this.lbl_ten.Size = new System.Drawing.Size(24, 25);
            this.lbl_ten.TabIndex = 10;
            this.lbl_ten.Text = "0";
            // 
            // lbl_five
            // 
            this.lbl_five.AutoSize = true;
            this.lbl_five.BackColor = System.Drawing.Color.Black;
            this.lbl_five.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_five.ForeColor = System.Drawing.Color.Lime;
            this.lbl_five.Location = new System.Drawing.Point(779, 3);
            this.lbl_five.Name = "lbl_five";
            this.lbl_five.Size = new System.Drawing.Size(24, 25);
            this.lbl_five.TabIndex = 11;
            this.lbl_five.Text = "0";
            // 
            // lbl_total
            // 
            this.lbl_total.AutoSize = true;
            this.lbl_total.BackColor = System.Drawing.Color.Black;
            this.lbl_total.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_total.ForeColor = System.Drawing.Color.Lime;
            this.lbl_total.Location = new System.Drawing.Point(885, 3);
            this.lbl_total.Name = "lbl_total";
            this.lbl_total.Size = new System.Drawing.Size(24, 25);
            this.lbl_total.TabIndex = 12;
            this.lbl_total.Text = "0";
            // 
            // DenominationList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 610);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.dataGridView1);
            this.Name = "DenominationList";
            this.Text = "DenominationList";
            this.Load += new System.EventHandler(this.DenominationList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Panel panel4;
        public System.Windows.Forms.Label lbl_ic;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ic;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_thousand;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_fivehundred;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_hundred;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_fifty;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_twenty;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ten;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_five;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_total;
        public System.Windows.Forms.Label lbl_total;
        public System.Windows.Forms.Label lbl_five;
        public System.Windows.Forms.Label lbl_ten;
        public System.Windows.Forms.Label lbl_twenty;
        public System.Windows.Forms.Label lbl_fifty;
        public System.Windows.Forms.Label lbl_hundred;
        public System.Windows.Forms.Label lbl_fivehundred;
        public System.Windows.Forms.Label lbl_thousand;
    }
}