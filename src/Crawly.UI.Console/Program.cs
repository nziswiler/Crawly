// See https://aka.ms/new-console-template for more information

using Crawly.Core.Domain;
using Crawly.Infrastructure.Services;


Console.WriteLine("Hello, World!");

var crawlingOptions = new CrawlingOptions("https://shawna.ch/");
crawlingOptions.CrawlRecursivly = true;
crawlingOptions.CrawlImages = true;
crawlingOptions.CrawlStylesheets = true;
var crawlingService = new CrawlingService("https://shawna.ch/", crawlingOptions);
crawlingService.CrawlWebsite();