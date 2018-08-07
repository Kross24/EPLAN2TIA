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
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.txt_Status = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdb_deviceItem = new System.Windows.Forms.RadioButton();
            this.rdb_Device = new System.Windows.Forms.RadioButton();
            this.label_rackPosition = new System.Windows.Forms.Label();
            this.txt_rackPosition = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btn_deleteChkDev = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.txt_Device = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.btn_CompileHW = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.txt_ProjectPath = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_ProjectName = new System.Windows.Forms.TextBox();
            this.btn_NewProject = new System.Windows.Forms.Button();
            this.txt_AddDevice = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Connect = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_CloseProject = new System.Windows.Forms.Button();
            this.txt_Version = new System.Windows.Forms.TextBox();
            this.btn_SearchProject = new System.Windows.Forms.Button();
            this.rdb_WithUI = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rdb_WithoutUI = new System.Windows.Forms.RadioButton();
            this.txt_OrderNo = new System.Windows.Forms.TextBox();
            this.btn_disposeTIA = new System.Windows.Forms.Button();
            this.btn_startTIA = new System.Windows.Forms.Button();
            this.btn_AddHW = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.Libaries = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txt_addHwInfoDeviceItem = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_addHwInfoDevice = new System.Windows.Forms.TextBox();
            this.btn_refresh = new System.Windows.Forms.Button();
            this.tv_ProjectTIA1 = new System.Windows.Forms.TreeView();
            this.label9 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_Status
            // 
            this.txt_Status.BackColor = System.Drawing.SystemColors.Info;
            this.txt_Status.Location = new System.Drawing.Point(237, 449);
            this.txt_Status.Name = "txt_Status";
            this.txt_Status.Size = new System.Drawing.Size(560, 20);
            this.txt_Status.TabIndex = 5;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(233, 5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(568, 438);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabControl1.TabIndex = 53;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.label_rackPosition);
            this.tabPage1.Controls.Add(this.txt_rackPosition);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.btn_deleteChkDev);
            this.tabPage1.Controls.Add(this.label14);
            this.tabPage1.Controls.Add(this.txt_Device);
            this.tabPage1.Controls.Add(this.label13);
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Controls.Add(this.btn_CompileHW);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.txt_ProjectPath);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.txt_ProjectName);
            this.tabPage1.Controls.Add(this.btn_NewProject);
            this.tabPage1.Controls.Add(this.txt_AddDevice);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.btn_Connect);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.btn_Save);
            this.tabPage1.Controls.Add(this.btn_CloseProject);
            this.tabPage1.Controls.Add(this.txt_Version);
            this.tabPage1.Controls.Add(this.btn_SearchProject);
            this.tabPage1.Controls.Add(this.rdb_WithUI);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.rdb_WithoutUI);
            this.tabPage1.Controls.Add(this.txt_OrderNo);
            this.tabPage1.Controls.Add(this.btn_disposeTIA);
            this.tabPage1.Controls.Add(this.btn_startTIA);
            this.tabPage1.Controls.Add(this.btn_AddHW);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(560, 412);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "General";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdb_deviceItem);
            this.groupBox1.Controls.Add(this.rdb_Device);
            this.groupBox1.Location = new System.Drawing.Point(158, 214);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(97, 50);
            this.groupBox1.TabIndex = 104;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Choose";
            // 
            // rdb_deviceItem
            // 
            this.rdb_deviceItem.AutoSize = true;
            this.rdb_deviceItem.Location = new System.Drawing.Point(6, 30);
            this.rdb_deviceItem.Name = "rdb_deviceItem";
            this.rdb_deviceItem.Size = new System.Drawing.Size(90, 17);
            this.rdb_deviceItem.TabIndex = 100;
            this.rdb_deviceItem.Text = "Is DeviceItem";
            this.rdb_deviceItem.UseVisualStyleBackColor = true;
            this.rdb_deviceItem.CheckedChanged += new System.EventHandler(this.rdb_DeviceItem_CheckedChanged);
            // 
            // rdb_Device
            // 
            this.rdb_Device.AutoSize = true;
            this.rdb_Device.Checked = true;
            this.rdb_Device.Location = new System.Drawing.Point(6, 13);
            this.rdb_Device.Name = "rdb_Device";
            this.rdb_Device.Size = new System.Drawing.Size(70, 17);
            this.rdb_Device.TabIndex = 101;
            this.rdb_Device.TabStop = true;
            this.rdb_Device.Text = "Is Device";
            this.rdb_Device.UseVisualStyleBackColor = true;
            this.rdb_Device.CheckedChanged += new System.EventHandler(this.rdb_Device_CheckedChanged);
            // 
            // label_rackPosition
            // 
            this.label_rackPosition.AutoSize = true;
            this.label_rackPosition.Enabled = false;
            this.label_rackPosition.Location = new System.Drawing.Point(85, 293);
            this.label_rackPosition.Name = "label_rackPosition";
            this.label_rackPosition.Size = new System.Drawing.Size(73, 13);
            this.label_rackPosition.TabIndex = 103;
            this.label_rackPosition.Text = "Rack Position";
            // 
            // txt_rackPosition
            // 
            this.txt_rackPosition.Enabled = false;
            this.txt_rackPosition.Location = new System.Drawing.Point(88, 310);
            this.txt_rackPosition.Name = "txt_rackPosition";
            this.txt_rackPosition.Size = new System.Drawing.Size(43, 20);
            this.txt_rackPosition.TabIndex = 102;
            this.txt_rackPosition.Text = "e.g. 4";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(302, 213);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 13);
            this.label8.TabIndex = 97;
            this.label8.Text = "Type Device name";
            // 
            // btn_deleteChkDev
            // 
            this.btn_deleteChkDev.Enabled = false;
            this.btn_deleteChkDev.Location = new System.Drawing.Point(16, 367);
            this.btn_deleteChkDev.Name = "btn_deleteChkDev";
            this.btn_deleteChkDev.Size = new System.Drawing.Size(115, 36);
            this.btn_deleteChkDev.TabIndex = 99;
            this.btn_deleteChkDev.Text = "Delete Checked ";
            this.btn_deleteChkDev.UseVisualStyleBackColor = true;
            this.btn_deleteChkDev.Click += new System.EventHandler(this.btn_deleteChkDev_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(148, 17);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(47, 13);
            this.label14.TabIndex = 81;
            this.label14.Text = "Project";
            // 
            // txt_Device
            // 
            this.txt_Device.Location = new System.Drawing.Point(305, 229);
            this.txt_Device.Name = "txt_Device";
            this.txt_Device.Size = new System.Drawing.Size(115, 20);
            this.txt_Device.TabIndex = 96;
            this.txt_Device.Text = "PLC_1";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(336, 171);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(0, 13);
            this.label13.TabIndex = 80;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(285, 74);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(61, 13);
            this.label12.TabIndex = 79;
            this.label12.Text = "Projektpfad";
            // 
            // btn_CompileHW
            // 
            this.btn_CompileHW.Enabled = false;
            this.btn_CompileHW.Location = new System.Drawing.Point(305, 253);
            this.btn_CompileHW.Name = "btn_CompileHW";
            this.btn_CompileHW.Size = new System.Drawing.Size(115, 36);
            this.btn_CompileHW.TabIndex = 95;
            this.btn_CompileHW.Text = "Compile";
            this.btn_CompileHW.UseVisualStyleBackColor = true;
            this.btn_CompileHW.Click += new System.EventHandler(this.Compile);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(285, 35);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(66, 13);
            this.label11.TabIndex = 78;
            this.label11.Text = "Projektname";
            // 
            // txt_ProjectPath
            // 
            this.txt_ProjectPath.Enabled = false;
            this.txt_ProjectPath.Location = new System.Drawing.Point(288, 90);
            this.txt_ProjectPath.Name = "txt_ProjectPath";
            this.txt_ProjectPath.Size = new System.Drawing.Size(115, 20);
            this.txt_ProjectPath.TabIndex = 77;
            this.txt_ProjectPath.Text = "D:\\TIA\\Projects";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 213);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 90;
            this.label5.Text = "Type name";
            // 
            // txt_ProjectName
            // 
            this.txt_ProjectName.Enabled = false;
            this.txt_ProjectName.Location = new System.Drawing.Point(288, 51);
            this.txt_ProjectName.Name = "txt_ProjectName";
            this.txt_ProjectName.Size = new System.Drawing.Size(115, 20);
            this.txt_ProjectName.TabIndex = 76;
            this.txt_ProjectName.Text = "Project1";
            // 
            // btn_NewProject
            // 
            this.btn_NewProject.Enabled = false;
            this.btn_NewProject.Location = new System.Drawing.Point(288, 111);
            this.btn_NewProject.Name = "btn_NewProject";
            this.btn_NewProject.Size = new System.Drawing.Size(115, 20);
            this.btn_NewProject.TabIndex = 75;
            this.btn_NewProject.Text = "Generate";
            this.btn_NewProject.UseVisualStyleBackColor = true;
            this.btn_NewProject.Click += new System.EventHandler(this.btn_NewProject_Click);
            // 
            // txt_AddDevice
            // 
            this.txt_AddDevice.Location = new System.Drawing.Point(16, 230);
            this.txt_AddDevice.Name = "txt_AddDevice";
            this.txt_AddDevice.Size = new System.Drawing.Size(142, 20);
            this.txt_AddDevice.TabIndex = 89;
            this.txt_AddDevice.Text = "PLC_1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(285, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 13);
            this.label2.TabIndex = 62;
            this.label2.Text = "Generate new project";
            // 
            // btn_Connect
            // 
            this.btn_Connect.Location = new System.Drawing.Point(151, 140);
            this.btn_Connect.Name = "btn_Connect";
            this.btn_Connect.Size = new System.Drawing.Size(115, 36);
            this.btn_Connect.TabIndex = 58;
            this.btn_Connect.Text = "Connect to open TIA Project";
            this.btn_Connect.UseVisualStyleBackColor = true;
            this.btn_Connect.Click += new System.EventHandler(this.btn_Connect_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 293);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 94;
            this.label6.Text = "Type Version";
            // 
            // btn_Save
            // 
            this.btn_Save.Enabled = false;
            this.btn_Save.Location = new System.Drawing.Point(151, 105);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(115, 36);
            this.btn_Save.TabIndex = 61;
            this.btn_Save.Text = "Save Project";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.SaveProject);
            // 
            // btn_CloseProject
            // 
            this.btn_CloseProject.Enabled = false;
            this.btn_CloseProject.Location = new System.Drawing.Point(151, 70);
            this.btn_CloseProject.Name = "btn_CloseProject";
            this.btn_CloseProject.Size = new System.Drawing.Size(115, 36);
            this.btn_CloseProject.TabIndex = 60;
            this.btn_CloseProject.Text = "Close Project";
            this.btn_CloseProject.UseVisualStyleBackColor = true;
            this.btn_CloseProject.Click += new System.EventHandler(this.CloseProject);
            // 
            // txt_Version
            // 
            this.txt_Version.Location = new System.Drawing.Point(16, 310);
            this.txt_Version.Name = "txt_Version";
            this.txt_Version.Size = new System.Drawing.Size(71, 20);
            this.txt_Version.TabIndex = 93;
            this.txt_Version.Text = "V2.1";
            // 
            // btn_SearchProject
            // 
            this.btn_SearchProject.Enabled = false;
            this.btn_SearchProject.Location = new System.Drawing.Point(151, 35);
            this.btn_SearchProject.Name = "btn_SearchProject";
            this.btn_SearchProject.Size = new System.Drawing.Size(115, 36);
            this.btn_SearchProject.TabIndex = 59;
            this.btn_SearchProject.Text = "Open Project";
            this.btn_SearchProject.UseVisualStyleBackColor = true;
            this.btn_SearchProject.Click += new System.EventHandler(this.btn_SearchProject_Click);
            // 
            // rdb_WithUI
            // 
            this.rdb_WithUI.AutoSize = true;
            this.rdb_WithUI.Checked = true;
            this.rdb_WithUI.Location = new System.Drawing.Point(16, 109);
            this.rdb_WithUI.Name = "rdb_WithUI";
            this.rdb_WithUI.Size = new System.Drawing.Size(115, 17);
            this.rdb_WithUI.TabIndex = 57;
            this.rdb_WithUI.TabStop = true;
            this.rdb_WithUI.Text = "With user Interface";
            this.rdb_WithUI.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 254);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 13);
            this.label7.TabIndex = 92;
            this.label7.Text = "Type Order Nr";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 56;
            this.label1.Text = "TIA Portal";
            // 
            // rdb_WithoutUI
            // 
            this.rdb_WithoutUI.AutoSize = true;
            this.rdb_WithoutUI.Location = new System.Drawing.Point(16, 128);
            this.rdb_WithoutUI.Name = "rdb_WithoutUI";
            this.rdb_WithoutUI.Size = new System.Drawing.Size(132, 17);
            this.rdb_WithoutUI.TabIndex = 55;
            this.rdb_WithoutUI.Text = "Without User Interface";
            this.rdb_WithoutUI.UseVisualStyleBackColor = true;
            // 
            // txt_OrderNo
            // 
            this.txt_OrderNo.Location = new System.Drawing.Point(17, 270);
            this.txt_OrderNo.Name = "txt_OrderNo";
            this.txt_OrderNo.Size = new System.Drawing.Size(141, 20);
            this.txt_OrderNo.TabIndex = 91;
            this.txt_OrderNo.Text = "6ES7 516-3AN01-0AB0";
            // 
            // btn_disposeTIA
            // 
            this.btn_disposeTIA.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_disposeTIA.Location = new System.Drawing.Point(16, 69);
            this.btn_disposeTIA.Name = "btn_disposeTIA";
            this.btn_disposeTIA.Size = new System.Drawing.Size(115, 36);
            this.btn_disposeTIA.TabIndex = 54;
            this.btn_disposeTIA.Text = "Dispose TIA";
            this.btn_disposeTIA.UseVisualStyleBackColor = true;
            this.btn_disposeTIA.Click += new System.EventHandler(this.btn_disposeTIA_Click);
            // 
            // btn_startTIA
            // 
            this.btn_startTIA.Location = new System.Drawing.Point(16, 35);
            this.btn_startTIA.Name = "btn_startTIA";
            this.btn_startTIA.Size = new System.Drawing.Size(115, 36);
            this.btn_startTIA.TabIndex = 53;
            this.btn_startTIA.Text = "Start TIA";
            this.btn_startTIA.UseVisualStyleBackColor = true;
            this.btn_startTIA.Click += new System.EventHandler(this.btn_StartTIA_Click);
            // 
            // btn_AddHW
            // 
            this.btn_AddHW.Enabled = false;
            this.btn_AddHW.Location = new System.Drawing.Point(16, 332);
            this.btn_AddHW.Name = "btn_AddHW";
            this.btn_AddHW.Size = new System.Drawing.Size(115, 36);
            this.btn_AddHW.TabIndex = 88;
            this.btn_AddHW.Text = "Add";
            this.btn_AddHW.UseVisualStyleBackColor = true;
            this.btn_AddHW.Click += new System.EventHandler(this.btn_AddHW_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 198);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 86;
            this.label3.Text = "Add / Delete";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(302, 198);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 87;
            this.label4.Text = "Compile";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(560, 412);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Device Add/Del";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // Libaries
            // 
            this.Libaries.AutoSize = true;
            this.Libaries.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Libaries.Location = new System.Drawing.Point(12, 333);
            this.Libaries.Name = "Libaries";
            this.Libaries.Size = new System.Drawing.Size(55, 13);
            this.Libaries.TabIndex = 90;
            this.Libaries.Text = "Libraries";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.textBox1.Location = new System.Drawing.Point(8, 349);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(223, 120);
            this.textBox1.TabIndex = 89;
            // 
            // txt_addHwInfoDeviceItem
            // 
            this.txt_addHwInfoDeviceItem.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txt_addHwInfoDeviceItem.Location = new System.Drawing.Point(8, 310);
            this.txt_addHwInfoDeviceItem.Name = "txt_addHwInfoDeviceItem";
            this.txt_addHwInfoDeviceItem.Size = new System.Drawing.Size(223, 20);
            this.txt_addHwInfoDeviceItem.TabIndex = 88;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(6, 273);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 13);
            this.label10.TabIndex = 87;
            this.label10.Text = "Additional Info";
            // 
            // txt_addHwInfoDevice
            // 
            this.txt_addHwInfoDevice.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txt_addHwInfoDevice.Location = new System.Drawing.Point(8, 289);
            this.txt_addHwInfoDevice.Name = "txt_addHwInfoDevice";
            this.txt_addHwInfoDevice.Size = new System.Drawing.Size(223, 20);
            this.txt_addHwInfoDevice.TabIndex = 86;
            // 
            // btn_refresh
            // 
            this.btn_refresh.Enabled = false;
            this.btn_refresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_refresh.Location = new System.Drawing.Point(183, 5);
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(48, 20);
            this.btn_refresh.TabIndex = 84;
            this.btn_refresh.Text = "refresh";
            this.btn_refresh.UseVisualStyleBackColor = true;
            this.btn_refresh.Click += new System.EventHandler(this.refresh_Click);
            // 
            // tv_ProjectTIA1
            // 
            this.tv_ProjectTIA1.CheckBoxes = true;
            this.tv_ProjectTIA1.Location = new System.Drawing.Point(8, 25);
            this.tv_ProjectTIA1.Name = "tv_ProjectTIA1";
            this.tv_ProjectTIA1.Size = new System.Drawing.Size(223, 245);
            this.tv_ProjectTIA1.TabIndex = 83;
            this.tv_ProjectTIA1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tv_ProjectTIA1_AfterSelect);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(12, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(147, 13);
            this.label9.TabIndex = 82;
            this.label9.Text = "Current project hierarchy";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 481);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btn_refresh);
            this.Controls.Add(this.txt_Status);
            this.Controls.Add(this.Libaries);
            this.Controls.Add(this.txt_addHwInfoDeviceItem);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txt_addHwInfoDevice);
            this.Controls.Add(this.tv_ProjectTIA1);
            this.Name = "Form1";
            this.Text = "TIdEmArK";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txt_Status;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private Label Libaries;
        private TextBox textBox1;
        private TextBox txt_addHwInfoDeviceItem;
        private Label label10;
        private TextBox txt_addHwInfoDevice;
        private Button btn_refresh;
        private TreeView tv_ProjectTIA1;
        private Label label9;
        private Label label14;
        private Label label13;
        private Label label12;
        private Label label11;
        private TextBox txt_ProjectPath;
        private TextBox txt_ProjectName;
        private Button btn_NewProject;
        private Label label2;
        private Button btn_Connect;
        private Button btn_Save;
        private Button btn_CloseProject;
        private Button btn_SearchProject;
        private RadioButton rdb_WithUI;
        private Label label1;
        private RadioButton rdb_WithoutUI;
        private Button btn_disposeTIA;
        private Button btn_startTIA;
        private TabPage tabPage2;
        private Label label8;
        private TextBox txt_Device;
        private Button btn_CompileHW;
        private Label label5;
        private TextBox txt_AddDevice;
        private Label label6;
        private TextBox txt_Version;
        private Label label7;
        private TextBox txt_OrderNo;
        private Button btn_AddHW;
        private Label label4;
        private Label label3;
        private Button btn_deleteChkDev;
        private RadioButton rdb_Device;
        private RadioButton rdb_deviceItem;
        private Label label_rackPosition;
        private TextBox txt_rackPosition;
        private GroupBox groupBox1;
    }
}

