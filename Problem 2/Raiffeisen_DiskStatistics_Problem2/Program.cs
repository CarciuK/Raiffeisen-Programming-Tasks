using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Raiffeisen_DiskStatistics_Problem2
{
    public class Program
    {
   
        static void Main(string[] args)
        {
            do { 
            Console.WriteLine("Enter the directory path to scan: ");
            string folderPath = Console.ReadLine();

            if (Directory.Exists(folderPath))
            {
                Console.WriteLine("Scanning directory '{0}'...", folderPath);
                long folderSize = ScanFolder(folderPath);
                Console.WriteLine("Folder stats are found: path='{0}', size={1}", folderPath, FormatSize(folderSize));
            }
            else
            {
                Console.WriteLine("Invalid directory path.");
            }

                Console.Write("Do you want to add another directory path? (yes/no)");
            } while (Console.ReadLine().ToLower() == "yes");

            Console.WriteLine("Scannig complete!\n-You can exit by typing any key.");
            Console.ReadKey();
           
        }

        static long ScanFolder(string folderPath)
        {
            long folderSize = 0;

            try
            {
                string[] files = Directory.GetFiles(folderPath);
                Parallel.ForEach(files, (file) =>
                {
                    FileInfo fileInfo = new FileInfo(file);
                    long fileSize = fileInfo.Length;
                    folderSize += fileSize;
                    Console.WriteLine("{0} - {1}", fileInfo.DirectoryName, FormatSize(fileSize));
                });

                string[] subFolders = Directory.GetDirectories(folderPath);
                Parallel.ForEach(subFolders, (subFolder) =>
                {
                    long subFolderSize = ScanFolder(subFolder);
                    folderSize += subFolderSize;
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error scanning folder '{0}': {1}", folderPath, ex.Message);
            }

            return folderSize;
        }

        static string FormatSize(long size)
        {
            if (size < 1024)
            {
                return string.Format("{0} bytes", size);
            }
            else if (size < 1024 * 1024)
            {
                return string.Format("{0:F2} KB", size / 1024.0);
            }
            else if (size < 1024 * 1024 * 1024)
            {
                return string.Format("{0:F2} MB", size / (1024.0 * 1024));
            }
            else
            {
                return string.Format("{0:F2} GB", size / (1024.0 * 1024 * 1024));
            }
        }
     

     

    }
}
