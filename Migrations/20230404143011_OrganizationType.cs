using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _10fwd_service.Migrations
{
    /// <inheritdoc />
    public partial class OrganizationType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Organizations",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Organizations");
        }
    }
}
