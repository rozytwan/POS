namespace POS_System
{
    partial class PendingBooking
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PendingBooking));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.col_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_customer_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_booking_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_checkin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_room_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_no_of_guest = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_check_out = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_pend_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_no_of_room = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_cancel = new System.Windows.Forms.DataGridViewButtonColumn();
            this.col_view = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bunifuGradientPanel1 = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_back = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.bunifuGradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_name,
            this.col_customer_id,
            this.col_booking_date,
            this.col_checkin,
            this.col_room_type,
            this.col_no_of_guest,
            this.col_check_out,
            this.col_pend_id,
            this.col_no_of_room,
            this.col_cancel,
            this.col_view});
            this.dataGridView1.Location = new System.Drawing.Point(0, 53);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(842, 525);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // col_name
            // 
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black;
            this.col_name.DefaultCellStyle = dataGridViewCellStyle9;
            this.col_name.HeaderText = "Customer Name";
            this.col_name.Name = "col_name";
            this.col_name.ReadOnly = true;
            this.col_name.Width = 150;
            // 
            // col_customer_id
            // 
            this.col_customer_id.HeaderText = "customer_id";
            this.col_customer_id.Name = "col_customer_id";
            this.col_customer_id.ReadOnly = true;
            this.col_customer_id.Visible = false;
            // 
            // col_booking_date
            // 
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black;
            this.col_booking_date.DefaultCellStyle = dataGridViewCellStyle10;
            this.col_booking_date.HeaderText = "Booking Date";
            this.col_booking_date.Name = "col_booking_date";
            this.col_booking_date.ReadOnly = true;
            // 
            // col_checkin
            // 
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black;
            this.col_checkin.DefaultCellStyle = dataGridViewCellStyle11;
            this.col_checkin.HeaderText = "Check In";
            this.col_checkin.Name = "col_checkin";
            this.col_checkin.ReadOnly = true;
            this.col_checkin.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_checkin.Width = 120;
            // 
            // col_room_type
            // 
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black;
            this.col_room_type.DefaultCellStyle = dataGridViewCellStyle12;
            this.col_room_type.HeaderText = "Room Type";
            this.col_room_type.Name = "col_room_type";
            this.col_room_type.ReadOnly = true;
            this.col_room_type.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_room_type.Width = 90;
            // 
            // col_no_of_guest
            // 
            dataGridViewCellStyle13.ForeColor = System.Drawing.Color.Black;
            this.col_no_of_guest.DefaultCellStyle = dataGridViewCellStyle13;
            this.col_no_of_guest.HeaderText = "No Of Guest";
            this.col_no_of_guest.Name = "col_no_of_guest";
            this.col_no_of_guest.ReadOnly = true;
            this.col_no_of_guest.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_no_of_guest.Visible = false;
            // 
            // col_check_out
            // 
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.Black;
            this.col_check_out.DefaultCellStyle = dataGridViewCellStyle14;
            this.col_check_out.HeaderText = "Check Out";
            this.col_check_out.Name = "col_check_out";
            this.col_check_out.ReadOnly = true;
            this.col_check_out.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_check_out.Width = 120;
            // 
            // col_pend_id
            // 
            this.col_pend_id.HeaderText = "Pending Id";
            this.col_pend_id.Name = "col_pend_id";
            this.col_pend_id.ReadOnly = true;
            this.col_pend_id.Visible = false;
            // 
            // col_no_of_room
            // 
            dataGridViewCellStyle15.ForeColor = System.Drawing.Color.Black;
            this.col_no_of_room.DefaultCellStyle = dataGridViewCellStyle15;
            this.col_no_of_room.HeaderText = "No of Room";
            this.col_no_of_room.Name = "col_no_of_room";
            this.col_no_of_room.ReadOnly = true;
            this.col_no_of_room.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_no_of_room.Width = 60;
            // 
            // col_cancel
            // 
            this.col_cancel.HeaderText = "Cancel Booking";
            this.col_cancel.Name = "col_cancel";
            this.col_cancel.ReadOnly = true;
            this.col_cancel.Text = "Cancel";
            this.col_cancel.ToolTipText = "Cancel";
            this.col_cancel.UseColumnTextForButtonValue = true;
            this.col_cancel.Width = 80;
            // 
            // col_view
            // 
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle16.ForeColor = System.Drawing.Color.Black;
            this.col_view.DefaultCellStyle = dataGridViewCellStyle16;
            this.col_view.HeaderText = "View Pending";
            this.col_view.Name = "col_view";
            this.col_view.ReadOnly = true;
            this.col_view.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_view.Text = "View Pending";
            this.col_view.ToolTipText = "View Pending";
            this.col_view.UseColumnTextForButtonValue = true;
            this.col_view.Width = 80;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.bunifuGradientPanel1);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Location = new System.Drawing.Point(3, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(845, 610);
            this.panel1.TabIndex = 1;
            // 
            // bunifuGradientPanel1
            // 
            this.bunifuGradientPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuGradientPanel1.BackgroundImage")));
            this.bunifuGradientPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuGradientPanel1.Controls.Add(this.btn_back);
            this.bunifuGradientPanel1.Controls.Add(this.pictureBox1);
            this.bunifuGradientPanel1.Controls.Add(this.label1);
            this.bunifuGradientPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bunifuGradientPanel1.GradientBottomLeft = System.Drawing.SystemColors.MenuText;
            this.bunifuGradientPanel1.GradientBottomRight = System.Drawing.Color.Brown;
            this.bunifuGradientPanel1.GradientTopLeft = System.Drawing.Color.SteelBlue;
            this.bunifuGradientPanel1.GradientTopRight = System.Drawing.Color.GreenYellow;
            this.bunifuGradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.bunifuGradientPanel1.Name = "bunifuGradientPanel1";
            this.bunifuGradientPanel1.Quality = 10;
            this.bunifuGradientPanel1.Size = new System.Drawing.Size(845, 54);
            this.bunifuGradientPanel1.TabIndex = 1;
            this.bunifuGradientPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.bunifuGradientPanel1_Paint);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::POS_System.Properties.Resources.cancel;
            this.pictureBox1.Location = new System.Drawing.Point(792, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(34, 34);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(314, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Booking Pending";
            // 
            // btn_back
            // 
            this.btn_back.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btn_back.FlatAppearance.BorderSize = 0;
            this.btn_back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_back.Image = global::POS_System.Properties.Resources.left_arrow_angle;
            this.btn_back.Location = new System.Drawing.Point(3, 3);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(66, 53);
            this.btn_back.TabIndex = 31;
            this.btn_back.UseVisualStyleBackColor = false;
            this.btn_back.Click += new System.EventHandler(this.btn_back_Click);
            // 
            // PendingBooking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 582);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PendingBooking";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.PendingBooking_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.bunifuGradientPanel1.ResumeLayout(false);
            this.bunifuGradientPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private Bunifu.Framework.UI.BunifuGradientPanel bunifuGradientPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_customer_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_booking_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_checkin;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_room_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_no_of_guest;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_check_out;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_pend_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_no_of_room;
        private System.Windows.Forms.DataGridViewButtonColumn col_cancel;
        private System.Windows.Forms.DataGridViewButtonColumn col_view;
        private System.Windows.Forms.Button btn_back;
        public System.Windows.Forms.Panel panel1;
    }
}