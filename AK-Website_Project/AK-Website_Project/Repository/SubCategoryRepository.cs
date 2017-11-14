using System.Collections.Generic;
using AK_Website_Project.Models.Entities;
using AK_Website_Project.Repository.Interface;
using AK_Website_Project.DAL.Interface;

namespace AK_Website_Project.Repository
{
    public class SubCategoryRepository : ISubCategoryRepository
    {
        private readonly ISubCategoryDao dao;

        public SubCategoryRepository(ISubCategoryDao dao)
        {
            this.dao = dao;
        }

        public List<SubCategory> GetAllSubCategories()
        {
            return dao.GetAllSubCategories();
        }

        public List<SubCategory> GetSubCategoriesByParentId(int categoryId)
        {
            return dao.GetSubCategoriesByParentId(categoryId);
        }

        public SubCategory GetSubCategory(int subId)
        {
            return dao.GetSubCategory(subId);
        }
    }
}