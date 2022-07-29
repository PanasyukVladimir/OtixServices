using Microsoft.EntityFrameworkCore;
using Money.Domain.Entities.AccountAggregate;
using Money.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Money.EF.Repositories
{
    public class SavingAccountRepository : IAccountRepository<SavingAccount>
    {
        private readonly MoneyContext _context;
        public SavingAccountRepository(MoneyContext context)
        {
            _context = context;
        }

        public SavingAccount GetAccountById(int accountId)
        {
            return _context.SavingAccounts.FirstOrDefault(c => c.Id == accountId);
        }

        public IEnumerable<SavingAccount> GetAccountsByUserId(string userId)
        {
            return _context.SavingAccounts.Where(c => c.UserId == userId);
        }

        public void CreateAccount(SavingAccount account)
        {
            _context.SavingAccounts.Add(account);
            _context.SaveChanges();
        }

        public void RemoveAccount(SavingAccount account)
        {
            _context.SavingAccounts.Remove(account);
            _context.SaveChanges();
        }

        public void UpdateAccount(SavingAccount account)
        {
            _context.SavingAccounts.Attach(account);
            _context.Entry(account).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
