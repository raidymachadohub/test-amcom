using Microsoft.EntityFrameworkCore;
using Questao5.Domain.Entities;

namespace Questao5.Infrastructure.Context
{
    public class Q5Context : DbContext
    {
        public Q5Context(DbContextOptions<Q5Context> options) : base(options) { }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=./database.sqlite");
        }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ContaCorrente>().HasKey(m => m.IdContaCorrente);
            builder.Entity<Movimento>().HasKey(m => m.IdMovimento);
            builder.Entity<Potencia>().HasKey(m => m.IdPotencia);
            
            base.OnModelCreating(builder);
        }
        public DbSet<ContaCorrente> ContaCorrente { get; set; }
        public DbSet<Movimento> Movimento { get; set; }
        public DbSet<Potencia> Potencias { get; set; }
    }
}