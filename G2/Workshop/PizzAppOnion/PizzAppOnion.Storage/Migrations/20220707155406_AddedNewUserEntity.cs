using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzAppOnion.Storage.Migrations
{
    public partial class AddedNewUserEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserFk",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserFk",
                table: "Orders",
                column: "UserFk");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_User_UserFk",
                table: "Orders",
                column: "UserFk",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_User_UserFk",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropIndex(
                name: "IX_Orders_UserFk",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "UserFk",
                table: "Orders");
        }
    }
}
