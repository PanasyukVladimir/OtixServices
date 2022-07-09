using Money.Domain.Entities.TransactionAggregate;
using Money.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Money.EF.Repositories
{
    public class DefaultTransactionRepository : ITransactionRepository<DefaultTransaction>
    {
        public IEnumerable<DefaultTransaction> GetAllTransactionsBy(int accountId)
        {
            throw new NotImplementedException();
        }

        public DefaultTransaction GetTransaction(int transactionId)
        {
            throw new NotImplementedException();
        }
        public void CreateTransaction(DefaultTransaction transaction)
        {
            throw new NotImplementedException();
        }

        public void RemoveTransaction(DefaultTransaction transaction)
        {
            throw new NotImplementedException();
        }

        public void UpdateTransaction(DefaultTransaction transaction)
        {
            throw new NotImplementedException();
        }
    }
}
