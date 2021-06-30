using Microsoft.EntityFrameworkCore.Migrations;

namespace DeloitteProject.Migrations
{
    public partial class updatedUserUploadTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "fileName",
                table: "UserUpload",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "fileName",
                table: "UserUpload");
        }
    }
}
