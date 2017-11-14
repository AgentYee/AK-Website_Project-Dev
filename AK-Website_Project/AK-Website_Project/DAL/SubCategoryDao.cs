using AK_Website_Project.DAL.Interface;
using System.Collections.Generic;
using System.Linq;
using AK_Website_Project.Models.Entities;

namespace AK_Website_Project.DAL
{
    public class SubCategoryDao : ISubCategoryDao
    {
        public List<SubCategory> GetAllSubCategories()
        {
            using (Entities ctx = new Entities())
            {
                var list = ctx.SubCategories;

                if (list != null)
                    return list.ToList();

                return new List<SubCategory>();
            }
        }

        public List<SubCategory> GetSubCategoriesByParentId(int categoryId)
        {
            using (Entities ctx = new Entities())
            {
                var list = ctx.SubCategories.Where(x => x.ParentCategoryId == categoryId);

                if (list != null)
                    return list.ToList();

                return new List<SubCategory>();
            }
        }

        public SubCategory GetSubCategory(int subId)
        {
            using (Entities ctx = new Entities())
            {
                var subCategory = ctx.SubCategories.Select(x => x.SubCategoryId == subId);

                if (subCategory != null)
                    return subCategory as SubCategory;

                return new SubCategory();
            }
        }
    }
}