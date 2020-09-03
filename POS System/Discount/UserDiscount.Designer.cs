namespace POS_System
{
    partial class UserDiscount
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
            this.lbl_addcategory = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel22 = new System.Windows.Forms.Panel();
            this.txt_discount_percent = new System.Windows.Forms.TextBox();
            this.panel9 = new System.Windows.Forms.Panel();
            this.txt_discount_to = new System.Windows.Forms.TextBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.txt_discount_from = new System.Windows.Forms.TextBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.cmb_card_type = new System.Windows.Forms.ComboBox();
            this.panel20 = new System.Windows.Forms.Panel();
            this.panel21 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_save = new DevComponents.DotNetBar.ButtonX();
            this.btn_update = new DevComponents.DotNetBar.ButtonX();
            this.btn_edit = new DevComponents.DotNetBar.ButtonX();
            this.col_user_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_card_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_dis_from = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_dis_to = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_dis_percent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel22.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel20.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel10.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(81)))), ((int)(((byte)(126)))));
            this.panel2.Controls.Add(this.btn_back);
            this.panel2.Controls.Add(this.lbl_addcategory);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(960, 68);
            this.panel2.TabIndex = 27;
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
            this.lbl_addcategory.Location = new System.Drawing.Point(385, 19);
            this.lbl_addcategory.Name = "lbl_addcategory";
            this.lbl_addcategory.Size = new System.Drawing.Size(246, 29);
            this.lbl_addcategory.TabIndex = 0;
            this.lbl_addcategory.Text = "User Level Discount";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_user_id,
            this.col_card_type,
            this.col_dis_from,
            this.col_dis_to,
            this.col_dis_percent});
            this.dataGridView1.Location = new System.Drawing.Point(3, 72);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(505, 473);
            this.dataGridView1.TabIndex = 42;
            // 
            // panel22
            // 
            this.panel22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel22.Controls.Add(this.txt_discount_percent);
            this.panel22.Location = new System.Drawing.Point(650, 214);
            this.panel22.Name = "panel22";
            this.panel22.Size = new System.Drawing.Size(285, 51);
            this.panel22.TabIndex = 50;
            // 
            // txt_discount_percent
            // 
            this.txt_discount_percent.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_discount_percent.Location = new System.Drawing.Point(3, 7);
            this.txt_discount_percent.Name = "txt_discount_percent";
            this.txt_discount_percent.Size = new System.Drawing.Size(278, 30);
            this.txt_discount_percent.TabIndex = 0;
            // 
            // panel9
            // 
            this.panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel9.Controls.Add(this.txt_discount_to);
            this.panel9.Location = new System.Drawing.Point(650, 164);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(285, 51);
            this.panel9.TabIndex = 49;
            // 
            // txt_discount_to
            // 
            this.txt_discount_to.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_discount_to.Location = new System.Drawing.Point(3, 7);
            this.txt_discount_to.Name = "txt_discount_to";
            this.txt_discount_to.Size = new System.Drawing.Size(278, 30);
            this.txt_discount_to.TabIndex = 0;
            // 
            // panel7
            // 
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.txt_discount_from);
            this.panel7.Location = new System.Drawing.Point(650, 118);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(285, 48);
            this.panel7.TabIndex = 48;
            // 
            // txt_discount_from
            // 
            this.txt_discount_from.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_discount_from.Location = new System.Drawing.Point(3, 9);
            this.txt_discount_from.Name = "txt_discount_from";
            this.txt_discount_from.Size = new System.Drawing.Size(275, 30);
            this.txt_discount_from.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.cmb_card_type);
            this.panel6.Location = new System.Drawing.Point(650, 74);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(285, 46);
            this.panel6.TabIndex = 47;
            // 
            // cmb_card_type
            // 
            this.cmb_card_type.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmb_card_type.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmb_card_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_card_type.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_card_type.FormattingEnabled = true;
            this.cmb_card_type.Location = new System.Drawing.Point(5, 8);
            this.cmb_card_type.Name = "cmb_card_type";
            this.cmb_card_type.Size = new System.Drawing.Size(277, 33);
            this.cmb_card_type.TabIndex = 0;
            // 
            // panel20
            // 
            this.panel20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel20.Controls.Add(this.panel21);
            this.panel20.Controls.Add(this.label3);
            this.panel20.Location = new System.Drawing.Point(524, 214);
            this.panel20.Name = "panel20";
            this.panel20.Size = new System.Drawing.Size(126, 51);
            this.panel20.TabIndex = 43;
            // 
            // panel21
            // 
            this.panel21.Location = new System.Drawing.Point(123, 3);
            this.panel21.Name = "panel21";
            this.panel21.Size = new System.Drawing.Size(277, 51);
            this.panel21.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(17, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Discount %";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.panel8);
            this.panel5.Controls.Add(this.label9);
            this.panel5.Location = new System.Drawing.Point(524, 164);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(126, 51);
            this.panel5.TabIndex = 44;
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
            this.label9.Location = new System.Drawing.Point(17, 17);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(94, 20);
            this.label9.TabIndex = 7;
            this.label9.Text = "Discount To";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.label2);
            this.panel4.Location = new System.Drawing.Point(524, 118);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(126, 50);
            this.panel4.TabIndex = 45;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Discount From";
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.Gainsboro;
            this.panel10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel10.Controls.Add(this.label4);
            this.panel10.Location = new System.Drawing.Point(524, 74);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(126, 46);
            this.panel10.TabIndex = 46;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(39, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Card Type";
            // 
            // btn_save
            // 
            this.btn_save.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_save.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btn_save.Location = new System.Drawing.Point(684, 308);
            this.btn_save.Name = "btn_save";
            this.btn_save.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(15);
            this.btn_save.Size = new System.Drawing.Size(116, 48);
            this.btn_save.Symbol = "";
            this.btn_save.TabIndex = 51;
            this.btn_save.Text = "Save";
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_update
            // 
            this.btn_update.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_update.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btn_update.Location = new System.Drawing.Point(832, 308);
            this.btn_update.Name = "btn_update";
            this.btn_update.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(15);
            this.btn_update.Size = new System.Drawing.Size(116, 48);
            this.btn_update.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_update.Symbol = "";
            this.btn_update.TabIndex = 52;
            this.btn_update.Text = "Update";
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // btn_edit
            // 
            this.btn_edit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_edit.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btn_edit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_edit.Location = new System.Drawing.Point(12, 551);
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(15);
            this.btn_edit.Size = new System.Drawing.Size(116, 48);
            this.btn_edit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_edit.Symbol = "";
            this.btn_edit.TabIndex = 53;
            this.btn_edit.Text = "Edit";
            this.btn_edit.Click += new System.EventHandler(this.btn_edit_Click);
            // 
            // col_user_id
            // 
            this.col_user_id.HeaderText = "User_id";
            this.col_user_id.Name = "col_user_id";
            this.col_user_id.ReadOnly = true;
            // 
            // col_card_type
            // 
            this.col_card_type.HeaderText = "Card Type";
            this.col_card_type.Name = "col_card_type";
            this.col_card_type.ReadOnly = true;
            // 
            // col_dis_from
            // 
            this.col_dis_from.HeaderText = "Discount From";
            this.col_dis_from.Name = "col_dis_from";
            this.col_dis_from.ReadOnly = true;
            // 
            // col_dis_to
            // 
            this.col_dis_to.HeaderText = "Discount To";
            this.col_dis_to.Name = "col_dis_to";
            this.col_dis_to.ReadOnly = true;
            // 
            // col_dis_percent
            // 
            this.col_dis_percent.HeaderText = "Discount %";
            this.col_dis_percent.Name = "col_dis_percent";
            this.col_dis_percent.ReadOnly = true;
            // 
            // UserDiscount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 602);
            this.Controls.Add(this.btn_edit);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.btn_update);
            this.Controls.Add(this.panel22);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel20);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel10);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel2);
            this.Name = "UserDiscount";
            this.Text = "UserDiscount";
            this.Load += new System.EventHandler(this.UserDiscount_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel22.ResumeLayout(false);
            this.panel22.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel20.ResumeLayout(false);
            this.panel20.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_back;
        private System.Windows.Forms.Label lbl_addcategory;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel22;
        public System.Windows.Forms.TextBox txt_discount_percent;
        private System.Windows.Forms.Panel panel9;
        public System.Windows.Forms.TextBox txt_discount_to;
        private System.Windows.Forms.Panel panel7;
        public System.Windows.Forms.TextBox txt_discount_from;
        private System.Windows.Forms.Panel panel6;
        public System.Windows.Forms.ComboBox cmb_card_type;
        private System.Windows.Forms.Panel panel20;
        private System.Windows.Forms.Panel panel21;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Label label4;
        private DevComponents.DotNetBar.ButtonX btn_save;
        private DevComponents.DotNetBar.ButtonX btn_update;
        private DevComponents.DotNetBar.ButtonX btn_edit;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_user_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_card_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_dis_from;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_dis_to;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_dis_percent;
    }
}