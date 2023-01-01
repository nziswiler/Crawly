namespace Crawly.Core.Domain
{
    public class Website
    {
        public Website(Uri uri)
        {
            this.Uri = uri;
            this.Pages = new List<Page>();
            this.ExternalReferences = new List<string>();
            this.ImageReferences = new List<string>();
            this.StylesheetReferences = new List<string>();
            this.JavaScriptReferences = new List<string>();
        }

        public Uri Uri { get; private set; }

        public List<Page> Pages { get; private set; }

        public List<string> ExternalReferences { get; private set; }

        public List<string> ImageReferences { get; private set; }

        public List<string> StylesheetReferences { get; private set; }

        public List<string> JavaScriptReferences { get; private set; }

        public void AddPageReference(Uri uri, string location)
        {
            if (!this.Uri.IsBaseOf(uri))
            {
                this.AddExternalReference(uri.AbsoluteUri);
                return;
            }

            var isNotADuplicate = this.Pages.FirstOrDefault(page => page.Uri.Equals(uri)) == null;
            if (isNotADuplicate)
            {
                this.Pages.Add(new Page(uri, location));
            }
        }

        public void AddImageReference(string url)
        {
            var isNotAlreadyExisting = !this.ImageReferences.Contains(url);
            if (isNotAlreadyExisting)
            {
                this.ImageReferences.Add(url);
            }
        }

        public void AddStylesheetReferences(string url)
        {
            var isNotAlreadyExisting = !this.StylesheetReferences.Contains(url);
            if (isNotAlreadyExisting)
            {
                this.StylesheetReferences.Add(url);
            }
        }

        private void AddExternalReference(string url)
        {
            if (!this.ExternalReferences.Contains(url))
            {
                this.ExternalReferences.Add(url);
            }
        }
    }
}
