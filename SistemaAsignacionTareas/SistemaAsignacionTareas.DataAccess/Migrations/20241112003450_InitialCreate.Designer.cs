﻿// <auto-generated />
using System;
using GestionDeTrabajo.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace SistemaAsignacionTareas.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241112003450_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GestionDeTrabajo.Data.Entities.Asignacion", b =>
                {
                    b.Property<int>("AsignacionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AsignacionId"));

                    b.Property<string>("EstadoAsignacion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaAsignacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("ItemDeTrabajoId")
                        .HasColumnType("int");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("AsignacionId");

                    b.HasIndex("ItemDeTrabajoId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Asignaciones");
                });

            modelBuilder.Entity("GestionDeTrabajo.Data.Entities.ItemDeTrabajo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaEntrega")
                        .HasColumnType("datetime2");

                    b.Property<string>("Relevancia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("ItemsDeTrabajo");
                });

            modelBuilder.Entity("GestionDeTrabajo.Data.Entities.Usuario", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UsuarioId"));

                    b.Property<string>("NombreUsuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UsuarioId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("GestionDeTrabajo.Data.Entities.Asignacion", b =>
                {
                    b.HasOne("GestionDeTrabajo.Data.Entities.ItemDeTrabajo", "ItemDeTrabajo")
                        .WithMany()
                        .HasForeignKey("ItemDeTrabajoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GestionDeTrabajo.Data.Entities.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ItemDeTrabajo");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("GestionDeTrabajo.Data.Entities.ItemDeTrabajo", b =>
                {
                    b.HasOne("GestionDeTrabajo.Data.Entities.Usuario", "Usuario")
                        .WithMany("ItemsDeTrabajoPendientes")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("GestionDeTrabajo.Data.Entities.Usuario", b =>
                {
                    b.Navigation("ItemsDeTrabajoPendientes");
                });
#pragma warning restore 612, 618
        }
    }
}