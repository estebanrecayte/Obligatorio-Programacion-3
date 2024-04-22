using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogicaDatos.Migrations
{
    /// <inheritdoc />
    public partial class Avances : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuarios Nuevo Nombre",
                table: "Usuarios Nuevo Nombre");

            migrationBuilder.RenameTable(
                name: "Usuarios Nuevo Nombre",
                newName: "Usuarios");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Usuarios",
                newName: "Nombre_Valor");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios");

            migrationBuilder.RenameTable(
                name: "Usuarios",
                newName: "Usuarios Nuevo Nombre");

            migrationBuilder.RenameColumn(
                name: "Nombre_Valor",
                table: "Usuarios Nuevo Nombre",
                newName: "Nombre");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuarios Nuevo Nombre",
                table: "Usuarios Nuevo Nombre",
                column: "Id");
        }
    }
}
