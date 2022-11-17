using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Repository.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class StudentManager : IStudentService
    {
        readonly IStudentRepository _studentRepository;

        public StudentManager(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public IResult Add(Student student)
        {
            var result = BusinessRules.Run(CheckIfStudentNnumberExists(student.StudentNo));

            if (result is not null)
            {
                return result;
            }
            _studentRepository.Add(student);
            return new SuccessResult(Messages.StudentAdded);
        }
        public IResult Update(Student student)
        {
            _studentRepository.Update(student);
            return new SuccessResult(Messages.StudentUpdated);
        }

        public IResult Delete(Student student)
        {
            _studentRepository.Delete(student);
            return new SuccessResult(Messages.StudentDeleted);
        }

        public int GetStudentIdByStudentNo(string studentNo)
        {
            var student = _studentRepository.GetFirstOrDefault(s => s.StudentNo == studentNo);
            return student.Id;
        }

        public Student GetStudentById(int studentId)
        {
            return _studentRepository.GetFirstOrDefault(s => s.Id == studentId);
        }

        public List<Student> GetAllStudents()
        {
            return _studentRepository.GetAll().ToList();
        }

        public IDataResult<List<Student>> GetAllByCourseId(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Student>> GetAllByExamGradeId(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Student>> GetAllByTeacherId(int id)
        {
            throw new NotImplementedException();
        }


        #region Functions
        private IResult CheckIfStudentNnumberExists(string studentNo)
        {
            var result = _studentRepository.GetAll(s => s.StudentNo == studentNo).Any();

            if (result)
            {
                return new ErrorResult(Messages.StudentNumberAlreadyExists);
            }
            return new SuccessResult();
        }
        #endregion
    }
}
