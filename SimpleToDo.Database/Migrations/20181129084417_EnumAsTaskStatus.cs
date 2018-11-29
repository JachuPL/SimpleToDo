using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleToDo.Database.Migrations
{
    public partial class EnumAsTaskStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Tasks",
                nullable: false,
                oldClrType: typeof(bool));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                table: "Tasks",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
