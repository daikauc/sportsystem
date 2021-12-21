using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportSystemAPI.Model;

namespace SportSystemAPI.Data.Subscription
{
    public interface ISubRepo
    {
        Task SaveChangesAsync();
        Task<IEnumerable<SubModel>> GetSubListAsync();
        Task<SubModel> GetSubByIdAsync(int id);
        Task<SubModel> GetSubByUserIdAsync(int userId);
        Task CreateSubAsync(SubModel subModel);
        Task UpdateSubAsync(SubModel subModel);
        Task DeleteSubAsync(int id);
    }
}