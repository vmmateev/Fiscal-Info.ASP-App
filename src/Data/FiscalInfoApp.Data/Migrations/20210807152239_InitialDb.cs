namespace FiscalInfoApp.Data.Migrations
{
    using System;

    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class InitialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsServiceOrganization = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OilLevel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PetrolStationId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OilLevel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SimCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imsi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GsmNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OperatorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FiscalPrinterId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SimCards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Probe",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProbeLength = table.Column<double>(type: "float", nullable: false),
                    FloatSize = table.Column<int>(type: "int", nullable: false),
                    FloatFuelType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OilLevelId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Probe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Probe_OilLevel_OilLevelId",
                        column: x => x.OilLevelId,
                        principalTable: "OilLevel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FiscalPrinters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OsNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MemoryNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fdrid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PetrolStationId = table.Column<int>(type: "int", nullable: false),
                    SimCardId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FiscalPrinters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FiscalPrinters_SimCards_SimCardId",
                        column: x => x.SimCardId,
                        principalTable: "SimCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PetrolStations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FiscalPrinterId = table.Column<int>(type: "int", nullable: false),
                    OilLevelId = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetrolStations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PetrolStations_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PetrolStations_FiscalPrinters_FiscalPrinterId",
                        column: x => x.FiscalPrinterId,
                        principalTable: "FiscalPrinters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PetrolStations_OilLevel_OilLevelId",
                        column: x => x.OilLevelId,
                        principalTable: "OilLevel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CommController",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BoxColor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsConcentrator = table.Column<bool>(type: "bit", nullable: false),
                    PetrolStationId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommController", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommController_PetrolStations_PetrolStationId",
                        column: x => x.PetrolStationId,
                        principalTable: "PetrolStations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PetrolStationId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comment_PetrolStations_PetrolStationId",
                        column: x => x.PetrolStationId,
                        principalTable: "PetrolStations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FuelDispenser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DispenserNumber = table.Column<int>(type: "int", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NozzleCount = table.Column<int>(type: "int", nullable: false),
                    MidCertificate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PetrolStationId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuelDispenser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FuelDispenser_PetrolStations_PetrolStationId",
                        column: x => x.PetrolStationId,
                        principalTable: "PetrolStations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FuelTanks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TankNumber = table.Column<int>(type: "int", nullable: false),
                    FullVolume = table.Column<int>(type: "int", nullable: false),
                    Diameter = table.Column<double>(type: "float", nullable: false),
                    CalibrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FuelType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PetrolStationId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuelTanks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FuelTanks_PetrolStations_PetrolStationId",
                        column: x => x.PetrolStationId,
                        principalTable: "PetrolStations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CompanyId",
                table: "AspNetUsers",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CommController_IsDeleted",
                table: "CommController",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_CommController_PetrolStationId",
                table: "CommController",
                column: "PetrolStationId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_IsDeleted",
                table: "Comment",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_PetrolStationId",
                table: "Comment",
                column: "PetrolStationId");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_IsDeleted",
                table: "Companies",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_FiscalPrinters_IsDeleted",
                table: "FiscalPrinters",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_FiscalPrinters_SimCardId",
                table: "FiscalPrinters",
                column: "SimCardId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FuelDispenser_IsDeleted",
                table: "FuelDispenser",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_FuelDispenser_PetrolStationId",
                table: "FuelDispenser",
                column: "PetrolStationId");

            migrationBuilder.CreateIndex(
                name: "IX_FuelTanks_IsDeleted",
                table: "FuelTanks",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_FuelTanks_PetrolStationId",
                table: "FuelTanks",
                column: "PetrolStationId");

            migrationBuilder.CreateIndex(
                name: "IX_OilLevel_IsDeleted",
                table: "OilLevel",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_PetrolStations_CompanyId",
                table: "PetrolStations",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_PetrolStations_FiscalPrinterId",
                table: "PetrolStations",
                column: "FiscalPrinterId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PetrolStations_IsDeleted",
                table: "PetrolStations",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_PetrolStations_OilLevelId",
                table: "PetrolStations",
                column: "OilLevelId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Probe_IsDeleted",
                table: "Probe",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Probe_OilLevelId",
                table: "Probe",
                column: "OilLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_SimCards_IsDeleted",
                table: "SimCards",
                column: "IsDeleted");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Companies_CompanyId",
                table: "AspNetUsers",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Companies_CompanyId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "CommController");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "FuelDispenser");

            migrationBuilder.DropTable(
                name: "FuelTanks");

            migrationBuilder.DropTable(
                name: "Probe");

            migrationBuilder.DropTable(
                name: "PetrolStations");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "FiscalPrinters");

            migrationBuilder.DropTable(
                name: "OilLevel");

            migrationBuilder.DropTable(
                name: "SimCards");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CompanyId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "AspNetUsers");
        }
    }
}
