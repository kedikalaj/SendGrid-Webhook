using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebhookTest.Migrations
{
    /// <inheritdoc />
    public partial class initial3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Emails",
                table: "Emails");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "Emails");

            migrationBuilder.AddColumn<string>(
                name: "MID",
                table: "Emails",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MID",
                table: "Emails");

            migrationBuilder.AddColumn<string>(
                name: "ID",
                table: "Emails",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Emails",
                table: "Emails",
                column: "ID");
        }
    }
}
