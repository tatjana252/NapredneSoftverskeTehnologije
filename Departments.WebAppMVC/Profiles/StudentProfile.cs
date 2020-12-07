using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Departments.Domain;
using Departments.Dtos;

namespace Departments.WebAppMVC.Profiles
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<Student, StudentDto>().ReverseMap();
            CreateMap<Subject, SubjectDto>().ForMember(sdto => sdto.Name, c => c.MapFrom(s => s.Name));
            CreateMap<Subject, SubjectDto>().ForMember(sdto => sdto.Name, c => c.Ignore());
        }
    }
}
