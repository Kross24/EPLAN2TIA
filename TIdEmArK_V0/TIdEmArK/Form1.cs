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
using System.Linq;
using System.Security;
using System.Xml.Linq;
using Siemens.Engineering.Connection;
using Siemens.Engineering.Download;
using Siemens.Engineering.Download.Configurations;




namespace TIdEmArK
{
    public partial class Form1 : Form
    {
        //Variablen für neues Projekt anlegen
        string TiaProjectPath;
        string TiaProjectName;
        //TIA Variablen
        TiaLibraryHelper tiaLibraryHelper = new TiaLibraryHelper();
        private static TiaPortalProcess _tiaProcess;
        public TiaPortal MyTiaPortal
        {
            get; set;
        }
        public Project MyProject
        {
            get; set;
        }

        public Form1()
        {
            InitializeComponent();
            AppDomain CurrentDomain = AppDomain.CurrentDomain;
            this.AutoSize = true;
            textBox1_edit();
        }
        //-----------------------------------------
        //Oberflächenprogrammierung in Windows Form
        //-----------------------------------------

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
            btn_deleteChkDev.Enabled = false;
            btn_refresh.Enabled = false;
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

            GenerateTreeView();
            tiaLibraryHelper.OpenGlobalLibrary(MyTiaPortal, textBox1);
            btn_CompileHW.Enabled = true;
            btn_CloseProject.Enabled = true;
            btn_SearchProject.Enabled = false;
            btn_Save.Enabled = true;
            btn_AddHW.Enabled = true;
            btn_deleteChkDev.Enabled = true;
            btn_refresh.Enabled = true;

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
        IList<TiaPortalProcess> processes = TiaPortal.GetProcesses();
        private void btn_Connect_Click(object sender, EventArgs e)
        {
            btn_Connect.Enabled = false;

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
                    GenerateTreeView();
                    tiaLibraryHelper.OpenGlobalLibrary(MyTiaPortal, textBox1);
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
            btn_deleteChkDev.Enabled = true;
            btn_refresh.Enabled = true;
        }
        #endregion

        #region TIA Compile
        private void Compile(object sender, EventArgs e)
        {
            btn_CompileHW.Enabled = false;

            string devname = txt_Device.Text;
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
                                    ICompilable compiler = controllerTarget.GetService<ICompilable>();

                                    CompilerResult result = compiler.Compile();
                                    txt_Status.Text = "Compiling of " + controllerTarget.Name + ": State: " + result.State + " / Warning Count: " + result.WarningCount + " / Error Count: " + result.ErrorCount;
                                }
                            }
                            if (softwareContainer.Software is HmiTarget)
                            {
                                HmiTarget hmitarget = softwareContainer.Software as HmiTarget;
                                if (hmitarget != null)
                                {
                                    found = true;
                                    ICompilable compiler = hmitarget.GetService<ICompilable>();
                                    CompilerResult result = compiler.Compile();
                                    txt_Status.Text = "Compiling of " + hmitarget.Name + ": State: " + result.State + " / Warning Count: " + result.WarningCount + " / Error Count: " + result.ErrorCount;
                                }
                            }
                        }
                    }
                }
            }
            if (found == false)
            {
                txt_Status.Text = "Found no device with name " + txt_Device.Text;
            }

            btn_CompileHW.Enabled = true;
        }
        #endregion

        #region TIA Device per Hand hinzufügen <<BEARBEITUNG NICHT ABGESCHLOSSEN >>
        //Add Device Namensabgleich funktioniert nicht
        //Add DeviceItem hinzufügen funktioniert nicht, TIA Lizenz?

        List<TreeNode> AddDeviceItem1 = new List<TreeNode>();
        List<Device> DeviceToAddItem = new List<Device>();

        private void btn_AddHW_Click(object sender, EventArgs e)
        {
            if (rdb_Device.Checked == true)
            {
                AddDevice(MyProject);
            }
            else
            {
                AddDeviceItem(tv_ProjectTIA1.Nodes[0].Nodes, MyProject);
            }            
        }

        void AddDevice(Project project)
        {
            btn_AddHW.Enabled = false;
            string MLFB = "OrderNumber:" + txt_OrderNo.Text + "/" + txt_Version.Text;

            string name = txt_AddDevice.Text;
            string devname = "station" + txt_AddDevice.Text;
            bool found = false;
            foreach (Device device in project.Devices)
            {                
                foreach (DeviceItem deviceItem in device.DeviceItems)
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
                Device deviceName = project.Devices.CreateWithItem(MLFB, name, devname);
                txt_Status.Text = "Add Device Name: " + name + " with Order Number: " + txt_OrderNo.Text + " and Firmware Version: " + txt_Version.Text;
            }
            btn_AddHW.Enabled = true;
        }

        /// <summary>
        /// AddDeviceItem fügt DeviceItem an ausgewähltem Device (TreeView) hinzu
        /// </summary>
        /// <param name="nodes">Einstieg mit Angabe des Device Knotens -> nodes[Projektknoten].Nodes[Device]</param>
        /// <param name="project"></param>
        void AddDeviceItem(TreeNodeCollection nodes, Project project)
        {
            btn_AddHW.Enabled = false;
            string MLFB = "OrderNumber:" + txt_OrderNo.Text + "/" + txt_Version.Text;
            string name = txt_AddDevice.Text;
            string devname = "station" + txt_AddDevice.Text;

            //In TreeView nach checked Nodes suchen 
            foreach (TreeNode node1 in nodes) // Achtung Einstieg schon mit nodes[Projektknoten].Nodes[Device] => Device
            {
                if (node1 != null)
                {
                    if (node1.Checked) //Deviceknoten
                    {
                        AddDeviceItem1.Add(node1); //Schreibe in Liste
                    }                    
                }
                else
                {
                    txt_Status.Text = "No node is checked!";
                }
            }
            foreach (TreeNode checkedNode in AddDeviceItem1) //Für jeden TreeView checked Node wird ein passender Device im Projekt zugeordnet
            {
                if (checkedNode != null)
                {
                    string _devname = checkedNode.Text; //Device Name von TreeView Auswahl
                    foreach (Device device in project.Devices) // Zuordnung der Devices in neuer Liste
                    {
                        if (device.Name == _devname)
                        {
                            DeviceToAddItem.Add(device);
                        }
                    }
                }
            }//Jetzt stehen alle gewählten Devices als Typ Device in einer Liste
            try
            {
                foreach (Device device in DeviceToAddItem) //jetzt wird für jeden Device das gewünschte DeviceItem hinzugefügt
                {
                    HardwareObject hwObject = device;
                    string name_braeak = hwObject.Name;
                    string typeIdentifier = MLFB;
                    int positionNumber = int.Parse(txt_rackPosition.Text); //String zu Int aus Textbox
                    if (hwObject.CanPlugNew(typeIdentifier, name, positionNumber)) //Gibt als Wert True oder False zurück (prüfen ob überhaupt möglich)
                    {
                        DeviceItem newPluggedDeviceItem = hwObject.PlugNew(typeIdentifier, name, positionNumber);
                    }
                }
                GenerateTreeView();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error generating new DeviceItem: " + e.Message);
            }
            btn_AddHW.Enabled = true;
        }
        #endregion

        #region TIA Hierarchie importieren

        List<string> myDevices = new List<string>();
        List<string> myDeviceItems = new List<string>();
        private void EnumerateDevicesInProject(Project project, TreeView tv_object)
        {
            tv_ProjectTIA1.Nodes.Add("Project:" + project.Name); // Projekt Node anlegen
            tv_ProjectTIA1.Nodes[0].Checked = false;
            int count = 0;
            var devices = MyProject.Devices;
            foreach (Device device in devices)
            {
                myDevices.Add(device.Name);
                tv_object.Nodes[0].Nodes.Add(device.Name);
                GenerateDeviceItems(device, tv_object, count);
                count = count + 1;
            }
        }
        private void GenerateDeviceItems(Device device, TreeView tv_object, int count)
        {
            foreach (var item in device.DeviceItems)
            {
                var deviceItem = (DeviceItem)item;
                tv_object.Nodes[0].Nodes[count].Nodes.Add(deviceItem.Name);
                myDeviceItems.Add(deviceItem.Name);
            }
        }
        #endregion

        #region TreeView aus TIA Hierarchie erzeugen
        public void GenerateTreeView()
        {
            tv_ProjectTIA1.Nodes.Clear();
            bool _currentProject;
            Program _statusproject = new Program();

            _currentProject = _statusproject.CurrentProject(_tiaProcess, MyTiaPortal, MyProject);

            if (_currentProject == true)
            {
                try
                {
                    EnumerateDevicesInProject(MyProject, tv_ProjectTIA1); // Geräte in Projekt enumerieren   
                    //tv_ProjectTIA1.ExpandAll(); //Subknoten aufklappen
                    tv_ProjectTIA1.Nodes[0].Expand(); //Projektknoten aufklappen
                }
                catch
                {
                    txt_Status.Text = "Fehler! Anderes Projekt geöffnet.";
                    tv_ProjectTIA1.Enabled = false;
                }
                tv_ProjectTIA1.Enabled = true;
            }
        }
        private void refresh_Click(object sender, EventArgs e)
        {
            GenerateTreeView();
            tiaLibraryHelper.OpenGlobalLibrary(MyTiaPortal, textBox1);
        }
        #endregion

        #region TIA Device im Projekt entfernen
        private void btn_deleteChkDev_Click(object sender, EventArgs e)
        {
            RemoveCheckedNodes(tv_ProjectTIA1.Nodes, MyProject);
        }

        List<TreeNode> checkedNodes = new List<TreeNode>(); //Vorteil Liste -> man muss die Größe vorher nicht wissen
        List<Device> checkedDevices1 = new List<Device>();
        List<DeviceItem> checkedDeviceItems1 = new List<DeviceItem>();

        void RemoveCheckedNodes(TreeNodeCollection nodes, Project project)
        {
            foreach (TreeNode node in nodes)
            {
                if (node != null)
                {
                    if (node.Checked) //Projektknoten
                    {
                        checkedNodes.Add(node); //Markierte Knoten werden der jeweiligen Liste hinzugefügt                        
                    }
                    else
                    {
                        foreach (TreeNode node1 in node.Nodes)
                        {
                            if (node1.Checked) //Deviceknoten
                            {
                                checkedNodes.Add(node1); //Markierte Knoten werden der jeweiligen Liste hinzugefügt                               
                            }
                            else
                            {
                                foreach (TreeNode node2 in node1.Nodes)
                                {
                                    if (node2.Checked) //DeviceItemknoten
                                    {
                                        checkedNodes.Add(node2); //Markierte Knoten werden der jeweiligen Liste hinzugefügt
                                    }
                                }
                            }
                        }
                    }
                }
            }
            foreach (TreeNode checkedNode in checkedNodes)
            {
                if (checkedNode != null)
                {
                    string devname = checkedNode.Text; //Device/DeviceItem Name von TreeView Auswahl
                    foreach (Device device in project.Devices) // Schreibt alle zu löschenden Devices/DeviceItems in eine Liste
                    {
                        DeviceItemComposition deviceItemAggregation = device.DeviceItems;
                        foreach (DeviceItem deviceItem in deviceItemAggregation)
                        {
                            if (deviceItem.Name == devname)
                            {
                                checkedDeviceItems1.Add(deviceItem);
                            }
                        }
                        if (device.Name == devname)
                        {
                            checkedDevices1.Add(device);
                        }
                    }
                }
                nodes.Remove(checkedNode); //Ausgewählten Knoten im TreeView löschen
            }
            for (int i = 0; i < checkedDevices1.Count(); i++) // Löscht die Devices aus der Liste
            {
                Device deviceToDelete = checkedDevices1[checkedDevices1.Count() - 1 - i];
                deviceToDelete.Delete(); //Ausgewähltes Device im TIA löschen

            }
            for (int u = 0; u < checkedDeviceItems1.Count(); u++) // Löscht die DeviceItems aus der Liste
            {
                DeviceItem deviceItemToDelete = checkedDeviceItems1[checkedDeviceItems1.Count() - 1 - u];
                deviceItemToDelete.Delete(); //Ausgewähltes DeviceItem im TIA löschen
            }
            //Listenelemente löschen nach Iteration
            checkedDeviceItems1.Clear();
            checkedDevices1.Clear();
            checkedNodes.Clear();
        }
        #endregion

        #region TreeView zusätzliche HW-Infos
        private void tv_ProjectTIA1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            GetHWAddInfo(MyProject, tv_ProjectTIA1);
        }

        void GetHWAddInfo(Project project, TreeView tv_item)
        {
            string devname = tv_item.SelectedNode.Text;
            foreach (Device device in project.Devices)
            {
                //Attribute für Geräte/Geräteelemente
                var typeidentifier = "TypeIdentifier";
                //var ordernumber = "OrderNumber";
                var typename = "TypeName"; //Achtung bei GSD Device funktioniert Typename nicht
                var name = "Name";

                DeviceItemComposition deviceItemAggregation = device.DeviceItems;
                foreach (DeviceItem deviceItem in deviceItemAggregation)
                {
                    if (deviceItem.Name == devname)
                    {
                        object attributeNamesInfo = ((IEngineeringObject)deviceItem).GetAttribute(typename);
                        txt_addHwInfoDevice.Text = attributeNamesInfo.ToString();

                        object attributeValueDeviceItem = ((IEngineeringObject)deviceItem).GetAttribute(typeidentifier);
                        txt_addHwInfoDeviceItem.Text = attributeValueDeviceItem.ToString();
                        //object ordernumberInfo = ((IEngineeringObject)deviceItem).GetAttribute(ordernumber);
                        //txt_addHwInfo3.Text = ordernumberInfo.ToString();
                    }
                    else if (device.Name == devname)
                    {
                        object attributeValueDevice1 = ((IEngineeringObject)device).GetAttribute(name);
                        txt_addHwInfoDevice.Text = attributeValueDevice1.ToString();

                        object attributeValueDevice2 = ((IEngineeringObject)device).GetAttribute(typeidentifier);
                        txt_addHwInfoDeviceItem.Text = attributeValueDevice2.ToString();
                    }
                }
            }
        }
        #endregion

        #region Textbox Bibliothek Edit
        private void textBox1_edit()
        {
            //Einstellung Textboxfenster txtBox1 ----> Kann später entfernt werden
            // Set the Multiline property to true.
            textBox1.Multiline = true;
            // Add vertical scroll bars to the TextBox control.
            textBox1.ScrollBars = ScrollBars.Vertical;
            // Allow the RETURN key to be entered in the TextBox control.
            textBox1.AcceptsReturn = true;
            // Allow the TAB key to be entered in the TextBox control.
            textBox1.AcceptsTab = true;
            // Set WordWrap to true to allow text to wrap to the next line.
            textBox1.WordWrap = true;
            // Set the default text of the control.            
        }









        #endregion

        #region Form Settings Device/DeviceItem
        private void rdb_Device_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_Device.Checked == true)
            {
                txt_rackPosition.Enabled = false;
                txt_AddDevice.Text = "PLC_1";
                txt_OrderNo.Text = "6ES7 516-3AN01-0AB0";
                txt_Version.Text = "V2.1";
                label_rackPosition.Enabled = false;
            }
            else
            {
                txt_rackPosition.Enabled = true;
            }

        }
        private void rdb_DeviceItem_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_deviceItem.Checked == true)
            {
                txt_rackPosition.Enabled = true;
                txt_AddDevice.Text = "PS 60W 120/230VAC/DC";
                txt_OrderNo.Text = "6ES7 507-0RA00-0AB0";
                txt_Version.Text = "V1.0";
                txt_rackPosition.Text = "0";
                label_rackPosition.Enabled = true;
            }
            else
            {
                txt_rackPosition.Enabled = false;
            }
        }
        #endregion


    }//Klassenende
}//Namespaceende



