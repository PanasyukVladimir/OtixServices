using Money.Domain.Entities.AccountAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Money.Domain.Repositories
{
    public interface IAccountRepository
    {
        //IEnumerable<T> GetAllAccounts<T>() where T : BaseAccount;
        T GetAccount<T>(int accountId) where T : BaseAccount;
        IEnumerable<T> GetAccountsByUserId<T>(int userId) where T : BaseAccount;
        void CreateAccount<T>(T account) where T : BaseAccount;
        void UpdateAccount<T>(T account) where T : BaseAccount;
        void RemoveAccount<T>(T account) where T : BaseAccount;
    }
}
