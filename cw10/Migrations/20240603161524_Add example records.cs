using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cw10.Migrations
{
    /// <inheritdoc />
    public partial class Addexamplerecords : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "Name" },
                values: new object[] { 1, "User" });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "AccountId", "Email", "FirstName", "LastName", "Phone", "RoleId" },
                values: new object[] { 1, "j@k.com", "Jan", "Kowalski", "999888777", 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1);
        }
    }
}
