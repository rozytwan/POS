using BLLS;
using BLLS.Bll_inventory;
using DevComponents.DotNetBar;
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
    public partial class AdvanceDiscount : Form
    {
        public AdvanceDiscount()
        {
            
            InitializeComponent();
        }
        public List<string> datagridview_item_name = new List<string>();
        public List<string> datagridview_item_price = new List<string>();
        public List<string> datagridview_quantity = new List<string>();
        public List<string> datagridview_total = new List<string>();
        public List<string> datagridview_KOT = new List<string>();
        public List<string> datagridview_discount = new List<string>();
        string kot_type;
        decimal k1_discount;
        decimal k2_discount;
        decimal bot_disount;
        decimal k1_discount_percent;
        decimal k2_discount_percent;
        decimal bot_disount_percent;
        public  decimal discount_amount;
        public decimal discount;
        public decimal discount_amount_percent;
        public string table_no;
        BLLdiscount bld = new BLLdiscount();
        BLLDyanmicDiscount bldd = new BLLDyanmicDiscount();
        bll_inv blli = new bll_inv();
        BLLOrder blord = new BLLOrder();
        private void AdvanceDiscount_Load(object sender, EventArgs e)
        {
            datagrid_Load();
        }
     
        public void datagrid_Load()
        {
            if (datagridview_item_name.Count > 0)
            {
                dataGridView1.Rows.Clear();
                for (int i = 0; i < datagridview_item_name.Count; i++)
                {
                    int abc=dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells["cal_item_name"].Value = datagridview_item_name[i];
             
                    dataGridView1.Rows[i].Cells["cal_qty"].Value = datagridview_quantity[i];
                    DataTable dt1 = blord.getallbyitem_name(datagridview_item_name[i]);
                    if (dt1.Rows.Count > 0)
                    {
                        int item_id = Convert.ToInt32(dt1.Rows[0]["item_id"].ToString());
                        dataGridView1.Rows[i].Cells["col_item_id"].Value = item_id.ToString();
                        if (dt1.Rows[0]["discount"].ToString() == null|| dt1.Rows[0]["discount"]== DBNull.Value)
                        {
                            dataGridView1.Rows[i].Cells["col_discount"].Value = 0.00;
                        }
                        else
                        {
                            discount = Convert.ToDecimal(dt1.Rows[0]["discount"].ToString());
                            dataGridView1.Rows[i].Cells["col_discount"].Value = discount.ToString();
                        }
                        //if ((dt1.Rows[0]["discount"].ToString()) == null)
                        //{
                        //    dataGridView1.Rows[i].Cells["col_discount"].Value = 0.00;
                        //}
                        //else
                        //{
                        //    dataGridView1.Rows[i].Cells["col_discount"].Value = Convert.ToDecimal(dt1.Rows[0]["discount"].ToString());
                        //}
                        DataTable dt2 = blli.GetItemCost(item_id);
                        if (dt2.Rows.Count > 0)
                        {
                            dataGridView1.Rows[i].Cells["col_estimate"].Value =Convert.ToDecimal( datagridview_quantity[i]) *Convert.ToDecimal(dt2.Rows[0]["total_cost"].ToString());
                        }
                    }
                    dataGridView1.Rows[i].Cells["cal_cost"].Value = datagridview_item_price[i];
                    dataGridView1.Rows[i].Cells["cal_total"].Value = datagridview_total[i];
                 

                }
                calculate_total();
            }
            hotDiscount();
        }
        ButtonX  btn_hot_discount = new ButtonX();
        public void hotDiscount()
        {
            DataTable dt = bldd.get_all_data();

            if (dt.Rows.Count > 0)
            {
                pnlHotDiscount.Controls.Clear();
                for (int x = 0; dt.Rows.Count > x; x++)
                {
                    btn_hot_discount = new ButtonX();
                    btn_hot_discount.Text = dt.Rows[x]["discount_type"].ToString() + "    "+ dt.Rows[x]["discount_percent"].ToString();
                   // btn_hot_discount.Location = System.Drawing.Point.Add(new Point(4 + x * 70, 4), new Size(100, 100));
                    btn_hot_discount.Name = dt.Rows[x]["discount_percent"].ToString();

                    btn_hot_discount.ForeColor = Color.White;
                    this.btn_hot_discount.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(15, 15, 15, 15);
                    this.btn_hot_discount.Size = new System.Drawing.Size(100, 100);
                    this.btn_hot_discount.TabIndex = 311;

                    btn_hot_discount.Click += new System.EventHandler(this.btn_hot_discount_click);
                    pnlHotDiscount.Controls.Add(btn_hot_discount);
                    btn_hot_discount.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                }
            }
        }
        private void btn_hot_discount_click(object sender, EventArgs e)
        {

            txt_discount_percent.Text= ((ButtonX)sender).Name;
        }
        public void datagrid_Load_kot_type()
        {
            if (datagridview_item_name.Count > 0)
            {
                dataGridView1.Rows.Clear();
                int xy = 0;
                for (int i = 0; i < datagridview_item_name.Count; i++)
                {
                    if (datagridview_KOT[i] == kot_type)
                    {
                      
                        int abc = dataGridView1.Rows.Add();
                        dataGridView1.Rows[xy].Cells["cal_item_name"].Value = datagridview_item_name[i];
                        dataGridView1.Rows[xy].Cells["cal_qty"].Value = datagridview_quantity[i];
                        dataGridView1.Rows[xy].Cells["cal_cost"].Value = datagridview_item_price[i];
                        dataGridView1.Rows[xy].Cells["cal_total"].Value = datagridview_total[i];
                        xy++;
                    }
                    
                }
                calculate_total();
            }
        }
        public void calculate_total()
        {
            decimal sum = 0;
            decimal estimate_cost = 0;
            decimal discount = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                sum += Convert.ToDecimal(dataGridView1.Rows[i].Cells["cal_total"].Value);
                estimate_cost += Convert.ToDecimal(dataGridView1.Rows[i].Cells["col_estimate"].Value);
                discount += Convert.ToDecimal(dataGridView1.Rows[i].Cells["col_discount"].Value);
            }

            lbl_total.Text = sum.ToString();
            lbl_total_discount.Text = sum.ToString();
            lbl_estimate.Text = estimate_cost.ToString();
            lbl_discount.Text = discount.ToString();

        }
        private void radioButton1_Click(object sender, EventArgs e)
        {
            datagrid_Load();
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            kot_type = "K1";
            datagrid_Load_kot_type();
            txt_discount_amount.Text = "0.00";
            txt_discount_percent.Text = "0.00";
            if (k1_discount != Convert.ToDecimal(0.00) || k1_discount_percent != Convert.ToDecimal(0.00))
            {
                txt_discount_amount.Text = k1_discount.ToString();
                txt_discount_percent.Text = k1_discount_percent.ToString();
            }
        }

        private void radioButton3_Click(object sender, EventArgs e)
        {
            kot_type = "K2";
            datagrid_Load_kot_type();
            txt_discount_amount.Text = "0.00";
            txt_discount_percent.Text = "0.00";
            if (k2_discount != Convert.ToDecimal(0.00) || k2_discount_percent != Convert.ToDecimal(0.00))
            {
                txt_discount_amount.Text = k2_discount.ToString();
                txt_discount_percent.Text = k2_discount_percent.ToString();
            }
        }

        private void radioButton4_Click(object sender, EventArgs e)
        {
            kot_type = "B1";
            datagrid_Load_kot_type();
            txt_discount_amount.Text = "0.00";
            txt_discount_percent.Text = "0.00";
            if (bot_disount != Convert.ToDecimal(0.00) || bot_disount_percent != Convert.ToDecimal(0.00))
            {
                txt_discount_amount.Text = bot_disount.ToString();
                txt_discount_percent.Text = bot_disount_percent.ToString();
            }
        }
       
        private void txt_discount_amount_TextChanged(object sender, EventArgs e)
        {
            if (!switch_discount_checker.IsOn)
            {
                if (txt_discount_amount.Text != "" && txt_discount_amount.Text != "0" && txt_discount_amount.Text != "0.00" && txt_discount_amount.Text != ".")
                {
                    lbl_total_discount.Text = (Convert.ToDecimal(lbl_total.Text) - Convert.ToDecimal(txt_discount_amount.Text)).ToString();
                    txt_discount_percent.Text = (((Convert.ToDecimal(txt_discount_amount.Text)) * 100) / (Convert.ToDecimal(lbl_total.Text))).ToString("#.##");
                    if (rbtn_k1.Checked)
                    {
                        k1_discount = Convert.ToDecimal(txt_discount_amount.Text);
                        k1_discount_percent= Convert.ToDecimal(txt_discount_percent.Text);
                    }
                    else if (rbtn_k2.Checked)
                    {
                        k2_discount = Convert.ToDecimal(txt_discount_amount.Text);
                        k2_discount_percent= Convert.ToDecimal(txt_discount_percent.Text);
                    }
                    else if (rbtn_bot.Checked)
                    {
                        bot_disount    = Convert.ToDecimal(txt_discount_amount.Text);
                        bot_disount_percent= Convert.ToDecimal(txt_discount_percent.Text);
                    }
                }
                else if (txt_discount_amount.Text == "")
                {
                    lbl_total_discount.Text = lbl_total.Text;
                    txt_discount_percent.Text = "0.00";
                }
            }
        }

        private void txt_discount_percent_TextChanged(object sender, EventArgs e)
        {
            if (switch_discount_checker.IsOn)
            {
                if (txt_discount_percent.Text != "" && txt_discount_percent.Text != "0" && txt_discount_percent.Text != "0.00" && txt_discount_percent.Text != ".")
                {
                    txt_discount_amount.Text = ((Convert.ToDecimal(lbl_total.Text) * Convert.ToDecimal(txt_discount_percent.Text)) / 100).ToString("#.##");
                    lbl_total_discount.Text = (Convert.ToDecimal(lbl_total.Text) - Convert.ToDecimal(txt_discount_amount.Text)).ToString("#.##");
                    if (rbtn_k1.Checked)
                    {
                        k1_discount = Convert.ToDecimal(txt_discount_amount.Text);

                    }
                    else if (rbtn_k2.Checked)
                    {
                        k2_discount = Convert.ToDecimal(txt_discount_amount.Text);
                    }
                    else if (rbtn_bot.Checked)
                    {
                        bot_disount = Convert.ToDecimal(txt_discount_amount.Text);
                    }
                }
                else if (txt_discount_percent.Text == "")
                {
                    lbl_total_discount.Text = lbl_total.Text;
                    txt_discount_amount.Text = "0.00";
                }
            }
        }

        private void toggleSwitch1_Properties_Click(object sender, EventArgs e)
        {
            if (switch_discount_checker.IsOn)
            {
                txt_discount_amount.ReadOnly = false;
                txt_discount_percent.ReadOnly = true;
            }
            else
            {
                txt_discount_percent.ReadOnly = false;
                txt_discount_amount.ReadOnly = true;
            }
        }

        private void txt_discount_amount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txt_discount_percent_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txt_discount_amount_Enter(object sender, EventArgs e)
        {
            if (txt_discount_amount.Text == "0.00")
            {
                txt_discount_amount.Text = "";
            }
        }

        private void txt_discount_amount_Leave(object sender, EventArgs e)
        {
            if (txt_discount_amount.Text == "")
            {
                txt_discount_amount.Text = "0.00";
            }
        }

        private void txt_discount_percent_Leave(object sender, EventArgs e)
        {
            if (txt_discount_percent.Text == "")
            {
                txt_discount_percent.Text = "0.00";
            }
        }

        private void txt_discount_percent_Enter(object sender, EventArgs e)
        {
            if (txt_discount_percent.Text == "0.00")
            {
                txt_discount_percent.Text = "";
            }
        }
        CheckDynamic cd = new CheckDynamic();
        bool status = false;
        bool discount_status = false;
        private void btn_ok_Click(object sender, EventArgs e)
        {
            status = cd.DiscountBelowEstimate();
            discount_status = cd.DiscountBelowDiscountCost();
            if (status == true)
            {
                if (Convert.ToDecimal(lbl_estimate.Text) > 0)
                {
                    if (Convert.ToDecimal(txt_discount_amount.Text) >= Convert.ToDecimal(lbl_estimate.Text))
                    {
                        MessageBox.Show("Discount cannot be greater than Product ", "Invalid discount amount!!");
                        return;
                    }
                }
            }
            if (discount_status == true)
            {
                if (Convert.ToDecimal(lbl_total_discount.Text) <= Convert.ToDecimal(lbl_discount.Text))
                {
                    MessageBox.Show("Discount cannot be greater than Total Discount Price", "Invalid discount amount!!");
                }
                else
                {
                    if (rbtn_all.Checked)
                    {
                        discount_amount = Convert.ToDecimal(txt_discount_amount.Text);
                        discount_amount_percent = Convert.ToDecimal(txt_discount_percent.Text);
                    }
                    else
                    {
                        discount_amount = k1_discount + k2_discount + bot_disount;
                        discount_amount_percent = k1_discount_percent + k2_discount_percent + bot_disount_percent;
                    }
                    advanceDiscountInsert();
                    datagridview_item_name.Clear();
                    datagridview_item_price.Clear();
                    datagridview_quantity.Clear();
                    datagridview_KOT.Clear();
                    this.Close();

                }
            }
            else
            {
                MessageBox.Show("Sorry please enable discount in setting.","Discount disable",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
         
        }

        public void advanceDiscountInsert()
        {
            if (table_no != null&&table_no !="")
            {
                DataTable dt = bld.ad_tableNoCheck(table_no);
                if (dt.Rows.Count > 0)
                {

                    DialogResult dr = MessageBox.Show("This table already contain discount do you want to update", "Advance Discount0", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (dr == DialogResult.Yes)
                    {
                        int update_discount = bld.UpdateAdvanceDiscount(table_no, discount_amount.ToString(), discount_amount_percent.ToString());
                    }
                    else
                    {
                        discount_amount = 0;
                        discount_amount_percent = 0;
                    }
                }
                else
                {
                    int insert_discount = bld.insertAdvanceDiscount(table_no, discount_amount.ToString(),discount_amount_percent.ToString());
                }
            }
        }
        private void btn_close_Click(object sender, EventArgs e)
        {
            datagridview_item_name.Clear();
            datagridview_item_price.Clear();
            datagridview_quantity.Clear();
            datagridview_KOT.Clear();
            this.Close();

        }
    }
}
