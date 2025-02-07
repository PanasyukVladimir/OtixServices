﻿using Money.Domain.Entities.CategoryAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Money.Domain.Repositories
{
    public interface ISubategoryRepository
    {
        Subcategory GetSubcategoryById(int categoryId);
        IEnumerable<Subcategory> GetAllSubcategoriesByCategoryId(int categoryId);
        void CreateSubcategory(Subcategory subcategory);
        void UpdateSubcategory(Subcategory subcategory);
        void RemoveSubcategory(Subcategory subcategory);
    }
}
