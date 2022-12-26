using Crawly.Core.Domain;

namespace Crawly.Core.Services
{
    public interface ICrawlingService
    {
        void CrawlWebsite(Website website);
    }
}
