// Copyright (c) 2024 ChobbyCode

using TerminalChad.Installer;
using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TerminalChad.Installer;

namespace TerminalChadInstaller
{
    public class FileDownloader
    {
        public bool DownloadFiles(string installLocation)
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;

            if (Directory.Exists(baseDir + @"\tmp\")) Directory.Delete(baseDir + @"\tmp\", true);
            if (Directory.Exists(baseDir + @"\Files\")) Directory.Delete(baseDir + @"\Files\", true);

            if (!Directory.Exists(baseDir + @"\tmp\")) Directory.CreateDirectory(baseDir + @"\tmp\");
            if (!Directory.Exists(baseDir + @"\tmp\zip")) Directory.CreateDirectory(baseDir + @"\tmp\zip");
            if (!Directory.Exists(baseDir + @"\tmp\dez")) Directory.CreateDirectory(baseDir + @"\tmp\dez");
            if (!Directory.Exists(baseDir + @"\Files\")) Directory.CreateDirectory(baseDir + @"\Files\");

            string path = "https://github.com/ChobbyCode/TerminalChad" + @"/zipball/InstallerFiles";
            if (Program.isBeta) path = "https://github.com/ChobbyCode/TerminalChad" + @"/zipball/BetaFiles";

            Console.WriteLine("Downloading Latest Version: ");
            Console.Write("Fetching Files From: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(path);
            Console.ForegroundColor = ConsoleColor.White;

            using (var client = new WebClient())
            {
                client.DownloadFile(path, baseDir + @"\tmp\zip\download.zip");
            }

            ZipFile.ExtractToDirectory(baseDir + @"\tmp\zip\download.zip", baseDir + @"\tmp\dez\");

            string DownloadLocation = Directory.GetDirectories(baseDir + @"\tmp\dez\")[0];
            DirectoryInfo source = new(DownloadLocation);
            DirectoryInfo target = new(installLocation);

            Console.Clear();

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Status  | File");
            Console.ForegroundColor = ConsoleColor.White;
            CopyFiles(source, target);

            return true;
        }


        private static void CopyFiles(DirectoryInfo source, DirectoryInfo target)
        {
            Directory.CreateDirectory(target.FullName);

            foreach (var file in source.GetFiles())
            {
                try
                {
                    file.CopyTo(Path.Combine(target.FullName, file.Name), true);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Success | {file.Name}");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Failed  | {file.Name}");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

            foreach (var sourceSubDirectory in source.GetDirectories())
            {
                var targetSubDirectory = target.CreateSubdirectory(sourceSubDirectory.Name);
                CopyFiles(sourceSubDirectory, targetSubDirectory);
            }
        }
    }
}