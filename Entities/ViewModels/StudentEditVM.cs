
using Entities.Abstract;
using Entities.Concrete.Enums;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using System.ComponentModel.DataAnnotations;

namespace Entities.ViewModels
{
    public class StudentEditVM : PersonEditVM
    { 
        [Required(ErrorMessage = "Student Number is required")]
        public string StudentNo { get; set; } 
    }
}
