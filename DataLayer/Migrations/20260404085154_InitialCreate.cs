using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Studios_Studio_id1",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_Studio_id1",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "Studio_id1",
                table: "Games");

            migrationBuilder.CreateIndex(
                name: "IX_Games_Studio_id",
                table: "Games",
                column: "Studio_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Studios_Studio_id",
                table: "Games",
                column: "Studio_id",
                principalTable: "Studios",
                principalColumn: "Studio_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Studios_Studio_id",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_Studio_id",
                table: "Games");

            migrationBuilder.AddColumn<int>(
                name: "Studio_id1",
                table: "Games",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Games_Studio_id1",
                table: "Games",
                column: "Studio_id1");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Studios_Studio_id1",
                table: "Games",
                column: "Studio_id1",
                principalTable: "Studios",
                principalColumn: "Studio_id");
        }
    }
}
