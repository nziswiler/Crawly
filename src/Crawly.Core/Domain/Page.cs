namespace Crawly.Core.Domain
{
    public class Page
    {
        public Page(string url, string fullPath)
        {
            this.Url = url;
            this.FullPath = fullPath;
        }

        public string Url { get; private set; }

        public string FullPath { get; private set; }

        public string FileName => this.FullPath.Split("/").Last();

        public string FolderPath => this.FullPath.Split("/").SkipLast(1).ToString() ?? string.Empty;
    }
}
