using Entities.Abstract;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Concrete
{
    public class Teacher : IEntity
    {
        public Teacher()
        {
            Students = new HashSet<Student>();
            ExamGrades = new HashSet<ExamGrade>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime Birthday { get; set; }
        public int Gender { get; set; }  
        public string? Picture { get; set; }
        public int CourseId { get; set; }

        [ValidateNever]
        public Course Course { get; set; }
        public ICollection<ExamGrade> ExamGrades { get; set; }
        public ICollection<Student> Students { get; set; }

        [NotMapped]
        public string FullName { get => $"{Name} {LastName}"; }
    }
}