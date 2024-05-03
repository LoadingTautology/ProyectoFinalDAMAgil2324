using Microsoft.AspNetCore.Mvc;
using ProyectoFinalDAMAgil2324.Data;
using ProyectoFinalDAMAgil2324.Models;
using ProyectoFinalDAMAgil2324.ViewModels;

namespace ProyectoFinalDAMAgil2324.Controllers
{
    public class AccesoController : Controller
    {
        private readonly AppDBContext _appDbContext;
        public AccesoController(AppDBContext appDBContext)
        {
            _appDbContext = appDBContext;
        }

        #region Registrarse

        [HttpGet]
        public IActionResult Registrarse()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registrarse(UsuarioVM modelo)
        {
            if (modelo.Clave != modelo.ConfirmarClave)
            {
                ViewData["Mensaje"] = "Las contraseñas no coinciden";
                return View();
            }

            Usuario usuario = new Usuario()
            {
                NombreCompleto = modelo.NombreCompleto,
                Correo = modelo.Correo,
                Clave = modelo.Clave
            };

            await _appDbContext.Usuarios.AddAsync(usuario);
            await _appDbContext.SaveChangesAsync();

            if (usuario.IdUsuario != 0)
            {
                return RedirectToAction("Login", "Acceso");
            }

            ViewData["Mensaje"] = "No se ha podido crear el usuario";

            return View();
        }

        #endregion Registrarse

        #region Login

        [HttpGet]
        public IActionResult Login() {
        
            return View();
        }


        #endregion Login



    }
}
