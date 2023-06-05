﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using webapi.Data;

#nullable disable

namespace webapi.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("webapi.Data.Models.Clan", b =>
                {
                    b.Property<int>("ClanID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClanID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(32)");

                    b.Property<string>("SubTotem")
                        .IsRequired()
                        .HasColumnType("varchar(32)");

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasColumnType("varchar(32)");

                    b.HasKey("ClanID");

                    b.ToTable("Clan");

                    b.HasData(
                        new
                        {
                            ClanID = 1,
                            Name = "Njovu",
                            SubTotem = "Hippopotamus",
                            Symbol = "Elephant"
                        },
                        new
                        {
                            ClanID = 2,
                            Name = "Clan2",
                            SubTotem = "Hippopotamus",
                            Symbol = "Elephant"
                        });
                });

            modelBuilder.Entity("webapi.Data.Models.ClanHouse", b =>
                {
                    b.Property<int>("ClanHouseID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClanHouseID"));

                    b.Property<string>("ClanHouseName")
                        .IsRequired()
                        .HasColumnType("varchar(32)");

                    b.Property<int>("ClanID")
                        .HasColumnType("int");

                    b.HasKey("ClanHouseID");

                    b.HasIndex("ClanID");

                    b.ToTable("ClanHouse");

                    b.HasData(
                        new
                        {
                            ClanHouseID = 1,
                            ClanHouseName = "FirstClanHouse",
                            ClanID = 1
                        },
                        new
                        {
                            ClanHouseID = 2,
                            ClanHouseName = "SecondClanHouse",
                            ClanID = 1
                        },
                        new
                        {
                            ClanHouseID = 3,
                            ClanHouseName = "SecondClan2House",
                            ClanID = 2
                        },
                        new
                        {
                            ClanHouseID = 4,
                            ClanHouseName = "SecondClan2House",
                            ClanID = 2
                        });
                });

            modelBuilder.Entity("webapi.Data.Models.Gender", b =>
                {
                    b.Property<int>("GenderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GenderID"));

                    b.Property<string>("GenderCode")
                        .IsRequired()
                        .HasColumnType("varchar(16)");

                    b.Property<string>("GenderValue")
                        .IsRequired()
                        .HasColumnType("varchar(32)");

                    b.HasKey("GenderID");

                    b.ToTable("Gender");

                    b.HasData(
                        new
                        {
                            GenderID = 1,
                            GenderCode = "M",
                            GenderValue = "Male"
                        },
                        new
                        {
                            GenderID = 2,
                            GenderCode = "F",
                            GenderValue = "Female"
                        });
                });

            modelBuilder.Entity("webapi.Data.Models.Person", b =>
                {
                    b.Property<int>("PersonID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PersonID"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("varchar(64)");

                    b.Property<string>("BirthDate")
                        .IsRequired()
                        .HasColumnType("varchar(16)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("varchar(32)");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(64)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("varchar(32)");

                    b.Property<int>("GenderID")
                        .HasColumnType("int");

                    b.Property<string>("Grandparents")
                        .HasColumnType("varchar(128)");

                    b.Property<string>("GreatGrandparents")
                        .HasColumnType("varchar(128)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsUser")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("varchar(32)");

                    b.Property<string>("LastUpdatedBy")
                        .IsRequired()
                        .HasColumnType("varchar(128)");

                    b.Property<DateTime>("LastUpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LoginId")
                        .IsRequired()
                        .HasColumnType("varchar(64)");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasColumnType("varchar(32)");

                    b.Property<string>("Parents")
                        .HasColumnType("varchar(128)");

                    b.Property<string>("Password")
                        .HasColumnType("varchar(128)");

                    b.Property<string>("ProfilePicPath")
                        .HasColumnType("varchar(128)");

                    b.Property<string>("RegisterPara")
                        .HasColumnType("varchar(MAX)");

                    b.Property<string>("Telephone")
                        .HasColumnType("varchar(16)");

                    b.HasKey("PersonID");

                    b.HasIndex("GenderID");

                    b.ToTable("Person");

                    b.HasData(
                        new
                        {
                            PersonID = 1,
                            Address = "123 Unknown Street",
                            BirthDate = "01/1970",
                            City = "Johanesburg",
                            Email = "kenny@unknown.com",
                            FirstName = "Kenneth",
                            GenderID = 1,
                            IsActive = true,
                            IsUser = true,
                            LastName = "Odombe",
                            LastUpdatedBy = "Kenneth R Odombe",
                            LastUpdatedDate = new DateTime(2023, 6, 3, 13, 59, 19, 36, DateTimeKind.Local).AddTicks(7844),
                            LoginId = "kenny",
                            MiddleName = "R",
                            Password = "1234",
                            Telephone = "1234567890"
                        });
                });

            modelBuilder.Entity("webapi.Data.Models.PersonClanHouseRequest", b =>
                {
                    b.Property<int>("PersonClanHouseRequestID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PersonClanHouseRequestID"));

                    b.Property<int>("ClanHouseID")
                        .HasColumnType("int");

                    b.Property<string>("LastUpdatedBy")
                        .IsRequired()
                        .HasColumnType("varchar(128)");

                    b.Property<DateTime>("LastUpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PersonID")
                        .HasColumnType("int");

                    b.Property<int>("RequestTypeID")
                        .HasColumnType("int");

                    b.HasKey("PersonClanHouseRequestID");

                    b.HasIndex("ClanHouseID");

                    b.HasIndex("PersonID");

                    b.HasIndex("RequestTypeID");

                    b.ToTable("PersonClanHouseRequest");
                });

            modelBuilder.Entity("webapi.Data.Models.PersonRole", b =>
                {
                    b.Property<int>("PersonRoleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PersonRoleID"));

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LastUpdatedBy")
                        .IsRequired()
                        .HasColumnType("varchar(128)");

                    b.Property<DateTime>("LastUpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PersonID")
                        .HasColumnType("int");

                    b.Property<int>("RoleID")
                        .HasColumnType("int");

                    b.HasKey("PersonRoleID");

                    b.HasIndex("PersonID");

                    b.HasIndex("RoleID");

                    b.ToTable("PersonRole");

                    b.HasData(
                        new
                        {
                            PersonRoleID = 1,
                            IsActive = true,
                            LastUpdatedBy = "Kenneth R Odombe",
                            LastUpdatedDate = new DateTime(2023, 6, 3, 13, 59, 19, 36, DateTimeKind.Local).AddTicks(8035),
                            PersonID = 1,
                            RoleID = 1
                        });
                });

            modelBuilder.Entity("webapi.Data.Models.RequestType", b =>
                {
                    b.Property<int>("RequestTypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RequestTypeID"));

                    b.Property<string>("RequestTypeCode")
                        .IsRequired()
                        .HasColumnType("varchar(16)");

                    b.Property<string>("RequestTypeValue")
                        .IsRequired()
                        .HasColumnType("varchar(32)");

                    b.HasKey("RequestTypeID");

                    b.ToTable("RequestType");

                    b.HasData(
                        new
                        {
                            RequestTypeID = 1,
                            RequestTypeCode = "R",
                            RequestTypeValue = "Requested"
                        },
                        new
                        {
                            RequestTypeID = 2,
                            RequestTypeCode = "A",
                            RequestTypeValue = "Approved"
                        },
                        new
                        {
                            RequestTypeID = 3,
                            RequestTypeCode = "D",
                            RequestTypeValue = "Declined"
                        });
                });

            modelBuilder.Entity("webapi.Data.Models.Role", b =>
                {
                    b.Property<int>("RoleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleID"));

                    b.Property<string>("RoleDesc")
                        .IsRequired()
                        .HasColumnType("varchar(64)");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("varchar(32)");

                    b.HasKey("RoleID");

                    b.ToTable("Role");

                    b.HasData(
                        new
                        {
                            RoleID = 1,
                            RoleDesc = "Admin role",
                            RoleName = "Admin"
                        },
                        new
                        {
                            RoleID = 2,
                            RoleDesc = "User role",
                            RoleName = "User"
                        });
                });

            modelBuilder.Entity("webapi.Data.Models.ClanHouse", b =>
                {
                    b.HasOne("webapi.Data.Models.Clan", "Clan")
                        .WithMany()
                        .HasForeignKey("ClanID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Clan");
                });

            modelBuilder.Entity("webapi.Data.Models.Person", b =>
                {
                    b.HasOne("webapi.Data.Models.Gender", "Gender")
                        .WithMany()
                        .HasForeignKey("GenderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gender");
                });

            modelBuilder.Entity("webapi.Data.Models.PersonClanHouseRequest", b =>
                {
                    b.HasOne("webapi.Data.Models.ClanHouse", "ClanHouse")
                        .WithMany()
                        .HasForeignKey("ClanHouseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("webapi.Data.Models.Person", "Person")
                        .WithMany("PersonClanHouseRequests")
                        .HasForeignKey("PersonID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("webapi.Data.Models.RequestType", "RequestType")
                        .WithMany()
                        .HasForeignKey("RequestTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClanHouse");

                    b.Navigation("Person");

                    b.Navigation("RequestType");
                });

            modelBuilder.Entity("webapi.Data.Models.PersonRole", b =>
                {
                    b.HasOne("webapi.Data.Models.Person", "Person")
                        .WithMany("PersonRoles")
                        .HasForeignKey("PersonID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("webapi.Data.Models.Role", "Role")
                        .WithMany("PersonRoles")
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("webapi.Data.Models.Person", b =>
                {
                    b.Navigation("PersonClanHouseRequests");

                    b.Navigation("PersonRoles");
                });

            modelBuilder.Entity("webapi.Data.Models.Role", b =>
                {
                    b.Navigation("PersonRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
