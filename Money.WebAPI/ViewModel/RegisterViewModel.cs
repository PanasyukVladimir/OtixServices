using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Money.WebAPI.ViewModel
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Введіть email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Введіть name")]
        [MinLength(5, ErrorMessage = "Мінімальна довжина name має бути більше за 5 символів")]
        [MaxLength(50, ErrorMessage = "Максимальна довжина name має бути не більше ніж 50 символів")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Введіть password")]
        [StringLength(100, ErrorMessage = "Пароль має містити мінімум 6 символів", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Підтвердіть password")]
        [Compare("Password", ErrorMessage = "Паролі не співпадають")]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }


        public static char[] ForbiddenCharacters =
        {
            '!', '"', '#', '$','%', '&', '(', ')', '*', '+', ',',
            '\\', '-', '/', '.', ':', ';', '<', '=', '>', '?', '~',
            '@', '[', ']', '^', '_', '`', '{', '|', '}', '№', '1',
            '2', '3', '4', '5', '6', '7', '8', '9', '0'
        };
        public static bool CheckUserName(string name)
        {
            if (name.Any(c => ForbiddenCharacters.Contains(c)))
            {
                return false;
            }

            return true;
        }
    }
}
