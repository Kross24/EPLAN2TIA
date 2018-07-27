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
            this.btn_Connect = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_CloseProject = new System.Windows.Forms.Button();
            this.btn_SearchProject = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_AddDevice = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_Version = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_OrderNo = new System.Windows.Forms.TextBox();
            this.btn_AddHW = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_Device = new System.Windows.Forms.TextBox();
            this.btn_CompileHW = new System.Windows.Forms.Button();
            this.btn_NewProject = new System.Windows.Forms.Button();
            this.txt_ProjectName = new System.Windows.Forms.TextBox();
            this.txt_ProjectPath = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.btn_startTIA = new System.Windows.Forms.Button();
            this.btn_disposeTIA = new System.Windows.Forms.Button();
            this.rdb_WithoutUI = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.rdb_WithUI = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // txt_Status
            // 
            this.txt_Status.Location = new System.Drawing.Point(15, 364);
            this.txt_Status.Name = "txt_Status";
            this.txt_Status.Size = new System.Drawing.Size(761, 20);
            this.txt_Status.TabIndex = 5;
            // 
            // btn_Connect
            // 
            this.btn_Connect.Location = new System.Drawing.Point(343, 77);
            this.btn_Connect.Name = "btn_Connect";
            this.btn_Connect.Size = new System.Drawing.Size(115, 36);
            this.btn_Connect.TabIndex = 15;
            this.btn_Connect.Text = "Connect to open TIA Project";
            this.btn_Connect.UseVisualStyleBackColor = true;
            this.btn_Connect.Click += new System.EventHandler(this.btn_Connect_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.Enabled = false;
            this.btn_Save.Location = new System.Drawing.Point(343, 120);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(115, 36);
            this.btn_Save.TabIndex = 18;
            this.btn_Save.Text = "Save Project";
            this.btn_Save.UseVisualStyleBackColor = true;
            // 
            // btn_CloseProject
            // 
            this.btn_CloseProject.Enabled = false;
            this.btn_CloseProject.Location = new System.Drawing.Point(343, 164);
            this.btn_CloseProject.Name = "btn_CloseProject";
            this.btn_CloseProject.Size = new System.Drawing.Size(115, 36);
            this.btn_CloseProject.TabIndex = 17;
            this.btn_CloseProject.Text = "Close Project";
            this.btn_CloseProject.UseVisualStyleBackColor = true;
            // 
            // btn_SearchProject
            // 
            this.btn_SearchProject.Enabled = false;
            this.btn_SearchProject.Location = new System.Drawing.Point(343, 35);
            this.btn_SearchProject.Name = "btn_SearchProject";
            this.btn_SearchProject.Size = new System.Drawing.Size(115, 36);
            this.btn_SearchProject.TabIndex = 16;
            this.btn_SearchProject.Text = "Open Project";
            this.btn_SearchProject.UseVisualStyleBackColor = true;
            this.btn_SearchProject.Click += new System.EventHandler(this.btn_SearchProject_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(191, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Generate new project";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(503, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Add";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(658, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Compile";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(502, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Type Device name";
            // 
            // txt_AddDevice
            // 
            this.txt_AddDevice.Location = new System.Drawing.Point(502, 52);
            this.txt_AddDevice.Name = "txt_AddDevice";
            this.txt_AddDevice.Size = new System.Drawing.Size(115, 20);
            this.txt_AddDevice.TabIndex = 24;
            this.txt_AddDevice.Text = "PLC_1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(502, 115);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 29;
            this.label6.Text = "Type Version";
            // 
            // txt_Version
            // 
            this.txt_Version.Location = new System.Drawing.Point(502, 132);
            this.txt_Version.Name = "txt_Version";
            this.txt_Version.Size = new System.Drawing.Size(115, 20);
            this.txt_Version.TabIndex = 28;
            this.txt_Version.Text = "V2.1";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(503, 75);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 13);
            this.label7.TabIndex = 27;
            this.label7.Text = "Type Order Nr";
            // 
            // txt_OrderNo
            // 
            this.txt_OrderNo.Location = new System.Drawing.Point(503, 92);
            this.txt_OrderNo.Name = "txt_OrderNo";
            this.txt_OrderNo.Size = new System.Drawing.Size(115, 20);
            this.txt_OrderNo.TabIndex = 26;
            this.txt_OrderNo.Text = "6ES7 516-3AN01-0AB0";
            // 
            // btn_AddHW
            // 
            this.btn_AddHW.Enabled = false;
            this.btn_AddHW.Location = new System.Drawing.Point(502, 164);
            this.btn_AddHW.Name = "btn_AddHW";
            this.btn_AddHW.Size = new System.Drawing.Size(115, 36);
            this.btn_AddHW.TabIndex = 23;
            this.btn_AddHW.Text = "Add Device";
            this.btn_AddHW.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(661, 35);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 13);
            this.label8.TabIndex = 32;
            this.label8.Text = "Type Device name";
            // 
            // txt_Device
            // 
            this.txt_Device.Location = new System.Drawing.Point(661, 52);
            this.txt_Device.Name = "txt_Device";
            this.txt_Device.Size = new System.Drawing.Size(115, 20);
            this.txt_Device.TabIndex = 31;
            this.txt_Device.Text = "PLC_1";
            // 
            // btn_CompileHW
            // 
            this.btn_CompileHW.Enabled = false;
            this.btn_CompileHW.Location = new System.Drawing.Point(661, 83);
            this.btn_CompileHW.Name = "btn_CompileHW";
            this.btn_CompileHW.Size = new System.Drawing.Size(115, 36);
            this.btn_CompileHW.TabIndex = 30;
            this.btn_CompileHW.Text = "Compile";
            this.btn_CompileHW.UseVisualStyleBackColor = true;
            // 
            // btn_NewProject
            // 
            this.btn_NewProject.Enabled = false;
            this.btn_NewProject.Location = new System.Drawing.Point(194, 119);
            this.btn_NewProject.Name = "btn_NewProject";
            this.btn_NewProject.Size = new System.Drawing.Size(115, 20);
            this.btn_NewProject.TabIndex = 33;
            this.btn_NewProject.Text = "Generate";
            this.btn_NewProject.UseVisualStyleBackColor = true;
            this.btn_NewProject.Click += new System.EventHandler(this.btn_NewProject_Click);
            // 
            // txt_ProjectName
            // 
            this.txt_ProjectName.Enabled = false;
            this.txt_ProjectName.Location = new System.Drawing.Point(194, 51);
            this.txt_ProjectName.Name = "txt_ProjectName";
            this.txt_ProjectName.Size = new System.Drawing.Size(115, 20);
            this.txt_ProjectName.TabIndex = 34;
            this.txt_ProjectName.Text = "Project1";
            // 
            // txt_ProjectPath
            // 
            this.txt_ProjectPath.Enabled = false;
            this.txt_ProjectPath.Location = new System.Drawing.Point(194, 90);
            this.txt_ProjectPath.Name = "txt_ProjectPath";
            this.txt_ProjectPath.Size = new System.Drawing.Size(115, 20);
            this.txt_ProjectPath.TabIndex = 36;
            this.txt_ProjectPath.Text = "D:\\TIA\\Projects";
            this.txt_ProjectPath.Click += new System.EventHandler(this.txt_ProjectPath_Click);
            this.txt_ProjectPath.TextChanged += new System.EventHandler(this.btn_disposeTIA_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(191, 35);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(66, 13);
            this.label11.TabIndex = 38;
            this.label11.Text = "Projektname";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(191, 74);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(61, 13);
            this.label12.TabIndex = 39;
            this.label12.Text = "Projektpfad";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(402, 172);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(0, 13);
            this.label13.TabIndex = 40;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(340, 8);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(47, 13);
            this.label14.TabIndex = 41;
            this.label14.Text = "Project";
            // 
            // btn_startTIA
            // 
            this.btn_startTIA.Location = new System.Drawing.Point(15, 35);
            this.btn_startTIA.Name = "btn_startTIA";
            this.btn_startTIA.Size = new System.Drawing.Size(143, 44);
            this.btn_startTIA.TabIndex = 0;
            this.btn_startTIA.Text = "Start TIA";
            this.btn_startTIA.UseVisualStyleBackColor = true;
            this.btn_startTIA.Click += new System.EventHandler(this.btn_StartTIA_Click);
            // 
            // btn_disposeTIA
            // 
            this.btn_disposeTIA.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_disposeTIA.Location = new System.Drawing.Point(15, 95);
            this.btn_disposeTIA.Name = "btn_disposeTIA";
            this.btn_disposeTIA.Size = new System.Drawing.Size(143, 44);
            this.btn_disposeTIA.TabIndex = 1;
            this.btn_disposeTIA.Text = "Dispose TIA";
            this.btn_disposeTIA.UseVisualStyleBackColor = true;
            this.btn_disposeTIA.Click += new System.EventHandler(this.btn_disposeTIA_Click);
            // 
            // rdb_WithoutUI
            // 
            this.rdb_WithoutUI.AutoSize = true;
            this.rdb_WithoutUI.Location = new System.Drawing.Point(15, 169);
            this.rdb_WithoutUI.Name = "rdb_WithoutUI";
            this.rdb_WithoutUI.Size = new System.Drawing.Size(132, 17);
            this.rdb_WithoutUI.TabIndex = 2;
            this.rdb_WithoutUI.Text = "Without User Interface";
            this.rdb_WithoutUI.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "TIA Portal";
            // 
            // rdb_WithUI
            // 
            this.rdb_WithUI.AutoSize = true;
            this.rdb_WithUI.Checked = true;
            this.rdb_WithUI.Location = new System.Drawing.Point(15, 146);
            this.rdb_WithUI.Name = "rdb_WithUI";
            this.rdb_WithUI.Size = new System.Drawing.Size(115, 17);
            this.rdb_WithUI.TabIndex = 4;
            this.rdb_WithUI.TabStop = true;
            this.rdb_WithUI.Text = "With user Interface";
            this.rdb_WithUI.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 405);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txt_ProjectPath);
            this.Controls.Add(this.txt_ProjectName);
            this.Controls.Add(this.btn_NewProject);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txt_Device);
            this.Controls.Add(this.btn_CompileHW);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_AddDevice);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_Version);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txt_OrderNo);
            this.Controls.Add(this.btn_AddHW);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_Connect);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.btn_CloseProject);
            this.Controls.Add(this.btn_SearchProject);
            this.Controls.Add(this.txt_Status);
            this.Controls.Add(this.rdb_WithUI);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rdb_WithoutUI);
            this.Controls.Add(this.btn_disposeTIA);
            this.Controls.Add(this.btn_startTIA);
            this.Name = "Form1";
            this.Text = "TIdEmArK";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txt_Status;
        private System.Windows.Forms.Button btn_Connect;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button btn_CloseProject;
        private System.Windows.Forms.Button btn_SearchProject;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_AddDevice;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_Version;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_OrderNo;
        private System.Windows.Forms.Button btn_AddHW;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_Device;
        private System.Windows.Forms.Button btn_CompileHW;
        private System.Windows.Forms.Button btn_NewProject;
        private System.Windows.Forms.TextBox txt_ProjectName;
        private System.Windows.Forms.TextBox txt_ProjectPath;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btn_startTIA;
        private System.Windows.Forms.Button btn_disposeTIA;
        private System.Windows.Forms.RadioButton rdb_WithoutUI;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdb_WithUI;
    }
}

