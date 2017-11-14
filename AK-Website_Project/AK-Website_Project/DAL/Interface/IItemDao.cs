using AK_Website_Project.Models.Entities;
using System.Collections.Generic;

namespace AK_Website_Project.DAL.Interface
{
    public interface IItemDao
    {
        bool CreateItem(Item item);
        Item GetItem(int itemId);
        bool DeleteItem(int itemId);
        bool EditItem(Item item);
        List<Item> GetAllItems();
    }
}
