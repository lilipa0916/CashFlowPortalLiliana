using CashFlowPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CashFlowPortal.Infraestructura.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) :
           base(options)
        { }

        public DbSet<TipoGasto> TiposGasto => Set<TipoGasto>();
        public DbSet<FondoMonetario> Fondos => Set<FondoMonetario>();
        public DbSet<Presupuesto> Presupuestos => Set<Presupuesto>();
        public DbSet<Gasto> Gastos => Set<Gasto>();
        public DbSet<GastoDetalle> GastoDetalles => Set<GastoDetalle>();
        public DbSet<Deposito> Depositos => Set<Deposito>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TipoGasto>()
                .Property(p => p.Codigo)
                .HasComputedColumnSql("'TG' + RIGHT('0000' + CAST([Id] AS VARCHAR), 4)", stored: true);

          //  modelBuilder.Entity<TipoGasto>()
          //.Property(x => x.Codigo)
          //.HasComputedColumnSql("FORMAT(Id, 'D5')"); // autogenera código

            modelBuilder.Entity<GastoDetalle>()
                .HasOne(d => d.Gasto)
                .WithMany(g => g.Detalles)
                .HasForeignKey(d => d.GastoId)
                .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<Usuario>().HasData(new Usuario
            //{
            //    Id = 1,
            //    Username = "admin",
            //    Password = "admin", // Puedes encriptarlo más adelante
            //});

            base.OnModelCreating(modelBuilder);
        }
    }
}
