using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api_One_Trick_Pony_Br.Migrations
{
    /// <inheritdoc />
    public partial class SegundaMigracao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Account_AuthorId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Account_PonyId",
                table: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_Comment_AuthorId",
                table: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_Comment_PonyId",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "PonyId",
                table: "Comment");

            migrationBuilder.AlterColumn<string>(
                name: "Message",
                table: "Comment",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AutorID",
                table: "Comment",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MonochampId",
                table: "Comment",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Comment_MonochampId",
                table: "Comment",
                column: "MonochampId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Account_MonochampId",
                table: "Comment",
                column: "MonochampId",
                principalTable: "Account",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Account_MonochampId",
                table: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_Comment_MonochampId",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "AutorID",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "MonochampId",
                table: "Comment");

            migrationBuilder.AlterColumn<string>(
                name: "Message",
                table: "Comment",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                table: "Comment",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PonyId",
                table: "Comment",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comment_AuthorId",
                table: "Comment",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_PonyId",
                table: "Comment",
                column: "PonyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Account_AuthorId",
                table: "Comment",
                column: "AuthorId",
                principalTable: "Account",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Account_PonyId",
                table: "Comment",
                column: "PonyId",
                principalTable: "Account",
                principalColumn: "Id");
        }
    }
}
