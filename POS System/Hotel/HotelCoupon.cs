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
    public partial class HotelCoupon : UserControl
    {
        public HotelCoupon()
        {
            InitializeComponent();
        }
        BLL_HotelDetails details = new BLL_HotelDetails();
        private void HotelCoupon_Load(object sender, EventArgs e)
        {
            LoadCoupon();
        }
        int coupon_id;
        public void LoadCoupon()
        {
            DataTable dt = details.GetCouponList();
            if (dt.Rows.Count>0)
            {
                dataGridView1.Rows.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dataGridView1.Rows.Add();
                     coupon_id=Convert.ToInt32(dt.Rows[i]["coupon_id"].ToString());
                    dataGridView1.Rows[i].Cells["col_id"].Value = coupon_id;
                    dataGridView1.Rows[i].Cells["col_coupon_type"].Value = dt.Rows[i]["coupon_type"].ToString();
                    dataGridView1.Rows[i].Cells["col_coupon_offer"].Value = dt.Rows[i]["coupon_offer"].ToString();
                 }
            }
        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            int insert_coupon = details.Insert_Coupon(txt_type.Text, Convert.ToInt32(txt_offer.Text));
            if (insert_coupon>0)
            {
                MessageBox.Show("Successfully Inserted", "Success Alert !!");
                LoadCoupon();
                clear();
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count>0)
            {
                DataTable dt = details.GetCouponByid(coupon_id);
                if (dt.Rows.Count>0)
                {
                    txt_type.Text = dt.Rows[0]["coupon_type"].ToString();
                    txt_offer.Text = dt.Rows[0]["coupon_offer"].ToString();
                }
            
            }
            else
            {
                MessageBox.Show("Plese select Row First", "Get Row Alert !!");
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            int update_coupon = details.Update_Coupon(coupon_id,txt_type.Text, Convert.ToInt32(txt_offer.Text));
            if (update_coupon > 0)
            {
                MessageBox.Show("Successfully Updated", "Success Alert !!");
                LoadCoupon();
                clear();
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count>0)
            {
                int delete_coupon = details.Delete_Coupon(coupon_id);
                if (delete_coupon > 0)
                {
                    MessageBox.Show("Successfully Deleted", "Success Alert !!");
                    LoadCoupon();
                    clear();
                }
  }
            else
            {
                MessageBox.Show("Plese select Row First", "Get Row Alert !!");
            }
       
        }
        public void clear()
        {
            txt_offer.Text = "";
            txt_type.Text = "";        }
    }
}
