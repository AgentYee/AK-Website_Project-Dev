using AK_Website_Project.Repository.Interface;
using System;
using System.Collections.Generic;
using AK_Website_Project.Models.Entities;
using AK_Website_Project.Models.ViewModels.Item;
using AK_Website_Project.DAL.Interface;

namespace AK_Website_Project.Repository
{
    public class ItemRepository : IItemRepository
    {
        private readonly IItemDao dao;

        public ItemRepository(IItemDao dao)
        {
            this.dao = dao;
        }

        public bool CreateItem(ItemViewModel itemViewModel)
        {
            Item item = new Item();
            item.Name = itemViewModel.Name;
            item.QualityLevel = itemViewModel.QualityLevel;
            item.SubCategoryId = itemViewModel.SubCategoryId;

            return dao.CreateItem(item);
        }

        public bool DeleteItem(int itemId)
        {
            return dao.DeleteItem(itemId);
        }

        public bool EditItem(Item item)
        {
            throw new NotImplementedException();
        }

        public List<Item> GetAllItems()
        {
            return dao.GetAllItems();
        }

        public Item GetItem(int itemId)
        {
            return dao.GetItem(itemId);
        }
    }
}