using Money.Domain.Entities.TransactionAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Money.Domain.Entities.AccountAggregate
{
    public enum TypeRegularAccountEnum
    {
        Card = 1,
        Cash = 2
    }
    /// <summary>
    /// Usual account (Cash/card)
    /// </summary>
    public class RegularAccount : BaseAccount
    {
        public double CreditLimit { get; set; }
        public TypeRegularAccountEnum TypeRegularAccount { get; set; }
        public int UserId { get; set; }

        //public User User { get; set; }
        public List<RegularAccountTransaction> RegularAccountTransactions { get; set; }
    }
}
