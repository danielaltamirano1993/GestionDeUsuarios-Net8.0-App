namespace GestionDeTrabajo.Data.Entities
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string NombreUsuario { get; set; }

        public ICollection<ItemDeTrabajo> ItemsDeTrabajoPendientes { get; set; }
    }
}
