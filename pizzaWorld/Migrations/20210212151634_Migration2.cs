using Microsoft.EntityFrameworkCore.Migrations;

namespace pizzaWorld.Migrations
{
    public partial class Migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizza_Livreur_LivreurId",
                table: "Pizza");

            migrationBuilder.DropIndex(
                name: "IX_Pizza_LivreurId",
                table: "Pizza");

            migrationBuilder.DropColumn(
                name: "LivreurId",
                table: "Pizza");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LivreurId",
                table: "Pizza",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pizza_LivreurId",
                table: "Pizza",
                column: "LivreurId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pizza_Livreur_LivreurId",
                table: "Pizza",
                column: "LivreurId",
                principalTable: "Livreur",
                principalColumn: "LivreurId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
