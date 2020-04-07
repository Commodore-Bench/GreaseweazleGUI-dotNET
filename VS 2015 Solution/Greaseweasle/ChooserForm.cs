﻿using System;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using System.Reflection;
using System.Drawing;
using System.Threading;
using System.Linq;
using System.IO.Ports;

namespace Greaseweazle
{
    public partial class ChooserForm : Form
    {
        #region declarations
        public static Form m_frmChooser = null;
        private Form m_frmRead = null;
        private Form m_frmWrite = null;
        private Form m_frmDelays = null;
        private Form m_frmUpdate = null;
        private Form m_frmPin = null;
        private Form m_frmReset = null;
        public string sExeDir = "";
        public string m_action = "read";
        public const int WM_CLOSE = 0x0010;
        public static Boolean m_bF7Type = false;
        public static string m_sUSBPort = "UNKNOWN";
        public static string m_sIniFile = ".\\GreaseweazleGUI.ini";
        public static IniFile m_Ini = null;
        public string m_sVersion = "";
        public Mutex m_exclusiveMutex = null;
        public static int m_ProcessId = 0;
        private string m_sReadDiskFolder = "";
        private string m_sWriteDiskFolder = "";
        private string m_sUpdateFirmwareFolder = "";
        #endregion

        #region ChooserForm
        public ChooserForm()
        {
            InitializeComponent();
            InitializeMyStuff();
        }
        #endregion

        #region InitializeMyStuff
        private void InitializeMyStuff()
        {
            // open application only once
            if (!RequestMutex())
            {
                MessageBox.Show(this, "An instance of \"GreaseweazleGUI.exe\" is already running", "Oops!");
                Icon.Dispose();
                System.Environment.Exit(1);
            }

            // create our forms in advance
            m_frmRead = new ReadForm(this);
            m_frmWrite = new WriteForm(this);
            m_frmDelays = new DelaysForm(this);
            m_frmUpdate = new UpdateForm(this);
            m_frmPin = new PinForm(this);
            m_frmReset = new ResetForm(this);

            // get version from Project, GreaseweaselGUI Properties, Assembly Information
            m_sVersion = Application.ProductVersion;
            string[] tokens = m_sVersion.Split('.');
            m_sVersion = "v" + tokens[2] + "." + tokens[3];
            this.Text = "GUI " + m_sVersion + " - Host Tools v0.12";

            // initialize some stuff
            m_Ini = new IniFile(m_sIniFile);
            string sOops = "";
            rbReadDisk.Checked = true;
            m_frmChooser = this;
            menuStrip1.BackColor = mnuSettings.BackColor;

            // set working directory to executable directory
            sExeDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            Directory.SetCurrentDirectory(sExeDir);

            // check for existance of gw.py
            if (!File.Exists(sExeDir + "\\gw.py"))
                sOops = "GreaseweazleGUI.exe must be moved to same folder as the controllers CURRENT firmware 'Host Tools' support files were extracted.";

            // display error
            if (sOops.Length > 0)
                System.Windows.Forms.MessageBox.Show(sOops, "Oops!");

            // read our settings
            iniReadFile();

            // set default folders
            if (m_sReadDiskFolder.Length == 0)
                m_sReadDiskFolder = sExeDir;
            if (m_sWriteDiskFolder.Length == 0)
                m_sWriteDiskFolder = sExeDir;
            if (m_sUpdateFirmwareFolder.Length == 0)
                m_sUpdateFirmwareFolder = sExeDir;

            // Get a list of serial port names.
            refreshUSBPorts();
        }
        #endregion

        #region iniReadFile
        public void iniReadFile()
        {
            string sRet;

            // get rid of previous ini file version
            if (File.Exists(m_Ini.path))
            {
                if ((m_Ini.IniReadValue("gbCommandLine", "m_sPythonFolder", "garbage").Trim()) != "garbage")
                {
                    // delete the old format ini file if it exists
                    File.Delete(m_Ini.path);

                    // disable usb port support
                    m_Ini.IniWriteValue("gbUSBPorts", "mnuUSBSupport", "False");
                    foreach (Control ctrl in gbUSBPorts.Controls)
                        ctrl.Enabled = false;
                    mnuUSBSupport.Checked = false;
                }
            }
            else
            {
                // inifile does not exist, disable usb suport the first run
                m_Ini.IniWriteValue("gbUSBPorts", "mnuUSBSupport", "False");
                foreach (Control ctrl in gbUSBPorts.Controls)
                    ctrl.Enabled = false;
                mnuUSBSupport.Checked = false;
            }

            // action
            if ((sRet = (m_Ini.IniReadValue("gbAction", "rbReadDisk", "garbage").Trim())) != "garbage")
            {
                if (sRet == "True")
                    rbReadDisk.Checked = true;
            }
            if ((sRet = (m_Ini.IniReadValue("gbAction", "rbWriteDisk", "garbage").Trim())) != "garbage")
            {
                if (sRet == "True")
                    rbWriteDisk.Checked = true;
            }
            if ((sRet = (m_Ini.IniReadValue("gbAction", "rbSetDelays", "garbage").Trim())) != "garbage")
            {
                if (sRet == "True")
                    rbSetDelays.Checked = true;
            }
            if ((sRet = (m_Ini.IniReadValue("gbAction", "rbUpdateFirmware", "garbage").Trim())) != "garbage")
            {
                if (sRet == "True")
                    rbUpdateFirmware.Checked = true;
            }
            if ((sRet = (m_Ini.IniReadValue("gbAction", "rbPin", "garbage").Trim())) != "garbage")
            {
                if (sRet == "True")
                    rbPin.Checked = true;
            }
            if ((sRet = (m_Ini.IniReadValue("gbAction", "rbReset", "garbage").Trim())) != "garbage")
            {
                if (sRet == "True")
                    rbReset.Checked = true;
            }

            // type
            if ((sRet = (m_Ini.IniReadValue("gbType", "rbF1", "garbage").Trim())) != "garbage")
            {
                if (sRet == "True")
                    rbF1.Checked = true;
            }
            if ((sRet = (m_Ini.IniReadValue("gbType", "rbF7", "garbage").Trim())) != "garbage")
            {
                if (sRet == "True")
                    rbF7.Checked = true;
            }

            // usb port
            if ((sRet = (m_Ini.IniReadValue("gbUSBPorts", "m_sUSBPort", "garbage").Trim())) != "garbage")
                m_sUSBPort = sRet;
            if ((sRet = (m_Ini.IniReadValue("gbUSBPorts", "mnuUSBSupport", "garbage").Trim())) != "garbage")
            {
                if (sRet == "True")
                {
                    // enable all the usb groupbox controls
                    foreach (Control ctrl in gbUSBPorts.Controls)
                        ctrl.Enabled = true;

                    // set selected usb port if remembered
                    if (m_sUSBPort != "UNKNOWN")
                    {
                        int iIndex = lbUSBPorts.FindString(m_sUSBPort);
                        if ((m_sUSBPort.Length > 0) && (iIndex != -1))
                            lbUSBPorts.SetSelected(iIndex, true);
                    }
                    mnuUSBSupport.Checked = true;
                }
                else
                {
                    // disable all the usb groupbox controls
                    foreach (Control ctrl in gbUSBPorts.Controls)
                        ctrl.Enabled = false;
                    mnuUSBSupport.Checked = false;
                }
            }
        }
        #endregion

        #region iniWriteFile
        public void iniWriteFile()
        {
            // action
            m_Ini.IniWriteValue("gbAction", "rbReadDisk", (rbReadDisk.Checked == true).ToString());
            m_Ini.IniWriteValue("gbAction", "rbWriteDisk", (rbWriteDisk.Checked == true).ToString());
            m_Ini.IniWriteValue("gbAction", "rbSetDelays", (rbSetDelays.Checked == true).ToString());
            m_Ini.IniWriteValue("gbAction", "rbUpdateFirmware", (rbUpdateFirmware.Checked == true).ToString());
            m_Ini.IniWriteValue("gbAction", "rbPin", (rbPin.Checked == true).ToString());
            m_Ini.IniWriteValue("gbAction", "rbReset", (rbReset.Checked == true).ToString());

            // type
            m_Ini.IniWriteValue("gbType", "rbF1", (rbF1.Checked == true).ToString());
            m_Ini.IniWriteValue("gbType", "rbF7", (rbF7.Checked == true).ToString());

            // usb port
            m_Ini.IniWriteValue("gbUSBPorts", "mnuUSBSupport", (mnuUSBSupport.Checked == true).ToString());
            m_Ini.IniWriteValue("gbUSBPorts", "m_sUSBPort", m_sUSBPort);
        }
        #endregion

        #region refreshUSBPorts
        private void refreshUSBPorts()
        {
            // Get a list of serial port names.
            string[] ports = SerialPort.GetPortNames();

            // clear port list
            lbUSBPorts.Items.Clear();

            // now rebuild the listbox
            foreach (string port in ports)
                lbUSBPorts.Items.Add(port);

            // set selected usb port if remembered
            int iIndex = lbUSBPorts.FindString(m_sUSBPort);
            if ((mnuUSBSupport.Checked == true) && (m_sUSBPort.Length > 0) && (iIndex != -1))
                lbUSBPorts.SetSelected(iIndex, true);
        }
        #endregion

        #region RequestMutex
        public bool RequestMutex()
        {
            // open mutex exclusively
            try
            {
                // make sure we were only called once
                bool requestInitialOwnership = true;
                bool mutexWasCreated;
                m_exclusiveMutex = new Mutex(requestInitialOwnership, "GreaseweazleMutex", out mutexWasCreated);
                return mutexWasCreated;
            }

            catch (Exception e)
            {
                Console.WriteLine("The following Exception reported: " + e.ToString());
                while (e.InnerException != null)
                {
                    Console.WriteLine("--------------------------------");
                    Console.WriteLine("The following InnerException reported: " + e.InnerException.ToString());
                    e = e.InnerException;
                }
            }
            return false;
        }
        #endregion

        #region WndProc
        protected override void WndProc(ref Message m) // capture close message so we can save our settings
        {
            if (m.Msg == WM_CLOSE)
            {
                // write inifile
                iniWriteFile();

                // release mutex
                if (null != m_exclusiveMutex)
                    m_exclusiveMutex.Close();
            }
            base.WndProc(ref m);
        }

        #endregion

        #region btnClose_Click
        private void btnClose_Click(object sender, EventArgs e)
        {
            iniWriteFile();
            Application.Exit();
        }
        #endregion

        #region btnRefreshUSB_Click
        private void btnRefreshUSB_Click(object sender, EventArgs e)
        {
            refreshUSBPorts();
        }
        #endregion

        #region lbUSBPorts_SelectedIndexChanged
        private void lbUSBPorts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((mnuUSBSupport.Checked == true) && (lbUSBPorts.SelectedIndex != -1))
            {
                m_sUSBPort = lbUSBPorts.Items[lbUSBPorts.SelectedIndex].ToString();
            }
        }
        #endregion

        #region mnuUSBSupport_Click
        private void mnuUSBSupport_Click(object sender, EventArgs e)
        {
            if (mnuUSBSupport.Checked != true)
                mnuUSBSupport.Checked = true;
            else
                mnuUSBSupport.Checked = false;

        }
        #endregion

        #region mnuUSBSupport_CheckChanged
        private void mnuUSBSupport_CheckChanged(object sender, EventArgs e)
        {
            if (mnuUSBSupport.Checked == true)
            {
                // enable all the usb groupbox controls
                foreach (Control ctrl in gbUSBPorts.Controls)
                    ctrl.Enabled = true;
                // set selected usb port if remembered
                int iIndex = lbUSBPorts.FindString(m_sUSBPort);
                if ((m_sUSBPort.Length > 0) && (iIndex != -1))
                    lbUSBPorts.SetSelected(iIndex, true);
            }
            else
            {
                // disable all the usb groupbox controls
                foreach (Control ctrl in gbUSBPorts.Controls)
                    ctrl.Enabled = false;
                lbUSBPorts.SelectedIndex = -1;
            }
        }
        #endregion

        #region btnSelect_Click
        private void btnSelect_Click(object sender, EventArgs e)
        {
            // save ini settings
            iniWriteFile();

            // minimize main window
            this.Hide();

            // close all open forms
            for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
            {
                if (Application.OpenForms[i].Name != "ChooserForm")
                {
                    Application.OpenForms[i].Close();
                }
            }

            switch (m_action)
            {
                case "update":
                    if (m_frmUpdate.Visible)
                    {
                        m_frmUpdate.WindowState = FormWindowState.Normal;
                        m_frmUpdate.BringToFront();
                    }
                    else
                    {
                        m_frmUpdate.Dispose();
                        m_frmUpdate = new UpdateForm(this);
                        m_frmUpdate.ShowDialog(this);
                    }
                    break;
                case "delays":
                    if (m_frmDelays.Visible)
                    {
                        m_frmDelays.WindowState = FormWindowState.Normal;
                        m_frmDelays.BringToFront();
                    }
                    else
                    {
                        m_frmDelays.Dispose();
                        m_frmDelays = new DelaysForm(this);
                        m_frmDelays.ShowDialog(this);
                    }
                    break;
                case "read":
                    if (m_frmRead.Visible)
                    {
                        m_frmRead.WindowState = FormWindowState.Normal;
                        m_frmRead.BringToFront();
                    }
                    else
                    {
                        m_frmRead.Dispose();
                        m_frmRead = new ReadForm(this);
                        m_frmRead.ShowDialog(this);
                    }
                    break;
                case "write":
                    if (m_frmWrite.Visible)
                    {
                        m_frmWrite.WindowState = FormWindowState.Normal;
                        m_frmWrite.BringToFront();
                    }
                    else
                    {
                        m_frmWrite.Dispose();
                        m_frmWrite = new WriteForm(this);
                        m_frmWrite.ShowDialog(this);
                    }
                    break;
                case "pinlevel":
                    if (m_frmPin.Visible)
                    {
                        m_frmPin.WindowState = FormWindowState.Normal;
                        m_frmPin.BringToFront();
                    }
                    else
                    {
                        m_frmPin.Dispose();
                        m_frmPin = new PinForm(this);
                        m_frmPin.ShowDialog(this);
                    }
                    break;
                case "reset":
                    if (m_frmReset.Visible)
                    {
                        m_frmReset.WindowState = FormWindowState.Normal;
                        m_frmReset.BringToFront();
                    }
                    else
                    {
                        m_frmReset.Dispose();
                        m_frmReset = new ResetForm(this);
                        m_frmReset.ShowDialog(this);
                    }
                    break;
            }
        }
        #endregion

        #region rbUpdateFirmware_CheckedChanged
        private void rbUpdateFirmware_CheckedChanged(object sender, EventArgs e)
        {
            if (rbUpdateFirmware.Checked == true)
            {
                m_action = "update";
            }
        }
        #endregion

        #region rbSetDelays_CheckedChanged
        private void rbSetDelays_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSetDelays.Checked == true)
                m_action = "delays";
        }
        #endregion

        #region rbReadDisk_CheckedChanged
        private void rbReadDisk_CheckedChanged(object sender, EventArgs e)
        {
            if (rbReadDisk.Checked == true)
                m_action = "read";
        }
        #endregion

        #region rbWriteDisk_CheckedChanged
        private void rbWriteDisk_CheckedChanged(object sender, EventArgs e)
        {
            if (rbWriteDisk.Checked == true)
                m_action = "write";
        }
        #endregion

        #region rbPin_CheckedChanged
        private void rbPin_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPin.Checked == true)
                m_action = "pinlevel";
        }
        #endregion

        #region rbReset_CheckedChanged
        private void rbReset_CheckedChanged(object sender, EventArgs e)
        {
            if (rbReset.Checked == true)
                m_action = "reset";
        }
        #endregion

        #region rbF7_CheckedChanged
        private void rbF7_CheckedChanged(object sender, EventArgs e)
        {
            if (rbF7.Checked)
                m_bF7Type = true;
        }
        #endregion

        #region rbF1_CheckedChanged
        private void rbF1_CheckedChanged(object sender, EventArgs e)
        {
            if (rbF1.Checked)
                m_bF7Type = false;
        }
        #endregion

        #region aboutToolStripMenuItem_Click
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form m_frmAbout = new AboutForm();
            m_frmAbout.ShowDialog(m_frmChooser);
        }
        #endregion
    }
}
