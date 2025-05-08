using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_deck_manager.Infrastructure.Migrations;

/// <inheritdoc />
public partial class TypesTable : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Types",
            columns: table => new
            {
                Id = table.Column<string>(type: "varchar(255)", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                Name = table.Column<string>(type: "longtext", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                Description = table.Column<string>(type: "longtext", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                Total = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Types", x => x.Id);
            })
            .Annotation("MySql:CharSet", "utf8mb4");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Types");
    }
}
