using Microsoft.EntityFrameworkCore;
using ProyectoFinalDAMAgil2324.Data;
using ProyectoFinalDAMAgil2324.Models;

namespace ProyectoFinalDAMAgil2324.Services
{
    public class UsuarioService : IUsuarioService
    {
        //Inyecta la base de datos para poder implementar los metodos de la interfaz
        private readonly AppDBContext _context;


        public UsuarioService(AppDBContext context)
        {
            _context = context;
        }
        //Nos conectamos a la base de datos y le pedimos que traiga un usuario que cumpla con las especificaciones de "correo" y "clave"
        public async Task<Usuario> GetUsuario(string correo, string clave)
        {
            Usuario usuario = await _context.Usuarios.Where(user => user.Correo == correo && user.Clave == clave).FirstOrDefaultAsync();

            return usuario;
        }

        //Creamos un usuario y lo introducimos en la base de datos.
        public async Task<Usuario> SaveUsuario(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

    }
}
