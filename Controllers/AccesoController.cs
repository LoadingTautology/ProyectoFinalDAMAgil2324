using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoFinalDAMAgil2324.Data;
using ProyectoFinalDAMAgil2324.Models;
using ProyectoFinalDAMAgil2324.ViewModels;

using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

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
            //Comprueba que las contraseñas coinciden
            bool contraseñasCoinciden = true;
            if (!modelo.Clave.ToString().Equals(modelo.ConfirmarClave.ToString()))
            {
                ViewData["Mensaje"] = "Las contraseñas no coinciden";
                contraseñasCoinciden = false;
            }

            //Si coinciden comprueba que no haya otro usuario con ese correo
            if (contraseñasCoinciden)
            {
                Usuario? usuario_encontrado = await _appDbContext.Usuarios
                                            .Where(u =>
                                                u.Correo == modelo.Correo
                                            ).FirstOrDefaultAsync();

                //Si no encuentra otro usuario con ese correo entonces intenta crear el usuario
                if (usuario_encontrado == null)
                {
                    Usuario usuario = new Usuario()
                    {
                        NombreCompleto = modelo.NombreCompleto,
                        Correo = modelo.Correo,
                        Clave = modelo.Clave
                    };

                    await _appDbContext.Usuarios.AddAsync(usuario);
                    await _appDbContext.SaveChangesAsync();

                    bool usuarioCreado = true;

                    if (usuario.IdUsuario == 0)
                    {
                        ViewData["Mensaje"] = "No se ha podido crear el usuario";
                        usuarioCreado = false;
                    }

                    if (usuarioCreado)
                    {
                        return RedirectToAction("Login", "Acceso");
                    }

                } else
                {
                    ViewData["Mensaje"] = "Correo ya registrado";
                }
                
            }

            return View();
        }
        #endregion

        #region Login

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginVM modelo)
        {
            Usuario? usuario_encontrado = await _appDbContext.Usuarios
                                            .Where(u =>
                                                u.Correo == modelo.Correo &&
                                                u.Clave == modelo.Clave
                                            ).FirstOrDefaultAsync();
            if (usuario_encontrado == null)
            {
                ViewData["Mensaje"] = "No se ha encontrado el usuario, correo o contraseña incorrectos";
                return View();
            }

            List<Claim> claims= new List<Claim>()
            {
                new Claim(ClaimTypes.Name, usuario_encontrado.NombreCompleto)
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            AuthenticationProperties authProperties = new AuthenticationProperties()
            {
                AllowRefresh = true,
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties
                );

            return RedirectToAction("Index", "Home");
        }
        #endregion
    }
}