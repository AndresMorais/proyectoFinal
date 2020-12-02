using Microsoft.EntityFrameworkCore.Migrations;

namespace proyecto_comunidad_it.Migrations
{
    public partial class LegislacionPropiedadEnlace : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Enlace",
                table: "legislacion",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Enlace",
                table: "legislacion");
        }
    }
}
