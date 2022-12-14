using Entities.Abstract;
using Entities.Concrete.Enums;
using System.ComponentModel.DataAnnotations; 

namespace Entities.ViewModels
{
    public class StudentRegisterVM : PersonRegisterVM
    {
        [Required(ErrorMessage = "Student Number is required")]
        public string StudentNo { get; set; } 
    }
}
