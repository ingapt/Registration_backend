﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Registration_backend.Data;

#nullable disable

namespace Registrationbackend.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230123034657_CreateNewEntities")]
    partial class CreateNewEntities
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Registration_backend.Models.Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AddressOfUserInfoId")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FlatNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HouseNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AddressOfUserInfoId")
                        .IsUnique()
                        .HasFilter("[AddressOfUserInfoId] IS NOT NULL");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("Registration_backend.Models.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Registration_backend.Models.Entities.UserInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PersonalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Photo")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserInfoOfUserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserInfoOfUserId")
                        .IsUnique()
                        .HasFilter("[UserInfoOfUserId] IS NOT NULL");

                    b.ToTable("UsersInfo");
                });

            modelBuilder.Entity("Registration_backend.Models.Entities.Address", b =>
                {
                    b.HasOne("Registration_backend.Models.Entities.UserInfo", "UserInfo")
                        .WithOne("Address")
                        .HasForeignKey("Registration_backend.Models.Entities.Address", "AddressOfUserInfoId");

                    b.Navigation("UserInfo");
                });

            modelBuilder.Entity("Registration_backend.Models.Entities.UserInfo", b =>
                {
                    b.HasOne("Registration_backend.Models.Entities.User", "User")
                        .WithOne("UserInfo")
                        .HasForeignKey("Registration_backend.Models.Entities.UserInfo", "UserInfoOfUserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Registration_backend.Models.Entities.User", b =>
                {
                    b.Navigation("UserInfo")
                        .IsRequired();
                });

            modelBuilder.Entity("Registration_backend.Models.Entities.UserInfo", b =>
                {
                    b.Navigation("Address")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
