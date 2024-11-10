using ItemsDeTrabajo_App.Models;
using ItemsDeTrabajo_App.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GestionDeUsuarios_App.Models;

namespace ItemsDeTrabajo_App.Services.Interfaces
{
    public interface IItemService
    {
        Task<ItemDto> CreateItem(ItemDto itemDto);
        Task<IEnumerable<ItemDto>> GetAllItems();
        Task<Item> ObtenerItemPorId(int id);
        Task<Item> GetItemByIdAsync(int id);
        Task UpdateItem(Item item);
        Task<bool> DeleteItem(int id);
        Task<bool> AsignarItemAUsuario(int itemId, int usuarioId);

        DbSet<Item> Items { get; }
        Task SaveChangesAsync();
        Task<IQueryable<Usuario>> ObtenerUsuariosAsync();
    }
}
