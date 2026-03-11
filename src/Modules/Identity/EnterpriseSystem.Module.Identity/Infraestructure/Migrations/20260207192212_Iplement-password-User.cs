using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnterpriseSystem.Module.Identity.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class IplementpasswordUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                schema: "identity",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                schema: "identity",
                table: "Users");
        }
    }
}
