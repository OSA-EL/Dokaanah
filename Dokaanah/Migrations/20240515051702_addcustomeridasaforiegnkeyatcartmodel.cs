using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dokaanah.Migrations
{
    /// <inheritdoc />
    public partial class addcustomeridasaforiegnkeyatcartmodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Custid",
                table: "Carts",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Custid",
                table: "Carts");
        }
    }
}
