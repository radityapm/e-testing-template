using MasterService.Libs;
using MasterService.Models.Inventory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InventoryController : ControllerBase
    {
        private readonly InventoryDAL inventoryService;

        public InventoryController(InventoryDAL _inventoryService)
        {
            inventoryService = _inventoryService;
        }

        [Route("get-inventory")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<PagedResult<InventoryModel>>> List()
        {
            int page = 1;
            int pagesize = 25;
            var count = await inventoryService.CountAll();
            var items = await inventoryService.Filter(page, pagesize);
            var pagedResult = new PagedResult<InventoryModel>(items, count, page, pagesize);

            return pagedResult;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<InventoryModel>> Retrieve(int id)
        {
            return await inventoryService.FindOne(id);
        }
    }
}
