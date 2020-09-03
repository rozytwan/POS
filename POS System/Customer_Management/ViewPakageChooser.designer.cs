namespace POS_System.Customer_Management
{
    partial class ViewPakageChooser
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
            this.components = new System.ComponentModel.Container();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txt_pakages = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.flp_pakages = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbo_packagename = new System.Windows.Forms.ComboBox();
            this.txt_name = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_setpakage = new System.Windows.Forms.Button();
            this.dgv_customers = new System.Windows.Forms.DataGridView();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colgender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colpakagename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colview = new System.Windows.Forms.DataGridViewButtonColumn();
            this.getcontextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_customers)).BeginInit();
            this.getcontextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(81)))), ((int)(((byte)(126)))));
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(904, 72);
            this.panel2.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(319, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(255, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Member with Packages";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.txt_pakages);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.flp_pakages);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 72);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(267, 589);
            this.panel3.TabIndex = 4;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // txt_pakages
            // 
            this.txt_pakages.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_pakages.Location = new System.Drawing.Point(137, 6);
            this.txt_pakages.Name = "txt_pakages";
            this.txt_pakages.Size = new System.Drawing.Size(124, 22);
            this.txt_pakages.TabIndex = 1;
            this.txt_pakages.TextChanged += new System.EventHandler(this.txt_pakages_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Package Search:";
            // 
            // flp_pakages
            // 
            this.flp_pakages.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(81)))), ((int)(((byte)(126)))));
            this.flp_pakages.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flp_pakages.Location = new System.Drawing.Point(3, 34);
            this.flp_pakages.Name = "flp_pakages";
            this.flp_pakages.Size = new System.Drawing.Size(261, 515);
            this.flp_pakages.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.btn_setpakage);
            this.panel1.Controls.Add(this.dgv_customers);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(267, 72);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(637, 589);
            this.panel1.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbo_packagename);
            this.groupBox1.Controls.Add(this.txt_name);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(5, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(399, 73);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search By:";
            // 
            // cbo_packagename
            // 
            this.cbo_packagename.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_packagename.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbo_packagename.FormattingEnabled = true;
            this.cbo_packagename.Location = new System.Drawing.Point(118, 41);
            this.cbo_packagename.Name = "cbo_packagename";
            this.cbo_packagename.Size = new System.Drawing.Size(273, 21);
            this.cbo_packagename.TabIndex = 13;
            this.cbo_packagename.SelectedIndexChanged += new System.EventHandler(this.cbo_packagename_SelectedIndexChanged);
            // 
            // txt_name
            // 
            this.txt_name.Location = new System.Drawing.Point(118, 15);
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(273, 20);
            this.txt_name.TabIndex = 12;
            this.txt_name.TextChanged += new System.EventHandler(this.txt_name_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(7, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 16);
            this.label4.TabIndex = 11;
            this.label4.Text = "Packae Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(64, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "Name:";
            // 
            // btn_setpakage
            // 
            this.btn_setpakage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(81)))), ((int)(((byte)(126)))));
            this.btn_setpakage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_setpakage.ForeColor = System.Drawing.Color.White;
            this.btn_setpakage.Location = new System.Drawing.Point(410, 7);
            this.btn_setpakage.Name = "btn_setpakage";
            this.btn_setpakage.Size = new System.Drawing.Size(223, 68);
            this.btn_setpakage.TabIndex = 5;
            this.btn_setpakage.Text = "Set Package to Customer";
            this.btn_setpakage.UseVisualStyleBackColor = false;
            this.btn_setpakage.Click += new System.EventHandler(this.btn_setpakage_Click);
            // 
            // dgv_customers
            // 
            this.dgv_customers.AllowUserToAddRows = false;
            this.dgv_customers.AllowUserToDeleteRows = false;
            this.dgv_customers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_customers.BackgroundColor = System.Drawing.Color.White;
            this.dgv_customers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_customers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.colName,
            this.colLastName,
            this.colgender,
            this.colpakagename,
            this.colview});
            this.dgv_customers.Location = new System.Drawing.Point(5, 84);
            this.dgv_customers.Name = "dgv_customers";
            this.dgv_customers.ReadOnly = true;
            this.dgv_customers.RowHeadersVisible = false;
            this.dgv_customers.Size = new System.Drawing.Size(628, 474);
            this.dgv_customers.TabIndex = 4;
            this.dgv_customers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_customers_CellClick);
            // 
            // colID
            // 
            this.colID.HeaderText = "Customer Id";
            this.colID.Name = "colID";
            this.colID.ReadOnly = true;
            this.colID.Visible = false;
            // 
            // colName
            // 
            this.colName.HeaderText = "Name";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            // 
            // colLastName
            // 
            this.colLastName.HeaderText = "LastName";
            this.colLastName.Name = "colLastName";
            this.colLastName.ReadOnly = true;
            // 
            // colgender
            // 
            this.colgender.HeaderText = "Gender";
            this.colgender.Name = "colgender";
            this.colgender.ReadOnly = true;
            // 
            // colpakagename
            // 
            this.colpakagename.HeaderText = "Pakage";
            this.colpakagename.Name = "colpakagename";
            this.colpakagename.ReadOnly = true;
            // 
            // colview
            // 
            this.colview.HeaderText = "View";
            this.colview.Name = "colview";
            this.colview.ReadOnly = true;
            this.colview.Text = "View ";
            this.colview.ToolTipText = "View Pakages of selected Customer";
            this.colview.UseColumnTextForButtonValue = true;
            // 
            // getcontextMenuStrip
            // 
            this.getcontextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripMenuItem});
            this.getcontextMenuStrip.Name = "getcontextMenuStrip";
            this.getcontextMenuStrip.Size = new System.Drawing.Size(114, 26);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // ViewPakageChooser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Name = "ViewPakageChooser";
            this.Size = new System.Drawing.Size(904, 661);
            this.Load += new System.EventHandler(this.ViewPakageChooser_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_customers)).EndInit();
            this.getcontextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flp_pakages;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_pakages;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgv_customers;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colgender;
        private System.Windows.Forms.DataGridViewTextBoxColumn colpakagename;
        private System.Windows.Forms.DataGridViewButtonColumn colview;
        private System.Windows.Forms.Button btn_setpakage;
        private System.Windows.Forms.ContextMenuStrip getcontextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbo_packagename;
        private System.Windows.Forms.TextBox txt_name;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}