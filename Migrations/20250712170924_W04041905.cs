using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace novin_library_backend.Migrations
{
    /// <inheritdoc />
    public partial class W04041905 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Members",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Mobile",
                table: "Members",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Phone",
                table: "Members",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "Mobile",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Members");
        }
    }
}
