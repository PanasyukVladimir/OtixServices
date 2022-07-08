using Money.Domain.Entities.AccountAggregate;
using Money.Domain.Entities.CategoryAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Money.Domain.Entities
{
    /// <summary>
    /// User
    /// </summary>
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; } 
        public string Name { get; set; }
        public string Email { get; set; }
        public bool IsEmailConfirmed { get; set; }

        public List<Category> Categories { get; set; }
        public List<RegularAccount> RegularAccounts { get; set; }
        public List<SavingAccount> SavingAccounts { get; set; }
        public List<DebtAccount> DebtAccounts { get; set; }
    }
}
