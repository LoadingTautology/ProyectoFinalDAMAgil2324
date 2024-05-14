using Microsoft.EntityFrameworkCore;
using ProyectoFinalDAMAgil2324.Migrations;
using ProyectoFinalDAMAgil2324.Models;

namespace ProyectoFinalDAMAgil2324.Services.Usuario
{
    public class UsuarioService : ProyectoFinalDAMAgil2324.Services.Usuario.IUsuarioService
    {
        //Inyecta la base de datos para poder implementar los metodos de la interfaz
        private readonly CampusbbddContext _context;


        public UsuarioService(CampusbbddContext context)
        {
            _context = context;
        }
        //Nos conectamos a la base de datos y le pedimos que traiga un usuario que cumpla con las especificaciones de "correo" y "clave"
        public async Task<Models.Usuario> GetUsuario(string correo, string clave)
        {
			Models.Usuario usuario = await _context.Usuarios.Where(user => user.Email == correo && user.Clave == clave).FirstOrDefaultAsync();

            return usuario;
        }

        //Creamos un usuario y lo introducimos en la base de datos.
        public async Task<Models.Usuario> SaveUsuario(Models.Usuario usuario)
        {

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

    }
}
