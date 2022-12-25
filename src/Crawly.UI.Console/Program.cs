// See https://aka.ms/new-console-template for more information

using Crawly.Infrastructure.Services;

Console.WriteLine("Hello, World!");

var downloadService = new DownloadService();
downloadService.DownloadPage("https://shawna.ch/", @"C:\\webseiten\\shawna");