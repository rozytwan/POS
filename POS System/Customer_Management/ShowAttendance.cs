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
    public partial class ShowAttendance : Form
    {
        public ShowAttendance()
        {
            InitializeComponent();
        }
        BLLS.Bll_mess_days.Bll_mess_dailyrecord Bllbmd = new BLLS.Bll_mess_days.Bll_mess_dailyrecord();
        Bll_customerMess_record cmrs = new Bll_customerMess_record();
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        String sun = "Sunday";
        String mon = "Monday";
        String tue = "Tuesday";
        String wed = "Wednesday";
        String thu = "Thursday";
        String fri = "Friday";
        String sat = "Saturday";
        string PushDate = DateTime.Now.Date.ToShortDateString();
        String status = "1";
        String nostatus = "0";
        String Packagename = "";

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbl_now.Text = DateTime.Now.ToLongDateString();
            lbl_time.Text = DateTime.Now.ToLongTimeString();
        }
        private void chk_bs_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_bs.Checked == true)
            { DataTable getRowbyDate = Bllbmd.getRowBYdatePush(PushDate,lbl_custoemrid.Text,sun,Packagename);

                if (getRowbyDate.Rows.Count>0) {
                    int i = Bllbmd.updatefrombreakfast(lbl_custoemrid.Text, sun, status,Packagename);
                }
                else {
                    if (Packagename.Length != 0)
                    {
                        int i = Bllbmd.insertintoBreakfast(lbl_custoemrid.Text, sun, PushDate, status, Packagename);
                    }
                }
            }
            else if (chk_bs.Checked == false) {
                AdminAccess accs = new AdminAccess();
                if (accs.ShowDialog() == DialogResult.OK)
                {
                   
                    accs.Admin_access_value = true;
                    int j = Bllbmd.updatefrombreakfast(lbl_custoemrid.Text, sun, nostatus, Packagename);
                    chk_bs.Checked = false;
                }
                else {
                    chk_bs.Checked = true;
                }
               
            }
           
        }

        private void chk_bm_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_bm.Checked == true)
            {
                DataTable getRowbyDate = Bllbmd.getRowBYdatePush(PushDate, lbl_custoemrid.Text, mon, Packagename);

                if (getRowbyDate.Rows.Count > 0)
                {
                    int i = Bllbmd.updatefrombreakfast(lbl_custoemrid.Text, mon, status, Packagename);
                }
                else
                {
                    if (Packagename.Length != 0)
                    {
                        int i = Bllbmd.insertintoBreakfast(lbl_custoemrid.Text, mon, PushDate, status, Packagename);
                    }
                }
            }
            else if (chk_bm.Checked == false)
            {
                AdminAccess accs = new AdminAccess();
                if (accs.ShowDialog() == DialogResult.OK)
                {
                    accs.Admin_access_value = true;
                    int j = Bllbmd.updatefrombreakfast(lbl_custoemrid.Text, mon, nostatus, Packagename);
                    chk_bm.Checked = false;
                }
                else {
                    chk_bm.Checked = true;
                }
            }

        }

        private void chk_bt_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_bt.Checked == true)
            {
                DataTable getRowbyDate = Bllbmd.getRowBYdatePush(PushDate, lbl_custoemrid.Text, tue, Packagename);

                if (getRowbyDate.Rows.Count > 0)
                {
                    int i = Bllbmd.updatefrombreakfast(lbl_custoemrid.Text, tue, status, Packagename);
                }
                else
                {
                    if (Packagename.Length != 0)
                    {
                        int i = Bllbmd.insertintoBreakfast(lbl_custoemrid.Text, tue, PushDate, status, Packagename);
                    }
                }
            }
            else if (chk_bt.Checked == false)
            {
                AdminAccess accs = new AdminAccess();
                if (accs.ShowDialog() == DialogResult.OK)
                {
                    accs.Admin_access_value = true;
                    int j = Bllbmd.updatefrombreakfast(lbl_custoemrid.Text, tue, nostatus, Packagename);
                    chk_bt.Checked = false;
                }
                else
                {
                    chk_bt.Checked = true;

                }
            }

        }

        private void chk_bw_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_bw.Checked == true)
            {
                DataTable getRowbyDate = Bllbmd.getRowBYdatePush(PushDate, lbl_custoemrid.Text, wed, Packagename);

                if (getRowbyDate.Rows.Count > 0)
                {
                    int i = Bllbmd.updatefrombreakfast(lbl_custoemrid.Text, wed, status, Packagename);
                }
                else
                {
                    if (Packagename.Length != 0)
                    {
                        int i = Bllbmd.insertintoBreakfast(lbl_custoemrid.Text, wed, PushDate, status, Packagename);
                    }
                }
            }
            else if (chk_bw.Checked == false)
            {
                AdminAccess accs = new AdminAccess();
                if (accs.ShowDialog() == DialogResult.OK)
                {
                    accs.Admin_access_value = true;
                    int j = Bllbmd.updatefrombreakfast(lbl_custoemrid.Text, wed, nostatus, Packagename);
                    chk_bw.Checked = false;
                }
                else {
                    chk_bw.Checked = true;
                }
            }

        }

        private void chk_bth_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_bth.Checked == true)
            {
                DataTable getRowbyDate = Bllbmd.getRowBYdatePush(PushDate, lbl_custoemrid.Text, thu, Packagename);

                if (getRowbyDate.Rows.Count > 0)
                {
                    int i = Bllbmd.updatefrombreakfast(lbl_custoemrid.Text, thu, status, Packagename);
                }
                else
                {
                    if (Packagename.Length != 0)
                    {
                        int i = Bllbmd.insertintoBreakfast(lbl_custoemrid.Text, thu, PushDate, status, Packagename);
                    }
                }
            }
            else if (chk_bth.Checked == false)
            {
                AdminAccess accs = new AdminAccess();
                if (accs.ShowDialog() == DialogResult.OK)
                {
                    accs.Admin_access_value = true;
                    int j = Bllbmd.updatefrombreakfast(lbl_custoemrid.Text, thu, nostatus, Packagename);
                    chk_bth.Checked = false;
                }
                else {
                    chk_bth.Checked = true;
                }
            }

        }

        private void chk_bfr_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_bfr.Checked == true)
            {
                DataTable getRowbyDate = Bllbmd.getRowBYdatePush(PushDate, lbl_custoemrid.Text, fri, Packagename);

                if (getRowbyDate.Rows.Count > 0)
                {
                    int i = Bllbmd.updatefrombreakfast(lbl_custoemrid.Text, fri, status, Packagename);
                }
                else
                {
                    if (Packagename.Length != 0)
                    {
                        int i = Bllbmd.insertintoBreakfast(lbl_custoemrid.Text, fri, PushDate, status, Packagename);
                    }
                }
            }
            else if (chk_bfr.Checked == false)
            {
                AdminAccess accs = new AdminAccess();
                if (accs.ShowDialog() == DialogResult.OK)
                {
                    accs.Admin_access_value = true;
                    int j = Bllbmd.updatefrombreakfast(lbl_custoemrid.Text, fri, nostatus, Packagename);
                    chk_bfr.Checked = false;
                }
                else {
                    chk_bfr.Checked = true;
                }
            }

        }

        private void chk_bsa_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_bsa.Checked == true)
            {
                DataTable getRowbyDate = Bllbmd.getRowBYdatePush(PushDate, lbl_custoemrid.Text, sat, Packagename);

                if (getRowbyDate.Rows.Count > 0)
                {
                    int i = Bllbmd.updatefrombreakfast(lbl_custoemrid.Text, sat, status, Packagename);
                }
                else
                {
                    if (Packagename.Length != 0)
                    {
                        int i = Bllbmd.insertintoBreakfast(lbl_custoemrid.Text, sat, PushDate, status, Packagename);
                    }
                }
            }
            else if (chk_bsa.Checked == false)
            {
                AdminAccess accs = new AdminAccess();
                if (accs.ShowDialog() == DialogResult.OK)
                {
                    accs.Admin_access_value = true;
                    int j = Bllbmd.updatefrombreakfast(lbl_custoemrid.Text, sat, nostatus, Packagename);
                    chk_bsa.Checked = false;
                }
                else {
                    chk_bsa.Checked = true;

                }
            }
        }

        private void ShowAttendance_Load(object sender, EventArgs e)
        {
            Packagename = lbl_package.Text;
            Bllbmd.deletestatusZerobreakfast();
            Bllbmd.deletestatusZerodinner();
            Bllbmd.deletestatusZerolunch();
            Bllbmd.deletestatusZerosnacks();

        }

        private void chk_ls_CheckedChanged(object sender, EventArgs e)
    {
        if (chk_ls.Checked == true)
        {
            DataTable getRowbyDate = Bllbmd.getRowBYdatePushlunch(PushDate, lbl_custoemrid.Text, sun, Packagename);

            if (getRowbyDate.Rows.Count > 0)
            {
                int i = Bllbmd.updatefroLunch(lbl_custoemrid.Text, sun, status, Packagename);
            }
            else
                {
                    if (Packagename.Length != 0)
                    {
                        int i = Bllbmd.insertintoLunch(lbl_custoemrid.Text, sun, PushDate, status, Packagename);
                    }
            }
        }
        else if (chk_ls.Checked == false)
        {
                AdminAccess accs = new AdminAccess();
                if (accs.ShowDialog() == DialogResult.OK)
                {
                    accs.Admin_access_value = true;
                    int j = Bllbmd.updatefroLunch(lbl_custoemrid.Text, sun, nostatus, Packagename);
                    chk_ls.Checked = false;
                }
                else {
                    chk_ls.Checked = true;
                }
        }
        }

        private void chk_lm_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_lm.Checked == true)
            {
                DataTable getRowbyDate = Bllbmd.getRowBYdatePushlunch(PushDate, lbl_custoemrid.Text, mon, Packagename);

                if (getRowbyDate.Rows.Count > 0)
                {
                    int i = Bllbmd.updatefroLunch(lbl_custoemrid.Text, mon, status, Packagename);
                }
                else
                {
                    if (Packagename.Length != 0)
                    {
                        int i = Bllbmd.insertintoLunch(lbl_custoemrid.Text, mon, PushDate, status, Packagename);
                    }
                }
            }
            else if (chk_lm.Checked == false)
            {

                AdminAccess accs = new AdminAccess();
                if (accs.ShowDialog() == DialogResult.OK)
                {
                    accs.Admin_access_value = true;
                    int j = Bllbmd.updatefroLunch(lbl_custoemrid.Text, mon, nostatus, Packagename);
                    chk_lm.Checked = false;
                }
                else {
                    chk_lm.Checked = true;
                }
            }
        }

        private void chk_lt_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_lt.Checked == true)
            {
                DataTable getRowbyDate = Bllbmd.getRowBYdatePushlunch(PushDate, lbl_custoemrid.Text, tue, Packagename);

                if (getRowbyDate.Rows.Count > 0)
                {
                    int i = Bllbmd.updatefroLunch(lbl_custoemrid.Text, tue, status, Packagename);
                }
                else
                {
                    if (Packagename.Length != 0)
                    {
                        int i = Bllbmd.insertintoLunch(lbl_custoemrid.Text, tue, PushDate, status, Packagename);
                    }
                }
            }
            else if (chk_lt.Checked == false)
            {
                AdminAccess accs = new AdminAccess();
                if (accs.ShowDialog() == DialogResult.OK)
                {
                    accs.Admin_access_value = true;
                    int j = Bllbmd.updatefroLunch(lbl_custoemrid.Text, tue, nostatus, Packagename);
                    chk_lt.Checked = false;
                }
                else {
                    chk_lt.Checked = true;
                }
            }
        }

        private void chk_lw_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_lw.Checked == true)
            {
                DataTable getRowbyDate = Bllbmd.getRowBYdatePushlunch(PushDate, lbl_custoemrid.Text, wed, Packagename);

                if (getRowbyDate.Rows.Count > 0)
                {
                    int i = Bllbmd.updatefroLunch(lbl_custoemrid.Text, wed, status, Packagename);
                }
                else
                {
                    if (Packagename.Length != 0)
                    {
                        int i = Bllbmd.insertintoLunch(lbl_custoemrid.Text, wed, PushDate, status, Packagename);
                    }
                }
            }
            else if (chk_lw.Checked == false)
            {
                AdminAccess accs = new AdminAccess();
                if (accs.ShowDialog() == DialogResult.OK)
                {
                    accs.Admin_access_value = true;
                    int j = Bllbmd.updatefroLunch(lbl_custoemrid.Text, wed, nostatus, Packagename);
                    chk_lw.Checked = false;
                }
                else {
                    chk_lw.Checked = true;
                }
            }
        }

        private void chk_lth_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_lth.Checked == true)
            {
                DataTable getRowbyDate = Bllbmd.getRowBYdatePushlunch(PushDate, lbl_custoemrid.Text, thu, Packagename);

                if (getRowbyDate.Rows.Count > 0)
                {
                    int i = Bllbmd.updatefroLunch(lbl_custoemrid.Text, thu, status, Packagename);
                }
                else
                {
                    if (Packagename.Length != 0)
                    {
                        int i = Bllbmd.insertintoLunch(lbl_custoemrid.Text, thu, PushDate, status, Packagename);
                    }
                }
            }
            else if (chk_lth.Checked == false)
            {
                AdminAccess accs = new AdminAccess();
                if (accs.ShowDialog() == DialogResult.OK)
                {
                    accs.Admin_access_value = true;
                    int j = Bllbmd.updatefroLunch(lbl_custoemrid.Text, thu, nostatus, Packagename);
                    chk_lth.Checked = false;
                }
                else {
                    chk_lth.Checked = true;
                }
            }
        }

        private void chk_lfr_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_lfr.Checked == true)
            {
                DataTable getRowbyDate = Bllbmd.getRowBYdatePushlunch(PushDate, lbl_custoemrid.Text, fri, Packagename);

                if (getRowbyDate.Rows.Count > 0)
                {
                    int i = Bllbmd.updatefroLunch(lbl_custoemrid.Text, fri, status, Packagename);
                }
                else
                {
                    if (Packagename.Length != 0)
                    {
                        int i = Bllbmd.insertintoLunch(lbl_custoemrid.Text, fri, PushDate, status, Packagename);
                    }
                }
            }
            else if (chk_lfr.Checked == false)
            {
                AdminAccess accs = new AdminAccess();
                if (accs.ShowDialog() == DialogResult.OK)
                {
                    accs.Admin_access_value = true;
                    int j = Bllbmd.updatefroLunch(lbl_custoemrid.Text, fri, nostatus, Packagename);
                    chk_lfr.Checked = false;
                }
                else {
                    chk_lfr.Checked = true;
                }
            }
        }

        private void chk_lsa_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_lsa.Checked == true)
            {
                DataTable getRowbyDate = Bllbmd.getRowBYdatePushlunch(PushDate, lbl_custoemrid.Text, sat, Packagename);

                if (getRowbyDate.Rows.Count > 0)
                {
                    int i = Bllbmd.updatefroLunch(lbl_custoemrid.Text, sat, status, Packagename);
                }
                else
                {
                    if (Packagename.Length != 0)
                    {
                        int i = Bllbmd.insertintoLunch(lbl_custoemrid.Text, sat, PushDate, status, Packagename);
                    }
                }
            }
            else if (chk_lsa.Checked == false)
            {
                AdminAccess accs = new AdminAccess();
                if (accs.ShowDialog() == DialogResult.OK)
                {
                    accs.Admin_access_value = true;
                    int j = Bllbmd.updatefroLunch(lbl_custoemrid.Text, sat, nostatus, Packagename);
                    chk_lsa.Checked = false;
                }
                else
                {

                    chk_lsa.Checked = true;
                }
            }
        }

        private void chk_sns_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_sns.Checked == true)
            {
                DataTable getRowbyDate = Bllbmd.getRowBYdatePushsnacks(PushDate, lbl_custoemrid.Text, sun, Packagename);

                if (getRowbyDate.Rows.Count > 0)
                {
                    int i = Bllbmd.updatefrosnacks(lbl_custoemrid.Text, sun, status, Packagename);
                }
                else
                {
                    if (Packagename.Length != 0)
                    {
                        int i = Bllbmd.insertintosnacks(lbl_custoemrid.Text, sun, PushDate, status, Packagename);
                    }
                }
            }
            else if (chk_sns.Checked == false)
            {
                AdminAccess accs = new AdminAccess();
                if (accs.ShowDialog() == DialogResult.OK)
                {
                    accs.Admin_access_value = true;
                    int j = Bllbmd.updatefrosnacks(lbl_custoemrid.Text, sun, nostatus, Packagename);
                    chk_sns.Checked = false;
                }
                else {
                    chk_sns.Checked = true;
                }
            }
        }

        private void chk_sm_CheckedChanged(object sender, EventArgs e)
        {

            if (chk_sm.Checked == true)
            {
                DataTable getRowbyDate = Bllbmd.getRowBYdatePushsnacks(PushDate, lbl_custoemrid.Text, mon, Packagename);

                if (getRowbyDate.Rows.Count > 0)
                {
                    int i = Bllbmd.updatefrosnacks(lbl_custoemrid.Text, mon, status, Packagename);
                }
                else
                {
                    if (Packagename.Length != 0)
                    {
                        int i = Bllbmd.insertintosnacks(lbl_custoemrid.Text, mon, PushDate, status, Packagename);
                    }
                }
            }
            else if (chk_sm.Checked == false)
            {
                AdminAccess accs = new AdminAccess();
                if (accs.ShowDialog() == DialogResult.OK)
                {
                    accs.Admin_access_value = true;
                    int j = Bllbmd.updatefrosnacks(lbl_custoemrid.Text, mon, nostatus, Packagename);
                    chk_sm.Checked = false;
                }
                else {
                    chk_sm.Checked = true;
                }
            }
        }

        private void chk_snt_CheckedChanged(object sender, EventArgs e)
        {

            if (chk_snt.Checked == true)
            {
                DataTable getRowbyDate = Bllbmd.getRowBYdatePushsnacks(PushDate, lbl_custoemrid.Text, tue, Packagename);

                if (getRowbyDate.Rows.Count > 0)
                {
                    int i = Bllbmd.updatefrosnacks(lbl_custoemrid.Text, tue, status, Packagename);
                }
                else
                {
                    if (Packagename.Length != 0)
                    {
                        int i = Bllbmd.insertintosnacks(lbl_custoemrid.Text, tue, PushDate, status, Packagename);
                    }
                }
            }
            else if (chk_snt.Checked == false)
            {
                AdminAccess accs = new AdminAccess();
                if (accs.ShowDialog() == DialogResult.OK)
                {
                    accs.Admin_access_value = true;
                    int j = Bllbmd.updatefrosnacks(lbl_custoemrid.Text, tue, nostatus, Packagename);
                    chk_snt.Checked = false;
                }
                else {
                    chk_snt.Checked = true;
                }
            }
        }

        private void chk_snw_CheckedChanged(object sender, EventArgs e)
        {

            if (chk_snw.Checked == true)
            {
                DataTable getRowbyDate = Bllbmd.getRowBYdatePushsnacks(PushDate, lbl_custoemrid.Text, wed, Packagename);

                if (getRowbyDate.Rows.Count > 0)
                {
                    int i = Bllbmd.updatefrosnacks(lbl_custoemrid.Text, wed, status, Packagename);
                }
                else
                {
                    if (Packagename.Length != 0)
                    {
                        int i = Bllbmd.insertintosnacks(lbl_custoemrid.Text, wed, PushDate, status, Packagename);
                    }
                }
            }
            else if (chk_snw.Checked == false)
            {
                AdminAccess accs = new AdminAccess();
                if (accs.ShowDialog() == DialogResult.OK)
                {
                    accs.Admin_access_value = true;
                    int j = Bllbmd.updatefrosnacks(lbl_custoemrid.Text, wed, nostatus, Packagename);
                    chk_snw.Checked = false;
                }
                else {
                    chk_snw.Checked = true;
                }
            }
        }

        private void chk_snth_CheckedChanged(object sender, EventArgs e)
        {

            if (chk_snth.Checked == true)
            {
                DataTable getRowbyDate = Bllbmd.getRowBYdatePushsnacks(PushDate, lbl_custoemrid.Text, thu, Packagename);

                if (getRowbyDate.Rows.Count > 0)
                {
                    int i = Bllbmd.updatefrosnacks(lbl_custoemrid.Text, thu, status, Packagename);
                }
                else
                {
                    if (Packagename.Length != 0)
                    {
                        int i = Bllbmd.insertintosnacks(lbl_custoemrid.Text, thu, PushDate, status, Packagename);
                    }
                }
            }
            else if (chk_snth.Checked == false)
            {
                AdminAccess accs = new AdminAccess();
                if (accs.ShowDialog() == DialogResult.OK)
                {
                    accs.Admin_access_value = true;
                    int j = Bllbmd.updatefrosnacks(lbl_custoemrid.Text, thu, nostatus, Packagename);
                    chk_snth.Checked = false;
                }
                else {
                    chk_snth.Checked = true;
                }
            }
        }

        private void chk_snbr_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_snbr.Checked == true)
            {
                DataTable getRowbyDate = Bllbmd.getRowBYdatePushsnacks(PushDate, lbl_custoemrid.Text, fri, Packagename);

                if (getRowbyDate.Rows.Count > 0)
                {
                    int i = Bllbmd.updatefrosnacks(lbl_custoemrid.Text, fri, status, Packagename);
                }
                else
                {
                    if (Packagename.Length != 0)
                    {
                        int i = Bllbmd.insertintosnacks(lbl_custoemrid.Text, fri, PushDate, status, Packagename);
                    }
                }
            }
            else if (chk_snbr.Checked == false)
            {
                AdminAccess accs = new AdminAccess();
                if (accs.ShowDialog() == DialogResult.OK)
                {
                    accs.Admin_access_value = true;
                  
                    int j = Bllbmd.updatefrosnacks(lbl_custoemrid.Text, fri, nostatus, Packagename);
                    chk_snbr.Checked = false;
                }
                else {
                    chk_snbr.Checked = true;
                }
            }
        }

        private void chk_snsa_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_snsa.Checked == true)
            {
                DataTable getRowbyDate = Bllbmd.getRowBYdatePushsnacks(PushDate, lbl_custoemrid.Text, sat, Packagename);

                if (getRowbyDate.Rows.Count > 0)
                {
                    int i = Bllbmd.updatefrosnacks(lbl_custoemrid.Text, sat, status, Packagename);
                }
                else
                {
                    if (Packagename.Length != 0)
                    {
                        int i = Bllbmd.insertintosnacks(lbl_custoemrid.Text, sat, PushDate, status, Packagename);
                    }
                }
            }
            else if (chk_snsa.Checked == false)
            {
                AdminAccess accs = new AdminAccess();
                if (accs.ShowDialog() == DialogResult.OK)
                {
                    accs.Admin_access_value = true;
                    int j = Bllbmd.updatefrosnacks(lbl_custoemrid.Text, sat, nostatus, Packagename);
                    chk_snsa.Checked = false;
                }
                else {
                    chk_snsa.Checked = true;
                }
            }
        }

        private void chk_ds_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_ds.Checked == true)
            {
                DataTable getRowbyDate = Bllbmd.getRowBYdatePushdinner(PushDate, lbl_custoemrid.Text, sun, Packagename);

                if (getRowbyDate.Rows.Count > 0)
                {
                    int i = Bllbmd.updatefrodinnner(lbl_custoemrid.Text, sun, status, Packagename);
                }
                else
                {
                    if (Packagename.Length != 0)
                    {
                        int i = Bllbmd.insertintodinnner(lbl_custoemrid.Text, sun, PushDate, status, Packagename);
                    }
                }
            }
            else if (chk_ds.Checked == false)
            {
                AdminAccess accs = new AdminAccess();
                if (accs.ShowDialog() == DialogResult.OK)
                {
                    accs.Admin_access_value = true;
                    int j = Bllbmd.updatefrodinnner(lbl_custoemrid.Text, sun, nostatus, Packagename);
                    chk_ds.Checked = false;
                }
                else {
                    chk_ds.Checked = true;
                }
            }
        }

        private void chk_dm_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_dm.Checked == true)
            {
                DataTable getRowbyDate = Bllbmd.getRowBYdatePushdinner(PushDate, lbl_custoemrid.Text, mon, Packagename);

                if (getRowbyDate.Rows.Count > 0)
                {
                    int i = Bllbmd.updatefrodinnner(lbl_custoemrid.Text, mon, status, Packagename);
                }
                else
                {
                    if (Packagename.Length != 0)
                    {
                        int i = Bllbmd.insertintodinnner(lbl_custoemrid.Text, mon, PushDate, status, Packagename);
                    }
                }
            }
            else if (chk_dm.Checked == false)
            {
                AdminAccess accs = new AdminAccess();
                if (accs.ShowDialog() == DialogResult.OK)
                {
                    accs.Admin_access_value = true;
                    int j = Bllbmd.updatefrodinnner(lbl_custoemrid.Text, mon, nostatus, Packagename);
                    chk_dm.Checked = false;
                }
                else {
                    chk_dm.Checked = true;
                }
            }
        }

        private void chk_dt_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_dt.Checked == true)
            {
                DataTable getRowbyDate = Bllbmd.getRowBYdatePushdinner(PushDate, lbl_custoemrid.Text, tue, Packagename);

                if (getRowbyDate.Rows.Count > 0)
                {
                    int i = Bllbmd.updatefrodinnner(lbl_custoemrid.Text, tue, status, Packagename);
                }
                else
                {
                    if (Packagename.Length != 0)
                    {
                        int i = Bllbmd.insertintodinnner(lbl_custoemrid.Text, tue, PushDate, status, Packagename);
                    }
                }
            }
            else if (chk_dt.Checked == false)
            {
                AdminAccess accs = new AdminAccess();
                if (accs.ShowDialog() == DialogResult.OK)
                {
                    accs.Admin_access_value = true;
                    int j = Bllbmd.updatefrodinnner(lbl_custoemrid.Text, tue, nostatus, Packagename);
                    chk_dt.Checked = false;
                }
                else {
                    chk_dt.Checked = true;
                }
            }
        }

        private void chk_dw_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_dw.Checked == true)
            {
                DataTable getRowbyDate = Bllbmd.getRowBYdatePushdinner(PushDate, lbl_custoemrid.Text, wed, Packagename);

                if (getRowbyDate.Rows.Count > 0)
                {
                    int i = Bllbmd.updatefrodinnner(lbl_custoemrid.Text, wed, status, Packagename);
                }
                else
                {
                    if (Packagename.Length != 0)
                    {
                        int i = Bllbmd.insertintodinnner(lbl_custoemrid.Text, wed, PushDate, status, Packagename);
                    }
                }
            }
            else if (chk_dw.Checked == false)
            {
                AdminAccess accs = new AdminAccess();
                if (accs.ShowDialog() == DialogResult.OK)
                {
                    accs.Admin_access_value = true;
                    int j = Bllbmd.updatefrodinnner(lbl_custoemrid.Text, wed, nostatus, Packagename);
                    chk_dw.Checked = false;
                }
                else {
                    chk_dw.Checked = true;
                }
            }
        }

        private void chk_dth_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_dth.Checked == true)
            {
                DataTable getRowbyDate = Bllbmd.getRowBYdatePushdinner(PushDate, lbl_custoemrid.Text, thu, Packagename);

                if (getRowbyDate.Rows.Count > 0)
                {
                    int i = Bllbmd.updatefrodinnner(lbl_custoemrid.Text, thu, status, Packagename);
                }
                else
                {
                    if (Packagename.Length != 0)
                    {
                        int i = Bllbmd.insertintodinnner(lbl_custoemrid.Text, thu, PushDate, status, Packagename);
                    }
                }
            }
            else if (chk_dth.Checked == false)
            {
                AdminAccess accs = new AdminAccess();
                if (accs.ShowDialog() == DialogResult.OK)
                {
                    accs.Admin_access_value = true;
                    int j = Bllbmd.updatefrodinnner(lbl_custoemrid.Text, thu, nostatus, Packagename);
                    chk_dth.Checked = false;
                }
                else {
                    chk_dth.Checked = true;
                }
            }
        }

        private void chk_dfr_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_dfr.Checked == true)
            {
                DataTable getRowbyDate = Bllbmd.getRowBYdatePushdinner(PushDate, lbl_custoemrid.Text, fri, Packagename);

                if (getRowbyDate.Rows.Count > 0)
                {
                    int i = Bllbmd.updatefrodinnner(lbl_custoemrid.Text, fri, status, Packagename);
                }
                else
                {
                    if (Packagename.Length != 0)
                    {
                        int i = Bllbmd.insertintodinnner(lbl_custoemrid.Text, fri, PushDate, status, Packagename);
                    }
                }
            }
            else if (chk_dfr.Checked == false)
            {
                AdminAccess accs = new AdminAccess();
                if (accs.ShowDialog() == DialogResult.OK)
                {
                    accs.Admin_access_value = true;
                    int j = Bllbmd.updatefrodinnner(lbl_custoemrid.Text, fri, nostatus, Packagename);
                    chk_dfr.Checked = false;
                }
                else {
                    chk_dfr.Checked = true;
                }
            }
        }

        private void chk_dsat_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_dsat.Checked == true)
            {
                DataTable getRowbyDate = Bllbmd.getRowBYdatePushdinner(PushDate, lbl_custoemrid.Text, sat, Packagename);

                if (getRowbyDate.Rows.Count > 0)
                {
                    int i = Bllbmd.updatefrodinnner(lbl_custoemrid.Text, sat, status, Packagename);
                }
                else
                {
                    if (Packagename.Length != 0)
                    {
                        int i = Bllbmd.insertintodinnner(lbl_custoemrid.Text, sat, PushDate, status, Packagename);
                    }
                }
            }
            else if (chk_dsat.Checked == false)
            {
                AdminAccess accs = new AdminAccess();
                if (accs.ShowDialog() == DialogResult.OK)
                {
                    accs.Admin_access_value = true;
                    int j = Bllbmd.updatefrodinnner(lbl_custoemrid.Text, sat, nostatus, Packagename);
                    chk_dsat.Checked = false;
                }
                else {
                    chk_dsat.Checked = true;
                }
            }
        }

        private void lbl_custoemrid_TextChanged(object sender, EventArgs e)
        {
            String[] weekdays = new string[] {
                "Sunday",
                "Monday",
                "Tuesday",
                "Wednesday",
                "Thursday",
                "Friday",
                "Saturday"
            };
            for (int i = 0; i < weekdays.Length; i++)
            {
                string datestring = PushDate;
                DataTable getdaysdata = Bllbmd.getRowBYdatePush(datestring, lbl_custoemrid.Text,weekdays[i], lbl_package.Text);
                if (getdaysdata.Rows.Count > 0)
                {
                    if (weekdays[i].ToString() == "Sunday")
                    {
                        chk_bs.Checked = true;
                    }

                    if (weekdays[i].ToString() == "Monday")
                    {
                        chk_bm.Checked = true;
                    }

                    if (weekdays[i].ToString() == "Tuesday")
                    {
                        chk_bt.Checked = true;
                    }
                    if (weekdays[i].ToString() == "Wednesday")
                    {
                        chk_bw.Checked = true;
                    }
                    if (weekdays[i].ToString() == "Thursday")
                    {
                        chk_bth.Checked = true;
                    }
                    if (weekdays[i].ToString() == "Friday")
                    {
                        chk_bfr.Checked = true;
                    }
                    if (weekdays[i].ToString() == "Saturday")
                    {
                        chk_bsa.Checked = true;
                    }
                } //end of datatable


                //lunch begining

                DataTable getallBylunch = Bllbmd.getRowBYdatePushlunch(datestring, lbl_custoemrid.Text, weekdays[i], lbl_package.Text);
                if (getallBylunch.Rows.Count > 0)
                {
                    if (weekdays[i].ToString() == "Sunday")
                    {
                        chk_ls.Checked = true;
                    }

                    if (weekdays[i].ToString() == "Monday")
                    {
                        chk_lm.Checked = true;
                    }

                    if (weekdays[i].ToString() == "Tuesday")
                    {
                        chk_lt.Checked = true;
                    }
                    if (weekdays[i].ToString() == "Wednesday")
                    {
                        chk_lw.Checked = true;
                    }
                    if (weekdays[i].ToString() == "Thursday")
                    {
                        chk_lth.Checked = true;
                    }
                    if (weekdays[i].ToString() == "Friday")
                    {
                        chk_lfr.Checked = true;
                    }
                    if (weekdays[i].ToString() == "Saturday")
                    {
                        chk_lsa.Checked = true;
                    }
                } //end of datatable
                
                  //begining snacks
                DataTable getallBysnacks = Bllbmd.getRowBYdatePushsnacks(datestring, lbl_custoemrid.Text, weekdays[i], lbl_package.Text);
                if (getallBysnacks.Rows.Count > 0)
                {
                    if (weekdays[i].ToString() == "Sunday")
                    {
                        chk_sns.Checked = true;
                    }

                    if (weekdays[i].ToString() == "Monday")
                    {
                        chk_sm.Checked = true;
                    }

                    if (weekdays[i].ToString() == "Tuesday")
                    {
                        chk_snt.Checked = true;
                    }
                    if (weekdays[i].ToString() == "Wednesday")
                    {
                        chk_snw.Checked = true;
                    }
                    if (weekdays[i].ToString() == "Thursday")
                    {
                        chk_snth.Checked = true;
                    }
                    if (weekdays[i].ToString() == "Friday")
                    {
                        chk_snbr.Checked = true;
                    }
                    if (weekdays[i].ToString() == "Saturday")
                    {
                        chk_snsa.Checked = true;
                    }
                } //end of datatable

                //begining of dinner

                //begining snacks
                DataTable getallByDinners = Bllbmd.getRowBYdatePushdinner(datestring, lbl_custoemrid.Text, weekdays[i], lbl_package.Text);
                if (getallByDinners.Rows.Count > 0)
                {
                    if (weekdays[i].ToString() == "Sunday")
                    {
                        chk_ds.Checked = true;
                    }

                    if (weekdays[i].ToString() == "Monday")
                    {
                        chk_dm.Checked = true;
                    }

                    if (weekdays[i].ToString() == "Tuesday")
                    {
                        chk_dt.Checked = true;
                    }
                    if (weekdays[i].ToString() == "Wednesday")
                    {
                        chk_dw.Checked = true;
                    }
                    if (weekdays[i].ToString() == "Thursday")
                    {
                        chk_dth.Checked = true;
                    }
                    if (weekdays[i].ToString() == "Friday")
                    {
                        chk_dfr.Checked = true;
                    }
                    if (weekdays[i].ToString() == "Saturday")
                    {
                        chk_dsat.Checked = true;
                    }
                } //end of datatable
            }
        }
      
        private void btn_sun_Click(object sender, EventArgs e)
        {
            xtraform addup = new xtraform();
            addup.lbl_id.Text = lbl_custoemrid.Text;
            addup.lbl_day.Text = sun;
            addup.lbl_date.Text = PushDate;
            addup.lbl_name.Text = lbl_Fullname.Text;
            addup.lbl_package.Text = lbl_package.Text;
            addup.ShowDialog();


            

        }

        private void btn_mon_Click(object sender, EventArgs e)
        {
            xtraform addup = new xtraform();
            addup.lbl_id.Text = lbl_custoemrid.Text;
            addup.lbl_day.Text = mon;
            addup.lbl_date.Text = PushDate;
            addup.lbl_name.Text = lbl_Fullname.Text;
            addup.lbl_package.Text = lbl_package.Text;
            addup.ShowDialog();
        }

        private void btn_tue_Click(object sender, EventArgs e)
        {
            xtraform addup = new xtraform();
            addup.lbl_id.Text = lbl_custoemrid.Text;
            addup.lbl_day.Text = tue;
            addup.lbl_date.Text = PushDate;
            addup.lbl_name.Text = lbl_Fullname.Text;
            addup.lbl_package.Text = lbl_package.Text;
            addup.ShowDialog();
        }

        private void btn_wed_Click(object sender, EventArgs e)
        {
            xtraform addup = new xtraform();
            addup.lbl_id.Text = lbl_custoemrid.Text;
            addup.lbl_day.Text = wed;
            addup.lbl_date.Text = PushDate;
            addup.lbl_name.Text = lbl_Fullname.Text;
            addup.lbl_package.Text = lbl_package.Text;
            addup.ShowDialog();
        }

        private void btn_thu_Click(object sender, EventArgs e)
        {
            xtraform addup = new xtraform();
            addup.lbl_id.Text = lbl_custoemrid.Text;
            addup.lbl_day.Text = thu;
            addup.lbl_date.Text = PushDate;
            addup.lbl_name.Text = lbl_Fullname.Text;
            addup.lbl_package.Text = lbl_package.Text;
            addup.ShowDialog();
        }

        private void btn_fri_Click(object sender, EventArgs e)
        {
            xtraform addup = new xtraform();
            addup.lbl_id.Text = lbl_custoemrid.Text;
            addup.lbl_day.Text = fri;
            addup.lbl_date.Text = PushDate;
            addup.lbl_name.Text = lbl_Fullname.Text;
            addup.lbl_package.Text = lbl_package.Text;
            addup.ShowDialog();
        }

        private void btn_sat_Click(object sender, EventArgs e)
        {
            xtraform addup = new xtraform();
            addup.lbl_id.Text = lbl_custoemrid.Text;
            addup.lbl_day.Text = sat;
            addup.lbl_date.Text = PushDate;
            addup.lbl_name.Text = lbl_Fullname.Text;
            addup.lbl_package.Text = lbl_package.Text;
            addup.ShowDialog();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
