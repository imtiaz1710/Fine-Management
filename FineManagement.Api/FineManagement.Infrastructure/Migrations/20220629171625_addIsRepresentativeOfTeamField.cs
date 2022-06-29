using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FineManagement.Infrastructure.Migrations
{
    public partial class addIsRepresentativeOfTeamField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsRepresentativeOfTeam",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRepresentativeOfTeam",
                table: "Users");
        }
    }
}
