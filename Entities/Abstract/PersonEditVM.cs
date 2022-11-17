
using Entities.Concrete.Enums;
using System.ComponentModel.DataAnnotations;

namespace Entities.Abstract
{
    public class PersonEditVM
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "LastName is required")]
        public string LastName { get; set; } 

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Birthday is required")]
        public DateTime Birthday { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public Gender Gender { get; set; } 
        public string? City { get; set; }
    }
}
