using Entities.Concrete;
using Entities.Concrete.Identity;

namespace Entities.ViewModels
{
    public class StudentInformationVM
    {
        public AppUser AppUser { get; set; }
        public Student Student { get; set; }
    }
}
