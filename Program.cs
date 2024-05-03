using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.EntityFrameworkCore;
using ProyectoFinalDAMAgil2324.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Add context Pedro
var connectionString = builder.Configuration.GetConnectionString("Default");

builder.Services.AddDbContext<AppDBContext>(options =>
        options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
//https://medium.com/@vahidalizadeh1990/crud-operation-by-repository-pattern-using-net-6-ef-core-sql-server-mysql-mongodb-part-2-25532829b79d
/*
builder.Services.AddDbContext<AppDBContext>(options =>
        options.UseMySql(builder.Configuration.GetConnectionString("Default"), Microsoft.EntityFrameworkCore.ServerVersion.Parse("11.3.2-mariadb")));
*/


builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
   .AddNegotiate();

builder.Services.AddAuthorization(options =>
{
    // By default, all incoming requests will be authorized according to the default policy.
    options.FallbackPolicy = options.DefaultPolicy;
});
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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
