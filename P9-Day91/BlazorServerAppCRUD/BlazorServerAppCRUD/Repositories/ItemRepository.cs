using BlazorServerAppCRUD.Data;
using System.Collections.Generic;
using System.Linq;

namespace BlazorServerAppCRUD.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly AppDbContext _context;
        public ItemRepository(AppDbContext context)
        {
            _context = context;
        }
        public string Delete(int itemId)
        {
            var item = _context.Items.FirstOrDefault(x => x.ItemId == itemId);
            _context.Items.Remove(item);
            _context.SaveChanges();
            return "Deleted";
        }

        public Item Get(int itemId)
        {
            return _context.Items.FirstOrDefault(i => i.ItemId == itemId);
        }

        public List<Item> GetItems()
        {
            return _context.Items.ToList();
        }

        public Item Save(Item item)
        {
            _context.Items.Add(item);
            _context.SaveChanges();
            return this.Get(item.ItemId);
        }

        public Item Update(Item item)
        {
            _context.Items.Update(item);
            _context.SaveChanges();
            return this.Get(item.ItemId); ;
        }
    }
}
