using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapi.Data.Migrations
{
    /// <inheritdoc />
    public partial class NewPerson3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "PersonID",
                keyValue: 32);

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

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "PersonID", "Address", "BirthDate", "City", "ClanHouseID", "Email", "FirstName", "GenderID", "Grandparents", "GreatGrandparents", "IsActive", "IsUser", "LastName", "LastUpdatedBy", "LastUpdatedDate", "LoginId", "MiddleName", "Parents", "Password", "ProfilePicPath", "RegisterPara", "Telephone" },
                values: new object[] { 35, "123 Unknown Street", "01/1970", "Johanesburg", 2, "kenny@unknown.com", "House", 1, null, null, true, true, "Second", "Kenneth R Odombe", new DateTime(2023, 6, 6, 8, 18, 11, 912, DateTimeKind.Local).AddTicks(2709), "secondhouse", "Clan", null, "1234", null, null, "1234567890" });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "PersonID",
                keyValue: 35);

            migrationBuilder.UpdateData(
                table: "Person",
                keyColumn: "PersonID",
                keyValue: 1,
                column: "LastUpdatedDate",
                value: new DateTime(2023, 6, 6, 8, 14, 49, 529, DateTimeKind.Local).AddTicks(6300));

            migrationBuilder.UpdateData(
                table: "Person",
                keyColumn: "PersonID",
                keyValue: 28,
                column: "LastUpdatedDate",
                value: new DateTime(2023, 6, 6, 8, 14, 49, 529, DateTimeKind.Local).AddTicks(6424));

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "PersonID", "Address", "BirthDate", "City", "ClanHouseID", "Email", "FirstName", "GenderID", "Grandparents", "GreatGrandparents", "IsActive", "IsUser", "LastName", "LastUpdatedBy", "LastUpdatedDate", "LoginId", "MiddleName", "Parents", "Password", "ProfilePicPath", "RegisterPara", "Telephone" },
                values: new object[] { 32, "123 Unknown Street", "01/1970", "Johanesburg", 2, "kenny@unknown.com", "House", 1, null, null, true, true, "Second", "Kenneth R Odombe", new DateTime(2023, 6, 6, 8, 14, 49, 529, DateTimeKind.Local).AddTicks(6438), "secondhouse", "Clan", null, "1234", null, null, "1234567890" });

            migrationBuilder.UpdateData(
                table: "PersonRole",
                keyColumn: "PersonRoleID",
                keyValue: 1,
                column: "LastUpdatedDate",
                value: new DateTime(2023, 6, 6, 8, 14, 49, 529, DateTimeKind.Local).AddTicks(6499));

            migrationBuilder.UpdateData(
                table: "PersonRole",
                keyColumn: "PersonRoleID",
                keyValue: 9,
                column: "LastUpdatedDate",
                value: new DateTime(2023, 6, 6, 8, 14, 49, 529, DateTimeKind.Local).AddTicks(6511));
        }
    }
}
