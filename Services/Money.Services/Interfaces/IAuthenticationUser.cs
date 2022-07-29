using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Money.Services.Interfaces
{
    public interface IAuthenticationUser
    {
        Task SendMessageAsync(string email, string subject, string message);
    }
}
