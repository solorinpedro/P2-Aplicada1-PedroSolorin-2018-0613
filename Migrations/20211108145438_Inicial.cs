using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace P2_Aplicada1_PedroSolorin_2018_0613.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tareas",
                columns: table => new
                {
                    TareaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: true),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Requerimiento = table.Column<string>(type: "TEXT", nullable: true),
                    Tiempo = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tareas", x => x.TareaId);
                });

            migrationBuilder.InsertData(
                table: "Tareas",
                columns: new[] { "TareaId", "Descripcion", "Fecha", "Requerimiento", "Tiempo" },
                values: new object[] { 1, "Analisis", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Analizar la opcion de clientes", 120 });

            migrationBuilder.InsertData(
                table: "Tareas",
                columns: new[] { "TareaId", "Descripcion", "Fecha", "Requerimiento", "Tiempo" },
                values: new object[] { 2, "Diseño", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hacer un diseño excelente", 60 });

            migrationBuilder.InsertData(
                table: "Tareas",
                columns: new[] { "TareaId", "Descripcion", "Fecha", "Requerimiento", "Tiempo" },
                values: new object[] { 3, "Programacion", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Programar todo el registro", 240 });

            migrationBuilder.InsertData(
                table: "Tareas",
                columns: new[] { "TareaId", "Descripcion", "Fecha", "Requerimiento", "Tiempo" },
                values: new object[] { 4, "Prueba", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Probar con mucho cuidado", 30 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tareas");
        }
    }
}
