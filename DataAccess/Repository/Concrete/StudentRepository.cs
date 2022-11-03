using DataAccess.Repository.Abstract;
using Microsoft.EntityFrameworkCore;
using Entities.Concrete;

namespace DataAccess.Repository.Concrete
{
    public class StudentRepository : RepositoryBase<Student>, IStudentRepository
    {
        private readonly AppDbContext _db;

        public StudentRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Student student)
        {
            _db.Update(student);
        }

        public IEnumerable<Course> GetStudentCourseList(int id)
        { 
            var student = _db.Students.Include(s => s.Courses).FirstOrDefault(s => s.Id == id);

            return student.Courses;

        }
    }
}
