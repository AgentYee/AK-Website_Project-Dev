using AK_Website_Project.Models.Entities;
using System.Collections.Generic;

namespace AK_Website_Project.Repository.Interface
{
    public interface ICategoryRepository
    {
        List<Category> GetCategoryList();
        Category GetCategory(int id);
    }
}
