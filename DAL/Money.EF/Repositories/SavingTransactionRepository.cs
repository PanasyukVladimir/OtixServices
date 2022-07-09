using Money.Domain.Entities.TransactionAggregate;
using Money.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Money.EF.Repositories
{
    public class SavingTransactionRepository : ITransactionRepository<SavingAccountTransaction>
    {
        public IEnumerable<SavingAccountTransaction> GetAllTransactionsBy(int accountId)
        {
            throw new NotImplementedException();
        }

        public SavingAccountTransaction GetTransaction(int transactionId)
        {
            throw new NotImplementedException();
        }

        public void CreateTransaction(SavingAccountTransaction transaction)
        {
            throw new NotImplementedException();
        }

        public void RemoveTransaction(SavingAccountTransaction transaction)
        {
            throw new NotImplementedException();
        }

        public void UpdateTransaction(SavingAccountTransaction transaction)
        {
            throw new NotImplementedException();
        }
    }
}
