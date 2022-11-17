using AutoMapper;
using Entities.Concrete;
using Entities.Concrete.Identity;
using Entities.ViewModels;

namespace Business.Mappers.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<MemberVM, AppUser>();
            CreateMap<AppUser, MemberVM>(); 

            CreateMap<Student, StudentEditVM>(); 
            CreateMap<StudentEditVM, Student>(); 


        } 
    }
}
