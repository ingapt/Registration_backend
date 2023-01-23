using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Registrationbackend.Migrations
{
    /// <inheritdoc />
    public partial class test2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_UsersInfo_AddressOfUserInfoId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersInfo_Users_UserInfoOfUserId",
                table: "UsersInfo");

            migrationBuilder.DropIndex(
                name: "IX_UsersInfo_UserInfoOfUserId",
                table: "UsersInfo");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_AddressOfUserInfoId",
                table: "Addresses");

            migrationBuilder.AlterColumn<int>(
                name: "UserInfoOfUserId",
                table: "UsersInfo",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AddressOfUserInfoId",
                table: "Addresses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_UsersInfo_UserInfoOfUserId",
                table: "UsersInfo",
                column: "UserInfoOfUserId",
                unique: true,
                filter: "[UserInfoOfUserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_AddressOfUserInfoId",
                table: "Addresses",
                column: "AddressOfUserInfoId",
                unique: true,
                filter: "[AddressOfUserInfoId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_UsersInfo_AddressOfUserInfoId",
                table: "Addresses",
                column: "AddressOfUserInfoId",
                principalTable: "UsersInfo",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersInfo_Users_UserInfoOfUserId",
                table: "UsersInfo",
                column: "UserInfoOfUserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_UsersInfo_AddressOfUserInfoId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersInfo_Users_UserInfoOfUserId",
                table: "UsersInfo");

            migrationBuilder.DropIndex(
                name: "IX_UsersInfo_UserInfoOfUserId",
                table: "UsersInfo");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_AddressOfUserInfoId",
                table: "Addresses");

            migrationBuilder.AlterColumn<int>(
                name: "UserInfoOfUserId",
                table: "UsersInfo",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AddressOfUserInfoId",
                table: "Addresses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsersInfo_UserInfoOfUserId",
                table: "UsersInfo",
                column: "UserInfoOfUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_AddressOfUserInfoId",
                table: "Addresses",
                column: "AddressOfUserInfoId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_UsersInfo_AddressOfUserInfoId",
                table: "Addresses",
                column: "AddressOfUserInfoId",
                principalTable: "UsersInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersInfo_Users_UserInfoOfUserId",
                table: "UsersInfo",
                column: "UserInfoOfUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
