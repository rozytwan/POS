namespace POS_System.Customer_Management
{
    partial class AppointmentGraph
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
            DevExpress.XtraScheduler.TimeRuler timeRuler1 = new DevExpress.XtraScheduler.TimeRuler();
            DevExpress.XtraScheduler.TimeRuler timeRuler2 = new DevExpress.XtraScheduler.TimeRuler();
            DevExpress.XtraScheduler.TimeRuler timeRuler3 = new DevExpress.XtraScheduler.TimeRuler();
            this.sch_appointment = new DevExpress.XtraScheduler.SchedulerControl();
            this.schedulerStorage1 = new DevExpress.XtraScheduler.SchedulerStorage(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.sch_appointment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerStorage1)).BeginInit();
            this.SuspendLayout();
            // 
            // sch_appointment
            // 
            this.sch_appointment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sch_appointment.Location = new System.Drawing.Point(0, 0);
            this.sch_appointment.LookAndFeel.SkinName = "Office 2013";
            this.sch_appointment.Name = "sch_appointment";
            this.sch_appointment.Size = new System.Drawing.Size(1011, 674);
            this.sch_appointment.Start = new System.DateTime(2018, 7, 25, 0, 0, 0, 0);
            this.sch_appointment.Storage = this.schedulerStorage1;
            this.sch_appointment.TabIndex = 0;
            this.sch_appointment.Text = "schedulerControl1";
            this.sch_appointment.Views.DayView.AllDayAreaScrollBarVisible = true;
            this.sch_appointment.Views.DayView.TimeRulers.Add(timeRuler1);
            this.sch_appointment.Views.FullWeekView.Enabled = true;
            this.sch_appointment.Views.FullWeekView.TimeRulers.Add(timeRuler2);
            this.sch_appointment.Views.TimelineView.TimeIndicatorDisplayOptions.ShowOverAppointment = true;
            this.sch_appointment.Views.WeekView.Enabled = false;
            this.sch_appointment.Views.WorkWeekView.TimeRulers.Add(timeRuler3);
            this.sch_appointment.EditAppointmentFormShowing += new DevExpress.XtraScheduler.AppointmentFormEventHandler(this.sch_appointment_EditAppointmentFormShowing);
            this.sch_appointment.DoubleClick += new System.EventHandler(this.sch_appointment_DoubleClick);
            // 
            // AppointmentGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.sch_appointment);
            this.Name = "AppointmentGraph";
            this.Size = new System.Drawing.Size(1011, 674);
            this.Load += new System.EventHandler(this.AppointmentGraph_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sch_appointment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerStorage1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraScheduler.SchedulerControl sch_appointment;
        private DevExpress.XtraScheduler.SchedulerStorage schedulerStorage1;
    }
}