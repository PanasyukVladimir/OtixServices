using Money.Domain.Entities.AccountAggregate;
using Money.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Money.EF.Repositories
{
    public class DebtAccountRepository : IAccountRepository<DebtAccount>
    {
        public DebtAccount GetAccount(int accountId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DebtAccount> GetAccountsByUserId(int userId)
        {
            throw new NotImplementedException();
        }

        public void CreateAccount(DebtAccount account)
        {
            throw new NotImplementedException();
        }

        public void RemoveAccount(DebtAccount account)
        {
            throw new NotImplementedException();
        }

        public void UpdateAccount(DebtAccount account)
        {
            throw new NotImplementedException();
        }
    }
}
