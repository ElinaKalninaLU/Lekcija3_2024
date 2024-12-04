using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeometryClasses.Migrations
{
    /// <inheritdoc />
    public partial class Polygons : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PolygonID",
                table: "Points",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Polygons",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    figureColour = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Polygons", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Points_PolygonID",
                table: "Points",
                column: "PolygonID");

            migrationBuilder.AddForeignKey(
                name: "FK_Points_Polygons_PolygonID",
                table: "Points",
                column: "PolygonID",
                principalTable: "Polygons",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Points_Polygons_PolygonID",
                table: "Points");

            migrationBuilder.DropTable(
                name: "Polygons");

            migrationBuilder.DropIndex(
                name: "IX_Points_PolygonID",
                table: "Points");

            migrationBuilder.DropColumn(
                name: "PolygonID",
                table: "Points");
        }
    }
}
