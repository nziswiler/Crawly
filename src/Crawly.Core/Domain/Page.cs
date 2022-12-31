namespace Crawly.Core.Domain
{
    public class Page
    {
        public Page(Uri uri, string topLevelFolder)
        {
            this.Uri = uri;
            this.TopLevelFolder = topLevelFolder;
            this.FileName = getFileName();
            this.FolderPath = Path.Combine(topLevelFolder, getRelativPath());
        }

        public Uri Uri { get; private set; }

        public string TopLevelFolder { get; private set; }

        public string FileName { get; private set; }

        public string FolderPath { get; private set; }

        public string FullPath => Path.Combine(this.FolderPath, this.FileName);

        private string getFileName()
        {
            var name = this.Uri.Segments.Last();
            if (string.IsNullOrEmpty(name) || name.Equals("/"))
            {
                name = Path.GetRandomFileName();
            }

            if (name.EndsWith("/"))
            {
                name = name.Remove(name.Length - 1, 1);
            }

            if (!name.EndsWith(".html"))
            {
                name += ".html";
            }

            return name;
        }

        private string getRelativPath()
        {
            if (this.Uri.Segments.Count() > 2) 
            {
                var folderPath = this.Uri.Segments[this.Uri.Segments.Length - 2];

                return folderPath.Replace("/", "\\");
            }

            return this.TopLevelFolder;
        }
    }
}
