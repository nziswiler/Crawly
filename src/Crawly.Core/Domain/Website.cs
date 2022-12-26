using System.Collections.ObjectModel;

namespace Crawly.Core.Domain
{
    public class Website
    {
        public Website(string url, string folderLocation)
        {
            this.Url = url;
            this.FolderLocation = folderLocation;
            this.Uri = new Uri(url);
            this.Pages = new Collection<Page>();
            this.ExternalLinks = new Collection<string>();
            this.Images = new Collection<string>();
        }

        public string Url { get; private set; }

        public string FolderLocation { get; private set; }

        public Uri Uri { get; private set; }

        public ICollection<Page> Pages { get; set; }

        public ICollection<string> ExternalLinks { get; set; }

        public ICollection<string> Images { get; set; }
    }
}
