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
       
       int row_ids=KOTOrder.row_id;
        public static string itemnote;
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (row_ids > 0)
            {
                itemnote= txt_rich_note.Text;
            }
        }

        private void NoteItem_Load(object sender, EventArgs e)
        {

        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            itemnote = txt_rich_note.Text;
             // KOTOrder_Load(null, null);
            this.Hide();
        }

        private void btn_modifier_Click(object sender, EventArgs e)
        {
            Item_modifier_list iml = new Item_modifier_list();
            iml.ShowDialog();
        }
    }
}
