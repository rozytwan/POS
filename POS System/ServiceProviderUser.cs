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
    public partial class ServiceProviderUser : Form
    {
        public ServiceProviderUser()
        {
            InitializeComponent();
        }
        BLLUser blu = new BLLUser();
     
     
        public static int id;
       
      

        private void ServiceProviderUser_Load(object sender, EventArgs e)
        {
            userLoad();
        }
        int i = 0;
        public void userLoad()
        {
            DataTable dt = blu.getalluser(); 
            flowLayoutPanel1.Controls.Clear();
            for (int low = 0; low < dt.Rows.Count; low++)
            {
                Button[] newPanelcategory = new Button[99];
                newPanelcategory[low] = new Button();
                newPanelcategory[low].Name = dt.Rows[low]["user_id"].ToString();
                newPanelcategory[low].Text = dt.Rows[low]["user_name"].ToString();
                newPanelcategory[low].Location = System.Drawing.Point.Add(new Point(0, 4 + i * 55), new Size(50, 50));
                newPanelcategory[low].Height = 98;
                newPanelcategory[low].Width = 114;
                newPanelcategory[low].AutoSizeMode = AutoSizeMode.GrowAndShrink;
                newPanelcategory[low].FlatStyle = FlatStyle.Flat;
                newPanelcategory[low].Font = new Font("Century Gothic", 10, FontStyle.Bold);
                //newPanelcategory[low].BackColor = ColorTranslator.FromHtml("#33A6FF");

                newPanelcategory[low].ForeColor = Color.White;

                string user_image = dt.Rows[low]["user_image"].ToString();

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
        public static string service_provider_name;
         List<string> service_provider_list = new List<string> { };
        public void panelButtons_Click(object sender, EventArgs e)
        {

            if (((Control)sender).BackColor == Color.Gray)
            {
                ((Control)sender).BackColor = Color.White;
                ((Control)sender).ForeColor = Color.Black;


                service_provider_list.Add(((Button)sender).Text);


            }
            else
            {
                ((Control)sender).BackColor = Color.Gray;
                ((Control)sender).ForeColor = Color.White;
                foreach (string s in service_provider_list.ToArray())
                {
                    if (s == ((Button)sender).Text)
                    {
                        service_provider_list.Remove(s);
                    }
                }
            } 
        }

        private void btn_ok_Click_1(object sender, EventArgs e)
        {
            service_provider_name=string.Join<string>(" ",service_provider_list);
            this.Hide();
        }
    }
}
