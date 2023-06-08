using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapi.Data.Migrations
{
    /// <inheritdoc />
    public partial class NewPersonRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Person",
                keyColumn: "PersonID",
                keyValue: 1,
                column: "LastUpdatedDate",
                value: new DateTime(2023, 6, 6, 8, 27, 49, 175, DateTimeKind.Local).AddTicks(4473));

            migrationBuilder.UpdateData(
                table: "Person",
                keyColumn: "PersonID",
                keyValue: 28,
                column: "LastUpdatedDate",
                value: new DateTime(2023, 6, 6, 8, 27, 49, 175, DateTimeKind.Local).AddTicks(4595));

            migrationBuilder.UpdateData(
                table: "Person",
                keyColumn: "PersonID",
                keyValue: 35,
                column: "LastUpdatedDate",
                value: new DateTime(2023, 6, 6, 8, 27, 49, 175, DateTimeKind.Local).AddTicks(4610));

            migrationBuilder.UpdateData(
                table: "PersonRole",
                keyColumn: "PersonRoleID",
                keyValue: 1,
                column: "LastUpdatedDate",
                value: new DateTime(2023, 6, 6, 8, 27, 49, 175, DateTimeKind.Local).AddTicks(4674));

            migrationBuilder.UpdateData(
                table: "PersonRole",
                keyColumn: "PersonRoleID",
                keyValue: 9,
                column: "LastUpdatedDate",
                value: new DateTime(2023, 6, 6, 8, 27, 49, 175, DateTimeKind.Local).AddTicks(4685));

            migrationBuilder.InsertData(
                table: "PersonRole",
                columns: new[] { "PersonRoleID", "IsActive", "LastUpdatedBy", "LastUpdatedDate", "PersonID", "RoleID" },
                values: new object[] { 11, true, "Kenneth R Odombe", new DateTime(2023, 6, 6, 8, 27, 49, 175, DateTimeKind.Local).AddTicks(4694), 35, 3 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PersonRole",
                keyColumn: "PersonRoleID",
                keyValue: 11);

            migrationBuilder.UpdateData(
                table: "Person",
                keyColumn: "PersonID",
                keyValue: 1,
                column: "LastUpdatedDate",
                value: new DateTime(2023, 6, 6, 8, 18, 11, 912, DateTimeKind.Local).AddTicks(2572));

            migrationBuilder.UpdateData(
                table: "Person",
                keyColumn: "PersonID",
                keyValue: 28,
                column: "LastUpdatedDate",
                value: new DateTime(2023, 6, 6, 8, 18, 11, 912, DateTimeKind.Local).AddTicks(2693));

            migrationBuilder.UpdateData(
                table: "Person",
                keyColumn: "PersonID",
                keyValue: 35,
                column: "LastUpdatedDate",
                value: new DateTime(2023, 6, 6, 8, 18, 11, 912, DateTimeKind.Local).AddTicks(2709));

            migrationBuilder.UpdateData(
                table: "PersonRole",
                keyColumn: "PersonRoleID",
                keyValue: 1,
                column: "LastUpdatedDate",
                value: new DateTime(2023, 6, 6, 8, 18, 11, 912, DateTimeKind.Local).AddTicks(2767));

            migrationBuilder.UpdateData(
                table: "PersonRole",
                keyColumn: "PersonRoleID",
                keyValue: 9,
                column: "LastUpdatedDate",
                value: new DateTime(2023, 6, 6, 8, 18, 11, 912, DateTimeKind.Local).AddTicks(2778));
        }
    }
}
