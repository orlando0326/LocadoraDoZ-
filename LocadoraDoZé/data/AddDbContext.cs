using Locadora_ze.api.models;
using LocadoraDoZe.Models;
using Microsoft.EntityFrameworkCore;

namespace Locadora_ze.api.data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>
       options) : base(options)
        {

        }
        public DbSet<cliente> clientes { get; set; }
        public DbSet<locacoes> locacoes { get; set; }
        public DbSet<Patinetes> patinetes { get; set; }
    }
}