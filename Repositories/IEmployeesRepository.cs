using Proiect_DAW.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_DAW.Repositories
{
    public interface IEmployeesRepository
    {
        IQueryable<Employee> GetEmployeesIQueriable();

        void Create(Employee emp);

        void Update(Employee emp);

        void Delete(Employee emp);

    }
}
