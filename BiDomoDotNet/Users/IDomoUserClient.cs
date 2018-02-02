using System.Collections.Generic;
using System.Threading.Tasks;

namespace BiDomoDotNet.Users
{
    public interface IDomoUserClient
    {
        Task<User> RetrieveUserAsync(long userId);
        Task<User> CreateUserAsync(User user, bool sendInvite);
        Task<bool> UpdateUserAsync(long userId, User user);
        Task<bool> DeleteUserAsync(long userId);
        Task<IEnumerable<User>> ListUsersAsync(long limit, long offset);
    }
}
