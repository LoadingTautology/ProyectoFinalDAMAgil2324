using Microsoft.EntityFrameworkCore;
using ProyectoFinalDAMAgil2324.Models;

namespace ProyectoFinalDAMAgil2324.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }

    }
}
