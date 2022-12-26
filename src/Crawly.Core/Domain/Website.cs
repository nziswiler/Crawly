namespace Crawly.Core.Domain
{
    public class Website
    {
        public Website(string url, string location)
        {
            this.Url = url;
            this.Location = location;
            this.Uri = new Uri(url);
            this.Pages = new List<Page>();
            this.ExternalLinks = new List<string>();
            this.Images = new List<string>();

            this.AddPageReference(this.Url);
        }

        public string Url { get; private set; }

        public string Location { get; private set; }

        public Uri Uri { get; private set; }

        public List<Page> Pages { get; private set; }

        public List<string> ExternalLinks { get; private set; }

        public List<string> Images { get; private set; }

        public void AddPageReference(string url)
        {
            try
            {
                var uri = new Uri(url);
                if (this.Uri.Host.Equals(uri.Host))
                {
                    var page = new Page(uri, this.Location);
                    this.Pages.Add(page);
                }
                else
                {
                    this.ExternalLinks.Add(url);
                }
            }
            catch
            {
                if (url.StartsWith("/"))
                {
                    var page = new Page(new Uri(this.Uri.AbsoluteUri + url), this.Location);
                    this.Pages.Add(page);
                }
            }
        }
    }
}
