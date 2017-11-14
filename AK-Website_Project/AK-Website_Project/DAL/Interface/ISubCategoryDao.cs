﻿using AK_Website_Project.Models.Entities;
using System.Collections.Generic;

namespace AK_Website_Project.DAL.Interface
{
    public interface ISubCategoryDao
    {
        List<SubCategory> GetAllSubCategories();
        List<SubCategory> GetSubCategoriesByParentId(int categoryId);
        SubCategory GetSubCategory(int subId);
    }
}
