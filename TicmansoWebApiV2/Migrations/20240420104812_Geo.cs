using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicmansoWebApiV2.Migrations
{
    /// <inheritdoc />
    public partial class Geo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.AddColumn<double>(
                name: "DepartureLatitude",
                table: "Attendances",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "DepartureLongitude",
                table: "Attendances",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "EntryLatitude",
                table: "Attendances",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "EntryLongitude",
                table: "Attendances",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.DropColumn(
                name: "DepartureLatitude",
                table: "Attendances");

            migrationBuilder.DropColumn(
                name: "DepartureLongitude",
                table: "Attendances");

            migrationBuilder.DropColumn(
                name: "EntryLatitude",
                table: "Attendances");

            migrationBuilder.DropColumn(
                name: "EntryLongitude",
                table: "Attendances");


        }
    }
}
