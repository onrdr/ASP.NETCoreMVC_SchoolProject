using Business.Abstract;
using DataAccess.Repository.Concrete;

namespace Business.Concrete
{
    public class CourseManager : ICourseService
    {
        CourseRepository _courseRepository;
        public CourseManager(CourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }
    }
}
