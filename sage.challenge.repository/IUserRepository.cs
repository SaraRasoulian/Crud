using sage.challenge.data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sage.challenge.repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUserById(int userId);
        Task<User> GetUserByEmail(string email);
        Task<User> AddUser(User user);
        Task<User> UpdateUser(User user);
        Task<User> DeleteUser(int userId);
    }
}
