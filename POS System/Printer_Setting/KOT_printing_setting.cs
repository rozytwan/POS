using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLLS;


namespace POS_System
{
    public partial class KOT_printing_setting : UserControl
    {
        public KOT_printing_setting()
        {
            InitializeComponent();
        }

        BLLkot_kitchen blkits = new BLLkot_kitchen();
        BLLUser blu = new BLLUser();
        int kot_kitchen_id = 1;
        public string getdata(string colname)
        {
            string neededvalue="null";
            DataTable dt = blu.checkbusiness();
            if (dt.Rows.Count > 0)
            {
                neededvalue = dt.Rows[0][colname].ToString();
           
            }
            return neededvalue;
           
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            swh_business_name.Value = true;
            swh_address.Value = true;
            swh_time.Value = true;
            swh_take_away.Value = true;
            swh_header.Value = true;
            swh_items.Value = true;
            swh_discription.Value = true;

            DataTable dtk = blps.getallPrintingTimes();
            if (dtk.Rows.Count > 0)
            {
                cbo_k1.Text = dtk.Rows[0]["K1"].ToString();
                cbo_k2.Text = dtk.Rows[0]["K2"].ToString();
                cbo_BOT.Text = dtk.Rows[0]["BOT"].ToString();
            }


            DataTable dt = blkits.getall_kot_data();
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["business_name"].ToString() == "False")
                {
                    //business_name = dt.Rows[0]["business_name"].ToString();
                    swh_business_name.Value = false;
                    pnl_business_name.Hide();
                }
                if (dt.Rows[0]["address"].ToString() == "False")
                {
                    //address = dt.Rows[0]["address"].ToString();
                    swh_address.Value = false;
                    pnl_address.Hide();
                }
                if (dt.Rows[0]["time"].ToString() == "False")
                {
                    //time = dt.Rows[0]["time"].ToString();
                    swh_time.Value = false;
                    pnl_time.Hide();
                }
                if (dt.Rows[0]["take_away"].ToString() == "False")
                {
                    swh_take_away.Value = false;
                    pnl_take_away.Hide();
                }
                if (dt.Rows[0]["header"].ToString() == "False")
                {
                    swh_header.Value = false;
                    pnl_header.Hide();
                }
                if (dt.Rows[0]["items"].ToString() == "False")
                {
                    swh_items.Value = false;
                    pnl_items.Hide();
                }
                if (dt.Rows[0]["discription"].ToString() == "False")
                {
                    swh_discription.Value = false;
                    pnl_discription.Hide();


                   
                }
            }
        }
        string business_name;
        string address;
        string time;
        string take_away;
        string header;
        string items;
        string discription;

        private void swh_store_name_ValueChanged(object sender, EventArgs e)
        {
            if (swh_business_name.Value == true)
            {
                pnl_business_name.Show();
                business_name = "True";
               // lbl_business_name.Text = getdata("business_name");
            }

            else
            {
                pnl_business_name.Hide();
                business_name = "False";
               // lbl_business_name.Text = "nothing";
            }

        }


        private void swh_address_ValueChanged(object sender, EventArgs e)
        {
            if (swh_address.Value == true)
            {
                pnl_address.Show();
                address = "True";
               // lbl_address.Text = getdata("address");

            }

            else
            {
                pnl_address.Hide();
                address = "False";
            }
        }

        private void swh_time_ValueChanged_1(object sender, EventArgs e)
        {
            if (swh_time.Value == true)
            {
                pnl_time.Show();
                time = "True";
            }
            else
            {
                pnl_time.Hide();
                time = "False";
            }
        }

        private void swh_take_away_ValueChanged(object sender, EventArgs e)
        {
            if (swh_take_away.Value == true)
            {
                pnl_take_away.Show();
                take_away = "True";
            }

            else
            {
                pnl_take_away.Hide();
                take_away = "False";
            }
        }

        private void swh_header_ValueChanged_1(object sender, EventArgs e)
        {
            if (swh_header.Value == true)
            {
                pnl_header.Show();
                header = "True";
            }


            else
            {
                pnl_header.Hide();
                header = "False";
            }
        }

        private void swh_items_ValueChanged(object sender, EventArgs e)
        {
            if (swh_items.Value == true)
            {
                pnl_items.Show();
                items = "True";
            }

            else
            {
                pnl_items.Hide();
                items = "False";
            }
        }

        private void swh_discription_ValueChanged(object sender, EventArgs e)
        {
            if (swh_discription.Value == true)
            {
                pnl_discription.Show();
                discription = "True";
            }

            else
            {
                pnl_discription.Hide();
                discription = "False";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = blkits.getall_kot_data();

            if (dt.Rows.Count > 0)
            {
                int x = blkits.update_kot(business_name, address, time, take_away, header, items, discription, kot_kitchen_id);
                if (x > 0)
                {
                    MessageBox.Show("Saved");
                }
            }
        }
        BLLPrinterSetting blps = new BLLPrinterSetting();
        private void btn_printing_times_Click(object sender, EventArgs e)
        {
            DataTable dt = blps.getallPrintingTimes();
            if (dt.Rows.Count > 0)
            {
                int updatePrint = blps.updateprintingTimes(cbo_k1.Text, cbo_k2.Text, cbo_BOT.Text);
                MessageBox.Show("Kitchen Printing Setting Has Been Updated", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                int insertprinting = blps.insertPrintingTimes(cbo_k1.Text, cbo_k2.Text, cbo_BOT.Text);
                MessageBox.Show("Kitchen Printing Setting Has Been Updated", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}