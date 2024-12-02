using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AngularCOMP584.Server.Migrations
{
    /// <inheritdoc />
    public partial class Identityo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "game_companies",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "game_companies",
                newName: "CompanyId");
        }
    }
}
