using HtmlAgilityPack;

namespace Crawly.Infrastructure.Extensions
{
    public static class HtmlAgilityPackExtension
    {
        public static HtmlDocument LoadHtmlDocumentByUrl(string url)
        {
            var web = new HtmlWeb();

            return web.Load(url);
        }

        public static HtmlDocument LoadHtmlDocumentByString(string html)
        {
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            return htmlDoc;
        }

        public static IEnumerable<string> GetPageReferences(HtmlDocument htmlDocument)
        {
            var references = htmlDocument.DocumentNode.SelectNodes("//a[@href]")
                ?.Where(n => !n.Attributes["href"].Value.ToString().StartsWith("#")) // Ignore anker links
                .Select(n => n.Attributes["href"].Value.ToString());

            return references ?? Enumerable.Empty<string>();
        }

        public static IEnumerable<string> GetImageReferences(HtmlDocument htmlDocument)
        {
            var references = htmlDocument.DocumentNode.SelectNodes("//img")
                ?.Select(n => n.Attributes["src"].Value.ToString());

            return references ?? Enumerable.Empty<string>();
        }

        public static IEnumerable<string> GetStylesheetReferences(HtmlDocument htmlDocument)
        {
            var references = htmlDocument.DocumentNode.SelectNodes("//link[@type='text/css']")
                ?.Select(n => n.Attributes["href"].Value.ToString());

            return references ?? Enumerable.Empty<string>();
        }
    }
}
