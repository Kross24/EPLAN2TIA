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
using System.Collections;
using System.Collections.ObjectModel;

namespace TIdEmArK
{
    public class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            AppDomain.CurrentDomain.AssemblyResolve += MyResolver;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());                       
        }
        //DebugHilfe ----- nur kopieren!!!!
        //using (StreamWriter writer = File.AppendText(@"C:\Users\benjamin.kross\Desktop\WriteLines.txt"))
        //{
        //  writer.WriteLine(node1.Name + "Node1 (Device)"+Environment.NewLine);
        //}

#region Assembly Resolve (TIA Pfad DDLs)
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
        #endregion

        #region Statusabfrage Projekt geöffnet
        public bool CurrentProject(TiaPortalProcess tiaProcess, TiaPortal _MyTiaPortal, Project _MyProject)
        {
            bool ProjectStatus;
            IList<TiaPortalProcess> processes = TiaPortal.GetProcesses();
            switch (processes.Count)
            {
                case 1:
                    tiaProcess = processes[0];
                    _MyTiaPortal = tiaProcess.Attach();

                    if (_MyTiaPortal.Projects.Count <= 0)
                    {
                        ProjectStatus = false;
                        return ProjectStatus;
                    }
                    _MyProject = _MyTiaPortal.Projects[0];
                    ProjectStatus = true;                    
                    break;

                case 0:
                    ProjectStatus = false;
                    return ProjectStatus;

                default:
                    ProjectStatus = false;
                    return ProjectStatus;
            }
            return ProjectStatus;
        }
        #endregion
    }
}