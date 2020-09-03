namespace POS_System.CustomerLoyalty
{
    partial class ViewCustomerLoyaltyPoint
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
            this.backPanel = new System.Windows.Forms.Panel();
            this.txt_search = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cal_customer_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_card_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_customer_point = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_view = new System.Windows.Forms.DataGridViewButtonColumn();
            this.cal_adjust = new System.Windows.Forms.DataGridViewButtonColumn();
            this.cal_customer_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_excel = new DevComponents.DotNetBar.ButtonX();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_back = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label23 = new System.Windows.Forms.Label();
            this.backPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // backPanel
            // 
            this.backPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.backPanel.Controls.Add(this.txt_search);
            this.backPanel.Controls.Add(this.dataGridView1);
            this.backPanel.Controls.Add(this.btn_excel);
            this.backPanel.Controls.Add(this.panel2);
            this.backPanel.Location = new System.Drawing.Point(-4, -1);
            this.backPanel.Margin = new System.Windows.Forms.Padding(4);
            this.backPanel.Name = "backPanel";
            this.backPanel.Size = new System.Drawing.Size(1343, 820);
            this.backPanel.TabIndex = 3;
            // 
            // txt_search
            // 
            this.txt_search.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_search.Location = new System.Drawing.Point(71, 103);
            this.txt_search.Margin = new System.Windows.Forms.Padding(4);
            this.txt_search.Name = "txt_search";
            this.txt_search.Size = new System.Drawing.Size(535, 36);
            this.txt_search.TabIndex = 141;
            this.txt_search.Text = "Search";
            this.txt_search.TextChanged += new System.EventHandler(this.txt_search_TextChanged);
            this.txt_search.Enter += new System.EventHandler(this.txt_search_Enter);
            this.txt_search.Leave += new System.EventHandler(this.txt_search_Leave);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cal_customer_name,
            this.cal_phone,
            this.cal_card_no,
            this.cal_customer_point,
            this.cal_view,
            this.cal_adjust,
            this.cal_customer_id});
            this.dataGridView1.Location = new System.Drawing.Point(4, 153);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(1339, 663);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // cal_customer_name
            // 
            this.cal_customer_name.HeaderText = "Customer Name";
            this.cal_customer_name.Name = "cal_customer_name";
            this.cal_customer_name.ReadOnly = true;
            this.cal_customer_name.Width = 300;
            // 
            // cal_phone
            // 
            this.cal_phone.HeaderText = "Phone";
            this.cal_phone.Name = "cal_phone";
            this.cal_phone.ReadOnly = true;
            this.cal_phone.Width = 200;
            // 
            // cal_card_no
            // 
            this.cal_card_no.HeaderText = "Card No";
            this.cal_card_no.Name = "cal_card_no";
            this.cal_card_no.ReadOnly = true;
            this.cal_card_no.Width = 200;
            // 
            // cal_customer_point
            // 
            this.cal_customer_point.HeaderText = "Customer Point";
            this.cal_customer_point.Name = "cal_customer_point";
            this.cal_customer_point.ReadOnly = true;
            // 
            // cal_view
            // 
            this.cal_view.HeaderText = "View";
            this.cal_view.Name = "cal_view";
            this.cal_view.ReadOnly = true;
            this.cal_view.Text = "View";
            this.cal_view.ToolTipText = "View";
            this.cal_view.UseColumnTextForButtonValue = true;
            this.cal_view.Visible = false;
            // 
            // cal_adjust
            // 
            this.cal_adjust.HeaderText = "Adjust";
            this.cal_adjust.Name = "cal_adjust";
            this.cal_adjust.ReadOnly = true;
            this.cal_adjust.Text = "Adjust";
            this.cal_adjust.ToolTipText = "Adjust";
            this.cal_adjust.UseColumnTextForButtonValue = true;
            this.cal_adjust.Visible = false;
            // 
            // cal_customer_id
            // 
            this.cal_customer_id.HeaderText = "Customer_id";
            this.cal_customer_id.Name = "cal_customer_id";
            this.cal_customer_id.ReadOnly = true;
            this.cal_customer_id.Visible = false;
            // 
            // btn_excel
            // 
            this.btn_excel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_excel.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btn_excel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_excel.Location = new System.Drawing.Point(1120, 95);
            this.btn_excel.Margin = new System.Windows.Forms.Padding(4);
            this.btn_excel.Name = "btn_excel";
            this.btn_excel.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(14);
            this.btn_excel.Size = new System.Drawing.Size(208, 50);
            this.btn_excel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_excel.Symbol = "";
            this.btn_excel.TabIndex = 140;
            this.btn_excel.Text = "Export to Excel";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(81)))), ((int)(((byte)(126)))));
            this.panel2.Controls.Add(this.btn_back);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.label23);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1343, 90);
            this.panel2.TabIndex = 130;
            // 
            // btn_back
            // 
            this.btn_back.FlatAppearance.BorderSize = 0;
            this.btn_back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_back.Image = global::POS_System.Properties.Resources.back36;
            this.btn_back.Location = new System.Drawing.Point(4, 4);
            this.btn_back.Margin = new System.Windows.Forms.Padding(4);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(123, 80);
            this.btn_back.TabIndex = 20;
            this.btn_back.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::POS_System.Properties.Resources.check__1_;
            this.pictureBox1.Location = new System.Drawing.Point(408, 6);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(95, 84);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 26;
            this.pictureBox1.TabStop = false;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.White;
            this.label23.Location = new System.Drawing.Point(497, 23);
            this.label23.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(525, 48);
            this.label23.TabIndex = 18;
            this.label23.Text = "View Details  Sales Report ";
            // 
            // ViewCustomerLoyaltyPoint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.backPanel);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ViewCustomerLoyaltyPoint";
            this.Size = new System.Drawing.Size(1340, 812);
            this.Load += new System.EventHandler(this.ViewCustomerLoyaltyPoint_Load);
            this.backPanel.ResumeLayout(false);
            this.backPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel backPanel;
        private DevComponents.DotNetBar.ButtonX btn_excel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_back;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txt_search;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_customer_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_card_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_customer_point;
        private System.Windows.Forms.DataGridViewButtonColumn cal_view;
        private System.Windows.Forms.DataGridViewButtonColumn cal_adjust;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_customer_id;
    }
}