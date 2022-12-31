// See https://aka.ms/new-console-template for more information

using Crawly.Core.Domain;
using Crawly.Infrastructure.Services;


Console.WriteLine("Hello, World!");

var crawlingOptions = new CrawlingOptions(@"C:\\webseiten\\lungenpraxis");
crawlingOptions.CrawlRecursivly = true;
crawlingOptions.CrawlImages = true;
crawlingOptions.CrawlStylesheets = true;
crawlingOptions.DownloadHtml = true;
crawlingOptions.DowloadStylesheets = true;
crawlingOptions.DownloadImages = true;
var crawlingService = new CrawlingService("https://www.lungenpraxis-spiez.ch/", crawlingOptions);
crawlingService.StartCrawling();