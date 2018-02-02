using System.Collections.Generic;
using System.Threading.Tasks;

namespace BiDomoDotNet.Pages
{
    public interface IDomoPageClient
    {
        Task<Page> RetrievePageAsync(string pageId);
        Task<Page> CreatePageAsync(Page page);
        Task<bool> UpdatePageAsync(string pageId, Page page);
        Task<bool> DeletePageAsync(string pageId);
        Task<IEnumerable<Page>> ListPagesAsync(int limit, int offset);
        Task<PageCollection> RetrievePageCollectionAsync(long pageId);
        Task<bool> CreatePageCollectionAsync(long pageId, PageInfo pageInfo);
        Task<bool> UpdatePageCollectionAsync(long pageId, long pageCollectionId, PageInfo pageInfo);
        Task<bool> DeletePageCollectionAsync(long pageId, long pageCollectionId);
    }
}
