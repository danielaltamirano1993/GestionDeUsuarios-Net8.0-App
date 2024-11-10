using System;

namespace ItemsDeTrabajo_App.Dtos
{
    public class ItemDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Prioridad { get; set; }

        //public DateTime FechaEntrega { get; set; }
        public string FechaEntrega { get; set; }
        public string Estado { get; set; }
    }

    public class UpdateEstadoDto
    {
        public string NuevoEstado { get; set; }
    }

}
