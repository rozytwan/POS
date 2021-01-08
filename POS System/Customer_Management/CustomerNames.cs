using BLLS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_System
{
    public partial class CustomerNames : Form
    {
        string table_no2;
        string Gettablename;
        public CustomerNames(string table_no, string tablename)
        {
            InitializeComponent();
            table_no2 = table_no;
            Gettablename = tablename;
        }
        BLLUser blu = new BLLUser();
        blllCustomerDetailednyo blcd = new blllCustomerDetailednyo();
        private void CustomerNames_Load(object sender, EventArgs e)
        {
            userLoad();
        }
        int i = 0;

        public void userLoad()
        {
            DataTable dt = blcd.getallcustomersPhoneNoName();
            flowLayoutPanel1.Controls.Clear();
            for (int low = 0; low < dt.Rows.Count; low++)
            {
                Button[] newPanelcategory = new Button[99];
                newPanelcategory[low] = new Button();
                newPanelcategory[low].Name = dt.Rows[low]["id"].ToString();
                newPanelcategory[low].Text = dt.Rows[low]["name"].ToString();
                newPanelcategory[low].Location = System.Drawing.Point.Add(new Point(0, 4 + i * 55), new Size(50, 50));
                newPanelcategory[low].Height = 98;
                newPanelcategory[low].Width = 114;
                newPanelcategory[low].AutoSizeMode = AutoSizeMode.GrowAndShrink;
                newPanelcategory[low].FlatStyle = FlatStyle.Flat;
                newPanelcategory[low].Font = new Font("Century Gothic", 10, FontStyle.Bold);
                //newPanelcategory[low].BackColor = ColorTranslator.FromHtml("#33A6FF");

                newPanelcategory[low].ForeColor = Color.White;

                string user_image = dt.Rows[low]["image"].ToString();

                if (user_image.Length == 0 || user_image == null || user_image == "")
                {

                    newPanelcategory[low].BackColor = Color.Gray;
                    newPanelcategory[low].TextAlign = ContentAlignment.TopCenter;
                }
                else
                {
                    newPanelcategory[low].TextAlign = ContentAlignment.BottomCenter;
                    var sm = File.Exists(user_image);
                    if (sm == true)
                    {
                        newPanelcategory[low].BackgroundImage = Image.FromFile(user_image);
                    }
                    newPanelcategory[low].BackgroundImageLayout = ImageLayout.Stretch;
                    newPanelcategory[low].ImageAlign = ContentAlignment.TopCenter;
                    newPanelcategory[low].BackColor = Color.Gray;
                }

                //this.Controls.Add(newPanelcategory);


                flowLayoutPanel1.Controls.Add(newPanelcategory[low]);
                newPanelcategory[low].Click += new EventHandler(panelButtons_Click);
                //lblitem_id.Hide();
            }

        }
        public static string customer_names;
        List<string> customer_name_list = new List<string> { };
        public static int id;
        int j = 0;
        public void panelButtons_Click(object sender, EventArgs e)
        {
            // customer_name_list.Add(((Button)sender).Text);
            if (j <= 1)
            {
                if (((Control)sender).BackColor == Color.Gray)
                {
                    ((Control)sender).BackColor = Color.White;
                    ((Control)sender).ForeColor = Color.Black;
                    customer_name_list.Add(((Button)sender).Text);
                    j--;
                }
                else
                {
                    ((Control)sender).BackColor = Color.Gray;
                    ((Control)sender).ForeColor = Color.White;
                    j++;
                    foreach (string s in customer_name_list.ToArray())
                    {
                        if (s == ((Button)sender).Text)
                        {
                            customer_name_list.Remove(s);

                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("no more");
            }
        }
        private void btn_ok_Click(object sender, EventArgs e)
        {
            customer_names = string.Join<string>(" ", customer_name_list);
            this.Hide();
            Control ctls = this.Parent;
            Billing bl = new Billing(table_no2, Gettablename);
            bl.cbo_customer_name.Text = customer_names;
            //ctls.Controls.Clear();
            //ctls.Controls.Add(bl);


        }
    }
}




