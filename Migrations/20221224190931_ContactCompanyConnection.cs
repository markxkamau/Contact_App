using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContactApp.Migrations
{
    /// <inheritdoc />
    public partial class ContactCompanyConnection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Company_Contact_contactId",
                table: "Company");

            migrationBuilder.DropIndex(
                name: "IX_Company_contactId",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "contactId",
                table: "Company");

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Contact",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contact_CompanyId",
                table: "Contact",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contact_Company_CompanyId",
                table: "Contact",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contact_Company_CompanyId",
                table: "Contact");

            migrationBuilder.DropIndex(
                name: "IX_Contact_CompanyId",
                table: "Contact");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Contact");

            migrationBuilder.AddColumn<int>(
                name: "contactId",
                table: "Company",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Company_contactId",
                table: "Company",
                column: "contactId");

            migrationBuilder.AddForeignKey(
                name: "FK_Company_Contact_contactId",
                table: "Company",
                column: "contactId",
                principalTable: "Contact",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
