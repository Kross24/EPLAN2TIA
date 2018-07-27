using Microsoft.Win32;
using Siemens.Engineering;
using Siemens.Engineering.HW;
using Siemens.Engineering.HW.Features;
using Siemens.Engineering.HW.Utilities;
using Siemens.Engineering.SW;
using Siemens.Engineering.SW.Blocks;
using Siemens.Engineering.SW.TechnologicalObjects;
using Siemens.Engineering.SW.TechnologicalObjects.Motion;
using Siemens.Engineering.SW.ExternalSources;
using Siemens.Engineering.SW.Tags;
using Siemens.Engineering.SW.Types;
using Siemens.Engineering.Hmi;
using Siemens.Engineering.Hmi.Tag;
using Siemens.Engineering.Hmi.Screen;
using Siemens.Engineering.Hmi.Cycle;
using Siemens.Engineering.Hmi.Communication;
using Siemens.Engineering.Hmi.Globalization;
using Siemens.Engineering.Hmi.TextGraphicList;
using Siemens.Engineering.Hmi.RuntimeScripting;
using System.Collections.Generic;
using Siemens.Engineering.Online;
using Siemens.Engineering.Compiler;
using Siemens.Engineering.Library;
using Siemens.Engineering.Library.Types;
using Siemens.Engineering.Library.MasterCopies;
using Siemens.Engineering.Compare;
using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.ComponentModel;

namespace TIdEmArK
{
    public partial class Form1 : Form
    {
        private static TiaPortalProcess _tiaProcess;

        public TiaPortal MyTiaPortal
        {
            get; set;
        }
        public Project MyProject
        {
            get; set;
        }

        //Variablen für neues Projekt anlegen
        string TiaProjectPath;
        string TiaProjectName;

        public Form1()
        {
            InitializeComponent();
            AppDomain CurrentDomain = AppDomain.CurrentDomain;
            CurrentDomain.AssemblyResolve += new ResolveEventHandler(MyResolver);
            this.AutoSize = true;
            //this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        }
        private static Assembly MyResolver(object sender, ResolveEventArgs args)
        {
            int index = args.Name.IndexOf(',');
            if (index == -1)
            {
                return null;
            }
            string name = args.Name.Substring(0, index);

            RegistryKey filePathReg = Registry.LocalMachine.OpenSubKey(
                "SOFTWARE\\Siemens\\Automation\\Openness\\15.0\\PublicAPI\\15.0.0.0");

            if (filePathReg == null)
                return null;

            object oRegKeyValue = filePathReg.GetValue(name);
            if (oRegKeyValue != null)
            {
                string filePath = oRegKeyValue.ToString();

                string path = filePath;
                string fullPath = Path.GetFullPath(path);
                if (File.Exists(fullPath))
                {
                    return Assembly.LoadFrom(fullPath);
                }
            }

            return null;
        }

        //Oberflächenprogrammierung in Windows Form

        #region TIA START
        private void btn_StartTIA_Click(object sender, EventArgs e)
        {
            if (rdb_WithoutUI.Checked == true)
            {
                MyTiaPortal = new TiaPortal(TiaPortalMode.WithoutUserInterface);
                txt_Status.Text = "TIA Portal started without user interface";
                _tiaProcess = TiaPortal.GetProcesses()[0];
            }
            else
            {
                MyTiaPortal = new TiaPortal(TiaPortalMode.WithUserInterface);
                txt_Status.Text = "TIA Portal started with user interface";
            }
            btn_SearchProject.Enabled = true;
            btn_disposeTIA.Enabled = true;
            btn_startTIA.Enabled = false;
            btn_NewProject.Enabled = true;
            txt_ProjectName.Enabled = true;
            txt_ProjectPath.Enabled = true;
        }
        #endregion

        #region TIA Dispose
        private void btn_disposeTIA_Click(object sender, EventArgs e)
        {
            MyTiaPortal.Dispose();
            txt_Status.Text = "TIA Portal disposed";
            btn_startTIA.Enabled = true;
            btn_disposeTIA.Enabled = false;
            btn_CloseProject.Enabled = false;
            btn_SearchProject.Enabled = false;
            btn_CompileHW.Enabled = false;
            btn_Save.Enabled = false;
            btn_NewProject.Enabled = false;
            txt_ProjectName.Enabled = false;
            txt_ProjectPath.Enabled = false;

        }
        #endregion

        #region TIA neues Projekt anlegen
        private void txt_ProjectPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                string ProjectSavePath = folderBrowserDialog1.SelectedPath.ToString();
                string ProjectSaveName = txt_ProjectName.Text;

                txt_ProjectPath.Text = ProjectSavePath;
                TiaProjectPath = ProjectSavePath;
                TiaProjectName = ProjectSaveName;
                btn_NewProject.Enabled = true;
            }
        }
        private void btn_NewProject_Click(object sender, EventArgs e)
        {
            //TiaPortal tiaPortal = new TiaPortal();
            ProjectComposition projectComposition = MyTiaPortal.Projects;
            DirectoryInfo targetDirectory = new DirectoryInfo(TiaProjectPath);
            Project project = projectComposition.Create(targetDirectory, TiaProjectName);

            txt_Status.Text = "New Project generated";
        }
        #endregion

        #region TIA Projekt öffnen
        //Projekt öffnen (1) Projektpfad sowie Projekt ermitteln
        private void btn_SearchProject_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileSearch = new OpenFileDialog();

            fileSearch.Filter = "*.ap15|*.ap15";
            fileSearch.RestoreDirectory = true;
            fileSearch.ShowDialog();

            string ProjectPath = fileSearch.FileName.ToString();

            if (string.IsNullOrEmpty(ProjectPath) == false)
            {
                OpenProject(ProjectPath);
            }
        }
        //Projekt öffnen (2) Projektpfad als Übergabewert von SearchProject() -> Projectpath
        private void OpenProject(string ProjectPath)
        {
            try
            {
                MyProject = MyTiaPortal.Projects.Open(new FileInfo(ProjectPath));
                txt_Status.Text = "Project " + ProjectPath + " opened";

            }
            catch (Exception ex)
            {
                txt_Status.Text = "Error while opening project" + ex.Message;
            }

            btn_CompileHW.Enabled = true;
            btn_CloseProject.Enabled = true;
            btn_SearchProject.Enabled = false;
            btn_Save.Enabled = true;
            btn_AddHW.Enabled = true;
        }
        #endregion

        #region TIA Projekt speichern
        private void SaveProject(object sender, EventArgs e)
        {
            MyProject.Save();
            txt_Status.Text = "Project saved";
        }
        #endregion

        #region TIA Projekt schließen
        private void CloseProject(object sender, EventArgs e)
        {
            MyProject.Close();

            txt_Status.Text = "Project closed";

            btn_SearchProject.Enabled = true;
            btn_CloseProject.Enabled = false;
            btn_Save.Enabled = false;
            btn_CompileHW.Enabled = false;
        }
        #endregion

        #region TIA Baustein exportieren (bisher ungenutzt)
        //Exports a regular block
        private static void ExportRegularBlock(PlcSoftware plcSoftware)
        {
            PlcBlock plcBlock = plcSoftware.BlockGroup.Blocks.Find("TestFC1");
            plcBlock.Export(new FileInfo(string.Format(@"D:\Samples\{0}.xml", plcBlock.Name)), ExportOptions.WithDefaults);
        }
        #endregion

        #region TIA Connect zu offenem Projekt
        //Mit geöffnetem Projekt verbinden
        private void btn_Connect_Click(object sender, EventArgs e)
        {
            btn_Connect.Enabled = false;
            IList<TiaPortalProcess> processes = TiaPortal.GetProcesses();
            switch (processes.Count)
            {
                case 1:
                    _tiaProcess = processes[0];
                    MyTiaPortal = _tiaProcess.Attach();
                    if (MyTiaPortal.GetCurrentProcess().Mode == TiaPortalMode.WithUserInterface)
                    {
                        rdb_WithUI.Checked = true;
                    }
                    else
                    {
                        rdb_WithoutUI.Checked = true;
                    }


                    if (MyTiaPortal.Projects.Count <= 0)
                    {
                        txt_Status.Text = "No TIA Portal Project was found!";
                        btn_Connect.Enabled = true;
                        return;
                    }
                    MyProject = MyTiaPortal.Projects[0];
                    break;
                case 0:
                    txt_Status.Text = "No running instance of TIA Portal was found!";
                    btn_Connect.Enabled = true;
                    return;
                default:
                    txt_Status.Text = "More than one running instance of TIA Portal was found!";
                    btn_Connect.Enabled = true;
                    return;
            }
            txt_Status.Text = _tiaProcess.ProjectPath.ToString();
            btn_startTIA.Enabled = false;
            btn_Connect.Enabled = true;
            btn_disposeTIA.Enabled = true;
            btn_CompileHW.Enabled = true;
            btn_CloseProject.Enabled = true;
            btn_SearchProject.Enabled = false;
            btn_Save.Enabled = true;
            btn_AddHW.Enabled = true;
        }
        #endregion

        #region TIA Hardware per Hand hinzufügen
        private void btn_AddHW_Click(object sender, EventArgs e)
        {
            btn_AddHW.Enabled = false;
            string MLFB = "OrderNumber:" + txt_OrderNo.Text + "/" + txt_Version.Text;

            string name = txt_AddDevice.Text;
            string devname = "station" + txt_AddDevice.Text;
            bool found = false;
            foreach (Device device in MyProject.Devices)
            {
                DeviceItemComposition deviceItemAggregation = device.DeviceItems;
                foreach (DeviceItem deviceItem in deviceItemAggregation)
                {
                    if (deviceItem.Name == devname || device.Name == devname)
                    {
                        SoftwareContainer softwareContainer = deviceItem.GetService<SoftwareContainer>();
                        if (softwareContainer != null)
                        {
                            if (softwareContainer.Software is PlcSoftware)
                            {
                                PlcSoftware controllerTarget = softwareContainer.Software as PlcSoftware;
                                if (controllerTarget != null)
                                {
                                    found = true;

                                }
                            }
                            if (softwareContainer.Software is HmiTarget)
                            {
                                HmiTarget hmitarget = softwareContainer.Software as HmiTarget;
                                if (hmitarget != null)
                                {
                                    found = true;

                                }

                            }
                        }
                    }
                }
            }
            if (found == true)
            {
                txt_Status.Text = "Device " + txt_Device.Text + " already exists";
            }
            else
            {
                Device deviceName = MyProject.Devices.CreateWithItem(MLFB, name, devname);

                txt_Status.Text = "Add Device Name: " + name + " with Order Number: " + txt_OrderNo.Text + " and Firmware Version: " + txt_Version.Text;
            }

            btn_AddHW.Enabled = true;

        }
        #endregion
    }
}
