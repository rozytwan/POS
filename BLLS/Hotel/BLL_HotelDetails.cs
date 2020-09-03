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
    public class BLL_HotelDetails
    {
        public int Insert_Customer(string f_name, string l_name, string contact, string country, string email_id, string gender, string house_no, string city, string state, string id_type, string id_number, byte[] id_image, DateTime date)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
            new SqlParameter("@f_name",f_name),
        new SqlParameter("@l_name",l_name),
        new SqlParameter ("@contact",contact),
        new SqlParameter("@country",country),
        new SqlParameter("@email_id",email_id),
        new SqlParameter("@gender",gender),
         new SqlParameter("@house_no",house_no),
          new SqlParameter("@city",city),
           new SqlParameter("@state",state),
           new SqlParameter("@id_type",id_type),
            new SqlParameter("@id_number",id_number),
                 new SqlParameter("@id_image",id_image),
             new SqlParameter("@date",date),
            };
            return DAL.IDU("Insert into hotel_customer(f_name,l_name,contact,country,email_id,gender,house_no,city,state,id_type,id_number,id_image,date_of_birth) values (@f_name,@l_name,@contact,@country,@email_id,@gender,@house_no,@city,@state,@id_type,@id_number,@id_image,@date)", parm);
        }
        public int Insert_Pending_booking(int customer_id, DateTime booking_date, DateTime check_in, string room_type, int no_of_guest, DateTime check_out, string no_of_room, string room_id, string book_by, DateTime insert_date)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
            new SqlParameter("@customer_id",customer_id),
        new SqlParameter("@booking_date",booking_date),
        new SqlParameter ("@check_in",check_in),
        new SqlParameter("@room_type",room_type),
        new SqlParameter("@no_of_guest",no_of_guest),
        new SqlParameter("@check_out",check_out),
         new SqlParameter("@no_of_room",no_of_room),
          new SqlParameter("@room_id",room_id),
           new SqlParameter("@book_by",book_by),
        new SqlParameter("@insert_date",insert_date),


            };
            return DAL.IDU("Insert into hotel_pending_book(customer_id,booking_date,check_in,room_type,no_of_guest,check_out,no_of_room,room_id,booking_by,insert_date) values (@customer_id,@booking_date,@check_in,@room_type,@no_of_guest,@check_out,@no_of_room,@room_id,@book_by,@insert_date)", parm);
        }
        public int Insert_Booking(int customer_id, DateTime booking_date, DateTime check_in, string room_type, int no_of_guest, DateTime check_out, string no_of_room, string room_id,int package_id)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
            new SqlParameter("@customer_id",customer_id),
        new SqlParameter("@booking_date",booking_date),
        new SqlParameter ("@check_in",check_in),
        new SqlParameter("@room_type",room_type),
        new SqlParameter("@no_of_guest",no_of_guest),
        new SqlParameter("@check_out",check_out),
         new SqlParameter("@no_of_room",no_of_room),
          new SqlParameter("@room_id",room_id),
            new SqlParameter("@package_id",package_id),
            };
            return DAL.IDU("Insert into hotel_bookings(customer_id,booking_date,check_in,room_type,no_of_guest,check_out,no_of_room,room_id,package_id) values (@customer_id,@booking_date,@check_in,@room_type,@no_of_guest,@check_out,@no_of_room,@room_id,@package_id)", parm);
        }
        public int Insert_Room_Category(int category_id, string category_name, decimal category_price, int no_of_beds, string description)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
            new SqlParameter("@category_id",category_id),
        new SqlParameter("@category_name",category_name),
        new SqlParameter ("@category_price",category_price),
        new SqlParameter("@no_of_beds",no_of_beds),
        new SqlParameter("@description",description),
     };
            return DAL.IDU("Insert into hotel_room_category(category_id,category_name,category_price,no_of_beds,description) values (@category_id,@category_name,@category_price,@no_of_beds,@description)", parm);
        }
        public int Insert_Coupon(string coupon_type, int coupon_offer)
        {
            SqlParameter[] parm = new SqlParameter[]
            {

        new SqlParameter("@coupon_type",coupon_type),
        new SqlParameter ("@coupon_offer",coupon_offer),

     };
            return DAL.IDU("Insert into hotel_coupon(coupon_type,coupon_offer) values (@coupon_type,@coupon_offer)", parm);
        }
        public int Update_Coupon(int coupon_id, string coupon_type, int coupon_offer)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
new SqlParameter("@coupon_id",coupon_id),
        new SqlParameter("@coupon_type",coupon_type),
        new SqlParameter ("@coupon_offer",coupon_offer),

     };
            return DAL.IDU("update hotel_coupon set coupon_type=@coupon_type,coupon_offer=@coupon_offer where coupon_id=@coupon_id", parm);
        }

        public int Delete_Coupon(int coupon_id)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
new SqlParameter("@coupon_id",coupon_id),


     };
            return DAL.IDU("delete from hotel_coupon  where coupon_id=@coupon_id", parm);
        }
        public DataTable GetCouponByid(int coupon_id)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
new SqlParameter("@coupon_id",coupon_id),


     };
            return DAL.getuser("select * from hotel_coupon where coupon_id=@coupon_id", parm);
        }
        public int Insert_Customer_details(int customer_id, string comming_from, string going_to, string purpose_of_visit)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
            new SqlParameter("@customer_id",customer_id),
        new SqlParameter("@comming_from",comming_from),
        new SqlParameter ("@going_to",going_to),
          new SqlParameter ("@purpose_of_visit",purpose_of_visit),

     };
            return DAL.IDU("Insert into hotel_customer_details(customer_id,comming_from,going_to,purpose_of_visit) values (@customer_id,@comming_from,@going_to,@purpose_of_visit)", parm);
        }
        public DataTable GetID(string f_name, string l_name)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
            new SqlParameter("@f_name",f_name),
        new SqlParameter("@l_name",l_name),


     };
            return DAL.getuser("select * from hotel_customer where f_name=@f_name and l_name=@l_name", parm);
        }
        public DataTable GetCouponList()
        {

            return DAL.getuser("select * from hotel_coupon ", null);
        }

       
    }
}
