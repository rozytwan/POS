using System;
using System.Collections.Generic;
using System.Text;
using System.Management;
using Microsoft.Win32;

namespace SoftwareLocker
{
    static class SystemInfo
    {
        #region -> Private Variables

        public static bool UseProcessorID;
        public static bool UseBaseBoardProduct;
        public static bool UseBaseBoardManufacturer;
        public static bool UseDiskDriveSignature;
        public static bool UseVideoControllerCaption;
        public static bool UsePhysicalMediaSerialNumber;
        public static bool UseBiosVersion;
        public static bool UseBiosManufacturer;
        public static bool UseWindowsSerialNumber;

        #endregion
        static string trial_version;
        public static string GetSystemInfo(string SoftwareName)
        {
            if(UseProcessorID == true)
                SoftwareName += RunQuery("Processor", "ProcessorId");

            if (UseBaseBoardProduct == true)
                SoftwareName += RunQuery("BaseBoard", "Product");

            if (UseBaseBoardManufacturer == true)
                SoftwareName += RunQuery("BaseBoard", "Manufacturer");

            //if (UseDiskDriveSignature == true)
            //    SoftwareName += RunQuery("DiskDrive", "Signature");

            if (UseVideoControllerCaption == true)
                SoftwareName += RunQuery("VideoController", "Caption");

            if (UsePhysicalMediaSerialNumber == true)
                SoftwareName += RunQuery("PhysicalMedia", "SerialNumber");

            if (UseBiosVersion == true)
                SoftwareName += RunQuery("BIOS", "Version");

            if (UseWindowsSerialNumber == true)
                SoftwareName += RunQuery("OperatingSystem", "SerialNumber");

            SoftwareName = RemoveUseLess(SoftwareName);
            RegistryKey regkey = Registry.CurrentUser;
            regkey = regkey.CreateSubKey(globalPath); //path
            string Br = (string)regkey.GetValue("Trial");
            trial_version = Br;
            if (trial_version == "False")
            {
                if (SoftwareName.Length < 25)
                {
                    var stchar = new char[8];
                    var rand = new Random();

                    for (int i = 0; i < stchar.Length; i++)
                    {
                        stchar[i] = SoftwareName[rand.Next(SoftwareName.Length)];
                    }

                    var finstring = new String(stchar);
                    return GetSystemInfo(finstring);
                }
                var stringChars = new char[25];
                var random = new Random();

                for (int i = 0; i < stringChars.Length; i++)
                {
                    stringChars[i] = SoftwareName[random.Next(SoftwareName.Length)];
                }

                var finalString = new String(stringChars);
                return finalString.Substring(0, 25).ToUpper();
            }
            else
            {

                if (SoftwareName.Length < 25)
                    return GetSystemInfo(SoftwareName);

                return SoftwareName.Substring(0, 25).ToUpper();
            }
        }
      
        static int totalOneyear;
        static string globalPath = @"Software\restrictedarea\restrictedValues\pospos\PosPrivate";
     

        private static String oneyearDifPutPresent()
        {
            // get present date from system
            DateTime dt = DateTime.Now;
            string today = dt.ToShortDateString();
            DateTime presentDate = Convert.ToDateTime(today);

            // get instalation date
            RegistryKey regkey = Registry.CurrentUser;
            regkey = regkey.CreateSubKey(globalPath); //path
            string Br = (string)regkey.GetValue("Install");
            DateTime installationDate = Convert.ToDateTime(Br);

            TimeSpan diff = presentDate.Subtract(installationDate); //first.Subtract(second);
            totalOneyear = (int)diff.TotalDays;

            // special check if user chenge date in system
            string usd = (string)regkey.GetValue("Use");
            DateTime lastUse = Convert.ToDateTime(usd);
            TimeSpan diff1 = presentDate.Subtract(lastUse); //first.Subtract(second);
            int useBetween = (int)diff1.TotalDays;

           
                // put next use day in registry
                regkey.SetValue("Use", today); //Value Name,Value Data

            if (useBetween >= 0)
            {
                if (totalOneyear < 0)
                    return "Error"; // if user change date in system like date set before installation
                else if (totalOneyear >= 0 && totalOneyear <= 365)
                    return Convert.ToString(365 - totalOneyear); //how many days remaining
                else
                    return "One Expired"; //Expired
            }
            else
                return "Error"; // if user change date in system
        }
        private static string RemoveUseLess(string st)
        {
            char ch;
            for (int i = st.Length - 1; i >= 0; i--)
            {
                ch = char.ToUpper(st[i]);
                
                if ((ch < 'A' || ch > 'Z') &&
                    (ch < '0' || ch > '9'))
                {
                    st = st.Remove(i, 1);
                }
            }
            return st;
        }

        private static string RunQuery(string TableName, string MethodName)
        {
            ManagementObjectSearcher MOS = new ManagementObjectSearcher("Select * from Win32_" + TableName);
            foreach (ManagementObject MO in MOS.Get())
            {
                try
                {
                    return MO[MethodName].ToString();
                }
                catch (Exception e)
                {
                    System.Windows.Forms.MessageBox.Show(e.Message);
                }
            }
            return "";
        }
    }
}
