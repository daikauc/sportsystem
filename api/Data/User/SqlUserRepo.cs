using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportSystemAPI.Model;
using Microsoft.EntityFrameworkCore;
using SportSystemAPI.Context;

namespace SportSystemAPI.Data.User
{
    public class SqlUserRepo : IUserRepo
    {
        public SqlUserRepo(SportSystemContext context)
        {
            _context = context;
        }
        private readonly SportSystemContext _context;

        public Task SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<UserModel>> GetUserListAsync()
        {
            var userList = _context.Users.ToList();

            return await Task.FromResult(userList);
        }

        public async Task<UserModel> GetUserByIdAsync(int id)
        {
            UserModel user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);

            return user;
        }

        public async Task<UserModel> GetUserByLoginAsync(string login)
        {
            UserModel user = await _context.Users.FirstOrDefaultAsync(x => x.Login == login);

            return user;
        }

        public async Task CreateUserAsync(UserModel userModel)
        {
            await _context.Users.AddAsync(userModel);
        }

        public async Task UpdateUserAsync(UserModel userModel)
        {
            await Task.CompletedTask;
        }

        public async Task DeleteUserAsync(int id)
        {
            UserModel user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user is null)
            {
                throw new ArgumentException(nameof(user));
            }
            await Task.FromResult(_context.Users.Remove(user));

        }

    }
}