using Money.Domain.Entities.AccountAggregate;
using Money.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Money.EF.Repositories
{
    public class SavingAccountRepository : IAccountRepository<SavingAccount>
    {
        public SavingAccount GetAccount(int accountId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SavingAccount> GetAccountsByUserId(int userId)
        {
            throw new NotImplementedException();
        }

        public void CreateAccount(SavingAccount account)
        {
            throw new NotImplementedException();
        }

        public void RemoveAccount(SavingAccount account)
        {
            throw new NotImplementedException();
        }

        public void UpdateAccount(SavingAccount account)
        {
            throw new NotImplementedException();
        }
    }
}
