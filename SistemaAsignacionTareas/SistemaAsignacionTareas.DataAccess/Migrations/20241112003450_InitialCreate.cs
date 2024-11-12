using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaAsignacionTareas.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioId);
                });

            migrationBuilder.CreateTable(
                name: "ItemsDeTrabajo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaEntrega = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Relevancia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemsDeTrabajo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemsDeTrabajo_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.NoAction); // Cambié de Cascade a NoAction
                });

            migrationBuilder.CreateTable(
                name: "Asignaciones",
                columns: table => new
                {
                    AsignacionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    FechaAsignacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstadoAsignacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemDeTrabajoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asignaciones", x => x.AsignacionId);
                    table.ForeignKey(
                        name: "FK_Asignaciones_ItemsDeTrabajo_ItemDeTrabajoId",
                        column: x => x.ItemDeTrabajoId,
                        principalTable: "ItemsDeTrabajo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction); // Cambié de Cascade a NoAction
                    table.ForeignKey(
                        name: "FK_Asignaciones_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.NoAction); // Cambié de Cascade a NoAction
                });

            migrationBuilder.CreateIndex(
                name: "IX_Asignaciones_ItemDeTrabajoId",
                table: "Asignaciones",
                column: "ItemDeTrabajoId");

            migrationBuilder.CreateIndex(
                name: "IX_Asignaciones_UsuarioId",
                table: "Asignaciones",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemsDeTrabajo_UsuarioId",
                table: "ItemsDeTrabajo",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Asignaciones");

            migrationBuilder.DropTable(
                name: "ItemsDeTrabajo");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
