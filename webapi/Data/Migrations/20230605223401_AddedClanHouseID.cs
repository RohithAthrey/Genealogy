﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapi.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedClanHouseID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                columns: new[] { "ClanHouseID", "LastUpdatedDate" },
                values: new object[] { 1, new DateTime(2023, 6, 5, 18, 34, 1, 66, DateTimeKind.Local).AddTicks(5150) });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Person",
                keyColumn: "PersonID",
                keyValue: 1,
                column: "LastUpdatedDate",
                value: new DateTime(2023, 6, 5, 18, 29, 41, 164, DateTimeKind.Local).AddTicks(7106));

            migrationBuilder.UpdateData(
                table: "Person",
                keyColumn: "PersonID",
                keyValue: 28,
                columns: new[] { "ClanHouseID", "LastUpdatedDate" },
                values: new object[] { 0, new DateTime(2023, 6, 5, 18, 29, 41, 164, DateTimeKind.Local).AddTicks(7235) });

            migrationBuilder.UpdateData(
                table: "PersonRole",
                keyColumn: "PersonRoleID",
                keyValue: 1,
                column: "LastUpdatedDate",
                value: new DateTime(2023, 6, 5, 18, 29, 41, 164, DateTimeKind.Local).AddTicks(7347));

            migrationBuilder.UpdateData(
                table: "PersonRole",
                keyColumn: "PersonRoleID",
                keyValue: 9,
                column: "LastUpdatedDate",
                value: new DateTime(2023, 6, 5, 18, 29, 41, 164, DateTimeKind.Local).AddTicks(7369));
        }
    }
}