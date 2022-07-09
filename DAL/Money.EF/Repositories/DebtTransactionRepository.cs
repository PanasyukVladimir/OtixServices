using Money.Domain.Entities.TransactionAggregate;
using Money.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Money.EF.Repositories
{
    public class DebtTransactionRepository : ITransactionRepository<DebtAccountTransaction>
    {
        public IEnumerable<DebtAccountTransaction> GetAllTransactionsBy(int accountId)
        {
            throw new NotImplementedException();
        }

        public DebtAccountTransaction GetTransaction(int transactionId)
        {
            throw new NotImplementedException();
        }

        public void CreateTransaction(DebtAccountTransaction transaction)
        {
            throw new NotImplementedException();
        }

        public void RemoveTransaction(DebtAccountTransaction transaction)
        {
            throw new NotImplementedException();
        }

        public void UpdateTransaction(DebtAccountTransaction transaction)
        {
            throw new NotImplementedException();
        }
    }
}
