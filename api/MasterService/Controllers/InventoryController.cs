using MasterService.Models.Inventory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private IInventory _inventory;
        public InventoryController(IInventory inventory)
        {
            _inventory = inventory;
        }

        [HttpGet("get-inventory")]
        public IActionResult GetInventory()
        {
           return Ok(_inventory.GetInventories());
        }

        [HttpGet("get-inventory/{id}")]
        public IActionResult GetInventory(int id)
        {
            return Ok(_inventory.GetInventory(id));
        }
    }
}
