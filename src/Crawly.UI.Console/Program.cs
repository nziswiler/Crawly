// See https://aka.ms/new-console-template for more information

using Crawly.Core.Domain;
using Crawly.Infrastructure.Services;


Console.WriteLine("Hello, World!");

var crawlingService = new CrawlingService();
crawlingService.CrawlWebsite(new Website("https://shawna.ch/", @"C:\\webseiten\\shawna"));