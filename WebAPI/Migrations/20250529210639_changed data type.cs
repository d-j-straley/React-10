using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class changeddatatype : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "Houses",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "ID",
                keyValue: 1,
                column: "Price",
                value: 900000);

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "ID",
                keyValue: 2,
                column: "Price",
                value: 500000);

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "ID",
                keyValue: 3,
                column: "Price",
                value: 200500);

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "ID",
                keyValue: 4,
                column: "Price",
                value: 259500);

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "ID",
                keyValue: 5,
                column: "Price",
                value: 400500);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Houses",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "ID",
                keyValue: 1,
                column: "Price",
                value: 900000m);

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "ID",
                keyValue: 2,
                column: "Price",
                value: 500000m);

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "ID",
                keyValue: 3,
                column: "Price",
                value: 200500m);

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "ID",
                keyValue: 4,
                column: "Price",
                value: 259500m);

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "ID",
                keyValue: 5,
                column: "Price",
                value: 400500m);
        }
    }
}
