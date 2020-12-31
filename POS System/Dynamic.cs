using BLLS;
using POS_System.Encryption;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_System
{
    public partial class Dynamic : Form
    {
        public Dynamic()
        {
            InitializeComponent();
        }
        BLLDynamic bld = new BLLDynamic();
        BLLPrinterSetting blpst = new BLLPrinterSetting();
        DataTable dt1 = new DataTable();
        private void Dynamic_Load(object sender, EventArgs e)
        {
            txt_min_tax_amount.Hide();
            label128.Hide();
            cmb_printer.SelectedIndex = 0;
            cmb_kot_print.SelectedIndex = 0;
            cmb_bill_print.SelectedIndex = 0;
            
            dt1 = bll.GetIrdInfo();
            if (dt1.Rows.Count > 0)
            {
                lbl_id.Text = dt1.Rows[0]["ird_id"].ToString();
                txtipaddress.Text = dt1.Rows[0]["ip_address"].ToString();
              //  txtpassword.Text = dt1.Rows[0]["password"].ToString();
                txtusername.Text = dt1.Rows[0]["username"].ToString();
                btn_update.Visible = true;
                btn_save.Visible = false;
            }
            else
            {
                txtpassword.ForeColor = SystemColors.GrayText;
                txtpassword.Text = "Password";
                btn_save.Visible = true;
                btn_update.Visible = false;
            }
            DataTable dt = bld.GetTrueDynamic();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string code = dt.Rows[i]["code"].ToString();
                    if (code == "TB")
                    {
                        chk_tb.Checked = true;
                        status = "True";
                    }
                   
                    if (code == "FL")
                    {
                        string description = dt.Rows[i]["description"].ToString();
                        if (description == "Table Load")
                        {
                            rbn_tl.Checked = true;
                        }
                        else if (description == "KFC Load")
                        {
                            rbn_kfc.Checked = true;
                        }
                        else
                        {
                            rbn_ta.Checked = true;
                        }
                    }
                    if (code=="CHDP")
                    {
                        string description = dt.Rows[i]["description"].ToString();
                        if (description == "Customer First")
                        {
                            rbn_customerfirst.Checked = true;
                        }
                        else
                        {
                            rbn_deliveryfirst.Checked = true;
                        }
                    }
                    if (code == "TOP")
                    {
                        string description = dt.Rows[i]["description"].ToString();
                        if (description == "Customer First")
                        {
                            rbn_table_customer.Checked = true;
                        }
                        else
                        {
                            rbn_tablefirst.Checked = true;
                        }
                    }
                    if (code == "TAP")
                    {
                        string description = dt.Rows[i]["description"].ToString();
                        if (description == "Customer First")
                        {
                            rbn_tacustomer.Checked = true;
                        }
                        else
                        {
                            rbn_tafirst.Checked = true;
                        }
                    }
                    if (code == "TP")
                    {
                        string description = dt.Rows[i]["description"].ToString();
                        if (description == "Customer First")
                        {
                            rbn_customer_first.Checked = true;
                        }
                        else
                        {
                            rbn_kotfirst.Checked = true;
                        }
                    }
                    if (code == "BT")
                    {
                        string description = dt.Rows[i]["description"].ToString();
                        if (description == "Restaurant")
                        {
                            rbn_restaurant.Checked = true;
                        }
                        else if (description=="Bakery")
                        {
                            rbn_bakery.Checked = true;
                        }
                        else
                        {
                            rbn_parlour.Checked = true;
                        }
                    }
                    if (code == "ATU")
                    {
                        string description = dt.Rows[i]["description"].ToString();
                        string chk_abbr = dt.Rows[i]["status"].ToString();
                        txt_min_tax_amount.Text =description;
                        if (chk_abbr == "True")
                        {
                            chk_brief_tax.Checked = true;
                        }
                        else
                        {
                            chk_brief_tax.Checked = false;
                        }
                    }
                    if (code == "AAD")
                    {
                        chk_discount.Checked = true;
                    }
                    if (code == "FG")
                    {
                        chk_fix_grouping.Checked = true;
                    }
                    if (code == "HG")
                    {
                        chk_hide_grouping.Checked = true;
                    }
                    if (code == "AAC")
                    {
                        chk_complementry.Checked = true;
                    }
                    if (code == "AADlt")
                    {
                        chk_delete.Checked = true;
                    }
                    if (code == "AACL")
                    {
                        chk_cancel.Checked = true;
                    }
                    if (code == "SCTA")
                    {
                        chk_takeaway.Checked = true;
                    }
                    if (code == "SCT")
                    {
                        chk_table.Checked = true;
                    }
                    if (code == "SCTB")
                    {
                        chk_token.Checked = true;
                    }
                    if (code == "RSC")
                    {
                        chk_roomsc.Checked = true;
                    }
                    if (code == "SPA")
                    {
                        chk_sp.Checked = true;
                    }
                    if (code == "QA")
                    {
                        chk_qa.Checked = true;
                    }
                    if (code == "CD")
                    {
                        chk_chequedetail.Checked = true;
                    }
                    if (code == "GTIW")
                    {
                        chk_grandtotal.Checked = true;
                    }
                    if (code == "BPF")
                    {
                        chk_billfooter.Checked = true;
                    }
                    if (code=="CSA")
                    {
                        chk_comp.Checked = true;
                    }
                    if (code == "CPA")
                    {
                        chk_comp_print.Checked = true;
                    }
                    if (code == "DEM")
                    {
                        chk_mail.Checked = true;
                    }
                    if (code == "QPH")
                    {
                        chk_header.Checked = true;
                    }
             
                    if (code == "QPF")
                    {
                        chk_footer.Checked = true;
                    }
                    if (code == "HED")
                    {
                        chk_hotel.Checked = true;
                    }
                    if (code == "SM001")
                    {
                        chk_grouping.Checked = true;
                    }
                    if (code == "BEC")
                    {
                        chk_estimate.Checked = true;
                    }
                    if (code == "BDC")
                    {
                        chk_compare_discount.Checked = true;
                    }
                    if (code == "KED")
                    {
                        chk_kot.Checked = true;
                    }
                    if (code == "KSED")
                    {
                        chk_kotsave.Checked = true;
                    }
                    if (code == "SM002")
                    {
                        chk_topsales.Checked = true;
                    }
                    if (code == "PCD")
                    {
                        chk_pay.Checked = true;
                    }
                    if (code == "AA")
                    {
                        chk_account.Checked = true;
                    }
                    if (code == "CU")
                    {
                        chk_cover.Checked = true;
                    }
                    if (code == "CA")
                    {
                        chk_attendence.Checked = true;
                    }
                    if (code == "CS")
                    {
                        chk_customer_settlement.Checked = true;
                    }
                    if (code == "LI")
                    {
                        DataTable dtli = bld.GetLoadImage();
                       string image = dtli.Rows[0]["description"].ToString();
                        var imageset = System.Drawing.Image.FromFile(image);
                         pictureBox1.Image = imageset;
                    }
                    if (code == "QR")
                    {

                    }

                }

            }
            HidePanel();
  
            // rbn_tl.Checked = true;
        }
        BLLDynamic bldd = new BLLDynamic();

        private void treeView1_AfterExpand(object sender, TreeViewEventArgs e)
        {

        }
  
            public const string MatchEmailPattern =
                      @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
               + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
               + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
               + @"([a-zA-Z0-9]+[\w-]+\.)+[a-zA-Z]{1}[a-zA-Z0-9-]{1,23})$";
   
            public static bool IsEmail(string email)
            {
                if (email != null) return Regex.IsMatch(email, MatchEmailPattern);
                else return false;
       
            }
        
        string load;
        string status;
        bool email=false;
       public static string code;
        string remarks = "Image";
        DataTable dt = new DataTable();
         public void checkBillPrint()
         {
            DataTable dt = blpst.getalldata();
            if (dt.Rows.Count>0)
            {
                int update = blpst.UpdatePrinter(cmb_bill_print.Text);
            }
            else
            {
                MessageBox.Show("Printer Is Not Set Alert !!", "Define Printer Size Alert !!");
            }
         
        }
        public void checkKotPrint()
        {
            DataTable dt = blpst.getalldata();
            if (dt.Rows.Count > 0)
            {
                int update = blpst.UpdateKotPrinter(cmb_kot_print.Text);
            }
            else
            {
                MessageBox.Show("Printer Is Not Set Alert !!", "Define Printer Size Alert !!");
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            //if (txt_rename.Text == "" || txt_renameSP.Text == "" || txt_qr.Text == "" || txt_panno.Text == "" || txt_mailsend.Text == "" || txt_kot.Text == "" || txt_itemrename.Text == "" || txt_homedelivery.Text == "" || txt_salesrename.Text == "" || txt_tablebilling.Text == "" || txt_token_rename.Text == "")
            //{
            //    MessageBox.Show("There Is Nothing To Change !!", "Nothing To Change Alert !!");
            //}
             if (panel_email.Visible == true)
            {
                dt = bld.GetDynamic(lbl_mailto.Text);
                try
                {
                    var eMailValidator = new System.Net.Mail.MailAddress(txt_mailsend.Text);
                    MessageBox.Show("Software Successfully Updated !!", "Successfully Updated Alert !!");
                }
                catch (FormatException ex)
                {
                    MessageBox.Show("Wrong Email Address Pattern !!", "Wrong Email Alert !! ");
                    txt_mailsend.Text = "";
                }
                // IsEmail(txt_mailsend.Text);

                if (dt.Rows.Count == 0)
                {
                    int insert = bldd.InsertDynamic("Mail To", "Email Name", txt_mailsend.Text, lbl_mailto.Text);
                }
                else
                {
                    int update = bldd.UpdateDynamic(txt_mailsend.Text, lbl_mailto.Text);
                }
            }
            else
            {
                if (panelTA.Visible == true)
                {
                    dt = bld.GetDynamic(lbl_code.Text);
                    if (dt.Rows.Count == 0)
                    {
                        int insert = bldd.InsertDynamic("Take Away Rename", "Rename", txt_rename.Text, lbl_code.Text);
                    }
                    else
                    {
                        int update = bldd.UpdateDynamic(txt_rename.Text, lbl_code.Text);
                    }
                    //  code = lbl_code.Text;
                }
                else if (PanelLoad.Visible == true)
                {
                    if (rbn_tl.Checked == true)
                    {
                        load = "Table Load";
                    }
                    else if (rbn_ta.Checked == true)
                    {
                        load = "TakeAway Load";
                    }
                    else if (rbn_kfc.Checked == true)
                    {
                        load = "KFC Load";
                    }
                    dt = bld.GetDynamic(lbl_firstload.Text);
                    if (dt.Rows.Count == 0)
                    {
                        int insert = bldd.InsertDynamic("First Load", "load", load, lbl_firstload.Text);
                    }
                    else
                    {
                        int update = bldd.UpdateDynamic(load, lbl_firstload.Text);
                    }
                    code = lbl_firstload.Text;

                }
                else if (panel_business.Visible == true)
                {
                    if (rbn_restaurant.Checked == true)
                    {
                        load = "Restaurant";
                    }
                    else if (rbn_parlour.Checked == true)
                    {
                        load = "Parlour";
                    }
                    else if (rbn_bakery.Checked == true)
                    {
                        load = "Bakery";
                    }
                    dt = bld.GetDynamic(lbl_business.Text);
                    if (dt.Rows.Count == 0)
                    {
                        int insert = bldd.InsertDynamic("Business Type",load, "load", lbl_business.Text);
                    }
                    else
                    {
                        int update = bldd.UpdateDynamic(load, lbl_business.Text);
                    }
                    code = lbl_business.Text;

                }
                else if (panelQA.Visible == true)
                {
                    if (chk_qa.Checked == true)
                    {
                        dt = bld.GetDynamic(lbl_qa.Text);
                        if (dt.Rows.Count == 0)
                        {
                            int insert = bldd.InsertDynamic("Quotation Access", "Access", "Enable", lbl_qa.Text);
                        }
                        else
                        {
                            int update = bldd.UpdateDynamic("Enable", lbl_qa.Text);
                        }
                    }
                    else
                    {
                        int update = bldd.UpdateDynamicFalse(lbl_qa.Text);
                    }
                }
                else if (panel_fix_grouping.Visible == true)
                {
                    if (chk_fix_grouping.Checked == true)
                    {
                        dt = bld.GetDynamic(lbl_fix_grouping.Text);
                        if (dt.Rows.Count == 0)
                        {
                            int insert = bldd.InsertDynamic("Fix Grouping Access", "Access", "Enable", lbl_fix_grouping.Text);
                        }
                        else
                        {
                            int update = bldd.UpdateDynamic("Enable", lbl_fix_grouping.Text);
                        }
                    }
                    else
                    {
                        int update = bldd.UpdateDynamicFalse(lbl_fix_grouping.Text);
                    }
                    if (chk_hide_grouping.Checked == true)
                    {
                        dt = bld.GetDynamic(lbl_hide_grouping.Text);
                        if (dt.Rows.Count == 0)
                        {
                            int insert = bldd.InsertDynamic("Hide 'G' Access", "Access", "Enable", lbl_hide_grouping.Text);
                        }
                        else
                        {
                            int update = bldd.UpdateDynamic("Enable", lbl_hide_grouping.Text);
                        }
                    }
                    else
                    {
                        int update = bldd.UpdateDynamicFalse(lbl_hide_grouping.Text);
                    }
                }
                else if (panel_checkdetail.Visible == true)
                {
                    if (chk_chequedetail.Checked == true)
                    {
                        dt = bld.GetDynamic(lbl_checkdetail.Text);
                        if (dt.Rows.Count == 0)
                        {
                            int insert = bldd.InsertDynamic("Cheque Detail Access", "Access", "Enable", lbl_checkdetail.Text);
                        }
                        else
                        {
                            int update = bldd.UpdateDynamic("Enable", lbl_checkdetail.Text);
                        }
                    }
                    else
                    {
                        int update = bldd.UpdateDynamicFalse(lbl_checkdetail.Text);
                    }
                }
                else if (panel_attendence.Visible == true)
                {
                    if (chk_attendence.Checked == true)
                    {
                        dt = bld.GetDynamic(lbl_attendence.Text);
                        if (dt.Rows.Count == 0)
                        {
                            int insert = bldd.InsertDynamic("Customer Attendence Access", "Access", "Enable", lbl_attendence.Text);
                        }
                        else
                        {
                            int update = bldd.UpdateDynamic("Enable", lbl_attendence.Text);
                        }
                    }
                    else
                    {
                        int update = bldd.UpdateDynamicFalse(lbl_attendence.Text);
                    }
                }
                else if (panel_grandtotal.Visible == true)
                {
                    if (chk_grandtotal.Checked == true)
                    {
                        dt = bld.GetDynamic(lbl_grandtotal.Text);
                        if (dt.Rows.Count == 0)
                        {
                            int insert = bldd.InsertDynamic("Grand Total In Word Access", "Access", "Enable", lbl_grandtotal.Text);
                        }
                        else
                        {
                            int update = bldd.UpdateDynamic("Enable", lbl_grandtotal.Text);
                        }
                    }
                    else
                    {
                        int update = bldd.UpdateDynamicFalse(lbl_grandtotal.Text);
                    }
                }
                else if (panel_footerbilling.Visible == true)
                {
                    if (chk_billfooter.Checked == true)
                    {
                        dt = bld.GetDynamic(lbl_billfooter.Text);
                        if (dt.Rows.Count == 0)
                        {
                            int insert = bldd.InsertDynamic("Footer in Billing Access", "Access", "Enable", lbl_billfooter.Text);
                        }
                        else
                        {
                            int update = bldd.UpdateDynamic("Enable", lbl_billfooter.Text);
                        }
                    }
                    else
                    {
                        int update = bldd.UpdateDynamicFalse(lbl_billfooter.Text);
                    }
                }

                else if (panel_pay.Visible == true)
                {
                    if (chk_pay.Checked == true)
                    {
                        dt = bld.GetDynamic(lbl_pay.Text);
                        if (dt.Rows.Count == 0)
                        {
                            int insert = bldd.InsertDynamic("Purchase Decrease Access", "Access", "Enable", lbl_pay.Text);
                        }
                        else
                        {
                            int update = bldd.UpdateDynamic("Enable", lbl_pay.Text);
                        }
                    }
                    else
                    {
                        int update = bldd.UpdateDynamicFalse(lbl_pay.Text);
                    }
                }
                else if (panel_account.Visible == true)
                {
                    if (chk_account.Checked == true)
                    {
                        dt = bld.GetDynamic(lbl_account.Text);
                        if (dt.Rows.Count == 0)
                        {
                            int insert = bldd.InsertDynamic("Account Access", "Access", "Enable", lbl_account.Text);
                        }
                        else
                        {
                            int update = bldd.UpdateDynamic("Enable", lbl_account.Text);
                        }
                    }
                    else
                    {
                        int update = bldd.UpdateDynamicFalse(lbl_account.Text);
                    }
                }
                else if (panelQR.Visible == true)
                {
                    dt = bld.GetDynamic(lbl_qr.Text);
                    if (dt.Rows.Count == 0)
                    {
                        int insert = bldd.InsertDynamic("Quotation Rename", "Rename", txt_qr.Text, lbl_qr.Text);
                    }
                    else
                    {
                        int update = bldd.UpdateDynamic(txt_qr.Text, lbl_qr.Text);
                    }
                }
                else if (panel_checkout_rename.Visible == true)
                {
                    dt = bld.GetDynamic(lbl_checkout_rename.Text);
                    if (dt.Rows.Count == 0)
                    {
                        int insert = bldd.InsertDynamic("Checkout Rename", txt_checkout_rename.Text,"Rename",lbl_checkout_rename.Text);
                    }
                    else
                    {
                        int update = bldd.UpdateDynamic(txt_checkout_rename.Text, lbl_checkout_rename.Text);
                    }
                }
                else if (panelSPA.Visible == true)
                {
                    if (chk_sp.Checked == true)
                    {
                        dt = bld.GetDynamic(lbl_spa.Text);
                        if (dt.Rows.Count == 0)
                        {
                            int insert = bldd.InsertDynamic("Service Provide Access", "Access", "Enable", lbl_spa.Text);
                        }
                        else
                        {
                            int update = bldd.UpdateDynamic("Enable", lbl_spa.Text);
                        }
                    }
                    else
                    {
                        int update = bldd.UpdateDynamicFalse(lbl_spa.Text);
                    }
                }
                else if (panel_mail.Visible == true)
                {
                    if (chk_mail.Checked == true)
                    {
                        dt = bld.GetDynamic(lbl_mail.Text);
                        if (dt.Rows.Count == 0)
                        {
                            int insert = bldd.InsertDynamic("Mail Access", "Access", "Enable", lbl_mail.Text);
                        }
                        else
                        {
                            int update = bldd.UpdateDynamic("Enable", lbl_mail.Text);
                        }
                    }
                    else
                    {
                        int update = bldd.UpdateDynamicFalse(lbl_mail.Text);
                    }
                }

                else if (panelSPR.Visible == true)
                {
                    dt = bld.GetDynamic(lbl_renameSP.Text);
                    if (dt.Rows.Count == 0)
                    {
                        int insert = bldd.InsertDynamic("Service Provider Rename", "Rename", txt_renameSP.Text, lbl_renameSP.Text);
                    }
                    else
                    {
                        int update = bldd.UpdateDynamic(txt_renameSP.Text, lbl_renameSP.Text);
                    }
                }
                else if (panel_ird.Visible==true)
                {
                    if (dt1.Rows.Count>0)
                    {
                        btn_update.Visible = true;
                        btn_save.Visible = false;
                    }
                    else
                    {
                        btn_save.Visible = true;
                        btn_update.Visible = false;
                    }
                }
                else if (panelAA.Visible == true)
                {
                    if (chk_discount.Checked == true)
                    {
                        dt = bld.GetDynamic(lbl_discount.Text);
                        if (dt.Rows.Count == 0)
                        {
                            int insert = bldd.InsertDynamic("Discount Access", "Access", "Enable", lbl_discount.Text);
                        }
                        else
                        {
                            int update = bldd.UpdateDynamic("Enable", lbl_discount.Text);
                        }
                    }
                    else
                    {
                        int update = bldd.UpdateDynamicFalse(lbl_discount.Text);
                    }
                    if (chk_complementry.Checked == true)
                    {
                        dt = bld.GetDynamic(lbl_complementry.Text);
                        if (dt.Rows.Count == 0)
                        {
                            int insert = bldd.InsertDynamic("Complementry Access", "Access", "Enable", lbl_complementry.Text);
                        }
                        else
                        {
                            int update = bldd.UpdateDynamic("Enable", lbl_complementry.Text);
                        }
                    }
                    else
                    {
                        int update = bldd.UpdateDynamicFalse(lbl_complementry.Text);
                    }
                    if (chk_delete.Checked == true)
                    {
                        dt = bld.GetDynamic(lbl_delete.Text);
                        if (dt.Rows.Count == 0)
                        {
                            int insert = bldd.InsertDynamic("Delete Access", "Access", "Enable", lbl_delete.Text);
                        }
                        else
                        {
                            int update = bldd.UpdateDynamic("Enable", lbl_delete.Text);
                        }
                    }
                    else
                    {
                        int update = bldd.UpdateDynamicFalse(lbl_delete.Text);
                    }
                    if (chk_cancel.Checked == true)
                    {
                        dt = bld.GetDynamic(lbl_cancel.Text);
                        if (dt.Rows.Count == 0)
                        {
                            int insert = bldd.InsertDynamic("Cancel Access", "Access", "Enable", lbl_cancel.Text);
                        }
                        else
                        {
                            int update = bldd.UpdateDynamic("Enable", lbl_cancel.Text);
                        }
                    }
                    else
                    {
                        int update = bldd.UpdateDynamicFalse(lbl_cancel.Text);
                    }
                }
                else if (panel_printer.Visible == true)
                {
                    dt = bld.GetDynamic(lbl_printer.Text);
                    if (dt.Rows.Count == 0)
                    {
                        int insert = bldd.InsertDynamic("Quotation Printer Name", "Printer", cmb_printer.Text, lbl_printer.Text);
                    }
                    else
                    {
                        int update = bldd.UpdateDynamic(cmb_printer.Text, lbl_printer.Text);
                    }
                }
                else if (panel_dayend_printer.Visible == true)
                {
                    dt = bld.GetDynamic(lbl_dayend_printer.Text);
                    if (dt.Rows.Count == 0)
                    {
                        int insert = bldd.InsertDynamic("DayEnd Printer Name", "Printer", cmb_dayend_printer.Text, lbl_dayend_printer.Text);
                    }
                    else
                    {
                        int update = bldd.UpdateDynamic(cmb_dayend_printer.Text, lbl_dayend_printer.Text);
                    }
                }
                else if (panel_billing_print.Visible == true)
                {
                    dt = bld.GetDynamic(lbl_bill_print.Text);
                    if (dt.Rows.Count == 0)
                    {
                        int insert = bldd.InsertDynamic("Billing Print Size", "Printer", cmb_bill_print.Text, lbl_bill_print.Text);
                        checkBillPrint();
                    }
                    else
                    {
                        int update = bldd.UpdateDynamic(cmb_bill_print.Text, lbl_bill_print.Text);
                        checkBillPrint();
                    }
                }
                else if (panel_kot_print.Visible == true)
                {
                    dt = bld.GetDynamic(lbl_kot_print.Text);
                    if (dt.Rows.Count == 0)
                    {
                        int insert = bldd.InsertDynamic("Kot Print Size", "Printer", cmb_kot_print.Text, lbl_kot_print.Text);
                        checkKotPrint();
                    }
                    else
                    {
                        int update = bldd.UpdateDynamic(cmb_kot_print.Text, lbl_kot_print.Text);
                        checkKotPrint();
                    }

                }
                else if (panel_bill_print.Visible == true)
                {
                    if (chk_header.Checked == true)
                    {
                        dt = bld.GetDynamic(lbl_header.Text);
                        if (dt.Rows.Count == 0)
                        {
                            int insert = bldd.InsertDynamic("Header Quotation Access", "Access", "Enable", lbl_header.Text);
                        }
                        else
                        {
                            int update = bldd.UpdateDynamic("Enable", lbl_header.Text);
                        }
                    }
                    else
                    {
                        int update = bldd.UpdateDynamicFalse(lbl_header.Text);
                    }
                    if (chk_footer.Checked == true)
                    {
                        dt = bld.GetDynamic(lbl_footer.Text);
                        if (dt.Rows.Count == 0)
                        {
                            int insert = bldd.InsertDynamic("Footer Quotation Access", "Access", "Enable", lbl_footer.Text);
                        }
                        else
                        {
                            int update = bldd.UpdateDynamic("Enable", lbl_footer.Text);
                        }
                    }
                    else
                    {
                        int update = bldd.UpdateDynamicFalse(lbl_footer.Text);
                    }
                }
                else if (panelimage.Visible == true)
                {
                    dt = bld.GetDynamic(lbl_complementry.Text);
                    if (dt.Rows.Count == 0)
                    {
                        int insert = bldd.InsertDynamic("Load Image", imagepath, "Image", lbl_image.Text);
                    }
                    else
                    {
                        int update = bldd.UpdateDynamic(imagepath, lbl_image.Text);
                    }
                }
                else if (panelServiceCharge.Visible == true)
                {
                    if (chk_takeaway.Checked == true)
                    {
                        dt = bld.GetDynamic(lbl_takeaway.Text);
                        if (dt.Rows.Count == 0)
                        {
                            int insert = bldd.InsertDynamic("TakeAway Service Charge", "Change", "Enable", lbl_takeaway.Text);
                        }
                        else
                        {
                            int update = bldd.UpdateDynamic("Enable", lbl_takeaway.Text);
                        }
                    }
                    else
                    {
                        int update = bldd.UpdateDynamicFalse(lbl_takeaway.Text);
                    }
                    if (chk_table.Checked == true)
                    {
                        dt = bld.GetDynamic(lbl_table.Text);
                        if (dt.Rows.Count == 0)
                        {
                            int insert = bldd.InsertDynamic("Table Service Charge", "Change", "Enable", lbl_table.Text);
                        }
                        else
                        {
                            int update = bldd.UpdateDynamic("Enable", lbl_table.Text);
                        }
                    }
                    else
                    {
                        int update = bldd.UpdateDynamicFalse(lbl_table.Text);
                    }
                    if (chk_token.Checked == true)
                    {
                        dt = bld.GetDynamic(lbl_token.Text);
                        if (dt.Rows.Count == 0)
                        {
                            int insert = bldd.InsertDynamic("Token Service Charge", "Change", "Enable", lbl_token.Text);
                        }
                        else
                        {
                            int update = bldd.UpdateDynamic("Enable", lbl_token.Text);
                        }
                    }
                    else
                    {
                        int update = bldd.UpdateDynamicFalse(lbl_token.Text);
                    }
                    if (chk_roomsc.Checked == true)
                    {
                        dt = bld.GetDynamic(lbl_roomsc.Text);
                        if (dt.Rows.Count == 0)
                        {
                            int insert = bldd.InsertDynamic("Room Service Charge", "Change", "Enable", lbl_roomsc.Text);
                        }
                        else
                        {
                            int update = bldd.UpdateDynamic("Enable", lbl_roomsc.Text);
                        }
                    }
                    else
                    {
                        int update = bldd.UpdateDynamicFalse(lbl_roomsc.Text);
                    }
                }
                else if (panelTB.Visible == true)
                {
                    if (chk_tb.Checked == true)
                    {
                        dt = bld.GetDynamic(lbl_tb.Text);
                        if (dt.Rows.Count == 0)
                        {
                            int insert = bldd.InsertDynamic("Token Billing", "Access", "Enable", lbl_tb.Text);
                        }
                        else
                        {
                            int update = bldd.UpdateDynamic("Enable", lbl_tb.Text);
                        }
                    }
                    else
                    {
                        int update = bldd.UpdateDynamicFalse(lbl_tb.Text);
                    }
                }
                else if (panel_hotel.Visible == true)
                {
                    if (chk_hotel.Checked == true)
                    {
                        dt = bld.GetDynamic(lbl_hotel.Text);
                        if (dt.Rows.Count == 0)
                        {
                            int insert = bldd.InsertDynamic("Hotel Enable", "Access", "Enable", lbl_hotel.Text);
                        }
                        else
                        {
                            int update = bldd.UpdateDynamic("Enable", lbl_hotel.Text);
                        }
                    }
                    else
                    {
                        int update = bldd.UpdateDynamicFalse(lbl_hotel.Text);
                    }
                }
                else if (panel_coverup.Visible == true)
                {
                    if (chk_cover.Checked == true)
                    {
                        dt = bld.GetDynamic(lbl_cover.Text);
                        if (dt.Rows.Count == 0)
                        {
                            int insert = bldd.InsertDynamic("Cover Up Enable", "Access", "Enable", lbl_cover.Text);
                        }
                        else
                        {
                            int update = bldd.UpdateDynamic("Enable", lbl_cover.Text);
                        }
                    }
                    else
                    {
                        int update = bldd.UpdateDynamicFalse(lbl_cover.Text);
                    }
                }
                else if (panel_discoutnt_estimate.Visible == true)
                {
                    if (chk_estimate.Checked == true)
                    {
                        dt = bld.GetDynamic(lbl_estimatecost.Text);
                        if (dt.Rows.Count == 0)
                        {
                            int insert = bldd.InsertDynamic("Discount Enable", "Access", "Enable", lbl_estimatecost.Text);
                        }
                        else
                        {
                            int update = bldd.UpdateDynamic("Enable", lbl_estimatecost.Text);
                        }
                    }
                    else
                    {
                        int update = bldd.UpdateDynamicFalse(lbl_estimatecost.Text);
                    }
                    if (chk_compare_discount.Checked == true)
                    {
                        dt = bld.GetDynamic(lbl_discount_estimate.Text);
                        if (dt.Rows.Count == 0)
                        {
                            int insert = bldd.InsertDynamic("Discount Enable", "Access", "Enable", lbl_discount_estimate.Text);
                        }
                        else
                        {
                            int update = bldd.UpdateDynamic("Enable", lbl_discount_estimate.Text);
                        }
                    }
                    else
                    {
                        int update = bldd.UpdateDynamicFalse(lbl_discount_estimate.Text);
                    }
                }
                else if (panel_kot.Visible == true)
                {
                    if (chk_kot.Checked == true)
                    {
                        dt = bld.GetDynamic(lbl_enabledisable.Text);
                        if (dt.Rows.Count == 0)
                        {
                            int insert = bldd.InsertDynamic("Kot Enable/Disable", "Enable", "Access", lbl_enabledisable.Text);
                        }
                        else
                        {
                            int update = bldd.UpdateDynamic("Enable", lbl_enabledisable.Text);
                        }
                    }
                    else
                    {
                        int update = bldd.UpdateDynamicFalse(lbl_enabledisable.Text);
                    }
                    if (chk_kotsave.Checked == true)
                    {
                        dt = bld.GetDynamic(lbl_kotsave.Text);
                        if (dt.Rows.Count == 0)
                        {
                            int insert = bldd.InsertDynamic("Kot Save Enable/Disable", "Enable", "Access", lbl_kotsave.Text);
                        }
                        else
                        {
                            int update = bldd.UpdateDynamic("Enable", lbl_kotsave.Text);
                        }
                    }
                    else
                    {
                        int update = bldd.UpdateDynamicFalse(lbl_kotsave.Text);
                    }
                }
                else if (panel_hd.Visible == true)
                {
                    if (rbn_customerfirst.Checked == true)
                    {
                        load = "Customer First";
                    }
                    else if (rbn_deliveryfirst.Checked == true)
                    {
                        load = "KOTOrder First";
                    }

                    dt = bld.GetDynamic(lbl_homedelivery.Text);
                    if (dt.Rows.Count == 0)
                    {
                        int insert = bldd.InsertDynamic("HomeDelivery Load", load, "load",  lbl_homedelivery.Text);
                    }
                    else
                    {
                        int update = bldd.UpdateDynamic(load, lbl_homedelivery.Text);
                    }
                    code = lbl_homedelivery.Text;

                }
                else if (panel_table_pattern.Visible == true)
                {
                    if (rbn_table_customer.Checked == true)
                    {
                        load = "Customer First";
                    }
                    else if (rbn_tablefirst.Checked == true)
                    {
                        load = "KOTOrder First";
                    }

                    dt = bld.GetDynamic(lbl_table_pattern.Text);
                    if (dt.Rows.Count == 0)
                    {
                        int insert = bldd.InsertDynamic("Table Order Load", load, "load", lbl_table_pattern.Text);
                    }
                    else
                    {
                        int update = bldd.UpdateDynamic(load, lbl_table_pattern.Text);
                    }
                    code = lbl_table_pattern.Text;

                }
                else if (panel_token_pattern.Visible == true)
                {
                    if (rbn_customer_first.Checked == true)
                    {
                        load = "Customer First";
                    }
                    else if (rbn_kotfirst.Checked == true)
                    {
                        load = "KOTOrder First";
                    }

                    dt = bld.GetDynamic(lbl_token_pattern.Text);
                    if (dt.Rows.Count == 0)
                    {
                        int insert = bldd.InsertDynamic("Token Load", load, "load", lbl_token_pattern.Text);
                    }
                    else
                    {
                        int update = bldd.UpdateDynamic(load, lbl_token_pattern.Text);
                    }
                    code = lbl_token_pattern.Text;

                }
                else if (panel_ta_pattern.Visible == true)
                {
                    if (rbn_tacustomer.Checked == true)
                    {
                        load = "Customer First";
                    }
                    else if (rbn_tafirst.Checked == true)
                    {
                        load = "KOTOrder First";
                    }

                    dt = bld.GetDynamic(lbl_ta_pattern.Text);
                    if (dt.Rows.Count == 0)
                    {
                        int insert = bldd.InsertDynamic("TakeAway Load", load, "load", lbl_ta_pattern.Text);
                    }
                    else
                    {
                        int update = bldd.UpdateDynamic(load, lbl_ta_pattern.Text);
                    }
                    code = lbl_ta_pattern.Text;

                }
                else if (panel_grouping.Visible == true)
                {
                    if (chk_grouping.Checked == true)
                    {
                        dt = bld.GetDynamic(lbl_grouping.Text);
                        if (dt.Rows.Count == 0)
                        {
                            int insert = bldd.InsertDynamic("Category Grouping Access", "Access", "Enable", lbl_grouping.Text);
                        }
                        else
                        {
                            int update = bldd.UpdateDynamic("Enable", lbl_grouping.Text);
                        }
                    }
                    else
                    {
                        int update = bldd.UpdateDynamicFalse(lbl_grouping.Text);
                    }
                }
                else if (panel_customer_settlement.Visible == true)
                {
                    if (chk_customer_settlement.Checked == true)
                    {
                        dt = bld.GetDynamic(lbl_customer_settlement.Text);
                        if (dt.Rows.Count == 0)
                        {
                            int insert = bldd.InsertDynamic("Customer Settlement", "Access", "Enable", lbl_customer_settlement.Text);
                        }
                        else
                        {
                            int update = bldd.UpdateDynamic("Enable", lbl_customer_settlement.Text);
                        }
                    }
                    else
                    {
                        int update = bldd.UpdateDynamicFalse(lbl_customer_settlement.Text);
                    }
                }
                else if (panel_topsales.Visible == true)
                {
                    if (chk_topsales.Checked == true)
                    {
                        dt = bld.GetDynamic(lbl_topsales.Text);
                        if (dt.Rows.Count == 0)
                        {
                            int insert = bldd.InsertDynamic("Item Sales Order", "Access", "Enable", lbl_topsales.Text);
                        }
                        else
                        {
                            int update = bldd.UpdateDynamic("Enable", lbl_topsales.Text);
                        }
                    }
                    else
                    {
                        int update = bldd.UpdateDynamicFalse(lbl_topsales.Text);
                    }
                }
                else if (panelTokenrename.Visible == true)
                {
                    dt = bld.GetDynamic(lbl_token_rename.Text);
                    if (dt.Rows.Count == 0)
                    {
                        int insert = bldd.InsertDynamic("Token Rename", "Change", txt_token_rename.Text, lbl_token_rename.Text);
                    }
                    else
                    {
                        int update = bldd.UpdateDynamic(txt_token_rename.Text, lbl_token_rename.Text);
                    }
                }
                else if (panelkot.Visible == true)
                {
                    dt = bld.GetDynamic(lbl_kot.Text);
                    if (dt.Rows.Count == 0)
                    {
                        int insert = bldd.InsertDynamic("KOT Rename", "Change", txt_kot.Text, lbl_kot.Text);
                    }
                    else
                    {
                        int update = bldd.UpdateDynamic(txt_kot.Text, lbl_kot.Text);
                    }
                }
                else if (panel_homedelivery.Visible == true)
                {
                    dt = bld.GetDynamic(lbl_hd.Text);
                    if (dt.Rows.Count == 0)
                    {
                        int insert = bldd.InsertDynamic("Home Delivery Rename", "Rename", txt_homedelivery.Text, lbl_hd.Text);
                    }
                    else
                    {
                        int update = bldd.UpdateDynamic(txt_homedelivery.Text, lbl_hd.Text);
                    }
                }
                else if (panelitemrename.Visible == true)
                {
                    dt = bld.GetDynamic(lbl_item.Text);
                    if (dt.Rows.Count == 0)
                    {
                        int insert = bldd.InsertDynamic("Menu Item Rename", "Rename", txt_itemrename.Text, lbl_item.Text);
                    }
                    else
                    {
                        int update = bldd.UpdateDynamic(txt_itemrename.Text, lbl_item.Text);
                    }
                }
                else if (panelsalesrename.Visible == true)
                {
                    dt = bld.GetDynamic(lbl_sales.Text);
                    if (dt.Rows.Count == 0)
                    {
                        int insert = bldd.InsertDynamic("View Sales Rename", "Rename", txt_salesrename.Text, lbl_sales.Text);
                    }
                    else
                    {
                        int update = bldd.UpdateDynamic(txt_salesrename.Text, lbl_sales.Text);
                    }
                }
                else if (panel_tbr.Visible == true)
                {
                    dt = bld.GetDynamic(lbl_tablebilling.Text);
                    if (dt.Rows.Count == 0)
                    {
                        int insert = bldd.InsertDynamic("Table Billing Rename", "Rename", txt_tablebilling.Text, lbl_tablebilling.Text);
                    }
                    else
                    {
                        int update = bldd.UpdateDynamic(txt_tablebilling.Text, lbl_tablebilling.Text);
                    }
                }
                else if (panel_comp.Visible == true)
                {
                    if (chk_comp.Checked == true)
                    {
                        dt = bld.GetDynamic(lbl_comp_access.Text);
                        if (dt.Rows.Count == 0)
                        {
                            int insert = bldd.InsertDynamic("Complementry Access", "Access", "Enable", lbl_comp_access.Text);
                        }
                        else
                        {
                            int update = bldd.UpdateDynamic("Enable", lbl_comp_access.Text);
                        }
                    }
                    else
                    {
                        int update = bldd.UpdateDynamicFalse(lbl_comp_access.Text);
                    }
                    if (chk_comp_print.Checked == true)
                    {
                        dt = bld.GetDynamic(lbl_comp_print.Text);
                        if (dt.Rows.Count == 0)
                        {
                            int insert = bldd.InsertDynamic("Complementry Print", "Access", "Enable", lbl_comp_print.Text);
                        }
                        else
                        {
                            int update = bldd.UpdateDynamic("Enable", lbl_comp_print.Text);
                        }
                    }
                    else
                    {
                        int update = bldd.UpdateDynamicFalse(lbl_comp_print.Text);
                    }
                }
                else if (panelHomeImage.Visible == true)
                {
                    if (lbl_menu.Text == "")
                    {
                        MessageBox.Show("Choose where to change Image !!", "Change Image Alert !!");
                    }
                    else
                    {
                        code = lbl_menu.Text;
                        dt = bld.GetDynamic(code);
                      
                        if (dt.Rows.Count == 0)
                        {
                            int insert = bldd.InsertDynamic(controller, remarks, imagepath, code);
                        }
                        else
                        {
                            int update = bldd.UpdateDynamic(imagepath, code);
                        }
                    }
                }
                else if (panelPanno.Visible == true)
                {
                    dt = bld.GetDynamic(lbl_panno.Text);
                    if (dt.Rows.Count == 0)
                    {
                        int insert = bldd.InsertDynamic("PanNo Rename", "Rename", txt_panno.Text, lbl_panno.Text);
                    }
                    else
                    {
                        int update = bldd.UpdateDynamic(txt_panno.Text, lbl_panno.Text);
                    }
                }
                else if (pnl_taxfrom.Visible == true)
                {
                    if (chk_brief_tax.Checked)
                    {
                        dt = bld.GetDynamic("BTU");
                        if (dt.Rows.Count == 0)
                        {
                            int insert = bldd.InsertDynamic("Abbreviated Tax ", txt_min_tax_amount.Text, "Enable", "ATU");
                        }
                        else
                        {
                            int update = bldd.UpdateDynamic(txt_min_tax_amount.Text, "ATU");
                        }
                    }
                    else
                    {
                        int update = bldd.UpdateDynamicFalse("ATU");
                    }
                }
                MessageBox.Show("Software Successfully Updated !!", "Successfully Updated Alert !!");
                DialogResult dig = MessageBox.Show("Need To Make Some Other Changes ?", "Change Alert !!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dig == DialogResult.No)
                {
                    this.Close();
                }

                //Login lg = new Login();
                //lg.Show();
            }
        }
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
             TreeNode node = treeView1.SelectedNode;
            switch (node.Text)
            {
                case "Rename Take Away":
                    HidePanel();
                    panelTA.Show();
                    break;
                case "Admin Access":
                    HidePanel();
                    panelAA.Show();
                     break;
                case "KOT Dynamic":
                    HidePanel();
                    panelkot.Show();
                      break;
                case "Login Image":
                    HidePanel();
                    panelimage.Show();
                    break;
                case "Service Charge Access":
                    HidePanel();
                    panelServiceCharge.Show();
                  
                    break;
                case "Token Billing":
                    HidePanel();
                    panelTB.Show();
                    
                    break;
                case "Token Billing Rename":
                    HidePanel();
                    panelTokenrename.Show();
                     break;
                case "First Load":
                    HidePanel();
                    PanelLoad.Show();
                    break;

                case "Service Provider Access":
                    HidePanel();
                    panelSPA.Show();
                break;

                case "Service Provider Name":
                    HidePanel();
                    panelSPR.Show();
                     break;
                case "Quotation Access":
                    HidePanel();
                    panelQA.Show();
                    break;
                case "Quotation Rename":
                    HidePanel();
                    panelQR.Show();
                  break;
                case "Checkout Rename":
                    HidePanel();
                    panel_checkout_rename.Show();
                    break;
                case "Pan No. or Vat No.":
                    HidePanel();
                    panelPanno.Show();
                     break;
                case "All Menu Image":
                    HidePanel();
                    panelHomeImage.Show();
                    break;
                case "Add Menu Item Rename":
                    HidePanel();
                    panelitemrename.Show();
                    break;
                case "View Sales Report Rename":
                    HidePanel();
                    panelsalesrename.Show();
                    break;
                case "Complementry":
                    HidePanel();
                    panel_comp.Show();
                     break;
                case "Home Delivery Rename":
                    HidePanel();
                    panel_homedelivery.Show();
                    break;
                case "Table Billing Rename":
                    HidePanel();
                    panel_tbr.Show();
                    break;
                case "Dayend Mail Access":
                    HidePanel();
                    panel_mail.Show();
                    break;
                case "Dayend Mail To":
                    HidePanel();
                    panel_email.Show();
                    break;
                case "Quotation Requirement":
                    HidePanel();
                    panel_bill_print.Show();
                    break;
                case "Quotation Printer Name":
                    HidePanel();
                    panel_printer.Show();
                    break;
                case "Category Grouping":
                    HidePanel();
                    panel_grouping.Show();
                    break;
                case "Item Sales Order":
                    HidePanel();
                    panel_topsales.Show();
                    break;
                case "Billing Printer Size":
                    HidePanel();
                    panel_billing_print.Show();
                    break;
                case "KOT Printer Size":
                    HidePanel();
                    panel_kot_print.Show();
                    break;
                case "Hotel Access":
                    HidePanel();
                    panel_hotel.Show();
                    break;
                case "Home Delivery Pattern":
                    HidePanel();
                    panel_hd.Show();
                    break;
                case "Table Order Pattern":
                    HidePanel();
                    panel_table_pattern.Show();
                    break;
                case "Take Away Pattern":
                    HidePanel();
                    panel_ta_pattern.Show();
                    break;
                case "Token Order Pattern":
                    HidePanel();
                    panel_token_pattern.Show();
                    break;
                case "DayEnd":
                    HidePanel();
                    panel_dayend_printer.Show();
                    break;
                case "Billing":
                    HidePanel();
                    panel_billing_printer.Show();
                    break;
                case "Discount & Estimate Cost":
                    HidePanel();
                    panel_discoutnt_estimate.Show();
                    break;
                case "Ird Info":
                    HidePanel();
                    panel_ird.Show();
                    break;
                case "Kot Enable/Disable":
                    HidePanel();
                    panel_kot.Show();
                    break;
                case "Business Type":
                    HidePanel();
                    panel_business.Show();
                    break;
                case "Cheque Details":
                    HidePanel();
                    panel_checkdetail.Show();
                    break;
                case "Purchase By CashDrop":
                    HidePanel();
                    panel_pay.Show();
                    break;
                case "Customer Settlement":
                    HidePanel();
                    panel_customer_settlement.Show();
                    break;
                case "Table CoverUp":
                    HidePanel();
                    panel_coverup.Show();
                    break;
                case "Grand Total":
                    HidePanel();
                    panel_grandtotal.Show();
                    break;
                case "Grouping Changes":
                    HidePanel();
                    panel_fix_grouping.Show();
                    break;
           
                case "Remove Footer":
                    HidePanel();
                    panel_footerbilling.Show();
                    break;
                case "Account Access":
                    SuperAdminAccess aa = new SuperAdminAccess();
                    aa.ShowDialog();
                    if (aa.DialogResult == DialogResult.OK)
                    {
                        HidePanel();
                        panel_account.Show();
                    }
                    break;
        
                case "Tax":
                    SuperAdminAccess saa = new SuperAdminAccess();
                    saa.ShowDialog();
                    if (saa.DialogResult == DialogResult.OK)
                    {
                        HidePanel();
                        pnl_taxfrom.Show();
                    }
                    break;
                case "Customer Attendence":
                    HidePanel();
                    panel_attendence.Show();
                    break;
                case "FonePay":
                    SuperAdminAccess su = new SuperAdminAccess();
                    su.ShowDialog();
                    if (su.DialogResult == DialogResult.OK)
                    {
                        HidePanel();
                        FonePayPanel.Show();
                    }
                    break;

            }
        }
        public void HidePanel()
        {
            panelTA.Hide();
            panelSPA.Hide();
            panelSPR.Hide();
            PanelLoad.Hide();
            panelTB.Hide();
            panelQR.Hide();
            panelQA.Hide();
            panelPanno.Hide();
            panelAA.Hide();
            panelimage.Hide();
            panelServiceCharge.Hide();
            panelkot.Hide();
            panelTokenrename.Hide();
            panelHomeImage.Hide();
            panelHomeImage.Hide();
            panelHomeImage.Hide();
            panel_comp.Hide();
            panel_homedelivery.Hide();
            panelitemrename.Hide();
            panelsalesrename.Hide();
            panel_tbr.Hide();
            panel_mail.Hide();
            panel_email.Hide();
            panel_bill_print.Hide();
            panel_printer.Hide();
            panel_topsales.Hide();
            panel_grouping.Hide();
            panel_billing_print.Hide();
            panel_kot_print.Hide();
            panel_hotel.Hide();
            panel_hd.Hide();
            panel_token_pattern.Hide();
            panel_ta_pattern.Hide();
            panel_table_pattern.Hide();
            panel_dayend_printer.Hide();
            panel_billing_printer.Hide();
            panel_discoutnt_estimate.Hide();
            pnl_taxfrom.Hide();
            panel_ird.Hide();
            panel_kot.Hide();
            panel_business.Hide();
            panel_pay.Hide();
            panel_account.Hide();
            panel_coverup.Hide();
            panel_customer_settlement.Hide();
            FonePayPanel.Hide();
            panel_checkdetail.Hide();
            panel_grandtotal.Hide();
            panel_footerbilling.Hide();
            panel_checkout_rename.Hide();
            panel_fix_grouping.Hide();
            panel_attendence.Hide();
           
        }
      public string imagepath;
        private static System.Drawing.Image ScaleImage(System.Drawing.Image image, int maxWidth, int maxHeight)
        {
            var ratioX = (double)maxWidth / image.Width;
            var ratioY = (double)maxHeight / image.Height;
            var ratio = Math.Min(ratioX, ratioY);
            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);
            var newImage = new Bitmap(newWidth, newHeight);
            Graphics.FromImage(newImage).DrawImage(image, 0, 0, newWidth, newHeight); return newImage;
        }
        string createfolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "POS" + "\\" + "POS Image";
        private void btn_browse_Click(object sender, EventArgs e)
        {
              OpenFileDialog ofd = new OpenFileDialog();
          //  ofd.InitialDirectory = createfolder;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (!Directory.Exists(createfolder))
                    {
                        Directory.CreateDirectory(createfolder);
                    }
                    string sourceFile = ofd.FileName;
                    string sourceFolder = sourceFile;
                    string filenameWithoutPath = Path.GetFileName(sourceFile);
                    FileInfo fi = new FileInfo(sourceFile);
                    string destinationfile = createfolder + "\\" + filenameWithoutPath;
             
                    if (!File.Exists(destinationfile))
                    {
                        fi.CopyTo(destinationfile);
                    }
                    imagepath = destinationfile;
                     pictureBox1.ImageLocation = imagepath;
              
                }
                catch
                {
                    MessageBox.Show("Error in Finding Path");
                }
            }
        }

        private void panelAA_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label41_Click(object sender, EventArgs e)
        {

        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panelkot_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
      public static string controller;
        string description;
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            lbl_menu.Text = "ITB";
            controller = "Table Billing Image";
           
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            lbl_menu.Text = "ITA";
            controller = "Take Away Image";
          
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            lbl_menu.Text = "IHD";
            controller = "Home Delivery Image";
           
       }

        private void button1_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (!Directory.Exists(createfolder))
                    {
                        Directory.CreateDirectory(createfolder);
                    }
                    string sourceFile = ofd.FileName;
                    string sourceFolder = sourceFile;
                    string filenameWithoutPath = Path.GetFileName(sourceFile);
                    FileInfo fi = new FileInfo(sourceFile);
                    string destinationfile = createfolder + "\\" + filenameWithoutPath;

                    if (!File.Exists(destinationfile))
                    {
                        fi.CopyTo(destinationfile);
                    }
                    imagepath = destinationfile;
                    pictureBox2.ImageLocation = imagepath;
              
                }
                catch
                {
                    MessageBox.Show("Error in Finding Path");
                }
            }
        }
        private void chk_tablebilling_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            lbl_menu.Text = "IVS";
            controller = "Sales Image";
      
        }

        private void rbn_token_CheckedChanged(object sender, EventArgs e)
        {
            lbl_menu.Text = "IT";
            controller = "Token Image";
       
        }

        private void rbn_menu_CheckedChanged(object sender, EventArgs e)
        {
            lbl_menu.Text = "IAM";
            controller = "Menu Image";
           // description = imagepath;
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void panelimage_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txt_mailsend_TextChanged(object sender, EventArgs e)
       {
            //if (txt_mailsend.Text!="")
            //{
            //    try
            //    {
            //        var eMailValidator = new System.Net.Mail.MailAddress(txt_mailsend.Text);
            //    }
            //    catch (FormatException ex)
            //    {
            //        MessageBox.Show("Wrong Email Address Pattern !!", "Wrong Email Alert !! ");
            //        txt_mailsend.Text = "";
            //    }
            //}
       
        }

        private void panel_billing_printer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel_table_pattern_Paint(object sender, PaintEventArgs e)
        {

        }

        private void treeView1_DoubleClick(object sender, EventArgs e)
        {
            TreeNode node = treeView1.SelectedNode;
            if (node.Text == "System Command")
            {
                AdminAccess ad = new AdminAccess();
                ad.ShowDialog();
                if (ad.Admin_access_value == true)
                {
                    SystemCommand sc = new SystemCommand();
                    sc.Show();
                }
            }
        }

        private void txt_min_tax_amount_TextChanged(object sender, EventArgs e)
        {

        }
        string brief_tax_check;
        private void chk_brief_tax_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_brief_tax.Checked)
            {
                brief_tax_check = "True";
                txt_min_tax_amount.Show();
                label128.Show();
            }
            else
            {
                brief_tax_check = "False";
                txt_min_tax_amount.Hide();
                label128.Hide();
            }
        }
        public int id;
        private void txt_min_tax_amount_KeyPress(object sender, KeyPressEventArgs e)
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
        BLL_Login_logout bll = new BLL_Login_logout();
        private void btn_save_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(lbl_id.Text) > 0 && txtusername.Text != "" && txtpassword.Text != "")
            {
                string epasswd = StringEncryption.Encrypt(txtpassword.Text, "sblw-3hn8-sqoy19");
                int insert = bll.InsertIrdInfo(txtusername.Text, txtpassword.Text, txtipaddress.Text);
                if (insert > 0)
                {
                    MessageBox.Show("Inserted Successfully !!", "Success Alert !!");
                }
                txtusername.Text = "";
                txtpassword.Text = "";
                txtipaddress.Text = "";
                Dynamic_Load(this, null);
            }
            else
            {
                MessageBox.Show("Update Successfully !!", "Success Alert !!");
            }
        }
      
        private void btn_update_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(lbl_id.Text) > 0 && txtusername.Text != "" && txtpassword.Text != "")
            {
                string epasswd = StringEncryption.Encrypt(txtpassword.Text, "sblw-3hn8-sqoy19");
                int insert = bll.UpdateIrdInfo(Convert.ToInt32(lbl_id.Text), txtusername.Text, epasswd, txtipaddress.Text);
                if (insert > 0)
                {
                    MessageBox.Show("Update Successfully !!", "Success Alert !!");

                }
                txtusername.Text = "";
                txtpassword.Text = "";
                txtipaddress.Text = "";
                Dynamic_Load(this, null);
                id = 0;
            }
            else
            {
                MessageBox.Show("Update Successfully !!", "Success Alert !!");
            }
        }

        private void panel_account_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_qrBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
            //  ofd.InitialDirectory = createfolder;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
              
                    if (!Directory.Exists(createfolder))
                    {
                        Directory.CreateDirectory(createfolder);
                    }
                    string sourceFile = ofd.FileName;
                    string sourceFolder = sourceFile;
                    string filenameWithoutPath = Path.GetFileName(sourceFile);
                    FileInfo fi = new FileInfo(sourceFile);
                    string destinationfile = createfolder + "\\" + filenameWithoutPath;

                    if (!File.Exists(destinationfile))
                    {
                        fi.CopyTo(destinationfile);
                    }
                    imagepath = destinationfile;
                    pbox_fonePay.ImageLocation = imagepath;

               
            }
            }
            catch
            {
                MessageBox.Show("Error in Finding Path");
            }
        }
        private void btn_set_Click(object sender, EventArgs e)
        {
            DataTable dtm = bld.GetDynamic("FP");
            if (dtm.Rows.Count == 0)
            {
                int insert = bldd.InsertDynamic("Fone Pay",  imagepath,"Static", "FP");
                if (insert > 0)
                {
                    MessageBox.Show("Software Successfully Updated !!", "Successfully Updated Alert !!");
                }
            }
            else
            {
                int update = bldd.UpdateDynamic(txt_rename.Text, "FP");
                if (update > 0)
                {
                    MessageBox.Show("Software Successfully Updated !!", "Successfully Updated Alert !!");
                }
            }
        }
        private void rbtn_fonePayDynamic_Click(object sender, EventArgs e)
        {
            FonePay fp = new FonePay();
            fp.Show();
        }

        private void label151_Click(object sender, EventArgs e)
        {

        }
    }
}
