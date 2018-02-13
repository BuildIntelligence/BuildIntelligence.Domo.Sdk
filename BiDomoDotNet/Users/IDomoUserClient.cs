using System.Collections.Generic;
using System.Threading.Tasks;

namespace BiDomoDotNet.Users
{
    public interface IDomoUserClient
    {
        /// <summary>
        /// Retreives a given Domo User by User Id
        /// </summary>
        /// <param name="userId">Id of user to retreive</param>
        /// <returns>Returns a Domo User. <see cref="BiDomoDotNet.Users.DomoUser"/></returns>
        Task<DomoUser> RetrieveUserAsync(long userId);

        /// <summary>
		/// Create a Domo User
		/// </summary>
		/// <param name="user">Properties and values for the user being created</param>
		/// <param name="sendInvite">Whether or not to send a "You Just Got Domo'd!" invitation email to new user</param>
		/// <returns>Returns the created Domo User. <see cref="BiDomoDotNet.Users.DomoUser"/></returns>
        Task<DomoUser> CreateUserAsync(DomoUser user, bool sendInvite);

        /// <summary>
        /// Update a given Domo User by User Id
        /// </summary>
        /// <param name="userId">Id of Domo User to Update.</param>
        /// <param name="user">Domo User Info to update to.</param>
        /// <returns>Returns a bool of whether the Domo User was succesfully updated.</returns>
        Task<bool> UpdateUserAsync(long userId, DomoUser user);

        /// <summary>
        /// Delete a given Domo User by User Id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>Returns a bool of whether or not the Domo User was successfully deleted</returns>
        Task<bool> DeleteUserAsync(long userId);

        /// <summary>
        /// Retreive a list of users up to the specified limit, starting at a given offset
        /// </summary>
        /// <param name="limit">Max number of users to return. Maximum amount of users to return is 500.</param>
        /// <param name="offset">Offset of users to begin the list of users from.</param>
        /// <returns>Returns a list of Domo Users. <see cref="BiDomoDotNet.Users.DomoUser"/></returns>
        Task<IEnumerable<DomoUser>> ListUsersAsync(long limit, long offset);
    }
}
