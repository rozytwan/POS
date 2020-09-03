namespace POS_System
{
    partial class SalesDataTaxCalculate
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_run = new DevComponents.DotNetBar.ButtonX();
            this.btn_run_all = new DevComponents.DotNetBar.ButtonX();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::POS_System.Properties.Resources.loading_with_fade;
            this.pictureBox1.Location = new System.Drawing.Point(35, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(208, 173);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btn_run
            // 
            this.btn_run.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_run.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_run.Location = new System.Drawing.Point(35, 191);
            this.btn_run.Name = "btn_run";
            this.btn_run.Size = new System.Drawing.Size(85, 41);
            this.btn_run.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005;
            this.btn_run.TabIndex = 1;
            this.btn_run.Text = "Run";
            this.btn_run.Click += new System.EventHandler(this.btn_run_Click);
            // 
            // btn_run_all
            // 
            this.btn_run_all.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_run_all.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_run_all.Location = new System.Drawing.Point(137, 191);
            this.btn_run_all.Name = "btn_run_all";
            this.btn_run_all.Size = new System.Drawing.Size(85, 41);
            this.btn_run_all.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005;
            this.btn_run_all.TabIndex = 2;
            this.btn_run_all.Text = "Run All";
            this.btn_run_all.Click += new System.EventHandler(this.btn_run_all_Click);
            // 
            // SalesDataTaxCalculate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btn_run_all);
            this.Controls.Add(this.btn_run);
            this.Controls.Add(this.pictureBox1);
            this.Name = "SalesDataTaxCalculate";
            this.Text = "SalesDataTaxCalculate";
            this.Load += new System.EventHandler(this.SalesDataTaxCalculate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private DevComponents.DotNetBar.ButtonX btn_run;
        private DevComponents.DotNetBar.ButtonX btn_run_all;
    }
}