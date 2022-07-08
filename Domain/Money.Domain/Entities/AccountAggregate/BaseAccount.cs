using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Money.Domain.Entities.AccountAggregate
{
    public enum AccountCurrencyEnum
    {
        USD = 1, 
        UAH = 2,
        EUR = 3
    }
    /// <summary>
    /// Abstract class for account
    /// </summary>
    public abstract class BaseAccount
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public AccountCurrencyEnum AccountCurrency { get; set; }
        public string Description { get; set; }
        public double Balance { get; set; }
    }
}
