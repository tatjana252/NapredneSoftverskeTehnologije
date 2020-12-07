using Departments.Data.Implementation;
using Departments.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Departments.Data.UnitOfWork.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbContext context;
        public IRepositoryDepartment Departments { get; set; }
        public IRepositoryStudent Students { get; set; }
        public IRepositorySubject Subjects { get; set; }

        public UnitOfWork(DbContext context)
        {
            this.context = context;
            Departments = new RepositoryDepartment(context);
            Students = new RepositoryStudent(context);
            Subjects = new RepositorySubject(context);
        }

        public void Commit()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
