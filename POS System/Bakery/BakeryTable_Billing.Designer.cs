﻿namespace POS_System.Table_Management
{
    partial class BakeryTable_Billing
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_back = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_header = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonX2 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX3 = new DevComponents.DotNetBar.ButtonX();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(81)))), ((int)(((byte)(126)))));
            this.panel2.Controls.Add(this.btn_back);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txt_header);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1025, 59);
            this.panel2.TabIndex = 299;
            // 
            // btn_back
            // 
            this.btn_back.FlatAppearance.BorderSize = 0;
            this.btn_back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_back.Image = global::POS_System.Properties.Resources.back36;
            this.btn_back.Location = new System.Drawing.Point(0, -2);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(78, 61);
            this.btn_back.TabIndex = 22;
            this.btn_back.UseVisualStyleBackColor = true;
            this.btn_back.Click += new System.EventHandler(this.btn_back_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::POS_System.Properties.Resources.food__1_;
            this.pictureBox1.Location = new System.Drawing.Point(365, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(61, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(864, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 7;
            this.label1.Visible = false;
            // 
            // txt_header
            // 
            this.txt_header.AutoSize = true;
            this.txt_header.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.txt_header.ForeColor = System.Drawing.Color.White;
            this.txt_header.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txt_header.Location = new System.Drawing.Point(432, 14);
            this.txt_header.Name = "txt_header";
            this.txt_header.Size = new System.Drawing.Size(82, 31);
            this.txt_header.TabIndex = 6;
            this.txt_header.Text = "Table";
            this.txt_header.Click += new System.EventHandler(this.txt_header_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(1, 65);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(863, 613);
            this.panel1.TabIndex = 307;
            this.panel1.DragEnter += new System.Windows.Forms.DragEventHandler(this.panel1_DragEnter);
            // 
            // buttonX2
            // 
            this.buttonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.buttonX2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonX2.Location = new System.Drawing.Point(870, 65);
            this.buttonX2.Name = "buttonX2";
            this.buttonX2.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(15);
            this.buttonX2.Size = new System.Drawing.Size(131, 66);
            this.buttonX2.TabIndex = 312;
            this.buttonX2.Text = "Home Delivery";
            this.buttonX2.Click += new System.EventHandler(this.btnhomedelivery1_Click);
            // 
            // buttonX3
            // 
            this.buttonX3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX3.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.buttonX3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonX3.Location = new System.Drawing.Point(868, 137);
            this.buttonX3.Name = "buttonX3";
            this.buttonX3.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(15);
            this.buttonX3.Size = new System.Drawing.Size(131, 66);
            this.buttonX3.TabIndex = 313;
            this.buttonX3.Text = "Take Away";
            this.buttonX3.Click += new System.EventHandler(this.btntakeaway_Click);
            // 
            // BakeryTable_Billing
            // 
            this.AllowDrop = true;
            this.Controls.Add(this.buttonX3);
            this.Controls.Add(this.buttonX2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "BakeryTable_Billing";
            this.Size = new System.Drawing.Size(1025, 681);
            this.Load += new System.EventHandler(this.BakeryTable_Billing_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label txt_header;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_back;
        private System.Windows.Forms.FlowLayoutPanel panel1;
        private DevComponents.DotNetBar.ButtonX buttonX2;
        private DevComponents.DotNetBar.ButtonX buttonX3;
        public System.Windows.Forms.Label label1;
    }
}