using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Proyecto1.Migrations
{
    public partial class Base12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: true),
                    Apellido = table.Column<string>(type: "text", nullable: true),
                    Telefono = table.Column<int>(type: "integer", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Tipo = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Credito",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Tipo = table.Column<string>(type: "text", nullable: true),
                    Fecha_Solicitud = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Credito", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Factura",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: true),
                    Telefono = table.Column<int>(type: "integer", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Tipo = table.Column<string>(type: "text", nullable: true),
                    Estado = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factura", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HistorialCrediticio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Puntaje = table.Column<int>(type: "integer", nullable: false),
                    DeudasActivas = table.Column<int>(type: "integer", nullable: false),
                    DeudasVencidas = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistorialCrediticio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HistorialCrediticioInterno",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Puntaje = table.Column<int>(type: "integer", nullable: false),
                    DeudasActivas = table.Column<int>(type: "integer", nullable: false),
                    DeudasVencidas = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistorialCrediticioInterno", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: true),
                    Marca = table.Column<string>(type: "text", nullable: true),
                    Precio = table.Column<decimal>(type: "numeric", nullable: false),
                    Stock = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Cliente",
                columns: new[] { "Id", "Apellido", "Email", "Nombre", "Telefono", "Tipo" },
                values: new object[,]
                {
                    { 1, "Taco", "eduardo@gmail.com", "Eduardo", 983121592, "Nuevo" },
                    { 2, "Betancourt", "leslie@gmail.com", "Leslie", 983123456, "habitual" },
                    { 3, "Muñoz", "liss@gmail.com", "Lisseth", 983123456, "Nuevo" },
                    { 4, "Vlarezo", "belen@gmail.com", "Belen", 983121598, "habitual" },
                    { 5, "Paucar", "hugo@gmail.com", "Hugo", 98314567, "Nuevo" }
                });

            migrationBuilder.InsertData(
                table: "Credito",
                columns: new[] { "Id", "Fecha_Solicitud", "Tipo" },
                values: new object[,]
                {
                    { 1, "24-10-2021", "Credito Directo" },
                    { 2, "25-10-2021", "Pago en dos partes" },
                    { 3, "26-10-2021", "Cheque" },
                    { 4, "27-10-2021", "Efectivo" }
                });

            migrationBuilder.InsertData(
                table: "Factura",
                columns: new[] { "Id", "Email", "Estado", "Nombre", "Telefono", "Tipo" },
                values: new object[,]
                {
                    { 1, "eduardo@gmail.com", "Entregado", "Eduardo", 983121592, "Nuevo" },
                    { 2, "leslie@gmail.com", "Pendiente de Entrega", "Leslie", 983123456, "habitual" },
                    { 3, "liss@gmail.com", "Entregado", "Lisseth", 983123456, "Nuevo" },
                    { 4, "belen@gmail.com", "Pendiente de Entrega", "Belen", 983121598, "habitual" },
                    { 5, "hugo@gmail.com", "Entregado", "Hugo", 98314567, "Nuevo" }
                });

            migrationBuilder.InsertData(
                table: "HistorialCrediticio",
                columns: new[] { "Id", "DeudasActivas", "DeudasVencidas", "Puntaje" },
                values: new object[,]
                {
                    { 5, 2, 0, 919 },
                    { 3, 3, 0, 820 },
                    { 4, 4, 4, 439 },
                    { 1, 2, 0, 950 },
                    { 2, 1, 1, 650 }
                });

            migrationBuilder.InsertData(
                table: "HistorialCrediticioInterno",
                columns: new[] { "Id", "DeudasActivas", "DeudasVencidas", "Puntaje" },
                values: new object[,]
                {
                    { 1, 1, 0, 98 },
                    { 2, 2, 1, 89 },
                    { 3, 1, 2, 76 },
                    { 4, 0, 5, 56 },
                    { 5, 1, 0, 86 }
                });

            migrationBuilder.InsertData(
                table: "Producto",
                columns: new[] { "Id", "Marca", "Nombre", "Precio", "Stock" },
                values: new object[,]
                {
                    { 10, "Continental", "Cocina", 625.00m, 12 },
                    { 9, "Indurama", "Cocina", 538.00m, 9 },
                    { 8, "Electrolux", "Cocina", 599.00m, 11 },
                    { 7, "GE", "Cocina", 538.00m, 9 },
                    { 6, "Mabe", "Cocina", 450.00m, 7 },
                    { 2, "GE", "Refrigeradora", 1610.00m, 10 },
                    { 4, "Indurama", "Refrigeradora", 850.00m, 25 },
                    { 3, "Electrolux", "Refrigeradora", 720.00m, 13 },
                    { 1, "Mabe", "Refrigeradora", 850.00m, 25 },
                    { 5, "Continental", "Refrigeradora", 1150.00m, 16 },
                    { 11, "Mabe", "Microondas", 178.00m, 4 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Credito");

            migrationBuilder.DropTable(
                name: "Factura");

            migrationBuilder.DropTable(
                name: "HistorialCrediticio");

            migrationBuilder.DropTable(
                name: "HistorialCrediticioInterno");

            migrationBuilder.DropTable(
                name: "Producto");
        }
    }
}
