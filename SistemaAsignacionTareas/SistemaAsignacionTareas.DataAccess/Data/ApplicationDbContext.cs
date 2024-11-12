using Microsoft.EntityFrameworkCore;
using GestionDeTrabajo.Data.Entities;

namespace GestionDeTrabajo.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<ItemDeTrabajo> ItemsDeTrabajo { get; set; }
        public DbSet<Asignacion> Asignaciones { get; set; }
    }
}
