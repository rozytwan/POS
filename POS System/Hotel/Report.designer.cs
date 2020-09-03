namespace POS_System
{
    partial class Report
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Report));
            this.bunifuGradientPanel1 = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.panel_daily = new System.Windows.Forms.Panel();
            this.btn_day = new DevComponents.DotNetBar.ButtonX();
            this.dtp_daily = new System.Windows.Forms.DateTimePicker();
            this.panel_week = new System.Windows.Forms.Panel();
            this.btn_date = new DevComponents.DotNetBar.ButtonX();
            this.dtp_to = new System.Windows.Forms.DateTimePicker();
            this.dtp_from = new System.Windows.Forms.DateTimePicker();
            this.btn_weekly_report = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btn_daily_report = new Bunifu.Framework.UI.BunifuFlatButton();
            this.ReportPanel = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txt_total_room = new System.Windows.Forms.TextBox();
            this.txt_total_free = new System.Windows.Forms.TextBox();
            this.bunifuCustomLabel5 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel6 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.txt_checkout = new System.Windows.Forms.TextBox();
            this.txt_room_charge = new System.Windows.Forms.TextBox();
            this.txt_guests = new System.Windows.Forms.TextBox();
            this.txt_cancel_check_in = new System.Windows.Forms.TextBox();
            this.txt_cancel_book = new System.Windows.Forms.TextBox();
            this.txt_pend_checkin = new System.Windows.Forms.TextBox();
            this.txt_pend_checkout = new System.Windows.Forms.TextBox();
            this.txt_check_in = new System.Windows.Forms.TextBox();
            this.txt_book = new System.Windows.Forms.TextBox();
            this.bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.lbl_today = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel13 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel3 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel12 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel11 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel4 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel2 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel7 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel10 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuGradientPanel1.SuspendLayout();
            this.panel_daily.SuspendLayout();
            this.panel_week.SuspendLayout();
            this.ReportPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuGradientPanel1
            // 
            this.bunifuGradientPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuGradientPanel1.BackgroundImage")));
            this.bunifuGradientPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuGradientPanel1.Controls.Add(this.panel_daily);
            this.bunifuGradientPanel1.Controls.Add(this.panel_week);
            this.bunifuGradientPanel1.Controls.Add(this.btn_weekly_report);
            this.bunifuGradientPanel1.Controls.Add(this.btn_daily_report);
            this.bunifuGradientPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bunifuGradientPanel1.GradientBottomLeft = System.Drawing.SystemColors.MenuText;
            this.bunifuGradientPanel1.GradientBottomRight = System.Drawing.Color.Brown;
            this.bunifuGradientPanel1.GradientTopLeft = System.Drawing.Color.SteelBlue;
            this.bunifuGradientPanel1.GradientTopRight = System.Drawing.Color.GreenYellow;
            this.bunifuGradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.bunifuGradientPanel1.Name = "bunifuGradientPanel1";
            this.bunifuGradientPanel1.Quality = 10;
            this.bunifuGradientPanel1.Size = new System.Drawing.Size(742, 66);
            this.bunifuGradientPanel1.TabIndex = 0;
            // 
            // panel_daily
            // 
            this.panel_daily.BackColor = System.Drawing.Color.Transparent;
            this.panel_daily.Controls.Add(this.btn_day);
            this.panel_daily.Controls.Add(this.dtp_daily);
            this.panel_daily.Location = new System.Drawing.Point(105, 6);
            this.panel_daily.Name = "panel_daily";
            this.panel_daily.Size = new System.Drawing.Size(259, 57);
            this.panel_daily.TabIndex = 14;
            // 
            // btn_day
            // 
            this.btn_day.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_day.BackColor = System.Drawing.Color.Transparent;
            this.btn_day.ColorTable = DevComponents.DotNetBar.eButtonColor.MagentaWithBackground;
            this.btn_day.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_day.Location = new System.Drawing.Point(156, 7);
            this.btn_day.Name = "btn_day";
            this.btn_day.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(15);
            this.btn_day.Size = new System.Drawing.Size(87, 35);
            this.btn_day.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_day.Symbol = "";
            this.btn_day.TabIndex = 119;
            this.btn_day.Text = "View";
            this.btn_day.Click += new System.EventHandler(this.btn_day_Click);
            // 
            // dtp_daily
            // 
            this.dtp_daily.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_daily.Location = new System.Drawing.Point(0, 20);
            this.dtp_daily.Name = "dtp_daily";
            this.dtp_daily.Size = new System.Drawing.Size(150, 22);
            this.dtp_daily.TabIndex = 5;
            // 
            // panel_week
            // 
            this.panel_week.BackColor = System.Drawing.Color.Transparent;
            this.panel_week.Controls.Add(this.btn_date);
            this.panel_week.Controls.Add(this.dtp_to);
            this.panel_week.Controls.Add(this.dtp_from);
            this.panel_week.Location = new System.Drawing.Point(483, 6);
            this.panel_week.Name = "panel_week";
            this.panel_week.Size = new System.Drawing.Size(271, 60);
            this.panel_week.TabIndex = 13;
            // 
            // btn_date
            // 
            this.btn_date.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_date.BackColor = System.Drawing.Color.Transparent;
            this.btn_date.ColorTable = DevComponents.DotNetBar.eButtonColor.MagentaWithBackground;
            this.btn_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_date.Location = new System.Drawing.Point(161, 7);
            this.btn_date.Name = "btn_date";
            this.btn_date.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(15);
            this.btn_date.Size = new System.Drawing.Size(87, 35);
            this.btn_date.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_date.Symbol = "";
            this.btn_date.TabIndex = 120;
            this.btn_date.Text = "View";
            this.btn_date.Click += new System.EventHandler(this.btn_date_Click_1);
            // 
            // dtp_to
            // 
            this.dtp_to.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_to.Location = new System.Drawing.Point(3, 31);
            this.dtp_to.Name = "dtp_to";
            this.dtp_to.Size = new System.Drawing.Size(152, 22);
            this.dtp_to.TabIndex = 6;
            // 
            // dtp_from
            // 
            this.dtp_from.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_from.Location = new System.Drawing.Point(3, 6);
            this.dtp_from.Name = "dtp_from";
            this.dtp_from.Size = new System.Drawing.Size(152, 22);
            this.dtp_from.TabIndex = 5;
            // 
            // btn_weekly_report
            // 
            this.btn_weekly_report.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btn_weekly_report.BackColor = System.Drawing.Color.Transparent;
            this.btn_weekly_report.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_weekly_report.BorderRadius = 0;
            this.btn_weekly_report.ButtonText = "Report By Dates";
            this.btn_weekly_report.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_weekly_report.DisabledColor = System.Drawing.Color.Gray;
            this.btn_weekly_report.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_weekly_report.Iconcolor = System.Drawing.Color.Transparent;
            this.btn_weekly_report.Iconimage = ((System.Drawing.Image)(resources.GetObject("btn_weekly_report.Iconimage")));
            this.btn_weekly_report.Iconimage_right = null;
            this.btn_weekly_report.Iconimage_right_Selected = null;
            this.btn_weekly_report.Iconimage_Selected = null;
            this.btn_weekly_report.IconMarginLeft = 0;
            this.btn_weekly_report.IconMarginRight = 0;
            this.btn_weekly_report.IconRightVisible = true;
            this.btn_weekly_report.IconRightZoom = 0D;
            this.btn_weekly_report.IconVisible = true;
            this.btn_weekly_report.IconZoom = 60D;
            this.btn_weekly_report.IsTab = false;
            this.btn_weekly_report.Location = new System.Drawing.Point(371, 7);
            this.btn_weekly_report.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_weekly_report.Name = "btn_weekly_report";
            this.btn_weekly_report.Normalcolor = System.Drawing.Color.Transparent;
            this.btn_weekly_report.OnHovercolor = System.Drawing.Color.MediumTurquoise;
            this.btn_weekly_report.OnHoverTextColor = System.Drawing.Color.White;
            this.btn_weekly_report.selected = false;
            this.btn_weekly_report.Size = new System.Drawing.Size(120, 56);
            this.btn_weekly_report.TabIndex = 0;
            this.btn_weekly_report.Text = "Report By Dates";
            this.btn_weekly_report.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_weekly_report.Textcolor = System.Drawing.Color.White;
            this.btn_weekly_report.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_weekly_report.Click += new System.EventHandler(this.btn_weekly_report_Click);
            // 
            // btn_daily_report
            // 
            this.btn_daily_report.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btn_daily_report.BackColor = System.Drawing.Color.Transparent;
            this.btn_daily_report.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_daily_report.BorderRadius = 0;
            this.btn_daily_report.ButtonText = "Daily Report";
            this.btn_daily_report.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_daily_report.DisabledColor = System.Drawing.Color.Gray;
            this.btn_daily_report.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_daily_report.Iconcolor = System.Drawing.Color.Transparent;
            this.btn_daily_report.Iconimage = ((System.Drawing.Image)(resources.GetObject("btn_daily_report.Iconimage")));
            this.btn_daily_report.Iconimage_right = null;
            this.btn_daily_report.Iconimage_right_Selected = null;
            this.btn_daily_report.Iconimage_Selected = null;
            this.btn_daily_report.IconMarginLeft = 0;
            this.btn_daily_report.IconMarginRight = 0;
            this.btn_daily_report.IconRightVisible = true;
            this.btn_daily_report.IconRightZoom = 0D;
            this.btn_daily_report.IconVisible = true;
            this.btn_daily_report.IconZoom = 50D;
            this.btn_daily_report.IsTab = false;
            this.btn_daily_report.Location = new System.Drawing.Point(0, 6);
            this.btn_daily_report.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_daily_report.Name = "btn_daily_report";
            this.btn_daily_report.Normalcolor = System.Drawing.Color.Transparent;
            this.btn_daily_report.OnHovercolor = System.Drawing.Color.MediumTurquoise;
            this.btn_daily_report.OnHoverTextColor = System.Drawing.Color.White;
            this.btn_daily_report.selected = false;
            this.btn_daily_report.Size = new System.Drawing.Size(102, 53);
            this.btn_daily_report.TabIndex = 0;
            this.btn_daily_report.Text = "Daily Report";
            this.btn_daily_report.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_daily_report.Textcolor = System.Drawing.Color.White;
            this.btn_daily_report.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_daily_report.Click += new System.EventHandler(this.btn_daily_report_Click);
            // 
            // ReportPanel
            // 
            this.ReportPanel.Controls.Add(this.panel2);
            this.ReportPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReportPanel.Location = new System.Drawing.Point(0, 66);
            this.ReportPanel.Name = "ReportPanel";
            this.ReportPanel.Size = new System.Drawing.Size(754, 621);
            this.ReportPanel.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(30)))), ((int)(((byte)(66)))));
            this.panel2.Controls.Add(this.txt_total_room);
            this.panel2.Controls.Add(this.txt_total_free);
            this.panel2.Controls.Add(this.bunifuCustomLabel5);
            this.panel2.Controls.Add(this.bunifuCustomLabel6);
            this.panel2.Controls.Add(this.txt_checkout);
            this.panel2.Controls.Add(this.txt_room_charge);
            this.panel2.Controls.Add(this.txt_guests);
            this.panel2.Controls.Add(this.txt_cancel_check_in);
            this.panel2.Controls.Add(this.txt_cancel_book);
            this.panel2.Controls.Add(this.txt_pend_checkin);
            this.panel2.Controls.Add(this.txt_pend_checkout);
            this.panel2.Controls.Add(this.txt_check_in);
            this.panel2.Controls.Add(this.txt_book);
            this.panel2.Controls.Add(this.bunifuCustomLabel1);
            this.panel2.Controls.Add(this.lbl_today);
            this.panel2.Controls.Add(this.bunifuCustomLabel13);
            this.panel2.Controls.Add(this.bunifuCustomLabel3);
            this.panel2.Controls.Add(this.bunifuCustomLabel12);
            this.panel2.Controls.Add(this.bunifuCustomLabel11);
            this.panel2.Controls.Add(this.bunifuCustomLabel4);
            this.panel2.Controls.Add(this.bunifuCustomLabel2);
            this.panel2.Controls.Add(this.bunifuCustomLabel7);
            this.panel2.Controls.Add(this.bunifuCustomLabel10);
            this.panel2.Location = new System.Drawing.Point(3, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(739, 618);
            this.panel2.TabIndex = 11;
            // 
            // txt_total_room
            // 
            this.txt_total_room.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(30)))), ((int)(((byte)(66)))));
            this.txt_total_room.ForeColor = System.Drawing.Color.White;
            this.txt_total_room.Location = new System.Drawing.Point(324, 42);
            this.txt_total_room.Name = "txt_total_room";
            this.txt_total_room.Size = new System.Drawing.Size(224, 29);
            this.txt_total_room.TabIndex = 38;
            this.txt_total_room.Text = "                    ";
            // 
            // txt_total_free
            // 
            this.txt_total_free.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(30)))), ((int)(((byte)(66)))));
            this.txt_total_free.ForeColor = System.Drawing.Color.White;
            this.txt_total_free.Location = new System.Drawing.Point(324, 89);
            this.txt_total_free.Name = "txt_total_free";
            this.txt_total_free.Size = new System.Drawing.Size(224, 29);
            this.txt_total_free.TabIndex = 37;
            // 
            // bunifuCustomLabel5
            // 
            this.bunifuCustomLabel5.AutoSize = true;
            this.bunifuCustomLabel5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel5.ForeColor = System.Drawing.Color.White;
            this.bunifuCustomLabel5.Location = new System.Drawing.Point(64, 98);
            this.bunifuCustomLabel5.Name = "bunifuCustomLabel5";
            this.bunifuCustomLabel5.Size = new System.Drawing.Size(182, 20);
            this.bunifuCustomLabel5.TabIndex = 36;
            this.bunifuCustomLabel5.Text = "Total No. of Free Rooms";
            // 
            // bunifuCustomLabel6
            // 
            this.bunifuCustomLabel6.AutoSize = true;
            this.bunifuCustomLabel6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel6.ForeColor = System.Drawing.Color.White;
            this.bunifuCustomLabel6.Location = new System.Drawing.Point(65, 48);
            this.bunifuCustomLabel6.Name = "bunifuCustomLabel6";
            this.bunifuCustomLabel6.Size = new System.Drawing.Size(145, 20);
            this.bunifuCustomLabel6.TabIndex = 34;
            this.bunifuCustomLabel6.Text = "Total No. of Rooms";
            // 
            // txt_checkout
            // 
            this.txt_checkout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(30)))), ((int)(((byte)(66)))));
            this.txt_checkout.ForeColor = System.Drawing.Color.White;
            this.txt_checkout.Location = new System.Drawing.Point(324, 427);
            this.txt_checkout.Name = "txt_checkout";
            this.txt_checkout.Size = new System.Drawing.Size(224, 29);
            this.txt_checkout.TabIndex = 33;
            // 
            // txt_room_charge
            // 
            this.txt_room_charge.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(30)))), ((int)(((byte)(66)))));
            this.txt_room_charge.ForeColor = System.Drawing.Color.White;
            this.txt_room_charge.Location = new System.Drawing.Point(324, 476);
            this.txt_room_charge.Name = "txt_room_charge";
            this.txt_room_charge.Size = new System.Drawing.Size(224, 29);
            this.txt_room_charge.TabIndex = 32;
            // 
            // txt_guests
            // 
            this.txt_guests.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(30)))), ((int)(((byte)(66)))));
            this.txt_guests.ForeColor = System.Drawing.Color.White;
            this.txt_guests.Location = new System.Drawing.Point(324, 520);
            this.txt_guests.Name = "txt_guests";
            this.txt_guests.Size = new System.Drawing.Size(224, 29);
            this.txt_guests.TabIndex = 31;
            // 
            // txt_cancel_check_in
            // 
            this.txt_cancel_check_in.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(30)))), ((int)(((byte)(66)))));
            this.txt_cancel_check_in.ForeColor = System.Drawing.Color.White;
            this.txt_cancel_check_in.Location = new System.Drawing.Point(324, 329);
            this.txt_cancel_check_in.Name = "txt_cancel_check_in";
            this.txt_cancel_check_in.Size = new System.Drawing.Size(224, 29);
            this.txt_cancel_check_in.TabIndex = 29;
            // 
            // txt_cancel_book
            // 
            this.txt_cancel_book.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(30)))), ((int)(((byte)(66)))));
            this.txt_cancel_book.ForeColor = System.Drawing.Color.White;
            this.txt_cancel_book.Location = new System.Drawing.Point(324, 377);
            this.txt_cancel_book.Name = "txt_cancel_book";
            this.txt_cancel_book.Size = new System.Drawing.Size(224, 29);
            this.txt_cancel_book.TabIndex = 28;
            // 
            // txt_pend_checkin
            // 
            this.txt_pend_checkin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(30)))), ((int)(((byte)(66)))));
            this.txt_pend_checkin.ForeColor = System.Drawing.Color.White;
            this.txt_pend_checkin.Location = new System.Drawing.Point(324, 232);
            this.txt_pend_checkin.Name = "txt_pend_checkin";
            this.txt_pend_checkin.Size = new System.Drawing.Size(224, 29);
            this.txt_pend_checkin.TabIndex = 27;
            // 
            // txt_pend_checkout
            // 
            this.txt_pend_checkout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(30)))), ((int)(((byte)(66)))));
            this.txt_pend_checkout.ForeColor = System.Drawing.Color.White;
            this.txt_pend_checkout.Location = new System.Drawing.Point(324, 276);
            this.txt_pend_checkout.Name = "txt_pend_checkout";
            this.txt_pend_checkout.Size = new System.Drawing.Size(224, 29);
            this.txt_pend_checkout.TabIndex = 26;
            // 
            // txt_check_in
            // 
            this.txt_check_in.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(30)))), ((int)(((byte)(66)))));
            this.txt_check_in.ForeColor = System.Drawing.Color.White;
            this.txt_check_in.Location = new System.Drawing.Point(324, 136);
            this.txt_check_in.Name = "txt_check_in";
            this.txt_check_in.Size = new System.Drawing.Size(224, 29);
            this.txt_check_in.TabIndex = 25;
            // 
            // txt_book
            // 
            this.txt_book.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(30)))), ((int)(((byte)(66)))));
            this.txt_book.ForeColor = System.Drawing.Color.White;
            this.txt_book.Location = new System.Drawing.Point(324, 183);
            this.txt_book.Name = "txt_book";
            this.txt_book.Size = new System.Drawing.Size(224, 29);
            this.txt_book.TabIndex = 24;
            // 
            // bunifuCustomLabel1
            // 
            this.bunifuCustomLabel1.AutoSize = true;
            this.bunifuCustomLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel1.ForeColor = System.Drawing.Color.White;
            this.bunifuCustomLabel1.Location = new System.Drawing.Point(63, 386);
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(206, 20);
            this.bunifuCustomLabel1.TabIndex = 21;
            this.bunifuCustomLabel1.Text = "Number of Cancel Bookings";
            // 
            // lbl_today
            // 
            this.lbl_today.AutoSize = true;
            this.lbl_today.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_today.ForeColor = System.Drawing.Color.White;
            this.lbl_today.Location = new System.Drawing.Point(320, 3);
            this.lbl_today.Name = "lbl_today";
            this.lbl_today.Size = new System.Drawing.Size(159, 23);
            this.lbl_today.TabIndex = 6;
            this.lbl_today.Text = "Today\'s Report";
            // 
            // bunifuCustomLabel13
            // 
            this.bunifuCustomLabel13.AutoSize = true;
            this.bunifuCustomLabel13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel13.ForeColor = System.Drawing.Color.White;
            this.bunifuCustomLabel13.Location = new System.Drawing.Point(63, 482);
            this.bunifuCustomLabel13.Name = "bunifuCustomLabel13";
            this.bunifuCustomLabel13.Size = new System.Drawing.Size(181, 20);
            this.bunifuCustomLabel13.TabIndex = 19;
            this.bunifuCustomLabel13.Text = "Room Charge Collection";
            // 
            // bunifuCustomLabel3
            // 
            this.bunifuCustomLabel3.AutoSize = true;
            this.bunifuCustomLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel3.ForeColor = System.Drawing.Color.White;
            this.bunifuCustomLabel3.Location = new System.Drawing.Point(64, 335);
            this.bunifuCustomLabel3.Name = "bunifuCustomLabel3";
            this.bunifuCustomLabel3.Size = new System.Drawing.Size(211, 20);
            this.bunifuCustomLabel3.TabIndex = 13;
            this.bunifuCustomLabel3.Text = "Number of Cancel Check Ins";
            // 
            // bunifuCustomLabel12
            // 
            this.bunifuCustomLabel12.AutoSize = true;
            this.bunifuCustomLabel12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel12.ForeColor = System.Drawing.Color.White;
            this.bunifuCustomLabel12.Location = new System.Drawing.Point(64, 192);
            this.bunifuCustomLabel12.Name = "bunifuCustomLabel12";
            this.bunifuCustomLabel12.Size = new System.Drawing.Size(153, 20);
            this.bunifuCustomLabel12.TabIndex = 9;
            this.bunifuCustomLabel12.Text = "Number of Bookings";
            // 
            // bunifuCustomLabel11
            // 
            this.bunifuCustomLabel11.AutoSize = true;
            this.bunifuCustomLabel11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel11.ForeColor = System.Drawing.Color.White;
            this.bunifuCustomLabel11.Location = new System.Drawing.Point(65, 526);
            this.bunifuCustomLabel11.Name = "bunifuCustomLabel11";
            this.bunifuCustomLabel11.Size = new System.Drawing.Size(197, 20);
            this.bunifuCustomLabel11.TabIndex = 7;
            this.bunifuCustomLabel11.Text = "Number of Guests in Hotel";
            // 
            // bunifuCustomLabel4
            // 
            this.bunifuCustomLabel4.AutoSize = true;
            this.bunifuCustomLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel4.ForeColor = System.Drawing.Color.White;
            this.bunifuCustomLabel4.Location = new System.Drawing.Point(65, 142);
            this.bunifuCustomLabel4.Name = "bunifuCustomLabel4";
            this.bunifuCustomLabel4.Size = new System.Drawing.Size(149, 20);
            this.bunifuCustomLabel4.TabIndex = 5;
            this.bunifuCustomLabel4.Text = "Number of Check-in";
            // 
            // bunifuCustomLabel2
            // 
            this.bunifuCustomLabel2.AutoSize = true;
            this.bunifuCustomLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel2.ForeColor = System.Drawing.Color.White;
            this.bunifuCustomLabel2.Location = new System.Drawing.Point(65, 436);
            this.bunifuCustomLabel2.Name = "bunifuCustomLabel2";
            this.bunifuCustomLabel2.Size = new System.Drawing.Size(163, 20);
            this.bunifuCustomLabel2.TabIndex = 5;
            this.bunifuCustomLabel2.Text = "Number of Check-Out";
            // 
            // bunifuCustomLabel7
            // 
            this.bunifuCustomLabel7.AutoSize = true;
            this.bunifuCustomLabel7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel7.ForeColor = System.Drawing.Color.White;
            this.bunifuCustomLabel7.Location = new System.Drawing.Point(65, 241);
            this.bunifuCustomLabel7.Name = "bunifuCustomLabel7";
            this.bunifuCustomLabel7.Size = new System.Drawing.Size(141, 20);
            this.bunifuCustomLabel7.TabIndex = 5;
            this.bunifuCustomLabel7.Text = "Pending Check-ins";
            // 
            // bunifuCustomLabel10
            // 
            this.bunifuCustomLabel10.AutoSize = true;
            this.bunifuCustomLabel10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel10.ForeColor = System.Drawing.Color.White;
            this.bunifuCustomLabel10.Location = new System.Drawing.Point(65, 294);
            this.bunifuCustomLabel10.Name = "bunifuCustomLabel10";
            this.bunifuCustomLabel10.Size = new System.Drawing.Size(155, 20);
            this.bunifuCustomLabel10.TabIndex = 5;
            this.bunifuCustomLabel10.Text = "Pending Check-Outs";
            // 
            // Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(24)))), ((int)(((byte)(45)))));
            this.Controls.Add(this.ReportPanel);
            this.Controls.Add(this.bunifuGradientPanel1);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.Name = "Report";
            this.Size = new System.Drawing.Size(742, 699);
            this.Load += new System.EventHandler(this.Report_Load);
            this.bunifuGradientPanel1.ResumeLayout(false);
            this.panel_daily.ResumeLayout(false);
            this.panel_week.ResumeLayout(false);
            this.ReportPanel.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuGradientPanel bunifuGradientPanel1;
        private Bunifu.Framework.UI.BunifuFlatButton btn_weekly_report;
        private Bunifu.Framework.UI.BunifuFlatButton btn_daily_report;
        private System.Windows.Forms.Panel ReportPanel;
        private System.Windows.Forms.Panel panel2;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel7;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel10;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel4;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel2;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel12;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel11;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel3;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel13;
        private System.Windows.Forms.Panel panel_daily;
        private System.Windows.Forms.DateTimePicker dtp_daily;
        private System.Windows.Forms.Panel panel_week;
        private System.Windows.Forms.DateTimePicker dtp_to;
        private System.Windows.Forms.DateTimePicker dtp_from;
        private DevComponents.DotNetBar.ButtonX btn_day;
        private DevComponents.DotNetBar.ButtonX btn_date;
        private Bunifu.Framework.UI.BunifuCustomLabel lbl_today;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel1;
        private System.Windows.Forms.TextBox txt_book;
        private System.Windows.Forms.TextBox txt_checkout;
        private System.Windows.Forms.TextBox txt_room_charge;
        private System.Windows.Forms.TextBox txt_guests;
        private System.Windows.Forms.TextBox txt_cancel_check_in;
        private System.Windows.Forms.TextBox txt_cancel_book;
        private System.Windows.Forms.TextBox txt_pend_checkin;
        private System.Windows.Forms.TextBox txt_pend_checkout;
        private System.Windows.Forms.TextBox txt_check_in;
        private System.Windows.Forms.TextBox txt_total_room;
        private System.Windows.Forms.TextBox txt_total_free;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel5;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel6;
    }
}