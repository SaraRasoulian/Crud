using sage.challenge.data.Entities;
using sage.challenge.model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sage.challenge.repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserViewModel>> GetUsers();
        Task<UserViewModel> GetUserById(int userId);
        Task<User> AddUser(User user);
        Task<User> UpdateUser(User user);
        Task<User> DeleteUser(int userId);
        Task<bool> IsEmailUnique(string email, int currentUserId = 0);
    }
}
