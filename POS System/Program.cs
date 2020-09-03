using System;
using System.Windows.Forms;
using SecureApp;
using SoftwareLocker;
using POS_System.CustomerLoyalty;
using POS_System.CustomerAttendance;

namespace POS_System
{
   public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            TrialMaker t = new TrialMaker("TMTestSM", Application.StartupPath + "\\RegFile.reg", Environment.GetFolderPath(Environment.SpecialFolder.System) + "\\TMSetup.dbf", "", 30, "745");
            byte[] MyOwenKey = { 97, 250, 1, 5, 84, 21, 7, 63, 4, 54, 87, 56, 123, 10, 3, 62, 7, 9, 20, 36, 37, 21, 101, 57 };
            t.TripleDESKey = MyOwenKey;
            TrialMaker.RunTypes RT = t.ShowDialog();
            string abc = @"Software\restrictedarea\restrictedValues\pospos\PosPrivate";
            Secure scr = new Secure();
            bool logic = scr.Algorithm(frmDialog.trial_code, abc);
            if (logic == true)
            {
                Application.Run(new Login());
            }
        }      
    }
}





