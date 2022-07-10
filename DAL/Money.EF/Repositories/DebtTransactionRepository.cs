using Microsoft.EntityFrameworkCore;
using Money.Domain.Entities.TransactionAggregate;
using Money.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Money.EF.Repositories
{
    public class DebtTransactionRepository : ITransactionRepository<DebtAccountTransaction>
    {
        private readonly MoneyContext _context;
        public DebtTransactionRepository(MoneyContext context)
        {
            _context = context;
        }

        public IEnumerable<DebtAccountTransaction> GetAllTransactionsBy(int accountId)
        {
            return _context.DebtAccountTransactions.Where(c => c.DebtAccountId == accountId);
        }

        public DebtAccountTransaction GetTransaction(int transactionId)
        {
            return _context.DebtAccountTransactions.FirstOrDefault(c => c.Id == transactionId);
        }

        public void CreateTransaction(DebtAccountTransaction transaction)
        {
            _context.DebtAccountTransactions.Add(transaction);
            _context.SaveChanges();
        }

        public void RemoveTransaction(DebtAccountTransaction transaction)
        {
            _context.DebtAccountTransactions.Remove(transaction);
            _context.SaveChanges();
        }

        public void UpdateTransaction(DebtAccountTransaction transaction)
        {
            _context.DebtAccountTransactions.Attach(transaction);
            _context.Entry(transaction).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
