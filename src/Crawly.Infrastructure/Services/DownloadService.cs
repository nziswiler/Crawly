using System.Net;
using HtmlAgilityPack;

using Crawly.Core.Services;

namespace Crawly.Infrastructure.Services
{
    public class DownloadService : IDownloadService
    {
        public void DownloadPage(string url, string location)
        {
            DownloadFile(url, location);

            var host = GetHostFromUrl(url);
            var links = GetPageLinksFilteredByHost(location, host);
            
            foreach (var link in links)
            {
                var localpath = link.Split(host)[1];
                this.DownloadPage(link, localpath);
            }

        }

        // TODO: Error handling
        private static string GetHostFromUrl(string url)
        {
            var uri = new Uri(url);
            return uri.Host;
        }

        private static void DownloadFile(string url, string location)
        {
            using WebClient client = new WebClient();
            client.DownloadFile(url, location);
        }

        private static IEnumerable<string> GetPageLinksFilteredByHost(string location, string host)
        {
            var doc = new HtmlDocument();
            doc.Load(location);

            return doc!.DocumentNode.SelectNodes("//a[@href]")
                .Select(n => n.Attributes["href"].Value.ToString())
                .Where(link => IsInternalUrl(link, host));
        }

        private static bool IsInternalUrl(string url, string host)
        {
            return url.StartsWith("/") || host.Equals(GetHostFromUrl(url));
        }
    }
}
