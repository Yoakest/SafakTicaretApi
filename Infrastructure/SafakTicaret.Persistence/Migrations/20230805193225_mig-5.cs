using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SafakTicaret.Persistence.Migrations
{
    public partial class mig5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Showcase",
                table: "UploadFiles",
                type: "bit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Showcase",
                table: "UploadFiles");
        }
    }
}
