using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEBSITESTEFANKEZDI.Data.Migrations
{
    public partial class URLNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "URL",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "URL",
                table: "Articles");
        }
    }
}
