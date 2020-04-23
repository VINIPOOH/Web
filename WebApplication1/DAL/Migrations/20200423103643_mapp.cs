﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class mapp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "BornDate",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FIO",
                table: "Users",
                nullable: false);

            migrationBuilder.AddColumn<int>(
                name: "ApartmentSpace",
                table: "Apartments",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BornDate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FIO",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ApartmentSpace",
                table: "Apartments");
        }
    }
}
