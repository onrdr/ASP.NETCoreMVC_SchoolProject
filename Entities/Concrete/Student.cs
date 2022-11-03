using Entities.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Concrete
{
    public class Student : IEntity
    {
        public Student()
        {
            Courses = new HashSet<Course>();
            Teachers = new HashSet<Teacher>();
            ExamGrades = new HashSet<ExamGrade>();
        }

        public int Id { get; set; }
        public string StudentNo { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime Birthday{ get; set; }
        public int Gender{ get; set; } 
        public string? Picture { get; set; }
        public ICollection<Course> Courses { get; set; }
        public ICollection<Teacher> Teachers { get; set; }
        public ICollection<ExamGrade> ExamGrades { get; set; }

        [NotMapped]
        public string FullName { get => $"{Name} {LastName}"; }
    }
}