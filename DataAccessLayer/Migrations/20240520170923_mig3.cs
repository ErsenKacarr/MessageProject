using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class mig3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserMessages_Users_UserId",
                table: "UserMessages");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "UserMessages",
                newName: "Subject");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "UserMessages",
                newName: "SenderName");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "UserMessages",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "MessageContent",
                table: "UserMessages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Receiver",
                table: "UserMessages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ReceiverName",
                table: "UserMessages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Sender",
                table: "UserMessages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_UserMessages_Users_UserId",
                table: "UserMessages",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserMessages_Users_UserId",
                table: "UserMessages");

            migrationBuilder.DropColumn(
                name: "MessageContent",
                table: "UserMessages");

            migrationBuilder.DropColumn(
                name: "Receiver",
                table: "UserMessages");

            migrationBuilder.DropColumn(
                name: "ReceiverName",
                table: "UserMessages");

            migrationBuilder.DropColumn(
                name: "Sender",
                table: "UserMessages");

            migrationBuilder.RenameColumn(
                name: "Subject",
                table: "UserMessages",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "SenderName",
                table: "UserMessages",
                newName: "Content");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "UserMessages",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserMessages_Users_UserId",
                table: "UserMessages",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
