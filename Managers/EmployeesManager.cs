using Proiect_DAW.Entities;
using Proiect_DAW.Models;
using Proiect_DAW.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_DAW.Managers
{
    public class EmployeesManager : IEmployeesManager
    {
        private readonly IEmployeesRepository employeesRepository;

        public EmployeesManager(IEmployeesRepository employeeRepository)
        {
            this.employeesRepository = employeeRepository;
        }

        public void Create(EmployeeCreationModel model)
        {
            var newEmp = new Employee
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Salary = model.Salary,
                Age = model.Age,
                ShopId = model.ShopId,
                Id = model.Id
            };

            employeesRepository.Create(newEmp);
        }
        public void Update(EmployeeCreationModel model)
        {
            var newEmp = GetEmployeeById(model.Id);
            newEmp.FirstName = model.FirstName;
            newEmp.LastName = model.LastName;
            newEmp.Salary = model.Salary;
            newEmp.Age = model.Age;
            newEmp.ShopId = model.ShopId;
            employeesRepository.Update(newEmp);
        }

        public void Delete(string id)
        {
            var newEmp = GetEmployeeById(id);
           

            employeesRepository.Delete(newEmp);
        }

        public Employee GetEmployeeById(string id)
        {
            var emp = employeesRepository
                  .GetEmployeesIQueriable()
                  .Where(x => x.Id == id)
                  .FirstOrDefault();
            return emp;
        }

        public List<Employee> getEmployees()
        {
            return employeesRepository.GetEmployeesIQueriable().ToList();
        }

        
    }
}
