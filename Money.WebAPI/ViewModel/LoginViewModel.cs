using System.ComponentModel.DataAnnotations;

namespace Money.WebAPI.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Введіть login(email)")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Введіть password")]
        public string Password { get; set; }
    }
}
