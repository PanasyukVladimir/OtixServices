using Money.Domain.Entities.TransactionAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Money.Domain.Entities.AccountAggregate
{
    /// <summary>
    /// Debt account
    /// </summary>
    public class DebtAccount : BaseAccount
    {
        public string UserId { get; set; }

        //public User User { get; set; }
        public List<DebtAccountTransaction> DebtAccountTransactions { get; set; }
    }
}
