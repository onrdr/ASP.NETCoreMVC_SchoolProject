using DataAccess.Repository.Abstract;
using Entities.Concrete;

namespace DataAccess.Repository.Concrete
{
    public class TeacherRepository : RepositoryBase<Teacher>, ITeacherRepository
    {
        private readonly AppDbContext _db;

        public TeacherRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Teacher teacher)
        {
            _db.Update(teacher);
        }
    }
}
