using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using Siemens.Engineering;
using Siemens.Engineering.Compare;
using Siemens.Engineering.Compiler;
using Siemens.Engineering.Hmi;
using Siemens.Engineering.Hmi.Communication;
using Siemens.Engineering.Hmi.Cycle;
using Siemens.Engineering.Hmi.Globalization;
using Siemens.Engineering.Hmi.RuntimeScripting;
using Siemens.Engineering.Hmi.Screen;
using Siemens.Engineering.Hmi.Tag;
using Siemens.Engineering.Hmi.TextGraphicList;
using Siemens.Engineering.HW;
using Siemens.Engineering.HW.Features;
using Siemens.Engineering.Library;
using Siemens.Engineering.Library.MasterCopies;
using Siemens.Engineering.Library.Types;
using Siemens.Engineering.Online;
using Siemens.Engineering.SW;
using Siemens.Engineering.SW.Blocks;
using Siemens.Engineering.SW.ExternalSources;
using Siemens.Engineering.SW.Tags;
using Siemens.Engineering.SW.Types;
using Screen = Siemens.Engineering.Hmi.Screen.Screen;
using View = Siemens.Engineering.HW.View;

/// <summary>
/// 
/// </summary>
//namespace BikoetV0
//{
//    class MainWindowViewModel 
//    {
//        private void LoadProjectTreeView()
//        {
//            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Send, new Action(() =>
//            {
//                if (_tiaPortalProject == null)
//                {
//                    // check if a project was opened in the UI
//                    _tiaPortalProjects = _tiaPortal.Projects;
//                    _tiaPortalProject = _tiaPortalProjects.FirstOrDefault();
//                    ProjectOpened = _tiaPortalProject != null;
//                }

//                //Root of TreeView
//                var projectTreeView = new TreeView();

//                //Project TreeViewItem
//                var projectTreeViewItem = new TreeViewItem();

//                if (ProjectOpened)
//                {
//                    // ReSharper disable once PossibleNullReferenceException
//                    var splitPath = _tiaPortalProject.Path.ToString().Split('\\');
//                    _projectName = splitPath[splitPath.Length - 1];

//                    projectTreeViewItem.Header = _projectName;
//                    projectTreeViewItem.Tag = _tiaPortalProject;

//                    //expand Item
//                    projectTreeViewItem.ExpandSubtree();

//                    foreach (var device in _tiaPortalProject.Devices)
//                    {
//                        var item = CreateDeviceTreeViewItem(device);

//                        projectTreeViewItem.Items.Add(item);
//                    }

//                    foreach (var folder in _tiaPortalProject.DeviceGroups)
//                    {
//                        FolderCrawler(projectTreeViewItem, folder);
//                    }

//                    #region Multilingual graphics
//                    projectTreeViewItem.Items.Add(OpennessTreeViews.GetGraphicsTreeView(_tiaPortalProject));
//                    #endregion

//                    projectTreeView.Items.Add(projectTreeViewItem);
//                }
//                else
//                {
//                    projectTreeViewItem.Header = "TIA Portal without project connected";

//                    projectTreeView.Items.Add(projectTreeViewItem);
//                }
//                ProjectTree.Refresh(projectTreeView);
//            }));
//        }
//    }
//}
