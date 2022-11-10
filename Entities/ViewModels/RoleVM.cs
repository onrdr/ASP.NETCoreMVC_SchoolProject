using System.ComponentModel.DataAnnotations;

namespace Entities.ViewModels
{
    public class RoleVM
    {
        public string Id { get; set; }

        [Required(ErrorMessage ="Role name is required")]
        [Display(Name="Role Name")]
        public string Name { get; set; }
    }
}
