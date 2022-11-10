using Business.Abstract;
using DataAccess.Repository.Concrete;

namespace Business.Concrete
{
    public class TeacherManager : ITeacherService
    {
        TeacherRepository _teacherRepository;
        public TeacherManager(TeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }
    }
}
