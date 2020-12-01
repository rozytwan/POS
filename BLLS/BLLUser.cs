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
    public class BLLUser
    {
        public DataTable getalluser()
        {
            return DAL.getuser("select * from tbl_user", null);
        }
        public DataTable GetServiceProvider()
        {
            return DAL.getuser("select distinct(service_provider) from tbl_sales_record where service_provider is not null", null);
        }
    public DataTable getusername(string user_name)
        {
             SqlParameter[] parm = new  SqlParameter[] 
            {
                new  SqlParameter("@user_name", user_name)
            };               
            return DAL.getuser("select * from tbl_user where user_name=@user_name",parm);
        }
        public DataTable getalluserlogin(string user_name, string password)
        {

         SqlParameter[] parm = new  SqlParameter[]
         {
         new  SqlParameter("@user_name",user_name),
         new  SqlParameter("@password",password)
         };
            return DAL.getuser("select * from tbl_user where user_name=@user_name and password=@password", parm);

        }

        public DataTable getpasswordbyusername(string password)
        {
            SqlParameter[] parm = new SqlParameter[]
           {
                new SqlParameter("@password",password)

           };

            return DAL.getuser("select * from tbl_user where password=@password", parm);
        }
        public int newpassword(string password, string user_name)
        {
            SqlParameter[] parm = new SqlParameter[]
           {
                new SqlParameter("@password",password),
                new SqlParameter("@user_name",user_name)


           };
            return DAL.IDU("update tbl_user set password=@password where user_name=@user_name", parm);
        }

        public int signupuser(string user_name, string pasword, string user_type, string e_mail)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
            new SqlParameter("@user_name",user_name),
            new SqlParameter("@password",pasword),
            new SqlParameter("@user_type",user_type),
            new SqlParameter("@e_mail",e_mail)
            };
            return DAL.IDU("insert into tbl_user(user_name,password,user_type,e_mail) values(@user_name,@password,@user_type,@e_mail)", parm);
        }

        
        public int createbusiness(string business_name, string address, string phone_no,string photo_name,string note_1,string note_2,string language,string pan_no,byte[] blogo)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
            new SqlParameter("@business_name",business_name),
            new SqlParameter("@address",address),
            new SqlParameter("@phone_no",phone_no),
            new SqlParameter("@note_1",note_1),
            new SqlParameter("@note_2",note_2),
             new SqlParameter("@language",language),
               new SqlParameter("@pan_no",pan_no),
                new SqlParameter("@blogo",blogo)
            };
            return DAL.IDU("insert into tbl_business (business_name,address,phone_no,note_1,note_2,language,pan_no,blogo) values (@business_name,@address,@phone_no,@note_1,@note_2,@language,@pan_no,@blogo)", parm);
        }
        public int updatebusiness(string business_name, string address, string phone_no,int business_id,string note_1,string note_2,string pan_no)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
            new SqlParameter("@business_name",business_name),
            new SqlParameter("@address",address),
            new SqlParameter("@phone_no",phone_no),
            new SqlParameter("@business_id",business_id),
            new SqlParameter("@note_1",note_1),
            new SqlParameter("@note_2",note_2),
             new SqlParameter("@pan_no",pan_no)
            };
            return DAL.IDU("Update tbl_business set business_name=@business_name,address=@address,phone_no=@phone_no,note_1=@note_1,note_2=@note_2,pan_no=@pan_no where business_id=@business_id", parm);
        }
        public DataTable checkbusiness()
        {
            return DAL.getuser("select * from tbl_business", null);
        }
      
        public DataTable getuserbyuser_idntype(int user_id)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                  new SqlParameter("@user_id",user_id),               
                };
            return DAL.getuser("select * from tbl_user_access where user_id=@user_id", parm);
        }
        public DataTable get_user_and_type_inner(int user_id)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                  new SqlParameter("@user_id",user_id),
                };
            return DAL.getuser("SELECT * FROM tbl_user_access where user_id=@user_id", parm);
        }
        public int updateuser_access(int user_id, string admin, string account, string sales, string report, string stock, string discount, string billing, string multibilling, string itemtransfer, string tabletransfer, string takeaway, string homedelivery, string dayend, string cashdrop, string menuupdate, string itemcancel,string restaurant,string hotel)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                  new SqlParameter("@user_id",user_id),
                  new SqlParameter("@admin",admin),
                    new SqlParameter("@account",account),
                    new SqlParameter("@sales",sales),
                    new SqlParameter("@report",report),
                    new SqlParameter("@stock",stock),
                    new SqlParameter("@discount",discount),
                    new SqlParameter("@billing",billing),
                     new SqlParameter("@multibilling",multibilling),
                    new SqlParameter("@itemtransfer",itemtransfer),
                    new SqlParameter("@tabletransfer",tabletransfer),
                     new SqlParameter("@takeaway",takeaway),
                    new SqlParameter("@homedelivery",homedelivery),
                    new SqlParameter("@dayend",dayend),
                     new SqlParameter("@cashdrop",cashdrop),
                    new SqlParameter("@menuupdate",menuupdate),
                    new SqlParameter("@itemcancel",itemcancel),
                    new SqlParameter("@restaurant",restaurant),
                    new SqlParameter("@hotel",hotel),
                };
            return DAL.IDU("update tbl_user_access set admin=@admin,account=@account,sales=@sales,report=@report,stock=@stock,discount=@discount,billing=@billing,multibilling=@multibilling,itemtransfer=@itemtransfer,tabletransfer=@tabletransfer,takeaway=@takeaway,homedelivery=@homedelivery,dayend=@dayend,cashdrop=@cashdrop,menuupdate=@menuupdate,itemcancel=@itemcancel,restaurant=@restaurant,hotel=@hotel where user_id=@user_id", parm);
        }
        public int insert_user_id(int user_id, string admin, string account, string sales, string report, string stock, string discount, string billing, string multibilling, string itemtransfer, string tabletransfer, string takeaway, string homedelivery, string dayend, string cashdrop, string menuupdate, string itemcancel,string restaurant,string hotel)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                  new SqlParameter("@user_id",user_id),
                  new SqlParameter("@admin",admin),
                    new SqlParameter("@account",account),
                    new SqlParameter("@sales",sales),
                  new SqlParameter("@report",report),
                    new SqlParameter("@stock",stock),
                    new SqlParameter("@discount",discount),
                    new SqlParameter("@billing",billing),
                     new SqlParameter("@multibilling",multibilling),
                    new SqlParameter("@itemtransfer",itemtransfer),
                    new SqlParameter("@tabletransfer",tabletransfer),
                      new SqlParameter("@takeaway",takeaway),
                    new SqlParameter("@homedelivery",homedelivery),
                    new SqlParameter("@dayend",dayend),
                     new SqlParameter("@cashdrop",cashdrop),
                    new SqlParameter("@menuupdate",menuupdate),
                    new SqlParameter("@itemcancel",itemcancel),
                    new SqlParameter("@restaurant",restaurant),
                    new SqlParameter("@hotel",hotel),

                };
            return DAL.IDU("insert into tbl_user_access (user_id,admin,account,sales,report,stock,discount,billing,multibilling,itemtransfer,tabletransfer,takeaway,homedelivery,dayend,cashdrop,menuupdate,itemcancel,restaurant,hotel) values(@user_id,@admin,@account,@sales,@report,@stock,@discount,@billing,@multibilling,@itemtransfer,@tabletransfer,@takeaway,@homedelivery,@dayend,@cashdrop,@menuupdate,@itemcancel,@restaurant,@hotel)", parm);
        }
        public int saveusers(string user_name, string password, string user_type, string e_mail, string first_name, string last_name, string gender, DateTime date_of_birth, string phone_number, string pin, DateTime date_of_joining, string address_line_1, string address_line_2, string city, string state, string zip_code, string user_image)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@user_name", user_name),
                new SqlParameter("@password", password),
                new SqlParameter("@user_type", user_type),
                new SqlParameter("@e_mail", e_mail),
                new SqlParameter("@first_name", first_name),
                new SqlParameter("@last_name", last_name),
                new SqlParameter("@gender", gender),
                new SqlParameter("@date_of_birth", date_of_birth),
                new SqlParameter("@phone_number", phone_number),
                new SqlParameter("@pin", pin),
                new SqlParameter("@date_of_joining", date_of_joining),
                new SqlParameter("@address_line_1", address_line_1),
                new SqlParameter("@address_line_2", address_line_2),
                new SqlParameter("@city", city),
                new SqlParameter("@state", state),
                new SqlParameter("@zip_code", zip_code),
                new SqlParameter("@user_image", user_image)
            };
            return DAL.IDU("Insert into tbl_user(user_name,password,user_type,e_mail,first_name,last_name,gender,date_of_birth,phone_number,pin,date_of_joining,address_line_1,address_line_2,city,state,zip_code,user_image) values(@user_name,@password,@user_type,@e_mail,@first_name,@last_name,@gender,@date_of_birth,@phone_number,@pin,@date_of_joining,@address_line_1,@address_line_2,@city,@state,@zip_code,@user_image)", parm);
        }

        public DataTable getalluserdetails()
        {
            return DAL.getuser("Select * from tbl_user", null);
        }

        public DataTable getuserdetailsby_user_id(int user_id)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@user_id", user_id)
            };
            return DAL.getuser("Select * from tbl_user where user_id = @user_id", parm);
        }

        public int deleteuser(int user_id)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@user_id", user_id)
            };
            return DAL.IDU("Delete from tbl_user where user_id = @user_id", parm);
        }

        public int update_users(int user_id, string user_name, string password, string user_type, string e_mail, string first_name, string last_name, string gender, DateTime date_of_birth, string phone_number, string pin, DateTime date_of_joining, string address_line_1, string address_line_2, string city, string state, string zip_code, string user_image)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@user_id", user_id),
                new SqlParameter("@user_name", user_name),
                new SqlParameter("@password", password),
                new SqlParameter("@user_type", user_type),
                new SqlParameter("@e_mail", e_mail),
                new SqlParameter("@first_name", first_name),
                new SqlParameter("@last_name", last_name),
                new SqlParameter("@gender", gender),
                new SqlParameter("@date_of_birth", date_of_birth),
                new SqlParameter("@phone_number", phone_number),
                new SqlParameter("@pin", pin),
                new SqlParameter("@date_of_joining", date_of_joining),
                new SqlParameter("@address_line_1", address_line_1),
                new SqlParameter("@address_line_2", address_line_2),
                new SqlParameter("@city", city),
                new SqlParameter("@state", state),
                new SqlParameter("@zip_code", zip_code),
                new SqlParameter("@user_image", user_image)
            };
            return DAL.IDU("Update tbl_user set user_name = @user_name,password = @password, user_type = @user_type, e_mail = @e_mail, first_name = @first_name, last_name = @last_name,gender = @gender,date_of_birth = @date_of_birth,phone_number = @phone_number,pin = @pin, date_of_joining = @date_of_joining, address_line_1 = @address_line_1,address_line_2 = @address_line_2,city = @city, state = @state,zip_code = @zip_code,user_image = @user_image where user_id = @user_id", parm);
        }

        public DataTable getuser_imagenamebyuser_id(int users_id)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@users_id", users_id)
            };
            return DAL.getuser("Select * from tbl_user where user_id = @users_id", parm);
        }
        public DataTable Getuserhotelaccess(int user_id)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                  new SqlParameter("@user_id",user_id),
                };
            return DAL.getuser("select * from hotel_access where user_id=@user_id", parm);
        }
        public int insert_access_user(int user_id, string admin, string room_access, string sales, string report, string discount)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                  new SqlParameter("@user_id",user_id),
                  new SqlParameter("@admin",admin),
                    new SqlParameter("@room_access",room_access),
                    new SqlParameter("@sales",sales),
                  new SqlParameter("@report",report),

                    new SqlParameter("@discount",discount)
                };
            return DAL.IDU("insert into hotel_access (user_id,admin,room_access,sales,report,discount) values(@user_id,@admin,@room_access,@sales,@report,@discount)", parm);
        }
        public int updatehotel_access(int user_id, string admin, string room_access, string sales, string report, string discount)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                  new SqlParameter("@user_id",user_id),
                  new SqlParameter("@admin",admin),
                    new SqlParameter("@room_access",room_access),
                    new SqlParameter("@sales",sales),
                    new SqlParameter("@report",report),

                    new SqlParameter("@discount",discount)
                };
            return DAL.IDU("update hotel_access set admin=@admin,room_access=@room_access,sales=@sales,report=@report,discount=@discount where user_id=@user_id", parm);
        }
        public int updateuser_access(int user_id, string admin, string account, string sales, string report, string stock, string discount, string billing, string multibilling, string itemtransfer, string tabletransfer)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                  new SqlParameter("@user_id",user_id),
                  new SqlParameter("@admin",admin),
                    new SqlParameter("@account",account),
                    new SqlParameter("@sales",sales),
                    new SqlParameter("@report",report),
                    new SqlParameter("@stock",stock),
                    new SqlParameter("@discount",discount),
                    new SqlParameter("@billing",billing),
                     new SqlParameter("@multibilling",multibilling),
                    new SqlParameter("@itemtransfer",itemtransfer),
                    new SqlParameter("@tabletransfer",tabletransfer),

                };
            return DAL.IDU("update tbl_user_access set admin=@admin,account=@account,sales=@sales,report=@report,stock=@stock,discount=@discount,billing=@billing,multibilling=@multibilling,itemtransfer=@itemtransfer,tabletransfer=@tabletransfer where user_id=@user_id", parm);
        }

    }
}
