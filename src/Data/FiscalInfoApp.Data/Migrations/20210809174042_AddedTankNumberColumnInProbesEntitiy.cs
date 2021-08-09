using Microsoft.EntityFrameworkCore.Migrations;

namespace FiscalInfoApp.Data.Migrations
{
    public partial class AddedTankNumberColumnInProbesEntitiy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TankNumber",
                table: "Probes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TankNumber",
                table: "Probes");
        }
    }
}
