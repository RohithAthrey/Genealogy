using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapi.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveClanName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Person",
                keyColumn: "PersonID",
                keyValue: 1,
                column: "LastUpdatedDate",
                value: new DateTime(2023, 6, 3, 13, 59, 19, 36, DateTimeKind.Local).AddTicks(7844));

            migrationBuilder.UpdateData(
                table: "PersonRole",
                keyColumn: "PersonRoleID",
                keyValue: 1,
                column: "LastUpdatedDate",
                value: new DateTime(2023, 6, 3, 13, 59, 19, 36, DateTimeKind.Local).AddTicks(8035));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Person",
                keyColumn: "PersonID",
                keyValue: 1,
                column: "LastUpdatedDate",
                value: new DateTime(2023, 6, 3, 10, 59, 24, 612, DateTimeKind.Local).AddTicks(6789));

            migrationBuilder.UpdateData(
                table: "PersonRole",
                keyColumn: "PersonRoleID",
                keyValue: 1,
                column: "LastUpdatedDate",
                value: new DateTime(2023, 6, 3, 10, 59, 24, 612, DateTimeKind.Local).AddTicks(7099));
        }
    }
}
