using System.Text.Json.Serialization;

namespace GestionDeTrabajo.Data.Entities
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string NombreUsuario { get; set; }

        [JsonIgnore]
        public ICollection<ItemDeTrabajo> ItemsDeTrabajoPendientes { get; set; }
    }
}
