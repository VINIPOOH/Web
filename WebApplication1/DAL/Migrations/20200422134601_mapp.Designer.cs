﻿﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication1.Dal;

namespace WebApplication1.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20200422134601_mapp")]
    partial class mapp
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0-preview.2.20159.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("DAL.Dto.Apartment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("HouseId")
                        .HasColumnType("int");

                    b.Property<int?>("HouseId1")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HouseId");

                    b.HasIndex("HouseId1");

                    b.ToTable("Apartments");
                });

            modelBuilder.Entity("DAL.Dto.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("CountryId")
                        .HasColumnType("int");

                    b.Property<int?>("CountryId1")
                        .HasColumnType("int");

                    b.Property<string>("SityName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.HasIndex("CountryId1");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("DAL.Dto.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("DAL.Dto.House", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("HouseNumber")
                        .HasColumnType("int");

                    b.Property<int?>("StreetId")
                        .HasColumnType("int");

                    b.Property<int?>("StreetId1")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StreetId");

                    b.HasIndex("StreetId1");

                    b.ToTable("Houses");
                });

            modelBuilder.Entity("DAL.Dto.Street", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("CityId")
                        .HasColumnType("int");

                    b.Property<int?>("CityId1")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("CityId1");

                    b.ToTable("Streets");
                });

            modelBuilder.Entity("DAL.Dto.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DAL.Dto.UserApartment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("ApartmentId")
                        .HasColumnType("int");

                    b.Property<int?>("ApartmentId1")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId1")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ApartmentId");

                    b.HasIndex("ApartmentId1");

                    b.HasIndex("UserId");

                    b.HasIndex("UserId1");

                    b.ToTable("UserApartment");
                });

            modelBuilder.Entity("DAL.Dto.Apartment", b =>
                {
                    b.HasOne("DAL.Dto.House", null)
                        .WithMany("Apartments")
                        .HasForeignKey("HouseId");

                    b.HasOne("DAL.Dto.House", null)
                        .WithMany()
                        .HasForeignKey("HouseId1");
                });

            modelBuilder.Entity("DAL.Dto.City", b =>
                {
                    b.HasOne("DAL.Dto.Country", null)
                        .WithMany("Cities")
                        .HasForeignKey("CountryId");

                    b.HasOne("DAL.Dto.Country", null)
                        .WithMany()
                        .HasForeignKey("CountryId1");
                });

            modelBuilder.Entity("DAL.Dto.House", b =>
                {
                    b.HasOne("DAL.Dto.Street", null)
                        .WithMany("Houses")
                        .HasForeignKey("StreetId");

                    b.HasOne("DAL.Dto.Street", null)
                        .WithMany()
                        .HasForeignKey("StreetId1");
                });

            modelBuilder.Entity("DAL.Dto.Street", b =>
                {
                    b.HasOne("DAL.Dto.City", null)
                        .WithMany("Streets")
                        .HasForeignKey("CityId");

                    b.HasOne("DAL.Dto.City", null)
                        .WithMany()
                        .HasForeignKey("CityId1");
                });

            modelBuilder.Entity("DAL.Dto.UserApartment", b =>
                {
                    b.HasOne("DAL.Dto.Apartment", "Apartment")
                        .WithMany("UserApartments")
                        .HasForeignKey("ApartmentId");

                    b.HasOne("DAL.Dto.Apartment", null)
                        .WithMany()
                        .HasForeignKey("ApartmentId1");

                    b.HasOne("DAL.Dto.User", "User")
                        .WithMany("UserApartments")
                        .HasForeignKey("UserId");

                    b.HasOne("DAL.Dto.User", null)
                        .WithMany()
                        .HasForeignKey("UserId1");
                });
#pragma warning restore 612, 618
        }
    }
}