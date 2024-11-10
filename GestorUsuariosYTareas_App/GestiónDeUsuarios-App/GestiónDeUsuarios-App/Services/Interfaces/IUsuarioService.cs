using GestionDeUsuarios_App.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestionDeUsuarios_App.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<List<Usuario>> ObtenerUsuariosAsync();
        Task<Usuario> GetUsuarioByIdAsync(int id);
        Task<Usuario> CreateUsuarioAsync(Usuario usuario);
        Task<bool> UpdateUsuarioAsync(int id, Usuario usuario);
        Task<bool> DeleteUsuarioAsync(int id);
    }
}
