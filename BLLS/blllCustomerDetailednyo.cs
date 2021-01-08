using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DOA;
using System.Data;
using System.Data.SqlClient;

namespace BLLS
{
    public class blllCustomerDetailednyo
    {
        public int insertintotables(Byte[] images, string name, string lastname, DateTime dob, string gender, string address, string phone, string phone2, string city, string country, string nationality, string nationalityId, string email, string status, string card_no, string card_type)
        {

            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@name",name),
                new SqlParameter("@lastname",lastname),
                new SqlParameter("@dob",dob),
                new SqlParameter("@gender",gender),
                new SqlParameter("@address",address),
                new SqlParameter("@phone",phone),
                new SqlParameter("@phone2",phone2),
                new SqlParameter("@city",city),
                new SqlParameter("@country",country),
                new SqlParameter("@nationality",nationality),
                new SqlParameter("@nationalityId",nationalityId),
                new SqlParameter("@email",email),
                  new SqlParameter("@images",images),
                new SqlParameter("@status",status),
                 new SqlParameter("@card_no",card_no),
                new SqlParameter("@card_type",card_type)

                };
            return DAL.IDU("insert into tbl_customerDetailnyo (name,lastname,birthdate,gender,phone,phone2,city,country,nationality,nationid,email,status,image,address,card_no,card_type) OUTPUT Inserted.id values(@name,@lastname,@dob,@gender,@phone,@phone2,@city,@country,@nationality,@nationalityId,@email,@status,@images,@address,@card_no,@card_type)", parm);
        }
        public int Insert_add_balance(int customer_id, string name, decimal balance_add, DateTime date, string status, string recharge_type, string remarks)
        {

            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@customer_id",customer_id),
                    new SqlParameter("@name",name),
                new SqlParameter("@balance_add",balance_add),
                new SqlParameter("@date",date),
                     new SqlParameter("@status",status),
                     new SqlParameter("@recharge_type",recharge_type),
                         new SqlParameter("@remarks",remarks),

            };
            return DAL.IDU("insert into tbl_add_balance_log(customer_id,username,balance_add,date,status,recharge_type,remarks) values (@customer_id,@name,@balance_add,@date,@status,@recharge_type,@remarks)", parm);
        }
        public int culbCardAmountLess(int customer_id, decimal grand_total)
        {
            SqlParameter[] parm = new SqlParameter[]
          {
              new SqlParameter("@customer_id",customer_id),
               new SqlParameter("@grand_total",grand_total)

           };
            return DAL.IDU("Update tbl_customer_card_info set customer_balance=customer_balance-@grand_total where customer_id=@customer_id", parm);
        }
     
        public int Insert_Cash_Back(int customer_id, string name, decimal cash_back, DateTime date, string status, string x_report)
        {

            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@customer_id",customer_id),
                    new SqlParameter("@name",name),
                new SqlParameter("@cash_back",cash_back),
                new SqlParameter("@date",date),
                     new SqlParameter("@status",status),
                      new SqlParameter("@x_report",x_report),


            };
            return DAL.IDU("insert into tbl_cash_back(customer_id,username,cash_back,date,status,x_report) values (@customer_id,@name,@cash_back,@date,@status,@x_report)", parm);
        }
        public int Update_customer_balane(int customer_id, decimal customer_balance)
        {

            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@customer_balance",customer_balance),
                new SqlParameter("@customer_id",customer_id)

            };
            return DAL.IDU("Update tbl_customer_card_info set customer_balance=customer_balance-@customer_balance where customer_id=@customer_id", parm);
        }
        public DataTable Getcustomerphone(string phone)
        {

            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@phone",phone),

            };
            return DAL.getuser("select * from tbl_customerDetailnyo where phone=@phone", parm);
        }
        public DataTable GetItems(string customer_no,DateTime date)
        {
            SqlParameter[] parm = new SqlParameter[]
             {
            new SqlParameter ("@customer_no", customer_no),
               new SqlParameter ("@date", date)
             };
            DataTable dt = new DataTable();
            dt = DAL.getuser("select * from tbl_sales_record where customer_no=@customer_no and date_of_sale=@date ", parm);
            return dt;
        }
        public DataTable GetItemsByDate(string customer_no, DateTime datefrom,DateTime dateto)
        {
            SqlParameter[] parm = new SqlParameter[]
             {
            new SqlParameter ("@customer_no", customer_no),
               new SqlParameter ("@datefrom", datefrom),
                new SqlParameter ("@dateto", dateto)
             };
            DataTable dt = new DataTable();
            dt = DAL.getuser("select * from tbl_sales_record where customer_no=@customer_no and date_of_sale between @datefrom and @dateto ", parm);
            return dt;
        }
        public DataTable getallcustomers()
        {

            return DAL.getuser("select  *  from tbl_customerDetailnyo order by id desc", null);
        }

        public DataTable GetSalesbyBillNo(int bill_no, DateTime date)
        {
            SqlParameter[] parm = new SqlParameter[]
               {
            new SqlParameter ("@bill_no", bill_no),
             new SqlParameter ("@date", date)
               };

            DataTable dt = new DataTable();
            dt = DAL.getuser("select * from tbl_sales_record where bill_no=@bill_no and date2=@date", parm);
            return dt;
        }
        public DataTable SearchCustomerSales(int customer_no, DateTime from, DateTime to)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
             new SqlParameter("@customer_no",customer_no),
              new SqlParameter("@from",from),
                new SqlParameter("@to",to)
            };
            return DAL.getuser("select * from tbl_sales_record where customer_no= @customer_no and  cast(date2 as date) between @from and @to ", parm);
        }
        public DataTable getallcustomersPhoneNoName()
        {
            return DAL.getuser("select concat(name , ' ' , lastname) AS name,phone,id,image from tbl_customerDetailnyo order by nationid desc", null);
        }
        public int fast_Customer_Create(string name, string phone, string address)
        {

            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@name",name),
                new SqlParameter("@phone",phone),
                 new SqlParameter("@address",address)
            };
            return DAL.IDU("insert into tbl_customerDetailnyo (name,phone,address) values (@name,@phone,@address)", parm);
        }

        public DataTable getallcustomersrecent(int minPageSize,int intskip)
        {

            return DAL.getuser("select Top " + minPageSize + " cd.card_no,cd.card_type,cd.name,cd.lastname,cd.id,cd.phone,c.customer_balance from tbl_customerDetailnyo cd left join tbl_customer_card_info c on (cd.id=c.customer_id) where  cd.id not in (select top " + intskip + " cn.id from tbl_customerDetailnyo cn)", null);
        }
        public DataTable getallcustomersrecent()
        {

            return DAL.getuser("select  cd.card_no,cd.card_type,cd.name,cd.lastname,cd.id,cd.phone,c.customer_balance from tbl_customerDetailnyo cd join tbl_customer_card_info c on (cd.id=c.customer_id)", null);
        }
        public DataTable search_By_name(string name, int minPageSize, int intskip)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@name",name),

            };
            return DAL.getuser("select Top " + minPageSize + " cd.card_no,cd.card_type,cd.name,cd.lastname,cd.id,cd.phone,c.customer_balance,cd.address from tbl_customerDetailnyo cd join tbl_customer_card_info c on (cd.id=c.customer_id) where  cd.id not in (select top " + intskip + " cn.id from tbl_customerDetailnyo cn) and cd.name like @name +'%'", parm);
        }
        public DataTable getDataByitsPhonenumbers(string numbers, int minPageSize, int intskip)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@numbers",numbers),

            };
            return DAL.getuser("select Top " + minPageSize + " cd.card_no,cd.card_type,cd.name,cd.lastname,cd.id,cd.phone,c.customer_balance from tbl_customerDetailnyo cd join tbl_customer_card_info c on (cd.id=c.customer_id) where  cd.id not in (select top " + intskip + " cn.id from tbl_customerDetailnyo cn) and phone like @numbers +'%' or phone2 like @numbers  +'%' ", parm);
        }
        public DataTable countTotalCUstomer()
        {
            return DAL.getuser("select count(id) from tbl_customerDetailnyo", null);
        }
       
        public DataTable getDataByitsId(int ids) {

            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@ids",ids)
            };
            return DAL.getuser("select * from tbl_customerDetailnyo where id = @ids", parm);
        }

        public DataTable getDataByitsusername(string name, string lastname)
        {

            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@name",name),
                new SqlParameter("@lastname",lastname)
            };
            return DAL.getuser("select * from tbl_customerDetailnyo where name =@name and lastname=@lastname", parm);
        }
        public DataTable getDataByitsusername_phone(string name, string phone)
        {

            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@name",name),
                new SqlParameter("@phone",phone)
            };
            return DAL.getuser("select * from tbl_customerDetailnyo where name =@name and phone=@phone", parm);
        }

        public DataTable getDataByitsPhonenumbers(string numbers)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@numbers",numbers),

            };
            return DAL.getuser("select * from tbl_customerDetailnyo where phone = @numbers  ", parm);
        }
        public DataTable search_By_Fullname(string full_name)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@full_name",full_name),

            };
            return DAL.getuser("select * from tbl_customerDetailnyo where name like '%'+@full_name ", parm);
        }
    
        public DataTable getDataByitsemails(string card_no)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@card_no",card_no),

            };
            return DAL.getuser("select * from tbl_customerDetailnyo where card_no=@card_no ", parm);
        }
        public int updateintotables(Byte[] images, string name, string lastname, DateTime dob, string gender, string address, string phone, string phone2, string city, string country, string nationality, string nationalityId, string email, String userid, string status, string card_no, string card_type)
        {

            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@userid",userid),
                new SqlParameter("@name",name),
                new SqlParameter("@lastname",lastname),
                new SqlParameter("@dob",dob),
                new SqlParameter("@gender",gender),
                new SqlParameter("@address",address),
                new SqlParameter("@phone",phone),
                new SqlParameter("@phone2",phone2),
                new SqlParameter("@city",city),
                new SqlParameter("@country",country),
                new SqlParameter("@nationality",nationality),
                new SqlParameter("@nationalityId",nationalityId),
                new SqlParameter("@email",email),
                new SqlParameter("@images",images),
                 new SqlParameter("@status",status),
                new SqlParameter("@card_no",card_no),
                new SqlParameter("@card_type",card_type)

             };
            return DAL.IDU("update tbl_customerDetailnyo set name = @name,lastname=@lastname,birthdate=@dob,gender=@gender,phone=@phone,phone2=@phone2,city=@city,country=@country,nationality=@nationality, nationid=@nationalityId,email=@email,image=@images,address=@address,card_no=@card_no,card_type=@card_type,status=@status where id = @userid", parm);
        }


        public DataTable search_By_Firstname(string name)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@name",name),

            };
            return DAL.getuser("select * from tbl_customerDetailnyo where name like @name +'%'", parm);
        }
        public DataTable getallcustomersWithOutPakges()
        {

            return DAL.getuser("select top 50 * from tbl_customerDetailnyo", null);
        }

        public DataTable getallcustomersHavingPakges()
        {

            return DAL.getuser("select * from tbl_customerDetailnyo where pakage_name !='' and status='ON'", null);
        }

        public DataTable getallcustomersbyPakages(String pakageName)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@pakageName",pakageName)
            };
            return DAL.getuser("select * from tbl_customerDetailnyo where pakage_name=@pakageName", parm);
        }
        public int delete_customer(int id)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@id",id)
            };
            return DAL.IDU("Delete from tbl_customerDetailnyo where id = @id", parm);
        }

        public DataTable searchallcustomersbyPakages(String pakageName, string customername)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@pakageName",pakageName),
                new SqlParameter("@customername",customername)
            };
            return DAL.getuser("select * from tbl_customerDetailnyo where pakage_name=@pakageName and name like @customername +'%' ", parm);
        }

        public int InsertCardTransaction(int customer_id, string user_name, decimal amount, DateTime date, string status, string payment_mode)
        {

            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@customer_id",customer_id),
                    new SqlParameter("@user_name",user_name),
                new SqlParameter("@amount",amount),
                new SqlParameter("@date",date),
                     new SqlParameter("@status",status),
                     new SqlParameter("@payment_mode",payment_mode),
              };
            return DAL.IDU("insert into tbl_card_transactionlog(customer_id,user_name,amount,date,status,payment_mode) values (@customer_id,@user_name,@amount,@date,@status,@payment_mode)", parm);
        }



        public DataTable getDataByitspackagename(string package)
        {

            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@package",package),
                           };
            return DAL.getuser("select * from tbl_customerDetailnyo where pakage_name like @package +'%'", parm);
        }
        public DataTable GetpackagenotsetCustomer(string id)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@id",id),

            };
            return DAL.getuser("Select *from tbl_customerDetailnyo where id=@id ", parm);
        }
        public int pakageUpdate(String id, string pakageName, string startingdate, int noofdays)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@id",id),
                new SqlParameter("@pakageName",pakageName),
                new SqlParameter("@startingdate",startingdate),
                new SqlParameter("@noofdays",noofdays),
                new SqlParameter("@status","ON")
            };
            return DAL.IDU("update tbl_customerDetailnyo set pakage_name=@pakageName, startingDate=@startingdate,noofdays=@noofdays, status=@status where id=@id", parm);


        }
        public DataTable getnamebyno(string card_no)
        {
            SqlParameter[] parm = new SqlParameter[]
             {
            new SqlParameter ("@card_no", card_no)
             };
            DataTable dt = new DataTable();
            dt = DAL.getuser("select * from tbl_customerDetailnyo where card_no=@card_no", parm);
            return dt;
        }
        public DataTable GetAddbalance()
        {
        
            DataTable dt = new DataTable();
            dt = DAL.getuser("select * from tbl_add_customer_balance", null);
            return dt;
        }
        public DataTable getcustomerbalance(int customer_id)
        {
            SqlParameter[] parm = new SqlParameter[]
             {
            new SqlParameter ("@customer_id", customer_id)
             };
            DataTable dt = new DataTable();
            dt = DAL.getuser("select * from tbl_customer_card_info where customer_id=@customer_id", parm);
            return dt;
        }

        public DataTable updateCustomerAfterCancelled(string id)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@id",id),

            };
            return DAL.getuser("update tbl_customerDetailnyo set pakage_name='Choose Package' where id=@id ", parm);
        }
        public int UpdateCardBalance(int id,decimal customer_balance)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@id",id),
                 new SqlParameter("@customer_balance",customer_balance),
            };
            return DAL.IDU("update tbl_customer_card_info set customer_balance=customer_balance+@customer_balance where customer_id=@id ", parm);
        }
        public DataTable GetCardType()
        {
            return DAL.getuser("select * from tbl_card_type", null);
        }
        public int DeleteCardType(int id)
        {
            SqlParameter[] parm = new SqlParameter[]
          {new SqlParameter("@id",id)

           };
            return DAL.IDU("delete from tbl_card_type where card_type_id=@id", parm);
        }
        public int InsertCardType(string card_type)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@card_type",card_type)
            };
            return DAL.IDU("Insert into tbl_card_type(card_type_name) values(@card_type)", parm);
        }
        public int UpdateCardType(int id, string card_type)
        {
            SqlParameter[] parm = new SqlParameter[]
            {new SqlParameter("@id",id),
                new SqlParameter("@card_type",card_type)
            };
            return DAL.IDU("Update tbl_card_type set card_type_name=@card_type where card_type_id=@id", parm);
        }
        public DataTable SearchCardType(string card_type)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@card_type",card_type)
            };
            return DAL.getuser("select * from tbl_card_type where card_type_name=@card_type", parm);
        }
        public DataTable Searchbycard(string card_no)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@card_no",card_no)
            };
            return DAL.getuser("select * from tbl_customerDetailnyo where card_no = @card_no", parm);
        }
        public DataTable GetPreviousBalance(int customer_id)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@customer_id",customer_id)
            };
            return DAL.getuser("select * from tbl_customer_card_info where customer_id = @customer_id", parm);
        }
        public int Insert_balance(int customer_id, decimal customer_balance, string status, decimal fix_spend_balance, string fix_spend_status, decimal fix_balance, string fix_balance_status)
        {

            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@customer_id",customer_id),
                new SqlParameter("@customer_balance",customer_balance),
                     new SqlParameter("@status",status),
                      new SqlParameter("@fix_spend_balance",fix_spend_balance),
                     new SqlParameter("@fix_spend_status",fix_spend_status),
                      new SqlParameter("@fix_balance",fix_balance),
                        new SqlParameter("@fix_balance_status",fix_balance_status),

            };
            return DAL.IDU("insert into tbl_customer_card_info(customer_id,customer_balance,status,fix_spend_balance,fix_spend_status,fix_balance,fix_balance_status) values (@customer_id,@customer_balance,@status,@fix_spend_balance,@fix_spend_status,@fix_balance,@fix_balance_status)", parm);
        }
        public int Add_balance(int customer_id, decimal customer_balance, string status, decimal fix_spend_balance, string fix_spend_status, decimal fix_balance, string fix_balance_status)
        {

            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@customer_id",customer_id),
                new SqlParameter("@customer_balance",customer_balance),
                     new SqlParameter("@status",status),
                       new SqlParameter("@fix_spend_balance",fix_spend_balance),
                     new SqlParameter("@fix_spend_status",fix_spend_status),
                      new SqlParameter("@fix_balance",fix_balance),
                      new SqlParameter("@fix_balance_status",fix_balance_status),

            };
            return DAL.IDU("Update tbl_customer_card_info set status=@status, customer_balance=@customer_balance+customer_balance,fix_spend_balance=@fix_spend_balance,fix_spend_status=@fix_spend_status,fix_balance=@fix_balance,fix_balance_status=@fix_balance_status where customer_id=@customer_id", parm);
        }
        public int DeleteCustomer(int customer_id)
        {
            SqlParameter[] parm = new SqlParameter[]
          {new SqlParameter("@customer_id",customer_id)

           };
            return DAL.IDU("delete from tbl_customer_card_info where customer_id=@customer_id", parm);
        }
        public DataTable CardSales(string customer_no, DateTime cash_back_date)
        {
            SqlParameter[] parm = new SqlParameter[]
          {
              new SqlParameter("@customer_no",customer_no),
              new SqlParameter("@cash_back_date",cash_back_date)

           };
            return DAL.getuser("select distinct bill_no,grand_total from tbl_sales_record where customer_no=@customer_no and x_report='X' and payment_mode='Club Card' and CAST(date_of_sale as datetime) > CAST(@cash_back_date as datetime)", parm);
        }
        public DataTable CardSales(string customer_no)
        {
            SqlParameter[] parm = new SqlParameter[]
          {
              new SqlParameter("@customer_no",customer_no),


           };
            return DAL.getuser("select distinct bill_no,grand_total from tbl_sales_record where customer_no=@customer_no and x_report='X' and payment_mode='Club Card'", parm);
        }
        public DataTable getid(int customer_id)
        {
            SqlParameter[] parm = new SqlParameter[]
          {
              new SqlParameter("@customer_id",customer_id)
            
           };
            return DAL.getuser("select * from tbl_cash_back where customer_id=@customer_id  and status='Full' order by cashback_id desc ", parm);
        }
   
        public DataTable Getfixbalance(int customer_id)
        {
            SqlParameter[] parm = new SqlParameter[]
          {new SqlParameter("@customer_id",customer_id)

           };
            return DAL.getuser("select * from tbl_customer_card_info where customer_id=@customer_id", parm);
        }
        public int updateNonRefundable()
        {
            return DAL.IDU("update tbl_customer_card_info set fix_spend_status='Inactive', fix_spend_balance='0.00' where fix_spend_status='Active'",null);
        }
        public DataTable getAllNonfedundableUser()
        {
            return DAL.getuser("select * from tbl_customer_card_info where fix_spend_status='Active'", null);
        }
        public DataTable getAllsalesById(int customer_id)
        {
            SqlParameter[] parm = new SqlParameter[]
           {
               new SqlParameter("@customer_id",customer_id)

            };
            return DAL.getuser("select distinct bill_no,grand_total from tbl_sales_record  s join  tbl_customerDetailnyo c on (s.customer_no=c.card_no) where c.id=@customer_id and x_report = 'X' and payment_mode = 'Club Card'", parm);
        }
        public int totalCardBalanceUnspendLess(int customer_id,decimal total_balance)
        {
            SqlParameter[] parm = new SqlParameter[]
           {
               new SqlParameter("@customer_id",customer_id),
                new SqlParameter("@total_balance",total_balance),

            };
            return DAL.IDU("update tbl_customer_card_info set customer_balance=@total_balance,fix_spend_status='Inactive', fix_spend_balance='0.00' where customer_id=@customer_id", parm);
        }
        public DataTable SearchSales(string customer_no, DateTime from, DateTime to)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
             new SqlParameter("@customer_no",customer_no),
              new SqlParameter("@from",from),
                new SqlParameter("@to",to)
            };
            return DAL.getuser("select distinct bill_no,grand_total,date2 from tbl_sales_record where customer_no= @customer_no and  date2 between @from and @to ", parm);
        }
        public DataTable SearchAddBalance(int customer_id, DateTime from, DateTime to)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
             new SqlParameter("@customer_id",customer_id),
              new SqlParameter("@from",from),
                new SqlParameter("@to",to)
            };
            return DAL.getuser("select * from tbl_add_balance_log where customer_id= @customer_id and  date between @from and @to ", parm);
        }
        public DataTable SearchCashBack(int customer_id, DateTime from, DateTime to)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
             new SqlParameter("@customer_id",customer_id),
              new SqlParameter("@from",from),
                new SqlParameter("@to",to)
            };
            return DAL.getuser("select * from tbl_cash_back where customer_id= @customer_id and  date between @from and @to ", parm);
        }
        public DataTable GetCustomerid(string card_no)
        {
            SqlParameter[] parm = new SqlParameter[]
             {
            new SqlParameter ("@card_no", card_no)

             };
            DataTable dt = new DataTable();
            dt = DAL.getuser("select * from tbl_customerDetailnyo where card_no=@card_no", parm);
            return dt;
        }
        public DataTable GetItems(string customer_no)
        {
            SqlParameter[] parm = new SqlParameter[]
             {
            new SqlParameter ("@customer_no", customer_no)

             };
            DataTable dt = new DataTable();
            dt = DAL.getuser("select * from tbl_sales_record where customer_no=@customer_no ", parm);
            return dt;
        }
        public DataTable GetCashBack(int customer_id)
        {
            SqlParameter[] parm = new SqlParameter[]
               {
            new SqlParameter ("@customer_id", customer_id)
               };

            DataTable dt = new DataTable();
            dt = DAL.getuser("select * from tbl_cash_back where customer_id=@customer_id", parm);
            return dt;
        }
        public DataTable GetAddbalance(int customer_id)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
            new SqlParameter ("@customer_id", customer_id)
                };
            DataTable dt = new DataTable();
            dt = DAL.getuser("select * from tbl_add_balance_log where customer_id=@customer_id", parm);
            return dt;
        }
        public DataTable GetAdvancePay(string table_no)
        {

            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@table_no",table_no),

            };
            return DAL.getuser("select * from tbl_quotation where table_no=@table_no", parm);
        }
        public DataTable GetHairCounsulation(int customer_id, string remarks)
        {

            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@customer_id",customer_id),
                 new SqlParameter("@remarks",remarks)
            };
            return DAL.getuser("select * from tbl_consulation where customer_id = @customer_id and remarks=@remarks", parm);
        }
        public DataTable GetCusotmerConsulation(int customer_id)
        {

            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@customer_id",customer_id),

            };
            return DAL.getuser("select * from tbl_consulation where customer_id = @customer_id", parm);
        }
        public DataTable GetConsulation()
        {

            return DAL.getuser("select distinct(remarks) from tbl_consulation", null);
        }
        public int Insert_hair_Consulation(int customer_id, string location, string file_name, string remarks)
        {

            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@customer_id",customer_id),
                    new SqlParameter("@Location",location),
                     new SqlParameter("@file_name",file_name),
                     new SqlParameter("@remarks",remarks),

            };
            return DAL.IDU("insert into tbl_consulation(customer_id,file_location,filename,remarks) values (@customer_id,@location,@file_name,@remarks)", parm);
        }
        public DataTable GetCusotmerPhone(string numbers)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@numbers",numbers),

            };
            return DAL.getuser("select * from tbl_customerDetailnyo where phone like @numbers +'%' or phone2 like @numbers  +'%' ", parm);
        }
        public int insertHomeDeliveryCustomer(string customer_id, string kot_id)
        {
            SqlParameter[] parm = new SqlParameter[]
           {
                new SqlParameter("@kot_id",kot_id),
                    new SqlParameter("@customer_id",customer_id)
           };
            return DAL.IDU("insert into tbl_homedeliveryCustomer (kot_id,customer_id) values (@kot_id,@customer_id)", parm);
           
       }
        public DataTable getallBykotid(string kot_id)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@kot_id",kot_id)

            };
            return DAL.getuser("select c.id, kot_id, name, lastname, phone, address from tbl_homedeliveryCustomer h left join tbl_customerDetailnyo c on (h.customer_id = c.id) where kot_id = @kot_id", parm);
        }
        public DataTable getDeliveryByitsusername_phone(int customer_id)
        {

            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@customer_id",customer_id),

            };
            return DAL.getuser("select * from tbl_homedeliveryCustomer where customer_id =@customer_id", parm);
        }
        public DataTable GetallcustomerbyId(string id)
        {

            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@id",id),

            };
            return DAL.getuser("select * from tbl_customerDetailnyo where id=@id", parm);
        }
        public DataTable getallcustomersettlement()
        {
            return DAL.getuser("select id,name+' '+lastname as name from tbl_customerDetailnyo where id in (select customer_id from tbl_customer_settlements)", null);
        }
        public DataTable GetCustomerInsertedId()
        {

            return DAL.getuser("select id from tbl_customerDetailnyo order by id desc;", null);
        }
        public DataTable GetCustomerwithcardno()
        {

            return DAL.getuser("select * from tbl_customerDetailnyo where card_no!=''", null);
        }
    }
}
