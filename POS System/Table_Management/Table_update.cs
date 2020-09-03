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

namespace POS_System.Table_Management
{
    public partial class Table_update : Form
    {
        public Table_update()
        {
            InitializeComponent();
        }
        BLLTable bltable = new BLLTable();
     
        public string table_no;
   

        private void Edit_Click(object sender, EventArgs e)
        {
            if (txt_tablearea.Text=="" || txt_tablename.Text==""|| txt_tableno.Text==""|| txt_tableno.Text=="0" )
            {
                MessageBox.Show("Please Fill the required fields");
               
            }
            else
            {
                int abc = bltable.Edit_table(Convert.ToInt32(table_no), txt_tablename.Text);
                if (abc > 0)
                {
                    MessageBox.Show("Table Updated successfully");
                    this.Close();
   }
             
            }
        }
        
        private void Table_update_Load(object sender, EventArgs e)
        {
            if(Convert.ToInt32(table_no) > 0)
            {
                DataTable dt = bltable.chheck_table_info(table_no);
                if (dt.Rows.Count > 0) {
                    txt_tablename.Text = dt.Rows[0]["rest_table_name"].ToString();
                    txt_tableno.Text = table_no;
                    int area_id = Convert.ToInt32(dt.Rows[0]["area_id"]);

                    DataTable dt1 = bltable.Get_Data_ByAreaId(area_id);
                    if (dt1.Rows.Count >0)
                    {
                        txt_tablearea.Text = dt1.Rows[0]["area_name"].ToString();
                        }
                  
                }

            }


        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
