using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DL.Migrations
{
    /// <inheritdoc />
    public partial class AddpropertiesonProducttbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 17, 17, 17, 32, 838, DateTimeKind.Local).AddTicks(6572));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 17, 17, 17, 32, 838, DateTimeKind.Local).AddTicks(6584));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 17, 17, 17, 32, 838, DateTimeKind.Local).AddTicks(6585));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 17, 17, 17, 32, 838, DateTimeKind.Local).AddTicks(6586));

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "CreatedOn", "IsDeleted", "Name", "UpdatedOn" },
                values: new object[] { 5, new DateTime(2024, 3, 17, 17, 17, 32, 838, DateTimeKind.Local).AddTicks(6587), false, "Permission.Role", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 17, 17, 17, 32, 838, DateTimeKind.Local).AddTicks(6811));

            migrationBuilder.UpdateData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 17, 17, 17, 32, 838, DateTimeKind.Local).AddTicks(6812));

            migrationBuilder.UpdateData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 17, 17, 17, 32, 838, DateTimeKind.Local).AddTicks(6814));

            migrationBuilder.UpdateData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 17, 17, 17, 32, 838, DateTimeKind.Local).AddTicks(6815));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 17, 17, 17, 32, 838, DateTimeKind.Local).AddTicks(6788));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "PasswordHash" },
                values: new object[] { new DateTime(2024, 3, 17, 17, 17, 32, 838, DateTimeKind.Local).AddTicks(6940), "$2a$11$LF.jO5445FGwpoGW9PGgR.TKNymOmleYKS2vPhTcpqanjMM9stbIC" });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "Id", "CreatedOn", "IsAllowed", "IsDeleted", "PermissionId", "RoleId", "UpdatedOn" },
                values: new object[] { 5, new DateTime(2024, 3, 17, 17, 17, 32, 838, DateTimeKind.Local).AddTicks(6816), true, false, 5, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "Color",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 12, 16, 47, 28, 618, DateTimeKind.Local).AddTicks(7952));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 12, 16, 47, 28, 618, DateTimeKind.Local).AddTicks(7969));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 12, 16, 47, 28, 618, DateTimeKind.Local).AddTicks(7970));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 12, 16, 47, 28, 618, DateTimeKind.Local).AddTicks(7970));

            migrationBuilder.UpdateData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 12, 16, 47, 28, 618, DateTimeKind.Local).AddTicks(8228));

            migrationBuilder.UpdateData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 12, 16, 47, 28, 618, DateTimeKind.Local).AddTicks(8230));

            migrationBuilder.UpdateData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 12, 16, 47, 28, 618, DateTimeKind.Local).AddTicks(8231));

            migrationBuilder.UpdateData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 12, 16, 47, 28, 618, DateTimeKind.Local).AddTicks(8233));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 12, 16, 47, 28, 618, DateTimeKind.Local).AddTicks(8207));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "PasswordHash" },
                values: new object[] { new DateTime(2024, 3, 12, 16, 47, 28, 618, DateTimeKind.Local).AddTicks(8251), "$2a$11$2teQoyykZlxpDQyXltysueHQYTHVo7pWY4RIqmmZxUqIWUMMJsdoW" });
        }
    }
}
