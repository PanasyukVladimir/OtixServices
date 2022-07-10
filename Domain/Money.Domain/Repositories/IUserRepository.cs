using Money.Domain.Entities.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Money.Domain.Repositories
{
    public interface IUserRepository
    {
        //IEnumerable<User> GetAllUsers();
        User GetUserById(int userId);
        User GetUserByLoginPassword(string login, string password);
        void CreateUser(User user);
        void UpdateUser(User user);
        void RemoveUser(User user);
    }
}
