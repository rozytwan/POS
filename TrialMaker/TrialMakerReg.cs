using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace SoftwareLocker
{
    public class TrialMakerReg
    {
        #region -> Private Variables 

        private string _BaseString;
        private string _Password;
        private string _SoftName;
        private string _RegFilePath;
        private string _HideFilePath;
        private int _DefDays;
        private int _Runed;
        private string _Text;
        private string _Identifier;

        #endregion

        #region -> Constructor 

        /// <summary>
        /// Make new TrialMaker class to make software trial
        /// </summary>
        /// <param name="SoftwareName">Name of software to make trial</param>
        /// <param name="RegFilePath">File path to save password(enrypted)</param>
        /// <param name="HideFilePath">file path for saving hidden information</param>
        /// <param name="Text">A text for contacting to you</param>
        /// <param name="TrialDays">Default period days</param>
        /// <param name="TrialRunTimes">How many times user can run as trial</param>
        /// <param name="Identifier">3 Digit string as your identifier to make password</param>
        public TrialMaker(string SoftwareName,
           string RegFilePath, string HideFilePath,
           string Text, string Identifier)
        {
            _SoftName = SoftwareName;
            _Identifier = Identifier;

            SetDefaults();
            _RegFilePath = RegFilePath;
            _HideFilePath = HideFilePath;
            _Text = Text;
        }
        private void SetDefaults()
        {
            SystemInfo.UseBaseBoardManufacturer = false;
            SystemInfo.UseBaseBoardProduct = true;
            SystemInfo.UseBiosManufacturer = false;
            SystemInfo.UseBiosVersion = true;
            SystemInfo.UseDiskDriveSignature = true;
            SystemInfo.UsePhysicalMediaSerialNumber = false;
            SystemInfo.UseProcessorID = true;
            SystemInfo.UseVideoControllerCaption = false;
            SystemInfo.UseWindowsSerialNumber = false;

            MakeBaseString();
            MakePassword();
        }
        private void MakeBaseString()
        {
            _BaseString = Encryption.Boring(Encryption.InverseByBase(SystemInfo.GetSystemInfo(_SoftName), 10));
        }

        private void MakePassword()
        {
            _Password = Encryption.MakePassword(_BaseString, _Identifier);
        }
        #endregion

    }

}
