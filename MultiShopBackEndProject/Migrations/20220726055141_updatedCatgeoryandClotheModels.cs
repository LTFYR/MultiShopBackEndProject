using Microsoft.EntityFrameworkCore.Migrations;

namespace MultiShopBackEndProject.Migrations
{
    public partial class updatedCatgeoryandClotheModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClotheCategories");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Clothes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Clothes_CategoryId",
                table: "Clothes",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clothes_Categories_CategoryId",
                table: "Clothes",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clothes_Categories_CategoryId",
                table: "Clothes");

            migrationBuilder.DropIndex(
                name: "IX_Clothes_CategoryId",
                table: "Clothes");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Clothes");

            migrationBuilder.CreateTable(
                name: "ClotheCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ClotheId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClotheCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClotheCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClotheCategories_Clothes_ClotheId",
                        column: x => x.ClotheId,
                        principalTable: "Clothes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClotheCategories_CategoryId",
                table: "ClotheCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ClotheCategories_ClotheId",
                table: "ClotheCategories",
                column: "ClotheId");
        }
    }
}
