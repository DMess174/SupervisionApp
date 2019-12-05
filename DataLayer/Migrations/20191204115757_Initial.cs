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
                    Melt = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BronzeSleeveShutters", x => x.Id);
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
                name: "CaseShutterTCPs",
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
                    table.PrimaryKey("PK_CaseShutterTCPs", x => x.Id);
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
                name: "ShutterReverseTCPs",
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
                    table.PrimaryKey("PK_ShutterReverseTCPs", x => x.Id);
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
                    Melt = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SteelSleeveShutters", x => x.Id);
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
                    Melt = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StubShutters", x => x.Id);
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
                name: "ValveCaseTCPs",
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
                    table.PrimaryKey("PK_ValveCaseTCPs", x => x.Id);
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
                name: "CaseShutterJournals",
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
                    table.PrimaryKey("PK_CaseShutterJournals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CaseShutterJournals_BaseCastingCase_DetailId",
                        column: x => x.DetailId,
                        principalTable: "BaseCastingCase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CaseShutterJournals_Inspectors_InspectorId",
                        column: x => x.InspectorId,
                        principalTable: "Inspectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CaseShutterJournals_CaseShutterTCPs_PointId",
                        column: x => x.PointId,
                        principalTable: "CaseShutterTCPs",
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

            migrationBuilder.CreateTable(
                name: "ValveCaseJournals",
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
                    table.PrimaryKey("PK_ValveCaseJournals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ValveCaseJournals_BaseCastingCase_DetailId",
                        column: x => x.DetailId,
                        principalTable: "BaseCastingCase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ValveCaseJournals_ValveCaseTCPs_PointId",
                        column: x => x.PointId,
                        principalTable: "ValveCaseTCPs",
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
                    CaseShutterId = table.Column<int>(nullable: true),
                    ShaftShutterId = table.Column<int>(nullable: true),
                    SlamShutterId = table.Column<int>(nullable: true),
                    FirstBronzeSleeveShutterId = table.Column<int>(nullable: true),
                    SecondBronzeSleeveShutterId = table.Column<int>(nullable: true),
                    FirstSteelSleeveShutterId = table.Column<int>(nullable: true),
                    SecondSteelSleeveShutterId = table.Column<int>(nullable: true),
                    FirstStubShutterId = table.Column<int>(nullable: true),
                    SecondStubShutterId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShutterReverses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShutterReverses_BaseCastingCase_CaseShutterId",
                        column: x => x.CaseShutterId,
                        principalTable: "BaseCastingCase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShutterReverses_BronzeSleeveShutters_FirstBronzeSleeveShutterId",
                        column: x => x.FirstBronzeSleeveShutterId,
                        principalTable: "BronzeSleeveShutters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShutterReverses_SteelSleeveShutters_FirstSteelSleeveShutterId",
                        column: x => x.FirstSteelSleeveShutterId,
                        principalTable: "SteelSleeveShutters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShutterReverses_StubShutters_FirstStubShutterId",
                        column: x => x.FirstStubShutterId,
                        principalTable: "StubShutters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShutterReverses_PIDs_PIDId",
                        column: x => x.PIDId,
                        principalTable: "PIDs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShutterReverses_BronzeSleeveShutters_SecondBronzeSleeveShutterId",
                        column: x => x.SecondBronzeSleeveShutterId,
                        principalTable: "BronzeSleeveShutters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShutterReverses_SteelSleeveShutters_SecondSteelSleeveShutterId",
                        column: x => x.SecondSteelSleeveShutterId,
                        principalTable: "SteelSleeveShutters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShutterReverses_StubShutters_SecondStubShutterId",
                        column: x => x.SecondStubShutterId,
                        principalTable: "StubShutters",
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
                name: "ShutterReverseJournals",
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
                    table.PrimaryKey("PK_ShutterReverseJournals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShutterReverseJournals_ShutterReverses_DetailId",
                        column: x => x.DetailId,
                        principalTable: "ShutterReverses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShutterReverseJournals_Inspectors_InspectorId",
                        column: x => x.InspectorId,
                        principalTable: "Inspectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShutterReverseJournals_ShutterReverseTCPs_PointId",
                        column: x => x.PointId,
                        principalTable: "ShutterReverseTCPs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
                name: "IX_CaseShutterJournals_DetailId",
                table: "CaseShutterJournals",
                column: "DetailId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseShutterJournals_InspectorId",
                table: "CaseShutterJournals",
                column: "InspectorId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseShutterJournals_PointId",
                table: "CaseShutterJournals",
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
                name: "IX_ShutterReverseJournals_DetailId",
                table: "ShutterReverseJournals",
                column: "DetailId");

            migrationBuilder.CreateIndex(
                name: "IX_ShutterReverseJournals_InspectorId",
                table: "ShutterReverseJournals",
                column: "InspectorId");

            migrationBuilder.CreateIndex(
                name: "IX_ShutterReverseJournals_PointId",
                table: "ShutterReverseJournals",
                column: "PointId");

            migrationBuilder.CreateIndex(
                name: "IX_ShutterReverses_CaseShutterId",
                table: "ShutterReverses",
                column: "CaseShutterId");

            migrationBuilder.CreateIndex(
                name: "IX_ShutterReverses_FirstBronzeSleeveShutterId",
                table: "ShutterReverses",
                column: "FirstBronzeSleeveShutterId");

            migrationBuilder.CreateIndex(
                name: "IX_ShutterReverses_FirstSteelSleeveShutterId",
                table: "ShutterReverses",
                column: "FirstSteelSleeveShutterId");

            migrationBuilder.CreateIndex(
                name: "IX_ShutterReverses_FirstStubShutterId",
                table: "ShutterReverses",
                column: "FirstStubShutterId");

            migrationBuilder.CreateIndex(
                name: "IX_ShutterReverses_PIDId",
                table: "ShutterReverses",
                column: "PIDId");

            migrationBuilder.CreateIndex(
                name: "IX_ShutterReverses_SecondBronzeSleeveShutterId",
                table: "ShutterReverses",
                column: "SecondBronzeSleeveShutterId");

            migrationBuilder.CreateIndex(
                name: "IX_ShutterReverses_SecondSteelSleeveShutterId",
                table: "ShutterReverses",
                column: "SecondSteelSleeveShutterId");

            migrationBuilder.CreateIndex(
                name: "IX_ShutterReverses_SecondStubShutterId",
                table: "ShutterReverses",
                column: "SecondStubShutterId");

            migrationBuilder.CreateIndex(
                name: "IX_ShutterReverses_ShaftShutterId",
                table: "ShutterReverses",
                column: "ShaftShutterId");

            migrationBuilder.CreateIndex(
                name: "IX_ShutterReverses_SlamShutterId",
                table: "ShutterReverses",
                column: "SlamShutterId");

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
                name: "IX_ValveCaseJournals_DetailId",
                table: "ValveCaseJournals",
                column: "DetailId");

            migrationBuilder.CreateIndex(
                name: "IX_ValveCaseJournals_PointId",
                table: "ValveCaseJournals",
                column: "PointId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BronzeSleeveShutterJournals");

            migrationBuilder.DropTable(
                name: "CaseShutterJournals");

            migrationBuilder.DropTable(
                name: "JournalNumbers");

            migrationBuilder.DropTable(
                name: "NozzleJournals");

            migrationBuilder.DropTable(
                name: "ShaftShutterJournals");

            migrationBuilder.DropTable(
                name: "ShutterReverseJournals");

            migrationBuilder.DropTable(
                name: "SlamShutterJournals");

            migrationBuilder.DropTable(
                name: "SteelSleeveShutterJournals");

            migrationBuilder.DropTable(
                name: "StubShutterJournals");

            migrationBuilder.DropTable(
                name: "ValveCaseJournals");

            migrationBuilder.DropTable(
                name: "BronzeSleeveShutterTCPs");

            migrationBuilder.DropTable(
                name: "CaseShutterTCPs");

            migrationBuilder.DropTable(
                name: "Nozzles");

            migrationBuilder.DropTable(
                name: "NozzleTCPs");

            migrationBuilder.DropTable(
                name: "ShaftShutterTCPs");

            migrationBuilder.DropTable(
                name: "ShutterReverses");

            migrationBuilder.DropTable(
                name: "ShutterReverseTCPs");

            migrationBuilder.DropTable(
                name: "SlamShutterTCPs");

            migrationBuilder.DropTable(
                name: "SteelSleeveShutterTCPs");

            migrationBuilder.DropTable(
                name: "Inspectors");

            migrationBuilder.DropTable(
                name: "StubShutterTCPs");

            migrationBuilder.DropTable(
                name: "ValveCaseTCPs");

            migrationBuilder.DropTable(
                name: "BaseCastingCase");

            migrationBuilder.DropTable(
                name: "BronzeSleeveShutters");

            migrationBuilder.DropTable(
                name: "SteelSleeveShutters");

            migrationBuilder.DropTable(
                name: "StubShutters");

            migrationBuilder.DropTable(
                name: "PIDs");

            migrationBuilder.DropTable(
                name: "ShaftShutters");

            migrationBuilder.DropTable(
                name: "SlamShutters");

            migrationBuilder.DropTable(
                name: "ProductTypes");

            migrationBuilder.DropTable(
                name: "Specifications");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
