using Money.Domain.Entities.TransactionAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Money.Domain.Entities.AccountAggregate
{
    /// <summary>
    /// Accumulation account
    /// </summary>
    public class SavingAccount : BaseAccount
    {
        public double GoalSavingBalance { get; set; }
        public string UserId { get; set; }

        //public User User { get; set; }
        public List<SavingAccountTransaction> SavingAccountTransactions { get; set; }
    }
}
