using Microsoft.AspNetCore.Mvc;

namespace ProyectoFinalDAMAgil2324.Controllers
{
    public class MainPageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
