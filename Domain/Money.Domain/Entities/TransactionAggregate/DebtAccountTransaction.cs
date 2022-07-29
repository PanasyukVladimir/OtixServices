using Money.Domain.Entities.AccountAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Money.Domain.Entities.TransactionAggregate
{
    public enum TypeDebtAccountTransactionEnum
    {
        Expenses = 1,
        Income = 2
    }
    /// <summary>
    /// A transaction for a debit account
    /// </summary>
    public class DebtAccountTransaction : BaseTransaction
    {
        public TypeDebtAccountTransactionEnum TypeDebtAccountTransaction { get; set; }
        public int DebtAccountId { get; set; }

        //public DebtAccount DebtAccount { get; set; }
    }
}
