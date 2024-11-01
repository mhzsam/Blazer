using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRole_Rols_RoleId",
                table: "UserRole");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRole_Users_UserId",
                table: "UserRole");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Rols",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertDate",
                value: new DateTime(2024, 11, 1, 20, 32, 36, 332, DateTimeKind.Local).AddTicks(1981));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertDate",
                value: new DateTime(2024, 11, 1, 20, 32, 36, 333, DateTimeKind.Local).AddTicks(2460));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertDate",
                value: new DateTime(2024, 11, 1, 20, 32, 36, 333, DateTimeKind.Local).AddTicks(92));

            migrationBuilder.AddForeignKey(
                name: "FK_UserRole_Rols_RoleId",
                table: "UserRole",
                column: "RoleId",
                principalTable: "Rols",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRole_Users_UserId",
                table: "UserRole",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRole_Rols_RoleId",
                table: "UserRole");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRole_Users_UserId",
                table: "UserRole");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Rols",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertDate",
                value: new DateTime(2024, 10, 31, 1, 33, 18, 314, DateTimeKind.Local).AddTicks(1453));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertDate",
                value: new DateTime(2024, 10, 31, 1, 33, 18, 314, DateTimeKind.Local).AddTicks(4468));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertDate",
                value: new DateTime(2024, 10, 31, 1, 33, 18, 314, DateTimeKind.Local).AddTicks(3158));

            migrationBuilder.AddForeignKey(
                name: "FK_UserRole_Rols_RoleId",
                table: "UserRole",
                column: "RoleId",
                principalTable: "Rols",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRole_Users_UserId",
                table: "UserRole",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
