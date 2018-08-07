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
    class EnumerateDevices
    {
        List<Device> checkedDevices = new List<Device>();
        List<DeviceItem> checkedDeviceItems = new List<DeviceItem>();


        /// <summary>
        /// Nutzen Sie diese Methode, um alle TIA Devices in eine Liste<Device> zu schreiben
        /// </summary>
        /// <param name="project"></param>
        /// <returns></returns>
        public void EnumerateDevice(Project project, List<Device> list_device)
        {
            list_device.Clear(); //Alte Elemente löschen
            foreach (Device device in project.Devices)
            {
                list_device.Add(device);
            }            
        }
        /// <summary>
        /// Nutzen Sie diese Methode, um alle TIA DeviceItems in eine Liste<DeviceItem> zu schreiben
        /// </summary>
        /// <param name="project"></param>
        /// <returns></returns>
        public void EnumerateDeviceItem(Project project, List<DeviceItem> list_deviceItem)
        {
            list_deviceItem.Clear(); //Alte Elemente löschen
            foreach (Device device in project.Devices)
            {
                DeviceItemComposition deviceItemAggregation = device.DeviceItems;
                foreach (DeviceItem deviceItem in deviceItemAggregation)
                {
                    list_deviceItem.Add(deviceItem);
                }
            }
        }
    }
}

