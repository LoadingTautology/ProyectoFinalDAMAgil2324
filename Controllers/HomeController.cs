using Microsoft.AspNetCore.Mvc;
using ProyectoFinalDAMAgil2324.Models;
using System.Diagnostics;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace ProyectoFinalDAMAgil2324.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //public async Task<ActionResult> Salir()
        //{
        //    await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        //    return RedirectToAction("Login", "Acceso");
        //}

        public async Task<IActionResult> Salir()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            
            //HttpContext.Session.Clear();

            return RedirectToAction("Login", "Acceso");
        }


        //public async Task<ActionResult> Salir()
        //{
        //    if (HttpContext.Request.Cookies.Count > 0)
        //    {
        //        var siteCookies = HttpContext.Request.Cookies.Where(c => c.Key.Contains(".AspNetCore.") || c.Key.Contains("Microsoft.Authentication"));
        //        foreach (var cookie in siteCookies)
        //        {
        //            Response.Cookies.Delete(cookie.Key);
        //        }
        //    }

        //    await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        //    HttpContext.Session.Clear();
        //    return RedirectToAction("Login", "Acceso");
        //}

        //public async Task<ActionResult> Salir()
        //{
        //    if (HttpContext.Request.Cookies.Count> 0)
        //    {
        //        var siteCookies = HttpContext.Request.Cookies.Where(c => c.Key.Contains(".AspNetCore.") || c.Key.Contains("Microsoft.Authentication"));
        //        foreach (var cookie in siteCookies)
        //        {
        //            Response.Cookies.Delete(cookie.Key);
        //        }
        //    }

        //    await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        //    HttpContext.Session.Clear();
        //    return RedirectToAction("Login", "Acceso");
        //}


        /*Acceso/Registrarse

        // in some controller/handler, notice the "bare" Task return value
        public async Task LogoutAction()
        {
            // SomeOtherPage is where we redirect to after signout
            await MyCustomSignOut("Acceso/Registrarse");
        }

        // probably in some utility service
        public async Task MyCustomSignOut(string redirectUri)
        {
            // inject the HttpContextAccessor to get "context"
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            var prop = new AuthenticationProperties()
            {
                RedirectUri = redirectUri
            };
            // after signout this will redirect to your provided target
            await HttpContext.SignOutAsync(, prop);
        }
        */
    }
}
//pedrolachuspa