using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Money.Domain.Entities.CategoryAggregate
{
    /// <summary>
    /// Subcategory for the category (Category - products, subcategory - vegetables, fruits, meat...)
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
