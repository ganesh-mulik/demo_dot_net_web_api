using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace demo_8_may.Migrations
{
    /// <inheritdoc />
    public partial class one : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Interns",
                columns: table => new
                {
                    InternId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InternName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InternDesgn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InternshipPeriod = table.Column<int>(type: "int", nullable: false),
                    InternshipTechnology = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interns", x => x.InternId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Interns");
        }
    }
}
