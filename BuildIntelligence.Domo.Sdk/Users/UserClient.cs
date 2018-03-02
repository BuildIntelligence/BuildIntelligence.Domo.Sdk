using BuildIntelligence.Domo.Sdk.Exceptions;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BuildIntelligence.Domo.Sdk.Users
{
    public class UserClient : IDomoUserClient
	{
		public DomoHttpClient _domoHttpClient;

		public UserClient(IDomoConfig config)
		{
			_domoHttpClient = new DomoHttpClient(config);
		}

		/// <summary>
		/// Retreives a given Domo User by User Id
		/// </summary>
		/// <param name="userId">Id of user to retreive</param>
		/// <returns>Returns a Domo User. <see cref="BuildIntelligence.Domo.Sdk.Users.DomoUser"/></returns>
		public async Task<DomoUser> RetrieveUserAsync(long userId)
		{
			string userUri = $"v1/users/{userId}";
			_domoHttpClient.SetAcceptRequestHeaders("application/json");

			var response = await _domoHttpClient.Client.GetAsync(userUri);
			string stringResponse = await response.Content.ReadAsStringAsync();
			return JsonConvert.DeserializeObject<DomoUser>(stringResponse);
		}

		/// <summary>
		/// Create a Domo User
		/// </summary>
		/// <param name="user">Properties and values for the user being created</param>
		/// <param name="sendInvite">Whether or not to send a "You Just Got Domo'd!" invitation email to new user</param>
		/// <returns>Returns the created Domo User. <see cref="BuildIntelligence.Domo.Sdk.Users.DomoUser"/></returns>
		public async Task<DomoUser> CreateUserAsync(DomoUser user, bool sendInvite)
		{
			string userId = $"v1/users?sendInvite={sendInvite}";
			_domoHttpClient.SetAcceptRequestHeaders("application/json");

			StringContent content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
			var response = await _domoHttpClient.Client.PostAsync(userId, content);
			string stringResponse = await response.Content.ReadAsStringAsync();
			return JsonConvert.DeserializeObject<DomoUser>(stringResponse);
		}

		/// <summary>
		/// Update a given Domo User by User Id
		/// </summary>
		/// <param name="userId">Id of Domo User to Update.</param>
		/// <param name="user">Domo User Info to update to.</param>
		/// <returns>Returns a bool of whether the Domo User was succesfully updated.</returns>
		public async Task<bool> UpdateUserAsync(long userId, DomoUser user)
		{
			string userUri = $"v1/users/{userId}";
			_domoHttpClient.SetAcceptRequestHeaders("application/json");

			StringContent content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
			var response = await _domoHttpClient.Client.PutAsync(userUri, content);
			return response.IsSuccessStatusCode;
		}

		/// <summary>
		/// Delete a given Domo User by User Id
		/// </summary>
		/// <param name="userId"></param>
		/// <returns>Returns a bool of whether or not the Domo User was successfully deleted</returns>
		public async Task<bool> DeleteUserAsync(long userId)
		{
			string userUri = $"v1/users/{userId}";
			_domoHttpClient.SetAcceptRequestHeaders("application/json");
			
			var response = await _domoHttpClient.Client.DeleteAsync(userUri);
			return response.IsSuccessStatusCode;
		}

		/// <summary>
		/// Retreive a list of users up to the specified limit, starting at a given offset
		/// </summary>
		/// <param name="limit">Max number of users to return. Maximum amount of users to return is 500.</param>
		/// <param name="offset">Offset of users to begin the list of users from.</param>
		/// <returns>Returns a list of Domo Users. <see cref="BuildIntelligence.Domo.Sdk.Users.DomoUser"/></returns>
		public async Task<IEnumerable<DomoUser>> ListUsersAsync(long limit, long offset)
		{
            if (limit > 500) throw new LimitNotWithinBoundsException($"The list limit of {limit} used is above the max limit. The maximum limit is 500");
            if (limit < 0) throw new LimitNotWithinBoundsException($"List limit {limit} cannot be used. Use a limit value between 1 and 500");

            string userUri = $"v1/users?limit={limit}&offset={offset}";
			_domoHttpClient.SetAcceptRequestHeaders("application/json");

			var response = await _domoHttpClient.Client.GetAsync(userUri);
			string stringResponse = await response.Content.ReadAsStringAsync();
			return JsonConvert.DeserializeObject<IEnumerable<DomoUser>>(stringResponse);
		}
	}
}
