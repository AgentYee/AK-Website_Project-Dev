using AK_Website_Project.DAL.Interface;
using AK_Website_Project.Models.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace AK_Website_Project.DAL
{
    public class CategoryDao : ICategoryDao
    {
        public Category GetCategory(int id)
        {
            using (Entities ctx = new Entities())
            {
                var category = ctx.Categories.FirstOrDefault(x => x.CategoryId == id);

                if (category != null)
                    return category as Category;

                return new Category();
            }
        }

        public List<Category> GetCategoryList()
        {
            using (Entities ctx = new Entities())
            {
                var list = ctx.Categories
                    .Include(x => x.SubCategories);

                if (list != null)
                    return list.ToList();

                return new List<Category>();
            }
        }
    }
}