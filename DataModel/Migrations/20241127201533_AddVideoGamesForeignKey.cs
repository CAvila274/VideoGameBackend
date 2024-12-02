using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AngularCOMP584.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddVideoGamesForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ConsoleId",
                table: "video_games",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_video_games_ConsoleId",
                table: "video_games",
                column: "ConsoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_video_games_game_consoles_ConsoleId",
                table: "video_games",
                column: "ConsoleId",
                principalTable: "game_consoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_video_games_game_consoles_ConsoleId",
                table: "video_games");

            migrationBuilder.DropIndex(
                name: "IX_video_games_ConsoleId",
                table: "video_games");

            migrationBuilder.DropColumn(
                name: "ConsoleId",
                table: "video_games");
        }
    }
}
