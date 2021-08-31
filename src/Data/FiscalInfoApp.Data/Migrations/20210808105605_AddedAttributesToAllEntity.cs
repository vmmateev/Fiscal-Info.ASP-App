namespace FiscalInfoApp.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddedAttributesToAllEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommController_PetrolStations_PetrolStationId",
                table: "CommController");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_PetrolStations_PetrolStationId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_FuelDispenser_PetrolStations_PetrolStationId",
                table: "FuelDispenser");

            migrationBuilder.DropForeignKey(
                name: "FK_PetrolStations_OilLevel_OilLevelId",
                table: "PetrolStations");

            migrationBuilder.DropForeignKey(
                name: "FK_Probe_OilLevel_OilLevelId",
                table: "Probe");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Probe",
                table: "Probe");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OilLevel",
                table: "OilLevel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FuelDispenser",
                table: "FuelDispenser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comment",
                table: "Comment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CommController",
                table: "CommController");

            migrationBuilder.RenameTable(
                name: "Probe",
                newName: "Probes");

            migrationBuilder.RenameTable(
                name: "OilLevel",
                newName: "OilLevels");

            migrationBuilder.RenameTable(
                name: "FuelDispenser",
                newName: "FuelDispensers");

            migrationBuilder.RenameTable(
                name: "Comment",
                newName: "Comments");

            migrationBuilder.RenameTable(
                name: "CommController",
                newName: "CommControllers");

            migrationBuilder.RenameIndex(
                name: "IX_Probe_OilLevelId",
                table: "Probes",
                newName: "IX_Probes_OilLevelId");

            migrationBuilder.RenameIndex(
                name: "IX_Probe_IsDeleted",
                table: "Probes",
                newName: "IX_Probes_IsDeleted");

            migrationBuilder.RenameIndex(
                name: "IX_OilLevel_IsDeleted",
                table: "OilLevels",
                newName: "IX_OilLevels_IsDeleted");

            migrationBuilder.RenameIndex(
                name: "IX_FuelDispenser_PetrolStationId",
                table: "FuelDispensers",
                newName: "IX_FuelDispensers_PetrolStationId");

            migrationBuilder.RenameIndex(
                name: "IX_FuelDispenser_IsDeleted",
                table: "FuelDispensers",
                newName: "IX_FuelDispensers_IsDeleted");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_PetrolStationId",
                table: "Comments",
                newName: "IX_Comments_PetrolStationId");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_IsDeleted",
                table: "Comments",
                newName: "IX_Comments_IsDeleted");

            migrationBuilder.RenameIndex(
                name: "IX_CommController_PetrolStationId",
                table: "CommControllers",
                newName: "IX_CommControllers_PetrolStationId");

            migrationBuilder.RenameIndex(
                name: "IX_CommController_IsDeleted",
                table: "CommControllers",
                newName: "IX_CommControllers_IsDeleted");

            migrationBuilder.AlterColumn<string>(
                name: "OperatorName",
                table: "SimCards",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Imsi",
                table: "SimCards",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "GsmNumber",
                table: "SimCards",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Street",
                table: "PetrolStations",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "PetrolStations",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "PetrolStations",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "FullVolume",
                table: "FuelTanks",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "FuelType",
                table: "FuelTanks",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "OsNumber",
                table: "FiscalPrinters",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MemoryNumber",
                table: "FiscalPrinters",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Fdrid",
                table: "FiscalPrinters",
                type: "nvarchar(7)",
                maxLength: 7,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Street",
                table: "Companies",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Companies",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Companies",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FloatFuelType",
                table: "Probes",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Model",
                table: "OilLevels",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Brand",
                table: "OilLevels",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Model",
                table: "FuelDispensers",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MidCertificate",
                table: "FuelDispensers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Brand",
                table: "FuelDispensers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Comments",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CommType",
                table: "CommControllers",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BoxColor",
                table: "CommControllers",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Probes",
                table: "Probes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OilLevels",
                table: "OilLevels",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FuelDispensers",
                table: "FuelDispensers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommControllers",
                table: "CommControllers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CommControllers_PetrolStations_PetrolStationId",
                table: "CommControllers",
                column: "PetrolStationId",
                principalTable: "PetrolStations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_PetrolStations_PetrolStationId",
                table: "Comments",
                column: "PetrolStationId",
                principalTable: "PetrolStations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FuelDispensers_PetrolStations_PetrolStationId",
                table: "FuelDispensers",
                column: "PetrolStationId",
                principalTable: "PetrolStations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PetrolStations_OilLevels_OilLevelId",
                table: "PetrolStations",
                column: "OilLevelId",
                principalTable: "OilLevels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Probes_OilLevels_OilLevelId",
                table: "Probes",
                column: "OilLevelId",
                principalTable: "OilLevels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommControllers_PetrolStations_PetrolStationId",
                table: "CommControllers");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_PetrolStations_PetrolStationId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_FuelDispensers_PetrolStations_PetrolStationId",
                table: "FuelDispensers");

            migrationBuilder.DropForeignKey(
                name: "FK_PetrolStations_OilLevels_OilLevelId",
                table: "PetrolStations");

            migrationBuilder.DropForeignKey(
                name: "FK_Probes_OilLevels_OilLevelId",
                table: "Probes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Probes",
                table: "Probes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OilLevels",
                table: "OilLevels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FuelDispensers",
                table: "FuelDispensers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CommControllers",
                table: "CommControllers");

            migrationBuilder.RenameTable(
                name: "Probes",
                newName: "Probe");

            migrationBuilder.RenameTable(
                name: "OilLevels",
                newName: "OilLevel");

            migrationBuilder.RenameTable(
                name: "FuelDispensers",
                newName: "FuelDispenser");

            migrationBuilder.RenameTable(
                name: "Comments",
                newName: "Comment");

            migrationBuilder.RenameTable(
                name: "CommControllers",
                newName: "CommController");

            migrationBuilder.RenameIndex(
                name: "IX_Probes_OilLevelId",
                table: "Probe",
                newName: "IX_Probe_OilLevelId");

            migrationBuilder.RenameIndex(
                name: "IX_Probes_IsDeleted",
                table: "Probe",
                newName: "IX_Probe_IsDeleted");

            migrationBuilder.RenameIndex(
                name: "IX_OilLevels_IsDeleted",
                table: "OilLevel",
                newName: "IX_OilLevel_IsDeleted");

            migrationBuilder.RenameIndex(
                name: "IX_FuelDispensers_PetrolStationId",
                table: "FuelDispenser",
                newName: "IX_FuelDispenser_PetrolStationId");

            migrationBuilder.RenameIndex(
                name: "IX_FuelDispensers_IsDeleted",
                table: "FuelDispenser",
                newName: "IX_FuelDispenser_IsDeleted");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_PetrolStationId",
                table: "Comment",
                newName: "IX_Comment_PetrolStationId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_IsDeleted",
                table: "Comment",
                newName: "IX_Comment_IsDeleted");

            migrationBuilder.RenameIndex(
                name: "IX_CommControllers_PetrolStationId",
                table: "CommController",
                newName: "IX_CommController_PetrolStationId");

            migrationBuilder.RenameIndex(
                name: "IX_CommControllers_IsDeleted",
                table: "CommController",
                newName: "IX_CommController_IsDeleted");

            migrationBuilder.AlterColumn<string>(
                name: "OperatorName",
                table: "SimCards",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "Imsi",
                table: "SimCards",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "GsmNumber",
                table: "SimCards",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(12)",
                oldMaxLength: 12);

            migrationBuilder.AlterColumn<string>(
                name: "Street",
                table: "PetrolStations",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(40)",
                oldMaxLength: 40);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "PetrolStations",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "PetrolStations",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<int>(
                name: "FullVolume",
                table: "FuelTanks",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<string>(
                name: "FuelType",
                table: "FuelTanks",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "OsNumber",
                table: "FiscalPrinters",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(8)",
                oldMaxLength: 8);

            migrationBuilder.AlterColumn<string>(
                name: "MemoryNumber",
                table: "FiscalPrinters",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(8)",
                oldMaxLength: 8);

            migrationBuilder.AlterColumn<string>(
                name: "Fdrid",
                table: "FiscalPrinters",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(7)",
                oldMaxLength: 7,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Street",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(40)",
                oldMaxLength: 40,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "FloatFuelType",
                table: "Probe",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "Model",
                table: "OilLevel",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "Brand",
                table: "OilLevel",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Model",
                table: "FuelDispenser",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MidCertificate",
                table: "FuelDispenser",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Brand",
                table: "FuelDispenser",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Comment",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CommType",
                table: "CommController",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "BoxColor",
                table: "CommController",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Probe",
                table: "Probe",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OilLevel",
                table: "OilLevel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FuelDispenser",
                table: "FuelDispenser",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comment",
                table: "Comment",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommController",
                table: "CommController",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CommController_PetrolStations_PetrolStationId",
                table: "CommController",
                column: "PetrolStationId",
                principalTable: "PetrolStations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_PetrolStations_PetrolStationId",
                table: "Comment",
                column: "PetrolStationId",
                principalTable: "PetrolStations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FuelDispenser_PetrolStations_PetrolStationId",
                table: "FuelDispenser",
                column: "PetrolStationId",
                principalTable: "PetrolStations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PetrolStations_OilLevel_OilLevelId",
                table: "PetrolStations",
                column: "OilLevelId",
                principalTable: "OilLevel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Probe_OilLevel_OilLevelId",
                table: "Probe",
                column: "OilLevelId",
                principalTable: "OilLevel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
