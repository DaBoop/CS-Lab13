using System;

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
        }
    }
}
