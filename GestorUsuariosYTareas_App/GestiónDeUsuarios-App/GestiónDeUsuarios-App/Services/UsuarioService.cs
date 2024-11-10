using GestionDeUsuarios_App.Data;
using GestionDeUsuarios_App.Models;
using GestionDeUsuarios_App.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GestionDeUsuarios_App.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly ApplicationDbContext _context;

        public UsuarioService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario> GetUsuarioByIdAsync(int id)
        {
            return await _context.Usuarios.FindAsync(id);
        }

        public async Task<Usuario> CreateUsuarioAsync(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task<bool> UpdateUsuarioAsync(int id, Usuario usuario)
        {
            var existingUser = await _context.Usuarios.FindAsync(id);
            if (existingUser == null) return false;

            existingUser.NombreUsuario = usuario.NombreUsuario;
            existingUser.ConteoAltaPrioridad = usuario.ConteoAltaPrioridad;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteUsuarioAsync(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null) return false;

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Usuario>> ObtenerUsuariosAsync()
        {
            return await _context.Usuarios.ToListAsync();
        }
    }
}
