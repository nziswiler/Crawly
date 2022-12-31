namespace Crawly.Core.Domain
{
    public class CrawlingOptions
    {
        public CrawlingOptions(string location)
        {
            this.Location = location;
        }

        public string Location { get; set; }

        public bool DownloadHtml { get; set; }

        public bool CrawlRecursivly { get; set; }

        public bool CrawlImages { get; set; }

        public bool DownloadImages { get; set; }

        public bool CrawlStylesheets { get; set; }

        public bool DowloadStylesheets { get; set; }
    }
}
