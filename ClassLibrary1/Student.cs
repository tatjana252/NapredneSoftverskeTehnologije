using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Departments.Domain
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        public string Name { get; set; }
        public int EnrollmentYear { get; set; }
        public double GPA { get; set; }
        public List<StudentSubject> EnrolledSubjects { get; set; } = new List<StudentSubject>();
    }
}
