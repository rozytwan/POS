using DOA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLS
{
   public class BLLEventAttedance
    {

        public int InsertEvent(string event_name,int total_guest)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@event_name",event_name),
                    new SqlParameter("@total_guest",total_guest)
                };
            return DAL.IDU("insert into tbl_event (event_name,total_guest) values (@event_name,@total_guest)", parm);
        }
        public int UpdateEvent(string event_name, int total_guest,int id)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@event_name",event_name),
                    new SqlParameter("@total_guest",total_guest),
                     new SqlParameter("@id",id)
                };
            return DAL.IDU("update  tbl_event set event_name=@event_name,total_guest=@total_guest where id=@id", parm);
        }
        public DataTable getAllDataFromEvent()
        {
            return DAL.getuser("select * from tbl_event",null);
        }
        public DataTable CardEventAttendanceCheck(string card_no)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@card_no",card_no)
                };
            return DAL.getuser("Select * from tbl_event_attendance where card_no=@card_no and x_report='X'", parm);

        }
        public DataTable GetallDataofattendance()
        {
            
            return DAL.getuser("Select count(event_id)total_no_guest,event_name,total_guest from tbl_event_attendance ea  left join tbl_event e on(ea.event_id=e.id) where  x_report='X' group by total_guest,event_name", null);

        }
        public int InserCardAttendance(string card_no, DateTime date_time, int customer_id,int event_id)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@card_no",card_no),
                    new SqlParameter("@date_time",date_time),
                     new SqlParameter("@customer_id",customer_id),
                     new SqlParameter("@event_id",event_id),

                };
            return DAL.IDU("insert into tbl_event_attendance (card_no,date_time,customer_id,x_report,event_id) values (@card_no,@date_time,@customer_id,'X',@event_id)", parm);
        }
        public int UpdateXreport(int event_id)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@event_id",event_id)
                };
            return DAL.IDU("update tbl_event_attendance set x_report='' where event_id=@event_id and x_report='X'", parm);

        }
    }
}
