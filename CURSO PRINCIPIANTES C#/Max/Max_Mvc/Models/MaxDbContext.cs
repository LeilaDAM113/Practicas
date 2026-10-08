using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Max_Mvc.Models;

public partial class MaxDbContext : DbContext
{
    public MaxDbContext()
    {
    }

    public MaxDbContext(DbContextOptions<MaxDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<FEjercicio> FEjercicio { get; set; }

    public virtual DbSet<MDificultad> MDificultad { get; set; }

    public virtual DbSet<MTipoCurso> MTipoCurso { get; set; }

	//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
	//        => optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=Max;User ID=sa;Password=sqlserver@2026;Encrypt=False;;TrustServerCertificate=True;");

	protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FEjercicio>(entity =>
        {
            entity.ToTable("F_Ejercicio");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Dificultad).HasColumnName("dificultad");
            entity.Property(e => e.Explicacion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("explicacion");
            entity.Property(e => e.TipoCurso).HasColumnName("tipo_curso");
            entity.Property(e => e.Titulo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("titulo");

            entity.HasOne(d => d.DificultadNavigation).WithMany(p => p.FEjercicio)
                .HasForeignKey(d => d.Dificultad)
                .HasConstraintName("FK_F_Ejercicio_M_Dificultad");

            entity.HasOne(d => d.TipoCursoNavigation).WithMany(p => p.FEjercicio)
                .HasForeignKey(d => d.TipoCurso)
                .HasConstraintName("FK_F_Ejercicio_M_Tipo_Curso");
        });

        modelBuilder.Entity<MDificultad>(entity =>
        {
            entity.ToTable("M_Dificultad");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("descripcion");
        });

        modelBuilder.Entity<MTipoCurso>(entity =>
        {
            entity.ToTable("M_Tipo_Curso");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("descripcion");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
