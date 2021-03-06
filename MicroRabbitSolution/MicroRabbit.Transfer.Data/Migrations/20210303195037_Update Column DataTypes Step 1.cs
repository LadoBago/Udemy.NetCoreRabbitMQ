using Microsoft.EntityFrameworkCore.Migrations;

namespace MicroRabbit.Transfer.Data.Migrations
{
    public partial class UpdateColumnDataTypesStep1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FromAccount",
                table: "TransferLogs");

            migrationBuilder.DropColumn(
                name: "ToAccount",
                table: "TransferLogs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FromAccount",
                table: "TransferLogs",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ToAccount",
                table: "TransferLogs",
                type: "text",
                nullable: true);
        }
    }
}
