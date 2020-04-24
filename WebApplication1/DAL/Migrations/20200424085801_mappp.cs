using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class mappp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apartments_Houses_HouseId",
                table: "Apartments");

            migrationBuilder.DropForeignKey(
                name: "FK_Streets_Cities_CityId",
                table: "Streets");

            migrationBuilder.DropColumn(
                name: "ApartmentId",
                table: "Streets");

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "Streets",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "HouseId",
                table: "Apartments",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Apartments_Houses_HouseId",
                table: "Apartments",
                column: "HouseId",
                principalTable: "Houses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Streets_Cities_CityId",
                table: "Streets",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apartments_Houses_HouseId",
                table: "Apartments");

            migrationBuilder.DropForeignKey(
                name: "FK_Streets_Cities_CityId",
                table: "Streets");

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "Streets",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "ApartmentId",
                table: "Streets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "HouseId",
                table: "Apartments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Apartments_Houses_HouseId",
                table: "Apartments",
                column: "HouseId",
                principalTable: "Houses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Streets_Cities_CityId",
                table: "Streets",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
