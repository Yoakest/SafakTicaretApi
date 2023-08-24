using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SafakTicaret.Persistence.Migrations
{
    public partial class _13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OrderCode",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderCode",
                table: "Orders");
        }
    }
}
