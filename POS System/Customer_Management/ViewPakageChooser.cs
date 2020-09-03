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
namespace POS_System.Customer_Management
{
    public partial class ViewPakageChooser : UserControl
    {
        public ViewPakageChooser()
        {
            InitializeComponent();
        }
        bll_customer_mess bllmess = new bll_customer_mess();
        blllCustomerDetailednyo bllcus = new blllCustomerDetailednyo();
        BLLS.Bll_mess_days.bll_breakfast Bllbreakfast = new BLLS.Bll_mess_days.bll_breakfast();

        private void ViewPakageChooser_Load(object sender, EventArgs e)
        {
            loadallPakages();
            loadAllPakagesCustomers();
            loaddallpakageslist();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        public void loadAllPakagesCustomers()
        {
            try
            {
                DataTable getaallpakages = bllmess.getallPakagesLists();

                if (getaallpakages.Rows.Count > 0)
                {
                    dgv_customers.Rows.Clear();
                    for (int i = 0; i < getaallpakages.Rows.Count; i++)
                    {
                        DataTable getallcustomer = bllcus.getallcustomersbyPakages(getaallpakages.Rows[i]["name"].ToString());
                        if (getallcustomer.Rows.Count > 0)
                        {
                            for (int j = 0; j < getallcustomer.Rows.Count; j++)
                            {
                                dgv_customers.Rows.Add(getallcustomer.Rows[j]["id"].ToString(), getallcustomer.Rows[j]["name"].ToString(), getallcustomer.Rows[j]["lastname"].ToString(), getallcustomer.Rows[j]["gender"].ToString(), getallcustomer.Rows[j]["pakage_name"].ToString());
                            }

                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void loadallPakages()
        {
            DataTable dtst = bllmess.getallPakagesLists();
            if (dtst.Rows.Count > 0)
            {
                flp_pakages.Controls.Clear();
                for (int i = 0; i < dtst.Rows.Count; i++)
                {
                    Button[] itembutton = new Button[dtst.Rows.Count];
                    itembutton[i] = new Button();
                    itembutton[i].Name = dtst.Rows[i]["pg_id"].ToString();
                    itembutton[i].Text = dtst.Rows[i]["name"].ToString();
                    itembutton[i].Height = 60;
                    itembutton[i].Width = 240;
                    itembutton[i].Font = new Font("", 14, FontStyle.Bold);
                    itembutton[i].BackColor = Color.Azure;
                    itembutton[i].ForeColor = Color.Black;
                    itembutton[i].ContextMenuStrip = getcontextMenuStrip;
                    itembutton[i].Click += new EventHandler(this.pakage_Click);
                    flp_pakages.Controls.Add(itembutton[i]);
                }
            }
        }
        String PushPakageName;
        public void pakage_Click(object sender, EventArgs m)
        {
            MessPakageChooser mpc = new MessPakageChooser();
            PushPakageName = ((Button)sender).Text;
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

                DataTable getallsunday = Bllbreakfast.getallBreakfastsforfromPakage(PushPakageName, weekdays[i].ToString());
                if (getallsunday.Rows.Count > 0)
                {

                    for (int sun = 0; sun < getallsunday.Rows.Count; sun++)
                    {
                        Label[] sunLabels = new Label[getallsunday.Rows.Count];
                        sunLabels[sun] = new Label();
                        sunLabels[sun].Name = getallsunday.Rows[sun]["br_id"].ToString();
                        sunLabels[sun].Text = getallsunday.Rows[sun]["itemname"].ToString();
                        sunLabels[sun].Height = 30;
                        sunLabels[sun].Width = 70;
                        sunLabels[sun].Font = new Font("", 10, FontStyle.Bold);
                        sunLabels[sun].ForeColor = Color.Black;


                        if (weekdays[i].ToString() == "Sunday")
                        {
                            mpc.flp_breakfast_sunday.Controls.Add(sunLabels[sun]);
                            mpc.flp_breakfast_sunday.HorizontalScroll.Visible = false;
                        }

                        if (weekdays[i].ToString() == "Monday")
                        {
                            mpc.flp_breakfast_mon.Controls.Add(sunLabels[sun]);
                            mpc.flp_breakfast_mon.HorizontalScroll.Visible = false;
                        }
                        if (weekdays[i].ToString() == "Tuesday")
                        {
                            mpc.flp_breakfast_tue.Controls.Add(sunLabels[sun]);
                            mpc.flp_breakfast_tue.HorizontalScroll.Visible = false;
                        }

                        if (weekdays[i].ToString() == "Wednesday")
                        {
                            mpc.flp_breakfast_wed.Controls.Add(sunLabels[sun]);
                            mpc.flp_breakfast_wed.HorizontalScroll.Visible = false;
                        }
                        if (weekdays[i].ToString() == "Thursday")
                        {
                            mpc.flp_breakfast_thur.Controls.Add(sunLabels[sun]);
                            mpc.flp_breakfast_thur.HorizontalScroll.Visible = false;
                        }
                        if (weekdays[i].ToString() == "Friday")
                        {
                            mpc.flp_breakfast_fri.Controls.Add(sunLabels[sun]);
                            mpc.flp_breakfast_fri.HorizontalScroll.Visible = false;
                        }
                        if (weekdays[i].ToString() == "Saturday")
                        {
                            mpc.flp_break_sat.Controls.Add(sunLabels[sun]);
                            mpc.flp_break_sat.HorizontalScroll.Visible = false;
                        }
                    }
                }
                //breakfast finish
                DataTable getallLunch = Bllbreakfast.getallLunchforfromPakage(PushPakageName, weekdays[i].ToString());
                if (getallLunch.Rows.Count > 0)
                {

                    for (int sun = 0; sun < getallLunch.Rows.Count; sun++)
                    {
                        Label[] sunLabels = new Label[getallLunch.Rows.Count];
                        sunLabels[sun] = new Label();
                        sunLabels[sun].Name = getallLunch.Rows[sun]["br_id"].ToString();
                        sunLabels[sun].Text = getallLunch.Rows[sun]["itemname"].ToString();
                        sunLabels[sun].Height = 30;
                        sunLabels[sun].Width = 70;
                        sunLabels[sun].Font = new Font("", 10, FontStyle.Bold);
                        sunLabels[sun].ForeColor = Color.Black;


                        if (weekdays[i].ToString() == "Sunday")
                        {
                            mpc.flp_lunch_sun.Controls.Add(sunLabels[sun]);
                        }

                        if (weekdays[i].ToString() == "Monday")
                        {
                            mpc.flp_lunch_mon.Controls.Add(sunLabels[sun]);
                        }
                        if (weekdays[i].ToString() == "Tuesday")
                        {
                            mpc.flp_lunch_tue.Controls.Add(sunLabels[sun]);
                        }

                        if (weekdays[i].ToString() == "Wednesday")
                        {
                            mpc.flp_lunch_wed.Controls.Add(sunLabels[sun]);
                        }
                        if (weekdays[i].ToString() == "Thursday")
                        {
                            mpc.flp_lunch_thur.Controls.Add(sunLabels[sun]);
                        }
                        if (weekdays[i].ToString() == "Friday")
                        {
                            mpc.flp_lunch_fri.Controls.Add(sunLabels[sun]);
                        }
                        if (weekdays[i].ToString() == "Saturday")
                        {
                            mpc.flp_lunch_sat.Controls.Add(sunLabels[sun]);
                        }
                    }
                }//lunch finish
                DataTable getallsnacks = Bllbreakfast.getallSnacksforfromPakage(PushPakageName, weekdays[i].ToString());
                if (getallsnacks.Rows.Count > 0)
                {

                    for (int sun = 0; sun < getallsnacks.Rows.Count; sun++)
                    {
                        Label[] sunLabels = new Label[getallsnacks.Rows.Count];
                        sunLabels[sun] = new Label();
                        sunLabels[sun].Name = getallsnacks.Rows[sun]["br_id"].ToString();
                        sunLabels[sun].Text = getallsnacks.Rows[sun]["itemname"].ToString();
                        sunLabels[sun].Height = 30;
                        sunLabels[sun].Width = 70;
                        sunLabels[sun].Font = new Font("", 10, FontStyle.Bold);
                        sunLabels[sun].ForeColor = Color.Black;


                        if (weekdays[i].ToString() == "Sunday")
                        {
                            mpc.flp_snacks_sun.Controls.Add(sunLabels[sun]);
                        }

                        if (weekdays[i].ToString() == "Monday")
                        {
                            mpc.flp_snacks_mon.Controls.Add(sunLabels[sun]);
                        }
                        if (weekdays[i].ToString() == "Tuesday")
                        {
                            mpc.flp_snacks_tue.Controls.Add(sunLabels[sun]);
                        }

                        if (weekdays[i].ToString() == "Wednesday")
                        {
                            mpc.flp_snacks_wed.Controls.Add(sunLabels[sun]);
                        }
                        if (weekdays[i].ToString() == "Thursday")
                        {
                            mpc.flp_snacks_thur.Controls.Add(sunLabels[sun]);
                        }
                        if (weekdays[i].ToString() == "Friday")
                        {
                            mpc.flp_snacks_fri.Controls.Add(sunLabels[sun]);
                        }
                        if (weekdays[i].ToString() == "Saturday")
                        {
                            mpc.flp_snacks_sat.Controls.Add(sunLabels[sun]);
                        }
                    }
                }//snacks finish
                DataTable getallDinner = Bllbreakfast.getallDinnerforfromPakage(PushPakageName, weekdays[i].ToString());
                if (getallDinner.Rows.Count > 0)
                {

                    for (int sun = 0; sun < getallDinner.Rows.Count; sun++)
                    {
                        Label[] sunLabels = new Label[getallDinner.Rows.Count];
                        sunLabels[sun] = new Label();
                        sunLabels[sun].Name = getallDinner.Rows[sun]["br_id"].ToString();
                        sunLabels[sun].Text = getallDinner.Rows[sun]["itemname"].ToString();
                        sunLabels[sun].Height = 30;
                        sunLabels[sun].Width = 70;
                        sunLabels[sun].Font = new Font("", 10, FontStyle.Bold);
                        sunLabels[sun].ForeColor = Color.Black;


                        if (weekdays[i].ToString() == "Sunday")
                        {
                            mpc.flp_dinner_sun.Controls.Add(sunLabels[sun]);
                            mpc.flp_dinner_sun.HorizontalScroll.Visible = false;
                        }

                        if (weekdays[i].ToString() == "Monday")
                        {
                            mpc.flp_dinner_mon.Controls.Add(sunLabels[sun]);
                            mpc.flp_dinner_mon.HorizontalScroll.Visible = false;
                        }
                        if (weekdays[i].ToString() == "Tuesday")
                        {
                            mpc.flp_dinner_tue.Controls.Add(sunLabels[sun]);
                            mpc.flp_dinner_tue.HorizontalScroll.Visible = false;
                        }

                        if (weekdays[i].ToString() == "Wednesday")
                        {
                            mpc.flp_dinner_wed.Controls.Add(sunLabels[sun]);
                            mpc.flp_dinner_wed.HorizontalScroll.Visible = false;
                        }
                        if (weekdays[i].ToString() == "Thursday")
                        {
                            mpc.flp_dinner_thur.Controls.Add(sunLabels[sun]);
                            mpc.flp_dinner_thur.HorizontalScroll.Visible = false;
                        }
                        if (weekdays[i].ToString() == "Friday")
                        {
                            mpc.flp_dinner_fri.Controls.Add(sunLabels[sun]);
                            mpc.flp_dinner_fri.HorizontalScroll.Visible = false;
                        }
                        if (weekdays[i].ToString() == "Saturday")
                        {
                            mpc.flp_dinner_sat.Controls.Add(sunLabels[sun]);
                            mpc.flp_dinner_sat.HorizontalScroll.Visible = false;
                        }

                    }

                }//Dinner finish


            }//forloop
            mpc.ShowDialog();
        }

        private void txt_pakages_TextChanged(object sender, EventArgs e)
        {
            if (txt_pakages.Text == "")
            {
                loadallPakages();
            }
            else
            {
                DataTable dtst = bllmess.SearchPakagename(txt_pakages.Text);

                if (dtst.Rows.Count > 0)
                {
                    flp_pakages.Controls.Clear();
                    for (int i = 0; i < dtst.Rows.Count; i++)
                    {
                        Button[] itembutton = new Button[dtst.Rows.Count];
                        itembutton[i] = new Button();
                        itembutton[i].Name = dtst.Rows[i]["pg_id"].ToString();
                        itembutton[i].Text = dtst.Rows[i]["name"].ToString();
                        itembutton[i].Height = 60;
                        itembutton[i].Width = 240;
                        itembutton[i].Font = new Font("", 14, FontStyle.Bold);
                        itembutton[i].BackColor = Color.Azure;
                        itembutton[i].ForeColor = Color.Black;
                        itembutton[i].ContextMenuStrip = getcontextMenuStrip;
                        itembutton[i].Click += new EventHandler(this.pakage_Click);

                        flp_pakages.Controls.Add(itembutton[i]);
                    }
                }
            }
        }

        private void dgv_customers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            MessPakageChooser mpc = new MessPakageChooser();
            if (e.ColumnIndex == dgv_customers.Columns["colview"].Index && e.RowIndex >= 0)
            {

                DataTable getpakageNameFromCustomer = bllmess.getPakageNameFromCustomer(dgv_customers.CurrentRow.Cells["colID"].Value.ToString());
                if (getpakageNameFromCustomer.Rows.Count > 0)
                {
                    String CusPakageName = getpakageNameFromCustomer.Rows[0]["pakage_name"].ToString();
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

                        DataTable getallsunday = Bllbreakfast.getallBreakfastsforfromPakage(CusPakageName, weekdays[i].ToString());
                        if (getallsunday.Rows.Count > 0)
                        {

                            for (int sun = 0; sun < getallsunday.Rows.Count; sun++)
                            {
                                Label[] sunLabels = new Label[getallsunday.Rows.Count];
                                sunLabels[sun] = new Label();
                                sunLabels[sun].Name = getallsunday.Rows[sun]["br_id"].ToString();
                                sunLabels[sun].Text = getallsunday.Rows[sun]["itemname"].ToString();
                                sunLabels[sun].Height = 30;
                                sunLabels[sun].Width = 100;
                                sunLabels[sun].Font = new Font("", 11, FontStyle.Bold);
                                sunLabels[sun].ForeColor = Color.Black;



                                if (weekdays[i].ToString() == "Sunday")
                                {
                                    mpc.flp_breakfast_sunday.Controls.Add(sunLabels[sun]);
                                    mpc.flp_breakfast_sunday.HorizontalScroll.Visible = false;
                                }

                                if (weekdays[i].ToString() == "Monday")
                                {
                                    mpc.flp_breakfast_mon.Controls.Add(sunLabels[sun]);
                                    mpc.flp_breakfast_mon.HorizontalScroll.Visible = false;
                                }
                                if (weekdays[i].ToString() == "Tuesday")
                                {
                                    mpc.flp_breakfast_tue.Controls.Add(sunLabels[sun]);
                                    mpc.flp_breakfast_tue.HorizontalScroll.Visible = false;
                                }

                                if (weekdays[i].ToString() == "Wednesday")
                                {
                                    mpc.flp_breakfast_wed.Controls.Add(sunLabels[sun]);
                                    mpc.flp_breakfast_wed.HorizontalScroll.Visible = false;
                                }
                                if (weekdays[i].ToString() == "Thursday")
                                {
                                    mpc.flp_breakfast_thur.Controls.Add(sunLabels[sun]);
                                    mpc.flp_breakfast_thur.HorizontalScroll.Visible = false;
                                }
                                if (weekdays[i].ToString() == "Friday")
                                {
                                    mpc.flp_breakfast_fri.Controls.Add(sunLabels[sun]);
                                    mpc.flp_breakfast_fri.HorizontalScroll.Visible = false;
                                }
                                if (weekdays[i].ToString() == "Saturday")
                                {
                                    mpc.flp_break_sat.Controls.Add(sunLabels[sun]);
                                    mpc.flp_break_sat.HorizontalScroll.Visible = false;
                                }
                            }
                        }
                        //breakfast finish
                        DataTable getallLunch = Bllbreakfast.getallLunchforfromPakage(CusPakageName, weekdays[i].ToString());
                        if (getallLunch.Rows.Count > 0)
                        {

                            for (int sun = 0; sun < getallLunch.Rows.Count; sun++)
                            {
                                Label[] sunLabels = new Label[getallLunch.Rows.Count];
                                sunLabels[sun] = new Label();
                                sunLabels[sun].Name = getallLunch.Rows[sun]["br_id"].ToString();
                                sunLabels[sun].Text = getallLunch.Rows[sun]["itemname"].ToString();
                                sunLabels[sun].Height = 30;
                                sunLabels[sun].Width = 100;
                                sunLabels[sun].Font = new Font("", 11, FontStyle.Bold);
                                sunLabels[sun].ForeColor = Color.Black;


                                if (weekdays[i].ToString() == "Sunday")
                                {
                                    mpc.flp_lunch_sun.Controls.Add(sunLabels[sun]);
                                }

                                if (weekdays[i].ToString() == "Monday")
                                {
                                    mpc.flp_lunch_mon.Controls.Add(sunLabels[sun]);
                                }
                                if (weekdays[i].ToString() == "Tuesday")
                                {
                                    mpc.flp_lunch_tue.Controls.Add(sunLabels[sun]);
                                }

                                if (weekdays[i].ToString() == "Wednesday")
                                {
                                    mpc.flp_lunch_wed.Controls.Add(sunLabels[sun]);
                                }
                                if (weekdays[i].ToString() == "Thursday")
                                {
                                    mpc.flp_lunch_thur.Controls.Add(sunLabels[sun]);
                                }
                                if (weekdays[i].ToString() == "Friday")
                                {
                                    mpc.flp_lunch_fri.Controls.Add(sunLabels[sun]);
                                }
                                if (weekdays[i].ToString() == "Saturday")
                                {
                                    mpc.flp_lunch_sat.Controls.Add(sunLabels[sun]);
                                }
                            }
                        }//lunch finish
                        DataTable getallsnacks = Bllbreakfast.getallSnacksforfromPakage(CusPakageName, weekdays[i].ToString());
                        if (getallsnacks.Rows.Count > 0)
                        {

                            for (int sun = 0; sun < getallsnacks.Rows.Count; sun++)
                            {
                                Label[] sunLabels = new Label[getallsnacks.Rows.Count];
                                sunLabels[sun] = new Label();
                                sunLabels[sun].Name = getallsnacks.Rows[sun]["br_id"].ToString();
                                sunLabels[sun].Text = getallsnacks.Rows[sun]["itemname"].ToString();
                                sunLabels[sun].Height = 30;
                                sunLabels[sun].Width = 100;
                                sunLabels[sun].Font = new Font("", 11, FontStyle.Bold);
                                sunLabels[sun].ForeColor = Color.Black;


                                if (weekdays[i].ToString() == "Sunday")
                                {
                                    mpc.flp_snacks_sun.Controls.Add(sunLabels[sun]);
                                }

                                if (weekdays[i].ToString() == "Monday")
                                {
                                    mpc.flp_snacks_mon.Controls.Add(sunLabels[sun]);
                                }
                                if (weekdays[i].ToString() == "Tuesday")
                                {
                                    mpc.flp_snacks_tue.Controls.Add(sunLabels[sun]);
                                }

                                if (weekdays[i].ToString() == "Wednesday")
                                {
                                    mpc.flp_snacks_wed.Controls.Add(sunLabels[sun]);
                                }
                                if (weekdays[i].ToString() == "Thursday")
                                {
                                    mpc.flp_snacks_thur.Controls.Add(sunLabels[sun]);
                                }
                                if (weekdays[i].ToString() == "Friday")
                                {
                                    mpc.flp_snacks_fri.Controls.Add(sunLabels[sun]);
                                }
                                if (weekdays[i].ToString() == "Saturday")
                                {
                                    mpc.flp_snacks_sat.Controls.Add(sunLabels[sun]);
                                }
                            }
                        }//snacks finish
                        DataTable getallDinner = Bllbreakfast.getallDinnerforfromPakage(CusPakageName, weekdays[i].ToString());
                        if (getallDinner.Rows.Count > 0)
                        {

                            for (int sun = 0; sun < getallDinner.Rows.Count; sun++)
                            {
                                Label[] sunLabels = new Label[getallDinner.Rows.Count];
                                sunLabels[sun] = new Label();
                                sunLabels[sun].Name = getallDinner.Rows[sun]["br_id"].ToString();
                                sunLabels[sun].Text = getallDinner.Rows[sun]["itemname"].ToString();
                                sunLabels[sun].Height = 30;
                                sunLabels[sun].Width = 100;
                                sunLabels[sun].Font = new Font("", 11, FontStyle.Bold);
                                sunLabels[sun].ForeColor = Color.Black;


                                if (weekdays[i].ToString() == "Sunday")
                                {
                                    mpc.flp_dinner_sun.Controls.Add(sunLabels[sun]);
                                    mpc.flp_dinner_sun.HorizontalScroll.Visible = false;
                                }

                                if (weekdays[i].ToString() == "Monday")
                                {
                                    mpc.flp_dinner_mon.Controls.Add(sunLabels[sun]);
                                    mpc.flp_dinner_mon.HorizontalScroll.Visible = false;
                                }
                                if (weekdays[i].ToString() == "Tuesday")
                                {
                                    mpc.flp_dinner_tue.Controls.Add(sunLabels[sun]);
                                    mpc.flp_dinner_tue.HorizontalScroll.Visible = false;
                                }

                                if (weekdays[i].ToString() == "Wednesday")
                                {
                                    mpc.flp_dinner_wed.Controls.Add(sunLabels[sun]);
                                    mpc.flp_dinner_wed.HorizontalScroll.Visible = false;
                                }
                                if (weekdays[i].ToString() == "Thursday")
                                {
                                    mpc.flp_dinner_thur.Controls.Add(sunLabels[sun]);
                                    mpc.flp_dinner_thur.HorizontalScroll.Visible = false;
                                }
                                if (weekdays[i].ToString() == "Friday")
                                {
                                    mpc.flp_dinner_fri.Controls.Add(sunLabels[sun]);
                                    mpc.flp_dinner_fri.HorizontalScroll.Visible = false;
                                }
                                if (weekdays[i].ToString() == "Saturday")
                                {
                                    mpc.flp_dinner_sat.Controls.Add(sunLabels[sun]);
                                    mpc.flp_dinner_sat.HorizontalScroll.Visible = false;
                                }
                            }

                        }//Dinner finish


                    }//forloop
                    mpc.ShowDialog();
                }
            }
        }

        private void btn_setpakage_Click(object sender, EventArgs e)
        {
            setCustomerPakages abc = new setCustomerPakages();
            if (abc.ShowDialog() == DialogResult.OK)
            {
                loadAllPakagesCustomers();
            }
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadallPakages();
        }
        public void loaddallpakageslist()
        {
            bll_customer_mess Bllmess = new bll_customer_mess();
            DataTable getpakage = Bllmess.getallPakagesLists();

            if (getpakage.Rows.Count > 0)
            {
                DataRow dr = getpakage.NewRow();
                dr["name"] = "Choose Package";
                getpakage.Rows.InsertAt(dr, 0);
                cbo_packagename.DataSource = getpakage;
                cbo_packagename.DisplayMember = "name";
            }
        }
        private void txt_name_TextChanged(object sender, EventArgs e)
        {
            if (txt_name.Text.Length > 0)
            {
                DataTable getallnames = bllcus.search_By_Firstname(txt_name.Text);
                dgv_customers.Rows.Clear();
                if (getallnames.Rows.Count > 0)
                {
                    for (int j = 0; j < getallnames.Rows.Count; j++)
                    {
                        dgv_customers.Rows.Add(getallnames.Rows[j]["id"].ToString(), getallnames.Rows[j]["name"].ToString(), getallnames.Rows[j]["lastname"].ToString(), getallnames.Rows[j]["gender"].ToString(), getallnames.Rows[j]["pakage_name"].ToString());
                    }

                }
            }
            else
            {
                loadAllPakagesCustomers();
            }
        }

        private void cbo_packagename_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_packagename.Text == "Choose Package")
            {
                loadAllPakagesCustomers();

            }
            else
            {
                DataTable getallpackages = bllcus.getallcustomersbyPakages (cbo_packagename.Text);

              if (getallpackages.Rows.Count > 0)
                {
                    dgv_customers.Rows.Clear();
                    for (int j = 0; j < getallpackages.Rows.Count; j++)
                    {
                        dgv_customers.Rows.Add(getallpackages.Rows[j]["id"].ToString(), getallpackages.Rows[j]["name"].ToString(), getallpackages.Rows[j]["lastname"].ToString(), getallpackages.Rows[j]["gender"].ToString(), getallpackages.Rows[j]["pakage_name"].ToString());
                    }

                }


            }
        }
    }
}
