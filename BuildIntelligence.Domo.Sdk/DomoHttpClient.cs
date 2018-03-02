using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BuildIntelligence.Domo.Sdk
{
    public class DomoHttpClient
	{
		private IDomoConfig _config;
		public DomoAuthToken _authToken;

		public HttpClient Client; // { get; set; } = new HttpClient();

		public DomoHttpClient(IDomoConfig config)
		{
			Client = new HttpClient();
			_config = config;
			InitializeDefaultClient();
		}

		private void InitializeDefaultClient()
		{
			GetDomoAuthAsync().Wait();
			Client.BaseAddress = _config.ApiHost;
			Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", _authToken.Token);
		}

		public async Task GetAuthToken()
		{
			await GetDomoAuthAsync();
			Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", _authToken.Token);
		}

		private async Task GetDomoAuthAsync()
		{
			using (HttpClient client = new HttpClient())
			{
				string authScope = "";
				switch (_config.Scope)
				{
					case DomoAuthScope.Data:
						authScope = "data";
						break;
					case DomoAuthScope.User:
						authScope = "user";
						break;
					case (DomoAuthScope)0x3:
						authScope = "data%20user";
						break;
					default:
						break;
				}



				byte[] clientCreds = Encoding.ASCII.GetBytes($"{_config.ClientId}:{_config.ClientSecret}");
				client.DefaultRequestHeaders.Accept.Clear();
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(clientCreds));
				string tokenUrl = "https://api.domo.com/oauth/token?grant_type=client_credentials&scope=" + authScope;
				var response = await client.PostAsync(tokenUrl, new FormUrlEncodedContent(new[] { new KeyValuePair<string, string>("", "") }));

				string jsonResponse = await response.Content.ReadAsStringAsync();

				DomoAuthToken authToken = JsonConvert.DeserializeObject<DomoAuthToken>(jsonResponse);

				_authToken = authToken;
			}
		}

		public void SetAcceptRequestHeaders(string mediaType)
		{
			Client.DefaultRequestHeaders.Accept.Clear();
			Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue($"{mediaType}"));
		}

		public void SetAcceptRequestHeaders(string mediaType, string mediaType2)
		{
			Client.DefaultRequestHeaders.Accept.Clear();
			Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue($"{mediaType}"));
			Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue($"{mediaType2}"));
		}

		public void SetAuthorizationHeader(string schema, string parameter)
		{
			Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue($"{schema}", $"{parameter}");
		}

	}
}
