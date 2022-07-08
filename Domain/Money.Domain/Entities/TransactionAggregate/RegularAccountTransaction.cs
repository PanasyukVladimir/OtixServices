using Money.Domain.Entities.AccountAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Money.Domain.Entities.TransactionAggregate
{
    /// <summary>
    /// A transaction between regular accounts
    /// </summary>
    public class RegularAccountTransaction : BaseTransaction
    {
        public int RegularAccountId { get; set; }

        //public RegularAccount RegularAccount { get; set; }
    }
}
