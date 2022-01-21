using Proiect_DAW.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_DAW.Repositories
{
    public class EmployeesRepository : IEmployeesRepository
    {
        private readonly ProiectContext db;

        public EmployeesRepository(ProiectContext db)
        {
            this.db = db;
        }

        public void Create(Employee emp)
        {
            db.Employees.Add(emp);
            db.SaveChanges();
        }

        public void Update(Employee emp)
        {
            db.Employees.Update(emp);
            db.SaveChanges();
        }
        public void Delete(Employee emp)
        {
            db.Employees.Remove(emp);
            db.SaveChanges();
        }

        public IQueryable<Employee> GetEmployeesIQueriable()
        {
            var emp = db.Employees;

            return emp;
        }

    }
}
