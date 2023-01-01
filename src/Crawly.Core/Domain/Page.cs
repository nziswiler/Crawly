namespace Crawly.Core.Domain
{
    public class Page
    {
        public Page (Uri uri, string topLevelFolder)
        {
            this.Uri = uri;
            var folderPath = Path.Combine(topLevelFolder, getRelativPath() ?? topLevelFolder);
            this.Location = Path.Combine(folderPath, generateFileName());
        }

        public Uri Uri { get; private set; }

        public string? Html { get; set; }

        public string Location { get; private set; }

        private string generateFileName()
        {
            var name = this.Uri.Segments.Last();
            if (string.IsNullOrEmpty(name) || name.Equals("/"))
            {
                name = Constants.FileNames.INDEX;
            }

            if (name.EndsWith("/"))
            {
                name = name.Remove(name.Length - 1, 1);
            }

            if (!name.EndsWith(Constants.UrlFragments.HTML))
            {
                name += Constants.UrlFragments.HTML;
            }

            return name;
        }

        private string? getRelativPath()
        {
            if (this.Uri.Segments.Count() > 2) 
            {
                var folderPath = this.Uri.Segments[this.Uri.Segments.Length - 2];

                return folderPath.Replace("/", "\\");
            }

            return null;
        }
    }
}
