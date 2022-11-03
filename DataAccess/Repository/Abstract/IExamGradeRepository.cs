using Entities.Concrete;

namespace DataAccess.Repository.Abstract
{
    public interface IExamGradeRepository : IRepository<ExamGrade>
    {
        void Update(ExamGrade examGrade);
    }
}
