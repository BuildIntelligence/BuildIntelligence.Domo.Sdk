﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BiDomoDotNet.Groups
{
	public class GroupClient : IDomoGroupClient
	{
		private DomoHttpClient _domoHttpClient;

		public GroupClient(IDomoConfig config)
		{
			_domoHttpClient = new DomoHttpClient(config);
		}

		/// <summary>
		/// Retrieves information about a group
		/// </summary>
		/// <param name="groupId"></param>
		/// <returns>Group requested</returns>
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

		/// <summary>
		/// Creates a group
		/// </summary>
		/// <param name="group"></param>
		/// <returns>Boolean whether method is successful</returns>
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

		/// <summary>
		/// Updates an existing group
		/// </summary>
		/// <param name="groupId"></param>
		/// <param name="groupSettings"></param>
		/// <returns>Boolean whether method is successful</returns>
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

		/// <summary>
		/// Permanently deletes a group
		/// </summary>
		/// <param name="groupId"></param>
		/// <returns>Boolean whether method is successful</returns>
		public async Task<bool> DeleteGroupAsync(string groupId)
		{
			string groupUri = $"v1/groups/{groupId}";
			_domoHttpClient.SetContentType("application/json");
			_domoHttpClient.SetAcceptRequestHeaders("application/json");

			var response = await _domoHttpClient.Client.DeleteAsync(groupUri);
			return response.IsSuccessStatusCode;
		}

		/// <summary>
		/// Gets a list of groups
		/// </summary>
		/// <param name="offset"></param>
		/// <param name="limit"></param>
		/// <returns>A list of groups</returns>
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

		/// <summary>
		/// Adds an existing user to a group
		/// </summary>
		/// <param name="groupId"></param>
		/// <param name="userId"></param>
		/// <returns>Boolean whether method is successful</returns>
		public async Task<bool> AddUserAsync(string groupId, string userId)
		{
			string groupUri = $"v1/groups/{groupId}/users/{userId}";
			_domoHttpClient.SetContentType("application/json");
			_domoHttpClient.SetAcceptRequestHeaders("application/json");

			var response = await _domoHttpClient.Client.PutAsync(groupUri, null);
			return response.IsSuccessStatusCode;
		}

		/// <summary>
		/// Lists users in a group
		/// </summary>
		/// <param name="groupId"></param>
		/// <param name="offset"></param>
		/// <param name="limit"></param>
		/// <returns>A list of user Ids</returns>
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

		/// <summary>
		/// Removes a user from a group
		/// </summary>
		/// <param name="groupId"></param>
		/// <param name="userId"></param>
		/// <returns>Boolean whether method is successful</returns>
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
