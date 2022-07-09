using Money.Domain.Entities;
using Money.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Money.EF.Repositories
{
    public class UserRepository : IUserRepository
    {
        public void CreateUser(User user)
        {
            throw new NotImplementedException();
        }

        public User GetUserById(int userId)
        {
            throw new NotImplementedException();
        }

        public User GetUserByLoginPassword(string login, string password)
        {
            throw new NotImplementedException();
        }

        public void RemoveUser(User user)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
