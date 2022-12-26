namespace Crawly.Core.Domain
{
    public class Page
    {
        public Page(Uri uri, string parentLocation)
        {
            this.Uri = uri;
            this.ParentLocation = parentLocation;
            this.FileName = getFileName();
        }

        public Uri Uri { get; private set; }

        public string ParentLocation { get; private set; }

        public string FileName { get; private set; }

        public string FolderPath => this.ParentLocation + getRelativPath();

        public string FullPath => this.FolderPath + this.FileName;

        private string getFileName()
        {
            var name = this.Uri.Segments.Last();
            if (name.Equals("/"))
            {
                name = "index.html";
            }
            if (!name.EndsWith(".html"))
            {
                name += ".html";
            }

            return name;
        }

        private string getRelativPath()
        {
            if (this.Uri.Segments.Count() > 1) 
            {
                var folderPath = this.Uri.Segments[this.Uri.Segments.Count() - 2];

                return folderPath.Replace("/", "\\");
            }

            return "\\";
        }
    }
}
