using Business.Abstract;
using DataAccess.Repository.Abstract;

namespace Business.Concrete
{
    public class ExamGradeManager : IExamGradeService
    {
        IExamGradeRepository _examGradeRepository;
    }
}
