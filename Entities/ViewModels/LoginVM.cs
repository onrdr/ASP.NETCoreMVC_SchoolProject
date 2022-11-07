using System.ComponentModel.DataAnnotations; 

namespace Entities.ViewModels
{
    public class LoginVM
    {
        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Email required")]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Password required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
