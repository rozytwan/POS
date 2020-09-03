using DOA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLS.BLLHotel
{
    public class BLL_HotelCategory
    {
        public DataTable GetCategory()
        {
            return DAL.getuser("select * from hotel_room_category", null);

        }
        public DataTable GetRoomDetails()
        {
            return DAL.getuser("select * from hotel_room_details", null);

        }
        public DataTable GetRoomPackage()
        {
            return DAL.getuser("select * from hotel_room_package", null);

        }
        public int Insert_Category(string category_name, int no_of_beds, string description)
        {
            SqlParameter[] parm = new SqlParameter[]
            {

        new SqlParameter("@category_name",category_name),

         new SqlParameter ("@no_of_beds",no_of_beds),
           new SqlParameter ("@description",description),
     };
            return DAL.IDU("Insert into hotel_room_category(category_name,no_of_bed,description) values (@category_name,@no_of_beds,@description)", parm);
        }
        public int Insert_Room_Package(string package_name,decimal price, string description)
        {
            SqlParameter[] parm = new SqlParameter[]
            {

        new SqlParameter("@package_name",package_name),
        new SqlParameter("@price",price),
           new SqlParameter ("@description",description),
     };
            return DAL.IDU("Insert into hotel_room_package(package_name,price,description) values (@package_name,@price,@description)", parm);
        }
        public DataTable GetRoompackageById(int package_id)
        {
            SqlParameter[] parm = new SqlParameter[]
        {

        new SqlParameter("@package_id",package_id),

 };
            return DAL.getuser("Select * from hotel_room_package where package_id=@package_id", parm);
        }

        public int UpdatePackage(int package_id, string package_name,decimal price, string description)
        {
            SqlParameter[] parm = new SqlParameter[]
        {

        new SqlParameter("@package_id",package_id),
         new SqlParameter("@package_name",package_name),
          new SqlParameter("@price",price),
           new SqlParameter ("@description",description),

 };
            return DAL.IDU("update hotel_room_package set package_name=@package_name,price=@price,description=@description where package_id=@package_id", parm);
        }
        public int DeleteRoomPackage(int package_id)
        {
            SqlParameter[] parm = new SqlParameter[]
        {

        new SqlParameter("@package_id",package_id),

        };
            return DAL.IDU("delete from hotel_room_package where package_id=@package_id", parm);

        }

        public DataTable GetCategoryById(int room_category_id)
        {
            SqlParameter[] parm = new SqlParameter[]
        {

        new SqlParameter("@room_category_id",room_category_id),

 };
            return DAL.getuser("Select * from hotel_room_category where room_category_id=@room_category_id", parm);
        }
        public DataTable GetBookingId(int room_id)
        {
            SqlParameter[] parm = new SqlParameter[]
        {

        new SqlParameter("@room_id",room_id),

 };
            return DAL.getuser("Select * from hotel_bookings where room_id=@room_id", parm);
        }
        public DataTable GetDetailById(int room_category_id)
        {
            SqlParameter[] parm = new SqlParameter[]
        {

        new SqlParameter("@room_category_id",room_category_id),

 };
            return DAL.getuser("Select * from hotel_room_details where room_category_id=@room_category_id", parm);
        }
        public DataTable GetRoomNo(int room_id)
        {
            SqlParameter[] parm = new SqlParameter[]
        {

        new SqlParameter("@room_id",room_id),

 };
            return DAL.getuser("Select * from hotel_room_details where room_id=@room_id", parm);
        }
        public int UpdateCategory(int room_category_id, string category_name, int no_of_bed, string description)
        {
            SqlParameter[] parm = new SqlParameter[]
        {

        new SqlParameter("@room_category_id",room_category_id),
         new SqlParameter("@category_name",category_name),

         new SqlParameter ("@no_of_bed",no_of_bed),
           new SqlParameter ("@description",description),

 };
            return DAL.IDU("update hotel_room_category set category_name=@category_name,no_of_bed=@no_of_bed,description=@description where room_category_id=@room_category_id", parm);
        }
        public int DeleteCategory(int room_category_id)
        {
            SqlParameter[] parm = new SqlParameter[]
 {

        new SqlParameter("@room_category_id",room_category_id),

};
            return DAL.IDU("delete from hotel_room_category where room_category_id=@room_category_id", parm);

        }

        public int Insert_Room(int room_category_id, int package_id, string room_no, decimal price, string status, Byte[] image)
        {
            SqlParameter[] parm = new SqlParameter[]
            {

        new SqlParameter("@room_category_id",room_category_id),
         new SqlParameter("@package_id",package_id),
        new SqlParameter ("@room_no",room_no),
        new SqlParameter ("@price",price),
         new SqlParameter ("@status",status),
         new SqlParameter ("@image",image),

     };
            return DAL.IDU("Insert into hotel_room_details(room_category_id,package_id,room_no,price,status,image) values (@room_category_id,@package_id,@room_no,@price,@status,@image)", parm);
        }
        public int Update_Room(int room_id, int room_category_id, int package_id, string room_no, decimal price, string status, Byte[] image)
        {
            SqlParameter[] parm = new SqlParameter[]
            {

        new SqlParameter("@room_id",room_id),
         new SqlParameter ("@room_category_id",room_category_id),
         new SqlParameter ("@package_id",package_id),
        new SqlParameter ("@room_no",room_no),
        new SqlParameter ("@price",price),
         new SqlParameter ("@status",status),
             new SqlParameter ("@image",image),

     };
            return DAL.IDU("update hotel_room_details set room_no=@room_no,status=@status,room_category_id=@room_category_id,package_id=@package_id,price=@price,image=@image where room_id=@room_id", parm);
        }
        public int DeleteRoom(int room_id)
        {
            SqlParameter[] parm = new SqlParameter[]
 {

        new SqlParameter("@room_id",room_id),

};
            return DAL.IDU("delete from hotel_room_details where room_id=@room_id", parm);

        }

        public int Insert_Room(int room_category_id, string room_no, decimal price, string status, Byte[] image)
        {
            SqlParameter[] parm = new SqlParameter[]
            {

        new SqlParameter("@room_category_id",room_category_id),
        new SqlParameter ("@room_no",room_no),
        new SqlParameter ("@price",price),
         new SqlParameter ("@status",status),
         new SqlParameter ("@image",image),

     };
            return DAL.IDU("Insert into hotel_room_details(room_category_id,room_no,price,status,image) values (@room_category_id,@room_no,@price,@status,@image)", parm);
        }
        public int Update_Room(int room_id, int room_category_id, string room_no, decimal price, string status, Byte[] image)
        {
            SqlParameter[] parm = new SqlParameter[]
            {

        new SqlParameter("@room_id",room_id),
         new SqlParameter ("@room_category_id",room_category_id),
        new SqlParameter ("@room_no",room_no),
        new SqlParameter ("@price",price),
         new SqlParameter ("@status",status),
             new SqlParameter ("@image",image),

     };
            return DAL.IDU("update hotel_room_details set room_no=@room_no,status=@status,room_category_id=@room_category_id,price=@price,image=@image where room_id=@room_id", parm);
        }
        public int UpdateRoombyid(int room_id)
        {
            SqlParameter[] parm = new SqlParameter[]
            {

             new SqlParameter("@room_id",room_id),

            };
            return DAL.IDU("update hotel_room_details set status='Messy' where room_id=@room_id", parm);

        }
        public int UpdateRoomstatusById(int room_id,string status)
        {
            SqlParameter[] parm = new SqlParameter[]
            {

             new SqlParameter("@room_id",room_id),
             new SqlParameter("@status",status)

            };
            return DAL.IDU("update hotel_room_details set status=@status where room_id=@room_id", parm);

        }
        public int UpdateImage(string image_id, string room_image,string description)
        {
            SqlParameter[] parm = new SqlParameter[]
            {

            new SqlParameter("@image_id",image_id),
            new SqlParameter ("@room_image",room_image),
            new SqlParameter ("@description",description)

            };
            return DAL.IDU("update hotel_room_image set room_image=@room_image,description=@description where image_id=@image_id", parm);

        }
        public int Insert_RoomImage(int room_id, string image, string description)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
             new SqlParameter("@room_id",room_id),
             new SqlParameter ("@image",image),
             new SqlParameter ("@description",description),

             };
            return DAL.IDU("Insert into hotel_room_image(room_id,room_image,description) values (@room_id,@image,@description)", parm);
        }
    }
}
