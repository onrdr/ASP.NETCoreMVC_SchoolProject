using Entities.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Concrete
{
    public class Course : IEntity
    {
        public Course()
        {
            Teachers = new HashSet<Teacher>();
            Students = new HashSet<Student>(); 
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public ICollection<Teacher> Teachers { get; set; }
        public ICollection<Student> Students { get; set; } 

        [NotMapped]
        public string FullName { get => $"{Name} {Code}"; }
    }
}