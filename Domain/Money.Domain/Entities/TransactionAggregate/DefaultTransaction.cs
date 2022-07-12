using Money.Domain.Entities.CategoryAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Money.Domain.Entities.TransactionAggregate
{
    /// <summary>
    /// Transaction for expenses/revenues
    /// </summary>
    public class DefaultTransaction : BaseTransaction
    {
        public int CategoryId { get; set; }
        public int? SubcategoryId { get; set; }

        //public Category Category { get; set; }
    }
}
