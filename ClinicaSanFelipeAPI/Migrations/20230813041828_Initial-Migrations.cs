using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicaSanFelipeAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "farmacia");

            migrationBuilder.CreateTable(
                name: "Productos",
                schema: "farmacia",
                columns: table => new
                {
                    IdProducto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescripcionProducto = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    PrecioCompra = table.Column<double>(type: "float(10)", precision: 10, scale: 2, nullable: false),
                    FechaLote = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FecRegistro = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.IdProducto);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DescripcionProducto",
                schema: "farmacia",
                table: "Productos",
                column: "DescripcionProducto");

            migrationBuilder.AddColumn<double>(
                name: "PrecioVenta",
                schema: "farmacia",
                table: "Productos",
                nullable: false,
                computedColumnSql: "PrecioCompra * 1.25"
                );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Productos",
                schema: "farmacia");
        }
    }
}
