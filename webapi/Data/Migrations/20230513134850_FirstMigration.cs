using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace webapi.Data.Migrations;

/// <inheritdoc />
public partial class FirstMigration : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Clan",
            columns: table => new
            {
                ClanID = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Name = table.Column<string>(type: "varchar(32)", nullable: false),
                Symbol = table.Column<string>(type: "varchar(32)", nullable: false),
                SubTotem = table.Column<string>(type: "varchar(32)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Clan", x => x.ClanID);
            });

        migrationBuilder.CreateTable(
            name: "Gender",
            columns: table => new
            {
                GenderID = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                GenderCode = table.Column<string>(type: "varchar(16)", nullable: false),
                GenderValue = table.Column<string>(type: "varchar(32)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Gender", x => x.GenderID);
            });

        migrationBuilder.CreateTable(
            name: "RequestType",
            columns: table => new
            {
                RequestTypeID = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                RequestTypeCode = table.Column<string>(type: "varchar(16)", nullable: false),
                RequestTypeValue = table.Column<string>(type: "varchar(32)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_RequestType", x => x.RequestTypeID);
            });

        migrationBuilder.CreateTable(
            name: "Person",
            columns: table => new
            {
                PersonID = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                LastName = table.Column<string>(type: "varchar(32)", nullable: false),
                MiddleName = table.Column<string>(type: "varchar(32)", nullable: false),
                FirstName = table.Column<string>(type: "varchar(32)", nullable: false),
                BirthDate = table.Column<string>(type: "varchar(16)", nullable: false),
                Address = table.Column<string>(type: "varchar(64)", nullable: false),
                City = table.Column<string>(type: "varchar(32)", nullable: false),
                Telephone = table.Column<string>(type: "varchar(16)", nullable: true),
                GenderID = table.Column<int>(type: "int", nullable: false),
                Email = table.Column<string>(type: "varchar(64)", nullable: true),
                LoginId = table.Column<string>(type: "varchar(64)", nullable: false),
                Password = table.Column<string>(type: "varchar(128)", nullable: true),
                IsActive = table.Column<bool>(type: "bit", nullable: false),
                IsUser = table.Column<bool>(type: "bit", nullable: false),
                LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                LastUpdatedBy = table.Column<string>(type: "varchar(128)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Person", x => x.PersonID);
                table.ForeignKey(
                    name: "FK_Person_Gender_GenderID",
                    column: x => x.GenderID,
                    principalTable: "Gender",
                    principalColumn: "GenderID",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "PersonClanRequest",
            columns: table => new
            {
                PersonClanRequestID = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                PersonID = table.Column<int>(type: "int", nullable: false),
                ClanID = table.Column<int>(type: "int", nullable: false),
                RequestTypeID = table.Column<int>(type: "int", nullable: false),
                LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                LastUpdatedBy = table.Column<string>(type: "varchar(128)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_PersonClanRequest", x => x.PersonClanRequestID);
                table.ForeignKey(
                    name: "FK_PersonClanRequest_Clan_ClanID",
                    column: x => x.ClanID,
                    principalTable: "Clan",
                    principalColumn: "ClanID",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_PersonClanRequest_Person_PersonID",
                    column: x => x.PersonID,
                    principalTable: "Person",
                    principalColumn: "PersonID",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_PersonClanRequest_RequestType_RequestTypeID",
                    column: x => x.RequestTypeID,
                    principalTable: "RequestType",
                    principalColumn: "RequestTypeID",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.InsertData(
            table: "Clan",
            columns: new[] { "ClanID", "Name", "SubTotem", "Symbol" },
            values: new object[] { 1, "Njovu", "Hippopotamus", "Elephant" });

        migrationBuilder.InsertData(
            table: "Gender",
            columns: new[] { "GenderID", "GenderCode", "GenderValue" },
            values: new object[,]
            {
                { 1, "M", "Male" },
                { 2, "F", "Female" }
            });

        migrationBuilder.InsertData(
            table: "RequestType",
            columns: new[] { "RequestTypeID", "RequestTypeCode", "RequestTypeValue" },
            values: new object[,]
            {
                { 1, "R", "Requested" },
                { 2, "A", "Approved" },
                { 3, "D", "Declined" }
            });

        migrationBuilder.InsertData(
            table: "Person",
            columns: new[] { "PersonID", "Address", "BirthDate", "City", "Email", "FirstName", "GenderID", "IsActive", "IsUser", "LastName", "LastUpdatedBy", "LastUpdatedDate", "LoginId", "MiddleName", "Password", "Telephone" },
            values: new object[] { 1, "123 Unknown Street", "01/1970", "Johanesburg", "kenny@unknown.com", "Kenneth", 1, true, true, "Odombe", "Kenneth R Odombe", new DateTime(2023, 5, 13, 9, 48, 49, 744, DateTimeKind.Local).AddTicks(7810), "kenny", "R", "1234", "1234567890" });

        migrationBuilder.CreateIndex(
            name: "IX_Person_GenderID",
            table: "Person",
            column: "GenderID");

        migrationBuilder.CreateIndex(
            name: "IX_PersonClanRequest_ClanID",
            table: "PersonClanRequest",
            column: "ClanID");

        migrationBuilder.CreateIndex(
            name: "IX_PersonClanRequest_PersonID",
            table: "PersonClanRequest",
            column: "PersonID");

        migrationBuilder.CreateIndex(
            name: "IX_PersonClanRequest_RequestTypeID",
            table: "PersonClanRequest",
            column: "RequestTypeID");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "PersonClanRequest");

        migrationBuilder.DropTable(
            name: "Clan");

        migrationBuilder.DropTable(
            name: "Person");

        migrationBuilder.DropTable(
            name: "RequestType");

        migrationBuilder.DropTable(
            name: "Gender");
    }
}
