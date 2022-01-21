using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proiect_DAW.Managers;
using Proiect_DAW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_DAW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeesManager manager;

        public EmployeeController(IEmployeesManager employeesManager)
        {
            this.manager = employeesManager;
        }

        [HttpGet("selectEmployeesIds")]
        [Authorize(Policy = "BasicUser")]
        public async Task<IActionResult> GetEmployeeIds()
        {


            var employees = manager.getEmployees().ToList();




            var employeeIds = employees.Select(x => x.Id).ToList();

            return Ok(employeeIds);

        }

        [HttpGet("selectEmployees")]
        [Authorize(Policy = "BasicUser")]
        public async Task<IActionResult> GetEmployees()
        {
            var employees = manager.getEmployees().ToList();
            return Ok(employees);
        }

        [HttpGet("GetEmployeeById/{id}")]
        [Authorize(Policy = "BasicUser")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            var employees = manager.GetEmployeeById(id);

            return Ok(employees);
        }


        [HttpPost("CreateEmployee")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Create([FromBody] EmployeeCreationModel emp)
        {
            manager.Create(emp);
            return Ok();
        }

        [HttpPost("UpdateEmployee")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Update([FromBody] EmployeeCreationModel emp)
        {
            manager.Update(emp);
            return Ok();
        }

        [HttpDelete("DeleteEmployee/{id}")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            manager.Delete(id);
            return Ok();
        }


    }
}
