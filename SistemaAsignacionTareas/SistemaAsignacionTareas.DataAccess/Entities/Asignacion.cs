namespace GestionDeTrabajo.Data.Entities
{
    public class Asignacion
    {
        public int AsignacionId { get; set; }
        public int UsuarioId { get; set; }
        public int ItemId { get; set; }
        public DateTime FechaAsignacion { get; set; }
        public string EstadoAsignacion { get; set; }  // "Pendiente" o "Completado"

        // Relación con las entidades Usuario y ItemDeTrabajo
        public Usuario Usuario { get; set; }
        public ItemDeTrabajo ItemDeTrabajo { get; set; }
    }
}
