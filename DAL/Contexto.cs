using Microsoft.EntityFrameworkCore;
using P2_Aplicada1_PedroSolorin_2018_0613.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2_Aplicada1_PedroSolorin_2018_0613.DAL
{
    public class Contexto:DbContext
    {
        public DbSet<TiposTareas> Tareas { get; set; }
        public DbSet<Proyectos> Proyectos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = Data\Proyecto.db");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TiposTareas>().HasData(new TiposTareas
            {
                TareaId = 1,
                Descripcion = "Analisis",
                Requerimiento = "Analizar la opcion de clientes",
                Tiempo = 120
            }
           );
            modelBuilder.Entity<TiposTareas>().HasData(new TiposTareas
            {
                TareaId = 2,
                Descripcion = "Diseño",
                Requerimiento = "Hacer un diseño excelente",
                Tiempo = 60
            }
           );
            modelBuilder.Entity<TiposTareas>().HasData(new TiposTareas
            {
                TareaId = 3,
                Descripcion = "Programacion",
                Requerimiento = "Programar todo el registro",
                Tiempo = 240
            }
           );
            modelBuilder.Entity<TiposTareas>().HasData(new TiposTareas
            {
                TareaId = 4,
                Descripcion = "Prueba",
                Requerimiento = "Probar con mucho cuidado",
                Tiempo = 30
            }
           );
        }
    }
}
