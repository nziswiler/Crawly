namespace Crawly.Core.Services
{
    public interface IDownloadService
    {
        void DownloadPage(string url, string location);
    }
}
