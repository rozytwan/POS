namespace POS_System.Loyality
{
    partial class Loyality_Amount
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbn_true = new System.Windows.Forms.RadioButton();
            this.rbn_false = new System.Windows.Forms.RadioButton();
            this.btn_save = new DevComponents.DotNetBar.ButtonX();
            this.btn_update = new DevComponents.DotNetBar.ButtonX();
            this.btn_edit = new DevComponents.DotNetBar.ButtonX();
            this.panel9 = new System.Windows.Forms.Panel();
            this.txt_points = new System.Windows.Forms.TextBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.txt_to = new System.Windows.Forms.TextBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.txt_from = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_back = new System.Windows.Forms.Button();
            this.lbl_addcategory = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.col_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_from = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_to = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_points = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.btn_save);
            this.panel1.Controls.Add(this.btn_update);
            this.panel1.Controls.Add(this.btn_edit);
            this.panel1.Controls.Add(this.panel9);
            this.panel1.Controls.Add(this.panel7);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel10);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(3, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(959, 641);
            this.panel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbn_true);
            this.groupBox1.Controls.Add(this.rbn_false);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(568, 258);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(383, 74);
            this.groupBox1.TabIndex = 59;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Loyality Status";
            // 
            // rbn_true
            // 
            this.rbn_true.AutoSize = true;
            this.rbn_true.Checked = true;
            this.rbn_true.Location = new System.Drawing.Point(27, 34);
            this.rbn_true.Name = "rbn_true";
            this.rbn_true.Size = new System.Drawing.Size(59, 24);
            this.rbn_true.TabIndex = 59;
            this.rbn_true.TabStop = true;
            this.rbn_true.Text = "True";
            this.rbn_true.UseVisualStyleBackColor = true;
            this.rbn_true.Click += new System.EventHandler(this.rbn_true_Click);
            // 
            // rbn_false
            // 
            this.rbn_false.AutoSize = true;
            this.rbn_false.Location = new System.Drawing.Point(131, 34);
            this.rbn_false.Name = "rbn_false";
            this.rbn_false.Size = new System.Drawing.Size(66, 24);
            this.rbn_false.TabIndex = 58;
            this.rbn_false.Text = "False";
            this.rbn_false.UseVisualStyleBackColor = true;
            this.rbn_false.Click += new System.EventHandler(this.rbn_false_Click);
            // 
            // btn_save
            // 
            this.btn_save.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_save.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btn_save.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save.Location = new System.Drawing.Point(698, 338);
            this.btn_save.Name = "btn_save";
            this.btn_save.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(15);
            this.btn_save.Size = new System.Drawing.Size(116, 48);
            this.btn_save.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_save.Symbol = "";
            this.btn_save.TabIndex = 55;
            this.btn_save.Text = "Save";
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_update
            // 
            this.btn_update.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_update.BackColor = System.Drawing.Color.Transparent;
            this.btn_update.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btn_update.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_update.Location = new System.Drawing.Point(835, 338);
            this.btn_update.Name = "btn_update";
            this.btn_update.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(15);
            this.btn_update.Size = new System.Drawing.Size(116, 48);
            this.btn_update.Symbol = "";
            this.btn_update.TabIndex = 54;
            this.btn_update.Text = "Update";
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // btn_edit
            // 
            this.btn_edit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_edit.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btn_edit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_edit.Location = new System.Drawing.Point(9, 573);
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(15);
            this.btn_edit.Size = new System.Drawing.Size(116, 48);
            this.btn_edit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_edit.Symbol = "";
            this.btn_edit.TabIndex = 53;
            this.btn_edit.Text = "Edit";
            this.btn_edit.Click += new System.EventHandler(this.btn_edit_Click);
            // 
            // panel9
            // 
            this.panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel9.Controls.Add(this.txt_points);
            this.panel9.Location = new System.Drawing.Point(694, 197);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(257, 51);
            this.panel9.TabIndex = 51;
            // 
            // txt_points
            // 
            this.txt_points.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_points.Location = new System.Drawing.Point(3, 7);
            this.txt_points.Name = "txt_points";
            this.txt_points.Size = new System.Drawing.Size(249, 30);
            this.txt_points.TabIndex = 0;
            this.txt_points.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_points_KeyPress);
            // 
            // panel7
            // 
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.txt_to);
            this.panel7.Location = new System.Drawing.Point(694, 142);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(257, 48);
            this.panel7.TabIndex = 50;
            // 
            // txt_to
            // 
            this.txt_to.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_to.Location = new System.Drawing.Point(4, 9);
            this.txt_to.Name = "txt_to";
            this.txt_to.Size = new System.Drawing.Size(248, 30);
            this.txt_to.TabIndex = 0;
            this.txt_to.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_to_KeyPress);
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.txt_from);
            this.panel6.Location = new System.Drawing.Point(694, 86);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(257, 46);
            this.panel6.TabIndex = 49;
            // 
            // txt_from
            // 
            this.txt_from.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_from.Location = new System.Drawing.Point(3, 7);
            this.txt_from.Name = "txt_from";
            this.txt_from.Size = new System.Drawing.Size(248, 30);
            this.txt_from.TabIndex = 1;
            this.txt_from.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_from_KeyPress);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.panel8);
            this.panel5.Controls.Add(this.label9);
            this.panel5.Location = new System.Drawing.Point(568, 197);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(125, 51);
            this.panel5.TabIndex = 45;
            // 
            // panel8
            // 
            this.panel8.Location = new System.Drawing.Point(123, 3);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(277, 51);
            this.panel8.TabIndex = 25;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(56, 17);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 20);
            this.label9.TabIndex = 7;
            this.label9.Text = "Points";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.label2);
            this.panel4.Location = new System.Drawing.Point(568, 142);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(125, 50);
            this.panel4.TabIndex = 46;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(22, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Amount To";
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.Gainsboro;
            this.panel10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel10.Controls.Add(this.label4);
            this.panel10.Location = new System.Drawing.Point(568, 86);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(124, 46);
            this.panel10.TabIndex = 47;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Amount From";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(81)))), ((int)(((byte)(126)))));
            this.panel2.Controls.Add(this.btn_back);
            this.panel2.Controls.Add(this.lbl_addcategory);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(959, 68);
            this.panel2.TabIndex = 43;
            // 
            // btn_back
            // 
            this.btn_back.FlatAppearance.BorderSize = 0;
            this.btn_back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_back.Image = global::POS_System.Properties.Resources.back36;
            this.btn_back.Location = new System.Drawing.Point(3, 2);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(70, 64);
            this.btn_back.TabIndex = 22;
            this.btn_back.UseVisualStyleBackColor = true;
            this.btn_back.Click += new System.EventHandler(this.btn_back_Click);
            // 
            // lbl_addcategory
            // 
            this.lbl_addcategory.AutoSize = true;
            this.lbl_addcategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_addcategory.ForeColor = System.Drawing.Color.White;
            this.lbl_addcategory.Location = new System.Drawing.Point(327, 16);
            this.lbl_addcategory.Name = "lbl_addcategory";
            this.lbl_addcategory.Size = new System.Drawing.Size(195, 29);
            this.lbl_addcategory.TabIndex = 0;
            this.lbl_addcategory.Text = "Loyality Amount";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_id,
            this.col_from,
            this.col_to,
            this.col_points,
            this.col_status});
            this.dataGridView1.Location = new System.Drawing.Point(3, 69);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(559, 498);
            this.dataGridView1.TabIndex = 42;
            // 
            // col_id
            // 
            this.col_id.HeaderText = "Id";
            this.col_id.Name = "col_id";
            this.col_id.ReadOnly = true;
            this.col_id.Visible = false;
            // 
            // col_from
            // 
            this.col_from.HeaderText = "Amount From";
            this.col_from.Name = "col_from";
            this.col_from.ReadOnly = true;
            this.col_from.Width = 150;
            // 
            // col_to
            // 
            this.col_to.HeaderText = "Amount To";
            this.col_to.Name = "col_to";
            this.col_to.ReadOnly = true;
            this.col_to.Width = 150;
            // 
            // col_points
            // 
            this.col_points.HeaderText = "Points";
            this.col_points.Name = "col_points";
            this.col_points.ReadOnly = true;
            // 
            // col_status
            // 
            this.col_status.HeaderText = "Status";
            this.col_status.Name = "col_status";
            this.col_status.ReadOnly = true;
            this.col_status.Width = 120;
            // 
            // Loyality_Amount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(966, 649);
            this.Controls.Add(this.panel1);
            this.Name = "Loyality_Amount";
            this.Text = "Loyality_Amount";
            this.Load += new System.EventHandler(this.Loyality_Amount_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_back;
        private System.Windows.Forms.Label lbl_addcategory;
        private System.Windows.Forms.Panel panel9;
        public System.Windows.Forms.TextBox txt_points;
        private System.Windows.Forms.Panel panel7;
        public System.Windows.Forms.TextBox txt_to;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Label label4;
        private DevComponents.DotNetBar.ButtonX btn_edit;
        public System.Windows.Forms.TextBox txt_from;
        private DevComponents.DotNetBar.ButtonX btn_save;
        private DevComponents.DotNetBar.ButtonX btn_update;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_from;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_to;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_points;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_status;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbn_true;
        private System.Windows.Forms.RadioButton rbn_false;
    }
}