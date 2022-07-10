using Microsoft.EntityFrameworkCore;
using Money.Domain.Entities.TransactionAggregate;
using Money.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Money.EF.Repositories
{
    public class DefaultTransactionRepository : ITransactionRepository<DefaultTransaction>
    {
        private readonly MoneyContext _context;
        public DefaultTransactionRepository(MoneyContext context)
        {
            _context = context;
        }

        public IEnumerable<DefaultTransaction> GetAllTransactionsBy(int accountId)
        {
            return _context.DefaultTransactions.Where(c => c.CategoryId == accountId);
        }

        public DefaultTransaction GetTransaction(int transactionId)
        {
            return _context.DefaultTransactions.FirstOrDefault(c => c.Id == transactionId);
        }
        public void CreateTransaction(DefaultTransaction transaction)
        {
            _context.DefaultTransactions.Add(transaction);
            _context.SaveChanges();
        }

        public void RemoveTransaction(DefaultTransaction transaction)
        {
            _context.DefaultTransactions.Remove(transaction);
            _context.SaveChanges();
        }

        public void UpdateTransaction(DefaultTransaction transaction)
        {
            _context.DefaultTransactions.Attach(transaction);
            _context.Entry(transaction).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
