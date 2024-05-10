using ProyectoFinalDAMAgil2324.Models;

namespace ProyectoFinalDAMAgil2324.Services
{
    public interface IUsuarioService
    {
        //Sirve para autenticar un usuario que se extrae de la bbdd
        Task<Usuario> GetUsuario(string correo, string clave);

        //Sirve guardar un usuario en la bbdd
        Task<Usuario> SaveUsuario(Usuario usuario);
    }
}
