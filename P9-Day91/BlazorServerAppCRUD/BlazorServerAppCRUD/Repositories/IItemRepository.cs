using BlazorServerAppCRUD.Data;
using System.Collections.Generic;

namespace BlazorServerAppCRUD.Repositories
{
    public interface IItemRepository
    {
        public Item Save(Item item);
        public Item Update(Item item);
        public Item Get(int itemId);
        public List<Item> GetItems();
        public string Delete(int itemId);
    }
}
