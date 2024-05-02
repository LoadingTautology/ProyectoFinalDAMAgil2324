﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProyectoFinalDAMAgil2324.Data;

#nullable disable

namespace ProyectoFinalDAMAgil2324.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20240501184736_Primera Migracion")]
    partial class PrimeraMigracion
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("ProyectoFinalDAMAgil2324.Models.Usuario", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("IdUsuario"));

                    b.Property<string>("Clave")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("NombreCompleto")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("IdUsuario");

                    b.ToTable("Usuario", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
