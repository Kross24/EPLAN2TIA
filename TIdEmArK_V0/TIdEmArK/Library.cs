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
using System.Windows.Forms;
using System.Linq;
using System.Collections;

namespace TIdEmArK
{
    public class TiaLibraryHelper
    {        
        public void OpenGlobalLibrary(TiaPortal tiaportal, TextBox txt_box)
        {
            try
            {
                var availableLibraries = tiaportal.GlobalLibraries.GetGlobalLibraryInfos();
                foreach (GlobalLibraryInfo info in availableLibraries)
                {
                    txt_box.Text =
                        "Library Name: " + info.Name + Environment.NewLine +
                        "Library Path: " + info.Path + Environment.NewLine +
                        "Library Type: " + info.LibraryType + Environment.NewLine +
                        "Library IsOpen: " + info.IsOpen;                    
                }
                //Bibliotheken öffnen (funktioniert bisher nicht)

                //Bibliothek mittels System.IO.FileInfo öffnen
                FileInfo fileInfo = new FileInfo(@"D:\Program Files\Siemens\Automation\Portal V15\lib\Sys\Long Functions\Long Functions.as15");
                //GlobalLibrary userLib = tiaportal.GlobalLibraries.Open(fileInfo, OpenMode.ReadWrite);

                ////----------------------------------
                ////Bibliothek mittels GlobalLibraryInfo öffnen
                //IList<GlobalLibraryInfo> libraryInfos = tiaportal.GlobalLibraries.GetGlobalLibraryInfos();
                //GlobalLibraryInfo libInfo = libraryInfos[0]; //check for the info you need from the list, e.g.
                //GlobalLibrary libraryOpenedWithInfo;
                //if (libInfo.Name == "myLibrary")
                //    libraryOpenedWithInfo = tiaportal.GlobalLibraries.Open(libInfo);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

















    }//++
}//+
