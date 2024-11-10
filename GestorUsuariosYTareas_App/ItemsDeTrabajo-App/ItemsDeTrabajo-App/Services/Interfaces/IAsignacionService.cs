using System.Threading.Tasks;

namespace ItemsDeTrabajo_App.Services.Interfaces
{
    public interface IAsignacionService
    {
        Task<bool> AsignarItemAUsuario(int itemId);
    }
}