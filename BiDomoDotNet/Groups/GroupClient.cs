using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BiDomoDotNet.Groups
{
	public class GroupClient
	{
		private DomoHttpClient _domoHttpClient;

		public GroupClient(DomoConfig config)
		{
			_domoHttpClient = new DomoHttpClient(config);
		}

		public async Task<Group> RetrieveGroupAsync(string groupId)
		{
			string groupUri = $"v1/groups/{groupId}";
			_domoHttpClient.SetContentType("application/json");
			_domoHttpClient.SetAcceptRequestHeaders("application/json");

			var response = await _domoHttpClient.Client.GetAsync(groupUri);
			string stringResponse = await response.Content.ReadAsStringAsync();
			var objectResponse = JsonConvert.DeserializeObject<Group>(stringResponse);
			return objectResponse;
		}

		public async Task<bool> CreateGroupAsync(Group group)
		{
			string groupUri = $"v1/groups";
			_domoHttpClient.SetContentType("application/json");
			_domoHttpClient.SetAcceptRequestHeaders("application/json");
			string groupJson = JsonConvert.SerializeObject(group);
			StringContent content = new StringContent(groupJson);

			var response = await _domoHttpClient.Client.PostAsync(groupUri, content);
			return response.IsSuccessStatusCode;
		}

		public async Task<bool> UpdateGroupAsync(string groupId, Group groupSettings)
		{
			string groupUri = $"v1/groups/{groupId}";
			_domoHttpClient.SetContentType("application/json");
			_domoHttpClient.SetAcceptRequestHeaders("application/json");
			string groupSettingsJson = JsonConvert.SerializeObject(groupSettings);
			StringContent content = new StringContent(groupSettingsJson);

			var response = await _domoHttpClient.Client.PutAsync(groupUri, content);
			return response.IsSuccessStatusCode;
		}

		public async Task<bool> DeleteGroupAsync(string groupId)
		{
			string groupUri = $"v1/groups/{groupId}";
			_domoHttpClient.SetContentType("application/json");
			_domoHttpClient.SetAcceptRequestHeaders("application/json");

			var response = await _domoHttpClient.Client.DeleteAsync(groupUri);
			return response.IsSuccessStatusCode;
		}

		public async Task<IEnumerable<Group>> ListGroupsAsync(int offset, int limit)
		{
			string groupUri = $"v1/groups?offset={offset}&limit={limit}";
			_domoHttpClient.SetAcceptRequestHeaders("application/json");
			_domoHttpClient.SetContentType("application/json");

			var response = await _domoHttpClient.Client.GetAsync(groupUri);
			string stringResponse = await response.Content.ReadAsStringAsync();
			var objectResponse = JsonConvert.DeserializeObject<IEnumerable<Group>>(stringResponse);
			return objectResponse;
		}

		public async Task<bool> AddUserAsync(string groupId, string userId)
		{
			string groupUri = $"v1/groups/{groupId}/users/{userId}";
			_domoHttpClient.SetContentType("application/json");
			_domoHttpClient.SetAcceptRequestHeaders("application/json");

			var response = await _domoHttpClient.Client.PutAsync(groupUri, null);
			return response.IsSuccessStatusCode;
		}

		public async Task<IEnumerable<int>> ListUsersAsync(string groupId, string offset, string limit)
		{
			string groupUri = $"v1/groups/{groupId}/users";
			_domoHttpClient.SetContentType("application/json");
			_domoHttpClient.SetAcceptRequestHeaders("application/json");

			var response = await _domoHttpClient.Client.GetAsync(groupUri);
			string stringResponse = await response.Content.ReadAsStringAsync();
			var users = JsonConvert.DeserializeObject<IEnumerable<int>>(stringResponse);
			return users;
		}

		public async Task<bool> RemoveUserAsync(string groupId, string userId)
		{
			string groupUri = $"v1/groups/{groupId}/users/{userId}";
			_domoHttpClient.SetContentType("application/json");
			_domoHttpClient.SetAcceptRequestHeaders("application/json");

			var response = await _domoHttpClient.Client.DeleteAsync(groupUri);
			return response.IsSuccessStatusCode;
		}
	}
}
