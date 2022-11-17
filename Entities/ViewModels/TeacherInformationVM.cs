using Entities.Concrete;
using Entities.Concrete.Identity;

namespace Entities.ViewModels
{
    public class TeacherInformationVM
    {
        public AppUser AppUser{ get; set; }
        public Teacher Teacher{ get; set; }
    }
}
