using ProyectoFinalDAMAgil2324.Models;


namespace ProyectoFinalDAMAgil2324.Services.Usuario
{
    public interface IUsuarioService
    {
        //Sirve para autenticar un usuario que se extrae de la bbdd
        Task<Models.Usuario> GetUsuario(string correo, string clave);

        //Sirve guardar un usuario en la bbdd
        Task<Models.Usuario> SaveUsuario(Models.Usuario usuario);
    }
}
