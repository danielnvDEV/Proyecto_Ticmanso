using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicmansoWebApiV2.Migrations
{
    /// <inheritdoc />
    public partial class ChatmessageModification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TicketId",
                table: "ChatMessages",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TicketId",
                table: "ChatMessages");
        }
    }
}
