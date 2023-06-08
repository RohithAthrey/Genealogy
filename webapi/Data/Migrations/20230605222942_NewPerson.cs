using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapi.Data.Migrations
{
    /// <inheritdoc />
    public partial class NewPerson : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Person",
                keyColumn: "PersonID",
                keyValue: 1,
                column: "LastUpdatedDate",
                value: new DateTime(2023, 6, 5, 18, 29, 41, 164, DateTimeKind.Local).AddTicks(7106));

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "PersonID", "Address", "BirthDate", "City", "ClanHouseID", "Email", "FirstName", "GenderID", "Grandparents", "GreatGrandparents", "IsActive", "IsUser", "LastName", "LastUpdatedBy", "LastUpdatedDate", "LoginId", "MiddleName", "Parents", "Password", "ProfilePicPath", "RegisterPara", "Telephone" },
                values: new object[] { 28, "123 Unknown Street", "01/1970", "Johanesburg", 0, "kenny@unknown.com", "House", 1, null, null, true, true, "First", "Kenneth R Odombe", new DateTime(2023, 6, 5, 18, 29, 41, 164, DateTimeKind.Local).AddTicks(7235), "firsthouse", "Clan", null, "1234", null, null, "1234567890" });

            migrationBuilder.UpdateData(
                table: "PersonRole",
                keyColumn: "PersonRoleID",
                keyValue: 1,
                column: "LastUpdatedDate",
                value: new DateTime(2023, 6, 5, 18, 29, 41, 164, DateTimeKind.Local).AddTicks(7347));

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "RoleID", "RoleDesc", "RoleName" },
                values: new object[] { 3, "Clan Leader role", "Clan Leader" });

            migrationBuilder.InsertData(
                table: "PersonRole",
                columns: new[] { "PersonRoleID", "IsActive", "LastUpdatedBy", "LastUpdatedDate", "PersonID", "RoleID" },
                values: new object[] { 9, true, "Kenneth R Odombe", new DateTime(2023, 6, 5, 18, 29, 41, 164, DateTimeKind.Local).AddTicks(7369), 28, 3 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PersonRole",
                keyColumn: "PersonRoleID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "PersonID",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "RoleID",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Person",
                keyColumn: "PersonID",
                keyValue: 1,
                column: "LastUpdatedDate",
                value: new DateTime(2023, 6, 5, 17, 27, 18, 125, DateTimeKind.Local).AddTicks(8470));

            migrationBuilder.UpdateData(
                table: "PersonRole",
                keyColumn: "PersonRoleID",
                keyValue: 1,
                column: "LastUpdatedDate",
                value: new DateTime(2023, 6, 5, 17, 27, 18, 125, DateTimeKind.Local).AddTicks(8803));
        }
    }
}
