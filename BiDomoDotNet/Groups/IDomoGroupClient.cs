using System.Collections.Generic;
using System.Threading.Tasks;

namespace BiDomoDotNet.Groups
{
    public interface IDomoGroupClient
    {
        Task<Group> RetrieveGroupAsync(string groupId);
        Task<bool> CreateGroupAsync(Group group);
        Task<bool> UpdateGroupAsync(string groupId, Group groupSettings);
        Task<bool> DeleteGroupAsync(string groupId);
        Task<IEnumerable<Group>> ListGroupsAsync(int offset, int limit);
        Task<bool> AddUserAsync(string groupId, string userId);
        Task<IEnumerable<int>> ListUsersAsync(string groupId, string offset, string limit);
        Task<bool> RemoveUserAsync(string groupId, string userId);
    }
}
