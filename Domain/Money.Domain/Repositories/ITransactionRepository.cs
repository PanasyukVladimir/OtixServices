using Money.Domain.Entities;
using Money.Domain.Entities.AccountAggregate;
using Money.Domain.Entities.TransactionAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Money.Domain.Repositories
{
    public interface ITransactionRepository
    {
        T GetTransaction<T>(int transactionId) where T : BaseTransaction;
        IEnumerable<T> GetAllTransactionsBy<T>(int accountId) where T : BaseTransaction;
        void CreateTransaction<T>(T transaction) where T : BaseTransaction;
        void UpdateTransaction<T>(T transaction) where T : BaseTransaction;
        void RemoveTransaction<T>(T transaction) where T : BaseTransaction;
    }
}
