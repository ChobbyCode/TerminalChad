using ConsoleUtils.Interaction;
using InstallerJazz.Models;
using InstallerJazz.Installer;

namespace InstallerJazz {
    public class AppPackager {

        public AppPackager(string[] externalArguments, InstallArguments installArguments) {
            Console.Title = installArguments.WindowName;
            List<string> appActions = new List<string>();
            if (installArguments.EnableInstallFeature) appActions.Add("Install");
            if (installArguments.EnableUninstallFeature) appActions.Add("Uninstall");
            if (installArguments.EnableUpdateFeature) appActions.Add("Update");

            int option = 0;
            bool validOption = false;
            while (!validOption) {
                if (appActions.Count > 1) {
                    Console.WriteLine("Enter the corresponding value presented in the brackets:");
                    option = MultipleChoiceOption.AskOption(appActions, "Please select an install option: ");
                }
                if (option < 0 || option > appActions.Count) validOption = false;
                else validOption = true;
            }

            var changedPath = 0;
            if (installArguments.AllowUsersToChooseInstallDrive) { installArguments.TargetLocation = GetNewInstallPath(installArguments.TargetLocation); changedPath = 1; }
            if (!Directory.Exists(installArguments.TargetLocation)) {
                // Force safe to stop writing or corrupting sys files
                throw new ArgumentException("installArguments.TargetLocation does not exist!");
            }

            try {
                switch (appActions[option].ToLower()) {
                    case "install":
                        Console.WriteLine("Please Wait While The Application Installs");
                        AppInstaller appInstaller = new AppInstaller(installArguments);
                        break;
                    case "update":
                        Updater.AppUpdater appUpdater = new Updater.AppUpdater();
                        if(appUpdater.isUpdate(installArguments.VersionInfoURL, installArguments.AppVersion)) {
                            AppInstaller appUpdateInstaller = new AppInstaller(installArguments, true); 
                        }
                        break;
                    case "uninstall":
                        AppUninstaller appUninstaller = new AppUninstaller();
                        if(changedPath == 0) installArguments.TargetLocation = GetNewInstallPath(installArguments.TargetLocation);
                        appUninstaller.Uninstall(installArguments.TargetLocation, installArguments.TargetLocation);
                        break;
                }
                Console.WriteLine("Function Complete. You can now safely close this window by pressing the enter key on your keyboard!");
            }
            catch (Exception ex) {
                Console.WriteLine(ex.ToString());
                Console.WriteLine($"Please restart the application and try again under higher credentials. If it fails please make a support request/issue at '{installArguments.HelpURL}'");
                Console.ReadLine();
            } 

            Console.ReadLine();
        }

        private string GetNewInstallPath(string oldPath) {
            Console.WriteLine("Please Select An Install Drive From Below:");
            Console.WriteLine(@$"The Application Will Be Found On '[Drive]:{Path.Combine(@"\", oldPath)}'");
            Console.WriteLine(@"Note: 'If you are uninstalling, please select the drive that you have installed it on.'");
            Console.WriteLine();

            DriveInfo[] allDrives = DriveInfo.GetDrives();

            foreach (DriveInfo d in allDrives) {
                Console.WriteLine("Drive {0}", d.Name);
                if (d.IsReady == true) {
                    Console.WriteLine(
                        "  Available space to current user:{0, 15} bytes",
                        d.AvailableFreeSpace);

                    Console.WriteLine(
                        "  Total available space:          {0, 15} bytes",
                        d.TotalFreeSpace);

                    Console.WriteLine(
                        "  Total size of drive:            {0, 15} bytes ",
                        d.TotalSize);
                }
            }

            bool correct = false;
            string drive = "";

            while (!correct) {
                Console.WriteLine();
                Console.Write("Drive (Enter The Letter, i.e. 'C', 'D', 'E'): ");
                drive = Console.ReadLine();
                if (string.IsNullOrEmpty(drive) || drive.Length > 1 || drive.Length == 0) continue;
                else if (Directory.Exists($@"{drive[0]}:\")) {
                    Console.WriteLine($@"The application will install to: '{drive.ToUpper()}:\{oldPath}'");
                    Console.Write($@"Is '{drive.ToUpper()}:\' correct? (y/n): ");
                    var res = Console.ReadLine();
                    if (res.ToLower() == "y") {
                        correct = true;
                    }
                } 
            }

            // Build a proper root like "C:\"
            var driveLetter = drive[0].ToString().ToUpper();
            var root = driveLetter + @":\";

            // Remove any leading slashes from oldPath so Path.Combine doesn't treat it as rooted
            var trimmedOld = (oldPath ?? string.Empty).TrimStart(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);

            // If nothing remains, return the drive root, otherwise combine
            var newPath = string.IsNullOrEmpty(trimmedOld) ? root : Path.Combine(root, trimmedOld);

            return newPath;
        }
    }
}
