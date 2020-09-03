namespace POS_System.Customer_Management
{
    partial class CustomerConsolation
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
            this.panel_document = new System.Windows.Forms.Panel();
            this.lbl_get_file = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.cmb_doucments = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel_remarks = new System.Windows.Forms.Panel();
            this.lbl_form = new System.Windows.Forms.Label();
            this.cmb_remarks = new System.Windows.Forms.ComboBox();
            this.btn_remarks = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_back = new System.Windows.Forms.Button();
            this.label23 = new System.Windows.Forms.Label();
            this.panel_code = new System.Windows.Forms.Panel();
            this.lbl_close = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_remarks = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.col_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_last_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_hair = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btn_documents = new System.Windows.Forms.Button();
            this.btn_remark = new System.Windows.Forms.Button();
            this.btn_code = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel_document.SuspendLayout();
            this.panel_remarks.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel_code.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel_document);
            this.panel1.Controls.Add(this.panel_remarks);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel_code);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Location = new System.Drawing.Point(12, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(995, 705);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // panel_document
            // 
            this.panel_document.Controls.Add(this.btn_documents);
            this.panel_document.Controls.Add(this.lbl_get_file);
            this.panel_document.Controls.Add(this.button2);
            this.panel_document.Controls.Add(this.cmb_doucments);
            this.panel_document.Controls.Add(this.label3);
            this.panel_document.Location = new System.Drawing.Point(343, 107);
            this.panel_document.Name = "panel_document";
            this.panel_document.Size = new System.Drawing.Size(280, 93);
            this.panel_document.TabIndex = 157;
            this.panel_document.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_document_Paint);
            // 
            // lbl_get_file
            // 
            this.lbl_get_file.AutoSize = true;
            this.lbl_get_file.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_get_file.ForeColor = System.Drawing.Color.Blue;
            this.lbl_get_file.Location = new System.Drawing.Point(16, 69);
            this.lbl_get_file.Name = "lbl_get_file";
            this.lbl_get_file.Size = new System.Drawing.Size(150, 16);
            this.lbl_get_file.TabIndex = 158;
            this.lbl_get_file.Text = "I didn\'t find my file here !!";
            this.lbl_get_file.Click += new System.EventHandler(this.lbl_get_file_Click);
            this.lbl_get_file.MouseHover += new System.EventHandler(this.lbl_get_file_MouseHover);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(172, 61);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(51, 24);
            this.button2.TabIndex = 154;
            this.button2.Text = "OK";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // cmb_doucments
            // 
            this.cmb_doucments.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_doucments.FormattingEnabled = true;
            this.cmb_doucments.Location = new System.Drawing.Point(8, 32);
            this.cmb_doucments.Name = "cmb_doucments";
            this.cmb_doucments.Size = new System.Drawing.Size(209, 24);
            this.cmb_doucments.TabIndex = 156;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 16);
            this.label3.TabIndex = 152;
            this.label3.Text = "Choose Your Document";
            // 
            // panel_remarks
            // 
            this.panel_remarks.Controls.Add(this.btn_remark);
            this.panel_remarks.Controls.Add(this.lbl_form);
            this.panel_remarks.Controls.Add(this.cmb_remarks);
            this.panel_remarks.Controls.Add(this.btn_remarks);
            this.panel_remarks.Controls.Add(this.label4);
            this.panel_remarks.Location = new System.Drawing.Point(343, 268);
            this.panel_remarks.Name = "panel_remarks";
            this.panel_remarks.Size = new System.Drawing.Size(280, 93);
            this.panel_remarks.TabIndex = 119;
            // 
            // lbl_form
            // 
            this.lbl_form.AutoSize = true;
            this.lbl_form.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_form.ForeColor = System.Drawing.Color.Blue;
            this.lbl_form.Location = new System.Drawing.Point(16, 66);
            this.lbl_form.Name = "lbl_form";
            this.lbl_form.Size = new System.Drawing.Size(126, 16);
            this.lbl_form.TabIndex = 156;
            this.lbl_form.Text = "I want to fill the form!!";
            this.lbl_form.Click += new System.EventHandler(this.lbl_form_Click);
            this.lbl_form.MouseHover += new System.EventHandler(this.lbl_form_MouseHover);
            // 
            // cmb_remarks
            // 
            this.cmb_remarks.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_remarks.FormattingEnabled = true;
            this.cmb_remarks.Location = new System.Drawing.Point(8, 30);
            this.cmb_remarks.Name = "cmb_remarks";
            this.cmb_remarks.Size = new System.Drawing.Size(209, 24);
            this.cmb_remarks.TabIndex = 155;
            // 
            // btn_remarks
            // 
            this.btn_remarks.Location = new System.Drawing.Point(166, 66);
            this.btn_remarks.Name = "btn_remarks";
            this.btn_remarks.Size = new System.Drawing.Size(51, 24);
            this.btn_remarks.TabIndex = 154;
            this.btn_remarks.Text = "OK";
            this.btn_remarks.UseVisualStyleBackColor = true;
            this.btn_remarks.Click += new System.EventHandler(this.btn_remarks_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(5, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(173, 16);
            this.label4.TabIndex = 152;
            this.label4.Text = "Choose Customer Remarks";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(81)))), ((int)(((byte)(126)))));
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.btn_back);
            this.panel2.Controls.Add(this.label23);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(995, 73);
            this.panel2.TabIndex = 116;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::POS_System.Properties.Resources.arrows__5_;
            this.pictureBox1.Location = new System.Drawing.Point(311, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(67, 68);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 21;
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
            this.btn_back.TabIndex = 20;
            this.btn_back.UseVisualStyleBackColor = true;
            this.btn_back.Click += new System.EventHandler(this.btn_back_Click);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.White;
            this.label23.Location = new System.Drawing.Point(395, 17);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(354, 39);
            this.label23.TabIndex = 18;
            this.label23.Text = "Customer Consolation";
            // 
            // panel_code
            // 
            this.panel_code.Controls.Add(this.btn_code);
            this.panel_code.Controls.Add(this.lbl_close);
            this.panel_code.Controls.Add(this.label7);
            this.panel_code.Controls.Add(this.label6);
            this.panel_code.Controls.Add(this.button1);
            this.panel_code.Controls.Add(this.label2);
            this.panel_code.Controls.Add(this.txt_remarks);
            this.panel_code.Location = new System.Drawing.Point(301, 167);
            this.panel_code.Name = "panel_code";
            this.panel_code.Size = new System.Drawing.Size(345, 164);
            this.panel_code.TabIndex = 118;
            // 
            // lbl_close
            // 
            this.lbl_close.AutoSize = true;
            this.lbl_close.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_close.ForeColor = System.Drawing.Color.Blue;
            this.lbl_close.Location = new System.Drawing.Point(4, 136);
            this.lbl_close.Name = "lbl_close";
            this.lbl_close.Size = new System.Drawing.Size(188, 16);
            this.lbl_close.TabIndex = 160;
            this.lbl_close.Text = "I dont want to save document !!";
            this.lbl_close.Click += new System.EventHandler(this.lbl_close_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(4, 36);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(335, 16);
            this.label7.TabIndex = 159;
            this.label7.Text = "Save the File at Documents/POS/Customer Documents";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(76, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 16);
            this.label6.TabIndex = 155;
            this.label6.Text = "Generate code";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(290, 113);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(43, 30);
            this.button1.TabIndex = 154;
            this.button1.Text = "Done";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(22, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 16);
            this.label2.TabIndex = 153;
            this.label2.Text = "Card Remark :";
            // 
            // txt_remarks
            // 
            this.txt_remarks.BackColor = System.Drawing.Color.White;
            this.txt_remarks.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_remarks.Location = new System.Drawing.Point(126, 71);
            this.txt_remarks.Multiline = true;
            this.txt_remarks.Name = "txt_remarks";
            this.txt_remarks.Size = new System.Drawing.Size(207, 36);
            this.txt_remarks.TabIndex = 151;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_name,
            this.col_last_name,
            this.col_phone,
            this.col_address,
            this.col_id,
            this.col_gender,
            this.col_hair});
            this.dataGridView1.Location = new System.Drawing.Point(3, 74);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(989, 628);
            this.dataGridView1.TabIndex = 117;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // col_name
            // 
            this.col_name.HeaderText = "Name";
            this.col_name.Name = "col_name";
            this.col_name.ReadOnly = true;
            this.col_name.Width = 150;
            // 
            // col_last_name
            // 
            this.col_last_name.HeaderText = "Last Name";
            this.col_last_name.Name = "col_last_name";
            this.col_last_name.ReadOnly = true;
            this.col_last_name.Width = 150;
            // 
            // col_phone
            // 
            this.col_phone.HeaderText = "Phone";
            this.col_phone.Name = "col_phone";
            this.col_phone.ReadOnly = true;
            this.col_phone.Width = 140;
            // 
            // col_address
            // 
            this.col_address.HeaderText = "Address";
            this.col_address.Name = "col_address";
            this.col_address.ReadOnly = true;
            this.col_address.Width = 140;
            // 
            // col_id
            // 
            this.col_id.HeaderText = "Id";
            this.col_id.Name = "col_id";
            this.col_id.ReadOnly = true;
            this.col_id.Visible = false;
            // 
            // col_gender
            // 
            this.col_gender.HeaderText = "Gender";
            this.col_gender.Name = "col_gender";
            this.col_gender.ReadOnly = true;
            this.col_gender.Width = 150;
            // 
            // col_hair
            // 
            this.col_hair.HeaderText = "Open Document";
            this.col_hair.Name = "col_hair";
            this.col_hair.ReadOnly = true;
            this.col_hair.Text = "Open Document";
            this.col_hair.ToolTipText = "Open Document";
            this.col_hair.UseColumnTextForButtonValue = true;
            this.col_hair.Width = 130;
            // 
            // btn_documents
            // 
            this.btn_documents.BackColor = System.Drawing.Color.Red;
            this.btn_documents.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_documents.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_documents.Location = new System.Drawing.Point(252, 0);
            this.btn_documents.Name = "btn_documents";
            this.btn_documents.Size = new System.Drawing.Size(28, 23);
            this.btn_documents.TabIndex = 159;
            this.btn_documents.Text = "X";
            this.btn_documents.UseVisualStyleBackColor = false;
            this.btn_documents.Click += new System.EventHandler(this.btn_documents_Click);
            // 
            // btn_remark
            // 
            this.btn_remark.BackColor = System.Drawing.Color.Red;
            this.btn_remark.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_remark.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_remark.Location = new System.Drawing.Point(252, 0);
            this.btn_remark.Name = "btn_remark";
            this.btn_remark.Size = new System.Drawing.Size(28, 23);
            this.btn_remark.TabIndex = 160;
            this.btn_remark.Text = "X";
            this.btn_remark.UseVisualStyleBackColor = false;
            this.btn_remark.Click += new System.EventHandler(this.btn_remark_Click);
            // 
            // btn_code
            // 
            this.btn_code.BackColor = System.Drawing.Color.Red;
            this.btn_code.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_code.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_code.Location = new System.Drawing.Point(314, 2);
            this.btn_code.Name = "btn_code";
            this.btn_code.Size = new System.Drawing.Size(28, 23);
            this.btn_code.TabIndex = 161;
            this.btn_code.Text = "X";
            this.btn_code.UseVisualStyleBackColor = false;
            this.btn_code.Click += new System.EventHandler(this.btn_code_Click);
            // 
            // CustomerConsolation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "CustomerConsolation";
            this.Size = new System.Drawing.Size(1033, 749);
            this.Load += new System.EventHandler(this.CustomerConsunlation_Load);
            this.panel1.ResumeLayout(false);
            this.panel_document.ResumeLayout(false);
            this.panel_document.PerformLayout();
            this.panel_remarks.ResumeLayout(false);
            this.panel_remarks.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel_code.ResumeLayout(false);
            this.panel_code.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_back;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel_code;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_remarks;
        private System.Windows.Forms.Panel panel_remarks;
        private System.Windows.Forms.ComboBox cmb_remarks;
        private System.Windows.Forms.Button btn_remarks;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmb_doucments;
        private System.Windows.Forms.Panel panel_document;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_form;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbl_get_file;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbl_close;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_last_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_address;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gender;
        private System.Windows.Forms.DataGridViewButtonColumn col_hair;
        private System.Windows.Forms.Button btn_documents;
        private System.Windows.Forms.Button btn_remark;
        private System.Windows.Forms.Button btn_code;
    }
}