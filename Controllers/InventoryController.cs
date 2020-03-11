using speed_stock.Models;
using speed_stock.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace InventorysApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly InventoryService _inventoryService;

        public InventoryController(InventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        [HttpGet]
        public ActionResult<List<Inventory>> Get() =>
            _inventoryService.Get();

        [HttpGet("{id:length(24)}", Name = "GetInventory")]
        public ActionResult<Inventory> Get(string id)
        {
            var inventory = _inventoryService.Get(id);

            if (inventory == null)
            {
                return NotFound();
            }

            return inventory;
        }

        [HttpPost]
        public ActionResult<Inventory> Create(Inventory inventory)
        {
            _inventoryService.Create(inventory);

            return CreatedAtRoute("GetInventory", new { id = inventory.Id.ToString() }, inventory);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Inventory inventoryIn)
        {
            var inventory = _inventoryService.Get(id);

            if (inventory == null)
            {
                return NotFound();
            }

            _inventoryService.Update(id, inventoryIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var inventory = _inventoryService.Get(id);

            if (inventory == null)
            {
                return NotFound();
            }

            _inventoryService.Remove(inventory.Id);

            return NoContent();
        }
    }
}