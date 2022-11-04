using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace Sensor_GUI.Helper
{
    public class SerialPortInfo
    {
        public SerialPortInfo(ManagementObject property)
        {
            Availability = property.GetPropertyValue("Availability") as int? ?? 0;
            Caption = property.GetPropertyValue("Caption") as string ?? string.Empty;
            ClassGuid = property.GetPropertyValue("ClassGuid") as string ?? string.Empty;
            CompatibleID = property.GetPropertyValue("CompatibleID") as string[] ?? new string[] { };
            ConfigManagerErrorCode = property.GetPropertyValue("ConfigManagerErrorCode") as int? ?? 0;
            ConfigManagerUserConfig = property.GetPropertyValue("ConfigManagerUserConfig") as bool? ?? false;
            CreationClassName = property.GetPropertyValue("CreationClassName") as string ?? string.Empty;
            Description = property.GetPropertyValue("Description") as string ?? string.Empty;
            DeviceID = property.GetPropertyValue("DeviceID") as string ?? string.Empty;
            ErrorCleared = property.GetPropertyValue("ErrorCleared") as bool? ?? false;
            ErrorDescription = property.GetPropertyValue("ErrorDescription") as string ?? string.Empty;
            HardwareID = property.GetPropertyValue("HardwareID") as string[] ?? new string[] { };
            InstallDate = property.GetPropertyValue("InstallDate") as DateTime? ?? DateTime.MinValue;
            LastErrorCode = property.GetPropertyValue("LastErrorCode") as int? ?? 0;
            Manufacturer = property.GetPropertyValue("Manufacturer") as string ?? string.Empty;
            Name = property.GetPropertyValue("Name") as string ?? string.Empty;
            PNPClass = property.GetPropertyValue("PNPClass") as string ?? string.Empty;
            PNPDeviceID = property.GetPropertyValue("PNPDeviceID") as string ?? string.Empty;
            PowerManagementCapabilities = property.GetPropertyValue("PowerManagementCapabilities") as int[] ?? new int[] { };
            PowerManagementSupported = property.GetPropertyValue("PowerManagementSupported") as bool? ?? false;
            Present = property.GetPropertyValue("Present") as bool? ?? false;
            Service = property.GetPropertyValue("Service") as string ?? string.Empty;
            Status = property.GetPropertyValue("Status") as string ?? string.Empty;
            StatusInfo = property.GetPropertyValue("StatusInfo") as int? ?? 0;
            SystemCreationClassName = property.GetPropertyValue("SystemCreationClassName") as string ?? string.Empty;
            SystemName = property.GetPropertyValue("SystemName") as string ?? string.Empty;

        }

        public int Availability;
        public string Caption;
        public string ClassGuid;
        public string[] CompatibleID;
        public int ConfigManagerErrorCode;
        public bool ConfigManagerUserConfig;
        public string CreationClassName;
        public string Description;
        public string DeviceID;
        public bool ErrorCleared;
        public string ErrorDescription;
        public string[] HardwareID;
        public DateTime InstallDate;
        public int LastErrorCode;
        public string Manufacturer;
        public string Name;
        public string PNPClass;
        public string PNPDeviceID;
        public int[] PowerManagementCapabilities;
        public bool PowerManagementSupported;
        public bool Present;
        public string Service;
        public string Status;
        public int StatusInfo;
        public string SystemCreationClassName;
        public string SystemName;
        public string COMPort = "";

    }
}
