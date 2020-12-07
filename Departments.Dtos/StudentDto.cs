using System;
using System.Collections.Generic;

namespace Departments.Dtos
{
    public class StudentDto
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public int EnrollmentYear { get; set; }
        public double GPA { get; set; }
        public List<StudentSubjectDto> EnrolledSubjects { get; set; } = new List<StudentSubjectDto>();
    }
}
