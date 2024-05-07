using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicmansoWebApiV2.Migrations
{
    /// <inheritdoc />
    public partial class ChatmessageModification3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ChatMessages_SenderId_ReceiverId",
                table: "ChatMessages");

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessages_SenderId",
                table: "ChatMessages",
                column: "SenderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ChatMessages_SenderId",
                table: "ChatMessages");

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessages_SenderId_ReceiverId",
                table: "ChatMessages",
                columns: new[] { "SenderId", "ReceiverId" },
                unique: true);
        }
    }
}
