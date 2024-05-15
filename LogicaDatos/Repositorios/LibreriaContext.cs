using LogicaNegocio.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDatos.Repositorios
{
    public class LibreriaContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Articulo> Articulos { get; set; }
        public DbSet<Linea> Lineas { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Express> Express { get; set; }
        public DbSet<Comun> Comun { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public LibreriaContext(DbContextOptions options) : base(options) 
        {
        }

       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Cliente>()
                .OwnsOne(c => c.Direccion)
                .Property(dc => dc.Calle)
                .IsRequired()
                .HasColumnName("Calle");

            modelBuilder.Entity<Cliente>()
                .OwnsOne(c => c.Direccion)
                .Property(dc => dc.Numero)
                .IsRequired()
                .HasColumnName("Numero");

            modelBuilder.Entity<Cliente>()
                .OwnsOne(c => c.Direccion)
                .Property(dc => dc.Ciudad)
                .IsRequired()
                .HasColumnName("Ciudad");

            modelBuilder.Entity<Articulo>()
                .HasKey(a => a.Codigo);

            modelBuilder.Entity<Articulo>().Property(a => a.Codigo).ValueGeneratedNever();


            modelBuilder.Entity<Pedido>()
                .HasDiscriminator<string>("TipoPedido")
                .HasValue<Express>("Express").HasValue<Comun>("Comun");

            modelBuilder.Entity<Linea>()
                .HasKey(l => new { l.PedidoId, l.ArticuloId }); // definoo clave foranea

            modelBuilder.Entity<Linea>().HasOne(l => l.Pedido)  // vinculo navegacion de linea a pedido, ida y vuelta. 1 pedido puede tener muchas lineas. con la clave
                                         // foranea vinculo cada linea a un pedido especifico
                  .WithMany(p => p.Lineas)
                  .HasForeignKey(l => l.PedidoId);
            
            modelBuilder.Entity<Linea>().HasOne(l => l.Articulo)  // cada linea esta vinculada a un unico articulo, la clave ArticuloId me ayuda a eso
                  .WithMany()  
                  .HasForeignKey(l => l.ArticuloId);

           
        }


        }
}

