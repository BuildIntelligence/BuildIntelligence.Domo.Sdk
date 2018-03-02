using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BuildIntelligence.Domo.Sdk.Pages
{
    public class PageClient : IDomoPageClient
	{
		private DomoHttpClient _domoHttpClient;

		public PageClient(IDomoConfig config)
		{
			_domoHttpClient = new DomoHttpClient(config);
		}
		
		/// <summary>
		/// Retrieves information about a page
		/// </summary>
		/// <param name="pageId"></param>
		/// <returns>Page information</returns>
		public async Task<Page> RetrievePageAsync(string pageId)
		{
			string pageUri = $"v1/pages/{pageId}";
			_domoHttpClient.SetAcceptRequestHeaders("application/json");

			var response = await _domoHttpClient.Client.GetAsync(pageUri);
			string stringResponse = await response.Content.ReadAsStringAsync();
			Page pageResponse = JsonConvert.DeserializeObject<Page>(stringResponse);
			return pageResponse;
		}

		/// <summary>
		/// Creates a new page
		/// </summary>
		/// <param name="page"></param>
		/// <returns>Newly created page information</returns>
		public async Task<Page> CreatePageAsync(Page page)
		{
			string pageUri = "v1/pages";
			_domoHttpClient.SetAcceptRequestHeaders("application/json");
			StringContent content = new StringContent(JsonConvert.SerializeObject(page), Encoding.UTF8, "application/json");

			var response = await _domoHttpClient.Client.PostAsync(pageUri, content);
			string stringResponse = await response.Content.ReadAsStringAsync();
			Page pageResponse = JsonConvert.DeserializeObject<Page>(stringResponse);
			return pageResponse;
		}

		/// <summary>
		/// Updates an existing page
		/// </summary>
		/// <param name="pageId"></param>
		/// <param name="page"></param>
		/// <returns>Boolean whether method is successful</returns>
		public async Task<bool> UpdatePageAsync(string pageId, Page page)
		{
			string pageUri = $"v1/pages/{pageId}";
			_domoHttpClient.SetAcceptRequestHeaders("application/json");

			StringContent content = new StringContent(JsonConvert.SerializeObject(page), Encoding.UTF8, "application/json");
			var response = await _domoHttpClient.Client.PutAsync(pageUri, content);
			return response.IsSuccessStatusCode;
		}

		/// <summary>
		/// Deletes a page
		/// </summary>
		/// <param name="pageId"></param>
		/// <returns>Boolean whether method is successful</returns>
		public async Task<bool> DeletePageAsync(string pageId)
		{
			string pageUri = $"v1/pages/{pageId}";
			_domoHttpClient.SetAcceptRequestHeaders("application/json");

			var response = await _domoHttpClient.Client.DeleteAsync(pageId);
			return response.IsSuccessStatusCode;
		}

		/// <summary>
		/// Gets a list of pages
		/// </summary>
		/// <param name="limit">Limit of pages to return. Limit is 50.</param>
		/// <param name="offset">Offset of Pages to start retrieving from.</param>
		/// <returns>List of pages</returns>
		public async Task<IEnumerable<Page>> ListPagesAsync(int limit, int offset)
		{
			string pageUri = $"v1/pages?offset={offset}&limit={limit}";
			_domoHttpClient.SetAcceptRequestHeaders("application/json");

			var response = await _domoHttpClient.Client.GetAsync(pageUri);
			string stringResponse = await response.Content.ReadAsStringAsync();
			IEnumerable<Page> pageResponse = JsonConvert.DeserializeObject<IEnumerable<Page>>(stringResponse);
			return pageResponse;
		}

		/// <summary>
		/// Retrives a page collection from a page Id
		/// </summary>
		/// <param name="pageId"></param>
		/// <returns>Page collection information</returns>
		public async Task<PageCollection> RetrievePageCollectionAsync(long pageId)
		{
			string pageUri = $"v1/pages/{pageId}/collections";
			_domoHttpClient.SetAcceptRequestHeaders("application/json");

			var response = await _domoHttpClient.Client.GetAsync(pageUri);
			string stringResponse = await response.Content.ReadAsStringAsync();
			PageCollection collection = JsonConvert.DeserializeObject<PageCollection>(stringResponse);
			return collection;
		}

		/// <summary>
		/// Creates a page collection
		/// </summary>
		/// <param name="pageId"></param>
		/// <param name="pageInfo"></param>
		/// <returns>Boolean whether method is successful</returns>
		public async Task<bool> CreatePageCollectionAsync(long pageId, PageInfo pageInfo)
		{
			string pageUri = $"v1/pages/{pageId}/collections";
			_domoHttpClient.SetAcceptRequestHeaders("application/json");

			StringContent content = new StringContent(JsonConvert.SerializeObject(pageInfo), Encoding.UTF8, "application/json");
			var response = await _domoHttpClient.Client.PostAsync(pageUri, content);
			return response.IsSuccessStatusCode;
		}

		/// <summary>
		/// Updates an existing page collection
		/// </summary>
		/// <param name="pageId"></param>
		/// <param name="pageCollectionId"></param>
		/// <param name="pageInfo"></param>
		/// <returns>Boolean whether method is successful</returns>
		public async Task<bool> UpdatePageCollectionAsync(long pageId, long pageCollectionId, PageInfo pageInfo)
		{
			string pageUri = $"v1/pages/{pageId}/collections/{pageCollectionId}";
			_domoHttpClient.SetAcceptRequestHeaders("application/json");

			StringContent content = new StringContent(JsonConvert.SerializeObject(pageInfo), Encoding.UTF8, "application/json");
			var response = await _domoHttpClient.Client.PutAsync(pageUri, content);
			return response.IsSuccessStatusCode;
		}

		/// <summary>
		/// Deletes a page collection
		/// </summary>
		/// <param name="pageId"></param>
		/// <param name="pageCollectionId"></param>
		/// <returns>Boolean whether method is successful</returns>
		public async Task<bool> DeletePageCollectionAsync(long pageId, long pageCollectionId)
		{
			string pageUri = $"v1/pages/{pageId}/collections/{pageCollectionId}";
			_domoHttpClient.SetAcceptRequestHeaders("application/json");

			var response = await _domoHttpClient.Client.DeleteAsync(pageUri);
			return response.IsSuccessStatusCode;
		}
	}
}
