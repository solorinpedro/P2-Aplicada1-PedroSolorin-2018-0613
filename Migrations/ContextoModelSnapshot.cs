﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using P2_Aplicada1_PedroSolorin_2018_0613.DAL;

namespace P2_Aplicada1_PedroSolorin_2018_0613.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("P2_Aplicada1_PedroSolorin_2018_0613.Entidades.TiposTareas", b =>
                {
                    b.Property<int>("TareaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<string>("Requerimiento")
                        .HasColumnType("TEXT");

                    b.Property<int>("Tiempo")
                        .HasColumnType("INTEGER");

                    b.HasKey("TareaId");

                    b.ToTable("Tareas");

                    b.HasData(
                        new
                        {
                            TareaId = 1,
                            Descripcion = "Analisis",
                            Fecha = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Requerimiento = "Analizar la opcion de clientes",
                            Tiempo = 120
                        },
                        new
                        {
                            TareaId = 2,
                            Descripcion = "Diseño",
                            Fecha = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Requerimiento = "Hacer un diseño excelente",
                            Tiempo = 60
                        },
                        new
                        {
                            TareaId = 3,
                            Descripcion = "Programacion",
                            Fecha = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Requerimiento = "Programar todo el registro",
                            Tiempo = 240
                        },
                        new
                        {
                            TareaId = 4,
                            Descripcion = "Prueba",
                            Fecha = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Requerimiento = "Probar con mucho cuidado",
                            Tiempo = 30
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
