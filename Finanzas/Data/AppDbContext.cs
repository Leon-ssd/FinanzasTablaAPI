// Finanzas/Data/AppDbContext.cs
using Finanzas.Models;
using Microsoft.EntityFrameworkCore;

namespace Finanzas.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // Tu tabla
        public DbSet<Moneda> Monedas { get; set; }

        // TODO: Tus compañeros agregarán aquí sus DbSet<OtraTabla>
    }
}