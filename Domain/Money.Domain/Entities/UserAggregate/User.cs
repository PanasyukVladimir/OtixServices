using Microsoft.AspNetCore.Identity;
using Money.Domain.Entities.AccountAggregate;
using Money.Domain.Entities.CategoryAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Money.Domain.Entities.UserAggregate
{
    /// <summary>
    /// User
    /// </summary>
    public class User : IdentityUser
    {
        //public int Id { get; set; }
        //[Required]
        //public string Login { get; set; }
        //[NotMapped]
        //public string Password { get; set; } 
        public string Name { get; set; }
        //[Required]
        //public string Email { get; set; }
        //public bool IsEmailConfirmed { get; set; }

        public List<Category> Categories { get; set; }
        public List<RegularAccount> RegularAccounts { get; set; }
        public List<SavingAccount> SavingAccounts { get; set; }
        public List<DebtAccount> DebtAccounts { get; set; }
    }
}
