namespace Crawly.Core.Domain
{
    public class CrawlingOptions
    {
        public CrawlingOptions(string location)
        {
            this.Location = location;
        }

        public string Location { get; private set; }

        public bool DownloadHtml { get; private set; }

        public bool CrawlRecursivly { get; private set; }

        public bool CrawlImages { get; private set; }

        public bool DownloadImages { get; private set; }

        public bool CrawlStylesheets { get; private set; }

        public bool DowloadStylesheets { get; private set; }

        public bool PageStatisticsEvaluation { get; private set; }

        public bool ExternalLinksEvaluation { get; private set; }

        public void ConfigureFullPageDownload()
        {
            this.Configure(dowloadHtml: true, 
                crawlRecursivly: true, 
                crawlImages: true, 
                downloadImages: true, 
                crawlStylesheets: true, 
                dowloadStylesheets: true,
                pageStatisticsEvaluation: false,
                externalLinksEvaluation: false);
        }

        public void ConfigureHtmlOnlyDownloadRecursivly()
        {
            this.Configure(dowloadHtml: true, 
                crawlRecursivly: true, 
                crawlImages: false, 
                downloadImages: false, 
                crawlStylesheets: false, 
                dowloadStylesheets: false,
                pageStatisticsEvaluation: false,
                externalLinksEvaluation: false);
        }

        public void ConfigureSinglePageDownload()
        {
            this.Configure(dowloadHtml: true, 
                crawlRecursivly: false, 
                crawlImages: true, 
                downloadImages: true, 
                crawlStylesheets: true, 
                dowloadStylesheets: true,
                pageStatisticsEvaluation: false,
                externalLinksEvaluation: false);
        }

        public void ConfigureImagesOnlyDownload()
        {
            this.Configure(dowloadHtml: false, 
                crawlRecursivly: false, 
                crawlImages: true, 
                downloadImages: true, 
                crawlStylesheets: false, 
                dowloadStylesheets: false,
                pageStatisticsEvaluation: false,
                externalLinksEvaluation: false);
        }
        public void ConfigureStylesheetsOnlyDownload()
        {
            this.Configure(dowloadHtml: false,
                crawlRecursivly: false,
                crawlImages: false,
                downloadImages: false,
                crawlStylesheets: true,
                dowloadStylesheets: true,
                pageStatisticsEvaluation: false,
                externalLinksEvaluation: false);
        }

        public void ConfigurePageStatisticsExport()
        {
            this.Configure(dowloadHtml: false,
                crawlRecursivly: true,
                crawlImages: false,
                downloadImages: false,
                crawlStylesheets: false,
                dowloadStylesheets: false,
                pageStatisticsEvaluation: true,
                externalLinksEvaluation: false);
        }

        public void ConfigureExternalLinksExport()
        {
            this.Configure(dowloadHtml: false,
                crawlRecursivly: true,
                crawlImages: false,
                downloadImages: false,
                crawlStylesheets: false,
                dowloadStylesheets: false,
                pageStatisticsEvaluation: false,
                externalLinksEvaluation: true);
        }

        public void Configure(bool dowloadHtml, bool crawlRecursivly, bool crawlImages, bool downloadImages, bool crawlStylesheets, bool dowloadStylesheets, bool pageStatisticsEvaluation, bool externalLinksEvaluation)
        {
            this.DownloadHtml = dowloadHtml;
            this.CrawlRecursivly = crawlRecursivly;
            this.CrawlImages = crawlImages;
            this.DownloadImages = downloadImages;
            this.CrawlStylesheets = crawlStylesheets;
            this.DowloadStylesheets = dowloadStylesheets;
            this.PageStatisticsEvaluation = pageStatisticsEvaluation;
            this.ExternalLinksEvaluation = externalLinksEvaluation;
        }
    }
}
