using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapi.Data.Migrations
{
    /// <inheritdoc />
    public partial class RenamedClanHouse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ClanHouse",
                keyColumn: "ClanHouseID",
                keyValue: 3,
                column: "ClanHouseName",
                value: "ThirdHouse");

            migrationBuilder.UpdateData(
                table: "ClanHouse",
                keyColumn: "ClanHouseID",
                keyValue: 4,
                column: "ClanHouseName",
                value: "FourthHouse");

            migrationBuilder.UpdateData(
                table: "Person",
                keyColumn: "PersonID",
                keyValue: 1,
                column: "LastUpdatedDate",
                value: new DateTime(2023, 6, 8, 8, 27, 31, 4, DateTimeKind.Local).AddTicks(236));

            migrationBuilder.UpdateData(
                table: "Person",
                keyColumn: "PersonID",
                keyValue: 28,
                column: "LastUpdatedDate",
                value: new DateTime(2023, 6, 8, 8, 27, 31, 4, DateTimeKind.Local).AddTicks(360));

            migrationBuilder.UpdateData(
                table: "Person",
                keyColumn: "PersonID",
                keyValue: 35,
                column: "LastUpdatedDate",
                value: new DateTime(2023, 6, 8, 8, 27, 31, 4, DateTimeKind.Local).AddTicks(375));

            migrationBuilder.UpdateData(
                table: "PersonRole",
                keyColumn: "PersonRoleID",
                keyValue: 1,
                column: "LastUpdatedDate",
                value: new DateTime(2023, 6, 8, 8, 27, 31, 4, DateTimeKind.Local).AddTicks(439));

            migrationBuilder.UpdateData(
                table: "PersonRole",
                keyColumn: "PersonRoleID",
                keyValue: 9,
                column: "LastUpdatedDate",
                value: new DateTime(2023, 6, 8, 8, 27, 31, 4, DateTimeKind.Local).AddTicks(450));

            migrationBuilder.UpdateData(
                table: "PersonRole",
                keyColumn: "PersonRoleID",
                keyValue: 11,
                column: "LastUpdatedDate",
                value: new DateTime(2023, 6, 8, 8, 27, 31, 4, DateTimeKind.Local).AddTicks(460));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ClanHouse",
                keyColumn: "ClanHouseID",
                keyValue: 3,
                column: "ClanHouseName",
                value: "SecondClan2House");

            migrationBuilder.UpdateData(
                table: "ClanHouse",
                keyColumn: "ClanHouseID",
                keyValue: 4,
                column: "ClanHouseName",
                value: "SecondClan2House");

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

            migrationBuilder.UpdateData(
                table: "PersonRole",
                keyColumn: "PersonRoleID",
                keyValue: 11,
                column: "LastUpdatedDate",
                value: new DateTime(2023, 6, 6, 8, 27, 49, 175, DateTimeKind.Local).AddTicks(4694));
        }
    }
}
