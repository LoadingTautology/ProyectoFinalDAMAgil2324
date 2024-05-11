using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoFinalDAMAgil2324.Data;
using ProyectoFinalDAMAgil2324.Services;



namespace ProyectoFinalDAMAgil2324
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            /* ********* Inyeccion Contexto ********* */
            var connectionString = builder.Configuration.GetConnectionString("Default");
            builder.Services.AddDbContext<AppDBContext>(options => { options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)); });
            //https://medium.com/@vahidalizadeh1990/crud-operation-by-repository-pattern-using-net-6-ef-core-sql-server-mysql-mongodb-part-2-25532829b79d

            /* ********* Inyeccion dependencias UsuarioService ********* */
            builder.Services.AddScoped<IUsuarioService, UsuarioService>();
            //Con esta inyeccion de dependencias ya podemos hacer uso en cualquier controlador de la App

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
            {
                options.LoginPath = "/Login/IniciarSesion";
                options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
				options.AccessDeniedPath = "/Login/IniciarSesion";
			});

            //builder.Services.AddControllersWithViews(options =>
            //{
            //    options.Filters.Add(
            //        new ResponseCacheAttribute
            //        {
            //            NoStore = true,
            //            Location = ResponseCacheLocation.None,
            //        }
            //       );
            //});


            builder.Services.AddRazorPages();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=MainPage}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
