using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace novin_library_backend.Migrations
{
    /// <inheritdoc />
    public partial class W04041903 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Guid",
                table: "Members",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Guid",
                table: "Borrows",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Guid",
                table: "Books",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Guid",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "Borrows");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "Books");
        }
    }
}
