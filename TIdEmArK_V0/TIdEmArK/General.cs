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
    public partial class OpennessHelper
    {

        //Adds an AssemblResolve for Siemens.Engineering.dll and Siemens.Engineering.HMI.dll
        public static void AssemblyResolve()
        {
            throw new NotImplementedException("Use TiaOpennessHelper.Utils.Resolver instead.");
        }
        
        // Searches the project for a PlcSoftware with the given name.
        // <param name="project">Opened TIA project</param>
        // <param name="controllerName">name to search for</param>
        // <returns>Reference to found PlcSoftware</returns>
        public static PlcSoftware FindPlcSoftwareByName(Project project, string controllerName)
        {
            if (project == null)
                throw new ArgumentNullException(nameof(project), "Parameter is null");
            if (string.IsNullOrEmpty(controllerName))
                throw new ArgumentException("Parameter is null or empty", nameof(controllerName));

            foreach (var device in project.Devices)
            {
                var target = GetPlcSoftware(device);
                if (target != null && target.Name == controllerName)
                    return target;
            }
            return null;
        }

        /// <summary>Searches the project for a HmiTarget with given name.</summary>
        /// <param name="project">opened TIA project</param>
        /// <param name="hmiName">name to search for</param>
        /// <returns>Reference to found HmiTarget</returns>
        /// <exception cref="System.ArgumentNullException">Parameter is null;project</exception>
        /// <exception cref="System.ArgumentException">Parameter is null or empty;hmiName</exception>
        /// <exception cref="ArgumentNullException">Parameter is null;project</exception>
        /// <exception cref="ArgumentException">Parameter is null or empty;hmiName</exception>
        public static HmiTarget FindHmiTargetByName(Project project, string hmiName)
        {
            if (project == null)
                throw new ArgumentNullException(nameof(project), "Parameter is null");
            if (string.IsNullOrEmpty(hmiName))
                throw new ArgumentException("Parameter is null or empty", nameof(hmiName));

            foreach (var device in project.Devices)
            {
                //if (device.Subtype.Equals("Sinamics.Device"))
                //    continue;

                if (device.Name == hmiName)
                {
                    foreach (var devItem in device.DeviceItems)
                    {
                        var target = ((IEngineeringServiceProvider)devItem).GetService<SoftwareContainer>();
                        if (target != null && target.Software is HmiTarget)
                            return target.Software as HmiTarget;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Returns IEnumerable Collection of all PlcSoftwares and HmiTargets in project
        /// </summary>
        /// <param name="project">The project.</param>
        /// <returns>IEnumerable&lt;IDeviceItem&gt;</returns>
        /// <exception cref="System.ArgumentNullException">Parameter is null;project</exception>
        /// <exception cref="ArgumentNullException">Parameter is null;project</exception>
        public static IEnumerable<Software> GetAllTargets(Project project)
        {
            if (project == null)
                throw new ArgumentNullException(nameof(project), "Parameter is null");

            foreach (var device in project.Devices)
            {
                //if (device.Subtype.Equals("Sinamics.Device"))
                //    continue;

                foreach (var devItem in device.DeviceItems)
                {
                    var target = ((IEngineeringServiceProvider)devItem).GetService<SoftwareContainer>();
                    if (target != null)
                        yield return target.Software;
                }
            }
        }

        /// <summary>
        /// Returns IEnumerable Collection of PlcSoftwares in project
        /// </summary>
        /// <param name="project">The project.</param>
        /// <returns>IEnumerable&lt;PlcSoftware&gt;</returns>
        /// <exception cref="System.ArgumentNullException">Parameter is null;project</exception>
        /// <exception cref="ArgumentNullException">Parameter is null;project</exception>
        public static IEnumerable<PlcSoftware> GetAllPlcSoftwares(Project project)
        {
            if (project == null)
                throw new ArgumentNullException(nameof(project), "Parameter is null");

            foreach (var device in project.Devices)
            {
                var ret = GetPlcSoftware(device);
                if (ret != null)
                    yield return ret;
            }
        }

        /// <summary>Returns IEnumerable Collection of HmiTargets in project</summary>
        /// <param name="project">The project.</param>
        /// <returns>IEnumerable&lt;HmiTarget&gt;</returns>
        /// <exception cref="System.ArgumentNullException">Parameter is null;project</exception>
        /// <exception cref="ArgumentNullException">Parameter is null;project</exception>
        public static IEnumerable<HmiTarget> GetAllHmiTargets(Project project)
        {
            if (project == null)
                throw new ArgumentNullException(nameof(project), "Parameter is null");

            foreach (var device in project.Devices)
            {
                //if (device.Subtype.Equals("Sinamics.Device"))
                //    continue;

                foreach (var devItem in device.DeviceItems)
                {
                    var target = ((IEngineeringServiceProvider)devItem).GetService<SoftwareContainer>();
                    if (target != null && target.Software is HmiTarget)
                    {
                        yield return (HmiTarget)target.Software;
                    }
                }
            }
        }

        /// <summary>Returns the PlcSoftware representing the device or null.</summary>
        /// <param name="device">The device.</param>
        /// <returns>PlcSoftware</returns>
        /// <exception cref="System.ArgumentNullException">Parameter is null;device</exception>
        /// <exception cref="ArgumentNullException">Parameter is null;device</exception>
        public static PlcSoftware GetPlcSoftware(Device device)
        {
            if (device == null)
                throw new ArgumentNullException(nameof(device), "Parameter is null");
            //if (device.Subtype.ToLower().Contains("sinamics"))
            //    return null;

            foreach (var devItem in device.DeviceItems)
            {
                var target = ((IEngineeringServiceProvider)devItem).GetService<SoftwareContainer>();
                if (target != null && target.Software is PlcSoftware)
                {
                    return (PlcSoftware)target.Software;
                }
            }

            return null;
        }

        /// <summary>Returns the HmiTarget representing the device or null.</summary>
        /// <param name="device">The device.</param>
        /// <returns>HmiTarget</returns>
        /// <exception cref="System.ArgumentNullException">Parameter is null;device</exception>
        /// <exception cref="ArgumentNullException">Parameter is null;device</exception>
        public static HmiTarget GetHmiTarget(Device device)
        {
            if (device == null)
                throw new ArgumentNullException(nameof(device), "Parameter is null");
            //if (device.Subtype.ToLower().Contains("sinamics"))
            //    return null;

            foreach (var devItem in device.DeviceItems)
            {
                var target = ((IEngineeringServiceProvider)devItem).GetService<SoftwareContainer>();
                if (target != null && target.Software is HmiTarget)
                {
                    return (HmiTarget)target.Software;
                }
            }

            return null;
        }

        /// <summary>Returns the name of the IEngineeringInstance</summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        public static string GetObjectName(IEngineeringInstance item)
        {
            var itemName = "";
            if (item == null)
                return itemName;
            try
            {
                itemName = ((IEngineeringObject)item).GetAttribute("Name") as string;
            }
            catch (Exception)
            {
                // ignored
            }

            if (string.IsNullOrEmpty(itemName))
            {
                if (item is CycleComposition)
                    itemName = "Cycles";
                else if (item is ConnectionComposition)
                    itemName = "Connections";
                else if (item is MasterCopySystemFolder)
                    itemName = "Master copies";
                else if (item is MultiLingualGraphicComposition)
                    itemName = "Mulilingual graphics";
                else if (item is ScreenOverview)
                    itemName = "ScreenOverview";
                else if (item is GraphicListComposition)
                    itemName = "GraphicLists";
                else if (item is TextListComposition)
                    itemName = "TextLists";
                else if (item is ScreenGlobalElements)
                    itemName = "ScreenGlobalElements";
                else if (item is PlcSystemBlockGroupComposition)
                    itemName = "SystemBlocks";
            }

            return itemName;
        }

        /// <summary>Recursively searches for a object with given namen in folder</summary>
        /// <param name="folder">The folder.</param>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        private static object RecursiveFindElementByName(object folder, string name)
        {
            foreach (var item in GetSubItem(folder))
                if (GetObjectName(item as IEngineeringInstance) == name)
                    return item;

            object ret;
            foreach (var subfolder in GetSubFolder(folder))
                if (GetObjectName((ret = RecursiveFindElementByName(subfolder, name)) as IEngineeringInstance) == name)
                    return ret;

            return null;
        }

        /// <summary>
        /// Recursively gathers all subitems and folder in the provided folder
        /// </summary>
        /// <param name="folder">The folder.</param>
        /// <param name="collection">The collection.</param>
        private static void RecursiveGetAllElements(object folder, ref Collection<object> collection)
        {
            foreach (var item in GetSubItem(folder))
                collection.Add(item);

            foreach (var subfolder in GetSubFolder(folder))
                RecursiveGetAllElements(subfolder, ref collection);
        }

        /// <summary>Returns a IEnumerable of all subitems of item</summary>
        /// <param name="item">The item.</param>
        /// <returns>IEnumerable&lt;object&gt;</returns>
        public static IEnumerable<object> GetSubItem(object item)
        {
            object subItem = null;
            if (item != null)
            {
                if (item is Project)
                {
                    subItem = new Collection<object>();
                    foreach (var device in (item as Project).Devices)
                        (subItem as Collection<object>).Add(device);
                    (subItem as Collection<object>).Add((item as Project).Graphics);
                }
                else if (item is DeviceUserGroup)
                    subItem = (item as DeviceUserGroup).Devices;
                else if (item is PlcSoftware)
                    subItem = new Collection<object>();
                else if (item is HmiTarget)
                    subItem = new Collection<object>();
                else if (item is Device)
                    subItem = (item as Device).Items;
                else if (item is DeviceItem)
                    subItem = (item as DeviceItem).Items;
                else if (item is PlcBlockGroup)
                    subItem = (item as PlcBlockGroup).Blocks;
                else if (item is PlcSystemBlockGroupComposition)
                    subItem = new Collection<object>();
                else if (item is PlcTagTableGroup)
                    subItem = (item as PlcTagTableGroup).TagTables;
                else if (item is PlcTypeGroup)
                    subItem = (item as PlcTypeGroup).Types;
                else if (item is PlcExternalSourceGroup)
                    subItem = (item as PlcExternalSourceGroup).ExternalSources;
                else if (item is TagFolder)
                    subItem = (item as TagFolder).TagTables;
                else if (item is ScreenFolder)
                    subItem = (item as ScreenFolder).Screens;
                else if (item is ScreenTemplateFolder)
                    subItem = (item as ScreenTemplateFolder).ScreenTemplates;
                else if (item is VBScriptFolder)
                    subItem = (item as VBScriptFolder).VBScripts;
                else if (item is MultiLingualGraphicComposition)
                    subItem = item;
                else if (item is TagTable)
                    subItem = (item as TagTable).Tags;
                else if (item is IEngineeringComposition)
                    subItem = item;
                else if (item is ProjectLibrary)
                    subItem = new Collection<object>();
                else if (item is MasterCopyFolder)
                    subItem = (item as MasterCopyFolder).MasterCopies;
                else if (item is LibraryTypeFolder)
                    subItem = (item as LibraryTypeFolder).Types;
                else
                {
                    subItem = new Collection<object>();
                }
            }

            return subItem as IEnumerable<object>;
        }

        /// <summary>Returns a IEnumerbale of all subfolder of item</summary>
        /// <param name="item">The item.</param>
        /// <returns>IEnumerable&lt;object&gt;</returns>
        public static IEnumerable<object> GetSubFolder(object item)
        {
            object subFolder;

            if (item is PlcSoftware)
            {
                var sw = item as PlcSoftware;
                var col = new Collection<object>();
                col.Add(sw.BlockGroup);
                col.Add(sw.TagTableGroup);
                col.Add(sw.TypeGroup);
                col.Add(sw.ExternalSourceGroup);
                subFolder = col;
            }
            else if (item is HmiTarget)
            {
                var target = item as HmiTarget;
                var col = new Collection<object>();
                col.Add(target.ScreenFolder);
                col.Add(target.ScreenTemplateFolder);
                col.Add(target.TagFolder);
                col.Add(target.Connections);
                col.Add(target.VBScriptFolder);
                col.Add(target.Cycles);
                subFolder = col;
            }
            else if (item is Device)
                subFolder = new Collection<object>();
            else if (item is DeviceItem)
                subFolder = new Collection<object>();
            else if (item is PlcBlockSystemGroup)
            {
                var col = new Collection<object>();
                var group = item as PlcBlockSystemGroup;
                foreach (var element in group.Groups)
                {
                    col.Add(element);
                }
                if ((item as PlcBlockSystemGroup).SystemBlockGroups != null)
                    col.Add(group.SystemBlockGroups);
                subFolder = col;
            }
            else if (item is PlcBlockGroup)
                subFolder = (item as PlcBlockGroup).Groups;
            else if (item is PlcSystemBlockGroupComposition)
            {
                var col = new Collection<object>();
                var group = item as PlcSystemBlockGroupComposition;
                foreach (var element in group)
                {
                    col.Add(element);
                }
                subFolder = col;
            }
            else if (item is PlcSystemBlockGroup)
                subFolder = (item as PlcSystemBlockGroup).Groups;
            else if (item is TagFolder)
                subFolder = (item as TagFolder).Folders;
            else if (item is PlcTagTableGroup)
                subFolder = (item as PlcTagTableGroup).Groups;
            else if (item is PlcTypeGroup)
                subFolder = (item as PlcTypeGroup).Groups;
            else if (item is VBScriptFolder)
                subFolder = (item as VBScriptFolder).Folders;
            else if (item is ScreenFolder)
                subFolder = (item as ScreenFolder).Folders;
            else if (item is ScreenTemplateFolder)
                subFolder = (item as ScreenTemplateFolder).Folders;
            else if (item is ProjectLibrary)
                subFolder = (item as ProjectLibrary).MasterCopyFolder.Folders;
            else if (item is TagTable)
                subFolder = (item as TagTable).Tags;
            else if (item is LibraryTypeFolder)
                subFolder = (item as LibraryTypeFolder).Folders;
            else if (item is MasterCopyFolder)
                subFolder = (item as MasterCopyFolder).Folders;
            else if (item is DeviceUserGroup)
                subFolder = item;
            else if (item is Project)
            {
                subFolder = new Collection<object>();
                //foreach (object obj in GetAllTargets(item))
                //    subFolder.Add(obj);
                foreach (var folder in (item as Project).DeviceGroups)
                    (subFolder as Collection<object>).Add(folder);
            }
            else
            {
                subFolder = new Collection<object>();
            }

            return subFolder as IEnumerable<object>;
        }

        /// <summary>Returns the folder with the given namen under target</summary>
        /// <param name="target">The target.</param>
        /// <param name="folderName">Name of the folder.</param>
        /// <returns></returns>
        private static object GetFolderByName(object target, string folderName)
        {
            object folder = null;

            if (target is PlcSoftware)
            {
                switch (folderName)
                {
                    case "Program blocks":
                        folder = (target as PlcSoftware).BlockGroup;
                        break;
                    case "External source files":
                        folder = (target as PlcSoftware).ExternalSourceGroup;
                        break;
                    case "PLC tags":
                        folder = (target as PlcSoftware).TagTableGroup;
                        break;
                    case "PLC data types":
                        folder = (target as PlcSoftware).TypeGroup;
                        break;
                }
            }
            else if (target is HmiTarget)
            {
                switch (folderName)
                {
                    case "HMI tags":
                        folder = (target as HmiTarget).TagFolder;
                        break;
                    case "Screens":
                        folder = (target as HmiTarget).ScreenFolder;
                        break;
                    case "Cycles":
                        folder = (target as HmiTarget).Cycles;
                        break;
                    case "Scripts":
                        folder = (target as HmiTarget).VBScriptFolder;
                        break;
                }
            }
            else if (target is Project)
            {
                foreach (var item in GetAllTargets(target as Project))
                {
                    if (item.Name == folderName)
                    {
                        return item;
                    }
                }
            }

            return folder;
        }
    }
}
