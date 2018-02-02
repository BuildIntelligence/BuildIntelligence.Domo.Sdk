using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BiDomoDotNet.Pages
{
    public class PageClient : IDomoPageClient
	{
		private DomoHttpClient _domoHttpClient;

		public PageClient(IDomoConfig config)
		{
			_domoHttpClient = new DomoHttpClient(config);
		}

		public async Task<Page> RetrievePageAsync(string pageId)
		{
			string pageUri = $"v1/pages/{pageId}";
			_domoHttpClient.SetAcceptRequestHeaders("application/json");
			_domoHttpClient.SetContentType("application/json");

			var response = await _domoHttpClient.Client.GetAsync(pageUri);
			string stringResponse = await response.Content.ReadAsStringAsync();
			Page pageResponse = JsonConvert.DeserializeObject<Page>(stringResponse);
			return pageResponse;
		}

		public async Task<Page> CreatePageAsync(Page page)
		{
			string pageUri = "v1/pages";
			_domoHttpClient.SetContentType("application/json");
			_domoHttpClient.SetAcceptRequestHeaders("application/json");
			StringContent content = new StringContent(JsonConvert.SerializeObject(page));

			var response = await _domoHttpClient.Client.PostAsync(pageUri, content);
			string stringResponse = await response.Content.ReadAsStringAsync();
			Page pageResponse = JsonConvert.DeserializeObject<Page>(stringResponse);
			return pageResponse;
		}

		public async Task<bool> UpdatePageAsync(string pageId, Page page)
		{
			string pageUri = $"v1/pages/{pageId}";
			_domoHttpClient.SetContentType("application/json");
			_domoHttpClient.SetAcceptRequestHeaders("application/json");

			StringContent content = new StringContent(JsonConvert.SerializeObject(page));
			var response = await _domoHttpClient.Client.PutAsync(pageUri, content);
			return response.IsSuccessStatusCode;
		}

		public async Task<bool> DeletePageAsync(string pageId)
		{
			string pageUri = $"v1/pages/{pageId}";
			_domoHttpClient.SetContentType("application/json");
			_domoHttpClient.SetAcceptRequestHeaders("application/json");

			var response = await _domoHttpClient.Client.DeleteAsync(pageId);
			return response.IsSuccessStatusCode;
		}

		public async Task<IEnumerable<Page>> ListPagesAsync(int limit, int offset)
		{
			string pageUri = $"v1/pages?offset={offset}&limit={limit}";
			_domoHttpClient.SetAcceptRequestHeaders("application/json");
			_domoHttpClient.SetContentType("application/json");

			var response = await _domoHttpClient.Client.GetAsync(pageUri);
			string stringResponse = await response.Content.ReadAsStringAsync();
			IEnumerable<Page> pageResponse = JsonConvert.DeserializeObject<IEnumerable<Page>>(stringResponse);
			return pageResponse;
		}

		public async Task<PageCollection> RetrievePageCollectionAsync(long pageId)
		{
			string pageUri = $"v1/pages/{pageId}/collections";
			_domoHttpClient.SetAcceptRequestHeaders("application/json");
			_domoHttpClient.SetContentType("application/json");

			var response = await _domoHttpClient.Client.GetAsync(pageUri);
			string stringResponse = await response.Content.ReadAsStringAsync();
			PageCollection collection = JsonConvert.DeserializeObject<PageCollection>(stringResponse);
			return collection;
		}

		public async Task<bool> CreatePageCollectionAsync(long pageId, PageInfo pageInfo)
		{
			string pageUri = $"v1/pages/{pageId}/collections";
			_domoHttpClient.SetAcceptRequestHeaders("application/json");
			_domoHttpClient.SetContentType("application/json");

			StringContent content = new StringContent(JsonConvert.SerializeObject(pageInfo));
			var response = await _domoHttpClient.Client.PostAsync(pageUri, content);
			return response.IsSuccessStatusCode;
		}

		public async Task<bool> UpdatePageCollectionAsync(long pageId, long pageCollectionId, PageInfo pageInfo)
		{
			string pageUri = $"v1/pages/{pageId}/collections/{pageCollectionId}";
			_domoHttpClient.SetAcceptRequestHeaders("application/json");
			_domoHttpClient.SetContentType("application/json");

			StringContent content = new StringContent(JsonConvert.SerializeObject(pageInfo));
			var response = await _domoHttpClient.Client.PutAsync(pageUri, content);
			return response.IsSuccessStatusCode;
		}

		public async Task<bool> DeletePageCollectionAsync(long pageId, long pageCollectionId)
		{
			string pageUri = $"v1/pages/{pageId}/collections/{pageCollectionId}";
			_domoHttpClient.SetAcceptRequestHeaders("application/json");
			_domoHttpClient.SetContentType("application/json");

			var response = await _domoHttpClient.Client.DeleteAsync(pageUri);
			return response.IsSuccessStatusCode;
		}
	}
}
