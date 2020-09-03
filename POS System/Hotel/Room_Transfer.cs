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

namespace POS_System.Hotel
{
    public partial class Room_Transfer : Form
    {
        public Room_Transfer()
        {
            InitializeComponent();
        }
        BLLTable blta = new BLLTable();
        BLLOrder blo = new BLLOrder();
        BLL_hotel_order bllho = new BLL_hotel_order();
        BLLHotelRoom blroom = new BLLHotelRoom();
        public void from()
        {
            DataTable dt = blta.getallroom();
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.NewRow();
                dr["room_no"] = "Choose Room";
                dt.Rows.InsertAt(dr, 0);
                txtfrom.DataSource = dt;
                txtfrom.DisplayMember = "room_no";
                txtfrom.ValueMember = "room_no";

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
        private void Room_Transfer_Load(object sender, EventArgs e)
        {

            TO();
            from();
            txtfrom.SelectedIndex = 0;
            txtto.SelectedIndex = 0;
        }
        string room_no_to;
        string room_id_to;
        private void btn_transfer_Click(object sender, EventArgs e)
        {
            if (txtto.Text == "Choose Room" || txtfrom.Text == "Choose Table")
            {
                MessageBox.Show("First Choose Room Alert !!", "Room Alert !!");
            }
            else
            {
                DataTable dtm = blroom.GetRoomId(txtfrom.Text);
                 string room_id_from = (dtm.Rows[0]["room_id"].ToString());
             
                DataTable dth = blroom.GetDates(Convert.ToInt32(room_id_from));
                if (dth.Rows.Count > 0)
                        {
                            DialogResult dialogResult = MessageBox.Show("Do You Like To Transfer From " + txtfrom.SelectedValue + " To " + txtto.Text, "Room Tarnsfer", MessageBoxButtons.YesNoCancel);
                            if (dialogResult == DialogResult.Yes)
                            {

                                int customer_id = Convert.ToInt32(dth.Rows[0]["customer_id"].ToString());
                        DataTable dtt = blroom.GetRoomId(txtto.Text);
                        if (dtt.Rows.Count > 0)
                        {
                            room_no_to = (dtt.Rows[0]["room_no"].ToString());
                            room_id_to = (dtt.Rows[0]["room_id"].ToString());
                        }
                        int updateTableTransfer = bllho.updateroom(Convert.ToInt32(room_id_to), Convert.ToInt32(room_id_from));
                        int updateorder = bllho.updateroomorder(room_id_to, Convert.ToInt32(room_id_from));

                        // int tableTranser = blta.delete_table_order(Convert.ToInt32(txtfrom.SelectedValue));
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
             
            }

        }


    