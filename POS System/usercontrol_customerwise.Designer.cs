﻿namespace POS_System
{
    partial class usercontrol_customerwise
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtusername = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.calcustomer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.caltable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calitem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calquantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calitemprice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.caltotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.caldate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_back = new System.Windows.Forms.Button();
            this.label23 = new System.Windows.Forms.Label();
            this.btnsearch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtusername
            // 
            this.txtusername.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtusername.Location = new System.Drawing.Point(298, 114);
            this.txtusername.Multiline = true;
            this.txtusername.Name = "txtusername";
            this.txtusername.Size = new System.Drawing.Size(275, 30);
            this.txtusername.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(132, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 20);
            this.label1.TabIndex = 104;
            this.label1.Tag = "";
            this.label1.Text = "Search By Username";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.calcustomer,
            this.caltable,
            this.calitem,
            this.calquantity,
            this.calitemprice,
            this.caltotal,
            this.caldate});
            this.dataGridView1.Location = new System.Drawing.Point(69, 151);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(745, 281);
            this.dataGridView1.TabIndex = 103;
            // 
            // calcustomer
            // 
            this.calcustomer.HeaderText = "Customer Name";
            this.calcustomer.Name = "calcustomer";
            this.calcustomer.ReadOnly = true;
            // 
            // caltable
            // 
            this.caltable.HeaderText = "Table No.";
            this.caltable.Name = "caltable";
            this.caltable.ReadOnly = true;
            // 
            // calitem
            // 
            this.calitem.HeaderText = "Item";
            this.calitem.Name = "calitem";
            this.calitem.ReadOnly = true;
            // 
            // calquantity
            // 
            this.calquantity.HeaderText = "Quantity";
            this.calquantity.Name = "calquantity";
            this.calquantity.ReadOnly = true;
            // 
            // calitemprice
            // 
            this.calitemprice.HeaderText = "Item Price";
            this.calitemprice.Name = "calitemprice";
            this.calitemprice.ReadOnly = true;
            // 
            // caltotal
            // 
            this.caltotal.HeaderText = "Total";
            this.caltotal.Name = "caltotal";
            this.caltotal.ReadOnly = true;
            // 
            // caldate
            // 
            this.caldate.HeaderText = "Date";
            this.caldate.Name = "caldate";
            this.caldate.ReadOnly = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(81)))), ((int)(((byte)(126)))));
            this.panel2.Controls.Add(this.btn_back);
            this.panel2.Controls.Add(this.label23);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1024, 73);
            this.panel2.TabIndex = 107;
            // 
            // btn_back
            // 
            this.btn_back.FlatAppearance.BorderSize = 0;
            this.btn_back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_back.Image = global::POS_System.Properties.Resources.back36;
            this.btn_back.Location = new System.Drawing.Point(3, 5);
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
            this.label23.Location = new System.Drawing.Point(320, 18);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(275, 39);
            this.label23.TabIndex = 18;
            this.label23.Text = "Customer Report";
            // 
            // btnsearch
            // 
            this.btnsearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.btnsearch.FlatAppearance.BorderSize = 0;
            this.btnsearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsearch.ForeColor = System.Drawing.Color.White;
            this.btnsearch.Image = global::POS_System.Properties.Resources.magnifying_glass34;
            this.btnsearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnsearch.Location = new System.Drawing.Point(579, 111);
            this.btnsearch.Name = "btnsearch";
            this.btnsearch.Size = new System.Drawing.Size(120, 34);
            this.btnsearch.TabIndex = 1;
            this.btnsearch.Text = "Search";
            this.btnsearch.UseVisualStyleBackColor = false;
            this.btnsearch.Click += new System.EventHandler(this.btnsearch_Click);
            // 
            // usercontrol_customerwise
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtusername);
            this.Controls.Add(this.btnsearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel2);
            this.Name = "usercontrol_customerwise";
            this.Size = new System.Drawing.Size(1024, 511);
            this.Load += new System.EventHandler(this.usercontrol_customerwise_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtusername;
        private System.Windows.Forms.Button btnsearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_back;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.DataGridViewTextBoxColumn calcustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn caltable;
        private System.Windows.Forms.DataGridViewTextBoxColumn calitem;
        private System.Windows.Forms.DataGridViewTextBoxColumn calquantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn calitemprice;
        private System.Windows.Forms.DataGridViewTextBoxColumn caltotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn caldate;
    }
}