using DTOs;
using LogicaAplicacion.CasosUso;
using LogicaAplicacion.InterfacesCasosUso;
using LogicaDatos.Repositorios;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorio;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ICUAlta<UsuarioDTO>, CUAltaUsuario>();
builder.Services.AddScoped<ICUAlta<ClienteDTO>, CUAltaCliente>();

builder.Services.AddScoped<ICUBaja<Usuario>, CUBajaUsuario>();
builder.Services.AddScoped<ICUBaja<Cliente>, CUBajaCliente>();

builder.Services.AddScoped<ICUBuscarPorId<Usuario>, CUBuscarUsuarioPorId>();
builder.Services.AddScoped<ICUBuscarClientePorNombre, CUBuscarClientePorNombre>();

builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuarioEF>();
builder.Services.AddScoped<IRepositorioCliente, RepositorioClienteEF>();

builder.Services.AddScoped<ICUModificar<Usuario>, CUModificarUsuario>();
builder.Services.AddScoped<ICUModificar<Cliente>, CUModificarCliente>();

builder.Services.AddScoped<ICUListado<Usuario>, CUListadoUsuario>();

builder.Services.AddScoped<ICUListado<Cliente>, CUListadoCliente>();

builder.Services.AddScoped<ICULogin , CULogin>();

string strCon = builder.Configuration.GetConnectionString("MiBase");

builder.Services.AddDbContext<LibreriaContext>(options => options.UseSqlServer(strCon));

builder.Services.AddControllersWithViews();

builder.Services.AddSession();



builder.Services.AddHttpContextAccessor();

var app = builder.Build();

app.UseSession();

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
