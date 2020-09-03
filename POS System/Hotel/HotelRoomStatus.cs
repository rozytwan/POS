using BLLS.BLLHotel;
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
    public partial class HotelRoomStatus : Form
    {
        public HotelRoomStatus()
        {
            InitializeComponent();
        }
        BLL_HotelCategory blhc = new BLL_HotelCategory();
        int room_id;
        private void HotelRoomStatus_Load(object sender, EventArgs e)
        {
            room_id = Convert.ToInt32(HotelStatusUpdate.room_id);
        }
        private void btn_messy_Click(object sender, EventArgs e)
        {
            setStatus(btn_messy.Text);
          
        }
      
        public void setStatus(string status)
        {
            int updateStatus = blhc.UpdateRoomstatusById(room_id,status);
            this.Hide();
        }

        private void btn_cleaning_Click(object sender, EventArgs e)
        {
            setStatus(btn_cleaning.Text);
        }

        private void btn_check_in_Click(object sender, EventArgs e)
        {
            setStatus(btn_check_in.Text);
        }

        private void btn_room_block_Click(object sender, EventArgs e)
        {
            setStatus(btn_room_block.Text);
        }

        private void btn_out_of_service_Click(object sender, EventArgs e)
        {
            setStatus(btn_out_of_service.Text);
        }

        
    }
}
