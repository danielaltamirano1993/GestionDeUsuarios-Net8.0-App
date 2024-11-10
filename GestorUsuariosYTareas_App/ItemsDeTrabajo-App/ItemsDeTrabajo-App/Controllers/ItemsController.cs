using ItemsDeTrabajo_App.Models;
using ItemsDeTrabajo_App.Dtos;
using ItemsDeTrabajo_App.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ItemsDeTrabajo_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IItemService _itemService;

        public ItemsController(IItemService itemService)
        {
            _itemService = itemService;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemDto>>> GetItems()
        {
            var items = await _itemService.GetAllItems();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> GetItem(int id)
        {
            var item = await _itemService.GetItemByIdAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<ItemDto>> PostItem(ItemDto itemDto)
        {
            var item = await _itemService.CreateItem(itemDto);
            return CreatedAtAction(nameof(GetItem), new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutItem(int id, Item item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            await _itemService.UpdateItem(item);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            var result = await _itemService.DeleteItem(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost("assign")]
        public async Task<IActionResult> AssignItemToUser(int itemId, int usuarioId)
        {
            var result = await _itemService.AsignarItemAUsuario(itemId, usuarioId);
            if (!result)
            {
                return NotFound("Item or User not found.");
            }

            return NoContent();
        }
    }
}
