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
    public partial class KOTSetting : Form
    {
        public KOTSetting()
        {
            InitializeComponent();
        }
        BLLKotDisplay blkot = new BLLKotDisplay();
        string colorname1;
        private void colorbox_Click(object sender, EventArgs e)
        {
            DialogResult result = colorDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                colorbox.BackColor = colorDialog1.Color;
                Color c = colorDialog1.Color;
                colorname1 = c.Name.ToString();
            }
        }

      

        private void KOTSetting_Load(object sender, EventArgs e)
        {

        }
        string colorname2;
        private void colorbox2_Click(object sender, EventArgs e)
        {
            DialogResult result = colorDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                colorbox2.BackColor = colorDialog1.Color;
                Color c = colorDialog1.Color;
                colorname2 = c.Name.ToString();
            }
        }
        string colorname3;
        private void colorbox3_Click(object sender, EventArgs e)
        {
            DialogResult result = colorDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                colorbox3.BackColor = colorDialog1.Color;
                Color c = colorDialog1.Color;
                colorname3 = c.Name.ToString();
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            DataTable dt_check = blkot.getallwarning();
            if (dt_check.Rows.Count > 0)
            {
                int update1 = blkot.warning_update(Convert.ToInt32(cbo1st.Text), colorname1,1);
                int update2 = blkot.warning_update(Convert.ToInt32(cbo2nd.Text), colorname2,2);
                int update3 = blkot.warning_update(Convert.ToInt32(cbo3.Text), colorname3,3);
                if (update3 > 0)
                {
                    this.Close();
                }
            }
            else
            {
                int insert1 = blkot.insert_into_warning(Convert.ToInt32(cbo1st.Text), colorname1);
                int insert2 = blkot.insert_into_warning(Convert.ToInt32(cbo2nd.Text), colorname2);
                int insert3 = blkot.insert_into_warning(Convert.ToInt32(cbo3.Text), colorname3);
                if (insert3 > 0)
                {
                    this.Close();
                }
            }
        }
    }
}
