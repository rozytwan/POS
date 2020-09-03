namespace POS_System
{
    partial class Home_delivery_check
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_name = new System.Windows.Forms.TextBox();
            this.txt_amount = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_deliverby = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.lblkotid = new System.Windows.Forms.Label();
            this.homeId = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtcashier = new System.Windows.Forms.Label();
            this.lbl_payment_type = new System.Windows.Forms.Label();
            this.button1 = new DevComponents.DotNetBar.ButtonX();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkRed;
            this.label1.Location = new System.Drawing.Point(90, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Check Delivery ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(44, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Name:";
            // 
            // txt_name
            // 
            this.txt_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_name.Location = new System.Drawing.Point(95, 106);
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(184, 23);
            this.txt_name.TabIndex = 0;
            this.txt_name.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_name_KeyDown);
            // 
            // txt_amount
            // 
            this.txt_amount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_amount.Location = new System.Drawing.Point(95, 132);
            this.txt_amount.Name = "txt_amount";
            this.txt_amount.Size = new System.Drawing.Size(184, 23);
            this.txt_amount.TabIndex = 1;
            this.txt_amount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_amount_KeyDown);
            this.txt_amount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_amount_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(32, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Amount:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // txt_deliverby
            // 
            this.txt_deliverby.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_deliverby.Location = new System.Drawing.Point(95, 158);
            this.txt_deliverby.Name = "txt_deliverby";
            this.txt_deliverby.Size = new System.Drawing.Size(184, 23);
            this.txt_deliverby.TabIndex = 2;
            this.txt_deliverby.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_deliverby_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 161);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "Delivered By:";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Red;
            this.button2.Location = new System.Drawing.Point(253, 231);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(54, 28);
            this.button2.TabIndex = 4;
            this.button2.Text = "Exit";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lblkotid
            // 
            this.lblkotid.AutoSize = true;
            this.lblkotid.Location = new System.Drawing.Point(22, 24);
            this.lblkotid.Name = "lblkotid";
            this.lblkotid.Size = new System.Drawing.Size(31, 13);
            this.lblkotid.TabIndex = 9;
            this.lblkotid.Text = "Kotid";
            this.lblkotid.Visible = false;
            // 
            // homeId
            // 
            this.homeId.AutoSize = true;
            this.homeId.Location = new System.Drawing.Point(15, 40);
            this.homeId.Name = "homeId";
            this.homeId.Size = new System.Drawing.Size(41, 13);
            this.homeId.TabIndex = 10;
            this.homeId.Text = "homeid";
            this.homeId.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(28, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "Cashier :";
            // 
            // txtcashier
            // 
            this.txtcashier.AutoSize = true;
            this.txtcashier.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcashier.Location = new System.Drawing.Point(98, 77);
            this.txtcashier.Name = "txtcashier";
            this.txtcashier.Size = new System.Drawing.Size(56, 17);
            this.txtcashier.TabIndex = 12;
            this.txtcashier.Text = "Cashier";
            // 
            // lbl_payment_type
            // 
            this.lbl_payment_type.AutoSize = true;
            this.lbl_payment_type.Location = new System.Drawing.Point(15, 53);
            this.lbl_payment_type.Name = "lbl_payment_type";
            this.lbl_payment_type.Size = new System.Drawing.Size(47, 13);
            this.lbl_payment_type.TabIndex = 13;
            this.lbl_payment_type.Text = "payment";
            this.lbl_payment_type.Visible = false;
            // 
            // button1
            // 
            this.button1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button1.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(94, 188);
            this.button1.Name = "button1";
            this.button1.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(15);
            this.button1.Size = new System.Drawing.Size(185, 37);
            this.button1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button1.TabIndex = 14;
            this.button1.Text = "Payment Recieved";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Home_delivery_check
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 260);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lbl_payment_type);
            this.Controls.Add(this.txtcashier);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.homeId);
            this.Controls.Add(this.lblkotid);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txt_deliverby);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_amount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_name);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Home_delivery_check";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home_delivery_check";
            this.Load += new System.EventHandler(this.Home_delivery_check_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txt_name;
        public System.Windows.Forms.TextBox txt_amount;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txt_deliverby;
        public System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button2;
        public System.Windows.Forms.Label lblkotid;
        public System.Windows.Forms.Label homeId;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label txtcashier;
        public System.Windows.Forms.Label lbl_payment_type;
        private DevComponents.DotNetBar.ButtonX button1;
    }
}