using Money.Domain.Entities.CategoryAggregate;
using Money.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Money.EF.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        public void CreateCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> GetAllCategoriesByUserId(int userId)
        {
            throw new NotImplementedException();
        }

        public Category GetCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public void RemoveCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public void UpdateCategory(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
