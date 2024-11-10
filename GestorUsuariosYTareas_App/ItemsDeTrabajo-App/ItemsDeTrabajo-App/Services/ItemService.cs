using ItemsDeTrabajo_App.Data;
using ItemsDeTrabajo_App.Dtos;
using ItemsDeTrabajo_App.Models;
using GestionDeUsuarios_App.Models;
using GestionDeUsuarios_App.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ItemsDeTrabajo_App.Services.Interfaces;

namespace ItemsDeTrabajo_App.Services
{
    public class ItemService : IItemService
    {
        private readonly ApplicationDbContext _context;

        public ItemService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ItemDto> CreateItem(ItemDto itemDto)
        {
            DateTime fechaEntrega = DateTime.Parse(itemDto.FechaEntrega);

            var item = new Item
            {
                Titulo = itemDto.Titulo,
                Descripcion = itemDto.Descripcion,
                Prioridad = itemDto.Prioridad,
                FechaEntrega = fechaEntrega,
                Estado = itemDto.Estado,
                FechaCreacion = DateTime.UtcNow,
                FechaActualizacion = DateTime.UtcNow
            };

            _context.Items.Add(item);
            await _context.SaveChangesAsync();

            itemDto.Id = item.Id;
            return itemDto;
        }

        public async Task<IEnumerable<ItemDto>> GetAllItems()
        {
            return await _context.Items.Select(i => new ItemDto
            {
                Id = i.Id,
                Titulo = i.Titulo,
                Descripcion = i.Descripcion,
                Prioridad = i.Prioridad,
                FechaEntrega = i.FechaEntrega.ToString("yyyy-MM-dd"),
                Estado = i.Estado
            }).ToListAsync();
        }

        public async Task<Item> ObtenerItemPorId(int id)
        {
            return await _context.Items.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Item> GetItemByIdAsync(int id)
        {
            return await _context.Items.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task UpdateItem(Item item)
        {
            var existingItem = await _context.Items.FirstOrDefaultAsync(i => i.Id == item.Id);
            if (existingItem != null)
            {
                existingItem.Titulo = item.Titulo;
                existingItem.Descripcion = item.Descripcion;
                existingItem.Prioridad = item.Prioridad;
                existingItem.FechaEntrega = item.FechaEntrega;
                existingItem.Estado = item.Estado;
                existingItem.FechaActualizacion = DateTime.UtcNow;

                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> DeleteItem(int id)
        {
            var item = await _context.Items.FirstOrDefaultAsync(i => i.Id == id);

            if (item != null)
            {
                _context.Items.Remove(item);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<bool> AsignarItemAUsuario(int itemId, int usuarioId)
        {
            var item = await _context.Items.FindAsync(itemId);
            var usuario = await _context.Usuarios.FindAsync(usuarioId);

            if (item == null || usuario == null) return false;

            item.UsuarioAsignadoId = usuarioId;
            await _context.SaveChangesAsync();
            return true;
        }

        public DbSet<Item> Items => _context.Set<Item>();

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<IQueryable<Usuario>> ObtenerUsuariosAsync()
        {
            return _context.Usuarios.AsQueryable();
        }
    }
}
