using AutoMapper;
using BL.ViewModels;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Configuration
{ 
    public static class MapperConfig
    {
        public static IMapper Mapper { get; set; }
        static MapperConfig()
        {
            var config = new MapperConfiguration(
                cfg =>
                {
                    cfg.CreateMap<Student, StudentVM>().ReverseMap();
                    cfg.CreateMap<ApplicationUserIdentity, StudentVM>().ReverseMap();
                    cfg.CreateMap<Teacher, TeacherVM>().ReverseMap();
                    cfg.CreateMap<ApplicationUserIdentity, LoginVM>().ReverseMap();
                    cfg.CreateMap<ApplicationUserIdentity, RegisterVM>().ReverseMap();
                    cfg.CreateMap<Student,RegisterVM>().ReverseMap();
                    cfg.CreateMap<Teacher,RegisterVM>().ReverseMap();

                    cfg.CreateMap<Category, CategoryVM>().ReverseMap();
                    cfg.CreateMap<Class, ClassVM>().ReverseMap();
                    cfg.CreateMap<Course, CourseVM>().ReverseMap();
                    cfg.CreateMap<Comment, CommentVM>().ReverseMap();

                });
            Mapper = config.CreateMapper();
        }
    }
}
