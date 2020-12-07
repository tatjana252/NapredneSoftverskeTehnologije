using Departments.Data.UnitOfWork;
using Departments.Domain;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Departments.WebAppMVC.Hubs
{
    public class DepartmentHub : Hub
    {
        private readonly IUnitOfWork uow;

        public DepartmentHub(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public async Task DepartmentAdd(Department department)
        {
            uow.Departments.Add(department);
            uow.Commit();
            await Clients.Others.SendAsync("UpdateDepartments", department);
            await Clients.Caller.SendAsync("DepartmentAdded", department);
        }

    }
}
