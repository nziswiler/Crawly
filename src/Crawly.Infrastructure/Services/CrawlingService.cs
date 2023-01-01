using HtmlAgilityPack;

using Crawly.Core.Domain;
using Crawly.Core.Services;
using System.Net;
using Crawly.Infrastructure.Extensions;

namespace Crawly.Infrastructure.Services
{
    public class CrawlingService : ICrawlingService
    {
        private readonly CrawlingOptions _crawlingOptions;
        private readonly Website _website;

        private readonly IFileService fileService;

        public CrawlingService(Uri uri, CrawlingOptions crawlingOptions)
        {
            this._crawlingOptions = crawlingOptions;
            this._website = new Website(uri);

            this.fileService = new FileService();
        }

        public void StartCrawling()
        {
            this._website.AddPageReference(this._website.Uri, this._crawlingOptions.Location);

            this.CrawlPage();
            this.SaveFiles();
        }

        private void CrawlPage()
        {
            for (int i = 0; i < this._website.Pages.Count; i++)
            {
                var currentPage = this._website.Pages[i];
                var htmlDoucment = HtmlAgilityPackExtension.LoadHtmlDocumentByUrl(currentPage.Uri.AbsoluteUri);
                currentPage.Html = htmlDoucment.DocumentNode.OuterHtml;

                if (this._crawlingOptions.CrawlImages)
                {
                    this.AddImageReferences(htmlDoucment);
                }

                if (this._crawlingOptions.CrawlStylesheets)
                {
                    this.AddStylesheetReferences(htmlDoucment);
                }

                if (this._crawlingOptions.CrawlRecursivly)
                {
                    this.AddReferencesRecursivly(htmlDoucment);
                }
            }
        }

        private void SaveFiles()
        {
            if (this._crawlingOptions.DownloadHtml)
            {
                this.SaveHtmlFiles();
            }

            if (this._crawlingOptions.DownloadImages)
            {
                this.DowloadImages();
            }

            if (this._crawlingOptions.DowloadStylesheets)
            {
                this.DowloadStylesheets();
            }

            if (this._crawlingOptions.PageStatisticsEvaluation)
            {
                this.SavePageStatisticsAsTxt();
            }

            if (this._crawlingOptions.ExternalLinksEvaluation)
            {
                this.SaveExternalReferencesAsTxt();
            }
        }

        private void AddReferencesRecursivly(HtmlDocument htmlDoucment)
        {
            foreach (var pageReference in HtmlAgilityPackExtension.GetPageReferences(htmlDoucment))
            {
                this._website.AddPageReference(UriHelper.CreateUriFromString(pageReference, this._website.Uri.Host), this._crawlingOptions.Location);
            }
        }

        private void AddImageReferences(HtmlDocument htmlDoucment)
        {
            foreach (var imageReference in HtmlAgilityPackExtension.GetImageReferences(htmlDoucment))
            {
                this._website.AddImageReference(imageReference);
            }
        }

        private void AddStylesheetReferences(HtmlDocument htmlDoucment)
        {
            foreach (var cssReference in HtmlAgilityPackExtension.GetStylesheetReferences(htmlDoucment))
            {
                this._website.AddStylesheetReferences(cssReference);
            }
        }

        private void SaveHtmlFiles()
        {
            foreach (var page in this._website.Pages.Where(p => p.Html != null))
            {
                this.fileService.SaveFileFromHtmlString(page.Html, page.Location);
            }
        }

        private void DowloadImages()
        {
            foreach (var image in this._website.ImageReferences)
            {
                this.fileService.DownloadImage(UriHelper.CreateUriFromString(image, this._website.Uri.Host), this._crawlingOptions.Location);
            }
        }

        private void DowloadStylesheets()
        {
            foreach (var stylesheet in this._website.StylesheetReferences)
            {
                this.fileService.DownloadStylesheet(UriHelper.CreateUriFromString(stylesheet, this._website.Uri.Host), this._crawlingOptions.Location);
            }
        }

        private void SavePageStatisticsAsTxt()
        {
            this.fileService.ExportPageStatistics(this._crawlingOptions.Location, StatisticsPorvider.GetPageMetaData(this._website));
        }

        private void SaveExternalReferencesAsTxt()
        {
            this.fileService.ExportExternalLinks(this._crawlingOptions.Location, this._website.ExternalReferences.ToArray());
        }

    }
}
