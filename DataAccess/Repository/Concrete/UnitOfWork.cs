
using DataAccess.Repository.Abstract;

namespace DataAccess.Repository.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _db;

        public UnitOfWork(AppDbContext db)
        {
            _db = db;
            StudentRepository = new StudentRepository(_db);
            TeacherRepository = new TeacherRepository(_db);
            CourseRepository = new CourseRepository(_db);
            ExamGradeRepository = new ExamGradeRepository(_db);
        }

        public IStudentRepository StudentRepository{ get; private set; }
        public ITeacherRepository TeacherRepository{ get; private set; }
        public ICourseRepository CourseRepository{ get; private set; }
        public IExamGradeRepository ExamGradeRepository { get; private set; }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
