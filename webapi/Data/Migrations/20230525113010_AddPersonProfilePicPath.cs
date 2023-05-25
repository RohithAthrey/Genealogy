using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapi.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddPersonProfilePicPath : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProfilePicPath",
                table: "Person",
                type: "varchar(128)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Person",
                keyColumn: "PersonID",
                keyValue: 1,
                columns: new[] { "LastUpdatedDate", "ProfilePicPath" },
                values: new object[] { new DateTime(2023, 5, 25, 7, 30, 10, 203, DateTimeKind.Local).AddTicks(1759), null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfilePicPath",
                table: "Person");

            migrationBuilder.UpdateData(
                table: "Person",
                keyColumn: "PersonID",
                keyValue: 1,
                column: "LastUpdatedDate",
                value: new DateTime(2023, 5, 13, 9, 48, 49, 744, DateTimeKind.Local).AddTicks(7810));
        }
    }
}
