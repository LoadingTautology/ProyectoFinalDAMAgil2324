﻿using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinalDAMAgil2324.Models;
using ProyectoFinalDAMAgil2324.Services;
using System.Security.Claims;

namespace ProyectoFinalDAMAgil2324.Controllers
{
    public class LoginController : Controller
    {
        //Inyeccion de dependencias que hay en Program.cs
        private readonly IUsuarioService _usuarioService;
        private readonly UsuarioContext _context;

        public LoginController(IUsuarioService usuarioService, UsuarioContext context)
        {
            _usuarioService = usuarioService;
            _context = context;
        }

        [HttpGet]
        public IActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registro(Usuario usuario, IFormFile Imagen)
        {

            usuario.Clave = Utilidades.EncriptarClave(usuario.Clave);

            Usuario usuarioCreado = await _usuarioService.SaveUsuario(usuario);

            if (usuarioCreado.Id > 0)
            {
                return RedirectToAction("IniciarSesion", "Login");
            }

            ViewData["Mensaje"] = "No se pudo crear el usuario";
            return View();
        }

        [HttpGet]
        public IActionResult IniciarSesion()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> IniciarSesion(string correo, string clave)
        {
            Usuario usuarioEncontrado = await _usuarioService.GetUsuario(correo, Utilidades.EncriptarClave(clave));

            if (usuarioEncontrado == null)
            {
                ViewData["Mensaje"] = "Usuaio no encontrado";
                return View();
            }

            List<Claim> claims = new List<Claim>() { new Claim(ClaimTypes.Name, usuarioEncontrado.NombreUsuario) };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            AuthenticationProperties properties = new AuthenticationProperties(){ AllowRefresh = true };

            await HttpContext.SignInAsync( CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), properties );

            return RedirectToAction("Index", "Home");

        }
    }
}