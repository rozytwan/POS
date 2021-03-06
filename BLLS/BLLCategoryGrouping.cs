﻿using DOA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLS
{
   public class BLLCategoryGrouping
    {
        public int insertCategoryGrouping(string group_name,string button_colour)
        {
            SqlParameter[] parm = new SqlParameter[] 
            {
                new SqlParameter("@group_name",group_name),
                new SqlParameter("@button_colour",button_colour)
            };
            return DAL.IDU("insert into tbl_item_category_grouping (group_name,button_colour) values (@group_name,@button_colour)", parm);
        }
        public int updateCategoryGrouping(int id, string group_name, string button_colour)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@group_name",group_name),
                new SqlParameter("@button_colour",button_colour),
                new SqlParameter("@id",id)
            };
            return DAL.IDU("update tbl_item_category_grouping set group_name=@group_name,button_colour=@button_colour where id=@id", parm);
        }
        public DataTable getallItemcategoryGrouping()
        {
            DataTable dt = new DataTable();
            return DAL.getuser("select * from tbl_item_category_grouping", null);

        }
        public DataTable getallitemcategoryGrouping(int id)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@id",id)
                };
            return DAL.getuser("select * from tbl_item_category_grouping where id=@id", parm);
        }
        public DataTable getallFromView(DateTime DateFrom,DateTime DateTo,string group_name)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@DateFrom",DateFrom),
                    new SqlParameter("@DateTo",DateTo),
                    new SqlParameter("@group_name",group_name)
                };
            return DAL.getuser("select * from ViewCategoryGrouping(@DateFrom,@DateTo,@group_name) order by bill_no", parm);
        }
    }
}
