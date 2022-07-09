using Money.Domain.Entities.TransactionAggregate;
using Money.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Money.EF.Repositories
{
    public class RegularTransactionRepository : ITransactionRepository<RegularAccountTransaction>
    {
        public IEnumerable<RegularAccountTransaction> GetAllTransactionsBy(int accountId)
        {
            throw new NotImplementedException();
        }

        public RegularAccountTransaction GetTransaction(int transactionId)
        {
            throw new NotImplementedException();
        }

        public void CreateTransaction(RegularAccountTransaction transaction)
        {
            throw new NotImplementedException();
        }

        public void RemoveTransaction(RegularAccountTransaction transaction)
        {
            throw new NotImplementedException();
        }

        public void UpdateTransaction(RegularAccountTransaction transaction)
        {
            throw new NotImplementedException();
        }
    }
}
