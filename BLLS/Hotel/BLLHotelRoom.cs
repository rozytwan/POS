using DOA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLS.Hotel
{
   public class BLLHotelRoom
    {
        public DataTable getAllRoomCategory()
        {
            return DAL.getuser("select * from hotel_room_category", null);
        }
        public DataTable getAllRoomDetaisbyId(int id)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@room_category_id",id)
                };
            return DAL.getuser("select * from hotel_room_details where room_category_id=@room_category_id", parm);

        }
        public DataTable getAllRoombookingbyId(int room_id)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@room_id",room_id)
                };
            return DAL.getuser("select f_name +' '+ l_name as name,contact,country,package_id from hotel_bookings h join hotel_customer cd on (h.customer_id=cd.customer_id) where  room_id=@room_id", parm);

        }
        public DataTable GetRoomId(string room_no)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@room_no",room_no)
                };
            return DAL.getuser("select * from hotel_room_details where room_no=@room_no", parm);

        }
        public DataTable GetDates(int room_id)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@room_id",room_id)

                };
            DataTable dt = DAL.getuser("select * from hotel_bookings where room_id=@room_id", parm);
            return dt;
        }
        public DataTable GetBookCustomer(string room_id)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@room_id",room_id)

                };
            DataTable dt = DAL.getuser("select * from hotel_bookings b inner join hotel_customer c on b.customer_id = c.customer_id where room_id=@room_id", parm);
            return dt;
        }
        public int deleteBooking(string room_id)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
            new SqlParameter("@room_id",room_id),
            };
            return DAL.IDU("delete hotel_bookings where room_id=@room_id", parm);
        }
        public DataTable SelectCustomerBookings(int customer_id)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
            new SqlParameter("@customer_id",customer_id),
            };
            return DAL.getuser("select * from hotel_bookings where customer_id=@customer_id", parm);
        }
        public int DeleteCustomerBookings(int customer_id)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
            new SqlParameter("@customer_id",customer_id),
            };
            return DAL.IDU("delete hotel_bookings where customer_id=@customer_id", parm);
        }
        public int deleteHotelOrder(string room_id)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
            new SqlParameter("@room_id",room_id),
            };
            return DAL.IDU("delete hotel_order where room_no=@room_id", parm);
        }
        public int deleteHotelOrderByid(int hotel_order_id)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
            new SqlParameter("@hotel_order_id",hotel_order_id),
            };
            return DAL.IDU("delete hotel_order where hotel_order_id=@hotel_order_id", parm);
        }
        public DataTable GetOrderByCustomerId(int customer_id)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@customer_id",customer_id)

                };
            DataTable dt = DAL.getuser("select * from hotel_order where customer_id=@customer_id", parm);
            return dt;
        }
        public int bulk_data_insert()
        {
            return DAL.IDU("insert into hotel_checkout(customer_id,checkout_date,check_in,room_id,check_out) select customer_id,booking_date as today,check_in,room_id,check_out from hotel_bookings", null);
        }
        public DataTable GetAllRoomById(int room_id)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@room_id",room_id)
                };
            return DAL.getuser("select * from hotel_room_image where room_id=@room_id", parm);

        }
        public DataTable GetAllRoom(string room_id)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@room_id",room_id)
                };
            return DAL.getuser("select * from hotel_room_image where room_id=@room_id", parm);

        }
        public DataTable GetRoomDetail(string room_image)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@room_image",room_image)

                };
            DataTable dt = DAL.getuser("select * from hotel_room_image where room_image=@room_image", parm);
            return dt;
        }
        public int DeleteImage(string image_id)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
            new SqlParameter("@image_id",image_id),
            };
            return DAL.IDU("delete hotel_room_image where image_id=@image_id", parm);
        }
    }
}
