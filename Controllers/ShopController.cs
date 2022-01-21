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
    public class ShopController : ControllerBase
    {
        private IShopsManager manager;

        public ShopController(IShopsManager shopsManager)
        {
            this.manager = shopsManager;
        }

        [HttpGet("selectShopsIds")]
        [Authorize(Policy = "BasicUser")]
        public async Task<IActionResult> GetShopsIds()
        {


            var shops = manager.getShops().ToList();




            var shopIds = shops.Select(x => x.Id).ToList();

            return Ok(shopIds);

        }

        [HttpGet("selectShops")]
        [Authorize(Policy = "BasicUser")]
        public async Task<IActionResult> GetShops()
        {
            var shops = manager.getShops().ToList();
            return Ok(shops);
        }

        [HttpGet("GetShopById/{id}")]
        [Authorize(Policy = "BasicUser")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            var shops = manager.GetShopById(id);

            return Ok(shops);
        }

        [HttpPost("CreateShop")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Create([FromBody] ShopCreationModel shp)
        {
            manager.Create(shp);
            return Ok();
        }

        [HttpPost("UpdateShop")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Update([FromBody] ShopCreationModel shp)
        {
            manager.Update(shp);
            return Ok();
        }

        [HttpDelete("DeleteShop/{id}")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            manager.Delete(id);
            return Ok();
        }

        [HttpGet("GetShopsWithEmployee")]
        [Authorize(Policy = "BasicUser")]
        public async Task<IActionResult> JoinEager()
        {
            var authorsWithBooks = manager.GetShopsWithEmployees();

            return Ok(authorsWithBooks);
        }

        [HttpGet("order-by-asc")]
        public async Task<IActionResult> OrderByAsc()
        {
            var orderedShops = manager.GetOrderedShops();

            return Ok(orderedShops);
        }

    }
}
