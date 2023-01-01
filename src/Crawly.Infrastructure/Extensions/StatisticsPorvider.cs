using Crawly.Core.Domain;

namespace Crawly.Infrastructure.Extensions
{
    public static class StatisticsPorvider
    {
        public static string[] GetPageMetaData(Website website)
        {
            return new string[]
            {
                $"Folgende Webseite wurde durchsucht: {website.Uri.AbsoluteUri}",
                $"Anzahl gefundene interne Links: {website.Pages.Count}",
                $"Anzahl gefundene externe Links: {website.ExternalReferences.Count}",
                $"Anzahl gefunde Bilder: {website.ExternalReferences.Count}",
                $"Anzahl gefunde CSS Dateien: {website.ExternalReferences.Count}"
            };
        }
    }
}
