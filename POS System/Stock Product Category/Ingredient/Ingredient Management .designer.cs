namespace POS_System
{
    partial class Ingredient_Management
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_total_cost = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.btn_calculation = new System.Windows.Forms.Button();
            this.panel_calculation = new System.Windows.Forms.Panel();
            this.txt_overhead = new System.Windows.Forms.TextBox();
            this.txt_labour = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_back = new System.Windows.Forms.Button();
            this.panel9 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.Name_panel = new System.Windows.Forms.Panel();
            this.lbl_manuName = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lbl_cost = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txt_unit = new System.Windows.Forms.Label();
            this.cmb_location = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lbl_err = new System.Windows.Forms.Label();
            this.txt_units = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnadd = new System.Windows.Forms.Button();
            this.cbocategorynamess = new System.Windows.Forms.ComboBox();
            this.cboproductname = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txt_item_name = new System.Windows.Forms.TextBox();
            this.txt_category_name = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colMenuId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_product_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMenuname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colinvCategoryId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colinvProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_location = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunitMeasures = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colremove = new System.Windows.Forms.DataGridViewButtonColumn();
            this.col_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbl_totalcost = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel_calculation.SuspendLayout();
            this.panel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel9.SuspendLayout();
            this.Name_panel.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lbl_total_cost);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.btn_calculation);
            this.panel1.Controls.Add(this.panel_calculation);
            this.panel1.Controls.Add(this.panel10);
            this.panel1.Controls.Add(this.panel9);
            this.panel1.Controls.Add(this.Name_panel);
            this.panel1.Controls.Add(this.panel7);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1027, 720);
            this.panel1.TabIndex = 0;
            // 
            // lbl_total_cost
            // 
            this.lbl_total_cost.AutoSize = true;
            this.lbl_total_cost.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_total_cost.ForeColor = System.Drawing.Color.Red;
            this.lbl_total_cost.Location = new System.Drawing.Point(661, 610);
            this.lbl_total_cost.Name = "lbl_total_cost";
            this.lbl_total_cost.Size = new System.Drawing.Size(44, 20);
            this.lbl_total_cost.TabIndex = 169;
            this.lbl_total_cost.Text = "0.00";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.Gray;
            this.label18.Location = new System.Drawing.Point(566, 610);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(89, 20);
            this.label18.TabIndex = 168;
            this.label18.Text = "Total Cost :";
            // 
            // btn_calculation
            // 
            this.btn_calculation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.btn_calculation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_calculation.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_calculation.ForeColor = System.Drawing.Color.White;
            this.btn_calculation.Location = new System.Drawing.Point(764, 600);
            this.btn_calculation.Name = "btn_calculation";
            this.btn_calculation.Size = new System.Drawing.Size(250, 35);
            this.btn_calculation.TabIndex = 167;
            this.btn_calculation.Text = "Ingredient Calculation Cost";
            this.btn_calculation.UseVisualStyleBackColor = false;
            this.btn_calculation.Click += new System.EventHandler(this.btn_calculation_Click);
            // 
            // panel_calculation
            // 
            this.panel_calculation.Controls.Add(this.txt_overhead);
            this.panel_calculation.Controls.Add(this.txt_labour);
            this.panel_calculation.Controls.Add(this.label13);
            this.panel_calculation.Controls.Add(this.label16);
            this.panel_calculation.Location = new System.Drawing.Point(759, 637);
            this.panel_calculation.Name = "panel_calculation";
            this.panel_calculation.Size = new System.Drawing.Size(254, 80);
            this.panel_calculation.TabIndex = 166;
            // 
            // txt_overhead
            // 
            this.txt_overhead.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_overhead.Location = new System.Drawing.Point(138, 36);
            this.txt_overhead.Name = "txt_overhead";
            this.txt_overhead.Size = new System.Drawing.Size(110, 26);
            this.txt_overhead.TabIndex = 165;
            this.txt_overhead.Text = "0.00";
            this.txt_overhead.TextChanged += new System.EventHandler(this.txt_overhead_TextChanged);
            // 
            // txt_labour
            // 
            this.txt_labour.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_labour.Location = new System.Drawing.Point(138, 4);
            this.txt_labour.Name = "txt_labour";
            this.txt_labour.Size = new System.Drawing.Size(110, 26);
            this.txt_labour.TabIndex = 164;
            this.txt_labour.Text = "0.00";
            this.txt_labour.TextChanged += new System.EventHandler(this.txt_labour_TextChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Gray;
            this.label13.Location = new System.Drawing.Point(24, 13);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(108, 20);
            this.label13.TabIndex = 162;
            this.label13.Text = " Labour Cost :";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Gray;
            this.label16.Location = new System.Drawing.Point(5, 39);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(127, 20);
            this.label16.TabIndex = 163;
            this.label16.Text = " Overhead Cost :";
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(81)))), ((int)(((byte)(126)))));
            this.panel10.Controls.Add(this.label6);
            this.panel10.Controls.Add(this.pictureBox1);
            this.panel10.Controls.Add(this.btn_back);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel10.Location = new System.Drawing.Point(0, 0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(1027, 77);
            this.panel10.TabIndex = 156;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(405, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(239, 39);
            this.label6.TabIndex = 159;
            this.label6.Text = "Add Ingredient";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::POS_System.Properties.Resources.ingredients_list;
            this.pictureBox1.Location = new System.Drawing.Point(328, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(71, 68);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 23;
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
            this.btn_back.TabIndex = 21;
            this.btn_back.UseVisualStyleBackColor = true;
            this.btn_back.Click += new System.EventHandler(this.btn_back_Click);
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(81)))), ((int)(((byte)(126)))));
            this.panel9.Controls.Add(this.label11);
            this.panel9.Location = new System.Drawing.Point(550, 79);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(463, 57);
            this.panel9.TabIndex = 150;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(126, 18);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(208, 20);
            this.label11.TabIndex = 0;
            this.label11.Text = "Menu And Stock Product";
            // 
            // Name_panel
            // 
            this.Name_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(81)))), ((int)(((byte)(126)))));
            this.Name_panel.Controls.Add(this.lbl_manuName);
            this.Name_panel.Controls.Add(this.label7);
            this.Name_panel.Location = new System.Drawing.Point(25, 83);
            this.Name_panel.Name = "Name_panel";
            this.Name_panel.Size = new System.Drawing.Size(494, 58);
            this.Name_panel.TabIndex = 149;
            // 
            // lbl_manuName
            // 
            this.lbl_manuName.AutoSize = true;
            this.lbl_manuName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_manuName.ForeColor = System.Drawing.Color.White;
            this.lbl_manuName.Location = new System.Drawing.Point(124, 16);
            this.lbl_manuName.Name = "lbl_manuName";
            this.lbl_manuName.Size = new System.Drawing.Size(14, 20);
            this.lbl_manuName.TabIndex = 1;
            this.lbl_manuName.Text = ":";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(18, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 20);
            this.label7.TabIndex = 0;
            this.label7.Text = "Menu Name:";
            // 
            // panel7
            // 
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.panel8);
            this.panel7.Controls.Add(this.button3);
            this.panel7.Location = new System.Drawing.Point(27, 609);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(493, 103);
            this.panel7.TabIndex = 148;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(81)))), ((int)(((byte)(126)))));
            this.panel8.Controls.Add(this.label14);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(491, 34);
            this.panel8.TabIndex = 110;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(171, 4);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(149, 25);
            this.label14.TabIndex = 0;
            this.label14.Text = "Ingredient Save";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(316, 40);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(131, 53);
            this.button3.TabIndex = 150;
            this.button3.Text = "Save";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.lbl_cost);
            this.panel4.Controls.Add(this.label12);
            this.panel4.Controls.Add(this.txt_unit);
            this.panel4.Controls.Add(this.cmb_location);
            this.panel4.Controls.Add(this.label9);
            this.panel4.Controls.Add(this.lbl_err);
            this.panel4.Controls.Add(this.txt_units);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Controls.Add(this.button1);
            this.panel4.Controls.Add(this.btnadd);
            this.panel4.Controls.Add(this.cbocategorynamess);
            this.panel4.Controls.Add(this.cboproductname);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.panel6);
            this.panel4.Location = new System.Drawing.Point(550, 302);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(463, 296);
            this.panel4.TabIndex = 10;
            // 
            // lbl_cost
            // 
            this.lbl_cost.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_cost.Location = new System.Drawing.Point(346, 207);
            this.lbl_cost.Name = "lbl_cost";
            this.lbl_cost.Size = new System.Drawing.Size(96, 26);
            this.lbl_cost.TabIndex = 165;
            this.lbl_cost.Text = "0.00";
            this.lbl_cost.TextChanged += new System.EventHandler(this.lbl_cost_TextChanged);
            this.lbl_cost.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lbl_cost_KeyPress);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Gray;
            this.label12.Location = new System.Drawing.Point(213, 210);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(130, 20);
            this.label12.TabIndex = 160;
            this.label12.Text = " Ingredient Cost :";
            this.label12.Click += new System.EventHandler(this.label12_Click);
            // 
            // txt_unit
            // 
            this.txt_unit.AutoSize = true;
            this.txt_unit.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_unit.Location = new System.Drawing.Point(285, 170);
            this.txt_unit.Name = "txt_unit";
            this.txt_unit.Size = new System.Drawing.Size(17, 25);
            this.txt_unit.TabIndex = 157;
            this.txt_unit.Text = ".";
            // 
            // cmb_location
            // 
            this.cmb_location.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmb_location.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmb_location.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_location.FormattingEnabled = true;
            this.cmb_location.Items.AddRange(new object[] {
            "M",
            "K1",
            "K2",
            "BOT",
            "S1",
            "S2",
            "S3",
            "Branch 1",
            "Branch 2",
            "Branch 3"});
            this.cmb_location.Location = new System.Drawing.Point(164, 128);
            this.cmb_location.Name = "cmb_location";
            this.cmb_location.Size = new System.Drawing.Size(273, 33);
            this.cmb_location.TabIndex = 156;
            this.cmb_location.SelectedIndexChanged += new System.EventHandler(this.cmb_location_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(80, 138);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 20);
            this.label9.TabIndex = 155;
            this.label9.Text = "Location :";
            // 
            // lbl_err
            // 
            this.lbl_err.AutoSize = true;
            this.lbl_err.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_err.ForeColor = System.Drawing.Color.Red;
            this.lbl_err.Location = new System.Drawing.Point(163, 271);
            this.lbl_err.Name = "lbl_err";
            this.lbl_err.Size = new System.Drawing.Size(47, 20);
            this.lbl_err.TabIndex = 153;
            this.lbl_err.Text = "Note:";
            // 
            // txt_units
            // 
            this.txt_units.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_units.Location = new System.Drawing.Point(165, 166);
            this.txt_units.Name = "txt_units";
            this.txt_units.Size = new System.Drawing.Size(110, 33);
            this.txt_units.TabIndex = 151;
            this.txt_units.TextChanged += new System.EventHandler(this.txt_units_TextChanged);
            this.txt_units.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_units_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(121, 176);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 20);
            this.label8.TabIndex = 150;
            this.label8.Text = "Unit:";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(164, 233);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(138, 35);
            this.button1.TabIndex = 149;
            this.button1.Text = "Refresh";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnadd
            // 
            this.btnadd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.btnadd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnadd.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnadd.ForeColor = System.Drawing.Color.White;
            this.btnadd.Location = new System.Drawing.Point(308, 233);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(136, 35);
            this.btnadd.TabIndex = 148;
            this.btnadd.Text = "Add";
            this.btnadd.UseVisualStyleBackColor = false;
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // cbocategorynamess
            // 
            this.cbocategorynamess.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbocategorynamess.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbocategorynamess.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbocategorynamess.FormattingEnabled = true;
            this.cbocategorynamess.Location = new System.Drawing.Point(164, 41);
            this.cbocategorynamess.Name = "cbocategorynamess";
            this.cbocategorynamess.Size = new System.Drawing.Size(273, 33);
            this.cbocategorynamess.TabIndex = 138;
            this.cbocategorynamess.SelectedIndexChanged += new System.EventHandler(this.cbocategorynamess_SelectedIndexChanged);
            // 
            // cboproductname
            // 
            this.cboproductname.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboproductname.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboproductname.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboproductname.FormattingEnabled = true;
            this.cboproductname.Location = new System.Drawing.Point(164, 89);
            this.cboproductname.Name = "cboproductname";
            this.cboproductname.Size = new System.Drawing.Size(273, 33);
            this.cboproductname.TabIndex = 139;
            this.cboproductname.SelectedIndexChanged += new System.EventHandler(this.cboproductname_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(48, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 20);
            this.label4.TabIndex = 140;
            this.label4.Text = "Product Name:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(39, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 20);
            this.label5.TabIndex = 141;
            this.label5.Text = "Catagory Name:";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(81)))), ((int)(((byte)(126)))));
            this.panel6.Controls.Add(this.label3);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(461, 34);
            this.panel6.TabIndex = 110;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(171, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(164, 25);
            this.label3.TabIndex = 0;
            this.label3.Text = "Inventory Product";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.txt_item_name);
            this.panel3.Controls.Add(this.txt_category_name);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(550, 142);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(463, 153);
            this.panel3.TabIndex = 9;
            // 
            // txt_item_name
            // 
            this.txt_item_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_item_name.Location = new System.Drawing.Point(176, 101);
            this.txt_item_name.Name = "txt_item_name";
            this.txt_item_name.Size = new System.Drawing.Size(265, 29);
            this.txt_item_name.TabIndex = 153;
            // 
            // txt_category_name
            // 
            this.txt_category_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_category_name.Location = new System.Drawing.Point(175, 59);
            this.txt_category_name.Name = "txt_category_name";
            this.txt_category_name.Size = new System.Drawing.Size(265, 29);
            this.txt_category_name.TabIndex = 152;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(81)))), ((int)(((byte)(126)))));
            this.panel5.Controls.Add(this.label1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(461, 34);
            this.panel5.TabIndex = 109;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(162, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Restaurant (Menu)";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(4, 59);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(159, 20);
            this.label10.TabIndex = 107;
            this.label10.Text = "Item Category Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(69, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 20);
            this.label2.TabIndex = 106;
            this.label2.Text = "Menu Name:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Controls.Add(this.lbl_totalcost);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Location = new System.Drawing.Point(25, 144);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(495, 459);
            this.panel2.TabIndex = 8;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMenuId,
            this.col_product_id,
            this.colMenuname,
            this.colinvCategoryId,
            this.colinvProductName,
            this.col_location,
            this.colunitMeasures,
            this.colunit,
            this.col_cost,
            this.colremove,
            this.col_id});
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(489, 412);
            this.dataGridView1.TabIndex = 164;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // colMenuId
            // 
            this.colMenuId.HeaderText = "MenuCategoryid";
            this.colMenuId.Name = "colMenuId";
            this.colMenuId.ReadOnly = true;
            this.colMenuId.Visible = false;
            // 
            // col_product_id
            // 
            this.col_product_id.HeaderText = "Product_id";
            this.col_product_id.Name = "col_product_id";
            this.col_product_id.ReadOnly = true;
            this.col_product_id.Visible = false;
            // 
            // colMenuname
            // 
            this.colMenuname.HeaderText = "Menuname";
            this.colMenuname.Name = "colMenuname";
            this.colMenuname.ReadOnly = true;
            this.colMenuname.Visible = false;
            // 
            // colinvCategoryId
            // 
            this.colinvCategoryId.HeaderText = "InvCategory";
            this.colinvCategoryId.Name = "colinvCategoryId";
            this.colinvCategoryId.ReadOnly = true;
            this.colinvCategoryId.Visible = false;
            // 
            // colinvProductName
            // 
            this.colinvProductName.HeaderText = "Inventory Name";
            this.colinvProductName.Name = "colinvProductName";
            this.colinvProductName.ReadOnly = true;
            // 
            // col_location
            // 
            this.col_location.HeaderText = "Location";
            this.col_location.Name = "col_location";
            this.col_location.ReadOnly = true;
            // 
            // colunitMeasures
            // 
            this.colunitMeasures.HeaderText = "Measures";
            this.colunitMeasures.Name = "colunitMeasures";
            this.colunitMeasures.ReadOnly = true;
            // 
            // colunit
            // 
            this.colunit.HeaderText = "Unit";
            this.colunit.Name = "colunit";
            this.colunit.ReadOnly = true;
            // 
            // col_cost
            // 
            this.col_cost.HeaderText = "Cost";
            this.col_cost.Name = "col_cost";
            this.col_cost.ReadOnly = true;
            // 
            // colremove
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(81)))), ((int)(((byte)(126)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(81)))), ((int)(((byte)(126)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.colremove.DefaultCellStyle = dataGridViewCellStyle1;
            this.colremove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colremove.HeaderText = "Remove";
            this.colremove.Name = "colremove";
            this.colremove.ReadOnly = true;
            this.colremove.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colremove.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colremove.Text = "Remove";
            this.colremove.UseColumnTextForButtonValue = true;
            // 
            // col_id
            // 
            this.col_id.HeaderText = " Id";
            this.col_id.Name = "col_id";
            this.col_id.ReadOnly = true;
            this.col_id.Visible = false;
            // 
            // lbl_totalcost
            // 
            this.lbl_totalcost.AutoSize = true;
            this.lbl_totalcost.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_totalcost.ForeColor = System.Drawing.Color.Red;
            this.lbl_totalcost.Location = new System.Drawing.Point(329, 430);
            this.lbl_totalcost.Name = "lbl_totalcost";
            this.lbl_totalcost.Size = new System.Drawing.Size(44, 20);
            this.lbl_totalcost.TabIndex = 163;
            this.lbl_totalcost.Text = "0.00";
            this.lbl_totalcost.TextChanged += new System.EventHandler(this.lbl_totalcost_TextChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Gray;
            this.label15.Location = new System.Drawing.Point(158, 430);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(165, 20);
            this.label15.TabIndex = 162;
            this.label15.Text = "Total Ingredient Cost :";
            // 
            // Ingredient_Management
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "Ingredient_Management";
            this.Size = new System.Drawing.Size(1027, 720);
            this.Load += new System.EventHandler(this.Ingredient_Management_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel_calculation.ResumeLayout(false);
            this.panel_calculation.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.Name_panel.ResumeLayout(false);
            this.Name_panel.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbocategorynamess;
        private System.Windows.Forms.ComboBox cboproductname;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnadd;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox txt_units;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel Name_panel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbl_manuName;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lbl_err;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_back;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.TextBox txt_item_name;
        public System.Windows.Forms.TextBox txt_category_name;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmb_location;
        private System.Windows.Forms.Label txt_unit;
        private System.Windows.Forms.Label lbl_total_cost;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button btn_calculation;
        private System.Windows.Forms.Panel panel_calculation;
        private System.Windows.Forms.TextBox txt_overhead;
        private System.Windows.Forms.TextBox txt_labour;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lbl_totalcost;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMenuId;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_product_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMenuname;
        private System.Windows.Forms.DataGridViewTextBoxColumn colinvCategoryId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colinvProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_location;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunitMeasures;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunit;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_cost;
        private System.Windows.Forms.DataGridViewButtonColumn colremove;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_id;
        private System.Windows.Forms.TextBox lbl_cost;
    }
}