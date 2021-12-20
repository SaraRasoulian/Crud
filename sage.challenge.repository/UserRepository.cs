using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using sage.challenge.data.Entities;

namespace sage.challenge.repository
{
    public class UserRepository : IUserRepository
    {
        private readonly CrudContext crudContext;

        public UserRepository(CrudContext crudContext)
        {
            this.crudContext = crudContext;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await crudContext.Users.ToListAsync();
        }

        public async Task<User> GetUserById(int userId)
        {
            return await crudContext.Users
                .FirstOrDefaultAsync(e => e.Id == userId);
        }

        public async Task<User> GetUserByEmail(string email)
        {
            User result = await crudContext.Users
                .FirstOrDefaultAsync(e => e.Email == email);
            return result;
        }

        public async Task<User> AddUser(User user)
        {
            var result = await crudContext.Users.AddAsync(user);
            await crudContext.SaveChangesAsync();
            return result.Entity;     
        }

        public async Task<User> UpdateUser(User user)
        {
            try
            {
                var result = await crudContext.Users
                .FirstOrDefaultAsync(e => e.Id == user.Id);

                if (result != null)
                {
                    result.FirstName = user.FirstName;
                    result.LastName = user.LastName;
                    result.Email = user.Email;
                    result.DateOfBirth = user.DateOfBirth;

                    await crudContext.SaveChangesAsync();

                    return result;
                }

                return null;
            }
            catch (System.Exception e)
            {
                throw;
            }            
        }

        public async Task<User> DeleteUser(int userId)
        {
            var result = await crudContext.Users
                .FirstOrDefaultAsync(e => e.Id == userId);
            if (result != null)
            {
                crudContext.Users.Remove(result);
                await crudContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
