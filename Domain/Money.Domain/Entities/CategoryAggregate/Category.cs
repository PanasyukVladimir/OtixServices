using Money.Domain.Entities.TransactionAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Money.Domain.Entities.CategoryAggregate
{
    public enum CategoryCurrencyEnum
    {
        USD = 1,
        UAH = 2,
        EUR = 3
    }
    public enum TypeCategoryEnum
    {
        Expenses = 1,
        Income = 2
    }
    /// <summary>
    /// Category of expenses or income
    /// </summary>
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CategoryCurrencyEnum CategoryCurrency { get; set; }
        public string Description { get; set; }
        public double Balance { get; set; }
        public TypeCategoryEnum TypeCategory { get; set; }
        public int UserId { get; set; }

        //public User User { get; set; }
        public List<DefaultTransaction> DefaultTransactions { get; set; }
        public List<Subcategory> Subcategories { get; set; }
    }
}
