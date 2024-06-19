
using DTOs;
using LogicaAplicacion.CasosUso;
using LogicaAplicacion.InterfacesCasosUso;
using LogicaDatos.Repositorios;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorio;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.IdentityModel.Tokens;

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
            builder.Services.AddScoped<ICUListado<MovimientoStockDTO>, CUListadoMovimientoStock>();           
            builder.Services.AddScoped<ICUBuscarPorId<MovimientoStockDTO>, CUBuscarMovimientoStockPorId>();


            builder.Services.AddScoped<IRepositorioArticulo, RepositorioArticuloEF>();
            builder.Services.AddScoped<ICUAlta<ArticuloDTO>, CUAltaArticulo>();
            builder.Services.AddScoped<ICUListado<ArticuloDTO>, CUListadoArticulo>();

            builder.Services.AddScoped<IRepositorioPedido, RepositorioPedidoEF>();
            builder.Services.AddScoped<ICUObtenerListadoAnulados, CUObtenerListadoAnulados>();

            builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuarioEF>();

            builder.Services.AddScoped<ICULoginUsuarios, CULoginUsuarios>();

            builder.Services.AddScoped<ICUCantidadTotalMovimientoStock, CUCantidadTotalMovimientoStock>();
            builder.Services.AddScoped<ICUMovimientosAMostrarPorPagina, CUMovimientosAMostrarPorPagina>();
            builder.Services.AddScoped<ICUObtenerArticulosConMovimientosEntreFechas, CUObtenerArticulosConMovimientosEntreFechas>();
            builder.Services.AddScoped<ICUObtenerMovimientosPorArticuloYTipo, CUObtenerMovimientosPorArticuloYTipo>();
            builder.Services.AddScoped<ICUResumenCantidadMovida, CUResumenCantidadMovida>();






            string strCon = builder.Configuration.GetConnectionString("MiBase");

            builder.Services.AddDbContext<LibreriaContext>(options => options.UseSqlServer(strCon));

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var claveSecreta = "ZWRpw6fDo28gZW0gY29tcHV0YWRvcmE=";
            builder.Services.AddAuthentication(aut => {
                aut.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                aut.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(aut => {
                aut.RequireHttpsMetadata = false;
                aut.SaveToken = true;
                aut.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.ASCII.GetBytes(claveSecreta)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });


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
