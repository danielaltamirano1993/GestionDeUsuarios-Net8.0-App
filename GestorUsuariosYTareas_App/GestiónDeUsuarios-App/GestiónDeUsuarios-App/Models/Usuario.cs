namespace GestionDeUsuarios_App.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public int ConteoPendientes { get; set; }
        public int ConteoAltaPrioridad { get; set; }
    }
}
