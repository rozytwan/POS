
namespace POS_System.Customer_Management
{
    partial class AppointmentBooking
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
            this.tbDescription = new DevExpress.XtraEditors.MemoEdit();
            this.cmb_starttime = new DevExpress.XtraScheduler.UI.SchedulerTimeEdit();
            this.dtp_startdate = new DevExpress.XtraEditors.DateEdit();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.lblStartTime = new DevExpress.XtraEditors.LabelControl();
            this.chkReminder = new DevExpress.XtraEditors.CheckEdit();
            this.lblLocation = new DevExpress.XtraEditors.LabelControl();
            this.lblSubject = new DevExpress.XtraEditors.LabelControl();
            this.lblEndTime = new DevExpress.XtraEditors.LabelControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.dtp_enddate = new DevExpress.XtraEditors.DateEdit();
            this.cmb_endtime = new DevExpress.XtraScheduler.UI.SchedulerTimeEdit();
            this.cmb_customer = new System.Windows.Forms.ComboBox();
            this.cmb_tableno = new System.Windows.Forms.ComboBox();
            this.btn_update = new DevExpress.XtraEditors.SimpleButton();
            this.cmb_reminder = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.tbDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_starttime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtp_startdate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtp_startdate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkReminder.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtp_enddate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtp_enddate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_endtime.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tbDescription
            // 
            this.tbDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDescription.EditValue = "";
            this.tbDescription.Location = new System.Drawing.Point(55, 200);
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Properties.AccessibleName = "Message";
            this.tbDescription.Properties.AccessibleRole = System.Windows.Forms.AccessibleRole.Client;
            this.tbDescription.Size = new System.Drawing.Size(496, 167);
            this.tbDescription.TabIndex = 40;
            // 
            // cmb_starttime
            // 
            this.cmb_starttime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmb_starttime.EditValue = new System.DateTime(2005, 3, 31, 0, 0, 0, 0);
            this.cmb_starttime.Location = new System.Drawing.Point(263, 107);
            this.cmb_starttime.Name = "cmb_starttime";
            this.cmb_starttime.Properties.AccessibleName = "Start time";
            this.cmb_starttime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.cmb_starttime.Size = new System.Drawing.Size(88, 20);
            this.cmb_starttime.TabIndex = 34;
            // 
            // dtp_startdate
            // 
            this.dtp_startdate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtp_startdate.EditValue = new System.DateTime(2005, 3, 31, 0, 0, 0, 0);
            this.dtp_startdate.Location = new System.Drawing.Point(135, 106);
            this.dtp_startdate.Name = "dtp_startdate";
            this.dtp_startdate.Properties.AccessibleName = "Start date";
            this.dtp_startdate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtp_startdate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtp_startdate.Properties.MaxValue = new System.DateTime(4000, 1, 1, 0, 0, 0, 0);
            this.dtp_startdate.Size = new System.Drawing.Size(120, 20);
            this.dtp_startdate.TabIndex = 33;
            // 
            // btnOk
            // 
            this.btnOk.AccessibleName = "Ok";
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOk.Location = new System.Drawing.Point(55, 376);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 41;
            this.btnOk.Text = "OK";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lblStartTime
            // 
            this.lblStartTime.AccessibleName = "Start time";
            this.lblStartTime.Location = new System.Drawing.Point(55, 109);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(51, 13);
            this.lblStartTime.TabIndex = 32;
            this.lblStartTime.Text = "S&tart time:";
            // 
            // chkReminder
            // 
            this.chkReminder.Location = new System.Drawing.Point(60, 161);
            this.chkReminder.Name = "chkReminder";
            this.chkReminder.Properties.AutoWidth = true;
            this.chkReminder.Properties.Caption = "&Reminder";
            this.chkReminder.Size = new System.Drawing.Size(67, 19);
            this.chkReminder.TabIndex = 38;
            // 
            // lblLocation
            // 
            this.lblLocation.AccessibleName = "Location";
            this.lblLocation.Location = new System.Drawing.Point(55, 72);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(42, 13);
            this.lblLocation.TabIndex = 30;
            this.lblLocation.Text = "Table No";
            // 
            // lblSubject
            // 
            this.lblSubject.AccessibleName = "Subject";
            this.lblSubject.Location = new System.Drawing.Point(55, 46);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(46, 13);
            this.lblSubject.TabIndex = 29;
            this.lblSubject.Text = "Customer";
            // 
            // lblEndTime
            // 
            this.lblEndTime.AccessibleName = "End time";
            this.lblEndTime.Location = new System.Drawing.Point(55, 134);
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.Size = new System.Drawing.Size(45, 13);
            this.lblEndTime.TabIndex = 35;
            this.lblEndTime.Text = "&End time:";
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleName = "Cancel";
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.CausesValidation = false;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(143, 376);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 42;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // dtp_enddate
            // 
            this.dtp_enddate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtp_enddate.EditValue = new System.DateTime(2005, 3, 31, 0, 0, 0, 0);
            this.dtp_enddate.Location = new System.Drawing.Point(135, 131);
            this.dtp_enddate.Name = "dtp_enddate";
            this.dtp_enddate.Properties.AccessibleName = "End date";
            this.dtp_enddate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtp_enddate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtp_enddate.Properties.MaxValue = new System.DateTime(4000, 1, 1, 0, 0, 0, 0);
            this.dtp_enddate.Size = new System.Drawing.Size(120, 20);
            this.dtp_enddate.TabIndex = 36;
            // 
            // cmb_endtime
            // 
            this.cmb_endtime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmb_endtime.EditValue = new System.DateTime(2005, 3, 31, 0, 0, 0, 0);
            this.cmb_endtime.Location = new System.Drawing.Point(263, 131);
            this.cmb_endtime.Name = "cmb_endtime";
            this.cmb_endtime.Properties.AccessibleName = "End time";
            this.cmb_endtime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.cmb_endtime.Size = new System.Drawing.Size(88, 20);
            this.cmb_endtime.TabIndex = 37;
            // 
            // cmb_customer
            // 
            this.cmb_customer.FormattingEnabled = true;
            this.cmb_customer.Location = new System.Drawing.Point(135, 38);
            this.cmb_customer.Name = "cmb_customer";
            this.cmb_customer.Size = new System.Drawing.Size(216, 21);
            this.cmb_customer.TabIndex = 45;
            // 
            // cmb_tableno
            // 
            this.cmb_tableno.FormattingEnabled = true;
            this.cmb_tableno.Location = new System.Drawing.Point(135, 72);
            this.cmb_tableno.Name = "cmb_tableno";
            this.cmb_tableno.Size = new System.Drawing.Size(216, 21);
            this.cmb_tableno.TabIndex = 46;
            // 
            // btn_update
            // 
            this.btn_update.AccessibleName = "Cancel";
            this.btn_update.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_update.CausesValidation = false;
            this.btn_update.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_update.Location = new System.Drawing.Point(224, 376);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(75, 23);
            this.btn_update.TabIndex = 47;
            this.btn_update.Text = "Update";
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // cmb_reminder
            // 
            this.cmb_reminder.FormattingEnabled = true;
            this.cmb_reminder.Items.AddRange(new object[] {
            "1",
            "5",
            "10",
            "15",
            "20",
            "25",
            "30",
            "35",
            "40",
            "45",
            "50",
            "55",
            "60",
            "65",
            "70",
            "75",
            "80",
            "85",
            "90",
            "95",
            "100",
            "105",
            "110",
            "115",
            "120"});
            this.cmb_reminder.Location = new System.Drawing.Point(135, 164);
            this.cmb_reminder.Name = "cmb_reminder";
            this.cmb_reminder.Size = new System.Drawing.Size(83, 21);
            this.cmb_reminder.TabIndex = 48;
            // 
            // AppointmentBooking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 438);
            this.Controls.Add(this.cmb_reminder);
            this.Controls.Add(this.btn_update);
            this.Controls.Add(this.cmb_tableno);
            this.Controls.Add(this.cmb_customer);
            this.Controls.Add(this.tbDescription);
            this.Controls.Add(this.cmb_starttime);
            this.Controls.Add(this.dtp_startdate);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lblStartTime);
            this.Controls.Add(this.chkReminder);
            this.Controls.Add(this.lblLocation);
            this.Controls.Add(this.lblSubject);
            this.Controls.Add(this.lblEndTime);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.dtp_enddate);
            this.Controls.Add(this.cmb_endtime);
            this.Name = "AppointmentBooking";
            this.Text = "AppointmentBooking";
            this.Load += new System.EventHandler(this.AppointmentBooking_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_starttime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtp_startdate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtp_startdate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkReminder.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtp_enddate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtp_enddate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_endtime.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        protected DevExpress.XtraEditors.SimpleButton btnOk;
        protected DevExpress.XtraEditors.LabelControl lblStartTime;
        protected DevExpress.XtraEditors.CheckEdit chkReminder;
        protected DevExpress.XtraEditors.LabelControl lblLocation;
        protected DevExpress.XtraEditors.LabelControl lblSubject;
        protected DevExpress.XtraEditors.LabelControl lblEndTime;
        protected DevExpress.XtraEditors.SimpleButton btnCancel;
        public DevExpress.XtraEditors.MemoEdit tbDescription;
        public DevExpress.XtraScheduler.UI.SchedulerTimeEdit cmb_starttime;
        public DevExpress.XtraEditors.DateEdit dtp_startdate;
        public DevExpress.XtraEditors.DateEdit dtp_enddate;
        public DevExpress.XtraScheduler.UI.SchedulerTimeEdit cmb_endtime;
        public System.Windows.Forms.ComboBox cmb_customer;
        public System.Windows.Forms.ComboBox cmb_tableno;
        protected DevExpress.XtraEditors.SimpleButton btn_update;
        public System.Windows.Forms.ComboBox cmb_reminder;
    }
}