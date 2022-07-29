using Microsoft.EntityFrameworkCore;
using Money.Domain.Entities.AccountAggregate;
using Money.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Money.EF.Repositories
{
    public class RegularAccountRepository : IAccountRepository<RegularAccount>
    {
        private readonly MoneyContext _context;
        public RegularAccountRepository(MoneyContext context)
        {
            _context = context;
        }

        public RegularAccount GetAccountById(int accountId)
        {
            return _context.RegularAccounts.FirstOrDefault(c => c.Id == accountId);
        }

        public IEnumerable<RegularAccount> GetAccountsByUserId(string userId)
        {
            return _context.RegularAccounts.Where(c => c.UserId == userId);
        }
        public void CreateAccount(RegularAccount account)
        {
            _context.RegularAccounts.Add(account);
            _context.SaveChanges();
        }

        public void RemoveAccount(RegularAccount account)
        {
            _context.RegularAccounts.Remove(account);
            _context.SaveChanges();
        }

        public void UpdateAccount(RegularAccount account)
        {
            _context.RegularAccounts.Attach(account);
            _context.Entry(account).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
