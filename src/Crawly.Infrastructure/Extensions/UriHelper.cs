namespace Crawly.Infrastructure.Extensions
{
    public static class UriHelper
    {
        public static Uri CreateUriFromString(string url, string baseUrl)
        {
            url = RemoveWorldWideWebFromUrl(url);
            var isAbsoultUrl = Uri.TryCreate(url, UriKind.Absolute, out Uri? uri);
            if (!isAbsoultUrl)
            {
                Uri.TryCreate(new Uri(@"https://" + baseUrl), url, out uri);
            }

            return uri ?? CreateBaseUri(@"https://" + baseUrl);
        }

        public static Uri CreateBaseUri(string url)
        {
            url = RemoveWorldWideWebFromUrl(url);
            Uri.TryCreate(url, UriKind.Absolute, out Uri? uri);

            return uri ?? throw new UriFormatException("This uri format is not supported!");
        }

        private static string RemoveWorldWideWebFromUrl(string url)
        {
            return url.Replace("www.", string.Empty).Replace("WWW.", string.Empty);
        }
    }
}
