using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssemblyUnitSeals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    Drawing = table.Column<string>(nullable: true),
                    Certificate = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    Material = table.Column<string>(nullable: true),
                    Batch = table.Column<string>(nullable: true),
                    Series = table.Column<string>(nullable: true),
                    Amount = table.Column<int>(nullable: false),
                    AmountRemaining = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssemblyUnitSeals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BaseAnticorrosiveCoatings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Certificate = table.Column<string>(nullable: true),
                    Batch = table.Column<string>(nullable: true),
                    Amount = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    Color = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseAnticorrosiveCoatings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BaseCastingCase",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    Drawing = table.Column<string>(nullable: true),
                    Certificate = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    Material = table.Column<string>(nullable: true),
                    Melt = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseCastingCase", x => x.Id);
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
                name: "FrontalSaddleSeals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    Drawing = table.Column<string>(nullable: true),
                    Certificate = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    Material = table.Column<string>(nullable: true),
                    Batch = table.Column<string>(nullable: true),
                    Series = table.Column<string>(nullable: true),
                    Amount = table.Column<int>(nullable: false),
                    AmountRemaining = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FrontalSaddleSeals", x => x.Id);
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
                    IsClosed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JournalNumbers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MetalMaterials",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    Material = table.Column<string>(nullable: true),
                    Melt = table.Column<string>(nullable: true),
                    Certificate = table.Column<string>(nullable: true),
                    Batch = table.Column<string>(nullable: true),
                    MaterialCertificateNumber = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    FirstSize = table.Column<string>(nullable: true),
                    SecondSize = table.Column<string>(nullable: true),
                    ThirdSize = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    MetalCharge = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetalMaterials", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OperationTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationTypes", x => x.Id);
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
                name: "RunningSleeves",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    Drawing = table.Column<string>(nullable: true),
                    Certificate = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    Material = table.Column<string>(nullable: true),
                    Melt = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RunningSleeves", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ScrewNuts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    Drawing = table.Column<string>(nullable: true),
                    Certificate = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    Material = table.Column<string>(nullable: true),
                    Melt = table.Column<string>(nullable: true),
                    Batch = table.Column<string>(nullable: true),
                    Amount = table.Column<int>(nullable: false),
                    AmountRemaining = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScrewNuts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ScrewStuds",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    Drawing = table.Column<string>(nullable: true),
                    Certificate = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    Material = table.Column<string>(nullable: true),
                    Melt = table.Column<string>(nullable: true),
                    Batch = table.Column<string>(nullable: true),
                    Amount = table.Column<int>(nullable: false),
                    AmountRemaining = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScrewStuds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shutters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    Drawing = table.Column<string>(nullable: true),
                    Certificate = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shutters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SlamShutters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    Drawing = table.Column<string>(nullable: true),
                    Certificate = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    Material = table.Column<string>(nullable: true),
                    Melt = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SlamShutters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Springs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    Drawing = table.Column<string>(nullable: true),
                    Certificate = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    Material = table.Column<string>(nullable: true),
                    Melt = table.Column<string>(nullable: true),
                    Batch = table.Column<string>(nullable: true),
                    Amount = table.Column<int>(nullable: false),
                    AmountRemaining = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Springs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WeldingMaterials",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Certificate = table.Column<string>(nullable: true),
                    Batch = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeldingMaterials", x => x.Id);
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
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "CaseBottoms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    Drawing = table.Column<string>(nullable: true),
                    Certificate = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    MetalMaterialId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseBottoms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CaseBottoms_MetalMaterials_MetalMaterialId",
                        column: x => x.MetalMaterialId,
                        principalTable: "MetalMaterials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "CaseFlanges",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    Drawing = table.Column<string>(nullable: true),
                    Certificate = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    MetalMaterialId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseFlanges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CaseFlanges_MetalMaterials_MetalMaterialId",
                        column: x => x.MetalMaterialId,
                        principalTable: "MetalMaterials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "CoverFlanges",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    Drawing = table.Column<string>(nullable: true),
                    Certificate = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    MetalMaterialId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoverFlanges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoverFlanges_MetalMaterials_MetalMaterialId",
                        column: x => x.MetalMaterialId,
                        principalTable: "MetalMaterials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "CoverSealingRings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    Drawing = table.Column<string>(nullable: true),
                    Certificate = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    MetalMaterialId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoverSealingRings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoverSealingRings_MetalMaterials_MetalMaterialId",
                        column: x => x.MetalMaterialId,
                        principalTable: "MetalMaterials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Gates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    Drawing = table.Column<string>(nullable: true),
                    Certificate = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    MetalMaterialId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Gates_MetalMaterials_MetalMaterialId",
                        column: x => x.MetalMaterialId,
                        principalTable: "MetalMaterials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Nozzles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    Drawing = table.Column<string>(nullable: true),
                    Certificate = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    Diameter = table.Column<string>(nullable: true),
                    Thickness = table.Column<string>(nullable: true),
                    ThicknessJoin = table.Column<string>(nullable: true),
                    MetalMaterialId = table.Column<int>(nullable: true),
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
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Nozzles_MetalMaterials_MetalMaterialId",
                        column: x => x.MetalMaterialId,
                        principalTable: "MetalMaterials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "ShaftShutters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    Drawing = table.Column<string>(nullable: true),
                    Certificate = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    MetalMaterialId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShaftShutters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShaftShutters_MetalMaterials_MetalMaterialId",
                        column: x => x.MetalMaterialId,
                        principalTable: "MetalMaterials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Spindles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    Drawing = table.Column<string>(nullable: true),
                    Certificate = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    MetalMaterialId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spindles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Spindles_MetalMaterials_MetalMaterialId",
                        column: x => x.MetalMaterialId,
                        principalTable: "MetalMaterials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "WeldNozzles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    Drawing = table.Column<string>(nullable: true),
                    Certificate = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    MetalMaterialId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeldNozzles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeldNozzles_MetalMaterials_MetalMaterialId",
                        column: x => x.MetalMaterialId,
                        principalTable: "MetalMaterials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "BaseTCP",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Point = table.Column<string>(nullable: true),
                    OperationName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    OperationNameId = table.Column<int>(nullable: true),
                    ProductTypeId = table.Column<int>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseTCP", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaseTCP_OperationTypes_OperationNameId",
                        column: x => x.OperationNameId,
                        principalTable: "OperationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_BaseTCP_ProductTypes_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalTable: "ProductTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "ShutterDisks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    Drawing = table.Column<string>(nullable: true),
                    Certificate = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    MetalMaterialId = table.Column<int>(nullable: true),
                    ShutterId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShutterDisks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShutterDisks_MetalMaterials_MetalMaterialId",
                        column: x => x.MetalMaterialId,
                        principalTable: "MetalMaterials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_ShutterDisks_Shutters_ShutterId",
                        column: x => x.ShutterId,
                        principalTable: "Shutters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "ShutterGuides",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    Drawing = table.Column<string>(nullable: true),
                    Certificate = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    MetalMaterialId = table.Column<int>(nullable: true),
                    ShutterId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShutterGuides", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShutterGuides_MetalMaterials_MetalMaterialId",
                        column: x => x.MetalMaterialId,
                        principalTable: "MetalMaterials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_ShutterGuides_Shutters_ShutterId",
                        column: x => x.ShutterId,
                        principalTable: "Shutters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
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
                    Comment = table.Column<string>(nullable: true),
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
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_PIDs_Specifications_SpecificationId",
                        column: x => x.SpecificationId,
                        principalTable: "Specifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "WeldGateValveCase",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    Drawing = table.Column<string>(nullable: true),
                    Certificate = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
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
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_WeldGateValveCase_CaseFlanges_CaseFlangeId",
                        column: x => x.CaseFlangeId,
                        principalTable: "CaseFlanges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "CoverSleeves",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    Drawing = table.Column<string>(nullable: true),
                    Certificate = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    MetalMaterialId = table.Column<int>(nullable: true),
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
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_CoverSleeves_MetalMaterials_MetalMaterialId",
                        column: x => x.MetalMaterialId,
                        principalTable: "MetalMaterials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "AbovegroundCoatingJournals",
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
                    RemarkIssued = table.Column<string>(nullable: true),
                    RemarkClosed = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    InspectorId = table.Column<int>(nullable: true),
                    DetailId = table.Column<int>(nullable: true),
                    PointId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbovegroundCoatingJournals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbovegroundCoatingJournals_BaseAnticorrosiveCoatings_DetailId",
                        column: x => x.DetailId,
                        principalTable: "BaseAnticorrosiveCoatings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_AbovegroundCoatingJournals_Inspectors_InspectorId",
                        column: x => x.InspectorId,
                        principalTable: "Inspectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_AbovegroundCoatingJournals_BaseTCP_PointId",
                        column: x => x.PointId,
                        principalTable: "BaseTCP",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "AbrasiveMaterialJournals",
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
                    RemarkIssued = table.Column<string>(nullable: true),
                    RemarkClosed = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    InspectorId = table.Column<int>(nullable: true),
                    DetailId = table.Column<int>(nullable: true),
                    PointId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbrasiveMaterialJournals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbrasiveMaterialJournals_BaseAnticorrosiveCoatings_DetailId",
                        column: x => x.DetailId,
                        principalTable: "BaseAnticorrosiveCoatings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_AbrasiveMaterialJournals_Inspectors_InspectorId",
                        column: x => x.InspectorId,
                        principalTable: "Inspectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_AbrasiveMaterialJournals_BaseTCP_PointId",
                        column: x => x.PointId,
                        principalTable: "BaseTCP",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "AssemblyUnitSealingJournals",
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
                    RemarkIssued = table.Column<string>(nullable: true),
                    RemarkClosed = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    InspectorId = table.Column<int>(nullable: true),
                    DetailId = table.Column<int>(nullable: true),
                    PointId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssemblyUnitSealingJournals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssemblyUnitSealingJournals_AssemblyUnitSeals_DetailId",
                        column: x => x.DetailId,
                        principalTable: "AssemblyUnitSeals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_AssemblyUnitSealingJournals_Inspectors_InspectorId",
                        column: x => x.InspectorId,
                        principalTable: "Inspectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_AssemblyUnitSealingJournals_BaseTCP_PointId",
                        column: x => x.PointId,
                        principalTable: "BaseTCP",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
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
                    RemarkIssued = table.Column<string>(nullable: true),
                    RemarkClosed = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
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
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_CaseBottomJournals_Inspectors_InspectorId",
                        column: x => x.InspectorId,
                        principalTable: "Inspectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_CaseBottomJournals_BaseTCP_PointId",
                        column: x => x.PointId,
                        principalTable: "BaseTCP",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
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
                    RemarkIssued = table.Column<string>(nullable: true),
                    RemarkClosed = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
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
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_CaseFlangeJournals_Inspectors_InspectorId",
                        column: x => x.InspectorId,
                        principalTable: "Inspectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_CaseFlangeJournals_BaseTCP_PointId",
                        column: x => x.PointId,
                        principalTable: "BaseTCP",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
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
                    RemarkIssued = table.Column<string>(nullable: true),
                    RemarkClosed = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
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
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_CastGateValveCaseJournals_Inspectors_InspectorId",
                        column: x => x.InspectorId,
                        principalTable: "Inspectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_CastGateValveCaseJournals_BaseTCP_PointId",
                        column: x => x.PointId,
                        principalTable: "BaseTCP",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
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
                    RemarkIssued = table.Column<string>(nullable: true),
                    RemarkClosed = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
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
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_CoverFlangeJournals_Inspectors_InspectorId",
                        column: x => x.InspectorId,
                        principalTable: "Inspectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_CoverFlangeJournals_BaseTCP_PointId",
                        column: x => x.PointId,
                        principalTable: "BaseTCP",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
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
                    RemarkIssued = table.Column<string>(nullable: true),
                    RemarkClosed = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
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
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_CoverSealingRingJournals_Inspectors_InspectorId",
                        column: x => x.InspectorId,
                        principalTable: "Inspectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_CoverSealingRingJournals_BaseTCP_PointId",
                        column: x => x.PointId,
                        principalTable: "BaseTCP",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "ForgingMaterialJournals",
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
                    RemarkIssued = table.Column<string>(nullable: true),
                    RemarkClosed = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    InspectorId = table.Column<int>(nullable: true),
                    DetailId = table.Column<int>(nullable: true),
                    PointId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForgingMaterialJournals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ForgingMaterialJournals_MetalMaterials_DetailId",
                        column: x => x.DetailId,
                        principalTable: "MetalMaterials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_ForgingMaterialJournals_Inspectors_InspectorId",
                        column: x => x.InspectorId,
                        principalTable: "Inspectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_ForgingMaterialJournals_BaseTCP_PointId",
                        column: x => x.PointId,
                        principalTable: "BaseTCP",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "FrontalSaddleSealingJournals",
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
                    RemarkIssued = table.Column<string>(nullable: true),
                    RemarkClosed = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    InspectorId = table.Column<int>(nullable: true),
                    DetailId = table.Column<int>(nullable: true),
                    PointId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FrontalSaddleSealingJournals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FrontalSaddleSealingJournals_FrontalSaddleSeals_DetailId",
                        column: x => x.DetailId,
                        principalTable: "FrontalSaddleSeals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_FrontalSaddleSealingJournals_Inspectors_InspectorId",
                        column: x => x.InspectorId,
                        principalTable: "Inspectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_FrontalSaddleSealingJournals_BaseTCP_PointId",
                        column: x => x.PointId,
                        principalTable: "BaseTCP",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
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
                    RemarkIssued = table.Column<string>(nullable: true),
                    RemarkClosed = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
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
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_GateJournals_Inspectors_InspectorId",
                        column: x => x.InspectorId,
                        principalTable: "Inspectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_GateJournals_BaseTCP_PointId",
                        column: x => x.PointId,
                        principalTable: "BaseTCP",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
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
                    RemarkIssued = table.Column<string>(nullable: true),
                    RemarkClosed = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
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
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_NozzleJournals_Inspectors_InspectorId",
                        column: x => x.InspectorId,
                        principalTable: "Inspectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_NozzleJournals_BaseTCP_PointId",
                        column: x => x.PointId,
                        principalTable: "BaseTCP",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "PipeMaterialJournals",
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
                    RemarkIssued = table.Column<string>(nullable: true),
                    RemarkClosed = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    InspectorId = table.Column<int>(nullable: true),
                    DetailId = table.Column<int>(nullable: true),
                    PointId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PipeMaterialJournals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PipeMaterialJournals_MetalMaterials_DetailId",
                        column: x => x.DetailId,
                        principalTable: "MetalMaterials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_PipeMaterialJournals_Inspectors_InspectorId",
                        column: x => x.InspectorId,
                        principalTable: "Inspectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_PipeMaterialJournals_BaseTCP_PointId",
                        column: x => x.PointId,
                        principalTable: "BaseTCP",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
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
                    RemarkIssued = table.Column<string>(nullable: true),
                    RemarkClosed = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
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
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_ReverseShutterCaseJournals_Inspectors_InspectorId",
                        column: x => x.InspectorId,
                        principalTable: "Inspectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_ReverseShutterCaseJournals_BaseTCP_PointId",
                        column: x => x.PointId,
                        principalTable: "BaseTCP",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "RolledMaterialJournals",
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
                    RemarkIssued = table.Column<string>(nullable: true),
                    RemarkClosed = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    InspectorId = table.Column<int>(nullable: true),
                    DetailId = table.Column<int>(nullable: true),
                    PointId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolledMaterialJournals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RolledMaterialJournals_MetalMaterials_DetailId",
                        column: x => x.DetailId,
                        principalTable: "MetalMaterials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_RolledMaterialJournals_Inspectors_InspectorId",
                        column: x => x.InspectorId,
                        principalTable: "Inspectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_RolledMaterialJournals_BaseTCP_PointId",
                        column: x => x.PointId,
                        principalTable: "BaseTCP",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
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
                    RemarkIssued = table.Column<string>(nullable: true),
                    RemarkClosed = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
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
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_RunningSleeveJournals_Inspectors_InspectorId",
                        column: x => x.InspectorId,
                        principalTable: "Inspectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_RunningSleeveJournals_BaseTCP_PointId",
                        column: x => x.PointId,
                        principalTable: "BaseTCP",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "ScrewNutJournals",
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
                    RemarkIssued = table.Column<string>(nullable: true),
                    RemarkClosed = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    InspectorId = table.Column<int>(nullable: true),
                    DetailId = table.Column<int>(nullable: true),
                    PointId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScrewNutJournals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScrewNutJournals_ScrewNuts_DetailId",
                        column: x => x.DetailId,
                        principalTable: "ScrewNuts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_ScrewNutJournals_Inspectors_InspectorId",
                        column: x => x.InspectorId,
                        principalTable: "Inspectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_ScrewNutJournals_BaseTCP_PointId",
                        column: x => x.PointId,
                        principalTable: "BaseTCP",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "ScrewStudJournals",
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
                    RemarkIssued = table.Column<string>(nullable: true),
                    RemarkClosed = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    InspectorId = table.Column<int>(nullable: true),
                    DetailId = table.Column<int>(nullable: true),
                    PointId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScrewStudJournals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScrewStudJournals_ScrewStuds_DetailId",
                        column: x => x.DetailId,
                        principalTable: "ScrewStuds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_ScrewStudJournals_Inspectors_InspectorId",
                        column: x => x.InspectorId,
                        principalTable: "Inspectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_ScrewStudJournals_BaseTCP_PointId",
                        column: x => x.PointId,
                        principalTable: "BaseTCP",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
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
                    RemarkIssued = table.Column<string>(nullable: true),
                    RemarkClosed = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
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
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_ShaftShutterJournals_Inspectors_InspectorId",
                        column: x => x.InspectorId,
                        principalTable: "Inspectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_ShaftShutterJournals_BaseTCP_PointId",
                        column: x => x.PointId,
                        principalTable: "BaseTCP",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "SheetMaterialJournals",
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
                    RemarkIssued = table.Column<string>(nullable: true),
                    RemarkClosed = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    InspectorId = table.Column<int>(nullable: true),
                    DetailId = table.Column<int>(nullable: true),
                    PointId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SheetMaterialJournals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SheetMaterialJournals_MetalMaterials_DetailId",
                        column: x => x.DetailId,
                        principalTable: "MetalMaterials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_SheetMaterialJournals_Inspectors_InspectorId",
                        column: x => x.InspectorId,
                        principalTable: "Inspectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_SheetMaterialJournals_BaseTCP_PointId",
                        column: x => x.PointId,
                        principalTable: "BaseTCP",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
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
                    RemarkIssued = table.Column<string>(nullable: true),
                    RemarkClosed = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
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
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_ShutterJournals_Inspectors_InspectorId",
                        column: x => x.InspectorId,
                        principalTable: "Inspectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_ShutterJournals_BaseTCP_PointId",
                        column: x => x.PointId,
                        principalTable: "BaseTCP",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
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
                    RemarkIssued = table.Column<string>(nullable: true),
                    RemarkClosed = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
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
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_SlamShutterJournals_Inspectors_InspectorId",
                        column: x => x.InspectorId,
                        principalTable: "Inspectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_SlamShutterJournals_BaseTCP_PointId",
                        column: x => x.PointId,
                        principalTable: "BaseTCP",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
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
                    RemarkIssued = table.Column<string>(nullable: true),
                    RemarkClosed = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
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
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_SpindleJournals_Inspectors_InspectorId",
                        column: x => x.InspectorId,
                        principalTable: "Inspectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_SpindleJournals_BaseTCP_PointId",
                        column: x => x.PointId,
                        principalTable: "BaseTCP",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "SpringJournals",
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
                    RemarkIssued = table.Column<string>(nullable: true),
                    RemarkClosed = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    InspectorId = table.Column<int>(nullable: true),
                    DetailId = table.Column<int>(nullable: true),
                    PointId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpringJournals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpringJournals_Springs_DetailId",
                        column: x => x.DetailId,
                        principalTable: "Springs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_SpringJournals_Inspectors_InspectorId",
                        column: x => x.InspectorId,
                        principalTable: "Inspectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_SpringJournals_BaseTCP_PointId",
                        column: x => x.PointId,
                        principalTable: "BaseTCP",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "UndercoatJournals",
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
                    RemarkIssued = table.Column<string>(nullable: true),
                    RemarkClosed = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    InspectorId = table.Column<int>(nullable: true),
                    DetailId = table.Column<int>(nullable: true),
                    PointId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UndercoatJournals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UndercoatJournals_BaseAnticorrosiveCoatings_DetailId",
                        column: x => x.DetailId,
                        principalTable: "BaseAnticorrosiveCoatings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_UndercoatJournals_Inspectors_InspectorId",
                        column: x => x.InspectorId,
                        principalTable: "Inspectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_UndercoatJournals_BaseTCP_PointId",
                        column: x => x.PointId,
                        principalTable: "BaseTCP",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "UndergroundCoatingJournals",
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
                    RemarkIssued = table.Column<string>(nullable: true),
                    RemarkClosed = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    InspectorId = table.Column<int>(nullable: true),
                    DetailId = table.Column<int>(nullable: true),
                    PointId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UndergroundCoatingJournals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UndergroundCoatingJournals_BaseAnticorrosiveCoatings_DetailId",
                        column: x => x.DetailId,
                        principalTable: "BaseAnticorrosiveCoatings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_UndergroundCoatingJournals_Inspectors_InspectorId",
                        column: x => x.InspectorId,
                        principalTable: "Inspectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_UndergroundCoatingJournals_BaseTCP_PointId",
                        column: x => x.PointId,
                        principalTable: "BaseTCP",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "WeldingMaterialJournals",
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
                    RemarkIssued = table.Column<string>(nullable: true),
                    RemarkClosed = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    InspectorId = table.Column<int>(nullable: true),
                    DetailId = table.Column<int>(nullable: true),
                    PointId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeldingMaterialJournals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeldingMaterialJournals_WeldingMaterials_DetailId",
                        column: x => x.DetailId,
                        principalTable: "WeldingMaterials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_WeldingMaterialJournals_Inspectors_InspectorId",
                        column: x => x.InspectorId,
                        principalTable: "Inspectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_WeldingMaterialJournals_BaseTCP_PointId",
                        column: x => x.PointId,
                        principalTable: "BaseTCP",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
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
                    RemarkIssued = table.Column<string>(nullable: true),
                    RemarkClosed = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
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
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_WeldNozzleJournals_Inspectors_InspectorId",
                        column: x => x.InspectorId,
                        principalTable: "Inspectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_WeldNozzleJournals_BaseTCP_PointId",
                        column: x => x.PointId,
                        principalTable: "BaseTCP",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
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
                    RemarkIssued = table.Column<string>(nullable: true),
                    RemarkClosed = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
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
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_ShutterDiskJournals_Inspectors_InspectorId",
                        column: x => x.InspectorId,
                        principalTable: "Inspectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_ShutterDiskJournals_BaseTCP_PointId",
                        column: x => x.PointId,
                        principalTable: "BaseTCP",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
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
                    RemarkIssued = table.Column<string>(nullable: true),
                    RemarkClosed = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
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
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_ShutterGuideJournals_Inspectors_InspectorId",
                        column: x => x.InspectorId,
                        principalTable: "Inspectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_ShutterGuideJournals_BaseTCP_PointId",
                        column: x => x.PointId,
                        principalTable: "BaseTCP",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "ReverseShutters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    Drawing = table.Column<string>(nullable: true),
                    Certificate = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    PIDId = table.Column<int>(nullable: true),
                    ReverseShutterCaseId = table.Column<int>(nullable: true),
                    ShaftShutterId = table.Column<int>(nullable: true),
                    SlamShutterId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReverseShutters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReverseShutters_PIDs_PIDId",
                        column: x => x.PIDId,
                        principalTable: "PIDs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_ReverseShutters_BaseCastingCase_ReverseShutterCaseId",
                        column: x => x.ReverseShutterCaseId,
                        principalTable: "BaseCastingCase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_ReverseShutters_ShaftShutters_ShaftShutterId",
                        column: x => x.ShaftShutterId,
                        principalTable: "ShaftShutters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_ReverseShutters_SlamShutters_SlamShutterId",
                        column: x => x.SlamShutterId,
                        principalTable: "SlamShutters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
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
                    RemarkIssued = table.Column<string>(nullable: true),
                    RemarkClosed = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
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
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_CompactGateValveCaseJournals_Inspectors_InspectorId",
                        column: x => x.InspectorId,
                        principalTable: "Inspectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_CompactGateValveCaseJournals_BaseTCP_PointId",
                        column: x => x.PointId,
                        principalTable: "BaseTCP",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "FrontWalls",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    Drawing = table.Column<string>(nullable: true),
                    Certificate = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    MetalMaterialId = table.Column<int>(nullable: true),
                    WeldGateValveCaseId = table.Column<int>(nullable: true),
                    WeldNozzleId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FrontWalls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FrontWalls_MetalMaterials_MetalMaterialId",
                        column: x => x.MetalMaterialId,
                        principalTable: "MetalMaterials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_FrontWalls_WeldGateValveCase_WeldGateValveCaseId",
                        column: x => x.WeldGateValveCaseId,
                        principalTable: "WeldGateValveCase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_FrontWalls_WeldNozzles_WeldNozzleId",
                        column: x => x.WeldNozzleId,
                        principalTable: "WeldNozzles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
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
                    RemarkIssued = table.Column<string>(nullable: true),
                    RemarkClosed = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
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
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_SheetGateValveCaseJournals_Inspectors_InspectorId",
                        column: x => x.InspectorId,
                        principalTable: "Inspectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_SheetGateValveCaseJournals_BaseTCP_PointId",
                        column: x => x.PointId,
                        principalTable: "BaseTCP",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "SideWalls",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    Drawing = table.Column<string>(nullable: true),
                    Certificate = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    MetalMaterialId = table.Column<int>(nullable: true),
                    WeldGateValveCaseId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SideWalls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SideWalls_MetalMaterials_MetalMaterialId",
                        column: x => x.MetalMaterialId,
                        principalTable: "MetalMaterials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_SideWalls_WeldGateValveCase_WeldGateValveCaseId",
                        column: x => x.WeldGateValveCaseId,
                        principalTable: "WeldGateValveCase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "BaseValveCover",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    Drawing = table.Column<string>(nullable: true),
                    Certificate = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    SpindleId = table.Column<int>(nullable: true),
                    RunningSleeveId = table.Column<int>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    Material = table.Column<string>(nullable: true),
                    Melt = table.Column<string>(nullable: true),
                    CoverSealingRingId = table.Column<int>(nullable: true),
                    CoverFlangeId = table.Column<int>(nullable: true),
                    CoverSleeveId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseValveCover", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaseValveCover_RunningSleeves_RunningSleeveId",
                        column: x => x.RunningSleeveId,
                        principalTable: "RunningSleeves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_BaseValveCover_Spindles_SpindleId",
                        column: x => x.SpindleId,
                        principalTable: "Spindles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_BaseValveCover_CoverSealingRings_CoverSealingRingId",
                        column: x => x.CoverSealingRingId,
                        principalTable: "CoverSealingRings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_BaseValveCover_CoverFlanges_CoverFlangeId",
                        column: x => x.CoverFlangeId,
                        principalTable: "CoverFlanges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_BaseValveCover_CoverSleeves_CoverSleeveId",
                        column: x => x.CoverSleeveId,
                        principalTable: "CoverSleeves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
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
                    RemarkIssued = table.Column<string>(nullable: true),
                    RemarkClosed = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
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
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_CoverSleeveJournals_Inspectors_InspectorId",
                        column: x => x.InspectorId,
                        principalTable: "Inspectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_CoverSleeveJournals_BaseTCP_PointId",
                        column: x => x.PointId,
                        principalTable: "BaseTCP",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "BronzeSleeveShutters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    Drawing = table.Column<string>(nullable: true),
                    Certificate = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    MetalMaterialId = table.Column<int>(nullable: true),
                    Material = table.Column<string>(nullable: true),
                    Melt = table.Column<string>(nullable: true),
                    ReverseShutterId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BronzeSleeveShutters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BronzeSleeveShutters_MetalMaterials_MetalMaterialId",
                        column: x => x.MetalMaterialId,
                        principalTable: "MetalMaterials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_BronzeSleeveShutters_ReverseShutters_ReverseShutterId",
                        column: x => x.ReverseShutterId,
                        principalTable: "ReverseShutters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
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
                    RemarkIssued = table.Column<string>(nullable: true),
                    RemarkClosed = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    InspectorId = table.Column<int>(nullable: true),
                    DetailId = table.Column<int>(nullable: true),
                    PointId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReverseShutterJournals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReverseShutterJournals_ReverseShutters_DetailId",
                        column: x => x.DetailId,
                        principalTable: "ReverseShutters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_ReverseShutterJournals_Inspectors_InspectorId",
                        column: x => x.InspectorId,
                        principalTable: "Inspectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_ReverseShutterJournals_BaseTCP_PointId",
                        column: x => x.PointId,
                        principalTable: "BaseTCP",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "ReverseShutterWithCoating",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ReverseShutterId = table.Column<int>(nullable: false),
                    BaseAnticorrosiveCoatingId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReverseShutterWithCoating", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReverseShutterWithCoating_BaseAnticorrosiveCoatings_BaseAnticorrosiveCoatingId",
                        column: x => x.BaseAnticorrosiveCoatingId,
                        principalTable: "BaseAnticorrosiveCoatings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReverseShutterWithCoating_ReverseShutters_ReverseShutterId",
                        column: x => x.ReverseShutterId,
                        principalTable: "ReverseShutters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SteelSleeveShutters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    Drawing = table.Column<string>(nullable: true),
                    Certificate = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    MetalMaterialId = table.Column<int>(nullable: true),
                    ReverseShutterId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SteelSleeveShutters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SteelSleeveShutters_MetalMaterials_MetalMaterialId",
                        column: x => x.MetalMaterialId,
                        principalTable: "MetalMaterials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_SteelSleeveShutters_ReverseShutters_ReverseShutterId",
                        column: x => x.ReverseShutterId,
                        principalTable: "ReverseShutters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "StubShutters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    Drawing = table.Column<string>(nullable: true),
                    Certificate = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    MetalMaterialId = table.Column<int>(nullable: true),
                    ReverseShutterId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StubShutters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StubShutters_MetalMaterials_MetalMaterialId",
                        column: x => x.MetalMaterialId,
                        principalTable: "MetalMaterials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_StubShutters_ReverseShutters_ReverseShutterId",
                        column: x => x.ReverseShutterId,
                        principalTable: "ReverseShutters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
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
                    RemarkIssued = table.Column<string>(nullable: true),
                    RemarkClosed = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
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
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_FrontWallJournals_Inspectors_InspectorId",
                        column: x => x.InspectorId,
                        principalTable: "Inspectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_FrontWallJournals_BaseTCP_PointId",
                        column: x => x.PointId,
                        principalTable: "BaseTCP",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
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
                    RemarkIssued = table.Column<string>(nullable: true),
                    RemarkClosed = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
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
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_SideWallJournals_Inspectors_InspectorId",
                        column: x => x.InspectorId,
                        principalTable: "Inspectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_SideWallJournals_BaseTCP_PointId",
                        column: x => x.PointId,
                        principalTable: "BaseTCP",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "BaseValve",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    Drawing = table.Column<string>(nullable: true),
                    Certificate = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
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
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_BaseValve_PIDs_PIDId",
                        column: x => x.PIDId,
                        principalTable: "PIDs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_BaseValve_Shutters_ShutterId",
                        column: x => x.ShutterId,
                        principalTable: "Shutters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_BaseValve_WeldGateValveCase_WeldGateValveCaseId",
                        column: x => x.WeldGateValveCaseId,
                        principalTable: "WeldGateValveCase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_BaseValve_BaseValveCover_WeldGateValveCoverId",
                        column: x => x.WeldGateValveCoverId,
                        principalTable: "BaseValveCover",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_BaseValve_BaseCastingCase_CastGateValveCaseId",
                        column: x => x.CastGateValveCaseId,
                        principalTable: "BaseCastingCase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_BaseValve_BaseValveCover_CastGateValveCoverId",
                        column: x => x.CastGateValveCoverId,
                        principalTable: "BaseValveCover",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
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
                    RemarkIssued = table.Column<string>(nullable: true),
                    RemarkClosed = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    InspectorId = table.Column<int>(nullable: true),
                    DetailId = table.Column<int>(nullable: true),
                    PointId = table.Column<int>(nullable: true),
                    CastGateValveCoverTCPId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CastGateValveCoverJournals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CastGateValveCoverJournals_BaseTCP_CastGateValveCoverTCPId",
                        column: x => x.CastGateValveCoverTCPId,
                        principalTable: "BaseTCP",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_CastGateValveCoverJournals_BaseValveCover_DetailId",
                        column: x => x.DetailId,
                        principalTable: "BaseValveCover",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_CastGateValveCoverJournals_Inspectors_InspectorId",
                        column: x => x.InspectorId,
                        principalTable: "Inspectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_CastGateValveCoverJournals_BaseTCP_PointId",
                        column: x => x.PointId,
                        principalTable: "BaseTCP",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
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
                    RemarkIssued = table.Column<string>(nullable: true),
                    RemarkClosed = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    InspectorId = table.Column<int>(nullable: true),
                    DetailId = table.Column<int>(nullable: true),
                    PointId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompactGateValveCoverJournals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompactGateValveCoverJournals_BaseValveCover_DetailId",
                        column: x => x.DetailId,
                        principalTable: "BaseValveCover",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_CompactGateValveCoverJournals_Inspectors_InspectorId",
                        column: x => x.InspectorId,
                        principalTable: "Inspectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_CompactGateValveCoverJournals_BaseTCP_PointId",
                        column: x => x.PointId,
                        principalTable: "BaseTCP",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
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
                    RemarkIssued = table.Column<string>(nullable: true),
                    RemarkClosed = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    InspectorId = table.Column<int>(nullable: true),
                    DetailId = table.Column<int>(nullable: true),
                    PointId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SheetGateValveCoverJournals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SheetGateValveCoverJournals_BaseValveCover_DetailId",
                        column: x => x.DetailId,
                        principalTable: "BaseValveCover",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_SheetGateValveCoverJournals_Inspectors_InspectorId",
                        column: x => x.InspectorId,
                        principalTable: "Inspectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_SheetGateValveCoverJournals_BaseTCP_PointId",
                        column: x => x.PointId,
                        principalTable: "BaseTCP",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
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
                    RemarkIssued = table.Column<string>(nullable: true),
                    RemarkClosed = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
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
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_BronzeSleeveShutterJournals_Inspectors_InspectorId",
                        column: x => x.InspectorId,
                        principalTable: "Inspectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_BronzeSleeveShutterJournals_BaseTCP_PointId",
                        column: x => x.PointId,
                        principalTable: "BaseTCP",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
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
                    RemarkIssued = table.Column<string>(nullable: true),
                    RemarkClosed = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
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
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_SteelSleeveShutterJournals_Inspectors_InspectorId",
                        column: x => x.InspectorId,
                        principalTable: "Inspectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_SteelSleeveShutterJournals_BaseTCP_PointId",
                        column: x => x.PointId,
                        principalTable: "BaseTCP",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
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
                    RemarkIssued = table.Column<string>(nullable: true),
                    RemarkClosed = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
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
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_StubShutterJournals_Inspectors_InspectorId",
                        column: x => x.InspectorId,
                        principalTable: "Inspectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_StubShutterJournals_BaseTCP_PointId",
                        column: x => x.PointId,
                        principalTable: "BaseTCP",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "BallValves",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    Drawing = table.Column<string>(nullable: true),
                    Certificate = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    Material = table.Column<string>(nullable: true),
                    Diameter = table.Column<string>(nullable: true),
                    Pressure = table.Column<string>(nullable: true),
                    Designation = table.Column<string>(nullable: true),
                    BaseValveId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BallValves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BallValves_BaseValve_BaseValveId",
                        column: x => x.BaseValveId,
                        principalTable: "BaseValve",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "BaseValveWithCoating",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BaseValveId = table.Column<int>(nullable: false),
                    BaseAnticorrosiveCoatingId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseValveWithCoating", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaseValveWithCoating_BaseAnticorrosiveCoatings_BaseAnticorrosiveCoatingId",
                        column: x => x.BaseAnticorrosiveCoatingId,
                        principalTable: "BaseAnticorrosiveCoatings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BaseValveWithCoating_BaseValve_BaseValveId",
                        column: x => x.BaseValveId,
                        principalTable: "BaseValve",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BaseValveWithScrewNuts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BaseValveId = table.Column<int>(nullable: false),
                    ScrewNutId = table.Column<int>(nullable: false),
                    ScrewNutAmount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseValveWithScrewNuts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaseValveWithScrewNuts_BaseValve_BaseValveId",
                        column: x => x.BaseValveId,
                        principalTable: "BaseValve",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BaseValveWithScrewNuts_ScrewNuts_ScrewNutId",
                        column: x => x.ScrewNutId,
                        principalTable: "ScrewNuts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BaseValveWithScrewStuds",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BaseValveId = table.Column<int>(nullable: false),
                    ScrewStudId = table.Column<int>(nullable: false),
                    ScrewStudAmount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseValveWithScrewStuds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaseValveWithScrewStuds_BaseValve_BaseValveId",
                        column: x => x.BaseValveId,
                        principalTable: "BaseValve",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BaseValveWithScrewStuds_ScrewStuds_ScrewStudId",
                        column: x => x.ScrewStudId,
                        principalTable: "ScrewStuds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BaseValveWithSeals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BaseValveId = table.Column<int>(nullable: false),
                    AssemblyUnitSealingId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseValveWithSeals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaseValveWithSeals_AssemblyUnitSeals_AssemblyUnitSealingId",
                        column: x => x.AssemblyUnitSealingId,
                        principalTable: "AssemblyUnitSeals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BaseValveWithSeals_BaseValve_BaseValveId",
                        column: x => x.BaseValveId,
                        principalTable: "BaseValve",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BaseValveWithSprings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BaseValveId = table.Column<int>(nullable: false),
                    SpringId = table.Column<int>(nullable: false),
                    SpringAmount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseValveWithSprings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaseValveWithSprings_BaseValve_BaseValveId",
                        column: x => x.BaseValveId,
                        principalTable: "BaseValve",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BaseValveWithSprings_Springs_SpringId",
                        column: x => x.SpringId,
                        principalTable: "Springs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    RemarkIssued = table.Column<string>(nullable: true),
                    RemarkClosed = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
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
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_CastGateValveJournals_Inspectors_InspectorId",
                        column: x => x.InspectorId,
                        principalTable: "Inspectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_CastGateValveJournals_BaseTCP_PointId",
                        column: x => x.PointId,
                        principalTable: "BaseTCP",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
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
                    RemarkIssued = table.Column<string>(nullable: true),
                    RemarkClosed = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
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
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_CompactGateValveJournals_Inspectors_InspectorId",
                        column: x => x.InspectorId,
                        principalTable: "Inspectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_CompactGateValveJournals_BaseTCP_PointId",
                        column: x => x.PointId,
                        principalTable: "BaseTCP",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "CounterFlanges",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    Drawing = table.Column<string>(nullable: true),
                    Certificate = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    MetalMaterialId = table.Column<int>(nullable: true),
                    BaseValveId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CounterFlanges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CounterFlanges_BaseValve_BaseValveId",
                        column: x => x.BaseValveId,
                        principalTable: "BaseValve",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_CounterFlanges_MetalMaterials_MetalMaterialId",
                        column: x => x.MetalMaterialId,
                        principalTable: "MetalMaterials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Saddles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    Drawing = table.Column<string>(nullable: true),
                    Certificate = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    MetalMaterialId = table.Column<int>(nullable: true),
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
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Saddles_MetalMaterials_MetalMaterialId",
                        column: x => x.MetalMaterialId,
                        principalTable: "MetalMaterials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "ShearPins",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    Drawing = table.Column<string>(nullable: true),
                    Certificate = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    Material = table.Column<string>(nullable: true),
                    Melt = table.Column<string>(nullable: true),
                    BaseValveId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShearPins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShearPins_BaseValve_BaseValveId",
                        column: x => x.BaseValveId,
                        principalTable: "BaseValve",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
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
                    RemarkIssued = table.Column<string>(nullable: true),
                    RemarkClosed = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
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
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_SheetGateValveJournals_Inspectors_InspectorId",
                        column: x => x.InspectorId,
                        principalTable: "Inspectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_SheetGateValveJournals_BaseTCP_PointId",
                        column: x => x.PointId,
                        principalTable: "BaseTCP",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "BallValveJournals",
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
                    RemarkIssued = table.Column<string>(nullable: true),
                    RemarkClosed = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    InspectorId = table.Column<int>(nullable: true),
                    DetailId = table.Column<int>(nullable: true),
                    PointId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BallValveJournals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BallValveJournals_BallValves_DetailId",
                        column: x => x.DetailId,
                        principalTable: "BallValves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_BallValveJournals_Inspectors_InspectorId",
                        column: x => x.InspectorId,
                        principalTable: "Inspectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_BallValveJournals_BaseTCP_PointId",
                        column: x => x.PointId,
                        principalTable: "BaseTCP",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "CounterFlangeJournals",
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
                    RemarkIssued = table.Column<string>(nullable: true),
                    RemarkClosed = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    InspectorId = table.Column<int>(nullable: true),
                    DetailId = table.Column<int>(nullable: true),
                    PointId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CounterFlangeJournals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CounterFlangeJournals_CounterFlanges_DetailId",
                        column: x => x.DetailId,
                        principalTable: "CounterFlanges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_CounterFlangeJournals_Inspectors_InspectorId",
                        column: x => x.InspectorId,
                        principalTable: "Inspectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_CounterFlangeJournals_BaseTCP_PointId",
                        column: x => x.PointId,
                        principalTable: "BaseTCP",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
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
                    RemarkIssued = table.Column<string>(nullable: true),
                    RemarkClosed = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
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
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_SaddleJournals_Inspectors_InspectorId",
                        column: x => x.InspectorId,
                        principalTable: "Inspectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_SaddleJournals_BaseTCP_PointId",
                        column: x => x.PointId,
                        principalTable: "BaseTCP",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "SaddleWithSeals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SaddleId = table.Column<int>(nullable: false),
                    FrontalSaddleSealingId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaddleWithSeals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SaddleWithSeals_FrontalSaddleSeals_FrontalSaddleSealingId",
                        column: x => x.FrontalSaddleSealingId,
                        principalTable: "FrontalSaddleSeals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SaddleWithSeals_Saddles_SaddleId",
                        column: x => x.SaddleId,
                        principalTable: "Saddles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShearPinJournals",
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
                    RemarkIssued = table.Column<string>(nullable: true),
                    RemarkClosed = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    InspectorId = table.Column<int>(nullable: true),
                    DetailId = table.Column<int>(nullable: true),
                    PointId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShearPinJournals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShearPinJournals_ShearPins_DetailId",
                        column: x => x.DetailId,
                        principalTable: "ShearPins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_ShearPinJournals_Inspectors_InspectorId",
                        column: x => x.InspectorId,
                        principalTable: "Inspectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_ShearPinJournals_BaseTCP_PointId",
                        column: x => x.PointId,
                        principalTable: "BaseTCP",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.InsertData(
                table: "OperationTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Входной контроль" });

            migrationBuilder.InsertData(
                table: "OperationTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Механическая обработка" });

            migrationBuilder.InsertData(
                table: "OperationTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "НК" });

            migrationBuilder.CreateIndex(
                name: "IX_AbovegroundCoatingJournals_DetailId",
                table: "AbovegroundCoatingJournals",
                column: "DetailId");

            migrationBuilder.CreateIndex(
                name: "IX_AbovegroundCoatingJournals_InspectorId",
                table: "AbovegroundCoatingJournals",
                column: "InspectorId");

            migrationBuilder.CreateIndex(
                name: "IX_AbovegroundCoatingJournals_PointId",
                table: "AbovegroundCoatingJournals",
                column: "PointId");

            migrationBuilder.CreateIndex(
                name: "IX_AbrasiveMaterialJournals_DetailId",
                table: "AbrasiveMaterialJournals",
                column: "DetailId");

            migrationBuilder.CreateIndex(
                name: "IX_AbrasiveMaterialJournals_InspectorId",
                table: "AbrasiveMaterialJournals",
                column: "InspectorId");

            migrationBuilder.CreateIndex(
                name: "IX_AbrasiveMaterialJournals_PointId",
                table: "AbrasiveMaterialJournals",
                column: "PointId");

            migrationBuilder.CreateIndex(
                name: "IX_AssemblyUnitSealingJournals_DetailId",
                table: "AssemblyUnitSealingJournals",
                column: "DetailId");

            migrationBuilder.CreateIndex(
                name: "IX_AssemblyUnitSealingJournals_InspectorId",
                table: "AssemblyUnitSealingJournals",
                column: "InspectorId");

            migrationBuilder.CreateIndex(
                name: "IX_AssemblyUnitSealingJournals_PointId",
                table: "AssemblyUnitSealingJournals",
                column: "PointId");

            migrationBuilder.CreateIndex(
                name: "IX_BallValveJournals_DetailId",
                table: "BallValveJournals",
                column: "DetailId");

            migrationBuilder.CreateIndex(
                name: "IX_BallValveJournals_InspectorId",
                table: "BallValveJournals",
                column: "InspectorId");

            migrationBuilder.CreateIndex(
                name: "IX_BallValveJournals_PointId",
                table: "BallValveJournals",
                column: "PointId");

            migrationBuilder.CreateIndex(
                name: "IX_BallValves_BaseValveId",
                table: "BallValves",
                column: "BaseValveId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseTCP_OperationNameId",
                table: "BaseTCP",
                column: "OperationNameId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseTCP_ProductTypeId",
                table: "BaseTCP",
                column: "ProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseValve_GateId",
                table: "BaseValve",
                column: "GateId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BaseValve_PIDId",
                table: "BaseValve",
                column: "PIDId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseValve_ShutterId",
                table: "BaseValve",
                column: "ShutterId",
                unique: true);

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
                name: "IX_BaseValveCover_CoverFlangeId",
                table: "BaseValveCover",
                column: "CoverFlangeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BaseValveCover_CoverSleeveId",
                table: "BaseValveCover",
                column: "CoverSleeveId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BaseValveWithCoating_BaseAnticorrosiveCoatingId",
                table: "BaseValveWithCoating",
                column: "BaseAnticorrosiveCoatingId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseValveWithCoating_BaseValveId",
                table: "BaseValveWithCoating",
                column: "BaseValveId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseValveWithScrewNuts_BaseValveId",
                table: "BaseValveWithScrewNuts",
                column: "BaseValveId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseValveWithScrewNuts_ScrewNutId",
                table: "BaseValveWithScrewNuts",
                column: "ScrewNutId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseValveWithScrewStuds_BaseValveId",
                table: "BaseValveWithScrewStuds",
                column: "BaseValveId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseValveWithScrewStuds_ScrewStudId",
                table: "BaseValveWithScrewStuds",
                column: "ScrewStudId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseValveWithSeals_AssemblyUnitSealingId",
                table: "BaseValveWithSeals",
                column: "AssemblyUnitSealingId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseValveWithSeals_BaseValveId",
                table: "BaseValveWithSeals",
                column: "BaseValveId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseValveWithSprings_BaseValveId",
                table: "BaseValveWithSprings",
                column: "BaseValveId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseValveWithSprings_SpringId",
                table: "BaseValveWithSprings",
                column: "SpringId");

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
                name: "IX_BronzeSleeveShutters_MetalMaterialId",
                table: "BronzeSleeveShutters",
                column: "MetalMaterialId");

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
                name: "IX_CaseBottoms_MetalMaterialId",
                table: "CaseBottoms",
                column: "MetalMaterialId");

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
                name: "IX_CaseFlanges_MetalMaterialId",
                table: "CaseFlanges",
                column: "MetalMaterialId");

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
                name: "IX_CounterFlangeJournals_DetailId",
                table: "CounterFlangeJournals",
                column: "DetailId");

            migrationBuilder.CreateIndex(
                name: "IX_CounterFlangeJournals_InspectorId",
                table: "CounterFlangeJournals",
                column: "InspectorId");

            migrationBuilder.CreateIndex(
                name: "IX_CounterFlangeJournals_PointId",
                table: "CounterFlangeJournals",
                column: "PointId");

            migrationBuilder.CreateIndex(
                name: "IX_CounterFlanges_BaseValveId",
                table: "CounterFlanges",
                column: "BaseValveId");

            migrationBuilder.CreateIndex(
                name: "IX_CounterFlanges_MetalMaterialId",
                table: "CounterFlanges",
                column: "MetalMaterialId");

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
                name: "IX_CoverFlanges_MetalMaterialId",
                table: "CoverFlanges",
                column: "MetalMaterialId");

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
                name: "IX_CoverSealingRings_MetalMaterialId",
                table: "CoverSealingRings",
                column: "MetalMaterialId");

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
                name: "IX_CoverSleeves_MetalMaterialId",
                table: "CoverSleeves",
                column: "MetalMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_ForgingMaterialJournals_DetailId",
                table: "ForgingMaterialJournals",
                column: "DetailId");

            migrationBuilder.CreateIndex(
                name: "IX_ForgingMaterialJournals_InspectorId",
                table: "ForgingMaterialJournals",
                column: "InspectorId");

            migrationBuilder.CreateIndex(
                name: "IX_ForgingMaterialJournals_PointId",
                table: "ForgingMaterialJournals",
                column: "PointId");

            migrationBuilder.CreateIndex(
                name: "IX_FrontalSaddleSealingJournals_DetailId",
                table: "FrontalSaddleSealingJournals",
                column: "DetailId");

            migrationBuilder.CreateIndex(
                name: "IX_FrontalSaddleSealingJournals_InspectorId",
                table: "FrontalSaddleSealingJournals",
                column: "InspectorId");

            migrationBuilder.CreateIndex(
                name: "IX_FrontalSaddleSealingJournals_PointId",
                table: "FrontalSaddleSealingJournals",
                column: "PointId");

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
                name: "IX_FrontWalls_MetalMaterialId",
                table: "FrontWalls",
                column: "MetalMaterialId");

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
                name: "IX_Gates_MetalMaterialId",
                table: "Gates",
                column: "MetalMaterialId");

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
                name: "IX_Nozzles_MetalMaterialId",
                table: "Nozzles",
                column: "MetalMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_PIDs_ProductTypeId",
                table: "PIDs",
                column: "ProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PIDs_SpecificationId",
                table: "PIDs",
                column: "SpecificationId");

            migrationBuilder.CreateIndex(
                name: "IX_PipeMaterialJournals_DetailId",
                table: "PipeMaterialJournals",
                column: "DetailId");

            migrationBuilder.CreateIndex(
                name: "IX_PipeMaterialJournals_InspectorId",
                table: "PipeMaterialJournals",
                column: "InspectorId");

            migrationBuilder.CreateIndex(
                name: "IX_PipeMaterialJournals_PointId",
                table: "PipeMaterialJournals",
                column: "PointId");

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
                name: "IX_ReverseShutters_PIDId",
                table: "ReverseShutters",
                column: "PIDId");

            migrationBuilder.CreateIndex(
                name: "IX_ReverseShutters_ReverseShutterCaseId",
                table: "ReverseShutters",
                column: "ReverseShutterCaseId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReverseShutters_ShaftShutterId",
                table: "ReverseShutters",
                column: "ShaftShutterId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReverseShutters_SlamShutterId",
                table: "ReverseShutters",
                column: "SlamShutterId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReverseShutterWithCoating_BaseAnticorrosiveCoatingId",
                table: "ReverseShutterWithCoating",
                column: "BaseAnticorrosiveCoatingId");

            migrationBuilder.CreateIndex(
                name: "IX_ReverseShutterWithCoating_ReverseShutterId",
                table: "ReverseShutterWithCoating",
                column: "ReverseShutterId");

            migrationBuilder.CreateIndex(
                name: "IX_RolledMaterialJournals_DetailId",
                table: "RolledMaterialJournals",
                column: "DetailId");

            migrationBuilder.CreateIndex(
                name: "IX_RolledMaterialJournals_InspectorId",
                table: "RolledMaterialJournals",
                column: "InspectorId");

            migrationBuilder.CreateIndex(
                name: "IX_RolledMaterialJournals_PointId",
                table: "RolledMaterialJournals",
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
                name: "IX_Saddles_MetalMaterialId",
                table: "Saddles",
                column: "MetalMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_SaddleWithSeals_FrontalSaddleSealingId",
                table: "SaddleWithSeals",
                column: "FrontalSaddleSealingId");

            migrationBuilder.CreateIndex(
                name: "IX_SaddleWithSeals_SaddleId",
                table: "SaddleWithSeals",
                column: "SaddleId");

            migrationBuilder.CreateIndex(
                name: "IX_ScrewNutJournals_DetailId",
                table: "ScrewNutJournals",
                column: "DetailId");

            migrationBuilder.CreateIndex(
                name: "IX_ScrewNutJournals_InspectorId",
                table: "ScrewNutJournals",
                column: "InspectorId");

            migrationBuilder.CreateIndex(
                name: "IX_ScrewNutJournals_PointId",
                table: "ScrewNutJournals",
                column: "PointId");

            migrationBuilder.CreateIndex(
                name: "IX_ScrewStudJournals_DetailId",
                table: "ScrewStudJournals",
                column: "DetailId");

            migrationBuilder.CreateIndex(
                name: "IX_ScrewStudJournals_InspectorId",
                table: "ScrewStudJournals",
                column: "InspectorId");

            migrationBuilder.CreateIndex(
                name: "IX_ScrewStudJournals_PointId",
                table: "ScrewStudJournals",
                column: "PointId");

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
                name: "IX_ShaftShutters_MetalMaterialId",
                table: "ShaftShutters",
                column: "MetalMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_ShearPinJournals_DetailId",
                table: "ShearPinJournals",
                column: "DetailId");

            migrationBuilder.CreateIndex(
                name: "IX_ShearPinJournals_InspectorId",
                table: "ShearPinJournals",
                column: "InspectorId");

            migrationBuilder.CreateIndex(
                name: "IX_ShearPinJournals_PointId",
                table: "ShearPinJournals",
                column: "PointId");

            migrationBuilder.CreateIndex(
                name: "IX_ShearPins_BaseValveId",
                table: "ShearPins",
                column: "BaseValveId");

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
                name: "IX_SheetMaterialJournals_DetailId",
                table: "SheetMaterialJournals",
                column: "DetailId");

            migrationBuilder.CreateIndex(
                name: "IX_SheetMaterialJournals_InspectorId",
                table: "SheetMaterialJournals",
                column: "InspectorId");

            migrationBuilder.CreateIndex(
                name: "IX_SheetMaterialJournals_PointId",
                table: "SheetMaterialJournals",
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
                name: "IX_ShutterDisks_MetalMaterialId",
                table: "ShutterDisks",
                column: "MetalMaterialId");

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
                name: "IX_ShutterGuides_MetalMaterialId",
                table: "ShutterGuides",
                column: "MetalMaterialId");

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
                name: "IX_SideWalls_MetalMaterialId",
                table: "SideWalls",
                column: "MetalMaterialId");

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
                name: "IX_Spindles_MetalMaterialId",
                table: "Spindles",
                column: "MetalMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_SpringJournals_DetailId",
                table: "SpringJournals",
                column: "DetailId");

            migrationBuilder.CreateIndex(
                name: "IX_SpringJournals_InspectorId",
                table: "SpringJournals",
                column: "InspectorId");

            migrationBuilder.CreateIndex(
                name: "IX_SpringJournals_PointId",
                table: "SpringJournals",
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
                name: "IX_SteelSleeveShutters_MetalMaterialId",
                table: "SteelSleeveShutters",
                column: "MetalMaterialId");

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
                name: "IX_StubShutters_MetalMaterialId",
                table: "StubShutters",
                column: "MetalMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_StubShutters_ReverseShutterId",
                table: "StubShutters",
                column: "ReverseShutterId");

            migrationBuilder.CreateIndex(
                name: "IX_UndercoatJournals_DetailId",
                table: "UndercoatJournals",
                column: "DetailId");

            migrationBuilder.CreateIndex(
                name: "IX_UndercoatJournals_InspectorId",
                table: "UndercoatJournals",
                column: "InspectorId");

            migrationBuilder.CreateIndex(
                name: "IX_UndercoatJournals_PointId",
                table: "UndercoatJournals",
                column: "PointId");

            migrationBuilder.CreateIndex(
                name: "IX_UndergroundCoatingJournals_DetailId",
                table: "UndergroundCoatingJournals",
                column: "DetailId");

            migrationBuilder.CreateIndex(
                name: "IX_UndergroundCoatingJournals_InspectorId",
                table: "UndergroundCoatingJournals",
                column: "InspectorId");

            migrationBuilder.CreateIndex(
                name: "IX_UndergroundCoatingJournals_PointId",
                table: "UndergroundCoatingJournals",
                column: "PointId");

            migrationBuilder.CreateIndex(
                name: "IX_WeldGateValveCase_CaseBottomId",
                table: "WeldGateValveCase",
                column: "CaseBottomId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WeldGateValveCase_CaseFlangeId",
                table: "WeldGateValveCase",
                column: "CaseFlangeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WeldingMaterialJournals_DetailId",
                table: "WeldingMaterialJournals",
                column: "DetailId");

            migrationBuilder.CreateIndex(
                name: "IX_WeldingMaterialJournals_InspectorId",
                table: "WeldingMaterialJournals",
                column: "InspectorId");

            migrationBuilder.CreateIndex(
                name: "IX_WeldingMaterialJournals_PointId",
                table: "WeldingMaterialJournals",
                column: "PointId");

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

            migrationBuilder.CreateIndex(
                name: "IX_WeldNozzles_MetalMaterialId",
                table: "WeldNozzles",
                column: "MetalMaterialId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AbovegroundCoatingJournals");

            migrationBuilder.DropTable(
                name: "AbrasiveMaterialJournals");

            migrationBuilder.DropTable(
                name: "AssemblyUnitSealingJournals");

            migrationBuilder.DropTable(
                name: "BallValveJournals");

            migrationBuilder.DropTable(
                name: "BaseValveWithCoating");

            migrationBuilder.DropTable(
                name: "BaseValveWithScrewNuts");

            migrationBuilder.DropTable(
                name: "BaseValveWithScrewStuds");

            migrationBuilder.DropTable(
                name: "BaseValveWithSeals");

            migrationBuilder.DropTable(
                name: "BaseValveWithSprings");

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
                name: "CounterFlangeJournals");

            migrationBuilder.DropTable(
                name: "CoverFlangeJournals");

            migrationBuilder.DropTable(
                name: "CoverSealingRingJournals");

            migrationBuilder.DropTable(
                name: "CoverSleeveJournals");

            migrationBuilder.DropTable(
                name: "ForgingMaterialJournals");

            migrationBuilder.DropTable(
                name: "FrontalSaddleSealingJournals");

            migrationBuilder.DropTable(
                name: "FrontWallJournals");

            migrationBuilder.DropTable(
                name: "GateJournals");

            migrationBuilder.DropTable(
                name: "JournalNumbers");

            migrationBuilder.DropTable(
                name: "NozzleJournals");

            migrationBuilder.DropTable(
                name: "PipeMaterialJournals");

            migrationBuilder.DropTable(
                name: "ReverseShutterCaseJournals");

            migrationBuilder.DropTable(
                name: "ReverseShutterJournals");

            migrationBuilder.DropTable(
                name: "ReverseShutterWithCoating");

            migrationBuilder.DropTable(
                name: "RolledMaterialJournals");

            migrationBuilder.DropTable(
                name: "RunningSleeveJournals");

            migrationBuilder.DropTable(
                name: "SaddleJournals");

            migrationBuilder.DropTable(
                name: "SaddleWithSeals");

            migrationBuilder.DropTable(
                name: "ScrewNutJournals");

            migrationBuilder.DropTable(
                name: "ScrewStudJournals");

            migrationBuilder.DropTable(
                name: "ShaftShutterJournals");

            migrationBuilder.DropTable(
                name: "ShearPinJournals");

            migrationBuilder.DropTable(
                name: "SheetGateValveCaseJournals");

            migrationBuilder.DropTable(
                name: "SheetGateValveCoverJournals");

            migrationBuilder.DropTable(
                name: "SheetGateValveJournals");

            migrationBuilder.DropTable(
                name: "SheetMaterialJournals");

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
                name: "SpringJournals");

            migrationBuilder.DropTable(
                name: "SteelSleeveShutterJournals");

            migrationBuilder.DropTable(
                name: "StubShutterJournals");

            migrationBuilder.DropTable(
                name: "UndercoatJournals");

            migrationBuilder.DropTable(
                name: "UndergroundCoatingJournals");

            migrationBuilder.DropTable(
                name: "WeldingMaterialJournals");

            migrationBuilder.DropTable(
                name: "WeldNozzleJournals");

            migrationBuilder.DropTable(
                name: "BallValves");

            migrationBuilder.DropTable(
                name: "AssemblyUnitSeals");

            migrationBuilder.DropTable(
                name: "BronzeSleeveShutters");

            migrationBuilder.DropTable(
                name: "CounterFlanges");

            migrationBuilder.DropTable(
                name: "FrontWalls");

            migrationBuilder.DropTable(
                name: "Nozzles");

            migrationBuilder.DropTable(
                name: "FrontalSaddleSeals");

            migrationBuilder.DropTable(
                name: "Saddles");

            migrationBuilder.DropTable(
                name: "ScrewNuts");

            migrationBuilder.DropTable(
                name: "ScrewStuds");

            migrationBuilder.DropTable(
                name: "ShearPins");

            migrationBuilder.DropTable(
                name: "ShutterDisks");

            migrationBuilder.DropTable(
                name: "ShutterGuides");

            migrationBuilder.DropTable(
                name: "SideWalls");

            migrationBuilder.DropTable(
                name: "Springs");

            migrationBuilder.DropTable(
                name: "SteelSleeveShutters");

            migrationBuilder.DropTable(
                name: "StubShutters");

            migrationBuilder.DropTable(
                name: "BaseAnticorrosiveCoatings");

            migrationBuilder.DropTable(
                name: "WeldingMaterials");

            migrationBuilder.DropTable(
                name: "Inspectors");

            migrationBuilder.DropTable(
                name: "BaseTCP");

            migrationBuilder.DropTable(
                name: "WeldNozzles");

            migrationBuilder.DropTable(
                name: "BaseValve");

            migrationBuilder.DropTable(
                name: "ReverseShutters");

            migrationBuilder.DropTable(
                name: "OperationTypes");

            migrationBuilder.DropTable(
                name: "Gates");

            migrationBuilder.DropTable(
                name: "Shutters");

            migrationBuilder.DropTable(
                name: "WeldGateValveCase");

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
                name: "RunningSleeves");

            migrationBuilder.DropTable(
                name: "Spindles");

            migrationBuilder.DropTable(
                name: "CoverFlanges");

            migrationBuilder.DropTable(
                name: "CoverSleeves");

            migrationBuilder.DropTable(
                name: "ProductTypes");

            migrationBuilder.DropTable(
                name: "Specifications");

            migrationBuilder.DropTable(
                name: "CoverSealingRings");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "MetalMaterials");
        }
    }
}
