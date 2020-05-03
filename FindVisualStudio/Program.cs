using System;
using System.Diagnostics;
using System.IO;

namespace FindVisualStudio
{
    internal class Program
    {
        static string ProcessStart(string fileName, string args)
        {
            var processStartInfo = new ProcessStartInfo
            {
                Arguments = args,
                CreateNoWindow = true,
                FileName = fileName,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                WindowStyle = ProcessWindowStyle.Hidden,
                WorkingDirectory = Path.GetDirectoryName(fileName),
            };

            using (var process = Process.Start(processStartInfo))
            {
                process.WaitForExit();
                return process.StandardOutput.ReadToEnd().Trim();
            }
        }

        private static string GetInstallationPath(string vsWhere)
        {
            var installationPath = ProcessStart(vsWhere, "-latest -products * -requires Microsoft.Component.MSBuild -property installationPath");
            return installationPath;
        }

        private static string GetProductLineVersion(string vsWhere)
        {
            var version = ProcessStart(vsWhere, "-latest -property catalog_productLineVersion");
            return version;
        }


        private static void Main(string[] args)
        {
            var programFiles = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);
            var vsWhere = Path.Combine(programFiles, "Microsoft Visual Studio", "Installer", "vswhere.exe");
            if (!File.Exists(vsWhere))
            {
                throw new FileNotFoundException("Cannot find Microsoft Visual Studio's vswhere.exe utility.", vsWhere);
            }

            var version = GetProductLineVersion(vsWhere);
            Console.WriteLine($"Visual Studio Version: {version}");

            var installationPath = GetInstallationPath(vsWhere);
            if (!Directory.Exists(installationPath))
            {
                throw new DirectoryNotFoundException(installationPath);
            }

            Console.WriteLine($"Visual Studio installation Path: {installationPath}");

        }

    }
}