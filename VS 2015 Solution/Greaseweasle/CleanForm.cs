﻿// CleanForm.cs
//
// Greaseweazle GUI Wrapper
//
// Copyright (c) 2019 Don Mankin <don.mankin@yahoo.com>
//
// MIT License
//
// See the file LICENSE for more details, or visit <https://opensource.org/licenses/MIT>.

using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Greaseweazle
{
    public partial class CleanForm : Form
    {
        private const int WM_CLOSE = 0x0010;
        private Form m_frmChooser = null;
        private string m_sUSBPort = "UNKNOWN";
        private bool m_bUSBSupport = false;
        private bool m_bLegacyUSB = true;
        private bool m_bWindowsEXE = false;
        private bool m_bElapsedTime = false;

        #region ResetForm
        public CleanForm(ChooserForm newForm)
        {
            m_frmChooser = newForm;
            InitializeComponent();

            // disable maximize box
            this.MaximizeBox = false;
        }
        #endregion

        #region LaunchPython
        private void LaunchPython()
        {
            // only allow one instance at a time
            Process[] processlist = Process.GetProcesses();
            foreach (Process theprocess in processlist)
            {
                if (theprocess.Id > 0)
                {
                    if (ChooserForm.m_ProcessId == theprocess.Id)
                    {
                        System.Windows.Forms.MessageBox.Show("You must first close the previous Greaseweazle command console", "Oops!");
                        return;
                    }
                }
            }

            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.CreateNoWindow = false;
            startInfo.UseShellExecute = false;
            startInfo.FileName = "C:\\WINDOWS\\SYSTEM32\\cmd.exe";
            startInfo.WindowStyle = ProcessWindowStyle.Normal;
            startInfo.Arguments = "/K " + "\"" + txtCleanCommandLine.Text + "\"";
            try
            {
                Process exeProcess = Process.Start(startInfo);
                ChooserForm.m_ProcessId = exeProcess.Id;
            }
            catch (Exception e)
            {
                string sMessage = e.Message.ToString();
                MessageBox.Show(this, "An error has occured\n" + sMessage, "Oops!");
            }
        }
        #endregion

        #region CreateCommandLine
        private void CreateCommandLine()
        {

            if (true == m_bWindowsEXE)
                txtCleanCommandLine.Text = "gw.exe";
            else
                txtCleanCommandLine.Text = "python.exe " + ChooserForm.m_sGWscript;
            if (true == m_bElapsedTime)
                txtCleanCommandLine.Text += " --time";
            txtCleanCommandLine.Text += " clean";
            if ((m_bLegacyUSB == false) && (m_bUSBSupport == true) && (m_sUSBPort != "UNKNOWN"))
                txtCleanCommandLine.Text += " --device=" + m_sUSBPort;
            if ((m_bLegacyUSB == true) && (m_bUSBSupport == true) && (m_sUSBPort != "UNKNOWN"))
                txtCleanCommandLine.Text += " " + m_sUSBPort;
        }
        #endregion

        #region iniWriteFile
        public void iniWriteFile()
        {
            // reset controller
            ChooserForm.m_Ini.IniWriteValue("gbClean", "txtCleanCommandLine", txtCleanCommandLine.Text);
        }
        #endregion

        #region iniReadFile
        public void iniReadFile()
        {
            string sRet;

            // usb port
            if ((sRet = (ChooserForm.m_Ini.IniReadValue("gbUSBPorts", "m_sUSBPort", "garbage").Trim())) != "garbage")
                m_sUSBPort = sRet;
            if ((sRet = (ChooserForm.m_Ini.IniReadValue("gbUSBPorts", "mnuUSBSupport", "garbage").Trim())) != "garbage")
                m_bUSBSupport = (sRet == "True");
            if ((sRet = (ChooserForm.m_Ini.IniReadValue("gbUSBPorts", "chkLegacyUSB", "garbage").Trim())) != "garbage")
                m_bLegacyUSB = (sRet == "True");

            // globals
            if ((sRet = (ChooserForm.m_Ini.IniReadValue("gbGlobals", "mnuWindowsEXE", "garbage").Trim())) != "garbage")
                m_bWindowsEXE = (sRet == "True");
            if ((sRet = (ChooserForm.m_Ini.IniReadValue("gbGlobals", "mnuElapsedTime", "garbage").Trim())) != "garbage")
                m_bElapsedTime = (sRet == "True");
        }
        #endregion

        #region btnLaunch_Click
        private void btnLaunch_Click(object sender, EventArgs e)
        {
            LaunchPython();
        }
        #endregion

        #region btnBack_Click
        private void btnBack_Click(object sender, EventArgs e)
        {
            iniWriteFile();
            m_frmChooser.Show();
            this.Close();
        }
        #endregion

        #region CleanForm_Load
        private void CleanForm_Load(object sender, EventArgs e)
        {
            iniReadFile();

            // set colors
            this.lblHostTools.Text = ChooserForm.m_sStatusLine;
            this.BackColor = ChooserForm.cChocolate;
            this.txtCleanCommandLine.BackColor = ChooserForm.cLightBrown;
            this.btnLaunch.BackColor = ChooserForm.cDarkBrown;
            this.btnBack.BackColor = ChooserForm.cDarkBrown;
            
            CreateCommandLine();
        }
        #endregion

        #region WndProc
        protected override void WndProc(ref Message m) // capture close message so we can save our settings
        {
            if (m.Msg == WM_CLOSE)
            {
                // write inifile
                iniWriteFile();

                // show main form
                ChooserForm.m_frmChooser.Show();
            }
            base.WndProc(ref m);
        }
        #endregion
    }
}