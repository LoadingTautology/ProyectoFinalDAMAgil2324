using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;
using ProyectoFinalDAMAgil2324.Models;

namespace ProyectoFinalDAMAgil2324.Migrations;

public partial class CampusbbddContext : DbContext
{
    public CampusbbddContext()
    {
    }

    public CampusbbddContext(DbContextOptions<CampusbbddContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Administrador> Administradors { get; set; }

    public virtual DbSet<Alumno> Alumnos { get; set; }

    public virtual DbSet<Asignatura> Asignaturas { get; set; }

    public virtual DbSet<Asignaturascicloformativo> Asignaturascicloformativos { get; set; }

    public virtual DbSet<Asistenciaalumno> Asistenciaalumnos { get; set; }

    public virtual DbSet<Aula> Aulas { get; set; }

    public virtual DbSet<Centroeducativo> Centroeducativos { get; set; }

    public virtual DbSet<Cicloformativo> Cicloformativos { get; set; }

    public virtual DbSet<Correoelectronico> Correoelectronicos { get; set; }

    public virtual DbSet<Diasemana> Diasemanas { get; set; }

    public virtual DbSet<Dudasalumnoprofesor> Dudasalumnoprofesors { get; set; }

    public virtual DbSet<Examenasignatura> Examenasignaturas { get; set; }

    public virtual DbSet<Franjahorarium> Franjahoraria { get; set; }

    public virtual DbSet<Horario> Horarios { get; set; }

    public virtual DbSet<Matriculasalumno> Matriculasalumnos { get; set; }

    public virtual DbSet<Profesor> Profesors { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

   
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("latin1_swedish_ci")
            .HasCharSet("latin1");

        modelBuilder.Entity<Administrador>(entity =>
        {
            entity.HasKey(e => e.IdAdministrador).HasName("PRIMARY");

            entity.ToTable("administrador");

            entity.Property(e => e.IdAdministrador)
                .ValueGeneratedNever()
                .HasColumnType("int(11)");
            entity.Property(e => e.Dni)
                .HasMaxLength(20)
                .HasDefaultValueSql("''")
                .HasColumnName("DNI");

            entity.HasOne(d => d.IdAdministradorNavigation).WithOne(p => p.Administrador)
                .HasForeignKey<Administrador>(d => d.IdAdministrador)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("administrador_ibfk_1");
        });

        modelBuilder.Entity<Alumno>(entity =>
        {
            entity.HasKey(e => e.IdAlumno).HasName("PRIMARY");

            entity.ToTable("alumno");

            entity.Property(e => e.IdAlumno)
                .ValueGeneratedNever()
                .HasColumnType("int(11)");
            entity.Property(e => e.FechaDeNacimiento).HasDefaultValueSql("'0000-01-01'");

            entity.HasOne(d => d.IdAlumnoNavigation).WithOne(p => p.Alumno)
                .HasForeignKey<Alumno>(d => d.IdAlumno)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("alumno_ibfk_1");
        });

        modelBuilder.Entity<Asignatura>(entity =>
        {
            entity.HasKey(e => e.IdAsignatura).HasName("PRIMARY");

            entity.ToTable("asignatura");

            entity.Property(e => e.IdAsignatura).HasColumnType("int(11)");
            entity.Property(e => e.Curso).HasColumnType("int(11)");
            entity.Property(e => e.NombreAsignatura)
                .HasMaxLength(100)
                .HasDefaultValueSql("'Asignatura'");
        });

        modelBuilder.Entity<Asignaturascicloformativo>(entity =>
        {
            entity.HasKey(e => new { e.IdAsignatura, e.IdCiclo })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("asignaturascicloformativo");

            entity.HasIndex(e => e.IdCiclo, "IdCiclo");

            entity.Property(e => e.IdAsignatura).HasColumnType("int(11)");
            entity.Property(e => e.IdCiclo).HasColumnType("int(11)");

            entity.HasOne(d => d.IdAsignaturaNavigation).WithMany(p => p.Asignaturascicloformativos)
                .HasForeignKey(d => d.IdAsignatura)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("asignaturascicloformativo_ibfk_2");

            entity.HasOne(d => d.IdCicloNavigation).WithMany(p => p.Asignaturascicloformativos)
                .HasForeignKey(d => d.IdCiclo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("asignaturascicloformativo_ibfk_1");
        });

        modelBuilder.Entity<Asistenciaalumno>(entity =>
        {
            entity.HasKey(e => new { e.IdAlumno, e.IdAsignatura, e.IdCiclo, e.Fecha })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0, 0 });

            entity.ToTable("asistenciaalumnos");

            entity.HasIndex(e => new { e.IdAsignatura, e.IdCiclo }, "IdAsignatura");

            entity.Property(e => e.IdAlumno).HasColumnType("int(11)");
            entity.Property(e => e.IdAsignatura).HasColumnType("int(11)");
            entity.Property(e => e.IdCiclo).HasColumnType("int(11)");
            entity.Property(e => e.Fecha).HasDefaultValueSql("curdate()");

            entity.HasOne(d => d.IdAlumnoNavigation).WithMany(p => p.Asistenciaalumnos)
                .HasForeignKey(d => d.IdAlumno)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("asistenciaalumnos_ibfk_1");

            entity.HasOne(d => d.Asignaturascicloformativo).WithMany(p => p.Asistenciaalumnos)
                .HasForeignKey(d => new { d.IdAsignatura, d.IdCiclo })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("asistenciaalumnos_ibfk_2");
        });

        modelBuilder.Entity<Aula>(entity =>
        {
            entity.HasKey(e => e.IdAula).HasName("PRIMARY");

            entity.ToTable("aula");

            entity.Property(e => e.IdAula).HasColumnType("int(11)");
            entity.Property(e => e.AforoMax).HasColumnType("int(11)");
            entity.Property(e => e.NombreAula)
                .HasMaxLength(50)
                .HasDefaultValueSql("'Aula'");
        });

        modelBuilder.Entity<Centroeducativo>(entity =>
        {
            entity.HasKey(e => e.IdCentro).HasName("PRIMARY");

            entity.ToTable("centroeducativo");

            entity.HasIndex(e => new { e.NombreCentro, e.Direccion }, "NombreCentro").IsUnique();

            entity.Property(e => e.IdCentro).HasColumnType("int(11)");
            entity.Property(e => e.Direccion).HasDefaultValueSql("''");
            entity.Property(e => e.NombreCentro)
                .HasMaxLength(100)
                .HasDefaultValueSql("''");

            entity.HasMany(d => d.IdUsuarios).WithMany(p => p.IdCentros)
                .UsingEntity<Dictionary<string, object>>(
                    "Usuarioscentroeducativo",
                    r => r.HasOne<Usuario>().WithMany()
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("usuarioscentroeducativo_ibfk_2"),
                    l => l.HasOne<Centroeducativo>().WithMany()
                        .HasForeignKey("IdCentro")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("usuarioscentroeducativo_ibfk_1"),
                    j =>
                    {
                        j.HasKey("IdCentro", "IdUsuario")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("usuarioscentroeducativo");
                        j.HasIndex(new[] { "IdUsuario" }, "IdUsuario");
                        j.IndexerProperty<int>("IdCentro").HasColumnType("int(11)");
                        j.IndexerProperty<int>("IdUsuario").HasColumnType("int(11)");
                    });
        });

        modelBuilder.Entity<Cicloformativo>(entity =>
        {
            entity.HasKey(e => e.IdCiclo).HasName("PRIMARY");

            entity.ToTable("cicloformativo");

            entity.Property(e => e.IdCiclo).HasColumnType("int(11)");
            entity.Property(e => e.NombreCiclo)
                .HasMaxLength(100)
                .HasDefaultValueSql("'Ciclo'");
        });

        modelBuilder.Entity<Correoelectronico>(entity =>
        {
            entity.HasKey(e => e.Email).HasName("PRIMARY");

            entity.ToTable("correoelectronico");

            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Contraseña)
                .HasMaxLength(100)
                .HasDefaultValueSql("''");
        });

        modelBuilder.Entity<Diasemana>(entity =>
        {
            entity.HasKey(e => e.Dia).HasName("PRIMARY");

            entity.ToTable("diasemana");

            entity.Property(e => e.Dia).HasMaxLength(10);
        });

        modelBuilder.Entity<Dudasalumnoprofesor>(entity =>
        {
            entity.HasKey(e => new { e.IdAlumno, e.IdProfesor, e.IdAsignatura, e.IdCiclo, e.Fecha })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0, 0, 0 });

            entity.ToTable("dudasalumnoprofesor");

            entity.HasIndex(e => new { e.IdAsignatura, e.IdCiclo }, "IdAsignatura");

            entity.HasIndex(e => e.IdProfesor, "IdProfesor");

            entity.Property(e => e.IdAlumno).HasColumnType("int(11)");
            entity.Property(e => e.IdProfesor).HasColumnType("int(11)");
            entity.Property(e => e.IdAsignatura).HasColumnType("int(11)");
            entity.Property(e => e.IdCiclo).HasColumnType("int(11)");
            entity.Property(e => e.Fecha)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("time");
            entity.Property(e => e.Atender).HasDefaultValueSql("'0'");

            entity.HasOne(d => d.IdAlumnoNavigation).WithMany(p => p.Dudasalumnoprofesors)
                .HasForeignKey(d => d.IdAlumno)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("dudasalumnoprofesor_ibfk_1");

            entity.HasOne(d => d.IdProfesorNavigation).WithMany(p => p.Dudasalumnoprofesors)
                .HasForeignKey(d => d.IdProfesor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("dudasalumnoprofesor_ibfk_2");

            entity.HasOne(d => d.Asignaturascicloformativo).WithMany(p => p.Dudasalumnoprofesors)
                .HasForeignKey(d => new { d.IdAsignatura, d.IdCiclo })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("dudasalumnoprofesor_ibfk_3");
        });

        modelBuilder.Entity<Examenasignatura>(entity =>
        {
            entity.HasKey(e => new { e.IdAsignatura, e.IdExamen })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("examenasignaturas");

            entity.Property(e => e.IdAsignatura).HasColumnType("int(11)");
            entity.Property(e => e.IdExamen).HasColumnType("int(11)");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .HasDefaultValueSql("''");
            entity.Property(e => e.NumEvaluacion).HasColumnType("int(11)");
            entity.Property(e => e.Tiempo)
                .HasDefaultValueSql("'01:30:00'")
                .HasColumnType("time");

            entity.HasOne(d => d.IdAsignaturaNavigation).WithMany(p => p.Examenasignaturas)
                .HasForeignKey(d => d.IdAsignatura)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("examenasignaturas_ibfk_1");
        });

        modelBuilder.Entity<Franjahorarium>(entity =>
        {
            entity.HasKey(e => new { e.HoraMinInicio, e.HoraMinFinal })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("franjahoraria");

            entity.Property(e => e.HoraMinInicio).HasColumnType("time");
            entity.Property(e => e.HoraMinFinal).HasColumnType("time");
        });

        modelBuilder.Entity<Horario>(entity =>
        {
            entity.HasKey(e => new { e.IdAula, e.HoraMinInicio, e.HoraMinFinal, e.Dia, e.IdAsignatura, e.IdCiclo })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0, 0, 0, 0 });

            entity.ToTable("horario");

            entity.HasIndex(e => e.Dia, "Dia");

            entity.HasIndex(e => new { e.HoraMinInicio, e.HoraMinFinal }, "HoraMinInicio");

            entity.HasIndex(e => new { e.IdAsignatura, e.IdCiclo }, "IdAsignatura");

            entity.Property(e => e.IdAula).HasColumnType("int(11)");
            entity.Property(e => e.HoraMinInicio).HasColumnType("time");
            entity.Property(e => e.HoraMinFinal).HasColumnType("time");
            entity.Property(e => e.Dia).HasMaxLength(10);
            entity.Property(e => e.IdAsignatura).HasColumnType("int(11)");
            entity.Property(e => e.IdCiclo).HasColumnType("int(11)");

            entity.HasOne(d => d.DiaNavigation).WithMany(p => p.Horarios)
                .HasForeignKey(d => d.Dia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("horario_ibfk_4");

            entity.HasOne(d => d.IdAulaNavigation).WithMany(p => p.Horarios)
                .HasForeignKey(d => d.IdAula)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("horario_ibfk_2");

            entity.HasOne(d => d.Franjahorarium).WithMany(p => p.Horarios)
                .HasForeignKey(d => new { d.HoraMinInicio, d.HoraMinFinal })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("horario_ibfk_3");

            entity.HasOne(d => d.Asignaturascicloformativo).WithMany(p => p.Horarios)
                .HasForeignKey(d => new { d.IdAsignatura, d.IdCiclo })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("horario_ibfk_1");
        });

        modelBuilder.Entity<Matriculasalumno>(entity =>
        {
            entity.HasKey(e => new { e.IdAlumno, e.IdAsignatura, e.IdCiclo })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

            entity.ToTable("matriculasalumnos");

            entity.HasIndex(e => new { e.IdAsignatura, e.IdCiclo }, "IdAsignatura");

            entity.Property(e => e.IdAlumno).HasColumnType("int(11)");
            entity.Property(e => e.IdAsignatura).HasColumnType("int(11)");
            entity.Property(e => e.IdCiclo).HasColumnType("int(11)");
            entity.Property(e => e.Eva2).HasDefaultValueSql("'0'");
            entity.Property(e => e.Eva3).HasDefaultValueSql("'0'");

            entity.HasOne(d => d.IdAlumnoNavigation).WithMany(p => p.Matriculasalumnos)
                .HasForeignKey(d => d.IdAlumno)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("matriculasalumnos_ibfk_1");

            entity.HasOne(d => d.Asignaturascicloformativo).WithMany(p => p.Matriculasalumnos)
                .HasForeignKey(d => new { d.IdAsignatura, d.IdCiclo })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("matriculasalumnos_ibfk_2");
        });

        modelBuilder.Entity<Profesor>(entity =>
        {
            entity.HasKey(e => e.IdProfesor).HasName("PRIMARY");

            entity.ToTable("profesor");

            entity.Property(e => e.IdProfesor)
                .ValueGeneratedNever()
                .HasColumnType("int(11)");
            entity.Property(e => e.Especialidad)
                .HasMaxLength(100)
                .HasDefaultValueSql("''");

            entity.HasOne(d => d.IdProfesorNavigation).WithOne(p => p.Profesor)
                .HasForeignKey<Profesor>(d => d.IdProfesor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("profesor_ibfk_1");

            entity.HasMany(d => d.Asignaturascicloformativos).WithMany(p => p.IdProfesors)
                .UsingEntity<Dictionary<string, object>>(
                    "Asignaturasprofesor",
                    r => r.HasOne<Asignaturascicloformativo>().WithMany()
                        .HasForeignKey("IdAsignatura", "IdCiclo")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("asignaturasprofesor_ibfk_2"),
                    l => l.HasOne<Profesor>().WithMany()
                        .HasForeignKey("IdProfesor")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("asignaturasprofesor_ibfk_1"),
                    j =>
                    {
                        j.HasKey("IdProfesor", "IdAsignatura", "IdCiclo")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });
                        j.ToTable("asignaturasprofesor");
                        j.HasIndex(new[] { "IdAsignatura", "IdCiclo" }, "IdAsignatura");
                        j.IndexerProperty<int>("IdProfesor").HasColumnType("int(11)");
                        j.IndexerProperty<int>("IdAsignatura").HasColumnType("int(11)");
                        j.IndexerProperty<int>("IdCiclo").HasColumnType("int(11)");
                    });
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PRIMARY");

            entity.ToTable("usuario");

            entity.HasIndex(e => e.Email, "Email").IsUnique();

            entity.Property(e => e.IdUsuario).HasColumnType("int(11)");
            entity.Property(e => e.ApellidosUsuario)
                .HasMaxLength(100)
                .HasDefaultValueSql("''");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.NombreUsuario)
                .HasMaxLength(50)
                .HasDefaultValueSql("''");
            entity.Property(e => e.Rol)
                .HasMaxLength(50)
                .HasDefaultValueSql("'ALUMNO'");

            entity.HasOne(d => d.EmailNavigation).WithOne(p => p.Usuario)
                .HasForeignKey<Usuario>(d => d.Email)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("usuario_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
