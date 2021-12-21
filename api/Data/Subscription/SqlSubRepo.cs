using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportSystemAPI.Model;
using Microsoft.EntityFrameworkCore;
using SportSystemAPI.Context;

namespace SportSystemAPI.Data.Subscription
{
    public class SqlSubRepo : ISubRepo
    {
        public SqlSubRepo(SportSystemContext context)
        {
            _context = context;
        }
        private readonly SportSystemContext _context;

        public Task SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<SubModel>> GetSubListAsync()
        {
            var subList = _context.Subs.ToList();

            return await Task.FromResult(subList);
        }

        public async Task<SubModel> GetSubByIdAsync(int id)
        {
            SubModel sub = await _context.Subs.FirstOrDefaultAsync(x => x.Id == id);

            return sub;
        }

        public async Task<SubModel> GetSubByUserIdAsync(int userId)
        {
            SubModel sub = await _context.Subs.FirstOrDefaultAsync(x => x.UserId == userId);

            return sub;
        }

        public async Task CreateSubAsync(SubModel subModel)
        {
            SubModel sub = await _context.Subs.FirstOrDefaultAsync(x => x.UserId == subModel.UserId);
            if (sub is null)
            {
                await _context.Subs.AddAsync(subModel);
            }
            else
            {
                sub.End = subModel.End;
            }
        }

        public async Task UpdateSubAsync(SubModel subModel)
        {
            await Task.CompletedTask;
        }

        public async Task DeleteSubAsync(int id)
        {
            SubModel sub = await _context.Subs.FirstOrDefaultAsync(x => x.UserId == id);
            if (sub is null)
            {
                throw new ArgumentException(nameof(sub));
            }
            await Task.FromResult(_context.Subs.Remove(sub));

        }

    }
}