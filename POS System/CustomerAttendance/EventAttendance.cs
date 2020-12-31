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
using System.Windows;
using System.Drawing.Printing;

namespace POS_System.CustomerAttendance
{
    public partial class EventAttendance : UserControl
    {
        public EventAttendance()
        {
            InitializeComponent();

        }
        BLLEventAttedance blea = new BLLEventAttedance();
        blllCustomerDetailednyo blcde = new blllCustomerDetailednyo();
        int total_guest = 0;
        bool event_status;
        bool user_access;
        //bool start_status;
        private void EventAttendance_Load(object sender, EventArgs e)
        {
            btn_start.Checked = false;
            btn_stop.Enabled = false;
            CUstomer_name();
        }
        public void CUstomer_name()
        {
            DataTable dt = blea.getAllDataFromEvent();
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.NewRow();
                dr["event_name"] = "Choose Event";
                dt.Rows.InsertAt(dr, 0);
                cbo_event_type.DataSource = dt;
                cbo_event_type.DisplayMember = "event_name";
                cbo_event_type.ValueMember = "id";
            }
        }

        private void txt_card_no_Enter(object sender, EventArgs e)
        {
            if (txt_card_no.Text == "Card No")
            {
                txt_card_no.Text = "";
            }
        }

        private void txt_card_no_Leave(object sender, EventArgs e)
        {
            if (txt_card_no.Text == "")
            {
                txt_card_no.Text = "Card No";
            }
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            
            if (cbo_event_type.Text != "Choose Event")
            {
            AdminAccess acc = new AdminAccess();
            acc.ShowDialog();
            user_access = AdminAccess.discount_access_value;
            if (user_access == true)
            {
                cbo_event_type.Enabled = true;
                event_status = true;
                btn_start.Enabled = false;
                btn_stop.Enabled = true;
                txt_card_no.Focus();
                    btn_start.Checked = true;
                    //this.ActiveControl = txt_card_no;
                }
            }
            else
            {
                MessageBox.Show("Please Choose Event.", "Event", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        int token=0;
        private void txt_card_no_TextChanged(object sender, EventArgs e)
        {
            if (btn_start.Checked == true)
            {
                if (cbo_event_type.Text == "Choose Event" && cbo_event_type.Text == "")
                {
                    MessageBox.Show("Please Choose Event.", "Event", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (txt_card_no.Text.Length > 0 && txt_card_no.Text != "Card No" && txt_card_no.Text != "")
                    {
                        DataTable dtm = blcde.getnamebyno(txt_card_no.Text);
                        if (dtm.Rows.Count > 0)
                        {
                            int customer_id = Convert.ToInt32(dtm.Rows[0]["id"]);
                            DataTable dt = blea.CardEventAttendanceCheck(txt_card_no.Text);
                            if (dt.Rows.Count == 0)
                            {
                                int insertCardAttendance = blea.InserCardAttendance(txt_card_no.Text, DateTime.Now, customer_id, Convert.ToInt32(cbo_event_type.SelectedValue));
                                token++;
                                printtobill();
                                txt_card_no.Text = "";
                            }
                            else
                            {
                                txt_card_no.Text = "";
                            }
                        }
                    }

                }
            }
            else
            {
                MessageBox.Show("Please Start Event First Alert !!", "Continue Event Alert !!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btn_stop_Click(object sender, EventArgs e)
        {
            btn_start.Checked = false;
            AdminAccess acc = new AdminAccess();
            acc.ShowDialog();
            user_access = AdminAccess.discount_access_value;
            if (user_access == true)
            {
                printtobill();
                int update = blea.UpdateXreport(Convert.ToInt32(cbo_event_type.SelectedValue));
                cbo_event_type.Enabled = true;
                
                btn_start.Enabled = true;
                btn_stop.Enabled = false;
            }
        }

        public void printtobill()
        {
            PrintDialog pd = new PrintDialog();
            PrintDocument pdoc = new PrintDocument();
            PrinterSettings ps = new PrinterSettings();
            Font font = new Font("Arial", 12);
            PaperSize psize = new PaperSize("Custome", 314, 60000);
            pd.Document = pdoc;
            pdoc.PrinterSettings.PrinterName = "Billing";
            pd.Document.DefaultPageSettings.PaperSize = psize;
            pdoc.DefaultPageSettings.PaperSize.Height = 60000;
            pdoc.DefaultPageSettings.PaperSize.Width = 314;
            if (btn_start.Checked == true)
            {
                pdoc.PrintPage += new PrintPageEventHandler(printDocument1s_PrintPagestart);
            }
            else
            {
                pdoc.PrintPage += new PrintPageEventHandler(printDocument1s_PrintPage);
            }

            if (pdoc.PrinterSettings.IsValid)
            {
                pdoc.Print();

            }
            else
            {
                MessageBox.Show("Invalid Printer", "Printer Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DialogResult results = pd.ShowDialog();
                if (results == DialogResult.OK)
                {

                    pdoc.Print();

                }

            }
        }
        PictureBox pb1 = new PictureBox();
        string panvat;
        CheckDynamic cd = new CheckDynamic();
        BLLDynamic bldd = new BLLDynamic();
        public bool Headerstatus;
        public bool FooterStatus;
        private void printDocument1s_PrintPage(object sender, PrintPageEventArgs e)
        {

            float xs = 10;
            float ys = 7;
            float widths = 285.0F; // max width I found through trial and error
            float heights = 0F;
            int y = 83;
            Pen drawingPen = new Pen(Color.Black, 1);
            Pen draw_watermark = new Pen(Color.FromArgb(64, Color.Black));
            Font drawFontArial12Bold = new Font("Arial", 12, System.Drawing.FontStyle.Bold);
            Font drawFontArial10Regular = new Font("Arial", 9, System.Drawing.FontStyle.Regular);
            Font drawFontArial10Regularsmall = new Font("Arial", 7, System.Drawing.FontStyle.Regular);
            SolidBrush drawBrush = new SolidBrush(Color.Black);

            // Set format of string.
            StringFormat drawFormatCenter = new StringFormat();
            drawFormatCenter.Alignment = StringAlignment.Center;
            StringFormat drawFormatLeft = new StringFormat();
            drawFormatLeft.Alignment = StringAlignment.Near;
            StringFormat drawFormatRight = new StringFormat();
            drawFormatRight.Alignment = StringAlignment.Far;
            StringFormat drawFormatRightlest = new StringFormat();
            StringFormat format = new StringFormat(StringFormatFlags.DirectionRightToLeft);

            Graphics gra = e.Graphics;
            //titel       
            DateTime strDate = Convert.ToDateTime(DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToShortTimeString());
            e.Graphics.DrawString("Event Attendance Report", drawFontArial12Bold, drawBrush, new RectangleF(xs, ys, widths, heights), drawFormatCenter);
            ys += e.Graphics.MeasureString("Event Attendance Report", drawFontArial12Bold).Height;
            gra.DrawLine(drawingPen, 0, y, 314, y);

            DataTable dt = blea.GetallDataofattendance();
            if (dt.Rows.Count > 0)
            {
                gra.DrawString("Event Name: ", new System.Drawing.Font("Courier New ", 8, System.Drawing.FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 10, y);
                gra.DrawString(dt.Rows[0]["event_name"].ToString(), new System.Drawing.Font("Courier New ", 8, System.Drawing.FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 220, y); y = y + 16;


                gra.DrawString("Total Estimated Guest: ", new System.Drawing.Font("Courier New ", 8, System.Drawing.FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 10, y);
                gra.DrawString(dt.Rows[0]["total_guest"].ToString(), new System.Drawing.Font("Courier New ", 8, System.Drawing.FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 220, y); y = y + 16;
                gra.DrawString("Total Guest: ", new System.Drawing.Font("Courier New ", 8, System.Drawing.FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 10, y);
                gra.DrawString(dt.Rows[0]["total_no_guest"].ToString(), new System.Drawing.Font("Courier New ", 8, System.Drawing.FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 220, y); y = y + 16;
            }

        }
        int yinc = 0;
        int ybinc = 0;
        private void printDocument1s_PrintPagestart(object sender, PrintPageEventArgs e)
        {

            float xs = 10;
            float ys = 7;
            float widths = 285.0F; // max width I found through trial and error
            float heights = 0F;
            int y = 83;
            Pen drawingPen = new Pen(Color.Black, 1);
            Pen draw_watermark = new Pen(Color.FromArgb(64, Color.Black));
            Font drawFontArial12Bold = new Font("Arial", 12, System.Drawing.FontStyle.Bold);
            Font drawFontArial10Regular = new Font("Arial", 9, System.Drawing.FontStyle.Regular);
            Font drawFontArial10Regularsmall = new Font("Arial", 7, System.Drawing.FontStyle.Regular);
            SolidBrush drawBrush = new SolidBrush(Color.Black);

            // Set format of string.
            StringFormat drawFormatCenter = new StringFormat();
            drawFormatCenter.Alignment = StringAlignment.Center;
            StringFormat drawFormatLeft = new StringFormat();
            drawFormatLeft.Alignment = StringAlignment.Near;
            StringFormat drawFormatRight = new StringFormat();
            drawFormatRight.Alignment = StringAlignment.Far;
            StringFormat drawFormatRightlest = new StringFormat();
            StringFormat format = new StringFormat(StringFormatFlags.DirectionRightToLeft);
           
            Graphics gra = e.Graphics;
            //titel       
            DateTime strDate = Convert.ToDateTime(DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToShortTimeString());
            e.Graphics.DrawString("Event Token No.", drawFontArial12Bold, drawBrush, new RectangleF(xs, ys, widths, heights), drawFormatCenter);
            ys += e.Graphics.MeasureString("Event Token No.", drawFontArial12Bold).Height;
            e.Graphics.DrawString(token.ToString(), drawFontArial12Bold, drawBrush, new RectangleF(xs, ys, widths, heights), drawFormatCenter);
            ys += e.Graphics.MeasureString(token.ToString(), drawFontArial12Bold).Height;
            gra.DrawString("Date :", new System.Drawing.Font("minisystem", 8, System.Drawing.FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, y + ybinc + yinc);
            gra.DrawString(strDate.ToString(), new System.Drawing.Font("minisystem", 8, System.Drawing.FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 80, y + ybinc + yinc);
            y = y + 13;
            gra.DrawString("Username :", new System.Drawing.Font("minisystem", 8, System.Drawing.FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, y + ybinc + yinc);
            gra.DrawString(AdminAccess.username, new System.Drawing.Font("minisystem", 8, System.Drawing.FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 80, y + ybinc + yinc);
            y = y + 13;
       
          
            gra.DrawLine(drawingPen, 0, y, 314, y);

            DataTable dt = blea.GetallDataofattendance();
            if (dt.Rows.Count > 0)
            {
                gra.DrawString("Event Name: ", new System.Drawing.Font("Courier New ", 8, System.Drawing.FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 10, y);
                gra.DrawString(dt.Rows[0]["event_name"].ToString(), new System.Drawing.Font("Courier New ", 8, System.Drawing.FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 220, y); y = y + 16;
                gra.DrawString("Card No: ", new System.Drawing.Font("Courier New ", 8, System.Drawing.FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 10, y);
                gra.DrawString(txt_card_no.Text, new System.Drawing.Font("Courier New ", 8, System.Drawing.FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 220, y); y = y + 16;
                gra.DrawString("Token No. ", new System.Drawing.Font("Courier New ", 8, System.Drawing.FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 10, y);
                gra.DrawString(token.ToString(), new System.Drawing.Font("Courier New ", 8, System.Drawing.FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 220, y); y = y + 16;

            }

        }


        private void txt_card_no_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txt_card_no.Text.Length > 0 && txt_card_no.Text != "Card No" && txt_card_no.Text != "")
                {
                    DataTable dtm = blcde.getnamebyno(txt_card_no.Text);
                    if (dtm.Rows.Count > 0)
                    {
                        int customer_id = Convert.ToInt32(dtm.Rows[0]["id"]);
                        DataTable dt = blea.CardEventAttendanceCheck(txt_card_no.Text);
                        if (dt.Rows.Count == 0)
                        {
                            int insertCardAttendance = blea.InserCardAttendance(txt_card_no.Text, DateTime.Now, customer_id, Convert.ToInt32(cbo_event_type.SelectedValue));
                            txt_card_no.Text = "";
                        }
                        else
                        {
                            txt_card_no.Text = "";
                        }
                    }
                }
            }
        }

        private void btn_back_Click(object sender, EventArgs e)
        {

        }
    }
}
