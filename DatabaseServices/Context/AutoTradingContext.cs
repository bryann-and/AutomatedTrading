using System;
using Database.Entities.Base;
using Database.Entities.CoinBase;
using Database.Entities.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Database.Context
{
    public partial class AutoTradingContext : DbContext
    {
        public AutoTradingContext(DbContextOptions<AutoTradingContext> options) : base(options) { }

        // Sistema
        public DbSet<Pessoa> Pessoa { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        // Base Entities
        public DbSet<BaseOrder> BaseOrder { get; set; }

        // CoinBase Entities
        public DbSet<CoinBaseOrder> CoinBaseOrder { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurando as relações
            modelBuilder.Entity<Usuario>().HasOne(u => u.Pessoa);
            modelBuilder.Entity<BaseOrder>().HasOne(b => b.Usuario);
            modelBuilder.Entity<CoinBaseOrder>().HasOne(c => c.BaseOrder);
        }
    }
}
