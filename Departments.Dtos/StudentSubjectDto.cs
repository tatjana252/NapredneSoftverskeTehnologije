using System;
using System.Collections.Generic;
using System.Text;

namespace Departments.Dtos
{
    public class StudentSubjectDto
    {
        public int SubjectId { get; set; }
        public SubjectDto Subject { get; set; }
    }
}
