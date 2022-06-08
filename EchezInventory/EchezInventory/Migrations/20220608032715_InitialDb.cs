using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EchezInventory.Migrations
{
    public partial class InitialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserEmailAndPasswords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    ExtensionNumber = table.Column<int>(type: "int", nullable: true),
                    ExtensionPassword = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: true),
                    Location = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEmailAndPasswords", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserEmailAndPasswords_Email",
                table: "UserEmailAndPasswords",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserEmailAndPasswords");
        }
    }
}
