using Microsoft.EntityFrameworkCore;
using Money.Domain.Entities.CategoryAggregate;
using Money.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Money.EF.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly MoneyContext _context;
        public CategoryRepository(MoneyContext context)
        {
            _context = context;
        }

        public IEnumerable<Category> GetAllCategoriesByUserId(int userId)
        {
            return _context.Categories.Where(c => c.UserId == userId);
        }

        public Category GetCategoryById(int categoryId)
        {
            return _context.Categories.FirstOrDefault(c => c.Id == categoryId);
        }
        public void CreateCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public void RemoveCategory(Category category)
        {
            _context.Categories.Remove(category);
            _context.SaveChanges();
        }

        public void UpdateCategory(Category category)
        {
            _context.Categories.Attach(category);
            _context.Entry(category).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
