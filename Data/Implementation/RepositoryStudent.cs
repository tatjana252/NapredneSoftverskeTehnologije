using Departments.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Departments.Data.Implementation
{
    public class RepositoryStudent : GenericRepository<Student>, IRepositoryStudent
    {
        public RepositoryStudent(DbContext context) : base(context)
        {
        }
    }
}
