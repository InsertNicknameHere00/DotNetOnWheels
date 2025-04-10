using CarManagerAPI.Data;
using CarManagerAPI.Entities;
using CarManagerAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Reflection.Metadata.Ecma335;

namespace CarManagerAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly CarDbContext _context;

        public UserRepository(CarDbContext context)
        {
            _context = context;
        }

        public async Task<User> CreateUserAsync(User user)
        {
            var tempUser = await _context.Users.FindAsync(user.Id);
            if (tempUser == null)
            {
                var newUser = new User();
                newUser.Name = user.Name;
                newUser.Email = user.Email;
                newUser.Password = user.Password;
                newUser.RoleID = 2;
            _context.Add(newUser);
          await _context.SaveChangesAsync();
            return tempUser;
        }
      return null;
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var tempUser = _context.Users.FindAsync(id);
            if (tempUser != null) {
                 _context.Remove(tempUser);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            var tempList = await _context.Users.ToListAsync();
            if (tempList != null)
            {
                return tempList;
            }
            return null;
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            var tempUser = await _context.Users.FindAsync(id);
            if (tempUser != null) {
                return tempUser;
            }
            return null;
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            var tempUser = await _context.Users.FindAsync(user.Id);
            if (tempUser != null)
            {
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
                return tempUser;
            }
            return null;
        }
    }
}
