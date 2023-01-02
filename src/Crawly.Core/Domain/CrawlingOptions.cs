namespace Crawly.Core.Domain
{
    public class CrawlingOptions
    {
        public CrawlingOptions(string location)
        {
            this.Location = location;
        }

        public string Location { get; private set; }

        public bool IsHtmlDownloadActiv { get; private set; }

        public bool IsRecurisvCrawlingActiv { get; private set; }

        public bool IsImageCrawlingActiv { get; private set; }

        public bool IsImageDownloadActiv { get; private set; }

        public bool IsStylesheetCrawlingActiv { get; private set; }

        public bool IsStylesheetDownloadActiv { get; private set; }

        public bool IsExportPageStatisticsActiv { get; private set; }

        public bool IsExportExternalLiksActiv { get; private set; }

        public void DowloadFullPageRecusivly()
        {
            this.Configure(isHtmlDownloadActiv: true,
                isRecurisvCrawlingActiv: true,
                isImageCrawlingActiv: true,
                isImageDownloadActiv: true,
                isStylesheetCrawlingActiv: true,
                isStylesheetDownloadActiv: true,
                isExportPageStatisticsActiv: false,
                isExportExternalLiksActiv: false);
        }

        public void DowonloadHtmlFilesRecursivly()
        {
            this.Configure(isHtmlDownloadActiv: true,
                isRecurisvCrawlingActiv: true,
                isImageCrawlingActiv: false,
                isImageDownloadActiv: false,
                isStylesheetCrawlingActiv: false,
                isStylesheetDownloadActiv: false,
                isExportPageStatisticsActiv: false,
                isExportExternalLiksActiv: false);
        }

        public void DowloadFullPageSingle()
        {
            this.Configure(isHtmlDownloadActiv: true,
                isRecurisvCrawlingActiv: false,
                isImageCrawlingActiv: true,
                isImageDownloadActiv: true,
                isStylesheetCrawlingActiv: true,
                isStylesheetDownloadActiv: true,
                isExportPageStatisticsActiv: false,
                isExportExternalLiksActiv: false);
        }

        public void DownloadImagesSingle()
        {
            this.Configure(isHtmlDownloadActiv: false,
                isRecurisvCrawlingActiv: true,
                isImageCrawlingActiv: true,
                isImageDownloadActiv: true,
                isStylesheetCrawlingActiv: false,
                isStylesheetDownloadActiv: false,
                isExportPageStatisticsActiv: false,
                isExportExternalLiksActiv: false);
        }
        public void DownloadStylesheetSingle()
        {
            this.Configure(isHtmlDownloadActiv: false,
                isRecurisvCrawlingActiv: false,
                isImageCrawlingActiv: false,
                isImageDownloadActiv: false,
                isStylesheetCrawlingActiv: true,
                isStylesheetDownloadActiv: true,
                isExportPageStatisticsActiv: false,
                isExportExternalLiksActiv: false);
        }

        public void ExportPageStatistics()
        {
            this.Configure(isHtmlDownloadActiv: false,
                isRecurisvCrawlingActiv: true,
                isImageCrawlingActiv: false,
                isImageDownloadActiv: false,
                isStylesheetCrawlingActiv: false,
                isStylesheetDownloadActiv: false,
                isExportPageStatisticsActiv: true,
                isExportExternalLiksActiv: false);
        }

        public void ExportExternalLinks()
        {
            this.Configure(isHtmlDownloadActiv: false,
                isRecurisvCrawlingActiv: true,
                isImageCrawlingActiv: false,
                isImageDownloadActiv: false,
                isStylesheetCrawlingActiv: false,
                isStylesheetDownloadActiv: false,
                isExportPageStatisticsActiv: false,
                isExportExternalLiksActiv: true);
        }

        public void Configure(bool isHtmlDownloadActiv, bool isRecurisvCrawlingActiv, bool isImageCrawlingActiv, bool isImageDownloadActiv, bool isStylesheetCrawlingActiv, bool isStylesheetDownloadActiv, bool isExportPageStatisticsActiv, bool isExportExternalLiksActiv)
        {
            this.IsHtmlDownloadActiv = isHtmlDownloadActiv;
            this.IsRecurisvCrawlingActiv = isRecurisvCrawlingActiv;
            this.IsImageCrawlingActiv = isImageCrawlingActiv;
            this.IsImageDownloadActiv = isImageDownloadActiv;
            this.IsStylesheetCrawlingActiv = isStylesheetCrawlingActiv;
            this.IsStylesheetDownloadActiv = isStylesheetDownloadActiv;
            this.IsExportPageStatisticsActiv = isExportPageStatisticsActiv;
            this.IsExportExternalLiksActiv = isExportExternalLiksActiv;
        }
    }
}
