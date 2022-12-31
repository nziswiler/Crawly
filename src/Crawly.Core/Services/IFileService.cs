namespace Crawly.Core.Services
{
    public interface IFileService
    {
        void SaveFileFromHtmlString(string html, string location);
        
        void DownloadImage(string url, string location);

        void DownloadStylesheet(string url, string location);

    }
}
