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
    public class ItemController : ControllerBase
    {

        private IItemsManager manager;

        public ItemController(IItemsManager itemsManager)
        {
            this.manager = itemsManager;
        }


        [HttpGet("selectItemsIds")]
        [Authorize(Policy = "BasicUser")]
        public async Task<IActionResult> GetItemIds()
        {


            var items = manager.getItems().ToList();




            var itemIds = items.Select(x => x.Id).ToList();

            return Ok(itemIds);

        }

        [HttpGet("selectItems")]
        [Authorize(Policy = "BasicUser")]
        public async Task<IActionResult> GetItems()
        {
            var items = manager.getItems().ToList();
            return Ok(items);
        }

        [HttpGet("GetItemById/{id}")]
        [Authorize(Policy = "BasicUser")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            var items = manager.GetItemById(id);

            return Ok(items);
        }


        [HttpPost("CreateItem")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Create([FromBody] ItemCreationModel itm)
        {
            manager.Create(itm);
            return Ok();
        }

        [HttpPost("UpdateItem")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Update([FromBody] ItemCreationModel itm)
        {
            manager.Update(itm);
            return Ok();
        }

        [HttpDelete("DeleteItem/{id}")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            manager.Delete(id);
            return Ok();
        }


    }
}
