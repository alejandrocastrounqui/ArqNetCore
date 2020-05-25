using Microsoft.EntityFrameworkCore.Migrations;

namespace ArqNetCore.Migrations
{
    public partial class CreateAccounts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: true),
                    Enable = table.Column<bool>(nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Email);
                }
            );

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Accounts_Email",
                table: "Users",
                column: "Email",
                principalTable: "Accounts",
                principalColumn: "Email",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Accounts_Email",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Accounts",
                table: "Accounts");

            migrationBuilder.RenameTable(
                name: "Accounts",
                newName: "Account");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Account",
                table: "Account",
                column: "Email");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Account_Email",
                table: "Users",
                column: "Email",
                principalTable: "Account",
                principalColumn: "Email",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
