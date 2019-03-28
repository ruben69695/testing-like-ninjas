namespace MagicDarkLibraries.Installer
{
    public interface IFileDownloader
    {
        void DownloadFile(string url, string fileName);
    }
}