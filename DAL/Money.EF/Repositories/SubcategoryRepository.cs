using Money.Domain.Entities.CategoryAggregate;
using Money.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Money.EF.Repositories
{
    public class SubcategoryRepository : ISubategoryRepository
    {
        public void CreateSubcategory(Subcategory category)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Subcategory> GetAllSubcategoriesByCategoryId(int categoryId)
        {
            throw new NotImplementedException();
        }

        public Subcategory GetSubcategory(int subcategoryId)
        {
            throw new NotImplementedException();
        }

        public void RemoveSubcategory(Subcategory category)
        {
            throw new NotImplementedException();
        }

        public void UpdateSubcategory(Subcategory category)
        {
            throw new NotImplementedException();
        }
    }
}
