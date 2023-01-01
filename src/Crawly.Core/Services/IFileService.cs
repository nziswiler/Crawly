namespace Crawly.Core.Services
{
    public interface IFileService
    {
        void SaveFileFromHtmlString(string html, string location);
        
        void DownloadImage(Uri uri, string location); 
        
        void DownloadStylesheet(Uri uri, string location);

        void ExportPageStatistics(string location, IEnumerable<string> text);

        void ExportExternalLinks(string location, IEnumerable<string> text);

    }
}
