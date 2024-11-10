using Microsoft.EntityFrameworkCore;
using GestionDeUsuarios_App.Models;

namespace GestionDeUsuarios_App.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        { }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}
