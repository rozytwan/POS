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
   public class BLLTable
    {
         
        public DataTable getalltable()
        {
            return DAL.getuser("select rest_table_no,rest_table_name from tbl_rest_table_info", null);
        }
        public DataTable getallhomedelevery()
        {
            return DAL.getuser("select * from tbl_home_delivery_nos", null);
        }
        public DataTable gettableno_max()
        {
            DataTable dt = new DataTable();
            dt = DAL.getuser("select max(rest_table_no) from tbl_rest_table", null);
            return dt;
        }
      

        public int insertintotable(int rest_table_no)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@rest_table_no",rest_table_no)
                };
            return DAL.IDU("insert into tbl_rest_table values(@rest_table_no)", parm);
        }
        public int insertintotable_info(int rest_table_no,string rest_table_name, decimal position_X, decimal position_Y, string image_name, int area_id)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@rest_table_no",rest_table_no),
                     new SqlParameter("@rest_table_name",rest_table_name),
                    new SqlParameter("@position_X",position_X),
                    new SqlParameter("@position_Y",position_Y),
                     new SqlParameter("@image_name",image_name),
                     new SqlParameter("@area_id",area_id)

  };
            return DAL.IDU("insert into tbl_rest_table_info (rest_table_no,rest_table_name,position_X,position_Y,image_name,area_id) values(@rest_table_no,@rest_table_name,@position_X,@position_Y,@image_name,@area_id)", parm);
        }
        public int update_table_location(int table_no, int position_X, int position_Y)
        {
            SqlParameter[] parm = new SqlParameter[]
               {
                    new SqlParameter("@table_no",table_no),
                  
                     new SqlParameter("@position_X",position_X),
                      new SqlParameter("@position_Y",position_Y)

               };
            return DAL.IDU("update tbl_rest_table_info set position_X=@position_X,position_Y=@position_Y where rest_table_no=@table_no", parm);
        }
        public DataTable chheck_table_info(string table_no)
        {
            SqlParameter[] parm = new SqlParameter[]
              {
                    new SqlParameter("@table_no",table_no)
              };
            return DAL.getuser("select * from tbl_rest_table_info where rest_table_no=@table_no", parm);
        }
        public DataTable chheck_rest_table(int table_no)
        {
            SqlParameter[] parm = new SqlParameter[]
              {
                    new SqlParameter("@table_no",table_no)
              };
            return DAL.getuser("select * from tbl_rest_table where rest_table_no=@table_no", parm);
        }
        public DataTable get_all_rest_table_info(int area_id)
        {
            SqlParameter[] parm = new SqlParameter[]
              {
                    new SqlParameter("@area_id",area_id)
              };
            return DAL.getuser("select * from tbl_rest_table_info where area_id=@area_id", parm);
        }
       
        public int delete_table(int rest_table_no)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@rest_table_no",rest_table_no)
                };
            return DAL.IDU("delete tbl_rest_table where rest_table_no=@rest_table_no", parm);
        }
        public int delete_table_info(int rest_table_no)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@rest_table_no",rest_table_no)
                };
            return DAL.IDU("delete tbl_rest_table_info where rest_table_no=@rest_table_no", parm);
        }
        public int delete_takeaway(int take_away_id)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@take_away_id",take_away_id)
                };
            return DAL.IDU("delete tbl_take_away where take_away_id=@take_away_id", parm);
        }
        public int tabletransfer(decimal table_no, decimal new_table_no)
        {
            SqlParameter[] parm = new SqlParameter[]
               {
                    new SqlParameter("@table_no",table_no),
                     new SqlParameter("@new_table_no",new_table_no)

               };
            return DAL.IDU("update tbl_orders set table_no=@new_table_no where table_no=@table_no", parm);
        }
        public DataTable checktransfer(decimal table_no)
        {
            SqlParameter[] parm = new SqlParameter[]
              {
                    new SqlParameter("@table_no",table_no)
              };
            return DAL.getuser("select * from tbl_orders where table_no=@table_no", parm);
        }
        public int Edit_table(int rest_table_no,string rest_table_name)
        {
            SqlParameter[] parm = new SqlParameter[]
                {

                new SqlParameter("@rest_table_no",rest_table_no),
                new SqlParameter("@rest_table_name",rest_table_name)

            };
                 
            return DAL.IDU("update tbl_rest_table_info set rest_table_name=@rest_table_name where rest_table_no=@rest_table_no", parm);
        }
        public DataTable Get_Data_ByAreaId(int area_id)
        { SqlParameter[] parm = new SqlParameter[]
                {
            new SqlParameter("@area_id",area_id)
         };
            return DAL.getuser("select * from tbl_table_area where area_id=@area_id", parm);
        }

        public int updateTableTransfer(string table_from,string table_to,string item_name,decimal qty,int order_id)        
        {
            SqlParameter[] parm = new SqlParameter[]
                {

                     new SqlParameter("@table_from",table_from),
                      new SqlParameter("@table_to",table_to),
                       new SqlParameter("@item_name",item_name),
                       new SqlParameter("@qty",qty),
                        new SqlParameter("@order_id",order_id)

                };
            return DAL.IUD_SP("sp_table_transfer", CommandType.StoredProcedure, parm);
        }
        public DataTable getallroom()
        {
            return DAL.getuser("select room_no from hotel_room_details", null);
        }
        public int delete_table_order(int table_no)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@table_no",table_no)
                };
            return DAL.IDU("delete tbl_orders where table_no=@table_no", parm);
        }
        public int Updatetransfer(string table_no, string new_table_no)
        {
            SqlParameter[] parm = new SqlParameter[]
               {
                    new SqlParameter("@table_no",table_no),
                     new SqlParameter("@new_table_no",new_table_no)

               };
            return DAL.IDU("update tbl_advance_discount set table_no=@new_table_no where table_no=@table_no", parm);
        }
    }
}
