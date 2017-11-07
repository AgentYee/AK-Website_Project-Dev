using AK_Website_Project.Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace AK_Website_Project.DAL
{
    public class CategoryDao
    {
        public List<Category> GetCategoryList()
        {
            using (Entities ctx = new Entities())
            {
                var list = ctx.Categories;

                if (list != null)
                    return list.ToList();

                return new List<Category>();
            }
        }
    }
}