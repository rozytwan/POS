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
    public partial class KOTOrderManagement : Form
    {
        public KOTOrderManagement()
        {

            InitializeComponent();
        }
        BLLOrder blord = new BLLOrder();
        public List<string> datagridview_item_name = new List<string>();
        public List<string> datagridview_item_price = new List<string>();
        public List<string> datagridview_quantity = new List<string>();
        public List<string> datagridview_total = new List<string>();
        public List<string> datagridview_complementary = new List<string>();
        public List<string> datagridview_order_id = new List<string>();
        public List<string> datagridview_category = new List<string>();
        public List<string> datagridview_kotType = new List<string>();
        public string table_no;
        public string table_name;
        public string service_provider;
        Rectangle dragBoxFromMouseDown;
        int rowIndexFromMouseDown;
        int rowIndexOfItemUnderMouseToDrop;
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        string sales_type = "TS";
        private object valueFromMouseDown;
        private void KOTOrderManagement_Load(object sender, EventArgs e)
        {
            dataGridView1.AllowDrop = true;

            for (int i = 0; i < datagridview_item_name.Count; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells["cal_item_name"].Value = datagridview_item_name[i];
                dataGridView1.Rows[i].Cells["cal_qty"].Value = datagridview_quantity[i];
                dataGridView1.Rows[i].Cells["cal_cost"].Value = datagridview_item_price[i];
                dataGridView1.Rows[i].Cells["cal_total"].Value = datagridview_total[i];
                //dataGridView1.Rows[i].Cells["cal_order_id"].Value = datagridview_order_id[i];
                //  dataGridView1.Rows[i].Cells["cal_kot_id"].Value = datagridview_quantity[i];
                dataGridView1.Rows[i].Cells["cal_kot_print"].Value = datagridview_kotType[i];
                dataGridView1.Rows[i].Cells["cal_category_name"].Value = datagridview_category[i];
            }
            startup_set_load();
            maincourse_set_laod();
            dessert_set_laod();
        }

        public void startup_set_load()
        {
            DataTable dt_startup = blord.getalldata_startup(table_no);
            if (dt_startup.Rows.Count > 0)
            {
                for (int i = 0; i < dt_startup.Rows.Count; i++)
                {
                    dataGridView2.Rows.Add();
                    dataGridView2.Rows[i].Cells["cal_item_name2"].Value = dt_startup.Rows[i]["item"].ToString();
                    dataGridView2.Rows[i].Cells["cal_qty_2"].Value = dt_startup.Rows[i]["quantity"].ToString();
                    dataGridView2.Rows[i].Cells["cal_cost_2"].Value = dt_startup.Rows[i]["cost"].ToString();
                    dataGridView2.Rows[i].Cells["cal_total_2"].Value = dt_startup.Rows[i]["total"].ToString();
                    dataGridView2.Rows[i].Cells["cal_order_id_2"].Value = dt_startup.Rows[i]["order_id"].ToString();
                    //  dataGridView1.Rows[i].Cells["cal_kot_id"].Value = datagridview_quantity[i];
                    dataGridView2.Rows[i].Cells["cal_kot_print_2"].Value = dt_startup.Rows[i]["kot_print"].ToString();
                    dataGridView2.Rows[i].Cells["cal_category_2"].Value = dt_startup.Rows[i]["category_name"].ToString();
                }
            }
        }
        public void maincourse_set_laod()
        {
            DataTable dt_maincourse = blord.getalldata_maincourse(table_no);
            if (dt_maincourse.Rows.Count > 0)
            {
                for (int i = 0; i < dt_maincourse.Rows.Count; i++)
                {
                    dataGridView3.Rows.Add();
                    dataGridView3.Rows[i].Cells["cal_item_3"].Value = dt_maincourse.Rows[i]["item"].ToString();
                    dataGridView3.Rows[i].Cells["cal_qty_3"].Value = dt_maincourse.Rows[i]["quantity"].ToString();
                    dataGridView3.Rows[i].Cells["cal_cost_3"].Value = dt_maincourse.Rows[i]["cost"].ToString();
                    dataGridView3.Rows[i].Cells["cal_total_3"].Value = dt_maincourse.Rows[i]["total"].ToString();
                    dataGridView3.Rows[i].Cells["cal_order_id_3"].Value = dt_maincourse.Rows[i]["order_id"].ToString();
                    //  dataGridView1.Rows[i].Cells["cal_kot_id"].Value = datagridview_quantity[i];
                    dataGridView3.Rows[i].Cells["cal_kot_print_3"].Value = dt_maincourse.Rows[i]["kot_print"].ToString();
                    dataGridView3.Rows[i].Cells["cal_category_3"].Value = dt_maincourse.Rows[i]["category_name"].ToString();
                }
            }
        }
        public void dessert_set_laod()
        {
            DataTable dt_dessert = blord.getalldata_dessert(table_no);
            if (dt_dessert.Rows.Count > 0)
            {
                for (int i = 0; i < dt_dessert.Rows.Count; i++)
                {
                    dataGridView4.Rows.Add();
                    dataGridView4.Rows[i].Cells["cal_item_4"].Value = dt_dessert.Rows[i]["item"].ToString();
                    dataGridView4.Rows[i].Cells["cal_qty_4"].Value = dt_dessert.Rows[i]["quantity"].ToString();
                    dataGridView4.Rows[i].Cells["cal_cost_4"].Value = dt_dessert.Rows[i]["cost"].ToString();
                    dataGridView4.Rows[i].Cells["cal_total_4"].Value = dt_dessert.Rows[i]["total"].ToString();
                    dataGridView4.Rows[i].Cells["cal_order_id_4"].Value = dt_dessert.Rows[i]["order_id"].ToString();
                    //  dataGridView1.Rows[i].Cells["cal_kot_id"].Value = datagridview_quantity[i];
                    dataGridView4.Rows[i].Cells["cal_kot_print_4"].Value = dt_dessert.Rows[i]["kot_print"].ToString();
                    dataGridView4.Rows[i].Cells["cal_category_4"].Value = dt_dessert.Rows[i]["category_name"].ToString();
                }
            }
        }
        private void dataGridView1_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                // If the mouse moves outside the rectangle, start the drag.
                if (dragBoxFromMouseDown != Rectangle.Empty &&
                    !dragBoxFromMouseDown.Contains(e.X, e.Y))
                {

                    // Proceed with the drag and drop, passing in the list item.                    
                    DragDropEffects dropEffect = dataGridView1.DoDragDrop(
                    dataGridView1.Rows[rowIndexFromMouseDown],
                    DragDropEffects.Move);
                }
            }
        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            // Get the index of the item the mouse is below.
            var hittestInfo = dataGridView1.HitTest(e.X, e.Y);

            if (hittestInfo.RowIndex != -1 && hittestInfo.ColumnIndex != -1)
            {
                valueFromMouseDown = dataGridView1.Rows[hittestInfo.RowIndex].Cells[hittestInfo.ColumnIndex].Value;
                if (valueFromMouseDown != null)
                {
                    // Remember the point where the mouse down occurred. 
                    // The DragSize indicates the size that the mouse can move 
                    // before a drag event should be started.                
                    Size dragSize = SystemInformation.DragSize;

                    // Create a rectangle using the DragSize, with the mouse position being
                    // at the center of the rectangle.
                    dragBoxFromMouseDown = new Rectangle(new Point(e.X - (dragSize.Width / 2), e.Y - (dragSize.Height / 2)), dragSize);
                }
            }
            else
                // Reset the rectangle if the mouse is not over an item in the ListBox.
                dragBoxFromMouseDown = Rectangle.Empty;
        }

        private void dataGridView1_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void dataGridView1_DragDrop(object sender, DragEventArgs e)
        {

            // The mouse locations are relative to the screen, so they must be 
            // converted to client coordinates.
            Point clientPoint = dataGridView2.PointToClient(new Point(e.X, e.Y));

            // If the drag operation was a copy then add the row to the other control.
            if (e.Effect == DragDropEffects.Copy)
            {
                string cellvalue = e.Data.GetData(typeof(string)) as string;
                var hittest = dataGridView2.HitTest(clientPoint.X, clientPoint.Y);
                if (hittest.ColumnIndex != -1
                    && hittest.RowIndex != -1)
                    dataGridView2[hittest.ColumnIndex, hittest.RowIndex].Value = cellvalue;

            }
        }

        private void dataGridView2_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void dataGridView2_DragDrop(object sender, DragEventArgs e)
        {
            // The mouse locations are relative to the screen, so they must be 
            // converted to client coordinates.
            Point clientPoint = dataGridView2.PointToClient(new Point(e.X, e.Y));

            // If the drag operation was a copy then add the row to the other control.
            if (e.Effect == DragDropEffects.Copy)
            {
                string cellvalue = e.Data.GetData(typeof(string)) as string;
                var hittest = dataGridView2.HitTest(clientPoint.X, clientPoint.Y);
                if (hittest.ColumnIndex != -1
                    && hittest.RowIndex != -1)
                    dataGridView2[hittest.ColumnIndex, hittest.RowIndex].Value = cellvalue;

            }
        }
        int i;
        private void btn_move_Click(object sender, EventArgs e)
        {

        }

        private void btn_startup_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                i = dataGridView2.Rows.Count;
                dataGridView2.Rows.Add();
                dataGridView2.Rows[i].Cells["cal_item_name2"].Value = dataGridView1.CurrentRow.Cells["cal_item_name"].Value;
                dataGridView2.Rows[i].Cells["cal_kot_print_2"].Value = dataGridView1.CurrentRow.Cells["cal_kot_print"].Value;
                decimal qty = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["cal_qty"].Value);
                dataGridView2.Rows[i].Cells["cal_qty_2"].Value = qty;
                dataGridView2.Rows[i].Cells["cal_cost_2"].Value = dataGridView1.CurrentRow.Cells["cal_cost"].Value;
                dataGridView2.Rows[i].Cells["cal_total_2"].Value = (Convert.ToDecimal(dataGridView1.CurrentRow.Cells["cal_total"].Value));
                //  dataGridView2.Rows[i].Cells["cal_status_2"].Value = "I";
                dataGridView2.Rows[i].Cells["cal_category_2"].Value = dataGridView1.CurrentRow.Cells["cal_category_name"].Value;
                dataGridView2.Rows[i].Cells["cal_order_id_2"].Value = dataGridView1.CurrentRow.Cells["cal_order_id"].Value;
                dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
            }


        }

        private void btn_main_course_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count > 0)
            {

                i = dataGridView3.Rows.Count;
                dataGridView3.Rows.Add();
                dataGridView3.Rows[i].Cells["cal_item_3"].Value = dataGridView1.CurrentRow.Cells["cal_item_name"].Value;
                dataGridView3.Rows[i].Cells["cal_kot_print_3"].Value = dataGridView1.CurrentRow.Cells["cal_kot_print"].Value;
                decimal qty = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["cal_qty"].Value);
                dataGridView3.Rows[i].Cells["cal_qty_3"].Value = qty;
                dataGridView3.Rows[i].Cells["cal_cost_3"].Value = dataGridView1.CurrentRow.Cells["cal_cost"].Value;
                dataGridView3.Rows[i].Cells["cal_total_3"].Value = (Convert.ToDecimal(dataGridView1.CurrentRow.Cells["cal_cost"].Value));
                dataGridView3.Rows[i].Cells["cal_order_id_3"].Value = dataGridView1.CurrentRow.Cells["cal_order_id"].Value;
                dataGridView3.Rows[i].Cells["cal_category_3"].Value = dataGridView1.CurrentRow.Cells["cal_category_name"].Value;
                dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);

            }
        }

        private void btn_desert_Click(object sender, EventArgs e)
        {
            bool Found = false;
            if (dataGridView1.SelectedRows.Count > 0)
            {

                i = dataGridView4.Rows.Count;
                dataGridView4.Rows.Add();
                dataGridView4.Rows[i].Cells["cal_item_4"].Value = dataGridView1.CurrentRow.Cells["cal_item_name"].Value;
                dataGridView4.Rows[i].Cells["cal_kot_print_4"].Value = dataGridView1.CurrentRow.Cells["cal_kot_print"].Value;
                decimal qty = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["cal_qty"].Value);
                dataGridView4.Rows[i].Cells["cal_qty_4"].Value = qty;
                dataGridView4.Rows[i].Cells["cal_cost_4"].Value = dataGridView1.CurrentRow.Cells["cal_cost"].Value;
                dataGridView4.Rows[i].Cells["cal_total_4"].Value = (Convert.ToDecimal(dataGridView1.CurrentRow.Cells["cal_cost"].Value));
                dataGridView4.Rows[i].Cells["cal_order_id_4"].Value = dataGridView1.CurrentRow.Cells["cal_order_id"].Value;
                dataGridView4.Rows[i].Cells["cal_category_4"].Value = dataGridView1.CurrentRow.Cells["cal_category_name"].Value;
                dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);


            }
        }

        private void btn_move_all_rows_left_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                i = dataGridView1.Rows.Count;
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells["cal_item_name"].Value = dataGridView2.CurrentRow.Cells["cal_item_name2"].Value;
                dataGridView1.Rows[i].Cells["cal_kot_print"].Value = dataGridView2.CurrentRow.Cells["cal_kot_print_2"].Value;
                dataGridView1.Rows[i].Cells["cal_qty"].Value = dataGridView2.CurrentRow.Cells["cal_qty_2"].Value;
                dataGridView1.Rows[i].Cells["cal_cost"].Value = dataGridView2.CurrentRow.Cells["cal_cost_2"].Value;
                dataGridView1.Rows[i].Cells["cal_total"].Value = (Convert.ToDecimal(dataGridView2.CurrentRow.Cells["cal_total_2"].Value));
                // dataGridView1.Rows[i].Cells["cal_status"].Value = "U";
                dataGridView1.Rows[i].Cells["cal_category_name"].Value = dataGridView2.CurrentRow.Cells["cal_category_2"].Value;
                dataGridView1.Rows[i].Cells["cal_order_id"].Value = dataGridView2.CurrentRow.Cells["cal_order_id_2"].Value;
                dataGridView2.Rows.RemoveAt(dataGridView2.CurrentRow.Index);
            }
            else if (dataGridView3.SelectedRows.Count > 0)
            {
                i = dataGridView1.Rows.Count;
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells["cal_item_name"].Value = dataGridView3.CurrentRow.Cells["cal_item_3"].Value;
                dataGridView1.Rows[i].Cells["cal_kot_print"].Value = dataGridView3.CurrentRow.Cells["cal_kot_print_3"].Value;
                dataGridView1.Rows[i].Cells["cal_qty"].Value = dataGridView3.CurrentRow.Cells["cal_qty_3"].Value;
                dataGridView1.Rows[i].Cells["cal_cost"].Value = dataGridView3.CurrentRow.Cells["cal_cost_3"].Value;
                dataGridView1.Rows[i].Cells["cal_total"].Value = (Convert.ToDecimal(dataGridView3.CurrentRow.Cells["cal_total_3"].Value));
                // dataGridView1.Rows[i].Cells["cal_status"].Value = "U";
                dataGridView1.Rows[i].Cells["cal_category_name"].Value = dataGridView3.CurrentRow.Cells["cal_category_3"].Value;
                dataGridView1.Rows[i].Cells["cal_order_id"].Value = dataGridView3.CurrentRow.Cells["cal_order_id_3"].Value;
                dataGridView3.Rows.RemoveAt(dataGridView3.CurrentRow.Index);
            }
            else if (dataGridView4.SelectedRows.Count > 0)
            {
                i = dataGridView1.Rows.Count;
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells["cal_item_name"].Value = dataGridView4.CurrentRow.Cells["cal_item_4"].Value;
                dataGridView1.Rows[i].Cells["cal_kot_print"].Value = dataGridView4.CurrentRow.Cells["cal_kot_print_4"].Value;
                dataGridView1.Rows[i].Cells["cal_qty"].Value = dataGridView4.CurrentRow.Cells["cal_qty_4"].Value;
                dataGridView1.Rows[i].Cells["cal_cost"].Value = dataGridView4.CurrentRow.Cells["cal_cost_4"].Value;
                dataGridView1.Rows[i].Cells["cal_total"].Value = (Convert.ToDecimal(dataGridView4.CurrentRow.Cells["cal_total_4"].Value));
                //dataGridView1.Rows[i].Cells["cal_status"].Value = "U";
                dataGridView1.Rows[i].Cells["cal_category_name"].Value = dataGridView4.CurrentRow.Cells["cal_category_4"].Value;
                dataGridView1.Rows[i].Cells["cal_order_id"].Value = dataGridView4.CurrentRow.Cells["cal_order_id_4"].Value;
                dataGridView4.Rows.RemoveAt(dataGridView4.CurrentRow.Index);
            }
        }
        bool click = true;
        private void btn_refresh_Click(object sender, EventArgs e)
        {
            if (click == true)
            {
                KOTOrderManagement_Load(null, null);
            }
            click = false;
            dataGridView2.Rows.Clear();
            dataGridView3.Rows.Clear();
            dataGridView4.Rows.Clear();
        }
        public void datagridviewload_startup()
        {
            dataGridView2.Rows.Clear();
            DataTable dt = new DataTable();
            dt = blord.getalldata(Convert.ToDecimal(table_no));
            if (dt.Rows.Count > 0)
            {
                for (int z = 0; z < dt.Rows.Count; z++)
                {
                    dataGridView2.Rows.Add();
                    dataGridView2.Rows[z].Cells["cal_order_id_2"].Value = dt.Rows[z]["order_id"].ToString();
                    dataGridView2.Rows[z].Cells["cal_item_name2"].Value = dt.Rows[z]["item"].ToString();
                    string xyz = dt.Rows[z]["quantity"].ToString();
                    dataGridView2.Rows[z].Cells["cal_qty_2"].Value = xyz;

                    dataGridView2.Rows[z].Cells["cal_total_2"].Value = dt.Rows[z]["total"].ToString();
                    dataGridView2.Rows[z].Cells["cal_cost_2"].Value = dt.Rows[z]["cost"].ToString();
                    dataGridView2.Rows[z].Cells["cal_category_2"].Value = dt.Rows[z]["category_name"].ToString();
                    dataGridView2.Rows[z].Cells["cal_kot_print_2"].Value = dt.Rows[z]["kot_print"].ToString();
                    //dataGridView2.Rows[z].Cells["cal_note"].Value = "";

                }

            }

        }
        public void datagridviewload_maincourse()
        {
            dataGridView3.Rows.Clear();
            DataTable dt = new DataTable();
            dt = blord.getalldata(Convert.ToDecimal(table_no));
            if (dt.Rows.Count > 0)
            {
                for (int z = 0; z < dt.Rows.Count; z++)
                {
                    dataGridView3.Rows.Add();
                    dataGridView3.Rows[z].Cells["cal_order_id_3"].Value = dt.Rows[z]["order_id"].ToString();
                    dataGridView3.Rows[z].Cells["cal_item_3"].Value = dt.Rows[z]["item"].ToString();
                    string xyz = dt.Rows[z]["quantity"].ToString();
                    dataGridView3.Rows[z].Cells["cal_qty_3"].Value = xyz;

                    dataGridView3.Rows[z].Cells["cal_total_3"].Value = dt.Rows[z]["total"].ToString();
                    dataGridView3.Rows[z].Cells["cal_cost_3"].Value = dt.Rows[z]["cost"].ToString();
                    dataGridView3.Rows[z].Cells["cal_category_3"].Value = dt.Rows[z]["category_name"].ToString();
                    dataGridView3.Rows[z].Cells["cal_kot_print_3"].Value = dt.Rows[z]["kot_print"].ToString();
                    //dataGridView2.Rows[z].Cells["cal_note"].Value = "";

                }

            }

        }
        public void datagridviewload_dessert()
        {
            dataGridView4.Rows.Clear();
            DataTable dt = new DataTable();
            dt = blord.getalldata(Convert.ToDecimal(table_no));
            if (dt.Rows.Count > 0)
            {
                for (int z = 0; z < dt.Rows.Count; z++)
                {
                    dataGridView4.Rows.Add();
                    dataGridView4.Rows[z].Cells["cal_order_id_4"].Value = dt.Rows[z]["order_id"].ToString();
                    dataGridView4.Rows[z].Cells["cal_item_4"].Value = dt.Rows[z]["item"].ToString();
                    string xyz = dt.Rows[z]["quantity"].ToString();
                    dataGridView4.Rows[z].Cells["cal_qty_4"].Value = xyz;

                    dataGridView4.Rows[z].Cells["cal_total_4"].Value = dt.Rows[z]["total"].ToString();
                    dataGridView4.Rows[z].Cells["cal_cost_4"].Value = dt.Rows[z]["cost"].ToString();
                    dataGridView4.Rows[z].Cells["cal_category_4"].Value = dt.Rows[z]["category_name"].ToString();
                    dataGridView4.Rows[z].Cells["cal_kot_print_4"].Value = dt.Rows[z]["kot_print"].ToString();
                    //dataGridView2.Rows[z].Cells["cal_note"].Value = "";

                }

            }

        }
        string service_provider_name;
        int kot_id;

        private void btn_startup_set_Click(object sender, EventArgs e)
        {
            if (dataGridView2.Rows.Count > 0)
            {
                for (int ib = 0; ib < dataGridView2.Rows.Count; ib++)
                {
                    //order_id_sender();
                    string item_name = dataGridView2.Rows[ib].Cells["cal_item_name2"].Value.ToString();
                    decimal quantity = Convert.ToDecimal(dataGridView2.Rows[ib].Cells["cal_qty_2"].Value.ToString());
                    decimal cost = Convert.ToDecimal(dataGridView2.Rows[ib].Cells["cal_cost_2"].Value.ToString());
                    decimal total = Convert.ToDecimal(dataGridView2.Rows[ib].Cells["cal_total_2"].Value.ToString());
                    string category_name = dataGridView2.Rows[ib].Cells["cal_category_2"].Value.ToString();
                    string kot_print = dataGridView2.Rows[ib].Cells["cal_kot_print_2"].Value.ToString();

                    DateTime todaydate = DateTime.Now;
                    string time = DateTime.Now.ToShortTimeString();
                    if (dataGridView2.Rows[ib].Cells["cal_order_id_2"].Value == null)
                    {
                        int insert_order_print = blord.insertorderfire(Login.sendtext, Convert.ToDecimal(table_no), item_name, quantity, total, cost, "T", category_name, kot_print, sales_type, service_provider, kot_id, "Startup");
                        //   datagridviewload_startup();
                    }
                }
                // startup_set_load();
                datagridviewload_startup();
                dataGridView2.Rows.Clear();
                startup_set_load();

            }

        }
        bool kot_printer_1 = false;
        bool kot_printer_2 = false;
        bool kot_printer_3 = false;
        bool kot_printer_4 = false;
        bool kot_printer_5 = false;
        KOTPrinting56 kot = new KOTPrinting56();
        string fire_type;
        int insert_order_print;

        private void btn_startup_fire_Click(object sender, EventArgs e)
        {
            fire_type = "startup";
            if (dataGridView2.Rows.Count > 0)
            {
                for (int ib = 0; ib < dataGridView2.Rows.Count; ib++)
                {
                    // order_id_sender();
                    string item_name = dataGridView2.Rows[ib].Cells["cal_item_name2"].Value.ToString();
                    decimal quantity = Convert.ToDecimal(dataGridView2.Rows[ib].Cells["cal_qty_2"].Value.ToString());
                    decimal cost = Convert.ToDecimal(dataGridView2.Rows[ib].Cells["cal_cost_2"].Value.ToString());
                    decimal total = Convert.ToDecimal(dataGridView2.Rows[ib].Cells["cal_total_2"].Value.ToString());
                    string category_name = dataGridView2.Rows[ib].Cells["cal_category_2"].Value.ToString();
                    string kot_print = dataGridView2.Rows[ib].Cells["cal_kot_print_2"].Value.ToString();
                    dataGridView2.Rows[ib].Cells["cal_order_id_2"].Value = null;
                    DateTime todaydate = DateTime.Now;
                    string time = DateTime.Now.ToShortTimeString();
                
                        if (dataGridView2.Rows[ib].Cells["cal_order_id_2"].Value == null)
                        {
                            insert_order_print = blord.insertorder_using_sp(Login.sendtext, Convert.ToDecimal(table_no), item_name, quantity, total, cost, "T", category_name, kot_print, sales_type, service_provider, kot_id);
                            if (dataGridView2.Rows[ib].Cells["cal_kot_print_2"].Value.ToString() == "K1")
                            {
                                kot_printer_1 = true;
                            }
                            if (dataGridView2.Rows[ib].Cells["cal_kot_print_2"].Value.ToString() == "K2")
                            {
                                kot_printer_2 = true;
                            }
                            if (dataGridView2.Rows[ib].Cells["cal_kot_print_2"].Value.ToString() == "B1")
                            {
                                kot_printer_3 = true;
                            }
                            if (dataGridView2.Rows[ib].Cells["cal_kot_print_2"].Value.ToString() == "B2")
                            {
                                kot_printer_4 = true;
                            }
                            if (dataGridView2.Rows[ib].Cells["cal_kot_print_2"].Value.ToString() == "K3")
                            {
                                kot_printer_5 = true;
                            }
                        }

                    }
                
                if (insert_order_print > 0)
                {
                    KotOrcerId();

                    kot_printChecker();
                    KotPrintStatus();
                    dataGridView2.Rows.Clear();
                    // datagridviewload_startup();
               }
                int delete = blord.deletefromorderfire_id(Convert.ToInt32(table_no));
            }

        }

        private void btn_main_fire_Click(object sender, EventArgs e)
        {
            fire_type = "main course";
            if (dataGridView3.Rows.Count > 0)
            {
                for (int ib = 0; ib < dataGridView3.Rows.Count; ib++)
                {

                    string item_name = dataGridView3.Rows[ib].Cells["cal_item_3"].Value.ToString();
                    decimal quantity = Convert.ToDecimal(dataGridView3.Rows[ib].Cells["cal_qty_3"].Value.ToString());
                    decimal cost = Convert.ToDecimal(dataGridView3.Rows[ib].Cells["cal_cost_3"].Value.ToString());

                    decimal total = Convert.ToDecimal(dataGridView3.Rows[ib].Cells["cal_total_3"].Value.ToString());
                    string category_name = dataGridView3.Rows[ib].Cells["cal_category_3"].Value.ToString();
                    string kot_print = dataGridView3.Rows[ib].Cells["cal_kot_print_3"].Value.ToString();
                    dataGridView3.Rows[ib].Cells["cal_order_id_3"].Value = null;
                    DateTime todaydate = DateTime.Now;
                    string time = DateTime.Now.ToShortTimeString();
                    if (dataGridView3.Rows[ib].Cells["cal_order_id_3"].Value == null)
                    {
                         insert_order_print = blord.insertorder_using_sp(Login.sendtext, Convert.ToDecimal(table_no), item_name, quantity, total, cost, "T", category_name, kot_print, sales_type, service_provider, kot_id);
                        if (dataGridView3.Rows[ib].Cells["cal_kot_print_3"].Value.ToString() == "K1")
                        {
                            kot_printer_1 = true;
                        }
                        if (dataGridView3.Rows[ib].Cells["cal_kot_print_3"].Value.ToString() == "K2")
                        {
                            kot_printer_2 = true;
                        }
                        if (dataGridView3.Rows[ib].Cells["cal_kot_print_3"].Value.ToString() == "B1")
                        {
                            kot_printer_3 = true;
                        }
                        if (dataGridView3.Rows[ib].Cells["cal_kot_print_3"].Value.ToString() == "B2")
                        {
                            kot_printer_4 = true;
                        }
                        if (dataGridView3.Rows[ib].Cells["cal_kot_print_3"].Value.ToString() == "K3")
                        {
                            kot_printer_5 = true;
                        }
                    }
                }
                    if (insert_order_print > 0)
                    {
                        KotOrcerId();
                        kot_printChecker();
                        // datagridviewload_maincourse();
                        KotPrintStatus();
                        dataGridView3.Rows.Clear();
                    }
                    int delete = blord.deletefromorderfire_id(Convert.ToInt32(table_no));

                }
            }

     
    
        private void btn_main_set_Click(object sender, EventArgs e)
        {
            if (dataGridView3.Rows.Count > 0)
            {
                for (int ib = 0; ib < dataGridView3.Rows.Count; ib++)
                {
                    //order_id_sender();
                    string item_name = dataGridView3.Rows[ib].Cells["cal_item_3"].Value.ToString();
                    decimal quantity = Convert.ToDecimal(dataGridView3.Rows[ib].Cells["cal_qty_3"].Value.ToString());
                    decimal cost = Convert.ToDecimal(dataGridView3.Rows[ib].Cells["cal_cost_3"].Value.ToString());
                    
                    decimal total = Convert.ToDecimal(dataGridView3.Rows[ib].Cells["cal_total_3"].Value.ToString());
                    string category_name = dataGridView3.Rows[ib].Cells["cal_category_3"].Value.ToString();
                    string kot_print = dataGridView3.Rows[ib].Cells["cal_kot_print_3"].Value.ToString();
                   
                    DateTime todaydate = DateTime.Now;
                    string time = DateTime.Now.ToShortTimeString();
                    if (dataGridView3.Rows[ib].Cells["cal_order_id_3"].Value == null)
                    {
                        int insert_order_print = blord.insertorderfire(Login.sendtext, Convert.ToDecimal(table_no), item_name, quantity, total, cost, "T", category_name, kot_print, sales_type, service_provider, kot_id, "Main Course");
                        //datagridviewload_maincourse();
                    }
                }
                datagridviewload_maincourse();
                dataGridView3.Rows.Clear();
                maincourse_set_laod();
            }
        
        }
        
     
        private void btn_dessert_fire_Click(object sender, EventArgs e)
        {
            fire_type = "dessert";
            if (dataGridView4.Rows.Count > 0)
            {
                for (int ib = 0; ib < dataGridView4.Rows.Count; ib++)
                {

                    string item_name = dataGridView4.Rows[ib].Cells["cal_item_4"].Value.ToString();
                    decimal quantity = Convert.ToDecimal(dataGridView4.Rows[ib].Cells["cal_qty_4"].Value.ToString());
                    decimal cost = Convert.ToDecimal(dataGridView4.Rows[ib].Cells["cal_cost_4"].Value.ToString());

                    decimal total = Convert.ToDecimal(dataGridView4.Rows[ib].Cells["cal_total_4"].Value.ToString());
                    string category_name = dataGridView4.Rows[ib].Cells["cal_category_4"].Value.ToString();
                    string kot_print = dataGridView4.Rows[ib].Cells["cal_kot_print_4"].Value.ToString();
                    dataGridView4.Rows[ib].Cells["cal_order_id_4"].Value = null;
                    DateTime todaydate = DateTime.Now;
                    string time = DateTime.Now.ToShortTimeString();
                    if (dataGridView4.Rows[ib].Cells["cal_order_id_4"].Value == null)
                    {
                        insert_order_print = blord.insertorder_using_sp(Login.sendtext, Convert.ToDecimal(table_no), item_name, quantity, total, cost, "T", category_name, kot_print, sales_type, service_provider, kot_id);
                        if (dataGridView4.Rows[ib].Cells["cal_kot_print_4"].Value.ToString() == "K1")
                        {
                            kot_printer_1 = true;
                        }
                        if (dataGridView4.Rows[ib].Cells["cal_kot_print_4"].Value.ToString() == "K2")
                        {
                            kot_printer_2 = true;
                        }
                        if (dataGridView4.Rows[ib].Cells["cal_kot_print_4"].Value.ToString() == "B1")
                        {
                            kot_printer_3 = true;
                        }
                        if (dataGridView4.Rows[ib].Cells["cal_kot_print_4"].Value.ToString() == "B2")
                        {
                            kot_printer_4 = true;
                        }
                        if (dataGridView4.Rows[ib].Cells["cal_kot_print_4"].Value.ToString() == "K3")
                        {
                            kot_printer_5 = true;
                        }
                    }
                }
                        if (insert_order_print > 0)
                        {
                            KotOrcerId();
                            kot_printChecker();
                            // datagridviewload_dessert();
                             KotPrintStatus();
                            dataGridView4.Rows.Clear();
                        }
                        int delete = blord.deletefromorderfire_id(Convert.ToInt32(table_no));

                    }
                }
        
        private void btn_dessert_set_Click(object sender, EventArgs e)
        {
            if (dataGridView4.Rows.Count > 0)
            {
                for (int ib = 0; ib < dataGridView4.Rows.Count; ib++)
                {
                    
                    string item_name = dataGridView4.Rows[ib].Cells["cal_item_4"].Value.ToString();
                    decimal quantity = Convert.ToDecimal(dataGridView4.Rows[ib].Cells["cal_qty_4"].Value.ToString());
                    decimal cost = Convert.ToDecimal(dataGridView4.Rows[ib].Cells["cal_cost_4"].Value.ToString());
                    
                    decimal total = Convert.ToDecimal(dataGridView4.Rows[ib].Cells["cal_total_4"].Value.ToString());
                    string category_name = dataGridView4.Rows[ib].Cells["cal_category_4"].Value.ToString();
                    string kot_print = dataGridView4.Rows[ib].Cells["cal_kot_print_4"].Value.ToString();
                   
                    DateTime todaydate = DateTime.Now;
                    string time = DateTime.Now.ToShortTimeString();
                    if (dataGridView4.Rows[ib].Cells["cal_order_id_4"].Value == null)
                    {
                        int insert_order_print = blord.insertorderfire(Login.sendtext, Convert.ToDecimal(table_no), item_name, quantity, total, cost, "T", category_name, kot_print, sales_type, service_provider, kot_id, "Dessert");
                      //  datagridviewload_dessert();
                    }
                }
                datagridviewload_dessert();
                dataGridView4.Rows.Clear();
                dessert_set_laod();
            }
          
        }
        public void KotPrintStatus()
        {
            kot_printer_1 = false;
            kot_printer_2 = false;
            kot_printer_3 = false;
            kot_printer_4 = false;
            kot_printer_5 = false;
        }
        public void kot_printing_56_startup()
        {
            kot.table_no = table_no;
            kot.table_display_no = table_no;
            kot.table_name = table_name;
           // kot.note_pad = txtrichbox.Text;_load
            kot.cashier = Login.sendtext;
            kot.service_provider = service_provider_name;
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                if (dataGridView2.Rows[i].Cells["cal_order_id_2"].Value == null)
                {
                    kot.datagridview_name.Add(dataGridView2.Rows[i].Cells["cal_item_name2"].Value.ToString());
                    kot.datagridview_qty.Add(dataGridView2.Rows[i].Cells["cal_qty_2"].Value.ToString());
                    kot.datagridview_kot_print.Add(dataGridView2.Rows[i].Cells["cal_kot_print_2"].Value.ToString());
                    //kot.datagridview_modifier.Add((dataGridView1.Rows[i].Cells["cal_description"].Value ?? string.Empty).ToString());
                }
            }

        }
        public void kot_printing_56_maincourse()
        {
            kot.table_no = table_no;
            kot.table_display_no = table_no;
            kot.table_name = table_name;
            // kot.note_pad = txtrichbox.Text;
            kot.cashier = Login.sendtext;
            kot.service_provider = service_provider_name;
            for (int i = 0; i < dataGridView3.Rows.Count; i++)
            {
                if (dataGridView3.Rows[i].Cells["cal_order_id_3"].Value == null)
                {
                    kot.datagridview_name.Add(dataGridView3.Rows[i].Cells["cal_item_3"].Value.ToString());
                    kot.datagridview_qty.Add(dataGridView3.Rows[i].Cells["cal_qty_3"].Value.ToString());
                    kot.datagridview_kot_print.Add(dataGridView3.Rows[i].Cells["cal_kot_print_3"].Value.ToString());
                    //kot.datagridview_modifier.Add((dataGridView1.Rows[i].Cells["cal_description"].Value ?? string.Empty).ToString());
                }
            }
        }
        public void kot_printing_56_dessert()
        {
            kot.table_no = table_no;
            kot.table_display_no = table_no;
            kot.table_name = table_name;
            // kot.note_pad = txtrichbox.Text;
            kot.cashier = Login.sendtext;
            kot.service_provider = service_provider_name;
            for (int i = 0; i < dataGridView4.Rows.Count; i++)
            {
                if (dataGridView4.Rows[i].Cells["cal_order_id_4"].Value == null)
                {
                    kot.datagridview_name.Add(dataGridView4.Rows[i].Cells["cal_item_4"].Value.ToString());
                    kot.datagridview_qty.Add(dataGridView4.Rows[i].Cells["cal_qty_4"].Value.ToString());
                    kot.datagridview_kot_print.Add(dataGridView4.Rows[i].Cells["cal_kot_print_4"].Value.ToString());
                    //kot.datagridview_modifier.Add((dataGridView1.Rows[i].Cells["cal_description"].Value ?? string.Empty).ToString());
                }
            }
        }
        KOTPrinting80 kot80 = new KOTPrinting80();
        BLLPrinterSetting blpt = new BLLPrinterSetting();
        public void kot_printing_80_startup()
        {
            kot80.table_no =table_no;
            kot80.table_displayNo =table_no;
            kot80.table_name = table_name;
           // kot80.note_pad = txtrichbox.Text;
            kot80.cashier = Login.sendtext;
            kot80.service_provider_name = service_provider_name;
            kot80.kot_id = kot_id.ToString();
            kot80.kid = KitchenOrderInfo.kid;
            kot80.adult = KitchenOrderInfo.adult;
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                if (dataGridView2.Rows[i].Cells["cal_order_id_2"].Value == null)
                {
                    kot80.datagridview_name.Add(dataGridView2.Rows[i].Cells["cal_item_name2"].Value.ToString());
                    kot80.datagridview_qty.Add(dataGridView2.Rows[i].Cells["cal_qty_2"].Value.ToString());
                    kot80.datagridview_kot_print.Add(dataGridView2.Rows[i].Cells["cal_kot_print_2"].Value.ToString());
                   // kot80.datagridview_modifier.Add((dataGridView2.Rows[i].Cells["cal_description"].Value ?? string.Empty).ToString());
                }
            }

        }
        public void kot_printing_80_maincourse()
        {
            kot80.table_no = table_no;
            kot80.table_displayNo = table_no;
            kot80.table_name = table_name;
            // kot80.note_pad = txtrichbox.Text;
            kot80.cashier = Login.sendtext;
            kot80.service_provider_name = service_provider_name;
            kot80.kot_id = kot_id.ToString();
            kot80.kid = KitchenOrderInfo.kid;
            kot80.adult = KitchenOrderInfo.adult;
            for (int i = 0; i < dataGridView3.Rows.Count; i++)
            {
                if (dataGridView3.Rows[i].Cells["cal_order_id_3"].Value == null)
                {
                    kot80.datagridview_name.Add(dataGridView3.Rows[i].Cells["cal_item_3"].Value.ToString());
                    kot80.datagridview_qty.Add(dataGridView3.Rows[i].Cells["cal_qty_3"].Value.ToString());
                    kot80.datagridview_kot_print.Add(dataGridView3.Rows[i].Cells["cal_kot_print_3"].Value.ToString());
                    // kot80.datagridview_modifier.Add((dataGridView2.Rows[i].Cells["cal_description"].Value ?? string.Empty).ToString());
                }
            }

        }
        public void kot_printing_80_dessert()
        {
            kot80.table_no = table_no;
            kot80.table_displayNo = table_no;
            kot80.table_name = table_name;
            // kot80.note_pad = txtrichbox.Text;
            kot80.cashier = Login.sendtext;
            kot80.service_provider_name = service_provider_name;
            kot80.kot_id = kot_id.ToString();
            kot80.kid = KitchenOrderInfo.kid;
            kot80.adult = KitchenOrderInfo.adult;
            for (int i = 0; i < dataGridView4.Rows.Count; i++)
            {
                if (dataGridView4.Rows[i].Cells["cal_order_id_4"].Value == null)
                {
                    kot80.datagridview_name.Add(dataGridView4.Rows[i].Cells["cal_item_4"].Value.ToString());
                    kot80.datagridview_qty.Add(dataGridView4.Rows[i].Cells["cal_qty_4"].Value.ToString());
                    kot80.datagridview_kot_print.Add(dataGridView4.Rows[i].Cells["cal_kot_print_4"].Value.ToString());
                    // kot80.datagridview_modifier.Add((dataGridView2.Rows[i].Cells["cal_description"].Value ?? string.Empty).ToString());
                }
            }

        }
        public void KotOrcerId()
        {
            DataTable dt = blord.GetMaxKotId();
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0][0].ToString() == "")
                {
                    kot_id = 1;

                }
                else
                {
                    kot_id = Convert.ToInt32(dt.Rows[0][0].ToString()) + 1;

                }
            }

        }
        public void kot_printChecker()
        {
            DataTable dt_prt = blpt.getalldata();
            DataTable dtp = blpt.getallPrintingTimes();
            if (dt_prt.Rows[0]["kot_printer"].ToString() == "80")
            {
                if (kot_printer_1 == true)
                {
                    if (dtp.Rows.Count > 0)
                    {
                        for (int i = 0; i < Convert.ToInt32(dtp.Rows[0]["K1"]); i++)
                        {
                            kot80.printerName = "K1";
                            if (fire_type == "startup")
                            {
                                kot_printing_80_startup();
                            }
                            else if (fire_type == "main course")
                            {
                                kot_printing_80_maincourse();
                            }
                            else
                            {
                                kot_printing_80_dessert();
                            }
                            kot80.printkot();
                            kot80.clear_data();
                            kot_printer_1 = kot80.kot_printer_1;
                        }
                    }
                }
                if (kot_printer_2 == true)
                {
                    if (dtp.Rows.Count > 0)
                    {
                        for (int i = 0; i < Convert.ToInt32(dtp.Rows[0]["K2"]); i++)
                        {
                            kot80.printerName = "K2";
                            if (fire_type == "startup")
                            {
                                kot_printing_80_startup();
                            }
                            else if (fire_type == "main course")
                            {
                                kot_printing_80_maincourse();
                            }
                            else
                            {
                                kot_printing_80_dessert();
                            }
                            kot80.printkot();
                            kot_printer_2 = kot80.kot_printer_1;
                        }
                    }
                }
                if (kot_printer_3 == true)
                {
                    if (dtp.Rows.Count > 0)
                    {
                        for (int i = 0; i < Convert.ToInt32(dtp.Rows[0]["BOT"]); i++)
                        {
                            kot80.printerName = "B1";
                            if (fire_type == "startup")
                            {
                                kot_printing_80_startup();
                            }
                            else if (fire_type == "main course")
                            {
                                kot_printing_80_maincourse();
                            }
                            else
                            {
                                kot_printing_80_dessert();
                            }
                            kot80.printkot();
                            kot_printer_3 = kot80.kot_printer_1;

                        }
                    }
                }
                if (kot_printer_4 == true)
                {
                    if (dtp.Rows.Count > 0)
                    {
                        for (int i = 0; i < Convert.ToInt32(dtp.Rows[0]["BOT"]); i++)
                        {
                            kot80.printerName = "B2";
                            if (fire_type == "startup")
                            {
                                kot_printing_80_startup();
                            }
                            else if (fire_type == "main course")
                            {
                                kot_printing_80_maincourse();
                            }
                            else
                            {
                                kot_printing_80_dessert();
                            }
                            kot80.printkot();
                            kot_printer_4 = kot80.kot_printer_1;

                        }
                    }
                }
                if (kot_printer_5 == true)
                {
                    if (dtp.Rows.Count > 0)
                    {
                        for (int i = 0; i < Convert.ToInt32(dtp.Rows[0]["K1"]); i++)
                        {
                            kot80.printerName = "K3";
                            if (fire_type == "startup")
                            {
                                kot_printing_80_startup();
                            }
                            else if (fire_type == "main course")
                            {
                                kot_printing_80_maincourse();
                            }
                            else
                            {
                                kot_printing_80_dessert();
                            }
                            kot80.printkot();
                            kot_printer_5 = kot80.kot_printer_1;

                        }
                    }
                }
            }
            else
            {
                if (kot_printer_1 == true)
                {
                    if (dtp.Rows.Count > 0)
                    {
                        for (int i = 0; i < Convert.ToInt32(dtp.Rows[0]["K1"]); i++)
                        {
                            kot.printer_name = "K1";
                            if (fire_type == "startup")
                            {
                                kot_printing_56_startup();
                            }
                            else if (fire_type == "main course")
                            {
                                kot_printing_56_maincourse();
                            }
                            else
                            {
                                kot_printing_56_dessert();
                            }
                            kot.printkot();
                            kot_printer_1 = kot.kot_printer_1;
                        }
                    }
                }
                if (kot_printer_2 == true)
                {
                    if (dtp.Rows.Count > 0)
                    {
                        for (int i = 0; i < Convert.ToInt32(dtp.Rows[0]["K2"]); i++)
                        {
                            kot.printer_name = "K2";
                            if (fire_type == "startup")
                            {
                                kot_printing_56_startup();
                            }
                            else if (fire_type == "main course")
                            {
                                kot_printing_56_maincourse();
                            }
                            else
                            {
                                kot_printing_56_dessert();
                            }
                            kot.printkot();
                            kot_printer_2 = kot.kot_printer_1;
                        }
                    }
                }
                if (kot_printer_3 == true)
                {
                    if (dtp.Rows.Count > 0)
                    {
                        for (int i = 0; i < Convert.ToInt32(dtp.Rows[0]["BOT"]); i++)
                        {
                            kot.printer_name = "B1";
                            if (fire_type == "startup")
                            {
                                kot_printing_56_startup();
                            }
                            else if (fire_type == "main course")
                            {
                                kot_printing_56_maincourse();
                            }
                            else
                            {
                                kot_printing_56_dessert();
                            }
                            kot.printkot();
                            kot_printer_3 = kot.kot_printer_1;
                        }
                    }
                }
                if (kot_printer_4 == true)
                {
                    if (dtp.Rows.Count > 0)
                    {
                        for (int i = 0; i < Convert.ToInt32(dtp.Rows[0]["BOT"]); i++)
                        {
                            kot.printer_name = "B2";
                            if (fire_type == "startup")
                            {
                                kot_printing_56_startup();
                            }
                            else if (fire_type == "main course")
                            {
                                kot_printing_56_maincourse();
                            }
                            else
                            {
                                kot_printing_56_dessert();
                            }
                            kot.printkot();
                            kot_printer_4 = kot.kot_printer_1;
                        }
                    }
                }
                if (kot_printer_5 == true)
                {
                    if (dtp.Rows.Count > 0)
                    {
                        for (int i = 0; i < Convert.ToInt32(dtp.Rows[0]["K1"]); i++)
                        {
                            kot.printer_name = "K3";
                            if (fire_type == "startup")
                            {
                                kot_printing_56_startup();
                            }
                            else if (fire_type == "main course")
                            {
                                kot_printing_56_maincourse();
                            }
                            else
                            {
                                kot_printing_56_dessert();
                            }
                            kot.printkot();
                            kot_printer_5 = kot.kot_printer_1;
                        }
                    }
                }
            }
        }

    }
}

