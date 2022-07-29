using Microsoft.EntityFrameworkCore;
using Money.Domain.Entities.AccountAggregate;
using Money.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Money.EF.Repositories
{
    public class DebtAccountRepository : IAccountRepository<DebtAccount>
    {
        private readonly MoneyContext _context;
        public DebtAccountRepository(MoneyContext context)
        {
            _context = context;
        }

        public DebtAccount GetAccountById(int accountId)
        {
            return _context.DebtAccounts.FirstOrDefault(c => c.Id == accountId);
        }

        public IEnumerable<DebtAccount> GetAccountsByUserId(string userId)
        {
            return _context.DebtAccounts.Where(c => c.UserId == userId);
        }

        public void CreateAccount(DebtAccount account)
        {
            _context.DebtAccounts.Add(account);
            _context.SaveChanges();
        }

        public void RemoveAccount(DebtAccount account)
        {
            _context.DebtAccounts.Remove(account);
            _context.SaveChanges();
        }

        public void UpdateAccount(DebtAccount account)
        {
            _context.DebtAccounts.Attach(account);
            _context.Entry(account).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
