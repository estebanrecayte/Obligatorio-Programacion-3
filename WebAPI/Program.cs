
using DTOs;
using LogicaAplicacion.CasosUso;
using LogicaAplicacion.InterfacesCasosUso;
using LogicaDatos.Repositorios;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorio;
using Microsoft.EntityFrameworkCore;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddScoped<IRepositorioTipoMovimientoStock, RepositorioTipoMovimientoStockEF>();
            builder.Services.AddScoped<ICUAlta<TipoMovimientoStockDTO>, CUAltaTipoMovimientoStock>();
            builder.Services.AddScoped<ICUModificar<TipoMovimientoStockDTO>, CUModificarTipoMovimientoStock>();
            builder.Services.AddScoped<ICUListado<TipoMovimientoStockDTO>, CUListadoTipoMovimientoStock>();
            builder.Services.AddScoped<ICUBaja<TipoMovimientoStockDTO>, CUBajaTipoMovimientoStock>();
            builder.Services.AddScoped<ICUBuscarPorId<TipoMovimientoStockDTO>, CUBuscarTipoMovimientoStockPorId>();

            builder.Services.AddScoped<IRepositorioMovimientoStock, RepositorioMovimientoStockEF>();
            builder.Services.AddScoped<ICUAlta<MovimientoStockDTO>, CUAltaMovimientoStock>();
            builder.Services.AddScoped<ICUModificar<MovimientoStockDTO>, CUModificarMovimientoStock>();
            builder.Services.AddScoped<ICUListado<MovimientoStockDTO>, CUListadoMovimientoStock>();
            builder.Services.AddScoped<ICUBaja<MovimientoStockDTO>, CUBajaMovimientoStock>();
            builder.Services.AddScoped<ICUBuscarPorId<MovimientoStockDTO>, CUBuscarMovimientoStockPorId>();


            builder.Services.AddScoped<IRepositorioArticulo, RepositorioArticuloEF>();
            builder.Services.AddScoped<ICUAlta<ArticuloDTO>, CUAltaArticulo>();
            builder.Services.AddScoped<ICUListado<ArticuloDTO>, CUListadoArticulo>();

            builder.Services.AddScoped<IRepositorioPedido, RepositorioPedidoEF>();
            builder.Services.AddScoped<ICUObtenerListadoAnulados, CUObtenerListadoAnulados>();

            builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuarioEF>();


            string strCon = builder.Configuration.GetConnectionString("MiBase");

            builder.Services.AddDbContext<LibreriaContext>(options => options.UseSqlServer(strCon));

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
