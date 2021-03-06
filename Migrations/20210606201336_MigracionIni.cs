using Microsoft.EntityFrameworkCore.Migrations;

namespace PruebaFall.Migrations
{
    public partial class MigracionIni : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Datos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    oc = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    f12 = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    sku = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    cc = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    estado = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Datos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cancelaciones",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    oc = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    precio_despacho = table.Column<int>(type: "INTEGER", nullable: false),
                    monto_total_linea = table.Column<int>(type: "INTEGER", nullable: false),
                    sku_linea = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    f12 = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    tipo_abastecimiento = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    dup_oc = table.Column<int>(type: "INTEGER", nullable: false),
                    dup_f12 = table.Column<int>(type: "INTEGER", nullable: false),
                    estado_linea = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    estado_orden_oms = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    estado_cd = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    _f12Id = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cancelaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cancelaciones_Datos__f12Id",
                        column: x => x._f12Id,
                        principalTable: "Datos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cancelaciones__f12Id",
                table: "Cancelaciones",
                column: "_f12Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cancelaciones");

            migrationBuilder.DropTable(
                name: "Datos");
        }
    }
}
