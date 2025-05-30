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

        public DbSet<PresupuestoDetalle> PresupuestoDetalle => Set<PresupuestoDetalle>();
        public DbSet<Gasto> Gastos => Set<Gasto>();
        public DbSet<GastoDetalle> GastoDetalles => Set<GastoDetalle>();
        public DbSet<Deposito> Depositos => Set<Deposito>();

        public DbSet<Usuario> Usuarios { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
         
           
            modelBuilder.Entity<TipoGasto>()
                .HasKey(t => t.Id);

           
            modelBuilder.Entity<GastoDetalle>()
                .HasOne(d => d.Gasto)
                .WithMany(g => g.Detalles)
                .HasForeignKey(d => d.GastoId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Presupuesto>(b =>
            {
                b.HasKey(p => p.Id);
                b.Property(p => p.Id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");
                b.Property(p => p.Mes).IsRequired();
                b.Property(p => p.Monto).HasColumnType("decimal(18,2)");
                b.HasIndex(p => new { p.UsuarioId, p.TipoGastoId, p.Mes }).IsUnique();
                b.HasMany(p => p.Detalles)
                 .WithOne(d => d.Presupuesto)
                 .HasForeignKey(d => d.PresupuestoId)
                 .OnDelete(DeleteBehavior.Cascade);
            });
            modelBuilder.Entity<PresupuestoDetalle>(b =>
            {
                b.HasKey(d => d.Id);
                b.Property(d => d.Id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");
                b.Property(d => d.MontoPresupuestado).HasColumnType("decimal(18,2)");
            });

            modelBuilder.Entity<PresupuestoDetalle>()
               .HasOne(dp => dp.TipoGasto)
               .WithMany()
               .HasForeignKey(dp => dp.TipoGastoId)
               .OnDelete(DeleteBehavior.Restrict); // 👈 importante

            modelBuilder.Entity<PresupuestoDetalle>()
                .HasOne(dp => dp.Presupuesto)
                .WithMany(p => p.Detalles)
                .HasForeignKey(dp => dp.PresupuestoId)
                .OnDelete(DeleteBehavior.Cascade); // solo uno con cascade


            // FondoMonetario
            modelBuilder.Entity<FondoMonetario>(b =>
            {
                b.HasKey(f => f.Id);
                // Configurar Id como columna de identidad (auto-incremental)
                b.Property(f => f.Id)
                 .ValueGeneratedOnAdd()
                 .UseIdentityColumn();

                b.Property(f => f.Nombre)
                 .IsRequired()
                 .HasMaxLength(100);

                b.Property(f => f.Tipo)
                 .IsRequired()
                 .HasMaxLength(50);

                b.Property(f => f.Saldo)
                 .HasColumnType("decimal(18,2)");

                b.Property(f => f.FechaCreacion)
                 .HasDefaultValueSql("GETUTCDATE()");
            });


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
