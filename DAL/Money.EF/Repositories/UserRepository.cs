using Microsoft.EntityFrameworkCore;
using Money.Domain.Entities.UserAggregate;
using Money.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Money.EF.Repositories
{
    public class UserRepository : IUserRepository
    {
        /*
        private readonly MoneyContext _context;
        public UserRepository(MoneyContext context)
        {
            _context = context;
        }

        public User GetUserById(string userId)
        {
            return _context.Users.FirstOrDefault(u => u.Id == userId);
        }

        public User GetUserByLoginPassword(string login, string password)
        {
            return _context.Users.Where(u => u.UserName == login && u.PasswordHash == password).FirstOrDefault();
        }

        public bool IsExistsLoginOrEmail(string login, string email)
        {
            var user = _context.Users.Where(u => u.UserName == login || u.Email == email).FirstOrDefault();

            if(user != null)
            {
                return true;
            }

            return false;
        }

        public void CreateUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void RemoveUser(User user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            _context.Users.Attach(user);
            _context.Entry(user).State = EntityState.Modified;
            _context.SaveChanges();
        }
        */
    }
}
