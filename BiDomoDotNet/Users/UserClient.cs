using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BiDomoDotNet.Users
{
    public class UserClient : IDomoUserClient
	{
		public DomoHttpClient _domoHttpClient;

		public UserClient(IDomoConfig config)
		{
			_domoHttpClient = new DomoHttpClient(config);
		}


		public async Task<User> RetrieveUserAsync(long userId)
		{
			string userUri = $"v1/users/{userId}";
			_domoHttpClient.SetAcceptRequestHeaders("application/json");
			_domoHttpClient.SetContentType("application/json");

			var response = await _domoHttpClient.Client.GetAsync(userUri);
			string stringResponse = await response.Content.ReadAsStringAsync();
			return JsonConvert.DeserializeObject<User>(stringResponse);
		}

		/// <summary>
		/// Creates a user in Domo
		/// </summary>
		/// <param name="user"></param>
		/// <param name="sendInvite">Will send an invitation email to new user</param>
		/// <returns></returns>
		public async Task<User> CreateUserAsync(User user, bool sendInvite)
		{
			string userId = $"v1/users?sendInvite={sendInvite}";
			_domoHttpClient.SetAcceptRequestHeaders("application/json");
			_domoHttpClient.SetContentType("application/json");

			StringContent content = new StringContent(JsonConvert.SerializeObject(user));
			var response = await _domoHttpClient.Client.PostAsync(userId, content);
			string stringResponse = await response.Content.ReadAsStringAsync();
			return JsonConvert.DeserializeObject<User>(stringResponse);
		}

		public async Task<bool> UpdateUserAsync(long userId, User user)
		{
			string userUri = $"v1/users/{userId}";
			_domoHttpClient.SetAcceptRequestHeaders("application/json");
			_domoHttpClient.SetContentType("application/json");

			StringContent content = new StringContent(JsonConvert.SerializeObject(user));
			var response = await _domoHttpClient.Client.PutAsync(userUri, content);
			return response.IsSuccessStatusCode;
		}
		public async Task<bool> DeleteUserAsync(long userId)
		{
			string userUri = $"v1/users/{userId}";
			_domoHttpClient.SetAcceptRequestHeaders("application/json");

			var response = await _domoHttpClient.Client.DeleteAsync(userUri);
			return response.IsSuccessStatusCode;
		}

		public async Task<IEnumerable<User>> ListUsersAsync(long limit, long offset)
		{
			string userUri = $"v1/users?limit={limit}&offset={offset}";
			_domoHttpClient.SetAcceptRequestHeaders("application/json");
			_domoHttpClient.SetContentType("application/json");

			var response = await _domoHttpClient.Client.GetAsync(userUri);
			string stringResponse = await response.Content.ReadAsStringAsync();
			return JsonConvert.DeserializeObject<IEnumerable<User>>(stringResponse);
		}
	}
}
