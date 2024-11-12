using GestionDeTrabajo.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using SistemaAsignacionTareas.Services;

namespace SistemaAsignacionTareas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemDeTrabajoController : ControllerBase
    {
        private readonly ItemAsignacionService _asignacionService;

        public ItemDeTrabajoController(ItemAsignacionService asignacionService)
        {
            _asignacionService = asignacionService;
        }

        [HttpPost("asignar")]
        public async Task<IActionResult> AsignarItem([FromBody] ItemDeTrabajo item)
        {
            try
            {
                await _asignacionService.AsignarItemDeTrabajo(item);
                return Ok(new { message = "Ítem de trabajo asignado exitosamente." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        // Otros métodos para obtener ítems pendientes o completados, etc.
    }
}
