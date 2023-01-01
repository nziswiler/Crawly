namespace Crawly.Core
{
    public struct Constants
    {
        public struct FileTypes
        {
            public const string IMAGES = nameof(IMAGES);
            public const string CSS = nameof(CSS);
        }

        public struct UrlFragments
        {
            public const string HTML = ".html";
            public const string WWW = "www.";
            public const string HTTPS = "https://";
        }

        public struct FileNames
        {
            public const string INDEX = "index.html";
        }
    }
}
