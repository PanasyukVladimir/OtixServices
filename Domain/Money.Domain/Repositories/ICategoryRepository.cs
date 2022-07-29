using Money.Domain.Entities.CategoryAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Money.Domain.Repositories
{
    public interface ICategoryRepository
    {
        Category GetCategoryById(int categoryId);
        IEnumerable<Category> GetAllCategoriesByUserId(string userId);
        void CreateCategory(Category category);
        void UpdateCategory(Category category);
        void RemoveCategory(Category category);
    }
}
