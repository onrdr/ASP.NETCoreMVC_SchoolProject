using DataAccess.Repository.Abstract;
using Entities.Concrete;

namespace DataAccess.Repository.Concrete
{
    public class ExamGradeRepository : RepositoryBase<ExamGrade>, IExamGradeRepository
    {
        private readonly AppDbContext _db;

        public ExamGradeRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(ExamGrade examGrade)
        {
            _db.Update(examGrade);
        }
    }
}
