using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;

// Edited by Edwin S. Garcia

namespace UsingWMI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // Get System Information using WMI Calls

            this.textBox1.Text += GetAccount() + Environment.NewLine;
            this.textBox1.Text += Environment.NewLine;
            this.textBox1.Text += GetHardDisks();
            this.textBox1.Text += GetBoardMaker() + Environment.NewLine;
            this.textBox1.Text += GetBoardSerNo() + Environment.NewLine;
            this.textBox1.Text += GetBoardProductId() + Environment.NewLine;
            this.textBox1.Text += Environment.NewLine;
            this.textBox1.Text += GetCacheBlockSize() + Environment.NewLine;
            this.textBox1.Text += GetCacheType() + Environment.NewLine;
            this.textBox1.Text += GetCacheMaxSize() + Environment.NewLine;
            this.textBox1.Text += Environment.NewLine;
            this.textBox1.Text += GetCdRomDrive() + Environment.NewLine;
            this.textBox1.Text += Environment.NewLine;
            this.textBox1.Text += GetBIOSmaker() + Environment.NewLine;
            this.textBox1.Text += GetBIOScaption() + Environment.NewLine;
            this.textBox1.Text += GetBIOSserNo() + Environment.NewLine;
            this.textBox1.Text += Environment.NewLine;
            this.textBox1.Text += GetWinIconSpace() + Environment.NewLine;
            this.textBox1.Text += GetWinCursorBlinkRate() +
            Environment.NewLine;
            this.textBox1.Text += GetWinScreenSaverActive() +
            Environment.NewLine;
            this.textBox1.Text += GetWinCoolSwitch() + Environment.NewLine;
            this.textBox1.SelectionStart = textBox1.Text.Length;
        }

        public string GetHardDisks()
        {
            ManagementObjectSearcher searcher = new
            ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_LogicalDisk");
            StringBuilder sb = new StringBuilder();
            foreach (ManagementObject wmi in searcher.Get())
            {
                try
                {
                    sb.Append("Drive Device ID: " +
                    wmi.GetPropertyValue("DeviceID").ToString() + Environment.NewLine);
                    sb.Append("Caption: " + wmi.GetPropertyValue("Caption").ToString() + Environment.NewLine);
                    sb.Append("Volume Serial Number: " + wmi.GetPropertyValue("VolumeSerialNumber").ToString()
                    + Environment.NewLine);
                    sb.Append("Free Space: " + wmi.GetPropertyValue("FreeSpace").ToString() + "bytes free" + Environment.NewLine + Environment.NewLine);
                }
                catch
                {
                    return sb.ToString();
                }
            }
            return sb.ToString();
        }

        public string GetBoardMaker()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_BaseBoard"); 
            foreach (ManagementObject wmi in searcher.Get())
            {
                try
                {
                    return Environment.NewLine + "Board Maker: " + wmi.GetPropertyValue("Manufacturer").ToString();
                }
                catch { }
            }
            return "Board Maker: Unknown";
        }

        public string GetBoardSerNo()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_BaseBoard"); 
            foreach (ManagementObject wmi in searcher.Get())
            {
                try
                {
                    return "Serial Number: " + wmi.GetPropertyValue("SerialNumber").ToString();
                }
                catch { }
            }
            return "Serial Number: Unknown";
        }

        public string GetBoardProductId()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_BaseBoard"); 
            foreach (ManagementObject wmi in searcher.Get())
            {
                try
                {
                    return "Product: " + wmi.GetPropertyValue("Product").ToString();
                }
                catch { }
            }
            return "Product: Unknown";
        }

        public string GetCacheBlockSize()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_CacheMemory"); 
            foreach (ManagementObject wmi in searcher.Get())
            {
                try
                {
                    return "Cache Block Size: " + wmi.GetPropertyValue("BlockSize").ToString();
                }
                catch { }
            }
            return "Cache Block Size: Unknown";
        }

        public string GetCacheType()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_CacheMemory"); 
            foreach (ManagementObject wmi in searcher.Get())
            {
                try
                {
                    return "Cache Type: " + wmi.GetPropertyValue("CacheType").ToString();
                }
                catch { }
            }
            return "Cache Type: Unknown";
        }

        public string GetCacheMaxSize()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_CacheMemory"); 
            foreach (ManagementObject wmi in searcher.Get())
            {
                try
                {
                    return "Max Cache Size: " + wmi.GetPropertyValue("MaxCacheSize").ToString();
                }
                catch { }
            }
            return "Max Cache Size: Unknown";
        }

        public string GetCdRomDrive()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_CDROMDrive"); 
            foreach (ManagementObject wmi in searcher.Get())
            {
                try
                {
                    return "CD ROM Drive Letter: " + wmi.GetPropertyValue("Drive").ToString();
                }
                catch { }
            }
            return "CD ROM Drive Letter: Unknown";
        }

        public string GetAccount()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_UserAccount"); 
            foreach (ManagementObject wmi in searcher.Get())
            {
                try
                {
                    return "User Account Name: " + wmi.GetPropertyValue("Name").ToString();
                }
                catch { }
            }
            return "User Account Name: Unknown";
        }

        public string GetBIOScaption()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_BIOS"); 
            foreach (ManagementObject wmi in searcher.Get())
            {
                try
                {
                    return "BIOS Caption: " + wmi.GetPropertyValue("Caption").ToString();
                }
                catch { }
            }
            return "BIOS Caption: Unknown";
        }

        public string GetBIOSmaker()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_BIOS"); 
            foreach (ManagementObject wmi in searcher.Get())
            {
                try
                {
                    return "BIOS Maker: " + wmi.GetPropertyValue("Manufacturer").ToString();
                }
                catch { }
            }
            return "BIOS Maker: Unknown";
        }

        public string GetBIOSserNo()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_BIOS"); 
            foreach (ManagementObject wmi in searcher.Get())
            {
                try
                {
                    return "BIOS Serial Number: " + wmi.GetPropertyValue("SerialNumber").ToString();
                }
                catch { }
            }
            return "BIOS Serial Number: Unknown";
        }

        public string GetWinIconSpace()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Desktop"); 
            foreach (ManagementObject wmi in searcher.Get())
            {
                try
                {
                    return "Desktop Icon Spacing: " + wmi.GetPropertyValue("IconSpacing").ToString();
                }
                catch { }
            }
            return "Desktop Icon Spacing: Unknown";
        }

        public string GetWinCursorBlinkRate()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Desktop"); 
            foreach (ManagementObject wmi in searcher.Get())
            {
                try
                {
                    return "Cursor Blink Rate: " + wmi.GetPropertyValue("CursorBlinkRate").ToString();
                }
                catch { }
            }
            return "Cursor Blink Rate: Unknown";
        }

        public string GetWinScreenSaverActive()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Desktop"); 
            foreach (ManagementObject wmi in searcher.Get())
            {
                try
                {
                    return "Screen Saver Active: " + wmi.GetPropertyValue("ScreenSaverActive").ToString();
                }
                catch { }
            }
            return "Screen Saver Active: Unknown";
        }

        public string GetWinCoolSwitch()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Desktop"); 
            foreach (ManagementObject wmi in searcher.Get())
            {
                try
                {
                    return "CoolSwitch: " + wmi.GetPropertyValue("CoolSwitch").ToString();
                }
                catch { }
            }
            return "CoolSwitch: Unknown";
        }

    }
}
