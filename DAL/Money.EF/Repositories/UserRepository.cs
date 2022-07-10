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
        private readonly MoneyContext _context;
        public UserRepository(MoneyContext context)
        {
            _context = context;
        }

        public User GetUserById(int userId)
        {
            return _context.Users.FirstOrDefault(u => u.Id == userId);
        }

        public User GetUserByLoginPassword(string login, string password)
        {
            return _context.Users.Where(u => u.Login == login && u.Password == password).FirstOrDefault();
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
    }
}
