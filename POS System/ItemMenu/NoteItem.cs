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
    public partial class NoteItem : Form
    {
        public NoteItem()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            //if (dataGridView1.SelectedRows.Count > 0)
            //{
            //    dataGridView1.CurrentRow.Cells["cal_description"].Value = txtrichbox.Text;
            //}
        }

        private void NoteItem_Load(object sender, EventArgs e)
        {

        }
    }
}
