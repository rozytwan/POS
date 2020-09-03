namespace POS_System
{
    partial class Search
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Search));
            this.dtp_search = new System.Windows.Forms.DateTimePicker();
            this.rbn_name = new System.Windows.Forms.RadioButton();
            this.rbn_checkin = new System.Windows.Forms.RadioButton();
            this.rbn_phone = new System.Windows.Forms.RadioButton();
            this.rbn_room_num = new System.Windows.Forms.RadioButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.col_fname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_lname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_mobile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_booking_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_room_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_checkin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_check_out = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bunifuCustomLabel3 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.cmb_search = new System.Windows.Forms.ComboBox();
            this.bunifuFlatButton1 = new Bunifu.Framework.UI.BunifuFlatButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dtp_search
            // 
            this.dtp_search.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_search.Location = new System.Drawing.Point(178, 62);
            this.dtp_search.Name = "dtp_search";
            this.dtp_search.Size = new System.Drawing.Size(345, 26);
            this.dtp_search.TabIndex = 3;
            this.dtp_search.Visible = false;
            // 
            // rbn_name
            // 
            this.rbn_name.AutoSize = true;
            this.rbn_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbn_name.ForeColor = System.Drawing.Color.White;
            this.rbn_name.Location = new System.Drawing.Point(57, 17);
            this.rbn_name.Name = "rbn_name";
            this.rbn_name.Size = new System.Drawing.Size(79, 28);
            this.rbn_name.TabIndex = 4;
            this.rbn_name.Text = "Name";
            this.rbn_name.UseVisualStyleBackColor = true;
            this.rbn_name.Click += new System.EventHandler(this.rbn_name_Click);
            // 
            // rbn_checkin
            // 
            this.rbn_checkin.AutoSize = true;
            this.rbn_checkin.Checked = true;
            this.rbn_checkin.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbn_checkin.ForeColor = System.Drawing.Color.White;
            this.rbn_checkin.Location = new System.Drawing.Point(284, 17);
            this.rbn_checkin.Name = "rbn_checkin";
            this.rbn_checkin.Size = new System.Drawing.Size(146, 28);
            this.rbn_checkin.TabIndex = 4;
            this.rbn_checkin.TabStop = true;
            this.rbn_checkin.Text = "Check-In Date";
            this.rbn_checkin.UseVisualStyleBackColor = true;
            this.rbn_checkin.Click += new System.EventHandler(this.rbn_checkin_Click);
            // 
            // rbn_phone
            // 
            this.rbn_phone.AutoSize = true;
            this.rbn_phone.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbn_phone.ForeColor = System.Drawing.Color.White;
            this.rbn_phone.Location = new System.Drawing.Point(147, 17);
            this.rbn_phone.Name = "rbn_phone";
            this.rbn_phone.Size = new System.Drawing.Size(119, 28);
            this.rbn_phone.TabIndex = 4;
            this.rbn_phone.Text = "Phone No.";
            this.rbn_phone.UseVisualStyleBackColor = true;
            this.rbn_phone.Click += new System.EventHandler(this.rbn_phone_Click);
            // 
            // rbn_room_num
            // 
            this.rbn_room_num.AutoSize = true;
            this.rbn_room_num.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbn_room_num.ForeColor = System.Drawing.Color.White;
            this.rbn_room_num.Location = new System.Drawing.Point(436, 17);
            this.rbn_room_num.Name = "rbn_room_num";
            this.rbn_room_num.Size = new System.Drawing.Size(153, 28);
            this.rbn_room_num.TabIndex = 4;
            this.rbn_room_num.Text = "Room Number";
            this.rbn_room_num.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(24)))), ((int)(((byte)(45)))));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_fname,
            this.col_lname,
            this.col_mobile,
            this.col_booking_date,
            this.col_room_type,
            this.col_checkin,
            this.col_check_out,
            this.col_gender,
            this.col_id});
            this.dataGridView1.Location = new System.Drawing.Point(-1, 133);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(755, 471);
            this.dataGridView1.TabIndex = 5;
            // 
            // col_fname
            // 
            this.col_fname.HeaderText = "First Name";
            this.col_fname.Name = "col_fname";
            this.col_fname.ReadOnly = true;
            // 
            // col_lname
            // 
            this.col_lname.HeaderText = "Last Name";
            this.col_lname.Name = "col_lname";
            this.col_lname.ReadOnly = true;
            // 
            // col_mobile
            // 
            this.col_mobile.HeaderText = "Mobile";
            this.col_mobile.Name = "col_mobile";
            this.col_mobile.ReadOnly = true;
            // 
            // col_booking_date
            // 
            this.col_booking_date.HeaderText = "Booking Date";
            this.col_booking_date.Name = "col_booking_date";
            this.col_booking_date.ReadOnly = true;
            // 
            // col_room_type
            // 
            this.col_room_type.HeaderText = "Room Type";
            this.col_room_type.Name = "col_room_type";
            this.col_room_type.ReadOnly = true;
            // 
            // col_checkin
            // 
            this.col_checkin.HeaderText = "Check In";
            this.col_checkin.Name = "col_checkin";
            this.col_checkin.ReadOnly = true;
            // 
            // col_check_out
            // 
            this.col_check_out.HeaderText = "Check Out";
            this.col_check_out.Name = "col_check_out";
            this.col_check_out.ReadOnly = true;
            // 
            // col_gender
            // 
            this.col_gender.HeaderText = "Gender";
            this.col_gender.Name = "col_gender";
            this.col_gender.ReadOnly = true;
            // 
            // col_id
            // 
            this.col_id.HeaderText = "customer Id";
            this.col_id.Name = "col_id";
            this.col_id.ReadOnly = true;
            // 
            // bunifuCustomLabel3
            // 
            this.bunifuCustomLabel3.AutoSize = true;
            this.bunifuCustomLabel3.Font = new System.Drawing.Font("Georgia", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel3.ForeColor = System.Drawing.Color.White;
            this.bunifuCustomLabel3.Location = new System.Drawing.Point(276, 107);
            this.bunifuCustomLabel3.Name = "bunifuCustomLabel3";
            this.bunifuCustomLabel3.Size = new System.Drawing.Size(183, 23);
            this.bunifuCustomLabel3.TabIndex = 26;
            this.bunifuCustomLabel3.Text = "Customer Details";
            // 
            // cmb_search
            // 
            this.cmb_search.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_search.FormattingEnabled = true;
            this.cmb_search.Location = new System.Drawing.Point(178, 60);
            this.cmb_search.Name = "cmb_search";
            this.cmb_search.Size = new System.Drawing.Size(345, 28);
            this.cmb_search.TabIndex = 28;
            // 
            // bunifuFlatButton1
            // 
            this.bunifuFlatButton1.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.bunifuFlatButton1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuFlatButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuFlatButton1.BorderRadius = 0;
            this.bunifuFlatButton1.ButtonText = "Search";
            this.bunifuFlatButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuFlatButton1.DisabledColor = System.Drawing.Color.Gray;
            this.bunifuFlatButton1.Iconcolor = System.Drawing.Color.Transparent;
            this.bunifuFlatButton1.Iconimage = ((System.Drawing.Image)(resources.GetObject("bunifuFlatButton1.Iconimage")));
            this.bunifuFlatButton1.Iconimage_right = null;
            this.bunifuFlatButton1.Iconimage_right_Selected = null;
            this.bunifuFlatButton1.Iconimage_Selected = null;
            this.bunifuFlatButton1.IconMarginLeft = 0;
            this.bunifuFlatButton1.IconMarginRight = 0;
            this.bunifuFlatButton1.IconRightVisible = true;
            this.bunifuFlatButton1.IconRightZoom = 0D;
            this.bunifuFlatButton1.IconVisible = true;
            this.bunifuFlatButton1.IconZoom = 75D;
            this.bunifuFlatButton1.IsTab = false;
            this.bunifuFlatButton1.Location = new System.Drawing.Point(539, 60);
            this.bunifuFlatButton1.Name = "bunifuFlatButton1";
            this.bunifuFlatButton1.Normalcolor = System.Drawing.Color.Transparent;
            this.bunifuFlatButton1.OnHovercolor = System.Drawing.Color.MediumTurquoise;
            this.bunifuFlatButton1.OnHoverTextColor = System.Drawing.Color.White;
            this.bunifuFlatButton1.selected = false;
            this.bunifuFlatButton1.Size = new System.Drawing.Size(148, 37);
            this.bunifuFlatButton1.TabIndex = 1;
            this.bunifuFlatButton1.Text = "Search";
            this.bunifuFlatButton1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bunifuFlatButton1.Textcolor = System.Drawing.Color.White;
            this.bunifuFlatButton1.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuFlatButton1.Click += new System.EventHandler(this.bunifuFlatButton1_Click);
            // 
            // Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(24)))), ((int)(((byte)(45)))));
            this.Controls.Add(this.bunifuCustomLabel3);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.rbn_phone);
            this.Controls.Add(this.rbn_room_num);
            this.Controls.Add(this.rbn_checkin);
            this.Controls.Add(this.rbn_name);
            this.Controls.Add(this.dtp_search);
            this.Controls.Add(this.bunifuFlatButton1);
            this.Controls.Add(this.cmb_search);
            this.Name = "Search";
            this.Size = new System.Drawing.Size(757, 641);
            this.Load += new System.EventHandler(this.Search_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Bunifu.Framework.UI.BunifuFlatButton bunifuFlatButton1;
        private System.Windows.Forms.DateTimePicker dtp_search;
        private System.Windows.Forms.RadioButton rbn_name;
        private System.Windows.Forms.RadioButton rbn_checkin;
        private System.Windows.Forms.RadioButton rbn_phone;
        private System.Windows.Forms.RadioButton rbn_room_num;
        private System.Windows.Forms.DataGridView dataGridView1;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel3;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_fname;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_lname;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_mobile;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_booking_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_room_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_checkin;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_check_out;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gender;
        private System.Windows.Forms.ComboBox cmb_search;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_id;
    }
}