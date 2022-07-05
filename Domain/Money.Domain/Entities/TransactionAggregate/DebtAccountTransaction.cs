using Money.Domain.Entities.AccountAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Money.Domain.Entities.TransactionAggregate
{
    /// <summary>
    /// Транзакція для боргового рахунку
    /// </summary>
    public class DebtAccountTransaction : BaseTransaction
    {
        public int DebtAccountId { get; set; }

        //public DebtAccount DebtAccount { get; set; }
    }
}
