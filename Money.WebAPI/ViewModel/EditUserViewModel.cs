using System.ComponentModel.DataAnnotations;

namespace Money.WebAPI.ViewModel
{
    public class EditUserViewModel
    {
        [Required]
        public string Id { get; set; }

        [Required(ErrorMessage = "Введіть name")]
        [MinLength(5, ErrorMessage = "Мінімальна довжина name має бути більше за 5 символів")]
        [MaxLength(50, ErrorMessage = "Максимальна довжина name має бути не більше ніж 50 символів")]
        public string Name { get; set; }

        //public virtual string Email { get; set; }

        //public virtual string PhoneNumber { get; set; }
    }
}
