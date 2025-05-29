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

        public DbSet<Usuario> Usuarios { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TipoGasto>()
                .Property(p => p.Codigo)
                .HasComputedColumnSql("'TG' + RIGHT('0000' + CONVERT(VARCHAR(36), [Id]), 4)",
                stored: true);

            //  modelBuilder.Entity<TipoGasto>()
            //.Property(x => x.Codigo)
            //.HasComputedColumnSql("FORMAT(Id, 'D5')"); // autogenera código

            modelBuilder.Entity<GastoDetalle>()
                .HasOne(d => d.Gasto)
                .WithMany(g => g.Detalles)
                .HasForeignKey(d => d.GastoId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<DetallePresupuesto>()
               .HasOne(dp => dp.TipoGasto)
               .WithMany()
               .HasForeignKey(dp => dp.TipoGastoId)
               .OnDelete(DeleteBehavior.Restrict); // 👈 importante

            modelBuilder.Entity<DetallePresupuesto>()
                .HasOne(dp => dp.Presupuesto)
                .WithMany(p => p.Detalles)
                .HasForeignKey(dp => dp.PresupuestoId)
                .OnDelete(DeleteBehavior.Cascade); // solo uno con cascade

            base.OnModelCreating(modelBuilder);

            var adminId = new Guid("D5A620C0-3C2B-4B36-87D5-8E4E8E3E44F4");
            modelBuilder.Entity<Usuario>().HasData(new Usuario
            {
                Id = adminId,
                Nombre = "Administrador",
                UsuarioLogin = "admin",
                ClaveHash = "$2a$11$dkCwSRu5VoQ7MyzVNTAbv.1BUL6DyhVRDkZJIbGBsRz5apcFTLQ5y", // 🔐 hash fijo
                Rol = "Admin"
            });
        }
    }
}
