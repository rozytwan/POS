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
    public partial class UserDiscount : UserControl
    {
        public UserDiscount()
        {
            InitializeComponent();
        }

   BLLUserLevelDiscount blluser = new BLLUserLevelDiscount();
  blllCustomerDetailednyo custor = new blllCustomerDetailednyo();
  private void UserDiscount_Load(object sender, EventArgs e)
        {
            LoadUser();
            Combocardtype();
        }
        public void Combocardtype()
        {
            DataTable dt = custor.GetCardType();
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.NewRow();
                dr["card_type_name"] = "Choose Type";
                dt.Rows.InsertAt(dr, 0);
                cmb_card_type.DataSource = dt;
                cmb_card_type.DisplayMember = "card_type_name";
                cmb_card_type.ValueMember = "card_type_id";
            }
        }
        public void LoadUser()
        {
            DataTable dt = blluser.GetUser();
            if (dt.Rows.Count>0)
            {
                dataGridView1.Rows.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells["col_user_id"].Value = dt.Rows[i]["user_dis_id"].ToString();

                    dataGridView1.Rows[i].Cells["col_card_type"].Value = dt.Rows[i]["card_type"].ToString();
                    dataGridView1.Rows[i].Cells["col_dis_from"].Value = dt.Rows[i]["dis_from"].ToString();
                    dataGridView1.Rows[i].Cells["col_dis_to"].Value = dt.Rows[i]["dis_to"].ToString();
                    dataGridView1.Rows[i].Cells["col_dis_percent"].Value = dt.Rows[i]["discount_percent"].ToString();

                }
            }
               
        }

        private void btn_back_Click(object sender, EventArgs e)
        {

        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (txt_discount_from.Text == "" && txt_discount_to.Text == "" && txt_discount_percent.Text == "")
            {
                MessageBox.Show("Please fill the required fields");
            }
            
            else
            {
                int insert = blluser.insert_user_discount(cmb_card_type.Text, Convert.ToDecimal(txt_discount_from.Text), Convert.ToDecimal(txt_discount_to.Text), txt_discount_percent.Text);
                if (insert > 0)
                {
                    MessageBox.Show("Inserted Successfully", "Successfull !!");
                }

                LoadUser();
                clear();
            }
        }
        int user_id;
        private void btn_edit_Click(object sender, EventArgs e)
        {
            btn_save.Enabled = false;
            btn_update.Enabled = true;
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["col_user_id"].Value);

            DataTable dt = blluser.Getuserbyid(id);
            if (dt.Rows.Count > 0)
            {
                cmb_card_type.Text = dt.Rows[0]["card_type"].ToString();
                txt_discount_from.Text = dt.Rows[0]["dis_from"].ToString();
                txt_discount_to.Text = dt.Rows[0]["dis_to"].ToString();
                txt_discount_percent.Text = dt.Rows[0]["discount_percent"].ToString();
                user_id =Convert.ToInt32( dt.Rows[0]["user_dis_id"].ToString());

            }

            }

        private void btn_update_Click(object sender, EventArgs e)
        {
            if (txt_discount_from.Text == "" && txt_discount_to.Text == "" && txt_discount_percent.Text == "")
            {
                MessageBox.Show("Please fill the required fields");
            }
            else
            {
                int update = blluser.Update_user_discount(cmb_card_type.Text, Convert.ToDecimal(txt_discount_from.Text), Convert.ToDecimal(txt_discount_to.Text), txt_discount_percent.Text, user_id);
                if (update > 0)
                {
                    MessageBox.Show("Updated Successfully");

                }
                LoadUser();
                clear();
            }
        }
        public void clear()
        {
            cmb_card_type.Text = "Choose Type";
            txt_discount_from.Text = "";
            txt_discount_to.Text = "";
            txt_discount_percent.Text = "";

        }

    }
}
