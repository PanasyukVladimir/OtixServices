using Microsoft.EntityFrameworkCore;
using Money.Domain.Entities.CategoryAggregate;
using Money.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Money.EF.Repositories
{
    public class SubcategoryRepository : ISubategoryRepository
    {
        private readonly MoneyContext _context;
        public SubcategoryRepository(MoneyContext context)
        {
            _context = context;
        }

        public IEnumerable<Subcategory> GetAllSubcategoriesByCategoryId(int categoryId)
        {
            return _context.Subcategories.Where(c => c.CategoryId == categoryId);
        }

        public Subcategory GetSubcategory(int subcategoryId)
        {
            return _context.Subcategories.FirstOrDefault(c => c.Id == subcategoryId);
        }
        public void CreateSubcategory(Subcategory subcategory)
        {
            _context.Subcategories.Add(subcategory);
            _context.SaveChanges();
        }

        public void RemoveSubcategory(Subcategory subcategory)
        {
            _context.Subcategories.Remove(subcategory);
            _context.SaveChanges();
        }

        public void UpdateSubcategory(Subcategory subcategory)
        {
            _context.Subcategories.Attach(subcategory);
            _context.Entry(subcategory).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
