namespace Crawly.Core
{
    public struct Constants
    {
        public struct FileTypes
        {
            public const string Images = nameof(Images);
            public const string Css = nameof(Css);
        }

        public struct UrlFragments
        {
            public const string Html = ".html";
            public const string www = "www.";
            public const string Https = "https://";
        }

        public struct FileNames
        {
            public const string Index = "index.html";
            public const string PageStatistics = "pageStatistics.txt";
            public const string ExternalReferences = "externalReferences.txt";
        }
    }
}
