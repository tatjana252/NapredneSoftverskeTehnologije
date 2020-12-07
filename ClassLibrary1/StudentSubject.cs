using System;
using System.Collections.Generic;
using System.Text;

namespace Departments.Domain
{
    public class StudentSubject
    {
        public string Prom { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
    }
}
