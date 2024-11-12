using GestionDeTrabajo.Data.Entities;
using GestionDeTrabajo.Data;
using Microsoft.EntityFrameworkCore;

namespace SistemaAsignacionTareas.Services
{
    public class ItemAsignacionService
    {
        private readonly ApplicationDbContext _context;

        public ItemAsignacionService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Método para asignar ítems de trabajo
        public async Task AsignarItemDeTrabajo(ItemDeTrabajo item)
        {
            // Obtener usuarios con menos ítems de trabajo asignados y que no estén saturados
            var usuarioAsignado = await _context.Usuarios
                .Where(u => u.ItemsDeTrabajoPendientes.Count(i => i.Relevancia == "Alta") < 3)
                .OrderBy(u => u.ItemsDeTrabajoPendientes.Count) // Ordenar por cantidad de ítems
                .FirstOrDefaultAsync(); // Solo obtenemos el primero disponible

            if (usuarioAsignado == null)
            {
                throw new Exception("No hay usuarios disponibles para asignar este ítem de trabajo.");
            }

            // Asigna el ítem de trabajo al usuario seleccionado
            item.UsuarioId = usuarioAsignado.UsuarioId;
            _context.ItemsDeTrabajo.Update(item);
            await _context.SaveChangesAsync();
        }

        // Otros métodos según reglas de asignación...
    }
}
