﻿using HtmlAgilityPack;

using Crawly.Core.Domain;
using Crawly.Core.Services;
using System.Net;

namespace Crawly.Infrastructure.Services
{
    public class CrawlingService : ICrawlingService
    {
        private readonly CrawlingOptions _crawlingOptions;
        private readonly Website _website;

        public CrawlingService(string url, CrawlingOptions crawlingOptions)
        {
            this._crawlingOptions = crawlingOptions;
            this._website = new Website(url);
            this._website.AddPageReference(url, crawlingOptions.Location);
        }

        public void CrawlWebsite()
        {
            for (int i = 0; i < this._website.Pages.Count; i++)
            {
                var currentPage = this._website.Pages[i];
                var htmlDoucment = LoadHtmlDocumentByUrl(currentPage.Uri.AbsoluteUri);

                if (this._crawlingOptions.DownloadHtml)
                {
                    SaveHtmlDocument(htmlDoucment, currentPage.FullPath);
                }

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

            // TODO: Refactor
            if (this._crawlingOptions.DownloadImages)
            {
                foreach(var imageReference in this._website.ImageReferences)
                {
                    this.DowloadFile(imageReference, "image");
                }
            }

            if (this._crawlingOptions.DowloadStylesheets)
            {
                foreach (var imageReference in this._website.StylesheetReferences)
                {
                    this.DowloadFile(imageReference, "css");
                }
            }
        }

        private void AddReferencesRecursivly(HtmlDocument htmlDoucment)
        {
            foreach (var pageReference in GetPageReferences(htmlDoucment))
            {
                this._website.AddPageReference(pageReference, this._crawlingOptions.Location);
            }
        }

        private void AddImageReferences(HtmlDocument htmlDoucment)
        {
            foreach (var imageReference in GetImageReferences(htmlDoucment))
            {
                this._website.AddImageReference(imageReference);
            }
        }

        private void AddStylesheetReferences(HtmlDocument htmlDoucment)
        {
            foreach (var cssReference in GetCssReferences(htmlDoucment))
            {
                this._website.AddStylesheetReferences(cssReference);
            }
        }

        private static void SaveHtmlDocument(HtmlDocument htmlDocument, string location)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(location));
            try
            {
                var fileStream = new FileStream(location, FileMode.Create);
                htmlDocument.Save(fileStream);
            }
            catch
            {

            }
        }

        private void DowloadFile(string url, string category)
        {
            var path = Path.Combine(this._crawlingOptions.Location, category, GetFileNameFromUrl(url));
            Directory.CreateDirectory(Path.GetDirectoryName(path));
            var webClient = new WebClient();
            webClient.DownloadFile(url, path);
        }

        private string GetFileNameFromUrl(string url)
        {
            var uri = new Uri(url);
            return Path.GetFileName(uri.LocalPath);
        }

        private static HtmlDocument LoadHtmlDocumentByUrl(string url)
        {
            var web = new HtmlWeb();
            return web.Load(url);
        }

        private static IEnumerable<string> GetPageReferences(HtmlDocument htmlDocument)
        {
            var references = htmlDocument.DocumentNode.SelectNodes("//a[@href]")
                ?.Select(n => n.Attributes["href"].Value.ToString());

            return references ?? Enumerable.Empty<string>();
        }

        private static IEnumerable<string> GetImageReferences(HtmlDocument htmlDocument)
        {
            var references = htmlDocument.DocumentNode.SelectNodes("//img")
                ?.Select(n => n.Attributes["src"].Value.ToString());

            return references ?? Enumerable.Empty<string>();
        }

        private static IEnumerable<string> GetCssReferences(HtmlDocument htmlDocument)
        {
            var references = htmlDocument.DocumentNode.SelectNodes("//link[@type='text/css']")
                ?.Select(n => n.Attributes["href"].Value.ToString());

            return references ?? Enumerable.Empty<string>();
        }
    }
}
