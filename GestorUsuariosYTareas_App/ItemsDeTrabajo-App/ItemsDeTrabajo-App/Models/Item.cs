namespace ItemsDeTrabajo_App.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Prioridad { get; set; }
        public DateTime FechaEntrega { get; set; }
        public string Estado { get; set; }
        public int? UsuarioAsignadoId { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActualizacion { get; set; }
    }
}
