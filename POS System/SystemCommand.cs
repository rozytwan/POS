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

namespace POS_System
{
    public partial class SystemCommand : Form
    {
        public SystemCommand()
        {
            InitializeComponent();
        }
        BLLSystemCommand blsc = new BLLSystemCommand();
        private void btn_takeaway_Click(object sender, EventArgs e)
        {
            if (commandLine.Text != "" && commandLine.Text.Length > 0)
            {
                if (commandLine.Text == "CS101")
                {
                    int TruncateTablebillInvoice = blsc.TruncateTablebillInvoice();
                    int TruncateTablebillReprint = blsc.TruncateTablebillReprint();
                    int TruncateTablebillVoid = blsc.TruncateTablebillVoid();
                    int TruncateTableComplemenrtyTracking = blsc.TruncateTableComplemenrtyTracking();
                    int TruncateTableComplementrySales = blsc.TruncateTableComplementrySales();
                    int TruncateTableIrdCBMSOffline = blsc.TruncateTableIrdCBMSOffline();
                    int TruncateTableIrdCBMSSROffline = blsc.TruncateTableIrdCBMSSROffline();
                    int TruncateTablematerilizedView = blsc.TruncateTablematerilizedView();
                    int TruncateTableSalesRecord = blsc.TruncateTableSalesRecord();

                    commandLine.Text = "";
                    commandLine.Text = "Execute Complete";

                }
                else if (commandLine.Text == "CCO102")
                {
                    int TruncateTableSalesRecord = blsc.TruncateTableOrderCancel();
                    commandLine.Text = "";
                    commandLine.Text = "Execute Complete";
                }
                else if (commandLine.Text == "Execute Complete")
                {
                    this.Close();
                }
            }
        }
    }
}
