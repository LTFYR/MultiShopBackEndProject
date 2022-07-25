using Microsoft.EntityFrameworkCore.Migrations;

namespace MultiShopBackEndProject.Migrations
{
    public partial class createdClothesCategoriesManytoManybetweenthemClotheImagesCloseInformationandDescriptionSizeColor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClotheDescriptions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClotheDescriptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClotheInformation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Information = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClotheInformation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sizes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sizes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clothes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Image = table.Column<string>(nullable: true),
                    ClotheDescriptionId = table.Column<int>(nullable: false),
                    ClotheInformationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clothes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clothes_ClotheDescriptions_ClotheDescriptionId",
                        column: x => x.ClotheDescriptionId,
                        principalTable: "ClotheDescriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Clothes_ClotheInformation_ClotheInformationId",
                        column: x => x.ClotheInformationId,
                        principalTable: "ClotheInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClotheCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(nullable: false),
                    ClotheId = table.Column<int>(nullable: false)
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

            migrationBuilder.CreateTable(
                name: "ClotheImages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(nullable: true),
                    Alt = table.Column<string>(nullable: true),
                    ClotheId = table.Column<string>(nullable: true),
                    IsMain = table.Column<bool>(nullable: false),
                    ClotheId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClotheImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClotheImages_Clothes_ClotheId1",
                        column: x => x.ClotheId1,
                        principalTable: "Clothes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClotheCategories_CategoryId",
                table: "ClotheCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ClotheCategories_ClotheId",
                table: "ClotheCategories",
                column: "ClotheId");

            migrationBuilder.CreateIndex(
                name: "IX_ClotheImages_ClotheId1",
                table: "ClotheImages",
                column: "ClotheId1");

            migrationBuilder.CreateIndex(
                name: "IX_Clothes_ClotheDescriptionId",
                table: "Clothes",
                column: "ClotheDescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Clothes_ClotheInformationId",
                table: "Clothes",
                column: "ClotheInformationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClotheCategories");

            migrationBuilder.DropTable(
                name: "ClotheImages");

            migrationBuilder.DropTable(
                name: "Colors");

            migrationBuilder.DropTable(
                name: "Sizes");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Clothes");

            migrationBuilder.DropTable(
                name: "ClotheDescriptions");

            migrationBuilder.DropTable(
                name: "ClotheInformation");
        }
    }
}
