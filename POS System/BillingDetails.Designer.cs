namespace POS_System
{
    partial class BillingDetails
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
            this.btn_create_new_billing = new DevComponents.DotNetBar.ButtonX();
            this.btn_reprint = new DevComponents.DotNetBar.ButtonX();
            this.btn_current_page = new DevComponents.DotNetBar.ButtonX();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_change_amount = new System.Windows.Forms.Label();
            this.lbl_received_amount = new System.Windows.Forms.Label();
            this.lbl_grand_total = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_create_new_billing
            // 
            this.btn_create_new_billing.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_create_new_billing.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btn_create_new_billing.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_create_new_billing.Location = new System.Drawing.Point(12, 12);
            this.btn_create_new_billing.Name = "btn_create_new_billing";
            this.btn_create_new_billing.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(15);
            this.btn_create_new_billing.Size = new System.Drawing.Size(140, 69);
            this.btn_create_new_billing.TabIndex = 302;
            this.btn_create_new_billing.Text = "Create New Billing";
            this.btn_create_new_billing.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left;
            this.btn_create_new_billing.Click += new System.EventHandler(this.btn_create_new_billing_Click);
            // 
            // btn_reprint
            // 
            this.btn_reprint.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_reprint.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btn_reprint.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_reprint.Location = new System.Drawing.Point(158, 12);
            this.btn_reprint.Name = "btn_reprint";
            this.btn_reprint.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(15);
            this.btn_reprint.Size = new System.Drawing.Size(140, 69);
            this.btn_reprint.TabIndex = 303;
            this.btn_reprint.Text = "Re-Print Billing";
            this.btn_reprint.Click += new System.EventHandler(this.btn_reprint_Click);
            // 
            // btn_current_page
            // 
            this.btn_current_page.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_current_page.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btn_current_page.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_current_page.Location = new System.Drawing.Point(304, 12);
            this.btn_current_page.Name = "btn_current_page";
            this.btn_current_page.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(15);
            this.btn_current_page.Size = new System.Drawing.Size(166, 69);
            this.btn_current_page.TabIndex = 304;
            this.btn_current_page.Text = "Stay In Current Page";
            this.btn_current_page.Click += new System.EventHandler(this.btn_current_page_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.lbl_change_amount);
            this.panel1.Controls.Add(this.lbl_received_amount);
            this.panel1.Controls.Add(this.lbl_grand_total);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(2, 117);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(470, 138);
            this.panel1.TabIndex = 305;
            // 
            // lbl_change_amount
            // 
            this.lbl_change_amount.AutoSize = true;
            this.lbl_change_amount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_change_amount.ForeColor = System.Drawing.Color.Lime;
            this.lbl_change_amount.Location = new System.Drawing.Point(330, 71);
            this.lbl_change_amount.Name = "lbl_change_amount";
            this.lbl_change_amount.Size = new System.Drawing.Size(45, 24);
            this.lbl_change_amount.TabIndex = 311;
            this.lbl_change_amount.Text = "0.00";
            // 
            // lbl_received_amount
            // 
            this.lbl_received_amount.AutoSize = true;
            this.lbl_received_amount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_received_amount.ForeColor = System.Drawing.Color.Lime;
            this.lbl_received_amount.Location = new System.Drawing.Point(188, 71);
            this.lbl_received_amount.Name = "lbl_received_amount";
            this.lbl_received_amount.Size = new System.Drawing.Size(45, 24);
            this.lbl_received_amount.TabIndex = 310;
            this.lbl_received_amount.Text = "0.00";
            // 
            // lbl_grand_total
            // 
            this.lbl_grand_total.AutoSize = true;
            this.lbl_grand_total.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_grand_total.ForeColor = System.Drawing.Color.Lime;
            this.lbl_grand_total.Location = new System.Drawing.Point(10, 71);
            this.lbl_grand_total.Name = "lbl_grand_total";
            this.lbl_grand_total.Size = new System.Drawing.Size(45, 24);
            this.lbl_grand_total.TabIndex = 309;
            this.lbl_grand_total.Text = "0.00";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Lime;
            this.label3.Location = new System.Drawing.Point(315, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 24);
            this.label3.TabIndex = 308;
            this.label3.Text = "Change AMT";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Lime;
            this.label2.Location = new System.Drawing.Point(184, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 24);
            this.label2.TabIndex = 307;
            this.label2.Text = "Recived AMT";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Lime;
            this.label1.Location = new System.Drawing.Point(10, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 24);
            this.label1.TabIndex = 306;
            this.label1.Text = "Grand Total";
            // 
            // BillingDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(477, 262);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_current_page);
            this.Controls.Add(this.btn_reprint);
            this.Controls.Add(this.btn_create_new_billing);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BillingDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BillingDetails";
            this.Load += new System.EventHandler(this.BillingDetails_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private DevComponents.DotNetBar.ButtonX btn_reprint;
        private DevComponents.DotNetBar.ButtonX btn_current_page;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_change_amount;
        private System.Windows.Forms.Label lbl_received_amount;
        private System.Windows.Forms.Label lbl_grand_total;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public DevComponents.DotNetBar.ButtonX btn_create_new_billing;
    }
}