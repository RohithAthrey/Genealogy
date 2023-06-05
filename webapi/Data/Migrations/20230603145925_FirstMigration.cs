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
                name: "Role",
                columns: table => new
                {
                    RoleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "varchar(32)", nullable: false),
                    RoleDesc = table.Column<string>(type: "varchar(64)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "ClanHouse",
                columns: table => new
                {
                    ClanHouseID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClanHouseName = table.Column<string>(type: "varchar(32)", nullable: false),
                    ClanID = table.Column<int>(type: "int", nullable: false)
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
                    ProfilePicPath = table.Column<string>(type: "varchar(128)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsUser = table.Column<bool>(type: "bit", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedBy = table.Column<string>(type: "varchar(128)", nullable: false),
                    RegisterPara = table.Column<string>(type: "varchar(MAX)", nullable: true),
                    Grandparents = table.Column<string>(type: "varchar(128)", nullable: true),
                    Parents = table.Column<string>(type: "varchar(128)", nullable: true),
                    GreatGrandparents = table.Column<string>(type: "varchar(128)", nullable: true)
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
                    PersonClanHouseRequestID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonID = table.Column<int>(type: "int", nullable: false),
                    ClanHouseID = table.Column<int>(type: "int", nullable: false),
                    RequestTypeID = table.Column<int>(type: "int", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedBy = table.Column<string>(type: "varchar(128)", nullable: false)
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
                    PersonRoleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonID = table.Column<int>(type: "int", nullable: false),
                    RoleID = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedBy = table.Column<string>(type: "varchar(128)", nullable: false)
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
                    { 2, "User role", "User" }
                });

            migrationBuilder.InsertData(
                table: "ClanHouse",
                columns: new[] { "ClanHouseID", "ClanHouseName", "ClanID" },
                values: new object[,]
                {
                    { 1, "FirstClanHouse", 1 },
                    { 2, "SecondClanHouse", 1 },
                    { 3, "SecondClan2House", 2 },
                    { 4, "SecondClan2House", 2 }
                });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "PersonID", "Address", "BirthDate", "City", "Email", "FirstName", "GenderID", "Grandparents", "GreatGrandparents", "IsActive", "IsUser", "LastName", "LastUpdatedBy", "LastUpdatedDate", "LoginId", "MiddleName", "Parents", "Password", "ProfilePicPath", "RegisterPara", "Telephone" },
                values: new object[] { 1, "123 Unknown Street", "01/1970", "Johanesburg", "kenny@unknown.com", "Kenneth", 1, null, null, true, true, "Odombe", "Kenneth R Odombe", new DateTime(2023, 6, 3, 10, 59, 24, 612, DateTimeKind.Local).AddTicks(6789), "kenny", "R", null, "1234", null, null, "1234567890" });

            migrationBuilder.InsertData(
                table: "PersonRole",
                columns: new[] { "PersonRoleID", "IsActive", "LastUpdatedBy", "LastUpdatedDate", "PersonID", "RoleID" },
                values: new object[] { 1, true, "Kenneth R Odombe", new DateTime(2023, 6, 3, 10, 59, 24, 612, DateTimeKind.Local).AddTicks(7099), 1, 1 });

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
