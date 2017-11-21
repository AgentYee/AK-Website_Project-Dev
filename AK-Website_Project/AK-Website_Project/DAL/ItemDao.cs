using System.Collections.Generic;
using AK_Website_Project.DAL.Interface;
using AK_Website_Project.Models.Entities;
using System.Linq;
using System.Data.Entity;

namespace AK_Website_Project.DAL
{
    public class ItemDao : IItemDao
    {
        public bool CreateItem(Item item)
        {
            int result = -1;
            using (Entities ctx = new Entities())
            {
                ctx.Items.Add(item);
                result = ctx.SaveChanges();
            }

            if (result == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteItem(int itemId)
        {
            int result = -1;
            using (Entities ctx = new Entities())
            {
                ctx.Items.Remove(ctx.Items.FirstOrDefault(x => x.ItemId == itemId));
                result = ctx.SaveChanges();
            }

            if (result == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool EditItem(Item item)
        {
            using (Entities ctx = new Entities())
            {
                if (item == null)
                    return false;

                ctx.Entry(item).State = EntityState.Modified;

                int result = ctx.SaveChanges();

                return result >= 1 ? true : false;
            }
        }

        public List<Item> GetAllItems()
        {
            using (Entities ctx = new Entities())
            {
                var list = ctx.Items;

                if (list != null)
                    return list.ToList();

                return new List<Item>();
            }
        }

        public Item GetItem(int itemId)
        {
            using (Entities ctx = new Entities())
            {
                Item item = ctx.Items
                     .Include(x => x.Comments)
                     .Include(x => x.Comments.Select(c => c.User))
                     .Include(x => x.QualityLevel)
                     .Include(x => x.SubCategory)
                     .Include(x => x.SubCategory.Category)
                     .FirstOrDefault(x => x.ItemId == itemId);

                if (item != null)
                {
                    return item;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}