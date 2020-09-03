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
    public partial class Item_modifier_list : Form
    {
        public Item_modifier_list()
        {
            InitializeComponent();
        }
        BLLItem_Modifier blmd = new BLLItem_Modifier();
        public string item_id;
        private void Item_modifier_list_Load(object sender, EventArgs e)
        {
            flow_modifier.Controls.Clear();
            if (Convert.ToInt32(item_id) > 0)
            {
                modifier_item_list();
            }
        }
        Button[] md_item = new Button[99];
        public void modifier_item_list()
        {
            DataTable dt_check_modifier = blmd.get_all_modifier_by_item_id_and_status(Convert.ToInt32(item_id));
            if (dt_check_modifier.Rows.Count > 0)
            {

                for (int i = 0; dt_check_modifier.Rows.Count > i; i++)
                {
                    Button[] md_item = new Button[99];
                    md_item[i] = new Button();
                    md_item[i].Text = dt_check_modifier.Rows[i]["modifier_name"].ToString();
                    md_item[i].Name = dt_check_modifier.Rows[i]["modifier_id"].ToString();
                    md_item[i].Location = System.Drawing.Point.Add(new Point(4 + i * 50, 5), new Size(50, 50));
                    md_item[i].Height = 70;
                    md_item[i].Width = 110;
                    md_item[i].Tag = i;
                    md_item[i].FlatStyle = FlatStyle.Flat;
                    md_item[i].Font = new Font("Times New Roman", 10, FontStyle.Bold);
                    flow_modifier.Controls.Add(md_item[i]);
                    md_item[i].Click += new EventHandler(md_item_Click);
                }
            }

        }
        int tag_id;
        string button_text;
       public string message;
        List<string> modifier_text = new List<string> { };
        public static string md_text;
        private void md_item_Click(object sender, EventArgs e)
        {
            tag_id = Convert.ToInt32("\r\n" + ((Button)sender).Tag);
            button_text = "\r\n" + ((Button)sender).Text;
          
            if (((Control)sender).BackColor != Color.Gray)
            {

                ((Control)sender).BackColor = Color.Gray;
                ((Control)sender).ForeColor = Color.White;
                modifier_text.Add(button_text);
                message=string.Join(",", modifier_text);

            }
            else
            {
                ((Control)sender).BackColor = Color.White;
                ((Control)sender).ForeColor = Color.Black;
                modifier_text.Add(button_text);
                foreach (string s in modifier_text.ToArray())
                {
                    if (s == button_text)
                    {
                        modifier_text.Remove(s);
                        message = string.Join(",", modifier_text);
                    }
                }

            }
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (message != "")
            {
                md_text = message.Replace(Environment.NewLine, @"");
                this.Hide();
            }
            else
            {
                md_text = "";
                this.Hide();
            }
        }

        private void btn_normal_Click(object sender, EventArgs e)
        {
            md_text = "";
            this.Hide();
        }

        private void btn_cross_Click(object sender, EventArgs e)
        {
            md_text = "";
            this.Hide();
        }
    }
}
