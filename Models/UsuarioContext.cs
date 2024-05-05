using Microsoft.EntityFrameworkCore;

namespace ProyectoFinalDAMAgil2324.Models
{
    public class UsuarioContext
    {
        public UsuarioContext(DbContextOptions<UsuarioContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }

    }
}
