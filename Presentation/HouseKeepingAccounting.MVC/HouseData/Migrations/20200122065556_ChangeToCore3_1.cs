using Microsoft.EntityFrameworkCore.Migrations;

namespace HouseData.Migrations
{
    public partial class ChangeToCore3_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FactoryNumber",
                table: "Counters",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "FactoryNumber",
                table: "Counters",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
