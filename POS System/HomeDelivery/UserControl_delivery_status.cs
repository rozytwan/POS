using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLLS;

namespace POS_System
{
    public partial class UserControl_delivery_status : UserControl
    {
        public UserControl_delivery_status()
        {
            InitializeComponent();
        }
        BLLhome_delivery BLLhome = new BLLhome_delivery();
        BLLOrder blord = new BLLOrder();
        bll_orderCancel bloc = new bll_orderCancel();
        BLLRestSell blress = new BLLRestSell();
        private void dgv_deliver_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Home_delivery_check check = new Home_delivery_check();
            check.txt_name.Text = dgv_deliver.CurrentRow.Cells["calcusname"].Value.ToString();
            check.txt_amount.Text = dgv_deliver.CurrentRow.Cells["caltotal"].Value.ToString();
            check.txt_deliverby.Text = dgv_deliver.CurrentRow.Cells["caldeliveryman"].Value.ToString();
            check.lblkotid.Text=dgv_deliver.CurrentRow.Cells["calkotid"].Value.ToString();
            check.homeId.Text=dgv_deliver.CurrentRow.Cells["calid"].Value.ToString();
            check.lbl_payment_type.Text= dgv_deliver.CurrentRow.Cells["cal_payment_type"].Value.ToString();
            check.ShowDialog();
            gridview();
        }   
        private void UserControl_delivery_status_Load(object sender, EventArgs e)
        {
          gridview();
        }
        public void gridview()
        {
            DataTable dt = new DataTable();
            dt = BLLhome.getalldata();
            dgv_deliver.Rows.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dgv_deliver.Rows.Add();
                dgv_deliver.Rows[i].Cells["caldeliveryman"].Value = dt.Rows[i]["deliveryman"].ToString();
                dgv_deliver.Rows[i].Cells["calstatus"].Value = dt.Rows[i]["payment_status"].ToString();
                dgv_deliver.Rows[i].Cells["calcusname"].Value = dt.Rows[i]["customer_name"].ToString();
                dgv_deliver.Rows[i].Cells["calcusadress"].Value = dt.Rows[i]["customer_adress"].ToString();
                dgv_deliver.Rows[i].Cells["calcusphone"].Value = dt.Rows[i]["customer_phone"].ToString();
                dgv_deliver.Rows[i].Cells["caltotal"].Value = dt.Rows[i]["grandtotal"].ToString();
                dgv_deliver.Rows[i].Cells["calkotid"].Value = dt.Rows[i]["kotid"].ToString();
                dgv_deliver.Rows[i].Cells["calid"].Value = dt.Rows[i]["home_deliver_id"].ToString();
                dgv_deliver.Rows[i].Cells["calbill_no"].Value = dt.Rows[i]["bill_no"].ToString();
                dgv_deliver.Rows[i].Cells["cal_payment_type"].Value = dt.Rows[i]["payment_type"].ToString();

            }

        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            Control ctls = this.Parent;
            allmenu alls = new allmenu();
            ctls.Controls.Clear();
            ctls.Controls.Add(alls);


        }

        private void dgv_deliver_RowHeadersBorderStyleChanged(object sender, EventArgs e)
        {

        }
        decimal table_no;
      
        private void dgv_deliver_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgv_deliver.Columns["cal_recived"].Index && e.RowIndex >= 0)
            {
                Home_delivery_check check = new Home_delivery_check();
                check.txt_name.Text = dgv_deliver.CurrentRow.Cells["calcusname"].Value.ToString();
                check.txt_amount.Text = dgv_deliver.CurrentRow.Cells["caltotal"].Value.ToString();
                check.txt_deliverby.Text = dgv_deliver.CurrentRow.Cells["caldeliveryman"].Value.ToString();
                check.lblkotid.Text = dgv_deliver.CurrentRow.Cells["calkotid"].Value.ToString();
                check.homeId.Text = dgv_deliver.CurrentRow.Cells["calid"].Value.ToString();
                check.lbl_payment_type.Text = dgv_deliver.CurrentRow.Cells["cal_payment_type"].Value.ToString();
                check.ShowDialog();
                gridview();
            }
            else if (e.ColumnIndex == dgv_deliver.Columns["cal_cancel"].Index && e.RowIndex >= 0)
            {
                DialogResult dialogResult = MessageBox.Show("Are You Sure Want To Delete Delivery", "Cancel", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    DataTable dt = blord.getalldata(Convert.ToDecimal(dgv_deliver.CurrentRow.Cells["calkotid"].Value.ToString()));
                    if (dt.Rows.Count > 0)
                    {
                        
                        for (int x = 0; dt.Rows.Count > x; x++)
                        {
                            string customer_name = dt.Rows[x]["user_name"].ToString();
                            table_no = Convert.ToDecimal(dt.Rows[x]["table_no"].ToString());
                          
                            string item_name = dt.Rows[x]["item"].ToString();
                            decimal quantity = Convert.ToDecimal(dt.Rows[x]["quantity"].ToString());
                            decimal total = Convert.ToDecimal(dt.Rows[x]["total"].ToString());
                            decimal cost = Convert.ToDecimal(dt.Rows[x]["cost"].ToString());
                            string category_name = dt.Rows[x]["category_name"].ToString();
                            string phone_no = dt.Rows[x]["phone"].ToString();
                            int bocs = bloc.insertordercancellation(customer_name, table_no, item_name, quantity, total, cost, "NO", category_name, "K1", phone_no, DateTime.Now, "NULL","HD");
                        }
                        int vb = blress.voidBillInsert(Convert.ToInt32(dgv_deliver.CurrentRow.Cells["calbill_no"].Value), Convert.ToInt32(0), "Home Delivery Cancel", "True", DateTime.Now, Login.sendtext);//void bill no save 
                        int delete_by_table = blord.deletefromtable(table_no);
                        if (delete_by_table > 0)
                        {
                            int hd_no = (int)table_no;
                            int delete_home_no = BLLhome.deletehomedeleveryid(hd_no.ToString());
                            int deletehomedelevery = BLLhome.deletehomedeleveryvalue(table_no);
                            MessageBox.Show("Home Delivery Order Has Been Deleted");
                            gridview();
                        }
                    }
                }
            }

        }
    }
}
