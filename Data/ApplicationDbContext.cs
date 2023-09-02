using Barberia.Models;

using Microsoft.AspNetCore.Identity;

using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Barberia.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public ApplicationDbContext()
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("BarberiaCnn");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
        public DbSet<Event> Events { get; set; }
        public DbSet<Zona> Zonas { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<DetalleCompra> DetalleCompras { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<Carrito> Carritos { get; set; }

    }
}
