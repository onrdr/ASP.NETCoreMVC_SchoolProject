namespace DataAccess.Repository.Abstract
{
    public interface IUnitOfWork
    {
        IStudentRepository StudentRepository { get; }
        ITeacherRepository TeacherRepository{ get; }
        ICourseRepository CourseRepository{ get; }
        IExamGradeRepository ExamGradeRepository{ get; }
        public Task SaveAsync();
    }
}
