using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Reflection;

namespace Lab13
{

    public static class OAALog
    {
        //List<string> list = new List<string>;
        private static string fileName = "OAAlogfie.txt";
        static OAALog() => File.WriteAllText(fileName, "");
        public static void Add(string message)
        {
            
            File.AppendAllText(fileName,System.DateTime.Now.ToString("dd.MM.yyyy hh:mm") + " " + message + "\n");
        }

    }

    public class OAADiskInfo
    {
        DriveInfo drive;
        public OAADiskInfo(string driveName)
        {
            MethodBase currentMethod = MethodBase.GetCurrentMethod();
            OAALog.Add(currentMethod.DeclaringType + " " + currentMethod.Name);
            drive = new DriveInfo(driveName);
        }

        public string Name 
        {
            get
            {
                MethodBase currentMethod = MethodBase.GetCurrentMethod();
                OAALog.Add(currentMethod.DeclaringType + " " + currentMethod.Name);
                return drive.Name;
            }
        }
        public long AvailableFreeSpace
        {
            get
            {
                MethodBase currentMethod = MethodBase.GetCurrentMethod();
                OAALog.Add(currentMethod.DeclaringType + " " + currentMethod.Name);
                return drive.AvailableFreeSpace;
            }
        }
        public string DriveFormat
        {
            get
            {
                MethodBase currentMethod = MethodBase.GetCurrentMethod();
                OAALog.Add(currentMethod.DeclaringType + " " + currentMethod.Name);
                return drive.DriveFormat;
            }
        }

        public static string drivesInfo 
        { 
            get
            {
                MethodBase currentMethod = MethodBase.GetCurrentMethod();
                OAALog.Add(currentMethod.DeclaringType + " " + currentMethod.Name);
                var allDrives = DriveInfo.GetDrives();
                string s = "";
                foreach (DriveInfo driveInstance in allDrives)
                {
                    s += $"{driveInstance.Name}\n\tTotal space: {driveInstance.TotalFreeSpace/(1024*1024)} MB\n\tFree Space: {driveInstance.AvailableFreeSpace/(1024 * 1024)} MB\n\tLabel: {driveInstance.VolumeLabel}\n";
                            
                }
                return s;
            }   
                    
        }

        



    }
    public class OAAFileInfo
    {
        FileInfo file;
        public OAAFileInfo(string fileName)
        {
            MethodBase currentMethod = MethodBase.GetCurrentMethod();
            OAALog.Add(currentMethod.DeclaringType + " " + currentMethod.Name);
            file = new FileInfo(fileName);
        }

        public string Name
        {
            get
            {
                MethodBase currentMethod = MethodBase.GetCurrentMethod();
                OAALog.Add(currentMethod.DeclaringType + " " + currentMethod.Name);
                return file.Name;
            }
        }
        public string Path
        {
            get
            {
                MethodBase currentMethod = MethodBase.GetCurrentMethod();
                OAALog.Add(currentMethod.DeclaringType + " " + currentMethod.Name);
                return file.FullName;
            }
        }
        public string Extension
        {
            get
            {
                MethodBase currentMethod = MethodBase.GetCurrentMethod();
                OAALog.Add(currentMethod.DeclaringType + " " + currentMethod.Name);
                return file.Extension;
            }
        }

        public long Length
        {
            get
            {
                MethodBase currentMethod = MethodBase.GetCurrentMethod();
                OAALog.Add(currentMethod.DeclaringType + " " + currentMethod.Name);
                return file.Length;
            }
        }

        public string CreationTime
        {
            get
            {
                MethodBase currentMethod = MethodBase.GetCurrentMethod();
                OAALog.Add(currentMethod.DeclaringType + " " + currentMethod.Name);
                return file.CreationTime.ToString("dd.MM.yyyy hh:mm");
            }
        }

        public string EditTime
        {
            get
            {
                MethodBase currentMethod = MethodBase.GetCurrentMethod();
                OAALog.Add(currentMethod.DeclaringType + " " + currentMethod.Name);
                return file.LastWriteTime.ToString("dd.MM.yyyy hh:mm");
            }
        }

    }
}


