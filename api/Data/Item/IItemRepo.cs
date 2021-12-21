using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportSystemAPI.Model;

namespace SportSystemAPI.Data.Item
{
    public interface IItemRepo
    {
        Task SaveChangesAsync();
        Task<IEnumerable<ItemModel>> GetItemListAsync();
        Task<ItemModel> GetItemByIdAsync(int id);
        Task<ItemModel> GetItemByNameAsync(string name);
        Task<List<ItemModel>> GetItemListByUserIdAsync(int userId);
        Task CreateItemAsync(ItemModel itemModel);
        Task UpdateItemAsync(ItemModel itemModel);
        Task DeleteItemAsync(ItemModel itemModel);

    }
}