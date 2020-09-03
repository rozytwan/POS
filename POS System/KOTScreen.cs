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
    public partial class KotScreen : Form
    {
        string[] Colors { get; set; }
        public KotScreen()
        {
            InitializeComponent();
           
        }
        BLLKotDisplay blkd = new BLLKotDisplay();       
        BLLRestSell blresll = new BLLRestSell();

     
      //  int page_count;
        private void KotScreen_Load(object sender, EventArgs e)
        {        
            Timer timer1 = new Timer();
            timer1.Interval = 10000;
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Start();
            lbltime.Text = DateTime.Now.ToLongTimeString();
           
            createflowlayouts();
            quantity_count();

            DataTable dt = blkd.distinct_time();
            DataTable dt_dts = blkd.distinct();
            DataTable dt_warning = blkd.getallwarning();
            if (dt_warning.Rows.Count > 0)
            {
                int last = Convert.ToInt32(dt_warning.Rows[2]["time"].ToString());
                int sec = Convert.ToInt32(dt_warning.Rows[1]["time"].ToString());
                int first = Convert.ToInt32(dt_warning.Rows[0]["time"].ToString());
                for (int c = 0; c < dt_dts.Rows.Count; c++)
                {
                    TimeSpan span = Convert.ToDateTime(lbltime.Text).Subtract(Convert.ToDateTime(dt.Rows[c]["time"].ToString()));
                    int min = Convert.ToInt32(span.Minutes.ToString());
                    if (min > last)
                    {
                        // StickyFlowPane[c].BackColor = Color.FromName(dt_warning.Rows[2]["color"].ToString());
                        StickyFlowPane[c].BackColor = Color.Khaki;
                    }
                    else if (min > sec)
                    {
                        //StickyFlowPane[c].BackColor = Color.FromName(dt_warning.Rows[1]["color"].ToString());
                        StickyFlowPane[c].BackColor = Color.Orange;
                    }
                    else if (min > first)
                    {
                        StickyFlowPane[c].BackColor = Color.FromName(dt_warning.Rows[0]["color"].ToString());
                        StickyFlowPane[c].BackColor = Color.Red;
                    }
                }
            }

        }
        public void quantity_count()
        {
            DataTable dt_count = blkd.count_quantity();
            lblorder.Text = dt_count.Rows[0][0].ToString();
        }
        public void timer1_Tick(object sender, EventArgs e)
        {
            createflowlayouts();
            quantity_count();

            DataTable dt = blkd.distinct_time();
            DataTable dt_warning = blkd.getallwarning();
            DataTable dt_dts = blkd.distinct();
            int last = Convert.ToInt32(dt_warning.Rows[2]["time"].ToString());
            int sec = Convert.ToInt32(dt_warning.Rows[1]["time"].ToString());
            int first = Convert.ToInt32(dt_warning.Rows[0]["time"].ToString());
            if (dt_warning.Rows.Count > 0)
            {
                for (int c = 0; c < dt_dts.Rows.Count; c++)
                {
                    TimeSpan span = Convert.ToDateTime(DateTime.Now.ToLongTimeString()).Subtract(Convert.ToDateTime(dt.Rows[c]["time"].ToString()));
                    int min = Convert.ToInt32(span.Minutes.ToString());
                    if (min > last)
                    {
                        // StickyFlowPane[c].BackColor = Color.FromName(dt_warning.Rows[2]["color"].ToString());
                        StickyFlowPane[c].BackColor = Color.Khaki;
                    }
                    else if (min > sec)
                    {
                        //StickyFlowPane[c].BackColor = Color.FromName(dt_warning.Rows[1]["color"].ToString());
                        StickyFlowPane[c].BackColor = Color.Orange;
                    }
                    else if (min > first)
                    {
                        //StickyFlowPane[c].BackColor = Color.FromName(dt_warning.Rows[0]["color"].ToString());
                        StickyFlowPane[c].BackColor = Color.Red;
                    }
                }
            }

        }
        int next_panel;
        int asd;
       
        FlowLayoutPanel[] StickyFlowPane = new FlowLayoutPanel[50];
        public void createflowlayouts()
        {

            flowLayoutPanel1.Controls.Clear();
            DataTable dtst = blkd.getallkot_display_countTotal();
            DataTable dt_dts = blkd.distinct();
            next_panel = 8;
            for (asd = 0; asd<dt_dts.Rows.Count; asd++)
            {
                DataTable dt = blkd.getallkot(Convert.ToDecimal(dtst.Rows[asd]["kot_display_id"].ToString()));
                StickyFlowPane[asd] = new FlowLayoutPanel();
                StickyFlowPane[asd].Size = new System.Drawing.Size(200, 330);
                StickyFlowPane[asd].BackColor = System.Drawing.Color.Black;
                StickyFlowPane[asd].ForeColor = System.Drawing.Color.White;
                StickyFlowPane[asd].Location = System.Drawing.Point.Add(new Point(0, 10 + asd * 50), new Size(200, 330));
                StickyFlowPane[asd].Name = asd.ToString();
                StickyFlowPane[asd].Tag = Convert.ToInt32(dtst.Rows[asd]["kot_display_id"].ToString());
                StickyFlowPane[asd].WrapContents = false;
                //  StickyFlowPane[asd].Padding = new System.Windows.Forms.Padding(10);
                StickyFlowPane[asd].AutoScroll = true;
                StickyFlowPane[asd].HorizontalScroll.Visible = false;

                StickyFlowPane[asd].FlowDirection = FlowDirection.TopDown;
                if (asd < next_panel)
                {
                    flowLayoutPanel1.Controls.Add(StickyFlowPane[asd]);
                }
                StickyFlowPane[asd].Click += new System.EventHandler(StickyFlowPabel_Click);
                Label Kotid = new Label();
                Kotid.Name = "Kot ID  ";
                Kotid.Text = " Table No: " + dt.Rows[0]["table_no"].ToString()+" ";
                Kotid.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular);
                Kotid.AutoSize = true;
                Kotid.ForeColor = Color.White;

                StickyFlowPane[asd].Controls.Add(Kotid);
                //  MessageBox.Show(dtst.Rows[asd]["kot_display_id"].ToString());

                Label lines = new Label();
                lines.Name = "Item  " + asd.ToString();
                lines.Text = "----------------------------";
                lines.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
                lines.AutoSize = true;

                StickyFlowPane[asd].Controls.Add(lines);

                Label a = new Label();
                a.Name = "item  " + asd.ToString();
                a.Text = "QTY " + "   Item";
                a.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
                a.AutoSize = true;
                a.ForeColor = Color.White;
                StickyFlowPane[asd].Controls.Add(a);
                DataTable getdata = blkd.getallkotDisplay_byid(Convert.ToInt32(dtst.Rows[asd]["kot_display_id"].ToString()));


                for (int hehe = 0; hehe < getdata.Rows.Count; hehe++)
                {

                    Label b = new Label();
                    b.Name = "item " + asd.ToString();
                    b.Text = " " + getdata.Rows[hehe]["quantity"].ToString() + "            " + getdata.Rows[hehe]["item"].ToString();
                    b.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular);
                    b.AutoSize = true;
                    b.ForeColor = Color.White;

                    StickyFlowPane[asd].Controls.Add(b);
                    string asap = "White";
                    if (getdata.Rows[hehe]["status"].ToString() == "cancel")
                    {
                        b.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular);
                        b.ForeColor = Color.FromName(asap);
                    }

                }
                for (int hehe = 0; hehe < getdata.Rows.Count; hehe++)
                {
                    Label c = new Label();
                    c.Name = "item  " + asd.ToString();
                    c.Text = "Note:  " + getdata.Rows[hehe]["note"].ToString();
                    c.MaximumSize = new Size(240, 0);
                    c.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Italic);
                    c.AutoSize = true;
                    c.ForeColor = Color.White;
                }
            }
            asd = next_panel;
           // page_count = 1;
        }
        int s;       
        int kot_id;
        public void StickyFlowPabel_Click(object sender, EventArgs e)
        {
            s = Convert.ToInt32("\r\n" + ((FlowLayoutPanel)sender).Name);
            kot_id = Convert.ToInt32("\r\n" + ((FlowLayoutPanel)sender).Tag);
            //StickyFlowPane[back_ids].BackColor = System.Drawing.Color.Black;           
            //back_ids = s;
            DataTable dt = blkd.distinct_time();
            DataTable dt_dts = blkd.distinct();
            DataTable dt_warning = blkd.getallwarning();
            int last = Convert.ToInt32(dt_warning.Rows[2]["time"].ToString());
            int sec = Convert.ToInt32(dt_warning.Rows[1]["time"].ToString());
            int first = Convert.ToInt32(dt_warning.Rows[0]["time"].ToString());
            for (int c = 0; c < dt_dts.Rows.Count; c++)
            {
                TimeSpan span = Convert.ToDateTime(lbltime.Text).Subtract(Convert.ToDateTime(dt.Rows[c]["time"].ToString()));
                int min = Convert.ToInt32(span.Minutes.ToString());
                if (min > last)
                {
                    // StickyFlowPane[c].BackColor = Color.FromName(dt_warning.Rows[2]["color"].ToString());
                    StickyFlowPane[c].BackColor = Color.Khaki;
                }
                else if (min > sec)
                {
                    //StickyFlowPane[c].BackColor = Color.FromName(dt_warning.Rows[1]["color"].ToString());
                    StickyFlowPane[c].BackColor = Color.Orange;
                }
                else if (min > first)
                {
                   // StickyFlowPane[c].BackColor = Color.FromName(dt_warning.Rows[0]["color"].ToString());
                    StickyFlowPane[c].BackColor = Color.Red;
                }
            }

            StickyFlowPane[s].BackColor = System.Drawing.Color.LightBlue;
        }

        private void btnnext_Click(object sender, EventArgs e)
        {
            next_panel = next_panel + 8;
            DataTable dtst = blkd.getallkot_display_countTotal();
            if (dtst.Rows.Count<40)
            { 
                flowLayoutPanel1.Controls.Clear();
             
                for (asd = asd; asd < dtst.Rows.Count; asd++)
                {
                    DataTable dt = blkd.getallkot(Convert.ToDecimal(dtst.Rows[asd]["kot_display_id"].ToString()));
                    StickyFlowPane[asd] = new FlowLayoutPanel();
                    StickyFlowPane[asd].Size = new System.Drawing.Size(200, 330);
                    StickyFlowPane[asd].BackColor = System.Drawing.Color.Black;
                    StickyFlowPane[asd].ForeColor = System.Drawing.Color.White;
                    StickyFlowPane[asd].Location = System.Drawing.Point.Add(new Point(0, 10 + asd * 50), new Size(200, 330));
                    StickyFlowPane[asd].Name = asd.ToString();
                    StickyFlowPane[asd].Tag = Convert.ToInt32(dtst.Rows[asd]["kot_display_id"].ToString());
                    StickyFlowPane[asd].WrapContents = false;
                    //  StickyFlowPane[asd].Padding = new System.Windows.Forms.Padding(10);
                    //StickyFlowPane[asd].AutoScroll = true;
                    //StickyFlowPane[asd].HorizontalScroll.Visible = false;

                    StickyFlowPane[asd].FlowDirection = FlowDirection.TopDown;
                    if (asd < next_panel)
                    {
                        flowLayoutPanel1.Controls.Add(StickyFlowPane[asd]);
                    }
                    StickyFlowPane[asd].Click += new System.EventHandler(StickyFlowPabel_Click);
                    Label Kotid = new Label();
                    Kotid.Name = "Kot ID  ";
                    Kotid.Text = " Table No: " + dt.Rows[0]["table_no"].ToString() + " ";
                    Kotid.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular);
                    Kotid.AutoSize = true;
                    Kotid.ForeColor = Color.White;
                    StickyFlowPane[asd].Controls.Add(Kotid);
                    //  MessageBox.Show(dtst.Rows[asd]["kot_display_id"].ToString());

                    Label lines = new Label();
                    lines.Name = "Item  " + asd.ToString();
                    lines.Text = "----------------------------";
                    lines.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
                    lines.AutoSize = true;
                    lines.ForeColor = Color.White;

                    StickyFlowPane[asd].Controls.Add(lines);

                    Label a = new Label();
                    a.Name = "item  " + asd.ToString();
                    a.Text = "QTY " + "   Item";
                    a.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
                    a.AutoSize = true;
                    a.ForeColor = Color.White;
                    StickyFlowPane[asd].Controls.Add(a);
                    DataTable getdata = blkd.getallkotDisplay_byid(Convert.ToInt32(dtst.Rows[asd]["kot_display_id"].ToString()));


                    for (int hehe = 0; hehe < getdata.Rows.Count; hehe++)
                    {

                        Label b = new Label();
                        b.Name = "item " + asd.ToString();
                        b.Text = " " + getdata.Rows[hehe]["quantity"].ToString() + "            " + getdata.Rows[hehe]["item"].ToString();
                        b.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular);
                        b.AutoSize = true;

                        StickyFlowPane[asd].Controls.Add(b);
                        b.ForeColor = Color.White;
                        string asap = "White";
                        if (getdata.Rows[hehe]["status"].ToString() == "cancel")
                        {
                            b.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular);
                            b.ForeColor = Color.FromName(asap);
                        }

                    }
                    for (int hehe = 0; hehe < getdata.Rows.Count; hehe++)
                    {
                        Label c = new Label();
                        c.Name = "item  " + asd.ToString();
                        c.Text = "Note:  " + getdata.Rows[hehe]["note"].ToString();
                        c.MaximumSize = new Size(240, 0);
                        c.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Italic);
                        c.AutoSize = true;
                        c.ForeColor = Color.White;
                    }
                }
                asd = next_panel ;
            }
           
        }

        private void btnprevious_Click(object sender, EventArgs e)
        {
            DataTable dtst = blkd.getallkot_display_countTotal();
            
              

                next_panel = next_panel - 8;
            if (next_panel > 0)
            {
                flowLayoutPanel1.Controls.Clear();
                for (asd = next_panel - 8; asd < dtst.Rows.Count; asd++)
                {
                    DataTable dt = blkd.getallkot(Convert.ToDecimal(dtst.Rows[asd]["kot_display_id"].ToString()));
                    StickyFlowPane[asd] = new FlowLayoutPanel();
                    StickyFlowPane[asd].Size = new System.Drawing.Size(200, 330);
                    StickyFlowPane[asd].BackColor = System.Drawing.Color.Black;
                    StickyFlowPane[asd].ForeColor = System.Drawing.Color.White;
                    StickyFlowPane[asd].Location = System.Drawing.Point.Add(new Point(0, 10 + asd * 50), new Size(200, 330));
                    StickyFlowPane[asd].Name = asd.ToString();
                    StickyFlowPane[asd].Tag = Convert.ToInt32(dtst.Rows[asd]["kot_display_id"].ToString());
                    StickyFlowPane[asd].WrapContents = false;
                    //  StickyFlowPane[asd].Padding = new System.Windows.Forms.Padding(10);
                    //StickyFlowPane[asd].AutoScroll = true;
                    //StickyFlowPane[asd].HorizontalScroll.Visible = false;

                    StickyFlowPane[asd].FlowDirection = FlowDirection.TopDown;
                    if (asd < next_panel)
                    {
                        flowLayoutPanel1.Controls.Add(StickyFlowPane[asd]);
                    }
                    StickyFlowPane[asd].Click += new System.EventHandler(StickyFlowPabel_Click);
                    Label Kotid = new Label();
                    Kotid.Name = "Kot ID  ";
                    Kotid.Text = " Table No: " + dt.Rows[0]["table_no"].ToString() + " ";
                    Kotid.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular);
                    Kotid.AutoSize = true;
                    Kotid.BackColor = Color.Purple;
                    Kotid.ForeColor = Color.White;
                    StickyFlowPane[asd].Controls.Add(Kotid);
                    //  MessageBox.Show(dtst.Rows[asd]["kot_display_id"].ToString());

                    Label lines = new Label();
                    lines.Name = "Item  " + asd.ToString();
                    lines.Text = "----------------------------";
                    lines.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
                    lines.AutoSize = true;
                    lines.ForeColor = Color.White;

                    StickyFlowPane[asd].Controls.Add(lines);

                    Label a = new Label();
                    a.Name = "item  " + asd.ToString();
                    a.Text = "QTY " + "   Item";
                    a.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
                    a.AutoSize = true;
                    StickyFlowPane[asd].Controls.Add(a);
                    DataTable getdata = blkd.getallkotDisplay_byid(Convert.ToInt32(dtst.Rows[asd]["kot_display_id"].ToString()));
                    a.ForeColor = Color.White;

                    for (int hehe = 0; hehe < getdata.Rows.Count; hehe++)
                    {

                        Label b = new Label();
                        b.Name = "item " + asd.ToString();
                        b.Text = " " + getdata.Rows[hehe]["quantity"].ToString() + "            " + getdata.Rows[hehe]["item"].ToString();
                        b.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular);
                        b.AutoSize = true;
                        b.ForeColor = Color.White;

                        StickyFlowPane[asd].Controls.Add(b);
                        string asap = "White";
                        if (getdata.Rows[hehe]["status"].ToString() == "cancel")
                        {
                            b.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular);
                            b.ForeColor = Color.FromName(asap);
                        }

                    }
                    for (int hehe = 0; hehe < getdata.Rows.Count; hehe++)
                    {
                        Label c = new Label();
                        c.Name = "item  " + asd.ToString();
                        c.Text = "Note:  " + getdata.Rows[hehe]["note"].ToString();
                        c.MaximumSize = new Size(240, 0);
                        c.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Italic);
                        c.AutoSize = true;
                        c.ForeColor = Color.White;
                    }
                }
            }
            asd = next_panel;

        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            lbltime.Text = DateTime.Now.ToLongTimeString();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnsetting_Click(object sender, EventArgs e)
        {
            KOTSetting kotset = new KOTSetting();
            kotset.ShowDialog();
        }

        private void btn_ready_Click(object sender, EventArgs e)
        {
            if (kot_id > 0)
            {
                int delt = blkd.delete_kot_display(kot_id);
                if (delt > 0)
                {
                    StickyFlowPane[s].Dispose();
                }
            }
        }
    }
    }
    
  
       

       




       
   





