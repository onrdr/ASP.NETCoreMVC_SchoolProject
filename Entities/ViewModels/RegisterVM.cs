using Entities.Concrete.Enums;
using System.ComponentModel.DataAnnotations; 

namespace Entities.ViewModels
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "LastName is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Student Number is required")]
        public string StudentNo { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Birthday")]
        public DateTime BirthDay { get; set; } 
        public Gender Gender { get; set; }       


        [Required(ErrorMessage = "Username is required")]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Phone Number is required")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email Adress is required")]
        [Display(Name = "Email Address")]
        [EmailAddress(ErrorMessage = "Email Address is not valid")]
        public string Email { get; set; }

        public string? City { get; set; }
        public string? Picture { get; set; } 
        
    }
}
