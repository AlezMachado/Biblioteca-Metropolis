using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca_Metropolis.Models.CRUD;

public partial class DbMetropolisContext : DbContext
{
    public DbMetropolisContext()
    {
    }

    public DbMetropolisContext(DbContextOptions<DbMetropolisContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Autor> Autors { get; set; }

    public virtual DbSet<AutoresRecurso> AutoresRecursos { get; set; }

    public virtual DbSet<Editorial> Editorials { get; set; }

    public virtual DbSet<Pai> Pais { get; set; }

    public virtual DbSet<Recurso> Recursos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=(local); Database=dbMetropolis; Trusted_Connection=true; TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Autor>(entity =>
        {
            entity.HasKey(e => e.IdAutor);

            entity.ToTable("Autor");

            entity.Property(e => e.Apellidos)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("apellidos");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<AutoresRecurso>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.EsPrincipal)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IdRec).ValueGeneratedOnAdd();

            entity.HasOne(d => d.IdAutorNavigation).WithMany()
                .HasForeignKey(d => d.IdAutor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AutoresRecursos_Autor");

            entity.HasOne(d => d.IdRecNavigation).WithMany()
                .HasForeignKey(d => d.IdRec)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AutoresRecursos_Recurso");
        });

        modelBuilder.Entity<Editorial>(entity =>
        {
            entity.HasKey(e => e.IdEdit);

            entity.ToTable("Editorial");

            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Pai>(entity =>
        {
            entity.HasKey(e => e.IdPais);

            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Recurso>(entity =>
        {
            entity.HasKey(e => e.IdRec);

            entity.ToTable("Recurso");

            entity.HasIndex(e => e.IdRec, "IX_Recurso");

            entity.Property(e => e.Annopublic).HasColumnName("annopublic");
            entity.Property(e => e.Edicion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("edicion");
            entity.Property(e => e.Palabrasbusqueda)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("palabrasbusqueda");
            entity.Property(e => e.Titulo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("titulo");

            entity.HasOne(d => d.IdEditNavigation).WithMany(p => p.Recursos)
                .HasForeignKey(d => d.IdEdit)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Recurso_Editorial");

            entity.HasOne(d => d.IdPaisNavigation).WithMany(p => p.Recursos)
                .HasForeignKey(d => d.IdPais)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Recurso_Pais");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
