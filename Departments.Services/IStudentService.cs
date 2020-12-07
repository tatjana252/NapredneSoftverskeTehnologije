using Departments.Domain;
using Departments.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Departments.Services
{
    public interface IStudentService
    {
        void Save(StudentDto student);

    }
}
