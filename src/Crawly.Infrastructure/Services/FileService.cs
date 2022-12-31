using Crawly.Core;
using Crawly.Core.Services;
using HtmlAgilityPack;
using System.Net;

namespace Crawly.Infrastructure.Services
{
    public class FileService : IFileService
    {
        public void DownloadImage(string url, string location)
        {
            this.DowloadFile(url, location, Constants.FileTypes.IMAGES);
        }

        public void DownloadStylesheet(string url, string location)
        {
            this.DowloadFile(url, location, Constants.FileTypes.CSS);
        }

        public void SaveFileFromHtmlString(string html, string location)
        {
            var htmlDoc = HtmlAgilityPackExtension.LoadHtmlDocumentByString(html);

            Directory.CreateDirectory(GetDirectoryByPath(location));
            htmlDoc.Save(location);
        }

        private void DowloadFile(string url, string location, string category)
        {
            var path = Path.Combine(location, category.ToLower(), GetFileNameFromUrl(url));

            Directory.CreateDirectory(GetDirectoryByPath(path));
            var webClient = new WebClient();
            webClient.DownloadFile(url, path);
        }


        private static string GetDirectoryByPath(string path)
        {
            var directory = Path.GetDirectoryName(path);

            return directory ?? throw new NotSupportedException("This path is not supported!");
        }

        // TODO: Check for relativ links
        private string GetFileNameFromUrl(string url)
        {
            var uri = new Uri(url);

            return Path.GetFileName(uri.LocalPath);
        }
    }
}
