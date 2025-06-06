﻿using CashFlowPortal.Domain.Entities;
using CashFlowPortal.Infraestructura.Seguridad;
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
                .HasKey(t => t.Id);

            modelBuilder.Entity<Gasto>(b =>
            {
                b.HasKey(e => e.Id);
                b.Property(e => e.Id)
                  .UseIdentityColumn();
                b.Property(e => e.Fecha).IsRequired();
                b.Property(e => e.Observaciones).HasMaxLength(250);
                b.Property(e => e.Comercio).HasMaxLength(100).IsRequired();
                b.Property(e => e.TipoDocumento).HasMaxLength(20).IsRequired();

                b.HasMany(e => e.Detalles)
                 .WithOne(d => d.Gasto)
                 .HasForeignKey(d => d.GastoId)
                 .OnDelete(DeleteBehavior.Cascade);
            });

            // GastoDetalle
            modelBuilder.Entity<GastoDetalle>(b =>
            {
                b.HasKey(d => d.Id);
                b.Property(d => d.Id)
                  .UseIdentityColumn();
                b.Property(d => d.Monto)
                 .HasColumnType("decimal(18,2)")
                 .IsRequired();
            });

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
                 
            });
       
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

            modelBuilder.Entity<Deposito>(b =>
            {
                b.HasKey(d => d.Id);
                b.Property(d => d.Id).UseIdentityColumn();
                b.Property(d => d.Fecha).IsRequired();
                b.Property(d => d.Monto)
                 .HasColumnType("decimal(18,2)")
                 .IsRequired();

                b.HasOne(d => d.FondoMonetario)
                 .WithMany()                   
                 .HasForeignKey(d => d.FondoMonetarioId)
                 .OnDelete(DeleteBehavior.Cascade);
            });

            base.OnModelCreating(modelBuilder);

            var adminId = new Guid("D5A620C0-3C2B-4B36-87D5-8E4E8E3E44F4");
            modelBuilder.Entity<Usuario>().HasData(new Usuario
            {
                Id = adminId,
                Nombre = "Administrador",
                UsuarioLogin = "admin",
                ClaveHash = "$2a$11$4W22RZrRxx1y8p..tWU20O5Mj6hM397CuMW3Q5HEJkvzzRHy/L8hW", // 🔐 hash fijo
                //ClaveHash = PasswordHasher.HashPassword("admin"), // 🔐 hash fijo
                Rol = "Admin"
            });
        }
    }
}
