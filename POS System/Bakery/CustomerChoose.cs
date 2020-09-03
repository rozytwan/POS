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

namespace POS_System.Bakery
{
    public partial class CustomerChoose : Form
    {
        public CustomerChoose()
        {
            InitializeComponent();
        }

        private void CustomerChoose_Load(object sender, EventArgs e)
        {
            flowLayoutPanel1.AutoScroll = true;
            DataTable dt  = blcd.getallcustomers();
            userLoad(dt);
        }
        blllCustomerDetailednyo blcd = new blllCustomerDetailednyo();
        int i = 0;
        public void userLoad(DataTable dt )
        {
            
            flowLayoutPanel1.Controls.Clear();
            for (int low = 0; low < dt.Rows.Count; low++)
            {
                Button[] newPanelcategory = new Button[99];
                newPanelcategory[low] = new Button();
                newPanelcategory[low].Name = dt.Rows[low]["id"].ToString();
                newPanelcategory[low].Text = dt.Rows[low]["name"].ToString() +" "+ dt.Rows[low]["lastname"].ToString();
                newPanelcategory[low].Location = System.Drawing.Point.Add(new Point(0, 4 + i * 55), new Size(50, 50));
                newPanelcategory[low].Height = 98;
                newPanelcategory[low].Width = 114;
                newPanelcategory[low].AutoSizeMode = AutoSizeMode.GrowAndShrink;
                newPanelcategory[low].FlatStyle = FlatStyle.Flat;
                newPanelcategory[low].Font = new Font("Century Gothic", 10, FontStyle.Bold);
                newPanelcategory[low].ForeColor = Color.White;
                newPanelcategory[low].BackColor = Color.DeepSkyBlue;
                newPanelcategory[low].TextAlign = ContentAlignment.TopCenter;
                newPanelcategory[low].DialogResult = DialogResult.OK;
                flowLayoutPanel1.Controls.Add(newPanelcategory[low]);
                newPanelcategory[low].Click += new EventHandler(panelButtons_Click);
                //lblitem_id.Hide();
            }

        }
       public string customer_id;
        public string customer_name;

        public void panelButtons_Click(object sender, EventArgs e)
        {
            customer_id=((Button)sender).Name;
            customer_name = ((Button)sender).Text;

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txt_name_TextChanged(object sender, EventArgs e)
        {
            if (txt_name.Text.Length > 2)
            {
                DataTable dt = blcd.search_By_Fullname(txt_name.Text);
                if (dt.Rows.Count > 0)
                {
                    userLoad(dt);
                }
            }
            else if (txt_name.Text == "")
            {
                DataTable dt = blcd.getallcustomers();
                userLoad(dt);
            }
        }

        private void txt_phone_TextChanged(object sender, EventArgs e)
        {
            if (txt_phone.Text.Length > 2)
            {
                DataTable dt = blcd.Getcustomerphone(txt_phone.Text);
                if (dt.Rows.Count > 0)
                {
                    userLoad(dt);
                }
            }
        }

        private void btn_add_menu_Click(object sender, EventArgs e)
        {
            if (txt_name.Text != "" && txt_phone.Text != "" && txt_address.Text != "")
            {
                int insertData = blcd.fast_Customer_Create(txt_name.Text,txt_phone.Text,txt_address.Text);
                if(insertData>0)
                {

                    DataTable dt = blcd.search_By_Fullname(txt_name.Text);
                    if (dt.Rows.Count > 0)
                    {
                        userLoad(dt);
                    }
                    txt_address.Text = "";
                    txt_header.Text = "";

                }
            }
            else
            {
                MessageBox.Show("Invalid Data", "Please enter a valid data.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
