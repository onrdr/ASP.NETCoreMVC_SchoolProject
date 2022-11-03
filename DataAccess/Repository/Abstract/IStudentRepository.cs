using Entities.Concrete;

namespace DataAccess.Repository.Abstract
{
    public interface IStudentRepository : IRepository<Student>
    {
        void Update(Student student);
        public IEnumerable<Course> GetStudentCourseList(int id);
    }
}
