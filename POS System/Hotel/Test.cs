using BLLS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_System
{
    public partial class Test : Form
    {
        public Test()
        {
            InitializeComponent();
        }
        BLL_hotel_order order = new BLL_hotel_order();
        private void Test_Load(object sender, EventArgs e)
        {
            datagridviewload();
        }
        public void datagridviewload()
        {
            
            DataTable dt = order.GetRoomOrder(lbl_room.Text);
       
            if (dt.Rows.Count > 0)
            {
                dataGridView1.Rows.Clear();
                for (int z = 0; z < dt.Rows.Count; z++)
                {
                    int abc = dataGridView1.Rows.Add();
                    dataGridView1.Rows[z].Cells["cal_order_id"].Value = dt.Rows[z]["hotel_order_id"].ToString();
                    dataGridView1.Rows[z].Cells["cal_item_name"].Value = dt.Rows[z]["item"].ToString();
                    dataGridView1.Rows[z].Cells["cal_qty"].Value = dt.Rows[z]["quantity"].ToString();
                    dataGridView1.Rows[z].Cells["cal_total"].Value = dt.Rows[z]["total"].ToString();
                    dataGridView1.Rows[z].Cells["cal_cost"].Value = dt.Rows[z]["cost"].ToString();
                    dataGridView1.Rows[z].Cells["cal_category_name"].Value = dt.Rows[z]["category_name"].ToString();
                    dataGridView1.Rows[z].Cells["cal_kot_type"].Value = dt.Rows[z]["kot_print"].ToString();
                    dataGridView1.Rows[z].Cells["cal_sales_type"].Value = dt.Rows[z]["customer_name"].ToString();//database column username is use for sales type 
                }
         
            }
        
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {

        }
    }
}
