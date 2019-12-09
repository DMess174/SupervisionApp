using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BaseCastingCase",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Number = table.Column<string>(nullable: true),
                    Drawing = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Material = table.Column<string>(nullable: true),
                    Certificate = table.Column<string>(nullable: true),
                    Melt = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseCastingCase", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BronzeSleeveShutterTCPs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Point = table.Column<string>(nullable: true),
                    OperationName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BronzeSleeveShutterTCPs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CaseBottoms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Number = table.Column<string>(nullable: true),
                    Drawing = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Material = table.Column<string>(nullable: true),
                    Certificate = table.Column<string>(nullable: true),
                    Melt = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseBottoms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CaseBottomTCPs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Point = table.Column<string>(nullable: true),
                    OperationName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseBottomTCPs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CaseFlanges",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Number = table.Column<string>(nullable: true),
                    Drawing = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Material = table.Column<string>(nullable: true),
                    Certificate = table.Column<string>(nullable: true),
                    Melt = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseFlanges", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CaseFlangeTCPs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Point = table.Column<string>(nullable: true),
                    OperationName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseFlangeTCPs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CastGateValveCaseTCPs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Point = table.Column<string>(nullable: true),
                    OperationName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CastGateValveCaseTCPs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CastGateValveCoverTCPs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Point = table.Column<string>(nullable: true),
                    OperationName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CastGateValveCoverTCPs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CastGateValveTCPs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Point = table.Column<string>(nullable: true),
                    OperationName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CastGateValveTCPs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompactGateValveCaseTCPs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Point = table.Column<string>(nullable: true),
                    OperationName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompactGateValveCaseTCPs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompactGateValveCoverTCPs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Point = table.Column<string>(nullable: true),
                    OperationName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompactGateValveCoverTCPs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompactGateValveTCPs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Point = table.Column<string>(nullable: true),
                    OperationName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompactGateValveTCPs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CoverFlanges",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Number = table.Column<string>(nullable: true),
                    Drawing = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Material = table.Column<string>(nullable: true),
                    Certificate = table.Column<string>(nullable: true),
                    Melt = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoverFlanges", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CoverFlangeTCPs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Point = table.Column<string>(nullable: true),
                    OperationName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoverFlangeTCPs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CoverSealingRings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Number = table.Column<string>(nullable: true),
                    Drawing = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Material = table.Column<string>(nullable: true),
                    Certificate = table.Column<string>(nullable: true),
                    Melt = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoverSealingRings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CoverSealingRingTCPs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Point = table.Column<string>(nullable: true),
                    OperationName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoverSealingRingTCPs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CoverSleeveTCPs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Point = table.Column<string>(nullable: true),
                    OperationName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoverSleeveTCPs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    ShortName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FrontWallTCPs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Point = table.Column<string>(nullable: true),
                    OperationName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FrontWallTCPs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Number = table.Column<string>(nullable: true),
                    Drawing = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Material = table.Column<string>(nullable: true),
                    Certificate = table.Column<string>(nullable: true),
                    Melt = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GateTCPs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Point = table.Column<string>(nullable: true),
                    OperationName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GateTCPs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Inspectors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Subdivision = table.Column<string>(nullable: true),
                    Department = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inspectors", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "NozzleTCPs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Point = table.Column<string>(nullable: true),
                    OperationName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NozzleTCPs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    ShortName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReverseShutterCaseTCPs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Point = table.Column<string>(nullable: true),
                    OperationName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReverseShutterCaseTCPs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReverseShutterTCPs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Point = table.Column<string>(nullable: true),
                    OperationName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReverseShutterTCPs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RunningSleeves",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Number = table.Column<string>(nullable: true),
                    Drawing = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Material = table.Column<string>(nullable: true),
                    Certificate = table.Column<string>(nullable: true),
                    Melt = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RunningSleeves", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RunningSleeveTCPs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Point = table.Column<string>(nullable: true),
                    OperationName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RunningSleeveTCPs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SaddleTCPs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Point = table.Column<string>(nullable: true),
                    OperationName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaddleTCPs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShaftShutters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Number = table.Column<string>(nullable: true),
                    Drawing = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Material = table.Column<string>(nullable: true),
                    Certificate = table.Column<string>(nullable: true),
                    Melt = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShaftShutters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShaftShutterTCPs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Point = table.Column<string>(nullable: true),
                    OperationName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShaftShutterTCPs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SheetGateValveCaseTCPs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Point = table.Column<string>(nullable: true),
                    OperationName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SheetGateValveCaseTCPs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SheetGateValveCoverTCPs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Point = table.Column<string>(nullable: true),
                    OperationName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SheetGateValveCoverTCPs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SheetGateValveTCPs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Point = table.Column<string>(nullable: true),
                    OperationName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SheetGateValveTCPs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShutterDiskTCPs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Point = table.Column<string>(nullable: true),
                    OperationName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShutterDiskTCPs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShutterGuideTCPs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Point = table.Column<string>(nullable: true),
                    OperationName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShutterGuideTCPs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shutters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Number = table.Column<string>(nullable: true),
                    Drawing = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shutters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShutterTCPs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Point = table.Column<string>(nullable: true),
                    OperationName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShutterTCPs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SideWallTCPs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Point = table.Column<string>(nullable: true),
                    OperationName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SideWallTCPs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SlamShutters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Number = table.Column<string>(nullable: true),
                    Drawing = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Material = table.Column<string>(nullable: true),
                    Certificate = table.Column<string>(nullable: true),
                    Melt = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SlamShutters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SlamShutterTCPs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Point = table.Column<string>(nullable: true),
                    OperationName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SlamShutterTCPs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Spindles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Number = table.Column<string>(nullable: true),
                    Drawing = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Material = table.Column<string>(nullable: true),
                    Certificate = table.Column<string>(nullable: true),
                    Melt = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spindles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpindleTCPs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Point = table.Column<string>(nullable: true),
                    OperationName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpindleTCPs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SteelSleeveShutterTCPs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Point = table.Column<string>(nullable: true),
                    OperationName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SteelSleeveShutterTCPs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StubShutterTCPs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Point = table.Column<string>(nullable: true),
                    OperationName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StubShutterTCPs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WeldNozzles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Number = table.Column<string>(nullable: true),
                    Drawing = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Material = table.Column<string>(nullable: true),
                    Certificate = table.Column<string>(nullable: true),
                    Melt = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeldNozzles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WeldNozzleTCPs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Point = table.Column<string>(nullable: true),
                    OperationName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeldNozzleTCPs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Nozzles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Number = table.Column<string>(nullable: true),
                    Drawing = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Material = table.Column<string>(nullable: true),
                    Certificate = table.Column<string>(nullable: true),
                    Melt = table.Column<string>(nullable: true),
                    Diameter = table.Column<string>(nullable: true),
                    Thickness = table.Column<string>(nullable: true),
                    ThicknessJoin = table.Column<string>(nullable: true),
                    CastingCaseId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nozzles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nozzles_BaseCastingCase_CastingCaseId",
                        column: x => x.CastingCaseId,
                        principalTable: "BaseCastingCase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WeldGateValveCase",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Number = table.Column<string>(nullable: true),
                    Drawing = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Diameter = table.Column<string>(nullable: true),
                    Thickness = table.Column<string>(nullable: true),
                    CaseFlangeId = table.Column<int>(nullable: true),
                    CaseBottomId = table.Column<int>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeldGateValveCase", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeldGateValveCase_CaseBottoms_CaseBottomId",
                        column: x => x.CaseBottomId,
                        principalTable: "CaseBottoms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WeldGateValveCase_CaseFlanges_CaseFlangeId",
                        column: x => x.CaseFlangeId,
                        principalTable: "CaseFlanges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CoverSleeves",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Number = table.Column<string>(nullable: true),
                    Drawing = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Material = table.Column<string>(nullable: true),
                    Certificate = table.Column<string>(nullable: true),
                    Melt = table.Column<string>(nullable: true),
                    CoverSealingRingId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoverSleeves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoverSleeves_CoverSealingRings_CoverSealingRingId",
                        column: x => x.CoverSealingRingId,
                        principalTable: "CoverSealingRings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Specifications",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Number = table.Column<string>(nullable: true),
                    Program = table.Column<string>(nullable: true),
                    Consignee = table.Column<string>(nullable: true),
                    Facility = table.Column<string>(nullable: true),
                    CustomerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Specifications_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CaseBottomJournals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DetailName = table.Column<string>(nullable: true),
                    DetailNumber = table.Column<string>(nullable: true),
                    DetailDrawing = table.Column<string>(nullable: true),
                    Point = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    JournalNumber = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    InspectorId = table.Column<int>(nullable: true),
                    DetailId = table.Column<int>(nullable: true),
                    PointId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseBottomJournals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CaseBottomJournals_CaseBottoms_DetailId",
                        column: x => x.DetailId,
                        principalTable: "CaseBottoms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CaseBottomJournals_Inspectors_InspectorId",
                        column: x => x.InspectorId,
                        principalTable: "Inspectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CaseBottomJournals_CaseBottomTCPs_PointId",
                        column: x => x.PointId,
                        principalTable: "CaseBottomTCPs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CaseFlangeJournals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DetailName = table.Column<string>(nullable: true),
                    DetailNumber = table.Column<string>(nullable: true),
                    DetailDrawing = table.Column<string>(nullable: true),
                    Point = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    JournalNumber = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    InspectorId = table.Column<int>(nullable: true),
                    DetailId = table.Column<int>(nullable: true),
                    PointId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseFlangeJournals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CaseFlangeJournals_CaseFlanges_DetailId",
                        column: x => x.DetailId,
                        principalTable: "CaseFlanges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CaseFlangeJournals_Inspectors_InspectorId",
                        column: x => x.InspectorId,
                        principalTable: "Inspectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CaseFlangeJournals_CaseFlangeTCPs_PointId",
                        column: x => x.PointId,
                        principalTable: "CaseFlangeTCPs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CastGateValveCaseJournals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DetailName = table.Column<string>(nullable: true),
                    DetailNumber = table.Column<string>(nullable: true),
                    DetailDrawing = table.Column<string>(nullable: true),
                    Point = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    JournalNumber = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    InspectorId = table.Column<int>(nullable: true),
                    DetailId = table.Column<int>(nullable: true),
                    PointId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CastGateValveCaseJournals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CastGateValveCaseJournals_BaseCastingCase_DetailId",
                        column: x => x.DetailId,
                        principalTable: "BaseCastingCase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CastGateValveCaseJournals_Inspectors_InspectorId",
                        column: x => x.InspectorId,
                        principalTable: "Inspectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CastGateValveCaseJournals_CastGateValveCaseTCPs_PointId",
                        column: x => x.PointId,
                        principalTable: "CastGateValveCaseTCPs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CoverFlangeJournals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DetailName = table.Column<string>(nullable: true),
                    DetailNumber = table.Column<string>(nullable: true),
                    DetailDrawing = table.Column<string>(nullable: true),
                    Point = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    JournalNumber = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    InspectorId = table.Column<int>(nullable: true),
                    DetailId = table.Column<int>(nullable: true),
                    PointId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoverFlangeJournals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoverFlangeJournals_CoverFlanges_DetailId",
                        column: x => x.DetailId,
                        principalTable: "CoverFlanges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CoverFlangeJournals_Inspectors_InspectorId",
                        column: x => x.InspectorId,
                        principalTable: "Inspectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CoverFlangeJournals_CoverFlangeTCPs_PointId",
                        column: x => x.PointId,
                        principalTable: "CoverFlangeTCPs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CoverSealingRingJournals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DetailName = table.Column<string>(nullable: true),
                    DetailNumber = table.Column<string>(nullable: true),
                    DetailDrawing = table.Column<string>(nullable: true),
                    Point = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    JournalNumber = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    InspectorId = table.Column<int>(nullable: true),
                    DetailId = table.Column<int>(nullable: true),
                    PointId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoverSealingRingJournals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoverSealingRingJournals_CoverSealingRings_DetailId",
                        column: x => x.DetailId,
                        principalTable: "CoverSealingRings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CoverSealingRingJournals_Inspectors_InspectorId",
                        column: x => x.InspectorId,
                        principalTable: "Inspectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CoverSealingRingJournals_CoverSealingRingTCPs_PointId",
                        column: x => x.PointId,
                        principalTable: "CoverSealingRingTCPs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GateJournals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DetailName = table.Column<string>(nullable: true),
                    DetailNumber = table.Column<string>(nullable: true),
                    DetailDrawing = table.Column<string>(nullable: true),
                    Point = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    JournalNumber = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    InspectorId = table.Column<int>(nullable: true),
                    DetailId = table.Column<int>(nullable: true),
                    PointId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GateJournals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GateJournals_Gates_DetailId",
                        column: x => x.DetailId,
                        principalTable: "Gates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GateJournals_Inspectors_InspectorId",
                        column: x => x.InspectorId,
                        principalTable: "Inspectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GateJournals_GateTCPs_PointId",
                        column: x => x.PointId,
                        principalTable: "GateTCPs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReverseShutterCaseJournals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DetailName = table.Column<string>(nullable: true),
                    DetailNumber = table.Column<string>(nullable: true),
                    DetailDrawing = table.Column<string>(nullable: true),
                    Point = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    JournalNumber = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    InspectorId = table.Column<int>(nullable: true),
                    DetailId = table.Column<int>(nullable: true),
                    PointId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReverseShutterCaseJournals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReverseShutterCaseJournals_BaseCastingCase_DetailId",
                        column: x => x.DetailId,
                        principalTable: "BaseCastingCase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReverseShutterCaseJournals_Inspectors_InspectorId",
                        column: x => x.InspectorId,
                        principalTable: "Inspectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReverseShutterCaseJournals_ReverseShutterCaseTCPs_PointId",
                        column: x => x.PointId,
                        principalTable: "ReverseShutterCaseTCPs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RunningSleeveJournals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DetailName = table.Column<string>(nullable: true),
                    DetailNumber = table.Column<string>(nullable: true),
                    DetailDrawing = table.Column<string>(nullable: true),
                    Point = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    JournalNumber = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    InspectorId = table.Column<int>(nullable: true),
                    DetailId = table.Column<int>(nullable: true),
                    PointId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RunningSleeveJournals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RunningSleeveJournals_RunningSleeves_DetailId",
                        column: x => x.DetailId,
                        principalTable: "RunningSleeves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RunningSleeveJournals_Inspectors_InspectorId",
                        column: x => x.InspectorId,
                        principalTable: "Inspectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RunningSleeveJournals_RunningSleeveTCPs_PointId",
                        column: x => x.PointId,
                        principalTable: "RunningSleeveTCPs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShaftShutterJournals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DetailName = table.Column<string>(nullable: true),
                    DetailNumber = table.Column<string>(nullable: true),
                    DetailDrawing = table.Column<string>(nullable: true),
                    Point = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    JournalNumber = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    InspectorId = table.Column<int>(nullable: true),
                    DetailId = table.Column<int>(nullable: true),
                    PointId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShaftShutterJournals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShaftShutterJournals_ShaftShutters_DetailId",
                        column: x => x.DetailId,
                        principalTable: "ShaftShutters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShaftShutterJournals_Inspectors_InspectorId",
                        column: x => x.InspectorId,
                        principalTable: "Inspectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShaftShutterJournals_ShaftShutterTCPs_PointId",
                        column: x => x.PointId,
                        principalTable: "ShaftShutterTCPs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShutterDisks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Number = table.Column<string>(nullable: true),
                    Drawing = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Material = table.Column<string>(nullable: true),
                    Certificate = table.Column<string>(nullable: true),
                    Melt = table.Column<string>(nullable: true),
                    ShutterId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShutterDisks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShutterDisks_Shutters_ShutterId",
                        column: x => x.ShutterId,
                        principalTable: "Shutters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShutterGuides",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Number = table.Column<string>(nullable: true),
                    Drawing = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Material = table.Column<string>(nullable: true),
                    Certificate = table.Column<string>(nullable: true),
                    Melt = table.Column<string>(nullable: true),
                    ShutterId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShutterGuides", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShutterGuides_Shutters_ShutterId",
                        column: x => x.ShutterId,
                        principalTable: "Shutters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShutterJournals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DetailName = table.Column<string>(nullable: true),
                    DetailNumber = table.Column<string>(nullable: true),
                    DetailDrawing = table.Column<string>(nullable: true),
                    Point = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    JournalNumber = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    InspectorId = table.Column<int>(nullable: true),
                    DetailId = table.Column<int>(nullable: true),
                    PointId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShutterJournals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShutterJournals_Shutters_DetailId",
                        column: x => x.DetailId,
                        principalTable: "Shutters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShutterJournals_Inspectors_InspectorId",
                        column: x => x.InspectorId,
                        principalTable: "Inspectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShutterJournals_ShutterTCPs_PointId",
                        column: x => x.PointId,
                        principalTable: "ShutterTCPs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SlamShutterJournals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DetailName = table.Column<string>(nullable: true),
                    DetailNumber = table.Column<string>(nullable: true),
                    DetailDrawing = table.Column<string>(nullable: true),
                    Point = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    JournalNumber = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    InspectorId = table.Column<int>(nullable: true),
                    DetailId = table.Column<int>(nullable: true),
                    PointId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SlamShutterJournals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SlamShutterJournals_SlamShutters_DetailId",
                        column: x => x.DetailId,
                        principalTable: "SlamShutters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SlamShutterJournals_Inspectors_InspectorId",
                        column: x => x.InspectorId,
                        principalTable: "Inspectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SlamShutterJournals_SlamShutterTCPs_PointId",
                        column: x => x.PointId,
                        principalTable: "SlamShutterTCPs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BaseValveCover",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Number = table.Column<string>(nullable: true),
                    Drawing = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    SpindleId = table.Column<int>(nullable: true),
                    RunningSleeveId = table.Column<int>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    Material = table.Column<string>(nullable: true),
                    Certificate = table.Column<string>(nullable: true),
                    Melt = table.Column<string>(nullable: true),
                    CoverSealingRingId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseValveCover", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaseValveCover_RunningSleeves_RunningSleeveId",
                        column: x => x.RunningSleeveId,
                        principalTable: "RunningSleeves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BaseValveCover_Spindles_SpindleId",
                        column: x => x.SpindleId,
                        principalTable: "Spindles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BaseValveCover_CoverSealingRings_CoverSealingRingId",
                        column: x => x.CoverSealingRingId,
                        principalTable: "CoverSealingRings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SpindleJournals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DetailName = table.Column<string>(nullable: true),
                    DetailNumber = table.Column<string>(nullable: true),
                    DetailDrawing = table.Column<string>(nullable: true),
                    Point = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    JournalNumber = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    InspectorId = table.Column<int>(nullable: true),
                    DetailId = table.Column<int>(nullable: true),
                    PointId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpindleJournals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpindleJournals_Spindles_DetailId",
                        column: x => x.DetailId,
                        principalTable: "Spindles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SpindleJournals_Inspectors_InspectorId",
                        column: x => x.InspectorId,
                        principalTable: "Inspectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SpindleJournals_SpindleTCPs_PointId",
                        column: x => x.PointId,
                        principalTable: "SpindleTCPs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WeldNozzleJournals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DetailName = table.Column<string>(nullable: true),
                    DetailNumber = table.Column<string>(nullable: true),
                    DetailDrawing = table.Column<string>(nullable: true),
                    Point = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    JournalNumber = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    InspectorId = table.Column<int>(nullable: true),
                    DetailId = table.Column<int>(nullable: true),
                    PointId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeldNozzleJournals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeldNozzleJournals_WeldNozzles_DetailId",
                        column: x => x.DetailId,
                        principalTable: "WeldNozzles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WeldNozzleJournals_Inspectors_InspectorId",
                        column: x => x.InspectorId,
                        principalTable: "Inspectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WeldNozzleJournals_WeldNozzleTCPs_PointId",
                        column: x => x.PointId,
                        principalTable: "WeldNozzleTCPs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NozzleJournals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DetailName = table.Column<string>(nullable: true),
                    DetailNumber = table.Column<string>(nullable: true),
                    DetailDrawing = table.Column<string>(nullable: true),
                    Point = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    JournalNumber = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    InspectorId = table.Column<int>(nullable: true),
                    DetailId = table.Column<int>(nullable: true),
                    PointId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NozzleJournals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NozzleJournals_Nozzles_DetailId",
                        column: x => x.DetailId,
                        principalTable: "Nozzles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NozzleJournals_Inspectors_InspectorId",
                        column: x => x.InspectorId,
                        principalTable: "Inspectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NozzleJournals_NozzleTCPs_PointId",
                        column: x => x.PointId,
                        principalTable: "NozzleTCPs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CompactGateValveCaseJournals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DetailName = table.Column<string>(nullable: true),
                    DetailNumber = table.Column<string>(nullable: true),
                    DetailDrawing = table.Column<string>(nullable: true),
                    Point = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    JournalNumber = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    InspectorId = table.Column<int>(nullable: true),
                    DetailId = table.Column<int>(nullable: true),
                    PointId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompactGateValveCaseJournals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompactGateValveCaseJournals_WeldGateValveCase_DetailId",
                        column: x => x.DetailId,
                        principalTable: "WeldGateValveCase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CompactGateValveCaseJournals_Inspectors_InspectorId",
                        column: x => x.InspectorId,
                        principalTable: "Inspectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CompactGateValveCaseJournals_CompactGateValveCaseTCPs_PointId",
                        column: x => x.PointId,
                        principalTable: "CompactGateValveCaseTCPs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FrontWalls",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Number = table.Column<string>(nullable: true),
                    Drawing = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Material = table.Column<string>(nullable: true),
                    Certificate = table.Column<string>(nullable: true),
                    Melt = table.Column<string>(nullable: true),
                    WeldGateValveCaseId = table.Column<int>(nullable: true),
                    WeldNozzleId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FrontWalls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FrontWalls_WeldGateValveCase_WeldGateValveCaseId",
                        column: x => x.WeldGateValveCaseId,
                        principalTable: "WeldGateValveCase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FrontWalls_WeldNozzles_WeldNozzleId",
                        column: x => x.WeldNozzleId,
                        principalTable: "WeldNozzles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SheetGateValveCaseJournals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DetailName = table.Column<string>(nullable: true),
                    DetailNumber = table.Column<string>(nullable: true),
                    DetailDrawing = table.Column<string>(nullable: true),
                    Point = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    JournalNumber = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    InspectorId = table.Column<int>(nullable: true),
                    DetailId = table.Column<int>(nullable: true),
                    PointId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SheetGateValveCaseJournals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SheetGateValveCaseJournals_WeldGateValveCase_DetailId",
                        column: x => x.DetailId,
                        principalTable: "WeldGateValveCase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SheetGateValveCaseJournals_Inspectors_InspectorId",
                        column: x => x.InspectorId,
                        principalTable: "Inspectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SheetGateValveCaseJournals_SheetGateValveCaseTCPs_PointId",
                        column: x => x.PointId,
                        principalTable: "SheetGateValveCaseTCPs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SideWalls",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Number = table.Column<string>(nullable: true),
                    Drawing = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Material = table.Column<string>(nullable: true),
                    Certificate = table.Column<string>(nullable: true),
                    Melt = table.Column<string>(nullable: true),
                    WeldGateValveCaseId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SideWalls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SideWalls_WeldGateValveCase_WeldGateValveCaseId",
                        column: x => x.WeldGateValveCaseId,
                        principalTable: "WeldGateValveCase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CoverSleeveJournals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DetailName = table.Column<string>(nullable: true),
                    DetailNumber = table.Column<string>(nullable: true),
                    DetailDrawing = table.Column<string>(nullable: true),
                    Point = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    JournalNumber = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    InspectorId = table.Column<int>(nullable: true),
                    DetailId = table.Column<int>(nullable: true),
                    PointId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoverSleeveJournals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoverSleeveJournals_CoverSleeves_DetailId",
                        column: x => x.DetailId,
                        principalTable: "CoverSleeves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CoverSleeveJournals_Inspectors_InspectorId",
                        column: x => x.InspectorId,
                        principalTable: "Inspectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CoverSleeveJournals_CoverSleeveTCPs_PointId",
                        column: x => x.PointId,
                        principalTable: "CoverSleeveTCPs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WeldGateValveCover",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Number = table.Column<string>(nullable: true),
                    Drawing = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    CoverFlangeId = table.Column<int>(nullable: true),
                    CoverSleeveId = table.Column<int>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeldGateValveCover", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeldGateValveCover_CoverFlanges_CoverFlangeId",
                        column: x => x.CoverFlangeId,
                        principalTable: "CoverFlanges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WeldGateValveCover_CoverSleeves_CoverSleeveId",
                        column: x => x.CoverSleeveId,
                        principalTable: "CoverSleeves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PIDs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Number = table.Column<string>(nullable: true),
                    Amount = table.Column<string>(nullable: true),
                    DN = table.Column<string>(nullable: true),
                    PN = table.Column<string>(nullable: true),
                    ConnectionType = table.Column<string>(nullable: true),
                    EarthquakeResistance = table.Column<string>(nullable: true),
                    Climatic = table.Column<string>(nullable: true),
                    DriveType = table.Column<string>(nullable: true),
                    TechDocumentation = table.Column<string>(nullable: true),
                    ShippingDate = table.Column<DateTime>(nullable: true),
                    SpecificationId = table.Column<int>(nullable: true),
                    ProductTypeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PIDs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PIDs_ProductTypes_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalTable: "ProductTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PIDs_Specifications_SpecificationId",
                        column: x => x.SpecificationId,
                        principalTable: "Specifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShutterDiskJournals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DetailName = table.Column<string>(nullable: true),
                    DetailNumber = table.Column<string>(nullable: true),
                    DetailDrawing = table.Column<string>(nullable: true),
                    Point = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    JournalNumber = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    InspectorId = table.Column<int>(nullable: true),
                    DetailId = table.Column<int>(nullable: true),
                    PointId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShutterDiskJournals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShutterDiskJournals_ShutterDisks_DetailId",
                        column: x => x.DetailId,
                        principalTable: "ShutterDisks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShutterDiskJournals_Inspectors_InspectorId",
                        column: x => x.InspectorId,
                        principalTable: "Inspectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShutterDiskJournals_ShutterDiskTCPs_PointId",
                        column: x => x.PointId,
                        principalTable: "ShutterDiskTCPs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShutterGuideJournals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DetailName = table.Column<string>(nullable: true),
                    DetailNumber = table.Column<string>(nullable: true),
                    DetailDrawing = table.Column<string>(nullable: true),
                    Point = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    JournalNumber = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    InspectorId = table.Column<int>(nullable: true),
                    DetailId = table.Column<int>(nullable: true),
                    PointId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShutterGuideJournals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShutterGuideJournals_ShutterGuides_DetailId",
                        column: x => x.DetailId,
                        principalTable: "ShutterGuides",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShutterGuideJournals_Inspectors_InspectorId",
                        column: x => x.InspectorId,
                        principalTable: "Inspectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShutterGuideJournals_ShutterGuideTCPs_PointId",
                        column: x => x.PointId,
                        principalTable: "ShutterGuideTCPs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CastGateValveCoverJournals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DetailName = table.Column<string>(nullable: true),
                    DetailNumber = table.Column<string>(nullable: true),
                    DetailDrawing = table.Column<string>(nullable: true),
                    Point = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    JournalNumber = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    InspectorId = table.Column<int>(nullable: true),
                    DetailId = table.Column<int>(nullable: true),
                    PointId = table.Column<int>(nullable: true),
                    CastGateValveCoverTCPId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CastGateValveCoverJournals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CastGateValveCoverJournals_CastGateValveCoverTCPs_CastGateValveCoverTCPId",
                        column: x => x.CastGateValveCoverTCPId,
                        principalTable: "CastGateValveCoverTCPs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CastGateValveCoverJournals_BaseValveCover_DetailId",
                        column: x => x.DetailId,
                        principalTable: "BaseValveCover",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CastGateValveCoverJournals_Inspectors_InspectorId",
                        column: x => x.InspectorId,
                        principalTable: "Inspectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CastGateValveCoverJournals_CastGateValveCaseTCPs_PointId",
                        column: x => x.PointId,
                        principalTable: "CastGateValveCaseTCPs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FrontWallJournals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DetailName = table.Column<string>(nullable: true),
                    DetailNumber = table.Column<string>(nullable: true),
                    DetailDrawing = table.Column<string>(nullable: true),
                    Point = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    JournalNumber = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    InspectorId = table.Column<int>(nullable: true),
                    DetailId = table.Column<int>(nullable: true),
                    PointId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FrontWallJournals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FrontWallJournals_FrontWalls_DetailId",
                        column: x => x.DetailId,
                        principalTable: "FrontWalls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FrontWallJournals_Inspectors_InspectorId",
                        column: x => x.InspectorId,
                        principalTable: "Inspectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FrontWallJournals_FrontWallTCPs_PointId",
                        column: x => x.PointId,
                        principalTable: "FrontWallTCPs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SideWallJournals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DetailName = table.Column<string>(nullable: true),
                    DetailNumber = table.Column<string>(nullable: true),
                    DetailDrawing = table.Column<string>(nullable: true),
                    Point = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    JournalNumber = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    InspectorId = table.Column<int>(nullable: true),
                    DetailId = table.Column<int>(nullable: true),
                    PointId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SideWallJournals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SideWallJournals_SideWalls_DetailId",
                        column: x => x.DetailId,
                        principalTable: "SideWalls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SideWallJournals_Inspectors_InspectorId",
                        column: x => x.InspectorId,
                        principalTable: "Inspectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SideWallJournals_SideWallTCPs_PointId",
                        column: x => x.PointId,
                        principalTable: "SideWallTCPs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CompactGateValveCoverJournals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DetailName = table.Column<string>(nullable: true),
                    DetailNumber = table.Column<string>(nullable: true),
                    DetailDrawing = table.Column<string>(nullable: true),
                    Point = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    JournalNumber = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    InspectorId = table.Column<int>(nullable: true),
                    DetailId = table.Column<int>(nullable: true),
                    PointId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompactGateValveCoverJournals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompactGateValveCoverJournals_WeldGateValveCover_DetailId",
                        column: x => x.DetailId,
                        principalTable: "WeldGateValveCover",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CompactGateValveCoverJournals_Inspectors_InspectorId",
                        column: x => x.InspectorId,
                        principalTable: "Inspectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CompactGateValveCoverJournals_CompactGateValveCoverTCPs_PointId",
                        column: x => x.PointId,
                        principalTable: "CompactGateValveCoverTCPs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SheetGateValveCoverJournals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DetailName = table.Column<string>(nullable: true),
                    DetailNumber = table.Column<string>(nullable: true),
                    DetailDrawing = table.Column<string>(nullable: true),
                    Point = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    JournalNumber = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    InspectorId = table.Column<int>(nullable: true),
                    DetailId = table.Column<int>(nullable: true),
                    PointId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SheetGateValveCoverJournals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SheetGateValveCoverJournals_WeldGateValveCover_DetailId",
                        column: x => x.DetailId,
                        principalTable: "WeldGateValveCover",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SheetGateValveCoverJournals_Inspectors_InspectorId",
                        column: x => x.InspectorId,
                        principalTable: "Inspectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SheetGateValveCoverJournals_SheetGateValveCoverTCPs_PointId",
                        column: x => x.PointId,
                        principalTable: "SheetGateValveCoverTCPs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BaseValve",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Number = table.Column<string>(nullable: true),
                    Drawing = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    PIDId = table.Column<int>(nullable: true),
                    GateId = table.Column<int>(nullable: true),
                    ShutterId = table.Column<int>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    WeldGateValveCoverId = table.Column<int>(nullable: true),
                    WeldGateValveCaseId = table.Column<int>(nullable: true),
                    CastGateValveCaseId = table.Column<int>(nullable: true),
                    CastGateValveCoverId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseValve", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaseValve_Gates_GateId",
                        column: x => x.GateId,
                        principalTable: "Gates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BaseValve_Shutters_ShutterId",
                        column: x => x.ShutterId,
                        principalTable: "Shutters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BaseValve_PIDs_PIDId",
                        column: x => x.PIDId,
                        principalTable: "PIDs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BaseValve_WeldGateValveCase_WeldGateValveCaseId",
                        column: x => x.WeldGateValveCaseId,
                        principalTable: "WeldGateValveCase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BaseValve_WeldGateValveCover_WeldGateValveCoverId",
                        column: x => x.WeldGateValveCoverId,
                        principalTable: "WeldGateValveCover",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BaseValve_BaseCastingCase_CastGateValveCaseId",
                        column: x => x.CastGateValveCaseId,
                        principalTable: "BaseCastingCase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BaseValve_BaseValveCover_CastGateValveCoverId",
                        column: x => x.CastGateValveCoverId,
                        principalTable: "BaseValveCover",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BaseValve_PIDs_PIDId1",
                        column: x => x.PIDId,
                        principalTable: "PIDs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShutterReverses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Number = table.Column<string>(nullable: true),
                    Drawing = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    PIDId = table.Column<int>(nullable: true),
                    ReverseShutterCaseId = table.Column<int>(nullable: true),
                    ShaftShutterId = table.Column<int>(nullable: true),
                    SlamShutterId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShutterReverses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShutterReverses_PIDs_PIDId",
                        column: x => x.PIDId,
                        principalTable: "PIDs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShutterReverses_BaseCastingCase_ReverseShutterCaseId",
                        column: x => x.ReverseShutterCaseId,
                        principalTable: "BaseCastingCase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShutterReverses_ShaftShutters_ShaftShutterId",
                        column: x => x.ShaftShutterId,
                        principalTable: "ShaftShutters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShutterReverses_SlamShutters_SlamShutterId",
                        column: x => x.SlamShutterId,
                        principalTable: "SlamShutters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CastGateValveJournals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DetailName = table.Column<string>(nullable: true),
                    DetailNumber = table.Column<string>(nullable: true),
                    DetailDrawing = table.Column<string>(nullable: true),
                    Point = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    JournalNumber = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    InspectorId = table.Column<int>(nullable: true),
                    DetailId = table.Column<int>(nullable: true),
                    PointId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CastGateValveJournals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CastGateValveJournals_BaseValve_DetailId",
                        column: x => x.DetailId,
                        principalTable: "BaseValve",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CastGateValveJournals_Inspectors_InspectorId",
                        column: x => x.InspectorId,
                        principalTable: "Inspectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CastGateValveJournals_CastGateValveTCPs_PointId",
                        column: x => x.PointId,
                        principalTable: "CastGateValveTCPs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CompactGateValveJournals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DetailName = table.Column<string>(nullable: true),
                    DetailNumber = table.Column<string>(nullable: true),
                    DetailDrawing = table.Column<string>(nullable: true),
                    Point = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    JournalNumber = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    InspectorId = table.Column<int>(nullable: true),
                    DetailId = table.Column<int>(nullable: true),
                    PointId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompactGateValveJournals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompactGateValveJournals_BaseValve_DetailId",
                        column: x => x.DetailId,
                        principalTable: "BaseValve",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CompactGateValveJournals_Inspectors_InspectorId",
                        column: x => x.InspectorId,
                        principalTable: "Inspectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CompactGateValveJournals_CompactGateValveTCPs_PointId",
                        column: x => x.PointId,
                        principalTable: "CompactGateValveTCPs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Saddles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Number = table.Column<string>(nullable: true),
                    Drawing = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Material = table.Column<string>(nullable: true),
                    Certificate = table.Column<string>(nullable: true),
                    Melt = table.Column<string>(nullable: true),
                    BaseValveId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Saddles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Saddles_BaseValve_BaseValveId",
                        column: x => x.BaseValveId,
                        principalTable: "BaseValve",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SheetGateValveJournals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DetailName = table.Column<string>(nullable: true),
                    DetailNumber = table.Column<string>(nullable: true),
                    DetailDrawing = table.Column<string>(nullable: true),
                    Point = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    JournalNumber = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    InspectorId = table.Column<int>(nullable: true),
                    DetailId = table.Column<int>(nullable: true),
                    PointId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SheetGateValveJournals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SheetGateValveJournals_BaseValve_DetailId",
                        column: x => x.DetailId,
                        principalTable: "BaseValve",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SheetGateValveJournals_Inspectors_InspectorId",
                        column: x => x.InspectorId,
                        principalTable: "Inspectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SheetGateValveJournals_SheetGateValveTCPs_PointId",
                        column: x => x.PointId,
                        principalTable: "SheetGateValveTCPs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BronzeSleeveShutters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Number = table.Column<string>(nullable: true),
                    Drawing = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Material = table.Column<string>(nullable: true),
                    Certificate = table.Column<string>(nullable: true),
                    Melt = table.Column<string>(nullable: true),
                    ReverseShutterId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BronzeSleeveShutters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BronzeSleeveShutters_ShutterReverses_ReverseShutterId",
                        column: x => x.ReverseShutterId,
                        principalTable: "ShutterReverses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReverseShutterJournals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DetailName = table.Column<string>(nullable: true),
                    DetailNumber = table.Column<string>(nullable: true),
                    DetailDrawing = table.Column<string>(nullable: true),
                    Point = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    JournalNumber = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    InspectorId = table.Column<int>(nullable: true),
                    DetailId = table.Column<int>(nullable: true),
                    PointId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReverseShutterJournals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReverseShutterJournals_ShutterReverses_DetailId",
                        column: x => x.DetailId,
                        principalTable: "ShutterReverses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReverseShutterJournals_Inspectors_InspectorId",
                        column: x => x.InspectorId,
                        principalTable: "Inspectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReverseShutterJournals_ReverseShutterTCPs_PointId",
                        column: x => x.PointId,
                        principalTable: "ReverseShutterTCPs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SteelSleeveShutters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Number = table.Column<string>(nullable: true),
                    Drawing = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Material = table.Column<string>(nullable: true),
                    Certificate = table.Column<string>(nullable: true),
                    Melt = table.Column<string>(nullable: true),
                    ReverseShutterId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SteelSleeveShutters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SteelSleeveShutters_ShutterReverses_ReverseShutterId",
                        column: x => x.ReverseShutterId,
                        principalTable: "ShutterReverses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StubShutters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Number = table.Column<string>(nullable: true),
                    Drawing = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Material = table.Column<string>(nullable: true),
                    Certificate = table.Column<string>(nullable: true),
                    Melt = table.Column<string>(nullable: true),
                    ReverseShutterId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StubShutters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StubShutters_ShutterReverses_ReverseShutterId",
                        column: x => x.ReverseShutterId,
                        principalTable: "ShutterReverses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SaddleJournals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DetailName = table.Column<string>(nullable: true),
                    DetailNumber = table.Column<string>(nullable: true),
                    DetailDrawing = table.Column<string>(nullable: true),
                    Point = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    JournalNumber = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    InspectorId = table.Column<int>(nullable: true),
                    DetailId = table.Column<int>(nullable: true),
                    PointId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaddleJournals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SaddleJournals_Saddles_DetailId",
                        column: x => x.DetailId,
                        principalTable: "Saddles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SaddleJournals_Inspectors_InspectorId",
                        column: x => x.InspectorId,
                        principalTable: "Inspectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SaddleJournals_SaddleTCPs_PointId",
                        column: x => x.PointId,
                        principalTable: "SaddleTCPs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BronzeSleeveShutterJournals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DetailName = table.Column<string>(nullable: true),
                    DetailNumber = table.Column<string>(nullable: true),
                    DetailDrawing = table.Column<string>(nullable: true),
                    Point = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    JournalNumber = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    InspectorId = table.Column<int>(nullable: true),
                    DetailId = table.Column<int>(nullable: true),
                    PointId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BronzeSleeveShutterJournals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BronzeSleeveShutterJournals_BronzeSleeveShutters_DetailId",
                        column: x => x.DetailId,
                        principalTable: "BronzeSleeveShutters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BronzeSleeveShutterJournals_Inspectors_InspectorId",
                        column: x => x.InspectorId,
                        principalTable: "Inspectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BronzeSleeveShutterJournals_BronzeSleeveShutterTCPs_PointId",
                        column: x => x.PointId,
                        principalTable: "BronzeSleeveShutterTCPs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SteelSleeveShutterJournals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DetailName = table.Column<string>(nullable: true),
                    DetailNumber = table.Column<string>(nullable: true),
                    DetailDrawing = table.Column<string>(nullable: true),
                    Point = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    JournalNumber = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    InspectorId = table.Column<int>(nullable: true),
                    DetailId = table.Column<int>(nullable: true),
                    PointId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SteelSleeveShutterJournals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SteelSleeveShutterJournals_SteelSleeveShutters_DetailId",
                        column: x => x.DetailId,
                        principalTable: "SteelSleeveShutters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SteelSleeveShutterJournals_Inspectors_InspectorId",
                        column: x => x.InspectorId,
                        principalTable: "Inspectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SteelSleeveShutterJournals_SteelSleeveShutterTCPs_PointId",
                        column: x => x.PointId,
                        principalTable: "SteelSleeveShutterTCPs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StubShutterJournals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DetailName = table.Column<string>(nullable: true),
                    DetailNumber = table.Column<string>(nullable: true),
                    DetailDrawing = table.Column<string>(nullable: true),
                    Point = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    JournalNumber = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    InspectorId = table.Column<int>(nullable: true),
                    DetailId = table.Column<int>(nullable: true),
                    PointId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StubShutterJournals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StubShutterJournals_StubShutters_DetailId",
                        column: x => x.DetailId,
                        principalTable: "StubShutters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StubShutterJournals_Inspectors_InspectorId",
                        column: x => x.InspectorId,
                        principalTable: "Inspectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StubShutterJournals_StubShutterTCPs_PointId",
                        column: x => x.PointId,
                        principalTable: "StubShutterTCPs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaseValve_GateId",
                table: "BaseValve",
                column: "GateId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BaseValve_ShutterId",
                table: "BaseValve",
                column: "ShutterId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BaseValve_PIDId",
                table: "BaseValve",
                column: "PIDId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseValve_WeldGateValveCaseId",
                table: "BaseValve",
                column: "WeldGateValveCaseId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BaseValve_WeldGateValveCoverId",
                table: "BaseValve",
                column: "WeldGateValveCoverId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BaseValve_CastGateValveCaseId",
                table: "BaseValve",
                column: "CastGateValveCaseId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BaseValve_CastGateValveCoverId",
                table: "BaseValve",
                column: "CastGateValveCoverId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BaseValve_PIDId1",
                table: "BaseValve",
                column: "PIDId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseValveCover_RunningSleeveId",
                table: "BaseValveCover",
                column: "RunningSleeveId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BaseValveCover_SpindleId",
                table: "BaseValveCover",
                column: "SpindleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BaseValveCover_CoverSealingRingId",
                table: "BaseValveCover",
                column: "CoverSealingRingId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BronzeSleeveShutterJournals_DetailId",
                table: "BronzeSleeveShutterJournals",
                column: "DetailId");

            migrationBuilder.CreateIndex(
                name: "IX_BronzeSleeveShutterJournals_InspectorId",
                table: "BronzeSleeveShutterJournals",
                column: "InspectorId");

            migrationBuilder.CreateIndex(
                name: "IX_BronzeSleeveShutterJournals_PointId",
                table: "BronzeSleeveShutterJournals",
                column: "PointId");

            migrationBuilder.CreateIndex(
                name: "IX_BronzeSleeveShutters_ReverseShutterId",
                table: "BronzeSleeveShutters",
                column: "ReverseShutterId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseBottomJournals_DetailId",
                table: "CaseBottomJournals",
                column: "DetailId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseBottomJournals_InspectorId",
                table: "CaseBottomJournals",
                column: "InspectorId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseBottomJournals_PointId",
                table: "CaseBottomJournals",
                column: "PointId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseFlangeJournals_DetailId",
                table: "CaseFlangeJournals",
                column: "DetailId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseFlangeJournals_InspectorId",
                table: "CaseFlangeJournals",
                column: "InspectorId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseFlangeJournals_PointId",
                table: "CaseFlangeJournals",
                column: "PointId");

            migrationBuilder.CreateIndex(
                name: "IX_CastGateValveCaseJournals_DetailId",
                table: "CastGateValveCaseJournals",
                column: "DetailId");

            migrationBuilder.CreateIndex(
                name: "IX_CastGateValveCaseJournals_InspectorId",
                table: "CastGateValveCaseJournals",
                column: "InspectorId");

            migrationBuilder.CreateIndex(
                name: "IX_CastGateValveCaseJournals_PointId",
                table: "CastGateValveCaseJournals",
                column: "PointId");

            migrationBuilder.CreateIndex(
                name: "IX_CastGateValveCoverJournals_CastGateValveCoverTCPId",
                table: "CastGateValveCoverJournals",
                column: "CastGateValveCoverTCPId");

            migrationBuilder.CreateIndex(
                name: "IX_CastGateValveCoverJournals_DetailId",
                table: "CastGateValveCoverJournals",
                column: "DetailId");

            migrationBuilder.CreateIndex(
                name: "IX_CastGateValveCoverJournals_InspectorId",
                table: "CastGateValveCoverJournals",
                column: "InspectorId");

            migrationBuilder.CreateIndex(
                name: "IX_CastGateValveCoverJournals_PointId",
                table: "CastGateValveCoverJournals",
                column: "PointId");

            migrationBuilder.CreateIndex(
                name: "IX_CastGateValveJournals_DetailId",
                table: "CastGateValveJournals",
                column: "DetailId");

            migrationBuilder.CreateIndex(
                name: "IX_CastGateValveJournals_InspectorId",
                table: "CastGateValveJournals",
                column: "InspectorId");

            migrationBuilder.CreateIndex(
                name: "IX_CastGateValveJournals_PointId",
                table: "CastGateValveJournals",
                column: "PointId");

            migrationBuilder.CreateIndex(
                name: "IX_CompactGateValveCaseJournals_DetailId",
                table: "CompactGateValveCaseJournals",
                column: "DetailId");

            migrationBuilder.CreateIndex(
                name: "IX_CompactGateValveCaseJournals_InspectorId",
                table: "CompactGateValveCaseJournals",
                column: "InspectorId");

            migrationBuilder.CreateIndex(
                name: "IX_CompactGateValveCaseJournals_PointId",
                table: "CompactGateValveCaseJournals",
                column: "PointId");

            migrationBuilder.CreateIndex(
                name: "IX_CompactGateValveCoverJournals_DetailId",
                table: "CompactGateValveCoverJournals",
                column: "DetailId");

            migrationBuilder.CreateIndex(
                name: "IX_CompactGateValveCoverJournals_InspectorId",
                table: "CompactGateValveCoverJournals",
                column: "InspectorId");

            migrationBuilder.CreateIndex(
                name: "IX_CompactGateValveCoverJournals_PointId",
                table: "CompactGateValveCoverJournals",
                column: "PointId");

            migrationBuilder.CreateIndex(
                name: "IX_CompactGateValveJournals_DetailId",
                table: "CompactGateValveJournals",
                column: "DetailId");

            migrationBuilder.CreateIndex(
                name: "IX_CompactGateValveJournals_InspectorId",
                table: "CompactGateValveJournals",
                column: "InspectorId");

            migrationBuilder.CreateIndex(
                name: "IX_CompactGateValveJournals_PointId",
                table: "CompactGateValveJournals",
                column: "PointId");

            migrationBuilder.CreateIndex(
                name: "IX_CoverFlangeJournals_DetailId",
                table: "CoverFlangeJournals",
                column: "DetailId");

            migrationBuilder.CreateIndex(
                name: "IX_CoverFlangeJournals_InspectorId",
                table: "CoverFlangeJournals",
                column: "InspectorId");

            migrationBuilder.CreateIndex(
                name: "IX_CoverFlangeJournals_PointId",
                table: "CoverFlangeJournals",
                column: "PointId");

            migrationBuilder.CreateIndex(
                name: "IX_CoverSealingRingJournals_DetailId",
                table: "CoverSealingRingJournals",
                column: "DetailId");

            migrationBuilder.CreateIndex(
                name: "IX_CoverSealingRingJournals_InspectorId",
                table: "CoverSealingRingJournals",
                column: "InspectorId");

            migrationBuilder.CreateIndex(
                name: "IX_CoverSealingRingJournals_PointId",
                table: "CoverSealingRingJournals",
                column: "PointId");

            migrationBuilder.CreateIndex(
                name: "IX_CoverSleeveJournals_DetailId",
                table: "CoverSleeveJournals",
                column: "DetailId");

            migrationBuilder.CreateIndex(
                name: "IX_CoverSleeveJournals_InspectorId",
                table: "CoverSleeveJournals",
                column: "InspectorId");

            migrationBuilder.CreateIndex(
                name: "IX_CoverSleeveJournals_PointId",
                table: "CoverSleeveJournals",
                column: "PointId");

            migrationBuilder.CreateIndex(
                name: "IX_CoverSleeves_CoverSealingRingId",
                table: "CoverSleeves",
                column: "CoverSealingRingId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FrontWallJournals_DetailId",
                table: "FrontWallJournals",
                column: "DetailId");

            migrationBuilder.CreateIndex(
                name: "IX_FrontWallJournals_InspectorId",
                table: "FrontWallJournals",
                column: "InspectorId");

            migrationBuilder.CreateIndex(
                name: "IX_FrontWallJournals_PointId",
                table: "FrontWallJournals",
                column: "PointId");

            migrationBuilder.CreateIndex(
                name: "IX_FrontWalls_WeldGateValveCaseId",
                table: "FrontWalls",
                column: "WeldGateValveCaseId");

            migrationBuilder.CreateIndex(
                name: "IX_FrontWalls_WeldNozzleId",
                table: "FrontWalls",
                column: "WeldNozzleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GateJournals_DetailId",
                table: "GateJournals",
                column: "DetailId");

            migrationBuilder.CreateIndex(
                name: "IX_GateJournals_InspectorId",
                table: "GateJournals",
                column: "InspectorId");

            migrationBuilder.CreateIndex(
                name: "IX_GateJournals_PointId",
                table: "GateJournals",
                column: "PointId");

            migrationBuilder.CreateIndex(
                name: "IX_NozzleJournals_DetailId",
                table: "NozzleJournals",
                column: "DetailId");

            migrationBuilder.CreateIndex(
                name: "IX_NozzleJournals_InspectorId",
                table: "NozzleJournals",
                column: "InspectorId");

            migrationBuilder.CreateIndex(
                name: "IX_NozzleJournals_PointId",
                table: "NozzleJournals",
                column: "PointId");

            migrationBuilder.CreateIndex(
                name: "IX_Nozzles_CastingCaseId",
                table: "Nozzles",
                column: "CastingCaseId");

            migrationBuilder.CreateIndex(
                name: "IX_PIDs_ProductTypeId",
                table: "PIDs",
                column: "ProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PIDs_SpecificationId",
                table: "PIDs",
                column: "SpecificationId");

            migrationBuilder.CreateIndex(
                name: "IX_ReverseShutterCaseJournals_DetailId",
                table: "ReverseShutterCaseJournals",
                column: "DetailId");

            migrationBuilder.CreateIndex(
                name: "IX_ReverseShutterCaseJournals_InspectorId",
                table: "ReverseShutterCaseJournals",
                column: "InspectorId");

            migrationBuilder.CreateIndex(
                name: "IX_ReverseShutterCaseJournals_PointId",
                table: "ReverseShutterCaseJournals",
                column: "PointId");

            migrationBuilder.CreateIndex(
                name: "IX_ReverseShutterJournals_DetailId",
                table: "ReverseShutterJournals",
                column: "DetailId");

            migrationBuilder.CreateIndex(
                name: "IX_ReverseShutterJournals_InspectorId",
                table: "ReverseShutterJournals",
                column: "InspectorId");

            migrationBuilder.CreateIndex(
                name: "IX_ReverseShutterJournals_PointId",
                table: "ReverseShutterJournals",
                column: "PointId");

            migrationBuilder.CreateIndex(
                name: "IX_RunningSleeveJournals_DetailId",
                table: "RunningSleeveJournals",
                column: "DetailId");

            migrationBuilder.CreateIndex(
                name: "IX_RunningSleeveJournals_InspectorId",
                table: "RunningSleeveJournals",
                column: "InspectorId");

            migrationBuilder.CreateIndex(
                name: "IX_RunningSleeveJournals_PointId",
                table: "RunningSleeveJournals",
                column: "PointId");

            migrationBuilder.CreateIndex(
                name: "IX_SaddleJournals_DetailId",
                table: "SaddleJournals",
                column: "DetailId");

            migrationBuilder.CreateIndex(
                name: "IX_SaddleJournals_InspectorId",
                table: "SaddleJournals",
                column: "InspectorId");

            migrationBuilder.CreateIndex(
                name: "IX_SaddleJournals_PointId",
                table: "SaddleJournals",
                column: "PointId");

            migrationBuilder.CreateIndex(
                name: "IX_Saddles_BaseValveId",
                table: "Saddles",
                column: "BaseValveId");

            migrationBuilder.CreateIndex(
                name: "IX_ShaftShutterJournals_DetailId",
                table: "ShaftShutterJournals",
                column: "DetailId");

            migrationBuilder.CreateIndex(
                name: "IX_ShaftShutterJournals_InspectorId",
                table: "ShaftShutterJournals",
                column: "InspectorId");

            migrationBuilder.CreateIndex(
                name: "IX_ShaftShutterJournals_PointId",
                table: "ShaftShutterJournals",
                column: "PointId");

            migrationBuilder.CreateIndex(
                name: "IX_SheetGateValveCaseJournals_DetailId",
                table: "SheetGateValveCaseJournals",
                column: "DetailId");

            migrationBuilder.CreateIndex(
                name: "IX_SheetGateValveCaseJournals_InspectorId",
                table: "SheetGateValveCaseJournals",
                column: "InspectorId");

            migrationBuilder.CreateIndex(
                name: "IX_SheetGateValveCaseJournals_PointId",
                table: "SheetGateValveCaseJournals",
                column: "PointId");

            migrationBuilder.CreateIndex(
                name: "IX_SheetGateValveCoverJournals_DetailId",
                table: "SheetGateValveCoverJournals",
                column: "DetailId");

            migrationBuilder.CreateIndex(
                name: "IX_SheetGateValveCoverJournals_InspectorId",
                table: "SheetGateValveCoverJournals",
                column: "InspectorId");

            migrationBuilder.CreateIndex(
                name: "IX_SheetGateValveCoverJournals_PointId",
                table: "SheetGateValveCoverJournals",
                column: "PointId");

            migrationBuilder.CreateIndex(
                name: "IX_SheetGateValveJournals_DetailId",
                table: "SheetGateValveJournals",
                column: "DetailId");

            migrationBuilder.CreateIndex(
                name: "IX_SheetGateValveJournals_InspectorId",
                table: "SheetGateValveJournals",
                column: "InspectorId");

            migrationBuilder.CreateIndex(
                name: "IX_SheetGateValveJournals_PointId",
                table: "SheetGateValveJournals",
                column: "PointId");

            migrationBuilder.CreateIndex(
                name: "IX_ShutterDiskJournals_DetailId",
                table: "ShutterDiskJournals",
                column: "DetailId");

            migrationBuilder.CreateIndex(
                name: "IX_ShutterDiskJournals_InspectorId",
                table: "ShutterDiskJournals",
                column: "InspectorId");

            migrationBuilder.CreateIndex(
                name: "IX_ShutterDiskJournals_PointId",
                table: "ShutterDiskJournals",
                column: "PointId");

            migrationBuilder.CreateIndex(
                name: "IX_ShutterDisks_ShutterId",
                table: "ShutterDisks",
                column: "ShutterId");

            migrationBuilder.CreateIndex(
                name: "IX_ShutterGuideJournals_DetailId",
                table: "ShutterGuideJournals",
                column: "DetailId");

            migrationBuilder.CreateIndex(
                name: "IX_ShutterGuideJournals_InspectorId",
                table: "ShutterGuideJournals",
                column: "InspectorId");

            migrationBuilder.CreateIndex(
                name: "IX_ShutterGuideJournals_PointId",
                table: "ShutterGuideJournals",
                column: "PointId");

            migrationBuilder.CreateIndex(
                name: "IX_ShutterGuides_ShutterId",
                table: "ShutterGuides",
                column: "ShutterId");

            migrationBuilder.CreateIndex(
                name: "IX_ShutterJournals_DetailId",
                table: "ShutterJournals",
                column: "DetailId");

            migrationBuilder.CreateIndex(
                name: "IX_ShutterJournals_InspectorId",
                table: "ShutterJournals",
                column: "InspectorId");

            migrationBuilder.CreateIndex(
                name: "IX_ShutterJournals_PointId",
                table: "ShutterJournals",
                column: "PointId");

            migrationBuilder.CreateIndex(
                name: "IX_ShutterReverses_PIDId",
                table: "ShutterReverses",
                column: "PIDId");

            migrationBuilder.CreateIndex(
                name: "IX_ShutterReverses_ReverseShutterCaseId",
                table: "ShutterReverses",
                column: "ReverseShutterCaseId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShutterReverses_ShaftShutterId",
                table: "ShutterReverses",
                column: "ShaftShutterId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShutterReverses_SlamShutterId",
                table: "ShutterReverses",
                column: "SlamShutterId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SideWallJournals_DetailId",
                table: "SideWallJournals",
                column: "DetailId");

            migrationBuilder.CreateIndex(
                name: "IX_SideWallJournals_InspectorId",
                table: "SideWallJournals",
                column: "InspectorId");

            migrationBuilder.CreateIndex(
                name: "IX_SideWallJournals_PointId",
                table: "SideWallJournals",
                column: "PointId");

            migrationBuilder.CreateIndex(
                name: "IX_SideWalls_WeldGateValveCaseId",
                table: "SideWalls",
                column: "WeldGateValveCaseId");

            migrationBuilder.CreateIndex(
                name: "IX_SlamShutterJournals_DetailId",
                table: "SlamShutterJournals",
                column: "DetailId");

            migrationBuilder.CreateIndex(
                name: "IX_SlamShutterJournals_InspectorId",
                table: "SlamShutterJournals",
                column: "InspectorId");

            migrationBuilder.CreateIndex(
                name: "IX_SlamShutterJournals_PointId",
                table: "SlamShutterJournals",
                column: "PointId");

            migrationBuilder.CreateIndex(
                name: "IX_Specifications_CustomerId",
                table: "Specifications",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_SpindleJournals_DetailId",
                table: "SpindleJournals",
                column: "DetailId");

            migrationBuilder.CreateIndex(
                name: "IX_SpindleJournals_InspectorId",
                table: "SpindleJournals",
                column: "InspectorId");

            migrationBuilder.CreateIndex(
                name: "IX_SpindleJournals_PointId",
                table: "SpindleJournals",
                column: "PointId");

            migrationBuilder.CreateIndex(
                name: "IX_SteelSleeveShutterJournals_DetailId",
                table: "SteelSleeveShutterJournals",
                column: "DetailId");

            migrationBuilder.CreateIndex(
                name: "IX_SteelSleeveShutterJournals_InspectorId",
                table: "SteelSleeveShutterJournals",
                column: "InspectorId");

            migrationBuilder.CreateIndex(
                name: "IX_SteelSleeveShutterJournals_PointId",
                table: "SteelSleeveShutterJournals",
                column: "PointId");

            migrationBuilder.CreateIndex(
                name: "IX_SteelSleeveShutters_ReverseShutterId",
                table: "SteelSleeveShutters",
                column: "ReverseShutterId");

            migrationBuilder.CreateIndex(
                name: "IX_StubShutterJournals_DetailId",
                table: "StubShutterJournals",
                column: "DetailId");

            migrationBuilder.CreateIndex(
                name: "IX_StubShutterJournals_InspectorId",
                table: "StubShutterJournals",
                column: "InspectorId");

            migrationBuilder.CreateIndex(
                name: "IX_StubShutterJournals_PointId",
                table: "StubShutterJournals",
                column: "PointId");

            migrationBuilder.CreateIndex(
                name: "IX_StubShutters_ReverseShutterId",
                table: "StubShutters",
                column: "ReverseShutterId");

            migrationBuilder.CreateIndex(
                name: "IX_WeldGateValveCase_CaseBottomId",
                table: "WeldGateValveCase",
                column: "CaseBottomId");

            migrationBuilder.CreateIndex(
                name: "IX_WeldGateValveCase_CaseFlangeId",
                table: "WeldGateValveCase",
                column: "CaseFlangeId");

            migrationBuilder.CreateIndex(
                name: "IX_WeldGateValveCover_CoverFlangeId",
                table: "WeldGateValveCover",
                column: "CoverFlangeId");

            migrationBuilder.CreateIndex(
                name: "IX_WeldGateValveCover_CoverSleeveId",
                table: "WeldGateValveCover",
                column: "CoverSleeveId");

            migrationBuilder.CreateIndex(
                name: "IX_WeldNozzleJournals_DetailId",
                table: "WeldNozzleJournals",
                column: "DetailId");

            migrationBuilder.CreateIndex(
                name: "IX_WeldNozzleJournals_InspectorId",
                table: "WeldNozzleJournals",
                column: "InspectorId");

            migrationBuilder.CreateIndex(
                name: "IX_WeldNozzleJournals_PointId",
                table: "WeldNozzleJournals",
                column: "PointId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BronzeSleeveShutterJournals");

            migrationBuilder.DropTable(
                name: "CaseBottomJournals");

            migrationBuilder.DropTable(
                name: "CaseFlangeJournals");

            migrationBuilder.DropTable(
                name: "CastGateValveCaseJournals");

            migrationBuilder.DropTable(
                name: "CastGateValveCoverJournals");

            migrationBuilder.DropTable(
                name: "CastGateValveJournals");

            migrationBuilder.DropTable(
                name: "CompactGateValveCaseJournals");

            migrationBuilder.DropTable(
                name: "CompactGateValveCoverJournals");

            migrationBuilder.DropTable(
                name: "CompactGateValveJournals");

            migrationBuilder.DropTable(
                name: "CoverFlangeJournals");

            migrationBuilder.DropTable(
                name: "CoverSealingRingJournals");

            migrationBuilder.DropTable(
                name: "CoverSleeveJournals");

            migrationBuilder.DropTable(
                name: "FrontWallJournals");

            migrationBuilder.DropTable(
                name: "GateJournals");

            migrationBuilder.DropTable(
                name: "JournalNumbers");

            migrationBuilder.DropTable(
                name: "NozzleJournals");

            migrationBuilder.DropTable(
                name: "ReverseShutterCaseJournals");

            migrationBuilder.DropTable(
                name: "ReverseShutterJournals");

            migrationBuilder.DropTable(
                name: "RunningSleeveJournals");

            migrationBuilder.DropTable(
                name: "SaddleJournals");

            migrationBuilder.DropTable(
                name: "ShaftShutterJournals");

            migrationBuilder.DropTable(
                name: "SheetGateValveCaseJournals");

            migrationBuilder.DropTable(
                name: "SheetGateValveCoverJournals");

            migrationBuilder.DropTable(
                name: "SheetGateValveJournals");

            migrationBuilder.DropTable(
                name: "ShutterDiskJournals");

            migrationBuilder.DropTable(
                name: "ShutterGuideJournals");

            migrationBuilder.DropTable(
                name: "ShutterJournals");

            migrationBuilder.DropTable(
                name: "SideWallJournals");

            migrationBuilder.DropTable(
                name: "SlamShutterJournals");

            migrationBuilder.DropTable(
                name: "SpindleJournals");

            migrationBuilder.DropTable(
                name: "SteelSleeveShutterJournals");

            migrationBuilder.DropTable(
                name: "StubShutterJournals");

            migrationBuilder.DropTable(
                name: "WeldNozzleJournals");

            migrationBuilder.DropTable(
                name: "BronzeSleeveShutters");

            migrationBuilder.DropTable(
                name: "BronzeSleeveShutterTCPs");

            migrationBuilder.DropTable(
                name: "CaseBottomTCPs");

            migrationBuilder.DropTable(
                name: "CaseFlangeTCPs");

            migrationBuilder.DropTable(
                name: "CastGateValveCoverTCPs");

            migrationBuilder.DropTable(
                name: "CastGateValveCaseTCPs");

            migrationBuilder.DropTable(
                name: "CastGateValveTCPs");

            migrationBuilder.DropTable(
                name: "CompactGateValveCaseTCPs");

            migrationBuilder.DropTable(
                name: "CompactGateValveCoverTCPs");

            migrationBuilder.DropTable(
                name: "CompactGateValveTCPs");

            migrationBuilder.DropTable(
                name: "CoverFlangeTCPs");

            migrationBuilder.DropTable(
                name: "CoverSealingRingTCPs");

            migrationBuilder.DropTable(
                name: "CoverSleeveTCPs");

            migrationBuilder.DropTable(
                name: "FrontWalls");

            migrationBuilder.DropTable(
                name: "FrontWallTCPs");

            migrationBuilder.DropTable(
                name: "GateTCPs");

            migrationBuilder.DropTable(
                name: "Nozzles");

            migrationBuilder.DropTable(
                name: "NozzleTCPs");

            migrationBuilder.DropTable(
                name: "ReverseShutterCaseTCPs");

            migrationBuilder.DropTable(
                name: "ReverseShutterTCPs");

            migrationBuilder.DropTable(
                name: "RunningSleeveTCPs");

            migrationBuilder.DropTable(
                name: "Saddles");

            migrationBuilder.DropTable(
                name: "SaddleTCPs");

            migrationBuilder.DropTable(
                name: "ShaftShutterTCPs");

            migrationBuilder.DropTable(
                name: "SheetGateValveCaseTCPs");

            migrationBuilder.DropTable(
                name: "SheetGateValveCoverTCPs");

            migrationBuilder.DropTable(
                name: "SheetGateValveTCPs");

            migrationBuilder.DropTable(
                name: "ShutterDisks");

            migrationBuilder.DropTable(
                name: "ShutterDiskTCPs");

            migrationBuilder.DropTable(
                name: "ShutterGuides");

            migrationBuilder.DropTable(
                name: "ShutterGuideTCPs");

            migrationBuilder.DropTable(
                name: "ShutterTCPs");

            migrationBuilder.DropTable(
                name: "SideWalls");

            migrationBuilder.DropTable(
                name: "SideWallTCPs");

            migrationBuilder.DropTable(
                name: "SlamShutterTCPs");

            migrationBuilder.DropTable(
                name: "SpindleTCPs");

            migrationBuilder.DropTable(
                name: "SteelSleeveShutters");

            migrationBuilder.DropTable(
                name: "SteelSleeveShutterTCPs");

            migrationBuilder.DropTable(
                name: "StubShutters");

            migrationBuilder.DropTable(
                name: "StubShutterTCPs");

            migrationBuilder.DropTable(
                name: "Inspectors");

            migrationBuilder.DropTable(
                name: "WeldNozzleTCPs");

            migrationBuilder.DropTable(
                name: "WeldNozzles");

            migrationBuilder.DropTable(
                name: "BaseValve");

            migrationBuilder.DropTable(
                name: "ShutterReverses");

            migrationBuilder.DropTable(
                name: "Gates");

            migrationBuilder.DropTable(
                name: "Shutters");

            migrationBuilder.DropTable(
                name: "WeldGateValveCase");

            migrationBuilder.DropTable(
                name: "WeldGateValveCover");

            migrationBuilder.DropTable(
                name: "BaseValveCover");

            migrationBuilder.DropTable(
                name: "PIDs");

            migrationBuilder.DropTable(
                name: "BaseCastingCase");

            migrationBuilder.DropTable(
                name: "ShaftShutters");

            migrationBuilder.DropTable(
                name: "SlamShutters");

            migrationBuilder.DropTable(
                name: "CaseBottoms");

            migrationBuilder.DropTable(
                name: "CaseFlanges");

            migrationBuilder.DropTable(
                name: "CoverFlanges");

            migrationBuilder.DropTable(
                name: "CoverSleeves");

            migrationBuilder.DropTable(
                name: "RunningSleeves");

            migrationBuilder.DropTable(
                name: "Spindles");

            migrationBuilder.DropTable(
                name: "ProductTypes");

            migrationBuilder.DropTable(
                name: "Specifications");

            migrationBuilder.DropTable(
                name: "CoverSealingRings");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
