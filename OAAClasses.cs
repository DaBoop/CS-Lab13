using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Reflection;
using System.Linq;
using System.IO.Compression;

namespace Lab13
{

    public static class OAALog
    {
        //List<string> list = new List<string>;
        private static string fileName = "OAAlogfie.txt";

        public static int EntryCount
        {
            get
            {
                int result;
                using (var streamReader = new StreamReader(fileName))
                {
                    result = streamReader.ReadToEnd().Split('\n').Count();
                }
                return result;
            }
        }
            
            
        //static OAALog() => File.WriteAllText(fileName, "");
        public static void Add(string message)
        {   
            File.AppendAllText(fileName,System.DateTime.Now.ToString("dd.MM.yyyy HH:mm") + " " + message + "\n");
        }

        public static string[] FindByDay(DateTime time)
        {
            var result = new List<string>();
            var entries = new List<string>();
            string dateString;
            DateTime lowerInterval = time.AddDays(-1);
            using (var streamReader = new StreamReader(fileName))
            {
                entries = streamReader.ReadToEnd().Split('\n').ToList();
                foreach (var entry in entries)
                {
                    if (entry.Length > 0)
                    { 
                        dateString = entry.Substring(0,16);
                        DateTime entryDate = DateTime.Parse(dateString);
                        
                        //DEBUG PURPOSE ONLY
                        //  int later = entryDate.CompareTo(lowerInterval);
                        //  int earlier = entryDate.CompareTo(time);
                        //=====

                        if (entryDate.CompareTo(lowerInterval) >= 0 && entryDate.CompareTo(time) <= 0) 
                            result.Add(entry);
                    }
                }
            }

            return result.ToArray();
        }

        public static string[] Find(DateTime lowerInterval, DateTime higherInterval)
        {
            var result = new List<string>();
            var entries = new List<string>();
            string dateString;
            using (var streamReader = new StreamReader(fileName))
            {
                entries = streamReader.ReadToEnd().Split('\n').ToList();
                foreach (var entry in entries)
                {
                    if (entry.Length > 0)
                    {
                        dateString = entry.Substring(0, 16);
                        DateTime entryDate = DateTime.Parse(dateString);

                        //DEBUG PURPOSE ONLY
                        //  int later = entryDate.CompareTo(lowerInterval);
                        //  int earlier = entryDate.CompareTo(time);
                        //=====

                        if (entryDate.CompareTo(lowerInterval) >= 0 && entryDate.CompareTo(higherInterval) <= 0)
                            result.Add(entry);
                    }
                }
            }

            return result.ToArray();
        }
        public static string[] Find(string keyword)
        {
            var result = new List<string>();
            var entries = new List<string>();
            string dateString;
            using (var streamReader = new StreamReader(fileName))
            {
                entries = streamReader.ReadToEnd().Split('\n').ToList();
                foreach (var entry in entries)
                {
                    if (entry.Length > 0 && entry.Contains(keyword))
                    {
                            result.Add(entry);
                    }
                }
            }

            return result.ToArray();
        }

        public static void RemoveOld() // Deletes entries older than 1 hour
        {
            var currentTime = System.DateTime.Now;
            var lowerInterval = currentTime.AddHours(-1);
            var entryList = Find(lowerInterval, currentTime);
            File.WriteAllText(fileName, "");
            File.AppendAllLines(fileName, entryList);
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
    public class OAADirInfo
    {
        DirectoryInfo dir;
        public OAADirInfo(string dirName)
        {
            MethodBase currentMethod = MethodBase.GetCurrentMethod();
            OAALog.Add(currentMethod.DeclaringType + " " + currentMethod.Name);
            dir = new DirectoryInfo(dirName);
        }

        public string Name
        {
            get
            {
                MethodBase currentMethod = MethodBase.GetCurrentMethod();
                OAALog.Add(currentMethod.DeclaringType + " " + currentMethod.Name);
                return dir.Name;
            }
        }
        public string CreationTime
        {
            get
            {
                MethodBase currentMethod = MethodBase.GetCurrentMethod();
                OAALog.Add(currentMethod.DeclaringType + " " + currentMethod.Name);
                return dir.CreationTime.ToString("dd.MM.yyyy hh:mm");
            }
        }
        public int SubfolderCount
        {
            get
            {
                MethodBase currentMethod = MethodBase.GetCurrentMethod();
                OAALog.Add(currentMethod.DeclaringType + " " + currentMethod.Name);
            

                return dir.GetDirectories().Count();
            }
        }

        public string[] ParentFolders
        {
            get
            {
                MethodBase currentMethod = MethodBase.GetCurrentMethod();
                OAALog.Add(currentMethod.DeclaringType + " " + currentMethod.Name);
                var s = new List<string>();

                DirectoryInfo curDir = dir;
                while(curDir.Parent != null)
                {
                    curDir = curDir.Parent;
                    s.Add(curDir.Name);
                }
                
                return s.ToArray();
            }

        }
    }
    public class OAAFileManager
    {
        DriveInfo drive;
        DirectoryInfo root;
        public OAAFileManager(string driveName)
        {
            MethodBase currentMethod = MethodBase.GetCurrentMethod();
            OAALog.Add(currentMethod.DeclaringType + " " + currentMethod.Name);
            drive = new DriveInfo(driveName);
            root = drive.RootDirectory;
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
        public string[] Elements
        {
            get
            {
                MethodBase currentMethod = MethodBase.GetCurrentMethod();
                OAALog.Add(currentMethod.DeclaringType + " " + currentMethod.Name);

                var elements = root.GetFiles().Select(x => "[file]" + x.Name).Concat(root.GetDirectories().Select(x => "[folder]" + x.Name)).ToArray();
                var subfolder = Directory.CreateDirectory(root.FullName + "OAAFiles");
                using (var file = File.CreateText(Path.Combine(subfolder.FullName, "\\OAAdirinfo.txt")))
                {
                    file.Write(string.Join("\n", elements));
                }

                var file2 = new FileInfo(Path.Combine(subfolder.FullName, "\\OAAdirInfo.txt"));

                //string s = subfolder.FullName + "\\OAAdiskinfo.txt";
                file2.CopyTo(subfolder.FullName + "\\OAAdiskinfo.txt",true);
                file2.Delete();

                var subfolder2 = Directory.CreateDirectory(root.FullName + "OAAInspect");

                var files = subfolder.GetFiles("*.txt");
                foreach (var file in files)
                {
                    file.CopyTo(Path.Combine(subfolder2.FullName, file.Name), true);
                }

                files = subfolder.GetFiles("*");
                foreach (var file in files)
                {
                    file.CopyTo(Path.Combine(subfolder2.FullName, file.Name), true);
                }

                try
                {
                    Directory.GetFiles(Path.Combine(subfolder.FullName, subfolder2.Name)).ToList().ForEach(File.Delete);
                    Directory.Delete(Path.Combine(subfolder.FullName, subfolder2.Name));

                } catch(Exception){};
                subfolder2.MoveTo(Path.Combine(subfolder.FullName, subfolder2.Name));

                try
                {
                    File.Delete(Path.Combine(root.FullName, "archive.zip"));
                }
                catch (Exception) { };
                ZipFile.CreateFromDirectory(subfolder2.FullName, Path.Combine(root.FullName, "archive.zip"));
                
                try
                {
                    Directory.GetFiles(Path.Combine(subfolder.FullName, "Extracted")).ToList().ForEach(File.Delete);
                    File.Delete(Path.Combine(subfolder.FullName, "Extracted"));
                }
                catch (Exception) { };
                ZipFile.ExtractToDirectory(Path.Combine(root.FullName, "archive.zip"), Path.Combine(subfolder.FullName, "Extracted"));

                       


                return elements;
            }
        }
    }
}


