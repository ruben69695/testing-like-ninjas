using System;
using System.Net;

namespace MagicDarkLibraries.Installer
{
    public class InstallerHelper
    {
        private readonly IFileDownloader _fileDownloader;
        private readonly string _setupDestinationFile;
        
        public InstallerHelper(IFileDownloader fileDownloader, string setupDestinationFile)
        {
            _fileDownloader = fileDownloader;
            _setupDestinationFile = setupDestinationFile;
        }

        public bool DownloadInstaller(string customerName, string installerName)
        {
            if (string.IsNullOrWhiteSpace(customerName))
                throw new ArgumentNullException(nameof(customerName));
            if (string.IsNullOrWhiteSpace(installerName))
                throw new ArgumentNullException(nameof(installerName));
            
            string url = $"https://example.com/{customerName}/{installerName}";
            
            try
            {
                _fileDownloader.DownloadFile(url, _setupDestinationFile);             
                return true;
            }
            catch (WebException e)
            {
                // Log...
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}