using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class Version1_0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DetailDrawing",
                table: "StubShutterJournals",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JournalNumber",
                table: "StubShutterJournals",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DetailDrawing",
                table: "SteelSleeveShutterJournals",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JournalNumber",
                table: "SteelSleeveShutterJournals",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DetailDrawing",
                table: "SlamShutterJournals",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JournalNumber",
                table: "SlamShutterJournals",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DetailDrawing",
                table: "ShutterReverseJournals",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JournalNumber",
                table: "ShutterReverseJournals",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DetailDrawing",
                table: "ShaftShutterJournals",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JournalNumber",
                table: "ShaftShutterJournals",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DetailDrawing",
                table: "NozzleJournals",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JournalNumber",
                table: "NozzleJournals",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DetailDrawing",
                table: "CaseShutterJournals",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JournalNumber",
                table: "CaseShutterJournals",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DetailDrawing",
                table: "BronzeSleeveShutterJournals",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JournalNumber",
                table: "BronzeSleeveShutterJournals",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "JournalNumbers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Number = table.Column<string>(nullable: true),
                    IsHidden = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JournalNumbers", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JournalNumbers");

            migrationBuilder.DropColumn(
                name: "DetailDrawing",
                table: "StubShutterJournals");

            migrationBuilder.DropColumn(
                name: "JournalNumber",
                table: "StubShutterJournals");

            migrationBuilder.DropColumn(
                name: "DetailDrawing",
                table: "SteelSleeveShutterJournals");

            migrationBuilder.DropColumn(
                name: "JournalNumber",
                table: "SteelSleeveShutterJournals");

            migrationBuilder.DropColumn(
                name: "DetailDrawing",
                table: "SlamShutterJournals");

            migrationBuilder.DropColumn(
                name: "JournalNumber",
                table: "SlamShutterJournals");

            migrationBuilder.DropColumn(
                name: "DetailDrawing",
                table: "ShutterReverseJournals");

            migrationBuilder.DropColumn(
                name: "JournalNumber",
                table: "ShutterReverseJournals");

            migrationBuilder.DropColumn(
                name: "DetailDrawing",
                table: "ShaftShutterJournals");

            migrationBuilder.DropColumn(
                name: "JournalNumber",
                table: "ShaftShutterJournals");

            migrationBuilder.DropColumn(
                name: "DetailDrawing",
                table: "NozzleJournals");

            migrationBuilder.DropColumn(
                name: "JournalNumber",
                table: "NozzleJournals");

            migrationBuilder.DropColumn(
                name: "DetailDrawing",
                table: "CaseShutterJournals");

            migrationBuilder.DropColumn(
                name: "JournalNumber",
                table: "CaseShutterJournals");

            migrationBuilder.DropColumn(
                name: "DetailDrawing",
                table: "BronzeSleeveShutterJournals");

            migrationBuilder.DropColumn(
                name: "JournalNumber",
                table: "BronzeSleeveShutterJournals");
        }
    }
}
