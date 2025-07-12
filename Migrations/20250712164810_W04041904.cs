using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace novin_library_backend.Migrations
{
    /// <inheritdoc />
    public partial class W04041904 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "NationalCode",
                table: "Members",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NationalCode",
                table: "Members");
        }
    }
}
