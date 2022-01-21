using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proiect_DAW.Entities;
using Proiect_DAW.Managers;
using Proiect_DAW.Models;
using Proiect_DAW.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_DAW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerController : ControllerBase
    {



        private IManagersManager manager;
        
        public ManagerController(IManagersManager managersManager)
        {
            this.manager = managersManager; 
        }
        [HttpGet("selectManagersIds")]
        [Authorize(Policy = "BasicUser")]
        public async Task<IActionResult> GetManagerIds()
        {


            var managers = manager.getManagers().ToList();


            

            var managerIds = managers.Select(x => x.Id).ToList();

            return Ok(managerIds);

        }


        [HttpGet("selectManagers")]
        [Authorize(Policy = "BasicUser")]
        public async Task<IActionResult> GetManagers()
        {
            var managers = manager.getManagers().ToList();
            return Ok(managers);
        }

        [HttpGet("GetManagerById/{id}")]
        [Authorize(Policy = "BasicUser")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            var managers = manager.GetManagerById(id);

            return Ok(managers);
        }

       

        [HttpPost("create")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Create([FromBody] ManagerCreationModel man)
        {


            manager.Create(man);
            return Ok();
        }

        [HttpPost("update")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Update([FromBody] ManagerCreationModel man)
        {
            manager.Update(man);
            return Ok();
        }

        [HttpDelete("delete/{id}")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            manager.Delete(id);
            return Ok();
        }

    }
}
