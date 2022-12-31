namespace Crawly.Infrastructure.Extensions
{
    public static class UriHelper
    {
        public static Uri GetUriFromString(string url, string baseUrl)
        {
            var isNotAbsolutUrl = !Uri.TryCreate(url, UriKind.Absolute, out Uri? uri);
            if (isNotAbsolutUrl)
            {
                Uri.TryCreate(new Uri(@"https://" + baseUrl), url, out uri);
            }

            return uri ?? throw new NotSupportedException("This Url is not Supported");
        }
    }
}
