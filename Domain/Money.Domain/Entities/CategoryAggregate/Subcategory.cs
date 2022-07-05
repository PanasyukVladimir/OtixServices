using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Money.Domain.Entities.CategoryAggregate
{
    /// <summary>
    /// Підкатегорія для категорії (Категорія - продукти, підкатегорія - овочі, фрукти, мясо...)
    /// </summary>
    public class Subcategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }

        //public Category Category { get; set; }
    }
}
