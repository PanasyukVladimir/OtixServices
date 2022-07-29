using System.ComponentModel.DataAnnotations;

namespace Money.WebAPI.ViewModel
{
    public class UserViewModel
    {
        [Required]
        public string Id { get; set; }
    }
}
