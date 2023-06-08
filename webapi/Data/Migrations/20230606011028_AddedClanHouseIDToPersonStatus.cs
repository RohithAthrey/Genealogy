using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapi.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedClanHouseIDToPersonStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Person",
                keyColumn: "PersonID",
                keyValue: 1,
                column: "LastUpdatedDate",
                value: new DateTime(2023, 6, 5, 21, 10, 28, 245, DateTimeKind.Local).AddTicks(7212));

            migrationBuilder.UpdateData(
                table: "Person",
                keyColumn: "PersonID",
                keyValue: 28,
                column: "LastUpdatedDate",
                value: new DateTime(2023, 6, 5, 21, 10, 28, 245, DateTimeKind.Local).AddTicks(7329));

            migrationBuilder.UpdateData(
                table: "PersonRole",
                keyColumn: "PersonRoleID",
                keyValue: 1,
                column: "LastUpdatedDate",
                value: new DateTime(2023, 6, 5, 21, 10, 28, 245, DateTimeKind.Local).AddTicks(7393));

            migrationBuilder.UpdateData(
                table: "PersonRole",
                keyColumn: "PersonRoleID",
                keyValue: 9,
                column: "LastUpdatedDate",
                value: new DateTime(2023, 6, 5, 21, 10, 28, 245, DateTimeKind.Local).AddTicks(7406));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Person",
                keyColumn: "PersonID",
                keyValue: 1,
                column: "LastUpdatedDate",
                value: new DateTime(2023, 6, 5, 18, 34, 1, 66, DateTimeKind.Local).AddTicks(5032));

            migrationBuilder.UpdateData(
                table: "Person",
                keyColumn: "PersonID",
                keyValue: 28,
                column: "LastUpdatedDate",
                value: new DateTime(2023, 6, 5, 18, 34, 1, 66, DateTimeKind.Local).AddTicks(5150));

            migrationBuilder.UpdateData(
                table: "PersonRole",
                keyColumn: "PersonRoleID",
                keyValue: 1,
                column: "LastUpdatedDate",
                value: new DateTime(2023, 6, 5, 18, 34, 1, 66, DateTimeKind.Local).AddTicks(5208));

            migrationBuilder.UpdateData(
                table: "PersonRole",
                keyColumn: "PersonRoleID",
                keyValue: 9,
                column: "LastUpdatedDate",
                value: new DateTime(2023, 6, 5, 18, 34, 1, 66, DateTimeKind.Local).AddTicks(5220));
        }
    }
}
