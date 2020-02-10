using Microsoft.EntityFrameworkCore.Migrations;

namespace Agency.Migrations
{
    public partial class pocetak : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "Contract",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Price",
                table: "Contract",
                type: "real",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}
