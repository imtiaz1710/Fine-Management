using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FineManagement.Infrastructure.Migrations
{
    public partial class userTableConfirmPasswordAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fines_UserTeams_UserTeamId",
                table: "Fines");

            migrationBuilder.AddColumn<string>(
                name: "ConfirmPassword",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "UserTeamId",
                table: "Fines",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Fines_UserTeams_UserTeamId",
                table: "Fines",
                column: "UserTeamId",
                principalTable: "UserTeams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fines_UserTeams_UserTeamId",
                table: "Fines");

            migrationBuilder.DropColumn(
                name: "ConfirmPassword",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "UserTeamId",
                table: "Fines",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Fines_UserTeams_UserTeamId",
                table: "Fines",
                column: "UserTeamId",
                principalTable: "UserTeams",
                principalColumn: "Id");
        }
    }
}
