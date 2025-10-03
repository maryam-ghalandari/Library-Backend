using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace novin_library_backend.Migrations
{
    /// <inheritdoc />
    public partial class W040710 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MemberId",
                table: "Borrows",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Borrows_MemberId",
                table: "Borrows",
                column: "MemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Borrows_Members_MemberId",
                table: "Borrows",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Borrows_Members_MemberId",
                table: "Borrows");

            migrationBuilder.DropIndex(
                name: "IX_Borrows_MemberId",
                table: "Borrows");

            migrationBuilder.DropColumn(
                name: "MemberId",
                table: "Borrows");
        }
    }
}
