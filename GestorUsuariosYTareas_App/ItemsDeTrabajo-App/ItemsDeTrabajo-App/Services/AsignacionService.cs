using System;
using System.Linq;
using System.Threading.Tasks;
using ItemsDeTrabajo_App.Models;
using ItemsDeTrabajo_App.Services.Interfaces;
using GestionDeUsuarios_App.Services.Interfaces;
using GestionDeUsuarios_App.Models;
using Microsoft.EntityFrameworkCore; 

namespace ItemsDeTrabajo_App.Services
{
    public class AsignacionService : IAsignacionService
    {
        private readonly IItemService _itemService;
        private readonly IUsuarioService _usuarioService;

        public AsignacionService(IItemService itemService, IUsuarioService usuarioService)
        {
            _itemService = itemService;
            _usuarioService = usuarioService;
        }

        public async Task<bool> AsignarItemAUsuario(int itemId)
        {
            var item = await _itemService.ObtenerItemPorId(itemId);
            if (item == null)
            {
                return false;
            }

            var fechaLimite = DateTime.Now.AddDays(2);
            bool esFechaProxima = item.FechaEntrega <= fechaLimite;
          
            var usuarios = await _usuarioService.ObtenerUsuariosAsync();
            var usuariosOrdenados = usuarios
                .OrderBy(u => u.ConteoPendientes)
                .ToList();

            Usuario usuarioAsignado = null;

            if (esFechaProxima)
            {
                usuarioAsignado = usuariosOrdenados.FirstOrDefault();
            }
            else
            {
                if (item.Prioridad == "Alta")
                {
                    usuarioAsignado = usuariosOrdenados.FirstOrDefault();
                }
            }

            if (usuarioAsignado != null)
            {
                item.UsuarioAsignadoId = usuarioAsignado.Id;
                await _itemService.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
