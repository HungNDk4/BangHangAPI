using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BangHangAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddSoLuongTon : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SoLuongTon",
                table: "HangHoa",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SoLuongTon",
                table: "HangHoa");
        }
    }
}
