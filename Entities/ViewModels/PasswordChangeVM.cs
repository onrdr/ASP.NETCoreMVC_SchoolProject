
using System.ComponentModel.DataAnnotations;

namespace Entities.ViewModels
{
    public class PasswordChangeVM
    {
        [Display(Name = "Old Password")]
        [Required(ErrorMessage = "Old Password is required")]
        [DataType(DataType.Password)]
        [MinLength(4, ErrorMessage = "Password must be a minimum of 4 characters")]
        public string PasswordOld { get; set; }

        [Display(Name = "New Password")]
        [Required(ErrorMessage = "New Password is required")]
        [DataType(DataType.Password)]
        [MinLength(4, ErrorMessage = "Password must be a minimum of 4 characters")]
        public string PasswordNew { get; set; }

        [Display(Name = "Confirm New Password")]
        [Required(ErrorMessage = "New Password Confirmation is required")]
        [DataType(DataType.Password)]
        [MinLength(4, ErrorMessage = "Password must be a minimum of 4 characters")]
        [Compare("PasswordNew")]
        public string PasswordConfirm { get; set; }
    }
}
