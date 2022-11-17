using Business.Abstract;
using DataAccess.Repository.Abstract;
using DataAccess.Repository.Concrete;

namespace Business.Concrete
{
    public class TeacherManager : ITeacherService
    {
        ITeacherRepository _teacherRepository;
        public TeacherManager(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }
    }
}
