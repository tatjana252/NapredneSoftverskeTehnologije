using AutoMapper;
using Departments.Data.UnitOfWork;
using Departments.Data.UnitOfWork.Implementation;
using Departments.Domain;
using Departments.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Departments.Services.Implementation
{
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork unitofwork;
        private readonly IMapper mapper;

        public StudentService(IUnitOfWork unitofwork, IMapper mapper)
        {
            this.unitofwork = unitofwork;
            this.mapper = mapper;
        }

        public void Save(StudentDto student)
        {
            Student s1 =mapper.Map<Student>(student);
            Student s = new Student
            {
                StudentId = student.StudentId,
                GPA = student.GPA,
                Name = student.Name,
                EnrollmentYear = student.EnrollmentYear,
                EnrolledSubjects = student.EnrolledSubjects.Select(e => new StudentSubject { SubjectId = e.SubjectId }).ToList()
            };
            unitofwork.Students.Add(s);
            unitofwork.Commit();
        }
    }
}
