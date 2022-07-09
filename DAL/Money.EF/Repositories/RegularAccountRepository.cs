using Money.Domain.Entities.AccountAggregate;
using Money.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Money.EF.Repositories
{
    public class RegularAccountRepository : IAccountRepository<RegularAccount>
    {
        public void CreateAccount(RegularAccount account)
        {
            throw new NotImplementedException();
        }

        public RegularAccount GetAccount(int accountId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RegularAccount> GetAccountsByUserId(int userId)
        {
            throw new NotImplementedException();
        }

        public void RemoveAccount(RegularAccount account)
        {
            throw new NotImplementedException();
        }

        public void UpdateAccount(RegularAccount account)
        {
            throw new NotImplementedException();
        }
    }
}
