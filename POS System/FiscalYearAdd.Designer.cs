namespace POS_System
{
    partial class FiscalYearAdd
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
            this.dtp_fiscal_year_from = new System.Windows.Forms.DateTimePicker();
            this.dtp_fiscal_year_to = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_new_fiscal_year = new DevComponents.DotNetBar.ButtonX();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_fixcal_year = new System.Windows.Forms.TextBox();
            this.lbl_nepali_date_from = new System.Windows.Forms.Label();
            this.lbl_nepali_date_to = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dtp_fiscal_year_from
            // 
            this.dtp_fiscal_year_from.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_fiscal_year_from.Location = new System.Drawing.Point(169, 93);
            this.dtp_fiscal_year_from.Name = "dtp_fiscal_year_from";
            this.dtp_fiscal_year_from.Size = new System.Drawing.Size(250, 26);
            this.dtp_fiscal_year_from.TabIndex = 0;
            this.dtp_fiscal_year_from.ValueChanged += new System.EventHandler(this.dtp_fiscal_year_from_ValueChanged);
            // 
            // dtp_fiscal_year_to
            // 
            this.dtp_fiscal_year_to.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_fiscal_year_to.Location = new System.Drawing.Point(169, 146);
            this.dtp_fiscal_year_to.Name = "dtp_fiscal_year_to";
            this.dtp_fiscal_year_to.Size = new System.Drawing.Size(250, 26);
            this.dtp_fiscal_year_to.TabIndex = 1;
            this.dtp_fiscal_year_to.ValueChanged += new System.EventHandler(this.dtp_fiscal_year_to_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(29, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Fiscal Year From";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(34, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Fiscal Year To";
            // 
            // btn_new_fiscal_year
            // 
            this.btn_new_fiscal_year.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_new_fiscal_year.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btn_new_fiscal_year.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_new_fiscal_year.Location = new System.Drawing.Point(169, 188);
            this.btn_new_fiscal_year.Name = "btn_new_fiscal_year";
            this.btn_new_fiscal_year.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(15);
            this.btn_new_fiscal_year.Size = new System.Drawing.Size(182, 48);
            this.btn_new_fiscal_year.TabIndex = 386;
            this.btn_new_fiscal_year.Text = "Add New Fiscal Year";
            this.btn_new_fiscal_year.Click += new System.EventHandler(this.btn_new_fiscal_year_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(29, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 20);
            this.label3.TabIndex = 387;
            this.label3.Text = "Fiscal Year";
            // 
            // txt_fixcal_year
            // 
            this.txt_fixcal_year.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_fixcal_year.Location = new System.Drawing.Point(169, 50);
            this.txt_fixcal_year.Name = "txt_fixcal_year";
            this.txt_fixcal_year.Size = new System.Drawing.Size(250, 26);
            this.txt_fixcal_year.TabIndex = 388;
            this.txt_fixcal_year.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_fixcal_year_KeyPress);
            // 
            // lbl_nepali_date_from
            // 
            this.lbl_nepali_date_from.AutoSize = true;
            this.lbl_nepali_date_from.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_nepali_date_from.Location = new System.Drawing.Point(425, 99);
            this.lbl_nepali_date_from.Name = "lbl_nepali_date_from";
            this.lbl_nepali_date_from.Size = new System.Drawing.Size(13, 20);
            this.lbl_nepali_date_from.TabIndex = 389;
            this.lbl_nepali_date_from.Text = ".";
            // 
            // lbl_nepali_date_to
            // 
            this.lbl_nepali_date_to.AutoSize = true;
            this.lbl_nepali_date_to.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_nepali_date_to.Location = new System.Drawing.Point(426, 149);
            this.lbl_nepali_date_to.Name = "lbl_nepali_date_to";
            this.lbl_nepali_date_to.Size = new System.Drawing.Size(13, 20);
            this.lbl_nepali_date_to.TabIndex = 390;
            this.lbl_nepali_date_to.Text = ".";
            // 
            // FiscalYearAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(566, 244);
            this.Controls.Add(this.lbl_nepali_date_to);
            this.Controls.Add(this.lbl_nepali_date_from);
            this.Controls.Add(this.txt_fixcal_year);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_new_fiscal_year);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtp_fiscal_year_to);
            this.Controls.Add(this.dtp_fiscal_year_from);
            this.Name = "FiscalYearAdd";
            this.Text = "FiscalYearAdd";
            this.Load += new System.EventHandler(this.FiscalYearAdd_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtp_fiscal_year_from;
        private System.Windows.Forms.DateTimePicker dtp_fiscal_year_to;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private DevComponents.DotNetBar.ButtonX btn_new_fiscal_year;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_fixcal_year;
        private System.Windows.Forms.Label lbl_nepali_date_from;
        private System.Windows.Forms.Label lbl_nepali_date_to;
    }
}