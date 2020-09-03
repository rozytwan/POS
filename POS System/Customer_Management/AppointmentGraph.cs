using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraScheduler;
using BLLS;

namespace POS_System.Customer_Management
{
    public partial class AppointmentGraph : UserControl
    {
        public AppointmentGraph()
        {
            InitializeComponent();
        }
        BLLAppointmentGraph blag = new BLLAppointmentGraph();
        private void AppointmentGraph_Load(object sender, EventArgs e)
        {
            DataTable dt = blag.GetAllAppointment();
            if (dt.Rows.Count > 0)
            {
                schedulerStorage1.Appointments.DataSource = dt;
                //schedulerStorage1.Resources.DataSource = dt2;

                SchedulerStorage schedulerStorage = sch_appointment.Storage;
                ResourceMappingInfo resourceMappings = schedulerStorage.Resources.Mappings;
                AppointmentDependencyMappingInfo appointmentDependencyMappings = schedulerStorage.AppointmentDependencies.Mappings;
                AppointmentMappingInfo appointmentMappings = schedulerStorage.Appointments.Mappings;

                resourceMappings.Id = "appo_id";
              
                
                appointmentMappings.AppointmentId = "appo_id";
                appointmentMappings.Start = "start_time";
                appointmentMappings.End = "end_time";
                appointmentMappings.Subject = "Remarks";
                appointmentMappings.Description = "Remarks";
                //appointmentMappings.Location = "cat_name";
                //appointmentMappings.Label = "color";
                //appointmentMappings.Status = "showAs";
                //appointmentMappings.AllDay = "allDay";
                //appointmentMappings.ReminderInfo = "ReminderInfo";
                //appointmentMappings.RecurrenceInfo = "RecurrenceInfo";
                //appointmentMappings.Type = "EventType";
                //appointmentMappings.ResourceId = "ResourceID";
                resourceMappings.Caption = "table_no";
                schedulerStorage.Appointments.CommitIdToDataSource = false;
                schedulerStorage.Appointments.ResourceSharing = true;
                sch_appointment.GroupType = SchedulerGroupType.Resource;
              
             
                sch_appointment.GoToDate(Convert.ToDateTime(DateTime.Now.ToShortDateString()));
                sch_appointment.ActiveViewType = SchedulerViewType.Day;
                //  sch_appointment.GetNextControl
               //   schedulerStorage.Resources.DataSource = dt;
              //    schedulerStorage.AppointmentDependencies.DataSource = dataSet.Tables["AppointmentDependencies"];
             //     schedulerStorage.Appointments.DataSource = dt;

                schedulerStorage.AppointmentsInserted += delegate (object s, PersistentObjectsEventArgs ea)
                {
                    DataTable dtAppointments = (DataTable)schedulerStorage.Appointments.DataSource;

                    schedulerStorage.SetAppointmentId((Appointment)ea.Objects[0],
                        Convert.ToInt32(dtAppointments.Rows[dtAppointments.Rows.Count - 1][appointmentMappings.AppointmentId]));
                };

            }
        }

        private void sch_appointment_DoubleClick(object sender, EventArgs e)
        {
           
                 
        }

        private void sch_appointment_EditAppointmentFormShowing(object sender, AppointmentFormEventArgs e)
        {
            DevExpress.XtraScheduler.SchedulerControl scheduler = ((DevExpress.XtraScheduler.SchedulerControl)(sender));
            POS_System.Customer_Management.AppointmentBooking form = new AppointmentBooking();
            try
            {
                e.DialogResult = form.ShowDialog();
                e.Handled = true;
            }
            finally
            {
                form.Dispose();
            }

        }
    }
}
