using System.Collections.Generic;
using System.Threading.Tasks;

namespace BiDomoDotNet.Pages
{
    public interface IDomoPageClient
    {
		/// <summary>
		/// Retrieves information about a page
		/// </summary>
		/// <param name="pageId"></param>
		/// <returns>Page information</returns>
		Task<Page> RetrievePageAsync(string pageId);
		/// <summary>
		/// Creates a new page
		/// </summary>
		/// <param name="page"></param>
		/// <returns>Newly created page information</returns>
		Task<Page> CreatePageAsync(Page page);
		/// <summary>
		/// Updates an existing page
		/// </summary>
		/// <param name="pageId"></param>
		/// <param name="page"></param>
		/// <returns>Boolean whether method is successful</returns>
		Task<bool> UpdatePageAsync(string pageId, Page page);
		/// <summary>
		/// Deletes a page
		/// </summary>
		/// <param name="pageId"></param>
		/// <returns>Boolean whether method is successful</returns>
		Task<bool> DeletePageAsync(string pageId);
		/// <summary>
		/// Gets a list of pages
		/// </summary>
		/// <param name="limit">Limit of pages to return. Limit is 50.</param>
		/// <param name="offset">Offset of Pages to start retrieving from.</param>
		/// <returns>List of pages</returns>
		Task<IEnumerable<Page>> ListPagesAsync(int limit, int offset);
		/// <summary>
		/// Retrives a page collection from a page Id
		/// </summary>
		/// <param name="pageId"></param>
		/// <returns>Page collection information</returns>
		Task<PageCollection> RetrievePageCollectionAsync(long pageId);
		/// <summary>
		/// Creates a page collection
		/// </summary>
		/// <param name="pageId"></param>
		/// <param name="pageInfo"></param>
		/// <returns>Boolean whether method is successful</returns>
		Task<bool> CreatePageCollectionAsync(long pageId, PageInfo pageInfo);
		/// <summary>
		/// Updates an existing page collection
		/// </summary>
		/// <param name="pageId"></param>
		/// <param name="pageCollectionId"></param>
		/// <param name="pageInfo"></param>
		/// <returns>Boolean whether method is successful</returns>
		Task<bool> UpdatePageCollectionAsync(long pageId, long pageCollectionId, PageInfo pageInfo);
		/// <summary>
		/// Deletes a page collection
		/// </summary>
		/// <param name="pageId"></param>
		/// <param name="pageCollectionId"></param>
		/// <returns>Boolean whether method is successful</returns>
		Task<bool> DeletePageCollectionAsync(long pageId, long pageCollectionId);
    }
}
