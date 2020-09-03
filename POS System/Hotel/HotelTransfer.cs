using BLLS;
using BLLS.Hotel;
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
    public partial class HotelTransfer : Form
    {
        public HotelTransfer()
        {
            InitializeComponent();
        }
        public string tableno;
        BLLTable blta = new BLLTable();
        BLLOrder blo = new BLLOrder();
        BLL_hotel_order bllho = new BLL_hotel_order();
        BLLHotelRoom blroom = new BLLHotelRoom();
        private void HotelTransfer_Load(object sender, EventArgs e)
        {
            TO();
            from();
            txtfrom.SelectedIndex = 0;
            txtto.SelectedIndex = 0;
        }
        public void from()
        {
            DataTable dt = blta.getalltable();
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.NewRow();
                dr["rest_table_name"] = "Choose Table";
                dt.Rows.InsertAt(dr, 0);
                txtfrom.DataSource = dt;
                txtfrom.DisplayMember = "rest_table_name";
                txtfrom.ValueMember = "rest_table_no";
            }
        }
        public void TO()
        {
            DataTable dt = blta.getallroom();
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.NewRow();
                dr["room_no"] = "Choose Room";
                dt.Rows.InsertAt(dr, 0);
                txtto.DataSource = dt;
                txtto.DisplayMember = "room_no";
                txtto.ValueMember = "room_no";

            }
        }
        DateTime todaydate = DateTime.Now;
        private void btn_transfer_Click(object sender, EventArgs e)
        {
            if (txtto.Text == "Choose Room" || txtfrom.Text=="Choose Table")
            {
                MessageBox.Show("First Choose Room Alert !!", "Room Alert !!");
            }
            else
            { 
                DataTable dt = blta.checktransfer(Convert.ToDecimal(txtfrom.SelectedValue));
                if (dt.Rows.Count > 0)
                {
                    DataTable dtm = blroom.GetRoomId(txtto.Text);
                   // DataTable dtm = blo.getallfromtblorder(Convert.ToDecimal(txtto.SelectedValue));
                            if (dtm.Rows.Count > 0)
                                {
                                    string room_id = (dtm.Rows[0]["room_id"].ToString());
                                    DataTable dth = blroom.GetDates(Convert.ToInt32(room_id));
                                if (dth.Rows.Count > 0)
                                {
                                    DialogResult dialogResult = MessageBox.Show("Do You Like To Transfer From " + txtfrom.SelectedValue + " To " + txtto.Text, "Table Tarnsfer", MessageBoxButtons.YesNoCancel);
                                    if (dialogResult == DialogResult.Yes)
                                    {
                                        int customer_id = Convert.ToInt32(dth.Rows[0]["customer_id"].ToString());

                                        for (int i = 0; i < dt.Rows.Count; i++)
                                        {
                                            int updateTableTransfer = bllho.Insert_Hotel_Order(Login.sendtext, room_id, dt.Rows[i]["item"].ToString(), Convert.ToInt32(dt.Rows[i]["quantity"]), Convert.ToDecimal(dt.Rows[i]["total"]), Convert.ToDecimal(dt.Rows[i]["cost"]), "H", dt.Rows[i]["category_name"].ToString(), dt.Rows[i]["kot_print"].ToString(), "HR", customer_id, todaydate);
                                        }

                                        int tableTranser = blta.delete_table_order(Convert.ToInt32(txtfrom.SelectedValue));
                                        MessageBox.Show("Successfully Transfered Alert !!", "Success Alert!!");

                                    }
                                    this.Close();
                                }
                                else
                                {
                                    MessageBox.Show("No Guest In This Room !!", "Room Is Empty Alert!!");

                                }

                                }
                            }
                else
                {
                    MessageBox.Show("No Orders In this Table !!", "Table Is Empty Alert!!");
                }
                  }
                       
                    }
                }
                //else
                //{
                //    MessageBox.Show("No Guest In This Room !!", "Room Is Empty Alert!!");
                //}
            }
        
    

