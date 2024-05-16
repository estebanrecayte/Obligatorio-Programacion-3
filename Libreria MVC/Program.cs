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
builder.Services.AddScoped<ICUAlta<ArticuloDTO>, CUAltaArticulo>();
builder.Services.AddScoped<ICUAlta<PedidoDTO>, CUAltaPedido>();
//builder.Services.AddScoped<ICUAlta<Linea>, 
//    >();

builder.Services.AddScoped<ICUBaja<Usuario>, CUBajaUsuario>();
builder.Services.AddScoped<ICUBaja<Cliente>, CUBajaCliente>();
builder.Services.AddScoped<ICUBaja<Pedido>, CUBajaPedido>();

builder.Services.AddScoped<ICUModificar<Pedido>, CUModificarPedido>();


builder.Services.AddScoped<ICUBuscarArticuloPorCodigo, CUBuscarArticuloPorCodigo>();
builder.Services.AddScoped<ICUBuscarPorId<Usuario>, CUBuscarUsuarioPorId>();
builder.Services.AddScoped<ICUBuscarPorId<Pedido>, CUBuscarPedidoPorId>();
builder.Services.AddScoped<ICUBuscarClientePorNombre, CUBuscarClientePorNombre>();
builder.Services.AddScoped<ICUBuscarClientePorPedidoMayor, CUBuscarClientePorPedidoMayor>(); 
builder.Services.AddScoped<ICUObtenerImporteTotalPedido, CUObtenerImporteTotalPedido>();

builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuarioEF>();
builder.Services.AddScoped<IRepositorioCliente, RepositorioClienteEF>();
builder.Services.AddScoped<IRepositorioPedido, RepositorioPedidoEF>();
builder.Services.AddScoped<IRepositorioLinea, RepositorioLineaEF>();
builder.Services.AddScoped<IRepositorioArticulo, RepositorioArticuloEF>();

builder.Services.AddScoped<ICUModificar<Usuario>, CUModificarUsuario>();
builder.Services.AddScoped<ICUModificar<Cliente>, CUModificarCliente>();

builder.Services.AddScoped<ICUListado<Usuario>, CUListadoUsuario>();
builder.Services.AddScoped<ICUListado<Cliente>, CUListadoCliente>();
builder.Services.AddScoped<ICUListado<Pedido>, CUListadoPedidos>();
builder.Services.AddScoped<ICUListado<Articulo>, CUListadoArticulo>();
//builder.Services.AddScoped<ICUListado<Linea>, CUListadoLinea>();
builder.Services.AddScoped<ICUObtenerListadoAnulados, CUObtenerListadoAnulados>();

builder.Services.AddScoped<ICUBuscarPedidoPorFecha, CUBuscarPedidoPorFecha>();

builder.Services.AddScoped<ICULogin , CULogin>();

string strCon = builder.Configuration.GetConnectionString("MiBase");
builder.Services.AddDbContext<LibreriaContext>(options => options.UseSqlServer(strCon));
builder.Services.AddSession();

builder.Services.AddControllersWithViews();






builder.Services.AddHttpContextAccessor();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseSession();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
