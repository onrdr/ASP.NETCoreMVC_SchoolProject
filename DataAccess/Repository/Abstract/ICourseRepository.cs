using Entities.Concrete; 

namespace DataAccess.Repository.Abstract
{
    public interface ICourseRepository : IRepository<Course>
    {
        void Update(Course course);
    }
}
