using AK_Website_Project.Models.Entities;
using System.Collections.Generic;

namespace AK_Website_Project.DAL.Interface
{
    public interface ICategoryDao
    {
        List<Category> GetCategoryList();
        Category GetCategory(int id);
    }
}