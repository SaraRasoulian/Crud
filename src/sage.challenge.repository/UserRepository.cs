using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using sage.challenge.data.Entities;
using sage.challenge.model;
using sage.challenge.framework;

namespace sage.challenge.repository
{
    public class UserRepository : IUserRepository
    {
        private readonly CrudContext crudContext;

        public UserRepository(CrudContext crudContext)
        {
            this.crudContext = crudContext;
        }

        public async Task<IEnumerable<UserViewModel>> GetUsers()
        {
            IEnumerable<User> userList = await crudContext.Users.ToListAsync();

            Helper helper = new Helper();
            List<UserViewModel> userViewModelList = new List<UserViewModel>();

            foreach (User item in userList)
            {
                UserViewModel model = new UserViewModel
                {
                    Id = item.Id,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Email = item.Email,
                    Age = helper.CalculateAgeByDateOfBirth(item.DateOfBirth),
                    DateOfBirth = item.DateOfBirth,
                };
                userViewModelList.Add(model);
            }
            return userViewModelList;
        }

        public async Task<UserViewModel> GetUserById(int userId)
        {
            User user = await crudContext.Users
                .FirstOrDefaultAsync(e => e.Id == userId);

            if (user != null)
            {
                Helper helper = new Helper();

                var viewModel = new UserViewModel
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Age = helper.CalculateAgeByDateOfBirth(user.DateOfBirth),
                    DateOfBirth = user.DateOfBirth,
                };

                return viewModel;
            }
            return null;
        }

        public async Task<bool> IsEmailUnique(string email, int currentUserId = 0)
        {
            User user = await crudContext.Users
                .FirstOrDefaultAsync(e => e.Email == email);
            if (user == null || user.Id == currentUserId)
                return true;
            return false;
        }

        public async Task<User> AddUser(User user)
        {
            var result = await crudContext.Users.AddAsync(user);
            await crudContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<User> UpdateUser(User user)
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
