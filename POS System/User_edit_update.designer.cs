namespace POS
{
    partial class EditUpdateUser
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.col_userid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_user_image = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_first_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_lastname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_username = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_password = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_usertype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_phonenumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_dob = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_zipcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_dateofjoining = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_city = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_state = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_addressline1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_addressline2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_pin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_adduser = new DevComponents.DotNetBar.ButtonX();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.btn_edit = new DevComponents.DotNetBar.ButtonX();
            this.btn_delete = new DevComponents.DotNetBar.ButtonX();
            this.btn_view = new DevComponents.DotNetBar.ButtonX();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btn_view);
            this.panel1.Controls.Add(this.btn_delete);
            this.panel1.Controls.Add(this.btn_edit);
            this.panel1.Controls.Add(this.buttonX1);
            this.panel1.Controls.Add(this.btn_adduser);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1021, 703);
            this.panel1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_userid,
            this.col_user_image,
            this.col_first_name,
            this.col_lastname,
            this.col_username,
            this.col_email,
            this.col_password,
            this.col_usertype,
            this.col_gender,
            this.col_phonenumber,
            this.col_dob,
            this.col_zipcode,
            this.col_dateofjoining,
            this.col_city,
            this.col_state,
            this.col_addressline1,
            this.col_addressline2,
            this.col_pin});
            this.dataGridView1.Location = new System.Drawing.Point(4, 111);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(1008, 523);
            this.dataGridView1.TabIndex = 1;
            // 
            // col_userid
            // 
            this.col_userid.HeaderText = "UserId";
            this.col_userid.Name = "col_userid";
            this.col_userid.ReadOnly = true;
            this.col_userid.Visible = false;
            // 
            // col_user_image
            // 
            this.col_user_image.HeaderText = "UserImage";
            this.col_user_image.Name = "col_user_image";
            this.col_user_image.ReadOnly = true;
            this.col_user_image.Visible = false;
            // 
            // col_first_name
            // 
            this.col_first_name.HeaderText = "First Name";
            this.col_first_name.Name = "col_first_name";
            this.col_first_name.ReadOnly = true;
            this.col_first_name.Width = 130;
            // 
            // col_lastname
            // 
            this.col_lastname.HeaderText = "Last Name";
            this.col_lastname.Name = "col_lastname";
            this.col_lastname.ReadOnly = true;
            this.col_lastname.Width = 120;
            // 
            // col_username
            // 
            this.col_username.HeaderText = "Username";
            this.col_username.Name = "col_username";
            this.col_username.ReadOnly = true;
            this.col_username.Width = 150;
            // 
            // col_email
            // 
            this.col_email.HeaderText = "Email";
            this.col_email.Name = "col_email";
            this.col_email.ReadOnly = true;
            this.col_email.Width = 130;
            // 
            // col_password
            // 
            this.col_password.HeaderText = "Password";
            this.col_password.Name = "col_password";
            this.col_password.ReadOnly = true;
            this.col_password.Visible = false;
            // 
            // col_usertype
            // 
            this.col_usertype.HeaderText = "Usertype";
            this.col_usertype.Name = "col_usertype";
            this.col_usertype.ReadOnly = true;
            // 
            // col_gender
            // 
            this.col_gender.HeaderText = "Gender";
            this.col_gender.Name = "col_gender";
            this.col_gender.ReadOnly = true;
            this.col_gender.Width = 95;
            // 
            // col_phonenumber
            // 
            this.col_phonenumber.HeaderText = "Phone Number";
            this.col_phonenumber.Name = "col_phonenumber";
            this.col_phonenumber.ReadOnly = true;
            this.col_phonenumber.Width = 130;
            // 
            // col_dob
            // 
            this.col_dob.HeaderText = "Date of Birth";
            this.col_dob.Name = "col_dob";
            this.col_dob.ReadOnly = true;
            this.col_dob.Width = 145;
            // 
            // col_zipcode
            // 
            this.col_zipcode.HeaderText = "Zip Code";
            this.col_zipcode.Name = "col_zipcode";
            this.col_zipcode.ReadOnly = true;
            this.col_zipcode.Visible = false;
            // 
            // col_dateofjoining
            // 
            this.col_dateofjoining.HeaderText = "Date of Joining";
            this.col_dateofjoining.Name = "col_dateofjoining";
            this.col_dateofjoining.ReadOnly = true;
            this.col_dateofjoining.Visible = false;
            // 
            // col_city
            // 
            this.col_city.HeaderText = "City";
            this.col_city.Name = "col_city";
            this.col_city.ReadOnly = true;
            this.col_city.Visible = false;
            // 
            // col_state
            // 
            this.col_state.HeaderText = "State";
            this.col_state.Name = "col_state";
            this.col_state.ReadOnly = true;
            this.col_state.Visible = false;
            // 
            // col_addressline1
            // 
            this.col_addressline1.HeaderText = "Address Line 1";
            this.col_addressline1.Name = "col_addressline1";
            this.col_addressline1.ReadOnly = true;
            this.col_addressline1.Visible = false;
            // 
            // col_addressline2
            // 
            this.col_addressline2.HeaderText = "Address Line 2";
            this.col_addressline2.Name = "col_addressline2";
            this.col_addressline2.ReadOnly = true;
            this.col_addressline2.Visible = false;
            // 
            // col_pin
            // 
            this.col_pin.HeaderText = "Pin";
            this.col_pin.Name = "col_pin";
            this.col_pin.ReadOnly = true;
            this.col_pin.Visible = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(81)))), ((int)(((byte)(126)))));
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1021, 57);
            this.panel2.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::POS_System.Properties.Resources.people;
            this.pictureBox1.Location = new System.Drawing.Point(398, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(56, 51);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(460, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Users";
            // 
            // btn_adduser
            // 
            this.btn_adduser.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_adduser.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btn_adduser.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_adduser.Location = new System.Drawing.Point(882, 64);
            this.btn_adduser.Name = "btn_adduser";
            this.btn_adduser.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(15);
            this.btn_adduser.Size = new System.Drawing.Size(130, 41);
            this.btn_adduser.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_adduser.Symbol = "";
            this.btn_adduser.TabIndex = 5;
            this.btn_adduser.Text = "Add User";
            this.btn_adduser.Click += new System.EventHandler(this.btn_adduser_Click);
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Location = new System.Drawing.Point(-15, -15);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(75, 23);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 6;
            this.buttonX1.Text = "buttonX1";
            // 
            // btn_edit
            // 
            this.btn_edit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_edit.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btn_edit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_edit.Location = new System.Drawing.Point(4, 636);
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(15);
            this.btn_edit.Size = new System.Drawing.Size(114, 50);
            this.btn_edit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_edit.Symbol = "";
            this.btn_edit.TabIndex = 7;
            this.btn_edit.Text = "Edit";
            this.btn_edit.Click += new System.EventHandler(this.btn_edit_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_delete.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btn_delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_delete.Location = new System.Drawing.Point(124, 636);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(15);
            this.btn_delete.Size = new System.Drawing.Size(118, 50);
            this.btn_delete.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_delete.Symbol = "";
            this.btn_delete.TabIndex = 8;
            this.btn_delete.Text = "Delete";
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // btn_view
            // 
            this.btn_view.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_view.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btn_view.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_view.Location = new System.Drawing.Point(248, 636);
            this.btn_view.Name = "btn_view";
            this.btn_view.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(15);
            this.btn_view.Size = new System.Drawing.Size(107, 50);
            this.btn_view.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_view.Symbol = "";
            this.btn_view.TabIndex = 9;
            this.btn_view.Text = "View";
            this.btn_view.Click += new System.EventHandler(this.btn_view_Click);
            // 
            // EditUpdateUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "EditUpdateUser";
            this.Size = new System.Drawing.Size(1021, 703);
            this.Load += new System.EventHandler(this.EditUpdateUser_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.DataGridView dataGridView1;
        public System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_userid;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_user_image;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_first_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_lastname;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_username;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_email;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_password;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_usertype;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gender;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_phonenumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_dob;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_zipcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_dateofjoining;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_city;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_state;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_addressline1;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_addressline2;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_pin;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DevComponents.DotNetBar.ButtonX btn_adduser;
        private DevComponents.DotNetBar.ButtonX btn_edit;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.ButtonX btn_delete;
        private DevComponents.DotNetBar.ButtonX btn_view;
    }
}