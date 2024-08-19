using System.Net;
using System.Diagnostics;
using System;
using System.IO;

namespace SJPKG
{
    class Pkgman
    {
        static void Main(string[] args)
        {
            string server = File.ReadAllText(@".\server.txt");
            string command = args[0];
            string filename = args[1];
            string file = $"{filename}.bat";
            var path = Path.Combine("Installers", file);
            switch (command.ToLower())
            {
                case "install":
                    Console.WriteLine($"Installing {filename}...");
                    DirectoryInfo di = Directory.CreateDirectory(@"Installers");
                    WebClient webClient = new WebClient();
                    webClient.DownloadFile(server + file, path);
                    Process.Start($@"Installers\{file}");
                    break;

                case "delete":
                    File.Delete(path);
                    break;

                default:
                    Console.WriteLine("Unknown command.");
                    break;
            }
        }

    }
}
