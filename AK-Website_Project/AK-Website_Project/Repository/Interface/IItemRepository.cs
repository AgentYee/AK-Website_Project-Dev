using AK_Website_Project.Models.Entities;
using AK_Website_Project.Models.ViewModels.Item;
using System.Collections.Generic;

namespace AK_Website_Project.Repository.Interface
{
    public interface IItemRepository
    {
        bool CreateItem(ItemViewModel itemViewModel);
        Item GetItem(int itemId);
        bool DeleteItem(int itemId);
        bool EditItem(Item item);
        List<Item> GetAllItems();
    }
}