using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IStudentService : IEntityService
    {
        IResult Add(Student product);
        IResult Delete(Student product);
        IResult Update(Student product); 
        List<Student> GetAllStudents();
        IDataResult<List<Student>> GetAllByCourseId(int id);
        IDataResult<List<Student>> GetAllByTeacherId(int id);
        IDataResult<List<Student>> GetAllByExamGradeId(int id);
        Student GetStudentById(int productId); 
        public int GetStudentIdByStudentNo(string studentNo);
    }
}
