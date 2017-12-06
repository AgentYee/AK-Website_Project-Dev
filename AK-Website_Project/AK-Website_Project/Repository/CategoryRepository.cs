using System.Collections.Generic;
using AK_Website_Project.Models.Entities;
using AK_Website_Project.Repository.Interface;
using AK_Website_Project.DAL.Interface;

namespace AK_Website_Project.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ICategoryDao dao;

        public CategoryRepository(ICategoryDao dao)
        {
            this.dao = dao;
        }

        public List<Category> GetCategoryList()
        {
            return dao.GetCategoryList();
        }

        public Category GetCategory(int id)
        {
            return dao.GetCategory(id);
        }
    }
}