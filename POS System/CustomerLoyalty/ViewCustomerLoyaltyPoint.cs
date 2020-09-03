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

namespace POS_System.CustomerLoyalty
{
    public partial class ViewCustomerLoyaltyPoint : UserControl
    {
        public ViewCustomerLoyaltyPoint()
        {
            InitializeComponent();
            txt_search.ForeColor = SystemColors.GrayText;
        }
        BLLLoyalty blty = new BLLLoyalty();


        private void ViewCustomerLoyaltyPoint_Load(object sender, EventArgs e)
        {
            DataTable dt = blty.getAllCustomerPoints();
            DatagridViewLoad(dt);

        }
        public void DatagridViewLoad(DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                dataGridView1.Rows.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int u = dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells["cal_phone"].Value = dt.Rows[i]["phone"];
                    dataGridView1.Rows[i].Cells["cal_card_no"].Value = dt.Rows[i]["card_no"];
                    dataGridView1.Rows[i].Cells["cal_customer_id"].Value = dt.Rows[i]["customer_id"];
                    dataGridView1.Rows[i].Cells["cal_customer_point"].Value = dt.Rows[i]["customer_point"];
                    dataGridView1.Rows[i].Cells["cal_customer_name"].Value = dt.Rows[i]["customer_name"].ToString();


                }
            }
        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            if (txt_search.Text.Length > 0 && txt_search.Text != "Search")
            {
                DataTable dt = blty.getAllCustomerPointsByName(txt_search.Text);
                DatagridViewLoad(dt);
            }
            else
            {
                DataTable dt = blty.getAllCustomerPoints();
                DatagridViewLoad(dt);
            }

        }

        private void txt_search_Leave(object sender, EventArgs e)
        {
            
             if (txt_search.Text == "")
             {
                txt_search.ForeColor = SystemColors.GrayText;
                txt_search.Text = "Search";
                DataTable dt = blty.getAllCustomerPoints();
                DatagridViewLoad(dt);
            }
            
        }

        private void txt_search_Enter(object sender, EventArgs e)
        {
            if (txt_search.Text == "Search")
            {
                txt_search.Text = "";
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == dataGridView1.Columns["cal_view"].Index && e.RowIndex >= 0))
            {

            }
        }
    }
    }
