using LogicaNegocio.Dominio;
using Microsoft.EntityFrameworkCore;
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
        //public DbSet<Articulo> Articulos { get; set; }
        //public DbSet<Linea> Lineas { get; set; }
        //public DbSet<Pedido> Pedidos { get; set; }
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
        }
    }
}
