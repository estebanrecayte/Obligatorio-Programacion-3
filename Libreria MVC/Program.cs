using LogicaAplicacion.CasosUso;
using LogicaAplicacion.InterfacesCasosUso;
using LogicaDatos.Repositorios;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorio;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<ICUAlta<Usuario>, CUAltaUsuario>();

builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuarioEF>();

builder.Services.AddScoped<ICUListado<Usuario>, CUListadoUsuario>();

builder.Services.AddScoped<ICULogin , CULogin>();

string strCon = builder.Configuration.GetConnectionString("MiBase");

builder.Services.AddDbContext<LibreriaContext>(options => options.UseSqlServer(strCon));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
