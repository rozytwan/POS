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

namespace POS_System.CustomerAttendance
{
    public partial class AddEventType : UserControl
    {
        public AddEventType()
        {
            InitializeComponent();
        }


        BLLEventAttedance blea = new BLLEventAttedance();
        private void AddEventType_Load(object sender, EventArgs e)
        {
            dataGridViewLoad();

        }
        public void dataGridViewLoad()
        {
            DataTable dt = blea.getAllDataFromEvent();
            if (dt.Rows.Count > 0)
            {
                dataGridView1.Rows.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int su = dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells["cal_event_name"].Value = dt.Rows[i]["event_name"];
                    dataGridView1.Rows[i].Cells["cal_total_guest"].Value = dt.Rows[i]["total_guest"];
                    dataGridView1.Rows[i].Cells["cal_id"].Value = dt.Rows[i]["id"];
                } 
            }
        }


        private void btn_save_Click(object sender, EventArgs e)
        {

            if (txt_event_name.Text != "" && txt_total_guest.Text != "")
            {
                if (btn_save.Text == "Update")
                {
                    int update = blea.UpdateEvent(txt_event_name.Text, Convert.ToInt32(txt_total_guest.Text),id);
                    if (update > 0)
                    {
                        dataGridViewLoad();
                        btn_save.Text = "Save";
                        clear();
                    }
                }
                else
                {
                    int insertEvent = blea.InsertEvent(txt_event_name.Text, Convert.ToInt32(txt_total_guest.Text));
                    if (insertEvent > 0)
                    {
                        dataGridViewLoad();
                        clear();
                    }
                }

            }
        }
        int id;
        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                txt_event_name.Text = dataGridView1.CurrentRow.Cells["cal_event_name"].Value.ToString();
                txt_total_guest.Text = dataGridView1.CurrentRow.Cells["cal_total_guest"].Value.ToString();
                id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["cal_id"].Value);
                btn_save.Text = "Update";
            }
        }
        public void clear()
        {
            txt_event_name.Text = "";
            txt_total_guest.Text = "";
        }
        private void btn_back_Click(object sender, EventArgs e)
        {

        }
    }
}
