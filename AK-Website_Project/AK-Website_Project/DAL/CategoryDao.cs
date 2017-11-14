﻿using AK_Website_Project.DAL.Interface;
using AK_Website_Project.Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace AK_Website_Project.DAL
{
    public class CategoryDao : ICategoryDao
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