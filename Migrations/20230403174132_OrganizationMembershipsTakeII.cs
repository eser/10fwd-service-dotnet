using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _10fwd_service.Migrations
{
    /// <inheritdoc />
    public partial class OrganizationMembershipsTakeII : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationMembership_Organizations_OrganizationId",
                table: "OrganizationMembership");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationMembership_Users_UserId",
                table: "OrganizationMembership");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrganizationMembership",
                table: "OrganizationMembership");

            migrationBuilder.RenameTable(
                name: "OrganizationMembership",
                newName: "OrganizationMemberships");

            migrationBuilder.RenameIndex(
                name: "IX_OrganizationMembership_UserId",
                table: "OrganizationMemberships",
                newName: "IX_OrganizationMemberships_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_OrganizationMembership_OrganizationId",
                table: "OrganizationMemberships",
                newName: "IX_OrganizationMemberships_OrganizationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrganizationMemberships",
                table: "OrganizationMemberships",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationMemberships_Organizations_OrganizationId",
                table: "OrganizationMemberships",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationMemberships_Users_UserId",
                table: "OrganizationMemberships",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationMemberships_Organizations_OrganizationId",
                table: "OrganizationMemberships");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationMemberships_Users_UserId",
                table: "OrganizationMemberships");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrganizationMemberships",
                table: "OrganizationMemberships");

            migrationBuilder.RenameTable(
                name: "OrganizationMemberships",
                newName: "OrganizationMembership");

            migrationBuilder.RenameIndex(
                name: "IX_OrganizationMemberships_UserId",
                table: "OrganizationMembership",
                newName: "IX_OrganizationMembership_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_OrganizationMemberships_OrganizationId",
                table: "OrganizationMembership",
                newName: "IX_OrganizationMembership_OrganizationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrganizationMembership",
                table: "OrganizationMembership",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationMembership_Organizations_OrganizationId",
                table: "OrganizationMembership",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationMembership_Users_UserId",
                table: "OrganizationMembership",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
