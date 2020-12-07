using Departments.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Departments.Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        public IRepositoryDepartment Departments { get; set; }
        public IRepositoryStudent Students { get; set; }
        public IRepositorySubject Subjects { get; set; }

        void Commit();
    }
}
