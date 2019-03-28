using System;
using System.Net;

namespace TrollLibraries.Installer
{
    public class InstallerHelper
    {
        private readonly string _setupDestinationFile;
        
        public InstallerHelper(string setupDestinationFile)
        {
            _setupDestinationFile = setupDestinationFile;
        }

        public bool DownloadInstaller(string customerName, string installerName)
        {
            try
            {
                var client = new WebClient();
                string address = $"https://example.com/{customerName}/{installerName}";
                client.DownloadFile(address, _setupDestinationFile);
                return true;
            }
            catch (WebException e)
            {
                // Log ...
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}