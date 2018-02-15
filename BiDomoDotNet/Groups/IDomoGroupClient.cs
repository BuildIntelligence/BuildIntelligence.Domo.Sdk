using System.Collections.Generic;
using System.Threading.Tasks;

namespace BiDomoDotNet.Groups
{
    public interface IDomoGroupClient
    {
        /// <summary>
        /// Retrieve a given Domo Group by Id.
        /// </summary>
        /// <param name="groupId">Id of Group to retrieve.</param>
        /// <returns></returns>
        Task<Group> RetrieveGroupAsync(string groupId);

        /// <summary>
        /// Create a Domo Group.
        /// </summary>
        /// <param name="group"></param>
        /// <returns></returns>
        Task<bool> CreateGroupAsync(Group group);

        /// <summary>
        /// Update a given Domo Group by Id.
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="groupSettings"></param>
        /// <returns></returns>
        Task<bool> UpdateGroupAsync(string groupId, Group groupSettings);

        /// <summary>
        /// Delete a Domo Group by Id.
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        Task<bool> DeleteGroupAsync(string groupId);

        /// <summary>
        /// Retrieve a List of Groups with a given limit on list size and a given starting offset
        /// </summary>
        /// <param name="offset"></param>
        /// <param name="limit">Max Number of Groups to return. The max limit is 500</param>
        /// <returns></returns>
        Task<IEnumerable<Group>> ListGroupsAsync(int offset, int limit);

        /// <summary>
        /// Add a Domo user to a given group.
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<bool> AddUserAsync(string groupId, string userId);

        /// <summary>
        /// Retrieve list of Domo Users in a given group.
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="offset">Offset of users to start list from</param>
        /// <param name="limit">Max number of users to return. the max limit is 500.</param>
        /// <returns></returns>
        Task<IEnumerable<int>> ListUsersAsync(string groupId, string offset, int limit);

        /// <summary>
        /// Remove a user from a Group.
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<bool> RemoveUserAsync(string groupId, string userId);
    }
}
