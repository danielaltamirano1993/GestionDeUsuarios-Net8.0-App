namespace GestionDeTrabajo.Data.Entities
{
    public class ItemDeTrabajo
    {
        public int Id { get; set; }  // Clave primaria

        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaEntrega { get; set; }
        public string Relevancia { get; set; }  // "Alta" o "Baja"


        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}
