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
using BLLS.Bll_mess_days;

namespace POS_System.Customer_Management
{
    public partial class CustomerMessProgram : UserControl
    {
        public CustomerMessProgram()
        {
            InitializeComponent();
        }

        String getDayName = "";
        String flp_panelName = "";

        bll_customer_mess Bllmess = new bll_customer_mess();
    bll_breakfast Bllbreak = new bll_breakfast();
        private void CustomerMessProgram_Load(object sender, EventArgs e)
        {
            loadallItems();
            flowLayoutDefaultcolors();
            getDayName = btn_sunday.Text;
            btn_sunday.BackColor = Color.FromArgb(11, 81, 90);
        }



        public void loadallItems() {
            DataTable getall = Bllmess.getallItems();
            if (getall.Rows.Count > 0) {
                flp_itemsList.Controls.Clear();
                for (int i = 0; i < getall.Rows.Count; i++)
                {
                    Button[] itembutton = new Button[getall.Rows.Count];
                    itembutton[i] = new Button();
                    itembutton[i].Name = getall.Rows[i]["item_id"].ToString();
                    itembutton[i].Text = getall.Rows[i]["item_name"].ToString();
                    itembutton[i].Height = 50;
                    itembutton[i].Width = 80;
                    itembutton[i].BackColor = Color.Azure;
                    itembutton[i].ForeColor = Color.Black;
                    itembutton[i].AllowDrop = true;
                    itembutton[i].ContextMenuStrip = contextMenuStrip1;
                    itembutton[i].Click += new System.EventHandler(this.itembutton_click);
                    itembutton[i].MouseMove += new MouseEventHandler(this.itembutton_mousemove);
                    itembutton[i].MouseDown += new MouseEventHandler(this.itembutton_mousedown);
                    itembutton[i].MouseClick += new MouseEventHandler(this.Itembutton_mouseClick);                                      
                    flp_itemsList.Controls.Add(itembutton[i]);
                    
                }
            }
        }
        
        private void flp_weekdays_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pakage_panel_Paint(object sender, PaintEventArgs e)
        {

        }

        public void defaultBackcolor() {

            btn_sunday.BackColor = Color.FromArgb(11, 81, 126);
            btn_monday.BackColor = Color.FromArgb(11, 81, 126);
            btn_tuesday.BackColor = Color.FromArgb(11, 81, 126);
            btn_webnesday.BackColor = Color.FromArgb(11, 81, 126);
            btn_Thursday.BackColor = Color.FromArgb(11, 81, 126);
            btn_Friday.BackColor = Color.FromArgb(11, 81, 126);
            btn_Saturday.BackColor = Color.FromArgb(11, 81, 126);
        }
        private void btn_sunday_Click(object sender, EventArgs e)
        {
            defaultBackcolor();
            getDayName = btn_sunday.Text;
            btn_sunday.BackColor = Color.FromArgb(11, 81, 90);
           
            if (flp_breakfast.Controls.Count > 0 || flp_lunch.Controls.Count > 0 || flp_snacks.Controls.Count > 0 || flp_dinner.Controls.Count > 0)
            {
                DialogResult Dialog = MessageBox.Show( " Are you sure want to clear added Items without Saving ?", "Items Added", MessageBoxButtons.YesNo);
                if (Dialog == DialogResult.Yes)
                {
                    flp_breakfast.Controls.Clear();
                    flp_lunch.Controls.Clear();
                    flp_snacks.Controls.Clear();
                    flp_dinner.Controls.Clear();
                }
                else if (Dialog == DialogResult.No)
                {
                   // MessageBox.Show(" First Save Items for Sunday");
                }


            }
            DataTable getItemsfromSelectedPakageinbreakfast = Bllbreak.getallBreakfastsforfromPakage(lbl_pakagenameget.Text,getDayName);
            if (getItemsfromSelectedPakageinbreakfast.Rows.Count>0) {

                for (int i = 0; i < getItemsfromSelectedPakageinbreakfast.Rows.Count; i++)
                {
                    Button[] itembutton = new Button[getItemsfromSelectedPakageinbreakfast.Rows.Count];
                    itembutton[i] = new Button();
                    itembutton[i].Name = getItemsfromSelectedPakageinbreakfast.Rows[i]["br_id"].ToString();
                    itembutton[i].Text = getItemsfromSelectedPakageinbreakfast.Rows[i]["itemname"].ToString();
                    itembutton[i].Height = 50;
                    itembutton[i].Width = 80;
                    itembutton[i].BackColor = Color.Azure;
                    itembutton[i].ForeColor = Color.Black;
                    itembutton[i].AllowDrop = true;
                    itembutton[i].ContextMenuStrip = contextMenuStrip1;
                    itembutton[i].Click += new System.EventHandler(this.itembutton_click);
                    itembutton[i].MouseMove += new MouseEventHandler(this.itembutton_mousemove);
                    itembutton[i].MouseDown += new MouseEventHandler(this.itembutton_mousedown);
                    itembutton[i].MouseClick += new MouseEventHandler(this.Itembutton_mouseClick);


                    flp_breakfast.Controls.Add(itembutton[i]);
                }
            }

            DataTable getItemsfromSelectedPakageinLunch = Bllbreak.getallLunchforfromPakage(lbl_pakagenameget.Text, getDayName);
            if (getItemsfromSelectedPakageinLunch.Rows.Count > 0)
            {

                for (int i = 0; i < getItemsfromSelectedPakageinLunch.Rows.Count; i++)
                {
                    Button[] itembutton = new Button[getItemsfromSelectedPakageinLunch.Rows.Count];
                    itembutton[i] = new Button();
                    itembutton[i].Name = getItemsfromSelectedPakageinLunch.Rows[i]["br_id"].ToString();
                    itembutton[i].Text = getItemsfromSelectedPakageinLunch.Rows[i]["itemname"].ToString();
                    itembutton[i].Height = 50;
                    itembutton[i].Width = 80;
                    itembutton[i].BackColor = Color.Azure;
                    itembutton[i].ForeColor = Color.Black;
                    itembutton[i].AllowDrop = true;
                    itembutton[i].ContextMenuStrip = contextMenuStrip1;
                    itembutton[i].Click += new System.EventHandler(this.itembutton_click);
                    itembutton[i].MouseMove += new MouseEventHandler(this.itembutton_mousemove);
                    itembutton[i].MouseDown += new MouseEventHandler(this.itembutton_mousedown);
                    itembutton[i].MouseClick += new MouseEventHandler(this.Itembutton_mouseClick);


                    flp_lunch.Controls.Add(itembutton[i]);
                }
            }

            DataTable getItemsfromSelectedPakageinsnacks = Bllbreak.getallSnacksforfromPakage(lbl_pakagenameget.Text, getDayName);
            if (getItemsfromSelectedPakageinsnacks.Rows.Count > 0)
            {

                for (int i = 0; i < getItemsfromSelectedPakageinsnacks.Rows.Count; i++)
                {
                    Button[] itembutton = new Button[getItemsfromSelectedPakageinsnacks.Rows.Count];
                    itembutton[i] = new Button();
                    itembutton[i].Name = getItemsfromSelectedPakageinsnacks.Rows[i]["br_id"].ToString();
                    itembutton[i].Text = getItemsfromSelectedPakageinsnacks.Rows[i]["itemname"].ToString();
                    itembutton[i].Height = 50;
                    itembutton[i].Width = 80;
                    itembutton[i].BackColor = Color.Azure;
                    itembutton[i].ForeColor = Color.Black;
                    itembutton[i].AllowDrop = true;
                    itembutton[i].ContextMenuStrip = contextMenuStrip1;
                    itembutton[i].Click += new System.EventHandler(this.itembutton_click);
                    itembutton[i].MouseMove += new MouseEventHandler(this.itembutton_mousemove);
                    itembutton[i].MouseDown += new MouseEventHandler(this.itembutton_mousedown);
                    itembutton[i].MouseClick += new MouseEventHandler(this.Itembutton_mouseClick);


                    flp_snacks.Controls.Add(itembutton[i]);
                }
            }
            DataTable getItemsfromSelectedPakageinDinner = Bllbreak.getallDinnerforfromPakage(lbl_pakagenameget.Text, getDayName);
            if (getItemsfromSelectedPakageinDinner.Rows.Count > 0)
            {

                for (int i = 0; i < getItemsfromSelectedPakageinDinner.Rows.Count; i++)
                {
                    Button[] itembutton = new Button[getItemsfromSelectedPakageinDinner.Rows.Count];
                    itembutton[i] = new Button();
                    itembutton[i].Name = getItemsfromSelectedPakageinDinner.Rows[i]["br_id"].ToString();
                    itembutton[i].Text = getItemsfromSelectedPakageinDinner.Rows[i]["itemname"].ToString();
                    itembutton[i].Height = 50;
                    itembutton[i].Width = 80;
                    itembutton[i].BackColor = Color.Azure;
                    itembutton[i].ForeColor = Color.Black;
                    itembutton[i].AllowDrop = true;
                    itembutton[i].ContextMenuStrip = contextMenuStrip1;
                    itembutton[i].Click += new System.EventHandler(this.itembutton_click);
                    itembutton[i].MouseMove += new MouseEventHandler(this.itembutton_mousemove);
                    itembutton[i].MouseDown += new MouseEventHandler(this.itembutton_mousedown);
                    itembutton[i].MouseClick += new MouseEventHandler(this.Itembutton_mouseClick);


                    flp_dinner.Controls.Add(itembutton[i]);
                }
            }


        }
        

        private void itembutton_doubleclick(object sender, EventArgs d) {
         

        }
        private void itembutton_click(object sender, EventArgs e)
        {
            //string a = ((Button)sender).Text.ToString();
            //MessageBox.Show(a);
            //if (flp_panelName == "flp_breakfast")
            //{
            //    flp_breakfast.Controls.Add(((Button)sender));
            //}
            //else if (flp_panelName == "flp_lunch")
            //{
            //    flp_lunch.Controls.Add(((Button)sender));

            //}
            //else if (flp_panelName == "flp_snacks")
            //{
            //    flp_snacks.Controls.Add(((Button)sender));

            //}
            //else if (flp_panelName == "flp_dinner")
            //{
            //    flp_dinner.Controls.Add(((Button)sender));

            //}
        }
        private void itembutton_mousedown(object sender, MouseEventArgs m) {
            if (m.Button == MouseButtons.Left) {
              
                ((Button)sender).DoDragDrop(((Button)sender), DragDropEffects.Copy);
               // loadallItems();

            }
        }
        private void Itembutton_mouseClick(object sender, MouseEventArgs rt) {

           
        }
        private void itembutton_mousemove(object sender, MouseEventArgs m) {

           
        }

        private void btn_monday_Click(object sender, EventArgs e)
        {

            defaultBackcolor();
            getDayName = btn_monday.Text;
            btn_monday.BackColor = Color.FromArgb(11, 81, 90);
            if (flp_breakfast.Controls.Count > 0 || flp_lunch.Controls.Count > 0 || flp_snacks.Controls.Count > 0 || flp_dinner.Controls.Count > 0)
            {
                DialogResult Dialog = MessageBox.Show( " Are you sure want to clear panels with out Saving", "Items Already Added", MessageBoxButtons.YesNo);
                if (Dialog == DialogResult.Yes)
                {
                    flp_breakfast.Controls.Clear();
                    flp_lunch.Controls.Clear();
                    flp_snacks.Controls.Clear();
                    flp_dinner.Controls.Clear();
                }
                else if (Dialog == DialogResult.No)
                {
                   // MessageBox.Show(" First Save Items for Monday");
                }

            }

            DataTable getItemsfromSelectedPakageinbreakfast = Bllbreak.getallBreakfastsforfromPakage(lbl_pakagenameget.Text, getDayName);
            if (getItemsfromSelectedPakageinbreakfast.Rows.Count > 0)
            {

                for (int i = 0; i < getItemsfromSelectedPakageinbreakfast.Rows.Count; i++)
                {
                    Button[] itembutton = new Button[getItemsfromSelectedPakageinbreakfast.Rows.Count];
                    itembutton[i] = new Button();
                    itembutton[i].Name = getItemsfromSelectedPakageinbreakfast.Rows[i]["br_id"].ToString();
                    itembutton[i].Text = getItemsfromSelectedPakageinbreakfast.Rows[i]["itemname"].ToString();
                    itembutton[i].Height = 50;
                    itembutton[i].Width = 80;
                    itembutton[i].BackColor = Color.Azure;
                    itembutton[i].ForeColor = Color.Black;
                    itembutton[i].AllowDrop = true;
                    itembutton[i].ContextMenuStrip = contextMenuStrip1;
                    itembutton[i].Click += new System.EventHandler(this.itembutton_click);
                    itembutton[i].MouseMove += new MouseEventHandler(this.itembutton_mousemove);
                    itembutton[i].MouseDown += new MouseEventHandler(this.itembutton_mousedown);
                    itembutton[i].MouseClick += new MouseEventHandler(this.Itembutton_mouseClick);


                    flp_breakfast.Controls.Add(itembutton[i]);
                }
            }

            DataTable getItemsfromSelectedPakageinLunch = Bllbreak.getallLunchforfromPakage(lbl_pakagenameget.Text, getDayName);
            if (getItemsfromSelectedPakageinLunch.Rows.Count > 0)
            {

                for (int i = 0; i < getItemsfromSelectedPakageinLunch.Rows.Count; i++)
                {
                    Button[] itembutton = new Button[getItemsfromSelectedPakageinLunch.Rows.Count];
                    itembutton[i] = new Button();
                    itembutton[i].Name = getItemsfromSelectedPakageinLunch.Rows[i]["br_id"].ToString();
                    itembutton[i].Text = getItemsfromSelectedPakageinLunch.Rows[i]["itemname"].ToString();
                    itembutton[i].Height = 50;
                    itembutton[i].Width = 80;
                    itembutton[i].BackColor = Color.Azure;
                    itembutton[i].ForeColor = Color.Black;
                    itembutton[i].AllowDrop = true;
                    itembutton[i].ContextMenuStrip = contextMenuStrip1;
                    itembutton[i].Click += new System.EventHandler(this.itembutton_click);
                    itembutton[i].MouseMove += new MouseEventHandler(this.itembutton_mousemove);
                    itembutton[i].MouseDown += new MouseEventHandler(this.itembutton_mousedown);
                    itembutton[i].MouseClick += new MouseEventHandler(this.Itembutton_mouseClick);


                    flp_lunch.Controls.Add(itembutton[i]);
                }
            }

            DataTable getItemsfromSelectedPakageinsnacks = Bllbreak.getallSnacksforfromPakage(lbl_pakagenameget.Text, getDayName);
            if (getItemsfromSelectedPakageinsnacks.Rows.Count > 0)
            {

                for (int i = 0; i < getItemsfromSelectedPakageinsnacks.Rows.Count; i++)
                {
                    Button[] itembutton = new Button[getItemsfromSelectedPakageinsnacks.Rows.Count];
                    itembutton[i] = new Button();
                    itembutton[i].Name = getItemsfromSelectedPakageinsnacks.Rows[i]["br_id"].ToString();
                    itembutton[i].Text = getItemsfromSelectedPakageinsnacks.Rows[i]["itemname"].ToString();
                    itembutton[i].Height = 50;
                    itembutton[i].Width = 80;
                    itembutton[i].BackColor = Color.Azure;
                    itembutton[i].ForeColor = Color.Black;
                    itembutton[i].AllowDrop = true;
                    itembutton[i].ContextMenuStrip = contextMenuStrip1;
                    itembutton[i].Click += new System.EventHandler(this.itembutton_click);
                    itembutton[i].MouseMove += new MouseEventHandler(this.itembutton_mousemove);
                    itembutton[i].MouseDown += new MouseEventHandler(this.itembutton_mousedown);
                    itembutton[i].MouseClick += new MouseEventHandler(this.Itembutton_mouseClick);


                    flp_snacks.Controls.Add(itembutton[i]);
                }
            }
            DataTable getItemsfromSelectedPakageinDinner = Bllbreak.getallDinnerforfromPakage(lbl_pakagenameget.Text, getDayName);
            if (getItemsfromSelectedPakageinDinner.Rows.Count > 0)
            {

                for (int i = 0; i < getItemsfromSelectedPakageinDinner.Rows.Count; i++)
                {
                    Button[] itembutton = new Button[getItemsfromSelectedPakageinDinner.Rows.Count];
                    itembutton[i] = new Button();
                    itembutton[i].Name = getItemsfromSelectedPakageinDinner.Rows[i]["br_id"].ToString();
                    itembutton[i].Text = getItemsfromSelectedPakageinDinner.Rows[i]["itemname"].ToString();
                    itembutton[i].Height = 50;
                    itembutton[i].Width = 80;
                    itembutton[i].BackColor = Color.Azure;
                    itembutton[i].ForeColor = Color.Black;
                    itembutton[i].AllowDrop = true;
                    itembutton[i].ContextMenuStrip = contextMenuStrip1;
                    itembutton[i].Click += new System.EventHandler(this.itembutton_click);
                    itembutton[i].MouseMove += new MouseEventHandler(this.itembutton_mousemove);
                    itembutton[i].MouseDown += new MouseEventHandler(this.itembutton_mousedown);
                    itembutton[i].MouseClick += new MouseEventHandler(this.Itembutton_mouseClick);


                    flp_dinner.Controls.Add(itembutton[i]);
                }
            }


        }

        private void btn_tuesday_Click(object sender, EventArgs e)
        {
            defaultBackcolor();
            getDayName = btn_tuesday.Text;
            btn_tuesday.BackColor = Color.FromArgb(11, 81, 90);
            if (flp_breakfast.Controls.Count > 0 || flp_lunch.Controls.Count > 0 || flp_snacks.Controls.Count > 0 || flp_dinner.Controls.Count > 0)
            {
                DialogResult Dialog = MessageBox.Show( " Are you sure want to clear panels with out Saving", "Items Already Added", MessageBoxButtons.YesNo);
                if (Dialog == DialogResult.Yes)
                {
                    flp_breakfast.Controls.Clear();
                    flp_lunch.Controls.Clear();
                    flp_snacks.Controls.Clear();
                    flp_dinner.Controls.Clear();
                }
                else if (Dialog == DialogResult.No)
                {
                   // MessageBox.Show(" First Save Items for Tuesday");
                }


            }
            DataTable getItemsfromSelectedPakageinbreakfast = Bllbreak.getallBreakfastsforfromPakage(lbl_pakagenameget.Text, getDayName);
            if (getItemsfromSelectedPakageinbreakfast.Rows.Count > 0)
            {

                for (int i = 0; i < getItemsfromSelectedPakageinbreakfast.Rows.Count; i++)
                {
                    Button[] itembutton = new Button[getItemsfromSelectedPakageinbreakfast.Rows.Count];
                    itembutton[i] = new Button();
                    itembutton[i].Name = getItemsfromSelectedPakageinbreakfast.Rows[i]["br_id"].ToString();
                    itembutton[i].Text = getItemsfromSelectedPakageinbreakfast.Rows[i]["itemname"].ToString();
                    itembutton[i].Height = 50;
                    itembutton[i].Width = 80;
                    itembutton[i].BackColor = Color.Azure;
                    itembutton[i].ForeColor = Color.Black;
                    itembutton[i].AllowDrop = true;
                    itembutton[i].ContextMenuStrip = contextMenuStrip1;
                    itembutton[i].Click += new System.EventHandler(this.itembutton_click);
                    itembutton[i].MouseMove += new MouseEventHandler(this.itembutton_mousemove);
                    itembutton[i].MouseDown += new MouseEventHandler(this.itembutton_mousedown);
                    itembutton[i].MouseClick += new MouseEventHandler(this.Itembutton_mouseClick);


                    flp_breakfast.Controls.Add(itembutton[i]);
                }
            }

            DataTable getItemsfromSelectedPakageinLunch = Bllbreak.getallLunchforfromPakage(lbl_pakagenameget.Text, getDayName);
            if (getItemsfromSelectedPakageinLunch.Rows.Count > 0)
            {

                for (int i = 0; i < getItemsfromSelectedPakageinLunch.Rows.Count; i++)
                {
                    Button[] itembutton = new Button[getItemsfromSelectedPakageinLunch.Rows.Count];
                    itembutton[i] = new Button();
                    itembutton[i].Name = getItemsfromSelectedPakageinLunch.Rows[i]["br_id"].ToString();
                    itembutton[i].Text = getItemsfromSelectedPakageinLunch.Rows[i]["itemname"].ToString();
                    itembutton[i].Height = 50;
                    itembutton[i].Width = 80;
                    itembutton[i].BackColor = Color.Azure;
                    itembutton[i].ForeColor = Color.Black;
                    itembutton[i].AllowDrop = true;
                    itembutton[i].ContextMenuStrip = contextMenuStrip1;
                    itembutton[i].Click += new System.EventHandler(this.itembutton_click);
                    itembutton[i].MouseMove += new MouseEventHandler(this.itembutton_mousemove);
                    itembutton[i].MouseDown += new MouseEventHandler(this.itembutton_mousedown);
                    itembutton[i].MouseClick += new MouseEventHandler(this.Itembutton_mouseClick);


                    flp_lunch.Controls.Add(itembutton[i]);
                }
            }

            DataTable getItemsfromSelectedPakageinsnacks = Bllbreak.getallSnacksforfromPakage(lbl_pakagenameget.Text, getDayName);
            if (getItemsfromSelectedPakageinsnacks.Rows.Count > 0)
            {

                for (int i = 0; i < getItemsfromSelectedPakageinsnacks.Rows.Count; i++)
                {
                    Button[] itembutton = new Button[getItemsfromSelectedPakageinsnacks.Rows.Count];
                    itembutton[i] = new Button();
                    itembutton[i].Name = getItemsfromSelectedPakageinsnacks.Rows[i]["br_id"].ToString();
                    itembutton[i].Text = getItemsfromSelectedPakageinsnacks.Rows[i]["itemname"].ToString();
                    itembutton[i].Height = 50;
                    itembutton[i].Width = 80;
                    itembutton[i].BackColor = Color.Azure;
                    itembutton[i].ForeColor = Color.Black;
                    itembutton[i].AllowDrop = true;
                    itembutton[i].ContextMenuStrip = contextMenuStrip1;
                    itembutton[i].Click += new System.EventHandler(this.itembutton_click);
                    itembutton[i].MouseMove += new MouseEventHandler(this.itembutton_mousemove);
                    itembutton[i].MouseDown += new MouseEventHandler(this.itembutton_mousedown);
                    itembutton[i].MouseClick += new MouseEventHandler(this.Itembutton_mouseClick);


                    flp_snacks.Controls.Add(itembutton[i]);
                }
            }
            DataTable getItemsfromSelectedPakageinDinner = Bllbreak.getallDinnerforfromPakage(lbl_pakagenameget.Text, getDayName);
            if (getItemsfromSelectedPakageinDinner.Rows.Count > 0)
            {

                for (int i = 0; i < getItemsfromSelectedPakageinDinner.Rows.Count; i++)
                {
                    Button[] itembutton = new Button[getItemsfromSelectedPakageinDinner.Rows.Count];
                    itembutton[i] = new Button();
                    itembutton[i].Name = getItemsfromSelectedPakageinDinner.Rows[i]["br_id"].ToString();
                    itembutton[i].Text = getItemsfromSelectedPakageinDinner.Rows[i]["itemname"].ToString();
                    itembutton[i].Height = 50;
                    itembutton[i].Width = 80;
                    itembutton[i].BackColor = Color.Azure;
                    itembutton[i].ForeColor = Color.Black;
                    itembutton[i].AllowDrop = true;
                    itembutton[i].ContextMenuStrip = contextMenuStrip1;
                    itembutton[i].Click += new System.EventHandler(this.itembutton_click);
                    itembutton[i].MouseMove += new MouseEventHandler(this.itembutton_mousemove);
                    itembutton[i].MouseDown += new MouseEventHandler(this.itembutton_mousedown);
                    itembutton[i].MouseClick += new MouseEventHandler(this.Itembutton_mouseClick);


                    flp_dinner.Controls.Add(itembutton[i]);
                }
            }

        }

        private void btn_webnesday_Click(object sender, EventArgs e)
        {
            defaultBackcolor();
            getDayName = btn_webnesday.Text;
            btn_webnesday.BackColor = Color.FromArgb(11, 81, 90);
            if (flp_breakfast.Controls.Count > 0 || flp_lunch.Controls.Count > 0 || flp_snacks.Controls.Count > 0 || flp_dinner.Controls.Count > 0)
            {
                DialogResult Dialog = MessageBox.Show( " Are you sure want to clear panels with out Saving", "Items Already Added", MessageBoxButtons.YesNo);
                if (Dialog == DialogResult.Yes)
                {
                    flp_breakfast.Controls.Clear();
                    flp_lunch.Controls.Clear();
                    flp_snacks.Controls.Clear();
                    flp_dinner.Controls.Clear();
                }
                else if (Dialog == DialogResult.No)
                {
                   // MessageBox.Show(" First Save Items for Wednusday");
                }


            }
            DataTable getItemsfromSelectedPakageinbreakfast = Bllbreak.getallBreakfastsforfromPakage(lbl_pakagenameget.Text, getDayName);
            if (getItemsfromSelectedPakageinbreakfast.Rows.Count > 0)
            {

                for (int i = 0; i < getItemsfromSelectedPakageinbreakfast.Rows.Count; i++)
                {
                    Button[] itembutton = new Button[getItemsfromSelectedPakageinbreakfast.Rows.Count];
                    itembutton[i] = new Button();
                    itembutton[i].Name = getItemsfromSelectedPakageinbreakfast.Rows[i]["br_id"].ToString();
                    itembutton[i].Text = getItemsfromSelectedPakageinbreakfast.Rows[i]["itemname"].ToString();
                    itembutton[i].Height = 50;
                    itembutton[i].Width = 80;
                    itembutton[i].BackColor = Color.Azure;
                    itembutton[i].ForeColor = Color.Black;
                    itembutton[i].AllowDrop = true;
                    itembutton[i].ContextMenuStrip = contextMenuStrip1;
                    itembutton[i].Click += new System.EventHandler(this.itembutton_click);
                    itembutton[i].MouseMove += new MouseEventHandler(this.itembutton_mousemove);
                    itembutton[i].MouseDown += new MouseEventHandler(this.itembutton_mousedown);
                    itembutton[i].MouseClick += new MouseEventHandler(this.Itembutton_mouseClick);


                    flp_breakfast.Controls.Add(itembutton[i]);
                }
            }

            DataTable getItemsfromSelectedPakageinLunch = Bllbreak.getallLunchforfromPakage(lbl_pakagenameget.Text, getDayName);
            if (getItemsfromSelectedPakageinLunch.Rows.Count > 0)
            {

                for (int i = 0; i < getItemsfromSelectedPakageinLunch.Rows.Count; i++)
                {
                    Button[] itembutton = new Button[getItemsfromSelectedPakageinLunch.Rows.Count];
                    itembutton[i] = new Button();
                    itembutton[i].Name = getItemsfromSelectedPakageinLunch.Rows[i]["br_id"].ToString();
                    itembutton[i].Text = getItemsfromSelectedPakageinLunch.Rows[i]["itemname"].ToString();
                    itembutton[i].Height = 50;
                    itembutton[i].Width = 80;
                    itembutton[i].BackColor = Color.Azure;
                    itembutton[i].ForeColor = Color.Black;
                    itembutton[i].AllowDrop = true;
                    itembutton[i].ContextMenuStrip = contextMenuStrip1;
                    itembutton[i].Click += new System.EventHandler(this.itembutton_click);
                    itembutton[i].MouseMove += new MouseEventHandler(this.itembutton_mousemove);
                    itembutton[i].MouseDown += new MouseEventHandler(this.itembutton_mousedown);
                    itembutton[i].MouseClick += new MouseEventHandler(this.Itembutton_mouseClick);


                    flp_lunch.Controls.Add(itembutton[i]);
                }
            }

            DataTable getItemsfromSelectedPakageinsnacks = Bllbreak.getallSnacksforfromPakage(lbl_pakagenameget.Text, getDayName);
            if (getItemsfromSelectedPakageinsnacks.Rows.Count > 0)
            {

                for (int i = 0; i < getItemsfromSelectedPakageinsnacks.Rows.Count; i++)
                {
                    Button[] itembutton = new Button[getItemsfromSelectedPakageinsnacks.Rows.Count];
                    itembutton[i] = new Button();
                    itembutton[i].Name = getItemsfromSelectedPakageinsnacks.Rows[i]["br_id"].ToString();
                    itembutton[i].Text = getItemsfromSelectedPakageinsnacks.Rows[i]["itemname"].ToString();
                    itembutton[i].Height = 50;
                    itembutton[i].Width = 80;
                    itembutton[i].BackColor = Color.Azure;
                    itembutton[i].ForeColor = Color.Black;
                    itembutton[i].AllowDrop = true;
                    itembutton[i].ContextMenuStrip = contextMenuStrip1;
                    itembutton[i].Click += new System.EventHandler(this.itembutton_click);
                    itembutton[i].MouseMove += new MouseEventHandler(this.itembutton_mousemove);
                    itembutton[i].MouseDown += new MouseEventHandler(this.itembutton_mousedown);
                    itembutton[i].MouseClick += new MouseEventHandler(this.Itembutton_mouseClick);


                    flp_snacks.Controls.Add(itembutton[i]);
                }
            }
            DataTable getItemsfromSelectedPakageinDinner = Bllbreak.getallDinnerforfromPakage(lbl_pakagenameget.Text, getDayName);
            if (getItemsfromSelectedPakageinDinner.Rows.Count > 0)
            {

                for (int i = 0; i < getItemsfromSelectedPakageinDinner.Rows.Count; i++)
                {
                    Button[] itembutton = new Button[getItemsfromSelectedPakageinDinner.Rows.Count];
                    itembutton[i] = new Button();
                    itembutton[i].Name = getItemsfromSelectedPakageinDinner.Rows[i]["br_id"].ToString();
                    itembutton[i].Text = getItemsfromSelectedPakageinDinner.Rows[i]["itemname"].ToString();
                    itembutton[i].Height = 50;
                    itembutton[i].Width = 80;
                    itembutton[i].BackColor = Color.Azure;
                    itembutton[i].ForeColor = Color.Black;
                    itembutton[i].AllowDrop = true;
                    itembutton[i].ContextMenuStrip = contextMenuStrip1;
                    itembutton[i].Click += new System.EventHandler(this.itembutton_click);
                    itembutton[i].MouseMove += new MouseEventHandler(this.itembutton_mousemove);
                    itembutton[i].MouseDown += new MouseEventHandler(this.itembutton_mousedown);
                    itembutton[i].MouseClick += new MouseEventHandler(this.Itembutton_mouseClick);


                    flp_dinner.Controls.Add(itembutton[i]);
                }
            }

        }

        private void btn_Thursday_Click(object sender, EventArgs e)
        {
            defaultBackcolor();
            getDayName = btn_Thursday.Text;
            btn_Thursday.BackColor = Color.FromArgb(11, 81, 90);
            if (flp_breakfast.Controls.Count > 0 || flp_lunch.Controls.Count > 0 || flp_snacks.Controls.Count > 0 || flp_dinner.Controls.Count > 0)
            {
                DialogResult Dialog = MessageBox.Show(" Are you sure want to clear panels with out Saving", "Items Already Added", MessageBoxButtons.YesNo);
                if (Dialog == DialogResult.Yes)
                {
                    flp_breakfast.Controls.Clear();
                    flp_lunch.Controls.Clear();
                    flp_snacks.Controls.Clear();
                    flp_dinner.Controls.Clear();
                }
                else if (Dialog == DialogResult.No)
                {
                   // MessageBox.Show(" First Save Items for Thursday");
                }

            }
            DataTable getItemsfromSelectedPakageinbreakfast = Bllbreak.getallBreakfastsforfromPakage(lbl_pakagenameget.Text, getDayName);
            if (getItemsfromSelectedPakageinbreakfast.Rows.Count > 0)
            {

                for (int i = 0; i < getItemsfromSelectedPakageinbreakfast.Rows.Count; i++)
                {
                    Button[] itembutton = new Button[getItemsfromSelectedPakageinbreakfast.Rows.Count];
                    itembutton[i] = new Button();
                    itembutton[i].Name = getItemsfromSelectedPakageinbreakfast.Rows[i]["br_id"].ToString();
                    itembutton[i].Text = getItemsfromSelectedPakageinbreakfast.Rows[i]["itemname"].ToString();
                    itembutton[i].Height = 50;
                    itembutton[i].Width = 80;
                    itembutton[i].BackColor = Color.Azure;
                    itembutton[i].ForeColor = Color.Black;
                    itembutton[i].AllowDrop = true;
                    itembutton[i].ContextMenuStrip = contextMenuStrip1;
                    itembutton[i].Click += new System.EventHandler(this.itembutton_click);
                    itembutton[i].MouseMove += new MouseEventHandler(this.itembutton_mousemove);
                    itembutton[i].MouseDown += new MouseEventHandler(this.itembutton_mousedown);
                    itembutton[i].MouseClick += new MouseEventHandler(this.Itembutton_mouseClick);


                    flp_breakfast.Controls.Add(itembutton[i]);
                }
            }

            DataTable getItemsfromSelectedPakageinLunch = Bllbreak.getallLunchforfromPakage(lbl_pakagenameget.Text, getDayName);
            if (getItemsfromSelectedPakageinLunch.Rows.Count > 0)
            {

                for (int i = 0; i < getItemsfromSelectedPakageinLunch.Rows.Count; i++)
                {
                    Button[] itembutton = new Button[getItemsfromSelectedPakageinLunch.Rows.Count];
                    itembutton[i] = new Button();
                    itembutton[i].Name = getItemsfromSelectedPakageinLunch.Rows[i]["br_id"].ToString();
                    itembutton[i].Text = getItemsfromSelectedPakageinLunch.Rows[i]["itemname"].ToString();
                    itembutton[i].Height = 50;
                    itembutton[i].Width = 80;
                    itembutton[i].BackColor = Color.Azure;
                    itembutton[i].ForeColor = Color.Black;
                    itembutton[i].AllowDrop = true;
                    itembutton[i].ContextMenuStrip = contextMenuStrip1;
                    itembutton[i].Click += new System.EventHandler(this.itembutton_click);
                    itembutton[i].MouseMove += new MouseEventHandler(this.itembutton_mousemove);
                    itembutton[i].MouseDown += new MouseEventHandler(this.itembutton_mousedown);
                    itembutton[i].MouseClick += new MouseEventHandler(this.Itembutton_mouseClick);


                    flp_lunch.Controls.Add(itembutton[i]);
                }
            }

            DataTable getItemsfromSelectedPakageinsnacks = Bllbreak.getallSnacksforfromPakage(lbl_pakagenameget.Text, getDayName);
            if (getItemsfromSelectedPakageinsnacks.Rows.Count > 0)
            {

                for (int i = 0; i < getItemsfromSelectedPakageinsnacks.Rows.Count; i++)
                {
                    Button[] itembutton = new Button[getItemsfromSelectedPakageinsnacks.Rows.Count];
                    itembutton[i] = new Button();
                    itembutton[i].Name = getItemsfromSelectedPakageinsnacks.Rows[i]["br_id"].ToString();
                    itembutton[i].Text = getItemsfromSelectedPakageinsnacks.Rows[i]["itemname"].ToString();
                    itembutton[i].Height = 50;
                    itembutton[i].Width = 80;
                    itembutton[i].BackColor = Color.Azure;
                    itembutton[i].ForeColor = Color.Black;
                    itembutton[i].AllowDrop = true;
                    itembutton[i].ContextMenuStrip = contextMenuStrip1;
                    itembutton[i].Click += new System.EventHandler(this.itembutton_click);
                    itembutton[i].MouseMove += new MouseEventHandler(this.itembutton_mousemove);
                    itembutton[i].MouseDown += new MouseEventHandler(this.itembutton_mousedown);
                    itembutton[i].MouseClick += new MouseEventHandler(this.Itembutton_mouseClick);


                    flp_snacks.Controls.Add(itembutton[i]);
                }
            }
            DataTable getItemsfromSelectedPakageinDinner = Bllbreak.getallDinnerforfromPakage(lbl_pakagenameget.Text, getDayName);
            if (getItemsfromSelectedPakageinDinner.Rows.Count > 0)
            {

                for (int i = 0; i < getItemsfromSelectedPakageinDinner.Rows.Count; i++)
                {
                    Button[] itembutton = new Button[getItemsfromSelectedPakageinDinner.Rows.Count];
                    itembutton[i] = new Button();
                    itembutton[i].Name = getItemsfromSelectedPakageinDinner.Rows[i]["br_id"].ToString();
                    itembutton[i].Text = getItemsfromSelectedPakageinDinner.Rows[i]["itemname"].ToString();
                    itembutton[i].Height = 50;
                    itembutton[i].Width = 80;
                    itembutton[i].BackColor = Color.Azure;
                    itembutton[i].ForeColor = Color.Black;
                    itembutton[i].AllowDrop = true;
                    itembutton[i].ContextMenuStrip = contextMenuStrip1;
                    itembutton[i].Click += new System.EventHandler(this.itembutton_click);
                    itembutton[i].MouseMove += new MouseEventHandler(this.itembutton_mousemove);
                    itembutton[i].MouseDown += new MouseEventHandler(this.itembutton_mousedown);
                    itembutton[i].MouseClick += new MouseEventHandler(this.Itembutton_mouseClick);


                    flp_dinner.Controls.Add(itembutton[i]);
                }
            }

        }

        private void btn_Friday_Click(object sender, EventArgs e)
        {
            defaultBackcolor();
            getDayName = btn_Friday.Text;
            btn_Friday.BackColor = Color.FromArgb(11, 81, 90);
            if (flp_breakfast.Controls.Count > 0 || flp_lunch.Controls.Count > 0 || flp_snacks.Controls.Count > 0 || flp_dinner.Controls.Count > 0)
            {
                DialogResult Dialog = MessageBox.Show(" Are you sure want to clear panels with out Saving","Items Already Added",MessageBoxButtons.YesNo);
                if (Dialog == DialogResult.Yes)
                {
                    flp_breakfast.Controls.Clear();
                    flp_lunch.Controls.Clear();
                    flp_snacks.Controls.Clear();
                    flp_dinner.Controls.Clear();
                }
                else if (Dialog == DialogResult.No)
                {
                   // MessageBox.Show(" First Save Items for Friday");
                }


            }
            DataTable getItemsfromSelectedPakageinbreakfast = Bllbreak.getallBreakfastsforfromPakage(lbl_pakagenameget.Text, getDayName);
            if (getItemsfromSelectedPakageinbreakfast.Rows.Count > 0)
            {

                for (int i = 0; i < getItemsfromSelectedPakageinbreakfast.Rows.Count; i++)
                {
                    Button[] itembutton = new Button[getItemsfromSelectedPakageinbreakfast.Rows.Count];
                    itembutton[i] = new Button();
                    itembutton[i].Name = getItemsfromSelectedPakageinbreakfast.Rows[i]["br_id"].ToString();
                    itembutton[i].Text = getItemsfromSelectedPakageinbreakfast.Rows[i]["itemname"].ToString();
                    itembutton[i].Height = 50;
                    itembutton[i].Width = 80;
                    itembutton[i].BackColor = Color.Azure;
                    itembutton[i].ForeColor = Color.Black;
                    itembutton[i].AllowDrop = true;
                    itembutton[i].ContextMenuStrip = contextMenuStrip1;
                    itembutton[i].Click += new System.EventHandler(this.itembutton_click);
                    itembutton[i].MouseMove += new MouseEventHandler(this.itembutton_mousemove);
                    itembutton[i].MouseDown += new MouseEventHandler(this.itembutton_mousedown);
                    itembutton[i].MouseClick += new MouseEventHandler(this.Itembutton_mouseClick);


                    flp_breakfast.Controls.Add(itembutton[i]);
                }
            }

            DataTable getItemsfromSelectedPakageinLunch = Bllbreak.getallLunchforfromPakage(lbl_pakagenameget.Text, getDayName);
            if (getItemsfromSelectedPakageinLunch.Rows.Count > 0)
            {

                for (int i = 0; i < getItemsfromSelectedPakageinLunch.Rows.Count; i++)
                {
                    Button[] itembutton = new Button[getItemsfromSelectedPakageinLunch.Rows.Count];
                    itembutton[i] = new Button();
                    itembutton[i].Name = getItemsfromSelectedPakageinLunch.Rows[i]["br_id"].ToString();
                    itembutton[i].Text = getItemsfromSelectedPakageinLunch.Rows[i]["itemname"].ToString();
                    itembutton[i].Height = 50;
                    itembutton[i].Width = 80;
                    itembutton[i].BackColor = Color.Azure;
                    itembutton[i].ForeColor = Color.Black;
                    itembutton[i].AllowDrop = true;
                    itembutton[i].ContextMenuStrip = contextMenuStrip1;
                    itembutton[i].Click += new System.EventHandler(this.itembutton_click);
                    itembutton[i].MouseMove += new MouseEventHandler(this.itembutton_mousemove);
                    itembutton[i].MouseDown += new MouseEventHandler(this.itembutton_mousedown);
                    itembutton[i].MouseClick += new MouseEventHandler(this.Itembutton_mouseClick);


                    flp_lunch.Controls.Add(itembutton[i]);
                }
            }

            DataTable getItemsfromSelectedPakageinsnacks = Bllbreak.getallSnacksforfromPakage(lbl_pakagenameget.Text, getDayName);
            if (getItemsfromSelectedPakageinsnacks.Rows.Count > 0)
            {

                for (int i = 0; i < getItemsfromSelectedPakageinsnacks.Rows.Count; i++)
                {
                    Button[] itembutton = new Button[getItemsfromSelectedPakageinsnacks.Rows.Count];
                    itembutton[i] = new Button();
                    itembutton[i].Name = getItemsfromSelectedPakageinsnacks.Rows[i]["br_id"].ToString();
                    itembutton[i].Text = getItemsfromSelectedPakageinsnacks.Rows[i]["itemname"].ToString();
                    itembutton[i].Height = 50;
                    itembutton[i].Width = 80;
                    itembutton[i].BackColor = Color.Azure;
                    itembutton[i].ForeColor = Color.Black;
                    itembutton[i].AllowDrop = true;
                    itembutton[i].ContextMenuStrip = contextMenuStrip1;
                    itembutton[i].Click += new System.EventHandler(this.itembutton_click);
                    itembutton[i].MouseMove += new MouseEventHandler(this.itembutton_mousemove);
                    itembutton[i].MouseDown += new MouseEventHandler(this.itembutton_mousedown);
                    itembutton[i].MouseClick += new MouseEventHandler(this.Itembutton_mouseClick);


                    flp_snacks.Controls.Add(itembutton[i]);
                }
            }
            DataTable getItemsfromSelectedPakageinDinner = Bllbreak.getallDinnerforfromPakage(lbl_pakagenameget.Text, getDayName);
            if (getItemsfromSelectedPakageinDinner.Rows.Count > 0)
            {

                for (int i = 0; i < getItemsfromSelectedPakageinDinner.Rows.Count; i++)
                {
                    Button[] itembutton = new Button[getItemsfromSelectedPakageinDinner.Rows.Count];
                    itembutton[i] = new Button();
                    itembutton[i].Name = getItemsfromSelectedPakageinDinner.Rows[i]["br_id"].ToString();
                    itembutton[i].Text = getItemsfromSelectedPakageinDinner.Rows[i]["itemname"].ToString();
                    itembutton[i].Height = 50;
                    itembutton[i].Width = 80;
                    itembutton[i].BackColor = Color.Azure;
                    itembutton[i].ForeColor = Color.Black;
                    itembutton[i].AllowDrop = true;
                    itembutton[i].ContextMenuStrip = contextMenuStrip1;
                    itembutton[i].Click += new System.EventHandler(this.itembutton_click);
                    itembutton[i].MouseMove += new MouseEventHandler(this.itembutton_mousemove);
                    itembutton[i].MouseDown += new MouseEventHandler(this.itembutton_mousedown);
                    itembutton[i].MouseClick += new MouseEventHandler(this.Itembutton_mouseClick);


                    flp_dinner.Controls.Add(itembutton[i]);
                }
            }

        }

        private void btn_Saturday_Click(object sender, EventArgs e)
        {
            defaultBackcolor();
            getDayName = btn_Saturday.Text;
            btn_Saturday.BackColor = Color.FromArgb(11, 81, 90);
            if (flp_breakfast.Controls.Count > 0 || flp_lunch.Controls.Count > 0 || flp_snacks.Controls.Count > 0 || flp_dinner.Controls.Count > 0)
            {
                DialogResult Dialog = MessageBox.Show(" Are you sure want to clear panels with out Saving", "Items Already Added", MessageBoxButtons.YesNo);
                if (Dialog == DialogResult.Yes)
                {
                    flp_breakfast.Controls.Clear();
                    flp_lunch.Controls.Clear();
                    flp_snacks.Controls.Clear();
                    flp_dinner.Controls.Clear();
                }
                else if (Dialog == DialogResult.No)
                {
                   // MessageBox.Show(" First Save Items for Saturday");
                }


            }
            DataTable getItemsfromSelectedPakageinbreakfast = Bllbreak.getallBreakfastsforfromPakage(lbl_pakagenameget.Text, getDayName);
            if (getItemsfromSelectedPakageinbreakfast.Rows.Count > 0)
            {

                for (int i = 0; i < getItemsfromSelectedPakageinbreakfast.Rows.Count; i++)
                {
                    Button[] itembutton = new Button[getItemsfromSelectedPakageinbreakfast.Rows.Count];
                    itembutton[i] = new Button();
                    itembutton[i].Name = getItemsfromSelectedPakageinbreakfast.Rows[i]["br_id"].ToString();
                    itembutton[i].Text = getItemsfromSelectedPakageinbreakfast.Rows[i]["itemname"].ToString();
                    itembutton[i].Height = 50;
                    itembutton[i].Width = 80;
                    itembutton[i].BackColor = Color.Azure;
                    itembutton[i].ForeColor = Color.Black;
                    itembutton[i].AllowDrop = true;
                    itembutton[i].ContextMenuStrip = contextMenuStrip1;
                    itembutton[i].Click += new System.EventHandler(this.itembutton_click);
                    itembutton[i].MouseMove += new MouseEventHandler(this.itembutton_mousemove);
                    itembutton[i].MouseDown += new MouseEventHandler(this.itembutton_mousedown);
                    itembutton[i].MouseClick += new MouseEventHandler(this.Itembutton_mouseClick);


                    flp_breakfast.Controls.Add(itembutton[i]);
                }
            }

            DataTable getItemsfromSelectedPakageinLunch = Bllbreak.getallLunchforfromPakage(lbl_pakagenameget.Text, getDayName);
            if (getItemsfromSelectedPakageinLunch.Rows.Count > 0)
            {

                for (int i = 0; i < getItemsfromSelectedPakageinLunch.Rows.Count; i++)
                {
                    Button[] itembutton = new Button[getItemsfromSelectedPakageinLunch.Rows.Count];
                    itembutton[i] = new Button();
                    itembutton[i].Name = getItemsfromSelectedPakageinLunch.Rows[i]["br_id"].ToString();
                    itembutton[i].Text = getItemsfromSelectedPakageinLunch.Rows[i]["itemname"].ToString();
                    itembutton[i].Height = 50;
                    itembutton[i].Width = 80;
                    itembutton[i].BackColor = Color.Azure;
                    itembutton[i].ForeColor = Color.Black;
                    itembutton[i].AllowDrop = true;
                    itembutton[i].ContextMenuStrip = contextMenuStrip1;
                    itembutton[i].Click += new System.EventHandler(this.itembutton_click);
                    itembutton[i].MouseMove += new MouseEventHandler(this.itembutton_mousemove);
                    itembutton[i].MouseDown += new MouseEventHandler(this.itembutton_mousedown);
                    itembutton[i].MouseClick += new MouseEventHandler(this.Itembutton_mouseClick);


                    flp_lunch.Controls.Add(itembutton[i]);
                }
            }

            DataTable getItemsfromSelectedPakageinsnacks = Bllbreak.getallSnacksforfromPakage(lbl_pakagenameget.Text, getDayName);
            if (getItemsfromSelectedPakageinsnacks.Rows.Count > 0)
            {

                for (int i = 0; i < getItemsfromSelectedPakageinsnacks.Rows.Count; i++)
                {
                    Button[] itembutton = new Button[getItemsfromSelectedPakageinsnacks.Rows.Count];
                    itembutton[i] = new Button();
                    itembutton[i].Name = getItemsfromSelectedPakageinsnacks.Rows[i]["br_id"].ToString();
                    itembutton[i].Text = getItemsfromSelectedPakageinsnacks.Rows[i]["itemname"].ToString();
                    itembutton[i].Height = 50;
                    itembutton[i].Width = 80;
                    itembutton[i].BackColor = Color.Azure;
                    itembutton[i].ForeColor = Color.Black;
                    itembutton[i].AllowDrop = true;
                    itembutton[i].ContextMenuStrip = contextMenuStrip1;
                    itembutton[i].Click += new System.EventHandler(this.itembutton_click);
                    itembutton[i].MouseMove += new MouseEventHandler(this.itembutton_mousemove);
                    itembutton[i].MouseDown += new MouseEventHandler(this.itembutton_mousedown);
                    itembutton[i].MouseClick += new MouseEventHandler(this.Itembutton_mouseClick);


                    flp_snacks.Controls.Add(itembutton[i]);
                }
            }
            DataTable getItemsfromSelectedPakageinDinner = Bllbreak.getallDinnerforfromPakage(lbl_pakagenameget.Text, getDayName);
            if (getItemsfromSelectedPakageinDinner.Rows.Count > 0)
            {

                for (int i = 0; i < getItemsfromSelectedPakageinDinner.Rows.Count; i++)
                {
                    Button[] itembutton = new Button[getItemsfromSelectedPakageinDinner.Rows.Count];
                    itembutton[i] = new Button();
                    itembutton[i].Name = getItemsfromSelectedPakageinDinner.Rows[i]["br_id"].ToString();
                    itembutton[i].Text = getItemsfromSelectedPakageinDinner.Rows[i]["itemname"].ToString();
                    itembutton[i].Height = 50;
                    itembutton[i].Width = 80;
                    itembutton[i].BackColor = Color.Azure;
                    itembutton[i].ForeColor = Color.Black;
                    itembutton[i].AllowDrop = true;
                    itembutton[i].ContextMenuStrip = contextMenuStrip1;
                    itembutton[i].Click += new System.EventHandler(this.itembutton_click);
                    itembutton[i].MouseMove += new MouseEventHandler(this.itembutton_mousemove);
                    itembutton[i].MouseDown += new MouseEventHandler(this.itembutton_mousedown);
                    itembutton[i].MouseClick += new MouseEventHandler(this.Itembutton_mouseClick);


                    flp_dinner.Controls.Add(itembutton[i]);
                }
            }

        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (lbl_pakagenameget.Text == "Choose Package")
            {
                MessageBox.Show("Choose Pakage Name First");
            }
            else
            {
               int i=Bllbreak.deletepakagesbydays(lbl_pakagenameget.Text,getDayName);
                int j = Bllbreak.deletepakagesbydaysdinner(lbl_pakagenameget.Text, getDayName);
                int k = Bllbreak.deletepakagesbydayslunch(lbl_pakagenameget.Text, getDayName);
                int l = Bllbreak.deletepakagesbydayssnacks(lbl_pakagenameget.Text, getDayName);

                BreakfastInsert();
                    lunchInsert();
                    snacksInsert();
                    DinnerInsert();
                    MessageBox.Show("Item Saved for " + getDayName);
                
            }          
        }
        public void BreakfastInsert() {
            if (flp_breakfast.Controls.Count > 0)
            {
                if (lbl_pakagenameget.Text == "Choose Package") {
                    MessageBox.Show("Choose Pakage Name First.");
                }
                else
                {
                    foreach (Button item in flp_breakfast.Controls)
                    {
                        int a = Bllmess.insertintoBreakfast(item.Text.ToString(), getDayName, lbl_pakagenameget.Text);
                    }
                }
            }
        }

        public void lunchInsert()
        {
            if (flp_lunch.Controls.Count > 0)
            {
                if (lbl_pakagenameget.Text == "Choose Package")
                {
                    MessageBox.Show("Choose Pakage Name First.");
                }
                else
                {

                    foreach (Button item in flp_lunch.Controls)
                    {
                        int a = Bllmess.insertintoLunch(item.Text.ToString(), getDayName, lbl_pakagenameget.Text);
                    }
                }
            }
            
        }
        public void snacksInsert()
        {
            if (flp_snacks.Controls.Count > 0)
            {
                if (lbl_pakagenameget.Text == "Choose Package")
                {
                    MessageBox.Show("Choose Pakage Name First.");
                }
                else
                {
                    foreach (Button item in flp_snacks.Controls)
                    {
                        int a = Bllmess.insertintosnacks(item.Text.ToString(), getDayName, lbl_pakagenameget.Text);
                    }
                }
            }


        }
        public void breakfastBUttons() {
         
        }
        public void DinnerInsert()
        {
            if (flp_dinner.Controls.Count > 0)
            {
                if (lbl_pakagenameget.Text == "Choose Package")
                {
                    MessageBox.Show("Choose Pakage Name First.");
                }
                else
                {
                    foreach (Button item in flp_dinner.Controls)
                    {
                        int a = Bllmess.insertintoDinner(item.Text.ToString(), getDayName, lbl_pakagenameget.Text);
                    }
                }
            }

        }

        public void flowLayoutDefaultcolors() {
            flp_breakfast.BackColor = Color.FromArgb(223, 243, 109);
            flp_lunch.BackColor = Color.FromArgb(223, 243, 109);
            flp_snacks.BackColor = Color.FromArgb(223, 243, 109);
            flp_dinner.BackColor = Color.FromArgb(223, 243, 109);


        }
        private void flp_breakfast_Click(object sender, EventArgs e)
        {
            flowLayoutDefaultcolors();
            flp_breakfast.BackColor = Color.FromArgb(148, 244, 134);
            flp_panelName = ((FlowLayoutPanel)sender).Name;
            loadallItems();
            //MessageBox.Show(flp_panelName);
        }

      
        private void flp_breakfast_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (flp_breakfast.Controls.Count>0) {
                
            }
        }

        private void flp_lunch_Click(object sender, EventArgs e)
        {
            flowLayoutDefaultcolors();
            flp_lunch.BackColor = Color.FromArgb(148, 244, 134);
            flp_panelName = ((FlowLayoutPanel)sender).Name;
            loadallItems();
        }

        private void flp_snacks_Click(object sender, EventArgs e)
        {
            flowLayoutDefaultcolors();
            flp_snacks.BackColor = Color.FromArgb(148, 244, 134);
            flp_panelName = ((FlowLayoutPanel)sender).Name;
            loadallItems();
        }

        private void flp_dinner_Click(object sender, EventArgs e)
        {
            flowLayoutDefaultcolors(); 
            flp_dinner.BackColor = Color.FromArgb(148, 244, 134);
            flp_panelName = ((FlowLayoutPanel)sender).Name;
            loadallItems();
        }

        private void flp_breakfast_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void flp_breakfast_DragDrop(object sender, DragEventArgs e)
        {
            ((Button)e.Data.GetData(typeof(Button))).Parent = (Panel)sender;
             loadallItems();
        }

        private void flp_lunch_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void flp_lunch_DragDrop(object sender, DragEventArgs e)
        {
            ((Button)e.Data.GetData(typeof(Button))).Parent = (Panel)sender;
            loadallItems();
        }

        private void flp_snacks_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void flp_snacks_DragDrop(object sender, DragEventArgs e)
        {
            ((Button)e.Data.GetData(typeof(Button))).Parent = (Panel)sender;
            loadallItems();
        }

        private void flp_dinner_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void flp_dinner_DragDrop(object sender, DragEventArgs e)
        {
            ((Button)e.Data.GetData(typeof(Button))).Parent = (Panel)sender;
            loadallItems();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void txt_searchItem_TextChanged(object sender, EventArgs e)
        {
            if (txt_searchItem.Text == "" || txt_searchItem.Text == null)
            {
                loadallItems();
            }
            else {
                DataTable getallsearchItems = Bllmess.searchallItems(txt_searchItem.Text);
                if (getallsearchItems.Rows.Count>0) {
                    flp_itemsList.Controls.Clear();
                    for (int k = 0; k< getallsearchItems.Rows.Count; k++)
                    {
                        Button[] itembutton = new Button[getallsearchItems.Rows.Count];
                        itembutton[k] = new Button();
                        itembutton[k].Name = getallsearchItems.Rows[k]["item_id"].ToString();
                        itembutton[k].Text = getallsearchItems.Rows[k]["item_name"].ToString();
                        itembutton[k].Height = 50;
                        itembutton[k].Width = 80;
                        itembutton[k].BackColor = Color.Azure;
                        itembutton[k].ForeColor = Color.Black;
                        itembutton[k].AllowDrop = true;
                        itembutton[k].Click += new System.EventHandler(this.itembutton_click);
                        itembutton[k].MouseMove += new MouseEventHandler(this.itembutton_mousemove);
                        itembutton[k].MouseDown += new MouseEventHandler(this.itembutton_mousedown);

                        flp_itemsList.Controls.Add(itembutton[k]);

                    }

                }
            }
        }

        private void Item_panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void contextMenuStrip1_Click(object sender, EventArgs e)
        {
            ContextMenuStrip menu = sender as ContextMenuStrip;
            Control sourceControl = menu.SourceControl;
            flp_breakfast.Controls.Remove(sourceControl);
            flp_snacks.Controls.Remove(sourceControl);
            flp_lunch.Controls.Remove(sourceControl);
            flp_dinner.Controls.Remove(sourceControl);

        }

        private void btn_choose_Click(object sender, EventArgs e)
        {
            Customer_Management.PakageNameSet pkset = new PakageNameSet();
            if (pkset.ShowDialog()==DialogResult.OK) {
                lbl_pakagenameget.Text = pkset.pakageName;
            }
        }

        
    }
}
