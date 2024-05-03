using Microsoft.AspNetCore.Mvc;
using ProyectoFinalDAMAgil2324.Data;
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
        public IActionResult Registrarse(UsuarioVM modelo)
        {
            return View();
        }

        #endregion Registrarse
    }
}
