using Microsoft.EntityFrameworkCore;
using Money.Domain.Entities.TransactionAggregate;
using Money.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Money.EF.Repositories
{
    public class RegularTransactionRepository : ITransactionRepository<RegularAccountTransaction>
    {
        private readonly MoneyContext _context;
        public RegularTransactionRepository(MoneyContext context)
        {
            _context = context;
        }

        public IEnumerable<RegularAccountTransaction> GetAllTransactionsByAccountId(int accountId)
        {
            return _context.RegularAccountTransactions.Where(c => c.RegularAccountId == accountId);
        }

        public RegularAccountTransaction GetTransactionById(int transactionId)
        {
            return _context.RegularAccountTransactions.FirstOrDefault(c => c.Id == transactionId);
        }

        public void CreateTransaction(RegularAccountTransaction transaction)
        {
            _context.RegularAccountTransactions.Add(transaction);
            _context.SaveChanges();
        }

        public void RemoveTransaction(RegularAccountTransaction transaction)
        {
            _context.RegularAccountTransactions.Remove(transaction);
            _context.SaveChanges();
        }

        public void UpdateTransaction(RegularAccountTransaction transaction)
        {
            _context.RegularAccountTransactions.Attach(transaction);
            _context.Entry(transaction).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
