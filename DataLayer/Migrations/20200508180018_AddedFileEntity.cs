using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class AddedFileEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "WeldingMaterials",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsSupervisionRequest",
                table: "Specifications",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Diameter",
                table: "ShearPins",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TensileStrength",
                table: "ShearPins",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Hardness",
                table: "ScrewStuds",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Thread",
                table: "ScrewStuds",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Hardness",
                table: "ScrewNuts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Thread",
                table: "ScrewNuts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Consignee",
                table: "PIDs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "PIDs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "STD1",
                table: "PIDs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "STD2",
                table: "PIDs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ThicknessJoining",
                table: "CounterFlanges",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "ControlWelds",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Stamp",
                table: "ControlWelds",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Welder",
                table: "ControlWelds",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AutoNumber",
                table: "BaseAssemblyUnit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Factory",
                table: "BaseAnticorrosiveCoatings",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ElectronicDocuments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FileType = table.Column<byte>(nullable: false),
                    Number = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    FilePath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElectronicDocuments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AssemblyUnitSealsWithFiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AssemblyUnitSealingId = table.Column<int>(nullable: false),
                    ElectronicDocumentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssemblyUnitSealsWithFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssemblyUnitSealsWithFiles_AssemblyUnitSeals_AssemblyUnitSealingId",
                        column: x => x.AssemblyUnitSealingId,
                        principalTable: "AssemblyUnitSeals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssemblyUnitSealsWithFiles_ElectronicDocuments_ElectronicDocumentId",
                        column: x => x.ElectronicDocumentId,
                        principalTable: "ElectronicDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BallValvesWithFiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BallValveId = table.Column<int>(nullable: false),
                    ElectronicDocumentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BallValvesWithFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BallValvesWithFiles_BallValves_BallValveId",
                        column: x => x.BallValveId,
                        principalTable: "BallValves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BallValvesWithFiles_ElectronicDocuments_ElectronicDocumentId",
                        column: x => x.ElectronicDocumentId,
                        principalTable: "ElectronicDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BaseAnticorrosiveCoatingWithFiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BaseAnticorrosiveCoatingId = table.Column<int>(nullable: false),
                    ElectronicDocumentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseAnticorrosiveCoatingWithFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaseAnticorrosiveCoatingWithFiles_BaseAnticorrosiveCoatings_BaseAnticorrosiveCoatingId",
                        column: x => x.BaseAnticorrosiveCoatingId,
                        principalTable: "BaseAnticorrosiveCoatings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BaseAnticorrosiveCoatingWithFiles_ElectronicDocuments_ElectronicDocumentId",
                        column: x => x.ElectronicDocumentId,
                        principalTable: "ElectronicDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BaseAssemblyUnitWithFiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BaseAssemblyUnitId = table.Column<int>(nullable: false),
                    ElectronicDocumentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseAssemblyUnitWithFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaseAssemblyUnitWithFiles_BaseAssemblyUnit_BaseAssemblyUnitId",
                        column: x => x.BaseAssemblyUnitId,
                        principalTable: "BaseAssemblyUnit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BaseAssemblyUnitWithFiles_ElectronicDocuments_ElectronicDocumentId",
                        column: x => x.ElectronicDocumentId,
                        principalTable: "ElectronicDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BaseCastingCaseWithFiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BaseCastingCaseId = table.Column<int>(nullable: false),
                    ElectronicDocumentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseCastingCaseWithFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaseCastingCaseWithFiles_BaseCastingCase_BaseCastingCaseId",
                        column: x => x.BaseCastingCaseId,
                        principalTable: "BaseCastingCase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BaseCastingCaseWithFiles_ElectronicDocuments_ElectronicDocumentId",
                        column: x => x.ElectronicDocumentId,
                        principalTable: "ElectronicDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BaseValveCoverWithFiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BaseValveCoverId = table.Column<int>(nullable: false),
                    ElectronicDocumentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseValveCoverWithFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaseValveCoverWithFiles_BaseValveCover_BaseValveCoverId",
                        column: x => x.BaseValveCoverId,
                        principalTable: "BaseValveCover",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BaseValveCoverWithFiles_ElectronicDocuments_ElectronicDocumentId",
                        column: x => x.ElectronicDocumentId,
                        principalTable: "ElectronicDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BronzeSleeveShutterWithFiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BronzeSleeveShutterId = table.Column<int>(nullable: false),
                    ElectronicDocumentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BronzeSleeveShutterWithFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BronzeSleeveShutterWithFiles_BronzeSleeveShutters_BronzeSleeveShutterId",
                        column: x => x.BronzeSleeveShutterId,
                        principalTable: "BronzeSleeveShutters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BronzeSleeveShutterWithFiles_ElectronicDocuments_ElectronicDocumentId",
                        column: x => x.ElectronicDocumentId,
                        principalTable: "ElectronicDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CaseBottomWithFiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CaseBottomId = table.Column<int>(nullable: false),
                    ElectronicDocumentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseBottomWithFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CaseBottomWithFiles_CaseBottoms_CaseBottomId",
                        column: x => x.CaseBottomId,
                        principalTable: "CaseBottoms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CaseBottomWithFiles_ElectronicDocuments_ElectronicDocumentId",
                        column: x => x.ElectronicDocumentId,
                        principalTable: "ElectronicDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CaseEdgeWithFiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CaseEdgeId = table.Column<int>(nullable: false),
                    ElectronicDocumentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseEdgeWithFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CaseEdgeWithFiles_CaseEdges_CaseEdgeId",
                        column: x => x.CaseEdgeId,
                        principalTable: "CaseEdges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CaseEdgeWithFiles_ElectronicDocuments_ElectronicDocumentId",
                        column: x => x.ElectronicDocumentId,
                        principalTable: "ElectronicDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CaseFlangeWithFiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CaseFlangeId = table.Column<int>(nullable: false),
                    ElectronicDocumentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseFlangeWithFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CaseFlangeWithFiles_CaseFlanges_CaseFlangeId",
                        column: x => x.CaseFlangeId,
                        principalTable: "CaseFlanges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CaseFlangeWithFiles_ElectronicDocuments_ElectronicDocumentId",
                        column: x => x.ElectronicDocumentId,
                        principalTable: "ElectronicDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ControlWeldWithFiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ControlWeldId = table.Column<int>(nullable: false),
                    ElectronicDocumentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ControlWeldWithFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ControlWeldWithFiles_ControlWelds_ControlWeldId",
                        column: x => x.ControlWeldId,
                        principalTable: "ControlWelds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ControlWeldWithFiles_ElectronicDocuments_ElectronicDocumentId",
                        column: x => x.ElectronicDocumentId,
                        principalTable: "ElectronicDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CounterFlangeWithFiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CounterFlangeId = table.Column<int>(nullable: false),
                    ElectronicDocumentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CounterFlangeWithFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CounterFlangeWithFiles_CounterFlanges_CounterFlangeId",
                        column: x => x.CounterFlangeId,
                        principalTable: "CounterFlanges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CounterFlangeWithFiles_ElectronicDocuments_ElectronicDocumentId",
                        column: x => x.ElectronicDocumentId,
                        principalTable: "ElectronicDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CoverFlangeWithFiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CoverFlangeId = table.Column<int>(nullable: false),
                    ElectronicDocumentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoverFlangeWithFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoverFlangeWithFiles_CoverFlanges_CoverFlangeId",
                        column: x => x.CoverFlangeId,
                        principalTable: "CoverFlanges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoverFlangeWithFiles_ElectronicDocuments_ElectronicDocumentId",
                        column: x => x.ElectronicDocumentId,
                        principalTable: "ElectronicDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CoverSealingRingWithFiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CoverSealingRingId = table.Column<int>(nullable: false),
                    ElectronicDocumentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoverSealingRingWithFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoverSealingRingWithFiles_CoverSealingRings_CoverSealingRingId",
                        column: x => x.CoverSealingRingId,
                        principalTable: "CoverSealingRings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoverSealingRingWithFiles_ElectronicDocuments_ElectronicDocumentId",
                        column: x => x.ElectronicDocumentId,
                        principalTable: "ElectronicDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CoverSleeveWithFiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CoverSleeveId = table.Column<int>(nullable: false),
                    ElectronicDocumentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoverSleeveWithFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoverSleeveWithFiles_CoverSleeves_CoverSleeveId",
                        column: x => x.CoverSleeveId,
                        principalTable: "CoverSleeves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoverSleeveWithFiles_ElectronicDocuments_ElectronicDocumentId",
                        column: x => x.ElectronicDocumentId,
                        principalTable: "ElectronicDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FrontalSaddleSealingWithFiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FrontalSaddleSealingId = table.Column<int>(nullable: false),
                    ElectronicDocumentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FrontalSaddleSealingWithFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FrontalSaddleSealingWithFiles_ElectronicDocuments_ElectronicDocumentId",
                        column: x => x.ElectronicDocumentId,
                        principalTable: "ElectronicDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FrontalSaddleSealingWithFiles_FrontalSaddleSeals_FrontalSaddleSealingId",
                        column: x => x.FrontalSaddleSealingId,
                        principalTable: "FrontalSaddleSeals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FrontWallWithFiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FrontWallId = table.Column<int>(nullable: false),
                    ElectronicDocumentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FrontWallWithFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FrontWallWithFiles_ElectronicDocuments_ElectronicDocumentId",
                        column: x => x.ElectronicDocumentId,
                        principalTable: "ElectronicDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FrontWallWithFiles_FrontWalls_FrontWallId",
                        column: x => x.FrontWallId,
                        principalTable: "FrontWalls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GateWithFiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GateId = table.Column<int>(nullable: false),
                    ElectronicDocumentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GateWithFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GateWithFiles_ElectronicDocuments_ElectronicDocumentId",
                        column: x => x.ElectronicDocumentId,
                        principalTable: "ElectronicDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GateWithFiles_Gates_GateId",
                        column: x => x.GateId,
                        principalTable: "Gates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MetalMaterialWithFiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MetalMaterialId = table.Column<int>(nullable: false),
                    ElectronicDocumentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetalMaterialWithFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MetalMaterialWithFiles_ElectronicDocuments_ElectronicDocumentId",
                        column: x => x.ElectronicDocumentId,
                        principalTable: "ElectronicDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MetalMaterialWithFiles_MetalMaterials_MetalMaterialId",
                        column: x => x.MetalMaterialId,
                        principalTable: "MetalMaterials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NozzleWithFiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NozzleId = table.Column<int>(nullable: false),
                    ElectronicDocumentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NozzleWithFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NozzleWithFiles_ElectronicDocuments_ElectronicDocumentId",
                        column: x => x.ElectronicDocumentId,
                        principalTable: "ElectronicDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NozzleWithFiles_Nozzles_NozzleId",
                        column: x => x.NozzleId,
                        principalTable: "Nozzles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PIDWithFiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PIDId = table.Column<int>(nullable: false),
                    ElectronicDocumentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PIDWithFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PIDWithFiles_ElectronicDocuments_ElectronicDocumentId",
                        column: x => x.ElectronicDocumentId,
                        principalTable: "ElectronicDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PIDWithFiles_PIDs_PIDId",
                        column: x => x.PIDId,
                        principalTable: "PIDs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RunningSleeveWithFiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RunningSleeveId = table.Column<int>(nullable: false),
                    ElectronicDocumentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RunningSleeveWithFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RunningSleeveWithFiles_ElectronicDocuments_ElectronicDocumentId",
                        column: x => x.ElectronicDocumentId,
                        principalTable: "ElectronicDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RunningSleeveWithFiles_RunningSleeves_RunningSleeveId",
                        column: x => x.RunningSleeveId,
                        principalTable: "RunningSleeves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SaddleWithFiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SaddleId = table.Column<int>(nullable: false),
                    ElectronicDocumentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaddleWithFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SaddleWithFiles_ElectronicDocuments_ElectronicDocumentId",
                        column: x => x.ElectronicDocumentId,
                        principalTable: "ElectronicDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SaddleWithFiles_Saddles_SaddleId",
                        column: x => x.SaddleId,
                        principalTable: "Saddles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScrewNutWithFiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ScrewNutId = table.Column<int>(nullable: false),
                    ElectronicDocumentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScrewNutWithFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScrewNutWithFiles_ElectronicDocuments_ElectronicDocumentId",
                        column: x => x.ElectronicDocumentId,
                        principalTable: "ElectronicDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScrewNutWithFiles_ScrewNuts_ScrewNutId",
                        column: x => x.ScrewNutId,
                        principalTable: "ScrewNuts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScrewStudWithFiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ScrewStudId = table.Column<int>(nullable: false),
                    ElectronicDocumentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScrewStudWithFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScrewStudWithFiles_ElectronicDocuments_ElectronicDocumentId",
                        column: x => x.ElectronicDocumentId,
                        principalTable: "ElectronicDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScrewStudWithFiles_ScrewStuds_ScrewStudId",
                        column: x => x.ScrewStudId,
                        principalTable: "ScrewStuds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShaftShutterWithFiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ShaftShutterId = table.Column<int>(nullable: false),
                    ElectronicDocumentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShaftShutterWithFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShaftShutterWithFiles_ElectronicDocuments_ElectronicDocumentId",
                        column: x => x.ElectronicDocumentId,
                        principalTable: "ElectronicDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShaftShutterWithFiles_ShaftShutters_ShaftShutterId",
                        column: x => x.ShaftShutterId,
                        principalTable: "ShaftShutters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShearPinWithFiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ShearPinId = table.Column<int>(nullable: false),
                    ElectronicDocumentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShearPinWithFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShearPinWithFiles_ElectronicDocuments_ElectronicDocumentId",
                        column: x => x.ElectronicDocumentId,
                        principalTable: "ElectronicDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShearPinWithFiles_ShearPins_ShearPinId",
                        column: x => x.ShearPinId,
                        principalTable: "ShearPins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShutterDiskWithFiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ShutterDiskId = table.Column<int>(nullable: false),
                    ElectronicDocumentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShutterDiskWithFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShutterDiskWithFiles_ElectronicDocuments_ElectronicDocumentId",
                        column: x => x.ElectronicDocumentId,
                        principalTable: "ElectronicDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShutterDiskWithFiles_ShutterDisks_ShutterDiskId",
                        column: x => x.ShutterDiskId,
                        principalTable: "ShutterDisks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShutterGuideWithFiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ShutterGuideId = table.Column<int>(nullable: false),
                    ElectronicDocumentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShutterGuideWithFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShutterGuideWithFiles_ElectronicDocuments_ElectronicDocumentId",
                        column: x => x.ElectronicDocumentId,
                        principalTable: "ElectronicDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShutterGuideWithFiles_ShutterGuides_ShutterGuideId",
                        column: x => x.ShutterGuideId,
                        principalTable: "ShutterGuides",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShutterWithFiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ShutterId = table.Column<int>(nullable: false),
                    ElectronicDocumentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShutterWithFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShutterWithFiles_ElectronicDocuments_ElectronicDocumentId",
                        column: x => x.ElectronicDocumentId,
                        principalTable: "ElectronicDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShutterWithFiles_Shutters_ShutterId",
                        column: x => x.ShutterId,
                        principalTable: "Shutters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SideWallWithFiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SideWallId = table.Column<int>(nullable: false),
                    ElectronicDocumentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SideWallWithFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SideWallWithFiles_ElectronicDocuments_ElectronicDocumentId",
                        column: x => x.ElectronicDocumentId,
                        principalTable: "ElectronicDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SideWallWithFiles_SideWalls_SideWallId",
                        column: x => x.SideWallId,
                        principalTable: "SideWalls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SlamShutterWithFiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SlamShutterId = table.Column<int>(nullable: false),
                    ElectronicDocumentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SlamShutterWithFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SlamShutterWithFiles_ElectronicDocuments_ElectronicDocumentId",
                        column: x => x.ElectronicDocumentId,
                        principalTable: "ElectronicDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SlamShutterWithFiles_SlamShutters_SlamShutterId",
                        column: x => x.SlamShutterId,
                        principalTable: "SlamShutters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpecificationWithFiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SpecificationId = table.Column<int>(nullable: false),
                    ElectronicDocumentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecificationWithFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpecificationWithFiles_ElectronicDocuments_ElectronicDocumentId",
                        column: x => x.ElectronicDocumentId,
                        principalTable: "ElectronicDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpecificationWithFiles_Specifications_SpecificationId",
                        column: x => x.SpecificationId,
                        principalTable: "Specifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpindleWithFiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SpindleId = table.Column<int>(nullable: false),
                    ElectronicDocumentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpindleWithFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpindleWithFiles_ElectronicDocuments_ElectronicDocumentId",
                        column: x => x.ElectronicDocumentId,
                        principalTable: "ElectronicDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpindleWithFiles_Spindles_SpindleId",
                        column: x => x.SpindleId,
                        principalTable: "Spindles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpringWithFiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SpringId = table.Column<int>(nullable: false),
                    ElectronicDocumentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpringWithFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpringWithFiles_ElectronicDocuments_ElectronicDocumentId",
                        column: x => x.ElectronicDocumentId,
                        principalTable: "ElectronicDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpringWithFiles_Springs_SpringId",
                        column: x => x.SpringId,
                        principalTable: "Springs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SteelSleeveShutterWithFiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SteelSleeveShutterId = table.Column<int>(nullable: false),
                    ElectronicDocumentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SteelSleeveShutterWithFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SteelSleeveShutterWithFiles_ElectronicDocuments_ElectronicDocumentId",
                        column: x => x.ElectronicDocumentId,
                        principalTable: "ElectronicDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SteelSleeveShutterWithFiles_SteelSleeveShutters_SteelSleeveShutterId",
                        column: x => x.SteelSleeveShutterId,
                        principalTable: "SteelSleeveShutters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StubShutterWithFiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StubShutterId = table.Column<int>(nullable: false),
                    ElectronicDocumentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StubShutterWithFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StubShutterWithFiles_ElectronicDocuments_ElectronicDocumentId",
                        column: x => x.ElectronicDocumentId,
                        principalTable: "ElectronicDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StubShutterWithFiles_StubShutters_StubShutterId",
                        column: x => x.StubShutterId,
                        principalTable: "StubShutters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WeldGateValveCaseWithFiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    WeldGateValveCaseId = table.Column<int>(nullable: false),
                    ElectronicDocumentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeldGateValveCaseWithFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeldGateValveCaseWithFiles_ElectronicDocuments_ElectronicDocumentId",
                        column: x => x.ElectronicDocumentId,
                        principalTable: "ElectronicDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WeldGateValveCaseWithFiles_WeldGateValveCase_WeldGateValveCaseId",
                        column: x => x.WeldGateValveCaseId,
                        principalTable: "WeldGateValveCase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WeldingMaterialWithFiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    WeldingMaterialId = table.Column<int>(nullable: false),
                    ElectronicDocumentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeldingMaterialWithFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeldingMaterialWithFiles_ElectronicDocuments_ElectronicDocumentId",
                        column: x => x.ElectronicDocumentId,
                        principalTable: "ElectronicDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WeldingMaterialWithFiles_WeldingMaterials_WeldingMaterialId",
                        column: x => x.WeldingMaterialId,
                        principalTable: "WeldingMaterials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WeldNozzleWithFiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    WeldNozzleId = table.Column<int>(nullable: false),
                    ElectronicDocumentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeldNozzleWithFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeldNozzleWithFiles_ElectronicDocuments_ElectronicDocumentId",
                        column: x => x.ElectronicDocumentId,
                        principalTable: "ElectronicDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WeldNozzleWithFiles_WeldNozzles_WeldNozzleId",
                        column: x => x.WeldNozzleId,
                        principalTable: "WeldNozzles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssemblyUnitSealsWithFiles_AssemblyUnitSealingId",
                table: "AssemblyUnitSealsWithFiles",
                column: "AssemblyUnitSealingId");

            migrationBuilder.CreateIndex(
                name: "IX_AssemblyUnitSealsWithFiles_ElectronicDocumentId",
                table: "AssemblyUnitSealsWithFiles",
                column: "ElectronicDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_BallValvesWithFiles_BallValveId",
                table: "BallValvesWithFiles",
                column: "BallValveId");

            migrationBuilder.CreateIndex(
                name: "IX_BallValvesWithFiles_ElectronicDocumentId",
                table: "BallValvesWithFiles",
                column: "ElectronicDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseAnticorrosiveCoatingWithFiles_BaseAnticorrosiveCoatingId",
                table: "BaseAnticorrosiveCoatingWithFiles",
                column: "BaseAnticorrosiveCoatingId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseAnticorrosiveCoatingWithFiles_ElectronicDocumentId",
                table: "BaseAnticorrosiveCoatingWithFiles",
                column: "ElectronicDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseAssemblyUnitWithFiles_BaseAssemblyUnitId",
                table: "BaseAssemblyUnitWithFiles",
                column: "BaseAssemblyUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseAssemblyUnitWithFiles_ElectronicDocumentId",
                table: "BaseAssemblyUnitWithFiles",
                column: "ElectronicDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseCastingCaseWithFiles_BaseCastingCaseId",
                table: "BaseCastingCaseWithFiles",
                column: "BaseCastingCaseId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseCastingCaseWithFiles_ElectronicDocumentId",
                table: "BaseCastingCaseWithFiles",
                column: "ElectronicDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseValveCoverWithFiles_BaseValveCoverId",
                table: "BaseValveCoverWithFiles",
                column: "BaseValveCoverId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseValveCoverWithFiles_ElectronicDocumentId",
                table: "BaseValveCoverWithFiles",
                column: "ElectronicDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_BronzeSleeveShutterWithFiles_BronzeSleeveShutterId",
                table: "BronzeSleeveShutterWithFiles",
                column: "BronzeSleeveShutterId");

            migrationBuilder.CreateIndex(
                name: "IX_BronzeSleeveShutterWithFiles_ElectronicDocumentId",
                table: "BronzeSleeveShutterWithFiles",
                column: "ElectronicDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseBottomWithFiles_CaseBottomId",
                table: "CaseBottomWithFiles",
                column: "CaseBottomId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseBottomWithFiles_ElectronicDocumentId",
                table: "CaseBottomWithFiles",
                column: "ElectronicDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseEdgeWithFiles_CaseEdgeId",
                table: "CaseEdgeWithFiles",
                column: "CaseEdgeId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseEdgeWithFiles_ElectronicDocumentId",
                table: "CaseEdgeWithFiles",
                column: "ElectronicDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseFlangeWithFiles_CaseFlangeId",
                table: "CaseFlangeWithFiles",
                column: "CaseFlangeId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseFlangeWithFiles_ElectronicDocumentId",
                table: "CaseFlangeWithFiles",
                column: "ElectronicDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_ControlWeldWithFiles_ControlWeldId",
                table: "ControlWeldWithFiles",
                column: "ControlWeldId");

            migrationBuilder.CreateIndex(
                name: "IX_ControlWeldWithFiles_ElectronicDocumentId",
                table: "ControlWeldWithFiles",
                column: "ElectronicDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_CounterFlangeWithFiles_CounterFlangeId",
                table: "CounterFlangeWithFiles",
                column: "CounterFlangeId");

            migrationBuilder.CreateIndex(
                name: "IX_CounterFlangeWithFiles_ElectronicDocumentId",
                table: "CounterFlangeWithFiles",
                column: "ElectronicDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_CoverFlangeWithFiles_CoverFlangeId",
                table: "CoverFlangeWithFiles",
                column: "CoverFlangeId");

            migrationBuilder.CreateIndex(
                name: "IX_CoverFlangeWithFiles_ElectronicDocumentId",
                table: "CoverFlangeWithFiles",
                column: "ElectronicDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_CoverSealingRingWithFiles_CoverSealingRingId",
                table: "CoverSealingRingWithFiles",
                column: "CoverSealingRingId");

            migrationBuilder.CreateIndex(
                name: "IX_CoverSealingRingWithFiles_ElectronicDocumentId",
                table: "CoverSealingRingWithFiles",
                column: "ElectronicDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_CoverSleeveWithFiles_CoverSleeveId",
                table: "CoverSleeveWithFiles",
                column: "CoverSleeveId");

            migrationBuilder.CreateIndex(
                name: "IX_CoverSleeveWithFiles_ElectronicDocumentId",
                table: "CoverSleeveWithFiles",
                column: "ElectronicDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_FrontalSaddleSealingWithFiles_ElectronicDocumentId",
                table: "FrontalSaddleSealingWithFiles",
                column: "ElectronicDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_FrontalSaddleSealingWithFiles_FrontalSaddleSealingId",
                table: "FrontalSaddleSealingWithFiles",
                column: "FrontalSaddleSealingId");

            migrationBuilder.CreateIndex(
                name: "IX_FrontWallWithFiles_ElectronicDocumentId",
                table: "FrontWallWithFiles",
                column: "ElectronicDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_FrontWallWithFiles_FrontWallId",
                table: "FrontWallWithFiles",
                column: "FrontWallId");

            migrationBuilder.CreateIndex(
                name: "IX_GateWithFiles_ElectronicDocumentId",
                table: "GateWithFiles",
                column: "ElectronicDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_GateWithFiles_GateId",
                table: "GateWithFiles",
                column: "GateId");

            migrationBuilder.CreateIndex(
                name: "IX_MetalMaterialWithFiles_ElectronicDocumentId",
                table: "MetalMaterialWithFiles",
                column: "ElectronicDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_MetalMaterialWithFiles_MetalMaterialId",
                table: "MetalMaterialWithFiles",
                column: "MetalMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_NozzleWithFiles_ElectronicDocumentId",
                table: "NozzleWithFiles",
                column: "ElectronicDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_NozzleWithFiles_NozzleId",
                table: "NozzleWithFiles",
                column: "NozzleId");

            migrationBuilder.CreateIndex(
                name: "IX_PIDWithFiles_ElectronicDocumentId",
                table: "PIDWithFiles",
                column: "ElectronicDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_PIDWithFiles_PIDId",
                table: "PIDWithFiles",
                column: "PIDId");

            migrationBuilder.CreateIndex(
                name: "IX_RunningSleeveWithFiles_ElectronicDocumentId",
                table: "RunningSleeveWithFiles",
                column: "ElectronicDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_RunningSleeveWithFiles_RunningSleeveId",
                table: "RunningSleeveWithFiles",
                column: "RunningSleeveId");

            migrationBuilder.CreateIndex(
                name: "IX_SaddleWithFiles_ElectronicDocumentId",
                table: "SaddleWithFiles",
                column: "ElectronicDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_SaddleWithFiles_SaddleId",
                table: "SaddleWithFiles",
                column: "SaddleId");

            migrationBuilder.CreateIndex(
                name: "IX_ScrewNutWithFiles_ElectronicDocumentId",
                table: "ScrewNutWithFiles",
                column: "ElectronicDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_ScrewNutWithFiles_ScrewNutId",
                table: "ScrewNutWithFiles",
                column: "ScrewNutId");

            migrationBuilder.CreateIndex(
                name: "IX_ScrewStudWithFiles_ElectronicDocumentId",
                table: "ScrewStudWithFiles",
                column: "ElectronicDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_ScrewStudWithFiles_ScrewStudId",
                table: "ScrewStudWithFiles",
                column: "ScrewStudId");

            migrationBuilder.CreateIndex(
                name: "IX_ShaftShutterWithFiles_ElectronicDocumentId",
                table: "ShaftShutterWithFiles",
                column: "ElectronicDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_ShaftShutterWithFiles_ShaftShutterId",
                table: "ShaftShutterWithFiles",
                column: "ShaftShutterId");

            migrationBuilder.CreateIndex(
                name: "IX_ShearPinWithFiles_ElectronicDocumentId",
                table: "ShearPinWithFiles",
                column: "ElectronicDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_ShearPinWithFiles_ShearPinId",
                table: "ShearPinWithFiles",
                column: "ShearPinId");

            migrationBuilder.CreateIndex(
                name: "IX_ShutterDiskWithFiles_ElectronicDocumentId",
                table: "ShutterDiskWithFiles",
                column: "ElectronicDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_ShutterDiskWithFiles_ShutterDiskId",
                table: "ShutterDiskWithFiles",
                column: "ShutterDiskId");

            migrationBuilder.CreateIndex(
                name: "IX_ShutterGuideWithFiles_ElectronicDocumentId",
                table: "ShutterGuideWithFiles",
                column: "ElectronicDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_ShutterGuideWithFiles_ShutterGuideId",
                table: "ShutterGuideWithFiles",
                column: "ShutterGuideId");

            migrationBuilder.CreateIndex(
                name: "IX_ShutterWithFiles_ElectronicDocumentId",
                table: "ShutterWithFiles",
                column: "ElectronicDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_ShutterWithFiles_ShutterId",
                table: "ShutterWithFiles",
                column: "ShutterId");

            migrationBuilder.CreateIndex(
                name: "IX_SideWallWithFiles_ElectronicDocumentId",
                table: "SideWallWithFiles",
                column: "ElectronicDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_SideWallWithFiles_SideWallId",
                table: "SideWallWithFiles",
                column: "SideWallId");

            migrationBuilder.CreateIndex(
                name: "IX_SlamShutterWithFiles_ElectronicDocumentId",
                table: "SlamShutterWithFiles",
                column: "ElectronicDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_SlamShutterWithFiles_SlamShutterId",
                table: "SlamShutterWithFiles",
                column: "SlamShutterId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecificationWithFiles_ElectronicDocumentId",
                table: "SpecificationWithFiles",
                column: "ElectronicDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecificationWithFiles_SpecificationId",
                table: "SpecificationWithFiles",
                column: "SpecificationId");

            migrationBuilder.CreateIndex(
                name: "IX_SpindleWithFiles_ElectronicDocumentId",
                table: "SpindleWithFiles",
                column: "ElectronicDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_SpindleWithFiles_SpindleId",
                table: "SpindleWithFiles",
                column: "SpindleId");

            migrationBuilder.CreateIndex(
                name: "IX_SpringWithFiles_ElectronicDocumentId",
                table: "SpringWithFiles",
                column: "ElectronicDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_SpringWithFiles_SpringId",
                table: "SpringWithFiles",
                column: "SpringId");

            migrationBuilder.CreateIndex(
                name: "IX_SteelSleeveShutterWithFiles_ElectronicDocumentId",
                table: "SteelSleeveShutterWithFiles",
                column: "ElectronicDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_SteelSleeveShutterWithFiles_SteelSleeveShutterId",
                table: "SteelSleeveShutterWithFiles",
                column: "SteelSleeveShutterId");

            migrationBuilder.CreateIndex(
                name: "IX_StubShutterWithFiles_ElectronicDocumentId",
                table: "StubShutterWithFiles",
                column: "ElectronicDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_StubShutterWithFiles_StubShutterId",
                table: "StubShutterWithFiles",
                column: "StubShutterId");

            migrationBuilder.CreateIndex(
                name: "IX_WeldGateValveCaseWithFiles_ElectronicDocumentId",
                table: "WeldGateValveCaseWithFiles",
                column: "ElectronicDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_WeldGateValveCaseWithFiles_WeldGateValveCaseId",
                table: "WeldGateValveCaseWithFiles",
                column: "WeldGateValveCaseId");

            migrationBuilder.CreateIndex(
                name: "IX_WeldingMaterialWithFiles_ElectronicDocumentId",
                table: "WeldingMaterialWithFiles",
                column: "ElectronicDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_WeldingMaterialWithFiles_WeldingMaterialId",
                table: "WeldingMaterialWithFiles",
                column: "WeldingMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_WeldNozzleWithFiles_ElectronicDocumentId",
                table: "WeldNozzleWithFiles",
                column: "ElectronicDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_WeldNozzleWithFiles_WeldNozzleId",
                table: "WeldNozzleWithFiles",
                column: "WeldNozzleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssemblyUnitSealsWithFiles");

            migrationBuilder.DropTable(
                name: "BallValvesWithFiles");

            migrationBuilder.DropTable(
                name: "BaseAnticorrosiveCoatingWithFiles");

            migrationBuilder.DropTable(
                name: "BaseAssemblyUnitWithFiles");

            migrationBuilder.DropTable(
                name: "BaseCastingCaseWithFiles");

            migrationBuilder.DropTable(
                name: "BaseValveCoverWithFiles");

            migrationBuilder.DropTable(
                name: "BronzeSleeveShutterWithFiles");

            migrationBuilder.DropTable(
                name: "CaseBottomWithFiles");

            migrationBuilder.DropTable(
                name: "CaseEdgeWithFiles");

            migrationBuilder.DropTable(
                name: "CaseFlangeWithFiles");

            migrationBuilder.DropTable(
                name: "ControlWeldWithFiles");

            migrationBuilder.DropTable(
                name: "CounterFlangeWithFiles");

            migrationBuilder.DropTable(
                name: "CoverFlangeWithFiles");

            migrationBuilder.DropTable(
                name: "CoverSealingRingWithFiles");

            migrationBuilder.DropTable(
                name: "CoverSleeveWithFiles");

            migrationBuilder.DropTable(
                name: "FrontalSaddleSealingWithFiles");

            migrationBuilder.DropTable(
                name: "FrontWallWithFiles");

            migrationBuilder.DropTable(
                name: "GateWithFiles");

            migrationBuilder.DropTable(
                name: "MetalMaterialWithFiles");

            migrationBuilder.DropTable(
                name: "NozzleWithFiles");

            migrationBuilder.DropTable(
                name: "PIDWithFiles");

            migrationBuilder.DropTable(
                name: "RunningSleeveWithFiles");

            migrationBuilder.DropTable(
                name: "SaddleWithFiles");

            migrationBuilder.DropTable(
                name: "ScrewNutWithFiles");

            migrationBuilder.DropTable(
                name: "ScrewStudWithFiles");

            migrationBuilder.DropTable(
                name: "ShaftShutterWithFiles");

            migrationBuilder.DropTable(
                name: "ShearPinWithFiles");

            migrationBuilder.DropTable(
                name: "ShutterDiskWithFiles");

            migrationBuilder.DropTable(
                name: "ShutterGuideWithFiles");

            migrationBuilder.DropTable(
                name: "ShutterWithFiles");

            migrationBuilder.DropTable(
                name: "SideWallWithFiles");

            migrationBuilder.DropTable(
                name: "SlamShutterWithFiles");

            migrationBuilder.DropTable(
                name: "SpecificationWithFiles");

            migrationBuilder.DropTable(
                name: "SpindleWithFiles");

            migrationBuilder.DropTable(
                name: "SpringWithFiles");

            migrationBuilder.DropTable(
                name: "SteelSleeveShutterWithFiles");

            migrationBuilder.DropTable(
                name: "StubShutterWithFiles");

            migrationBuilder.DropTable(
                name: "WeldGateValveCaseWithFiles");

            migrationBuilder.DropTable(
                name: "WeldingMaterialWithFiles");

            migrationBuilder.DropTable(
                name: "WeldNozzleWithFiles");

            migrationBuilder.DropTable(
                name: "ElectronicDocuments");

            migrationBuilder.DropColumn(
                name: "Comment",
                table: "WeldingMaterials");

            migrationBuilder.DropColumn(
                name: "IsSupervisionRequest",
                table: "Specifications");

            migrationBuilder.DropColumn(
                name: "Diameter",
                table: "ShearPins");

            migrationBuilder.DropColumn(
                name: "TensileStrength",
                table: "ShearPins");

            migrationBuilder.DropColumn(
                name: "Hardness",
                table: "ScrewStuds");

            migrationBuilder.DropColumn(
                name: "Thread",
                table: "ScrewStuds");

            migrationBuilder.DropColumn(
                name: "Hardness",
                table: "ScrewNuts");

            migrationBuilder.DropColumn(
                name: "Thread",
                table: "ScrewNuts");

            migrationBuilder.DropColumn(
                name: "Consignee",
                table: "PIDs");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "PIDs");

            migrationBuilder.DropColumn(
                name: "STD1",
                table: "PIDs");

            migrationBuilder.DropColumn(
                name: "STD2",
                table: "PIDs");

            migrationBuilder.DropColumn(
                name: "ThicknessJoining",
                table: "CounterFlanges");

            migrationBuilder.DropColumn(
                name: "Comment",
                table: "ControlWelds");

            migrationBuilder.DropColumn(
                name: "Stamp",
                table: "ControlWelds");

            migrationBuilder.DropColumn(
                name: "Welder",
                table: "ControlWelds");

            migrationBuilder.DropColumn(
                name: "AutoNumber",
                table: "BaseAssemblyUnit");

            migrationBuilder.DropColumn(
                name: "Factory",
                table: "BaseAnticorrosiveCoatings");

            migrationBuilder.AddColumn<int>(
                name: "CastGateValveCoverTCPId",
                table: "CastGateValveCoverJournals",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CastGateValveCoverJournals_CastGateValveCoverTCPId",
                table: "CastGateValveCoverJournals",
                column: "CastGateValveCoverTCPId");

            migrationBuilder.AddForeignKey(
                name: "FK_CastGateValveCoverJournals_BaseTCP_CastGateValveCoverTCPId",
                table: "CastGateValveCoverJournals",
                column: "CastGateValveCoverTCPId",
                principalTable: "BaseTCP",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
