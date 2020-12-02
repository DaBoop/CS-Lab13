using System;
using System.Linq;
namespace Lab13
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Console.WriteLine(OAADiskInfo.drivesInfo);
            var driveC = new OAADiskInfo("C");
            Console.WriteLine(driveC.Name + ": " + driveC.AvailableFreeSpace/(1024*1024) + "MB\t" + driveC.DriveFormat);

            var file = new OAAFileInfo("e:\\ООП\\Лабы\\CS-Lab-12-master\\bin\\Debug\\netcoreapp3.1\\IntListInfo.txt");
            Console.WriteLine($"{file.Name}\n\tPath: {file.Path}\n\tLength: {file.Length}\n\tExtension: {file.Extension}\n\tCreation/Edit time: {file.CreationTime}/{file.EditTime}");

            var dir = new OAADirInfo("e:\\ООП\\Лабы\\Lab10");
            Console.WriteLine($"{dir.Name}\n\tSubfolder count: {dir.SubfolderCount}\n\tParent folders:\n\t\t{string.Join("\n\t\t", dir.ParentFolders)}"); // Join сливает массив в строку

            var fileManager = new OAAFileManager("e");
            Console.WriteLine($"{fileManager.Name}\n\tElements:\n\t\t{string.Join("\n\t\t", fileManager.Elements)}");

            DateTime time = new DateTime(2020,12,3,0,0,0);

            Console.WriteLine("\n\t\t" + string.Join("\n\t\t", OAALog.FindByDay(time)));
            Console.WriteLine("\n\t\t" + string.Join("\n\t\t", OAALog.Find("Disk")));

            Console.WriteLine("Entry count in log file: " + OAALog.EntryCount);

            OAALog.RemoveOld();
        }
    }
}
