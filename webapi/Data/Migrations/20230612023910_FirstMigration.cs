using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace webapi.Data.Migrations
{
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
                    ClanID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Symbol = table.Column<string>(type: "TEXT", nullable: false),
                    SubTotem = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clan", x => x.ClanID);
                });

            migrationBuilder.CreateTable(
                name: "Gender",
                columns: table => new
                {
                    GenderID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GenderCode = table.Column<string>(type: "TEXT", nullable: false),
                    GenderValue = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gender", x => x.GenderID);
                });

            migrationBuilder.CreateTable(
                name: "RequestType",
                columns: table => new
                {
                    RequestTypeID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RequestTypeCode = table.Column<string>(type: "varchar(16)", nullable: false),
                    RequestTypeValue = table.Column<string>(type: "varchar(32)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestType", x => x.RequestTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    RoleID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleName = table.Column<string>(type: "TEXT", nullable: false),
                    RoleDesc = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "ClanHouse",
                columns: table => new
                {
                    ClanHouseID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClanHouseName = table.Column<string>(type: "TEXT", nullable: false),
                    ClanID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClanHouse", x => x.ClanHouseID);
                    table.ForeignKey(
                        name: "FK_ClanHouse_Clan_ClanID",
                        column: x => x.ClanID,
                        principalTable: "Clan",
                        principalColumn: "ClanID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    PersonID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    MiddleName = table.Column<string>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    BirthDate = table.Column<string>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: false),
                    City = table.Column<string>(type: "TEXT", nullable: false),
                    Telephone = table.Column<string>(type: "TEXT", nullable: true),
                    GenderID = table.Column<int>(type: "INTEGER", nullable: false),
                    ClanHouseID = table.Column<int>(type: "INTEGER", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    LoginId = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: true),
                    ProfilePicPath = table.Column<string>(type: "TEXT", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsUser = table.Column<bool>(type: "INTEGER", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastUpdatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    RegisterPara = table.Column<string>(type: "TEXT", nullable: true),
                    Grandparents = table.Column<string>(type: "TEXT", nullable: true),
                    Parents = table.Column<string>(type: "TEXT", nullable: true),
                    GreatGrandparents = table.Column<string>(type: "TEXT", nullable: true)
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
                name: "PersonClanHouseRequest",
                columns: table => new
                {
                    PersonClanHouseRequestID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PersonID = table.Column<int>(type: "INTEGER", nullable: false),
                    ClanHouseID = table.Column<int>(type: "INTEGER", nullable: false),
                    RequestTypeID = table.Column<int>(type: "INTEGER", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastUpdatedBy = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonClanHouseRequest", x => x.PersonClanHouseRequestID);
                    table.ForeignKey(
                        name: "FK_PersonClanHouseRequest_ClanHouse_ClanHouseID",
                        column: x => x.ClanHouseID,
                        principalTable: "ClanHouse",
                        principalColumn: "ClanHouseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonClanHouseRequest_Person_PersonID",
                        column: x => x.PersonID,
                        principalTable: "Person",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonClanHouseRequest_RequestType_RequestTypeID",
                        column: x => x.RequestTypeID,
                        principalTable: "RequestType",
                        principalColumn: "RequestTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonRole",
                columns: table => new
                {
                    PersonRoleID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PersonID = table.Column<int>(type: "INTEGER", nullable: false),
                    RoleID = table.Column<int>(type: "INTEGER", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastUpdatedBy = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonRole", x => x.PersonRoleID);
                    table.ForeignKey(
                        name: "FK_PersonRole_Person_PersonID",
                        column: x => x.PersonID,
                        principalTable: "Person",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonRole_Role_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Role",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Clan",
                columns: new[] { "ClanID", "Name", "SubTotem", "Symbol" },
                values: new object[,]
                {
                    { 1, "Njovu", "Hippopotamus", "Elephant" },
                    { 2, "Clan2", "Hippopotamus", "Elephant" }
                });

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
                table: "Role",
                columns: new[] { "RoleID", "RoleDesc", "RoleName" },
                values: new object[,]
                {
                    { 1, "Admin role", "Admin" },
                    { 2, "User role", "User" },
                    { 3, "Clan Leader role", "Clan Leader" }
                });

            migrationBuilder.InsertData(
                table: "ClanHouse",
                columns: new[] { "ClanHouseID", "ClanHouseName", "ClanID" },
                values: new object[,]
                {
                    { 1, "FirstClanHouse", 1 },
                    { 2, "SecondClanHouse", 1 },
                    { 3, "ThirdHouse", 2 },
                    { 4, "FourthHouse", 2 }
                });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "PersonID", "Address", "BirthDate", "City", "ClanHouseID", "Email", "FirstName", "GenderID", "Grandparents", "GreatGrandparents", "IsActive", "IsUser", "LastName", "LastUpdatedBy", "LastUpdatedDate", "LoginId", "MiddleName", "Parents", "Password", "ProfilePicPath", "RegisterPara", "Telephone" },
                values: new object[,]
                {
                    { 1, "123 Unknown Street", "01/1970", "Johanesburg", 0, "kenny@unknown.com", "Kenneth", 1, null, null, true, true, "Odombe", "Kenneth R Odombe", new DateTime(2023, 6, 11, 22, 39, 9, 510, DateTimeKind.Local).AddTicks(9874), "kenny", "R", null, "1234", null, null, "1234567890" },
                    { 2, "123 Unknown Street", "01/1970", "Johanesburg", 1, "kenny@unknown.com", "House", 1, null, null, true, true, "First", "Kenneth R Odombe", new DateTime(2023, 6, 11, 22, 39, 9, 510, DateTimeKind.Local).AddTicks(9994), "firsthouse", "Clan", null, "1234", null, null, "1234567890" },
                    { 3, "123 Unknown Street", "01/1970", "Johanesburg", 2, "kenny@unknown.com", "House", 1, null, null, true, true, "Second", "Kenneth R Odombe", new DateTime(2023, 6, 11, 22, 39, 9, 511, DateTimeKind.Local).AddTicks(9), "secondhouse", "Clan", null, "1234", null, null, "1234567890" }
                });

            migrationBuilder.InsertData(
                table: "PersonRole",
                columns: new[] { "PersonRoleID", "IsActive", "LastUpdatedBy", "LastUpdatedDate", "PersonID", "RoleID" },
                values: new object[,]
                {
                    { 1, true, "Kenneth R Odombe", new DateTime(2023, 6, 11, 22, 39, 9, 511, DateTimeKind.Local).AddTicks(70), 1, 1 },
                    { 2, true, "Kenneth R Odombe", new DateTime(2023, 6, 11, 22, 39, 9, 511, DateTimeKind.Local).AddTicks(81), 2, 3 },
                    { 3, true, "Kenneth R Odombe", new DateTime(2023, 6, 11, 22, 39, 9, 511, DateTimeKind.Local).AddTicks(91), 3, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClanHouse_ClanID",
                table: "ClanHouse",
                column: "ClanID");

            migrationBuilder.CreateIndex(
                name: "IX_Person_GenderID",
                table: "Person",
                column: "GenderID");

            migrationBuilder.CreateIndex(
                name: "IX_PersonClanHouseRequest_ClanHouseID",
                table: "PersonClanHouseRequest",
                column: "ClanHouseID");

            migrationBuilder.CreateIndex(
                name: "IX_PersonClanHouseRequest_PersonID",
                table: "PersonClanHouseRequest",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "IX_PersonClanHouseRequest_RequestTypeID",
                table: "PersonClanHouseRequest",
                column: "RequestTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_PersonRole_PersonID",
                table: "PersonRole",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "IX_PersonRole_RoleID",
                table: "PersonRole",
                column: "RoleID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonClanHouseRequest");

            migrationBuilder.DropTable(
                name: "PersonRole");

            migrationBuilder.DropTable(
                name: "ClanHouse");

            migrationBuilder.DropTable(
                name: "RequestType");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Clan");

            migrationBuilder.DropTable(
                name: "Gender");
        }
    }
}
