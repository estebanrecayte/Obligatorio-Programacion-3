using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogicaDatos.Migrations
{
    /// <inheritdoc />
    public partial class AgregandoClasesObligatorio2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TiposDeMovimiento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AumentaStock = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposDeMovimiento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MovimientosDeStock",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ArticuloId = table.Column<long>(type: "bigint", nullable: false),
                    TipoMovimientoStockId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovimientosDeStock", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovimientosDeStock_Articulos_ArticuloId",
                        column: x => x.ArticuloId,
                        principalTable: "Articulos",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovimientosDeStock_TiposDeMovimiento_TipoMovimientoStockId",
                        column: x => x.TipoMovimientoStockId,
                        principalTable: "TiposDeMovimiento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovimientosDeStock_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovimientosDeStock_ArticuloId",
                table: "MovimientosDeStock",
                column: "ArticuloId");

            migrationBuilder.CreateIndex(
                name: "IX_MovimientosDeStock_TipoMovimientoStockId",
                table: "MovimientosDeStock",
                column: "TipoMovimientoStockId");

            migrationBuilder.CreateIndex(
                name: "IX_MovimientosDeStock_UsuarioId",
                table: "MovimientosDeStock",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovimientosDeStock");

            migrationBuilder.DropTable(
                name: "TiposDeMovimiento");
        }
    }
}
