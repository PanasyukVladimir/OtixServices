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
    public interface ITransactionRepository<T> where T : BaseTransaction
    {
        T GetTransaction(int transactionId);
        IEnumerable<T> GetAllTransactionsBy(int accountId);
        void CreateTransaction(T transaction);
        void UpdateTransaction(T transaction);
        void RemoveTransaction(T transaction);
    }
}
