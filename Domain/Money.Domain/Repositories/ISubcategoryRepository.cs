using Money.Domain.Entities.CategoryAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Money.Domain.Repositories
{
    public interface ISubategoryRepository
    {
        Subcategory GetSubcategory(int subcategoryId);
        IEnumerable<Subcategory> GetAllSubcategoriesByCategoryId(int categoryId);
        void CreateSubcategory(Subcategory category);
        void UpdateSubcategory(Subcategory category);
        void RemoveSubcategory(Subcategory category);
    }
}
