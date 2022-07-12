using Microsoft.EntityFrameworkCore.Migrations;

namespace Money.EF.Migrations
{
    public partial class SubcategoryDefaultTransaction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DefaultTransactionId",
                table: "Subcategories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SubcategoryId",
                table: "DefaultTransactions",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DefaultTransactionId",
                table: "Subcategories");

            migrationBuilder.DropColumn(
                name: "SubcategoryId",
                table: "DefaultTransactions");
        }
    }
}
