using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Api.Infrastructure.Migrations;

/// <inheritdoc />
public partial class BaseMigration : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AlterDatabase()
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "collections",
            columns: table => new
            {
                id = table.Column<string>(type: "varchar(255)", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                name = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                description = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                amount = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                icon_url = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                release_year = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Collection_Id", x => x.id);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "deck_types",
            columns: table => new
            {
                id = table.Column<string>(type: "varchar(255)", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                name = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                description = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                total = table.Column<int>(type: "int", nullable: false, defaultValue: 1)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Type_Id", x => x.id);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "users",
            columns: table => new
            {
                id = table.Column<string>(type: "varchar(255)", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                email = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4")
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_User_Id", x => x.id);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "cards",
            columns: table => new
            {
                id = table.Column<string>(type: "varchar(255)", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                collection_id = table.Column<string>(type: "varchar(255)", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                owner_id = table.Column<string>(type: "longtext", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                custom_deck_id = table.Column<string>(type: "longtext", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                name = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                description = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                number = table.Column<int>(type: "int", nullable: false),
                mana_cost = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                label = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                code = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                foil = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Card_Id", x => x.id);
                table.ForeignKey(
                    name: "FK_cards_collections_collection_id",
                    column: x => x.collection_id,
                    principalTable: "collections",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Cascade);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.InsertData(
            table: "collections",
            columns: new[] { "id", "amount", "description", "icon_url", "name", "release_year" },
            values: new object[,]
            {
                { "210525-3jP6J4-160849", 281, "The epic climax of the Phyrexian arc, where all planes unite against Elesh Norn’s multiversal invasion.", "https://example.com/icons/mom.png", "March of the Machine", 2023 },
                { "210525-f7CwFg-160857a", 287, "A time-traveling journey back to the legendary conflict between Urza and Mishra, shaping Magic's early lore.", "https://example.com/icons/mom.png", "The Brothers’ War", 2022 },
                { "210525-MFy4Qc-160824", 271, "A return to New Phyrexia, showcasing the brutal unity of the Phyrexians and their plan to conquer the Multiverse.", "https://example.com/icons/mom.png", "Phyrexia: All Will Be One", 2023 },
                { "210525-nq8CKU-160836", 302, "A futuristic reimagining of Kamigawa blending high-tech and tradition in a cyberpunk-inspired plane.", "https://example.com/icons/mom.png", "Kamigawa: Neon Dynasty", 2022 }
            });

        migrationBuilder.InsertData(
            table: "deck_types",
            columns: new[] { "id", "description", "name", "total" },
            values: new object[,]
            {
                { "210525-LOUq7e-161113", "A non-rotating format with cards from 8th Edition forward, allowing a wide but regulated pool of cards.", "Modern", 60 },
                { "210525-mKawsj-161128", "A format where only common-rarity cards are allowed, promoting budget-friendly and strategic gameplay.", "Pauper", 60 },
                { "210525-oUaYF4-161058", "A multiplayer format where each deck has 100 singleton cards and is led by a legendary creature known as the commander.", "Commander", 100 },
                { "210525-RspDhL-161105", "A rotating format using the most recent sets, designed for balanced competitive play.", "Standard", 60 },
                { "210525-Sd3WF4-161119", "A limited format where players build decks by selecting cards from booster packs in real-time.", "Draft", 40 }
            });

        migrationBuilder.InsertData(
            table: "users",
            columns: new[] { "id", "email", "name" },
            values: new object[] { "210525-G3nVW2-160305", "vincenzo@email.com", "Vincenzo F. Di Giacomo" });

        migrationBuilder.CreateIndex(
            name: "IX_cards_collection_id",
            table: "cards",
            column: "collection_id");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "cards");

        migrationBuilder.DropTable(
            name: "deck_types");

        migrationBuilder.DropTable(
            name: "users");

        migrationBuilder.DropTable(
            name: "collections");
    }
}
