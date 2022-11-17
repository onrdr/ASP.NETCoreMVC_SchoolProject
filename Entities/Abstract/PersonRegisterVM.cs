
using Entities.Concrete.Enums;
using System.ComponentModel.DataAnnotations;

namespace Entities.Abstract
{
    public class PersonRegisterVM : IViewModel
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "LastName is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email Adress is required")]
        [Display(Name = "Email Address")]
        [EmailAddress(ErrorMessage = "Email Address is not valid")]
        public string Email { get; set; }

        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }
        public Gender Gender { get; set; }
         
        [Required(ErrorMessage = "Phone Number is required")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; } 
        public string? Picture { get; set; }
        public string? City { get; set; }


        [Required(ErrorMessage = "Username is required")]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MinLength(4, ErrorMessage = "Password must be a minimum of 4 characters")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [MinLength(4, ErrorMessage = "Password must be a minimum of 4 characters")]
        [Compare("Password")]
        public string PasswordConfirm { get; set; } 
    }
}
