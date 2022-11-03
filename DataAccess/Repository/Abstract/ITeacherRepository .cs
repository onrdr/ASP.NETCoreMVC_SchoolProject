using Entities.Concrete;

namespace DataAccess.Repository.Abstract
{
    public interface ITeacherRepository : IRepository<Teacher>
    {
        void Update(Teacher teacher);
    }
}
