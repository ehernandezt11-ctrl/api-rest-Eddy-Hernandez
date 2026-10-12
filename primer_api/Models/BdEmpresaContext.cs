using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace primer_api.Models;

public partial class BdEmpresaContext : DbContext
{
    public BdEmpresaContext()
    {
    }

    public BdEmpresaContext(DbContextOptions<BdEmpresaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<Puesto> Puestos { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        //=> optionsBuilder.UseMySql("server=localhost;port=3306;user=root;password=Guatemala26.;database=bd_empresa", Microsoft.EntityFrameworkCore.ServerVersion.Parse("9.6.0-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Idclientes).HasName("PRIMARY");

            entity.ToTable("clientes");

            entity.Property(e => e.Idclientes).HasColumnName("idclientes");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(45)
                .HasColumnName("apellidos");
            entity.Property(e => e.Nombre)
                .HasMaxLength(45)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(45)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.Idempleados).HasName("PRIMARY");

            entity.ToTable("empleados");

            entity.HasIndex(e => e.Idpuesto, "fk_puestos_idx");

            entity.Property(e => e.Idempleados).HasColumnName("idempleados");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(45)
                .HasColumnName("apellidos");
            entity.Property(e => e.Idpuesto).HasColumnName("idpuesto");
            entity.Property(e => e.Nombres)
                .HasMaxLength(45)
                .HasColumnName("nombres");

            entity.HasOne(d => d.IdpuestoNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.Idpuesto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_puestos");
        });

        modelBuilder.Entity<Puesto>(entity =>
        {
            entity.HasKey(e => e.Idpuestos).HasName("PRIMARY");

            entity.ToTable("puestos");

            entity.Property(e => e.Idpuestos).HasColumnName("idpuestos");
            entity.Property(e => e.Nombre)
                .HasMaxLength(45)
                .HasColumnName("nombre");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
