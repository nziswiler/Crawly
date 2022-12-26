using System.Net;
using HtmlAgilityPack;

using Crawly.Core.Domain;
using Crawly.Core.Services;

namespace Crawly.Infrastructure.Services
{
    public class CrawlingService : ICrawlingService
    {
        public void CrawlWebsite(Website website)
        {
            for(int i = 0; i <= website.Pages.Count; i++)
            {
                var currentPage = website.Pages[i];
                DownloadFile(currentPage);
                var references = GetPageLinks(currentPage.FullPath);
                
                foreach(var reference in references)
                {
                    website.AddPageReference(reference);
                }

            }
        }

        private static void DownloadFile(Page page)
        {
            WebClient client = new WebClient();
            CreateDirectoryIfNotExists(page.FolderPath);
            client.DownloadFile(page.Uri.AbsoluteUri, page.FullPath);
        }

        private static void CreateDirectoryIfNotExists(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        private static IEnumerable<string> GetPageLinks(string location)
        {
            var doc = new HtmlDocument();
            doc.Load(location);

            return doc!.DocumentNode.SelectNodes("//a[@href]")
                .Select(n => n.Attributes["href"].Value.ToString());
        }
    }
}
