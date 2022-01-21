using Proiect_DAW.Entities;
using Proiect_DAW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_DAW.Managers
{
    public interface IEmployeesManager
    {
        List<Employee> getEmployees();

        Employee GetEmployeeById(string id);

        void Create(EmployeeCreationModel model);
        void Update(EmployeeCreationModel model);
        void Delete(string id);

    }
}
