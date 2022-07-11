using Microsoft.EntityFrameworkCore;
using Money.Domain.Entities.TransactionAggregate;
using Money.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Money.EF.Repositories
{
    public class SavingTransactionRepository : ITransactionRepository<SavingAccountTransaction>
    {
        private readonly MoneyContext _context;
        public SavingTransactionRepository(MoneyContext context)
        {
            _context = context;
        }

        public IEnumerable<SavingAccountTransaction> GetAllTransactionsByAccountId(int accountId)
        {
            return _context.SavingAccountTransactions.Where(c => c.SavingAccountId == accountId);
        }

        public SavingAccountTransaction GetTransactionById(int transactionId)
        {
            return _context.SavingAccountTransactions.FirstOrDefault(c => c.Id == transactionId);
        }

        public void CreateTransaction(SavingAccountTransaction transaction)
        {
            _context.SavingAccountTransactions.Add(transaction);
            _context.SaveChanges();
        }

        public void RemoveTransaction(SavingAccountTransaction transaction)
        {
            _context.SavingAccountTransactions.Remove(transaction);
            _context.SaveChanges();
        }

        public void UpdateTransaction(SavingAccountTransaction transaction)
        {
            _context.SavingAccountTransactions.Attach(transaction);
            _context.Entry(transaction).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
