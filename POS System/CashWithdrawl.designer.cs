namespace POS_System
{
    partial class CashWithdrawl
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
            this.label6 = new System.Windows.Forms.Label();
            this.dgv_all = new System.Windows.Forms.DataGridView();
            this.colid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.caldate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.caldesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calamount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_edit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.edit = new DevComponents.DotNetBar.ButtonX();
            this.btn_save = new DevComponents.DotNetBar.ButtonX();
            this.txt_withdrawl = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_cash = new System.Windows.Forms.TextBox();
            this.txt_name = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_credit = new System.Windows.Forms.Label();
            this.txt_CounterCashremain = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lbl_openingbalance = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label_sale = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_back = new System.Windows.Forms.Button();
            this.label23 = new System.Windows.Forms.Label();
            this.btn_export_to_pdf = new DevComponents.DotNetBar.ButtonX();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_all)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(144, 286);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 17);
            this.label6.TabIndex = 12;
            this.label6.Text = "List of Cash Drop";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // dgv_all
            // 
            this.dgv_all.AllowUserToAddRows = false;
            this.dgv_all.AllowUserToDeleteRows = false;
            this.dgv_all.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_all.BackgroundColor = System.Drawing.Color.White;
            this.dgv_all.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_all.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colid,
            this.caldate,
            this.calname,
            this.caldesc,
            this.calamount,
            this.cal_name,
            this.col_edit});
            this.dgv_all.Location = new System.Drawing.Point(57, 306);
            this.dgv_all.Name = "dgv_all";
            this.dgv_all.ReadOnly = true;
            this.dgv_all.Size = new System.Drawing.Size(822, 279);
            this.dgv_all.TabIndex = 13;
            this.dgv_all.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_all_CellClick);
            this.dgv_all.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_all_CellContentClick);
            // 
            // colid
            // 
            this.colid.HeaderText = "Id";
            this.colid.Name = "colid";
            this.colid.ReadOnly = true;
            this.colid.Visible = false;
            // 
            // caldate
            // 
            this.caldate.HeaderText = "Date";
            this.caldate.Name = "caldate";
            this.caldate.ReadOnly = true;
            // 
            // calname
            // 
            this.calname.HeaderText = "Care Of";
            this.calname.Name = "calname";
            this.calname.ReadOnly = true;
            // 
            // caldesc
            // 
            this.caldesc.HeaderText = "Description";
            this.caldesc.Name = "caldesc";
            this.caldesc.ReadOnly = true;
            // 
            // calamount
            // 
            this.calamount.HeaderText = "Amount";
            this.calamount.Name = "calamount";
            this.calamount.ReadOnly = true;
            // 
            // cal_name
            // 
            this.cal_name.HeaderText = "Name";
            this.cal_name.Name = "cal_name";
            this.cal_name.ReadOnly = true;
            // 
            // col_edit
            // 
            this.col_edit.HeaderText = "Edit";
            this.col_edit.Name = "col_edit";
            this.col_edit.ReadOnly = true;
            this.col_edit.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_edit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.col_edit.Text = "Edit";
            this.col_edit.ToolTipText = "Edit";
            this.col_edit.UseColumnTextForButtonValue = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.edit);
            this.groupBox1.Controls.Add(this.btn_save);
            this.groupBox1.Controls.Add(this.txt_withdrawl);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txt_cash);
            this.groupBox1.Controls.Add(this.txt_name);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(276, 75);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(415, 212);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // edit
            // 
            this.edit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.edit.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.edit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edit.Location = new System.Drawing.Point(210, 110);
            this.edit.Name = "edit";
            this.edit.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(15);
            this.edit.Size = new System.Drawing.Size(89, 69);
            this.edit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.edit.Symbol = "";
            this.edit.TabIndex = 21;
            this.edit.Text = "Edit";
            this.edit.Click += new System.EventHandler(this.edit_Click);
            // 
            // btn_save
            // 
            this.btn_save.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_save.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btn_save.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save.Location = new System.Drawing.Point(112, 110);
            this.btn_save.Name = "btn_save";
            this.btn_save.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(15);
            this.btn_save.Size = new System.Drawing.Size(85, 69);
            this.btn_save.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_save.Symbol = "";
            this.btn_save.TabIndex = 20;
            this.btn_save.Text = "Save";
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // txt_withdrawl
            // 
            this.txt_withdrawl.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_withdrawl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_withdrawl.Location = new System.Drawing.Point(96, 44);
            this.txt_withdrawl.Name = "txt_withdrawl";
            this.txt_withdrawl.Size = new System.Drawing.Size(250, 22);
            this.txt_withdrawl.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(14, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 16);
            this.label4.TabIndex = 17;
            this.label4.Text = "Description";
            // 
            // txt_cash
            // 
            this.txt_cash.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_cash.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_cash.Location = new System.Drawing.Point(96, 70);
            this.txt_cash.Name = "txt_cash";
            this.txt_cash.Size = new System.Drawing.Size(250, 22);
            this.txt_cash.TabIndex = 3;
            this.txt_cash.Text = "0";
            this.txt_cash.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_cash_KeyPress_1);
            // 
            // txt_name
            // 
            this.txt_name.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_name.Location = new System.Drawing.Point(96, 19);
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(250, 22);
            this.txt_name.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(4, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 16);
            this.label3.TabIndex = 12;
            this.label3.Text = "Cash Amount:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(37, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 14;
            this.label2.Text = "Care Of:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.lbl_credit);
            this.panel1.Controls.Add(this.txt_CounterCashremain);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.lbl_openingbalance);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label_sale);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Location = new System.Drawing.Point(57, 590);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(822, 32);
            this.panel1.TabIndex = 21;
            // 
            // lbl_credit
            // 
            this.lbl_credit.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_credit.AutoSize = true;
            this.lbl_credit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_credit.ForeColor = System.Drawing.Color.Black;
            this.lbl_credit.Location = new System.Drawing.Point(504, 9);
            this.lbl_credit.Name = "lbl_credit";
            this.lbl_credit.Size = new System.Drawing.Size(36, 16);
            this.lbl_credit.TabIndex = 115;
            this.lbl_credit.Text = "0.00";
            // 
            // txt_CounterCashremain
            // 
            this.txt_CounterCashremain.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_CounterCashremain.AutoSize = true;
            this.txt_CounterCashremain.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_CounterCashremain.ForeColor = System.Drawing.Color.Lime;
            this.txt_CounterCashremain.Location = new System.Drawing.Point(742, 9);
            this.txt_CounterCashremain.Name = "txt_CounterCashremain";
            this.txt_CounterCashremain.Size = new System.Drawing.Size(36, 16);
            this.txt_CounterCashremain.TabIndex = 23;
            this.txt_CounterCashremain.Text = "0.00";
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Lime;
            this.label10.Location = new System.Drawing.Point(600, 8);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(138, 16);
            this.label10.TabIndex = 22;
            this.label10.Text = "Total Cash In Counter:";
            // 
            // lbl_openingbalance
            // 
            this.lbl_openingbalance.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_openingbalance.AutoSize = true;
            this.lbl_openingbalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_openingbalance.ForeColor = System.Drawing.Color.Lime;
            this.lbl_openingbalance.Location = new System.Drawing.Point(415, 9);
            this.lbl_openingbalance.Name = "lbl_openingbalance";
            this.lbl_openingbalance.Size = new System.Drawing.Size(36, 16);
            this.lbl_openingbalance.TabIndex = 21;
            this.lbl_openingbalance.Text = "0.00";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Lime;
            this.label9.Location = new System.Drawing.Point(301, 8);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(115, 16);
            this.label9.TabIndex = 20;
            this.label9.Text = "Opening Balance:";
            // 
            // label_sale
            // 
            this.label_sale.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label_sale.AutoSize = true;
            this.label_sale.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_sale.ForeColor = System.Drawing.Color.Lime;
            this.label_sale.Location = new System.Drawing.Point(152, 8);
            this.label_sale.Name = "label_sale";
            this.label_sale.Size = new System.Drawing.Size(36, 16);
            this.label_sale.TabIndex = 19;
            this.label_sale.Text = "0.00";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Lime;
            this.label7.Location = new System.Drawing.Point(42, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(114, 16);
            this.label7.TabIndex = 18;
            this.label7.Text = "Total Cash Sales:";
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
            this.panel2.TabIndex = 113;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::POS_System.Properties.Resources.arrows__5_;
            this.pictureBox1.Location = new System.Drawing.Point(311, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(67, 68);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            // 
            // btn_back
            // 
            this.btn_back.FlatAppearance.BorderSize = 0;
            this.btn_back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_back.Image = global::POS_System.Properties.Resources.back36;
            this.btn_back.Location = new System.Drawing.Point(3, 3);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(92, 65);
            this.btn_back.TabIndex = 20;
            this.btn_back.UseVisualStyleBackColor = true;
            this.btn_back.Click += new System.EventHandler(this.btn_back_Click);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.White;
            this.label23.Location = new System.Drawing.Point(395, 17);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(180, 39);
            this.label23.TabIndex = 18;
            this.label23.Text = "Cash Drop";
            // 
            // btn_export_to_pdf
            // 
            this.btn_export_to_pdf.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_export_to_pdf.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btn_export_to_pdf.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_export_to_pdf.Location = new System.Drawing.Point(57, 629);
            this.btn_export_to_pdf.Name = "btn_export_to_pdf";
            this.btn_export_to_pdf.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(15);
            this.btn_export_to_pdf.Size = new System.Drawing.Size(223, 44);
            this.btn_export_to_pdf.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_export_to_pdf.TabIndex = 114;
            this.btn_export_to_pdf.Text = "Export to PDF";
            this.btn_export_to_pdf.Click += new System.EventHandler(this.btn_export_to_pdf_Click);
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.buttonX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonX1.Location = new System.Drawing.Point(293, 629);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(15);
            this.buttonX1.Size = new System.Drawing.Size(223, 44);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 115;
            this.buttonX1.Text = "Export to Excel";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // CashWithdrawl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.buttonX1);
            this.Controls.Add(this.btn_export_to_pdf);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgv_all);
            this.Controls.Add(this.label6);
            this.Name = "CashWithdrawl";
            this.Size = new System.Drawing.Size(1027, 720);
            this.Load += new System.EventHandler(this.CashWithdrawl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_all)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgv_all;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_withdrawl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_cash;
        private System.Windows.Forms.TextBox txt_name;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_openingbalance;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label_sale;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_back;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label txt_CounterCashremain;
        private System.Windows.Forms.Label label10;
        private DevComponents.DotNetBar.ButtonX btn_save;
        private DevComponents.DotNetBar.ButtonX btn_export_to_pdf;
        private DevComponents.DotNetBar.ButtonX edit;
        private System.Windows.Forms.Label lbl_credit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colid;
        private System.Windows.Forms.DataGridViewTextBoxColumn caldate;
        private System.Windows.Forms.DataGridViewTextBoxColumn calname;
        private System.Windows.Forms.DataGridViewTextBoxColumn caldesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn calamount;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_name;
        private System.Windows.Forms.DataGridViewButtonColumn col_edit;
        private DevComponents.DotNetBar.ButtonX buttonX1;
    }
}