using DataAccess.Repository.Abstract;
using Entities.Concrete;

namespace DataAccess.Repository.Concrete
{
    public class CourseRepository : RepositoryBase<Course>, ICourseRepository
    {
        private readonly AppDbContext _db;

        public CourseRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Course course)
        {
            _db.Update(course);
        }
    }
}
