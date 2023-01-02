using Crawly.Core;
using Crawly.Core.Services;
using Crawly.Infrastructure.Extensions;
using System.Net;

namespace Crawly.Infrastructure.Services
{
    public class FileService : IFileService
    {
        public void DownloadImage(Uri uri, string location)
        {
            DowloadFile(uri, location, Constants.FileTypes.Images);
        }

        public void DownloadStylesheet(Uri uri, string location)
        {
            DowloadFile(uri, location, Constants.FileTypes.Css);
        }

        public void SaveFileFromHtmlString(string html, string location)
        {
            var htmlDoc = HtmlAgilityPackExtension.LoadHtmlDocumentByString(html);

            Directory.CreateDirectory(GetDirectoryByPath(location));
            htmlDoc.Save(location);
        }

        public void ExportPageStatistics(string location, IEnumerable<string> text)
        {
            SaveStringArrayAsTxt(location, Constants.FileNames.PageStatistics, text);
        }

        public void ExportExternalLinks(string location, IEnumerable<string> text)
        {
            SaveStringArrayAsTxt(location, Constants.FileNames.ExternalReferences, text);
        }

        // TODO: Refector and use HttpClient instead of WebClient
        private static void DowloadFile(Uri uri, string location, string category)
        {
            var path = Path.Combine(location, category.ToLower(), Path.GetFileName(uri.LocalPath));

            Directory.CreateDirectory(GetDirectoryByPath(path));
            var webClient = new WebClient();
            webClient.DownloadFile(uri.AbsoluteUri, path);
        }

        private static void SaveStringArrayAsTxt(string location, string fileName, IEnumerable<string> text)
        {
            var path = Path.Combine(location, fileName);
            Directory.CreateDirectory(GetDirectoryByPath(path));
            File.WriteAllLines(path, text);
        }

        private static string GetDirectoryByPath(string path)
        {
            var directory = Path.GetDirectoryName(path);

            return directory ?? throw new NotSupportedException("This path is not supported!");
        }
    }
}
